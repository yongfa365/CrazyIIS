using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        List<String> AllUsedUser()
        {
            List<String> list = new List<String>();
            string MetaBase = File.ReadAllText(Comm.MetaBasePath());
            MatchCollection _AnonymousUserName = Regex.Matches(MetaBase, @"AnonymousUserName=""(.+?)""");
            foreach (Match item in _AnonymousUserName)
            {
                if (!list.Contains(item.Groups[1].Value))
                {
                    list.Add(item.Groups[1].Value);
                }
            }
            return list;

        }

        private void btnUserSearch_Click(object sender, EventArgs e)
        {
            dgvUsers.Rows.Clear();

            List<String> list = AllUsedUser();
            List<String> list2 = WinNT.User.List();
            list2.Remove("__vmware_user__");
            list2.Remove("Administrator");
            list2.Remove("ASPNET");
            list2.Remove("Guest");
            list2.Remove("SUPPORT_388945a0");
            list2.Remove("IWAM_" + Environment.MachineName.ToUpper());
            list2.Remove("IUSR_" + Environment.MachineName.ToUpper());

            foreach (string user in list2)
            {

                if (txtUserName.Text.Trim() != "")
                {
                    if (!user.Contains(txtUserName.Text.Trim()))
                    {
                        continue;

                    }
                }

                if (chkNoUse.Checked)
                {
                    if (list.Contains(user))
                    {
                        continue;

                    }
                }
                dgvUsers.Rows.Add(false, user);

            }



            lblResult.Text = "共：" + dgvUsers.Rows.Count + "条";

        }


        private void btnUserSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvUsers.RowCount; i++)
            {
                dgvUsers[0, i].Value = true;
            }
        }

        private void btnUserSelectOther_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvUsers.RowCount; i++)
            {
                dgvUsers[0, i].Value = !Convert.ToBoolean(dgvUsers[0, i].Value);
            }
        }

        private void btnUserDelete_Click(object sender, EventArgs e)
        {
            WinNT.NetUser user = new WinNT.NetUser();
            for (int i = 0; i < dgvUsers.RowCount; i++)
            {
                user.UserDelete(dgvUsers[1, i].Value.ToString());
            }
            dgvUsers.Rows.Clear();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {

        }

        private void btnOneWebOneUser_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();

            //路径，用户名，密码
            WinNT.NetUser User = new WinNT.NetUser();
            DataTable dtUser = Comm.GetAllWebInfo();

            dtUser.Columns["AppPoolId"].ColumnName = "U";
            dtUser.Columns["ServerBindings"].ColumnName = "P";
            Dictionary<string, string> AllUsers = new Dictionary<string, string>();

            for (int i = 0; i < dtUser.Rows.Count; i++)
            {
                string AnonymousUserName = txtUserNamePre.Text.Trim() + Regex.Replace(dtUser.Rows[i]["Web"].ToString(), @"\.|-", "_");
                string AnonymousUserPass = "";
                if (AnonymousUserName.Length > 20)
                {
                    AnonymousUserName = AnonymousUserName.Substring(0, 20);
                }
                if (AllUsers.ContainsKey(AnonymousUserName))
                {
                    AnonymousUserPass = AllUsers[AnonymousUserName];
                }
                else
                {
                    AnonymousUserPass = Comm.Random(Convert.ToInt32(txtPasswordNumber.Value));
                    AllUsers.Add(AnonymousUserName, AnonymousUserPass);
                }
                dtUser.Rows[i]["U"] = AnonymousUserName;
                dtUser.Rows[i]["P"] = AnonymousUserPass;
            }

            #region 删除所有要删除的用户
            {
                backgroundWorker1.ReportProgress(25, "将要删除用户" + sp.ElapsedMilliseconds.ToString());
                List<String> _NowUsers = WinNT.User.List();
                foreach (string item in AllUsers.Keys)
                {
                    if (_NowUsers.Contains(item))
                    {
                        backgroundWorker1.ReportProgress(25, "正在删除用户：" + item);
                        User.UserDelete(item);
                    }
                }
                _NowUsers = null;
                backgroundWorker1.ReportProgress(28, "删除用户完成" + sp.ElapsedMilliseconds.ToString());
            }
            #endregion

            #region 创建所有要创建的用户
            {
                backgroundWorker1.ReportProgress(25, "将要创建用户" + sp.ElapsedMilliseconds.ToString());
                foreach (KeyValuePair<string, string> item in AllUsers)
                {
                    backgroundWorker1.ReportProgress(50, "正在创建匿名用户：" + item.Key);
                    User.UserAdd(item.Key, item.Value, null);
                }

                backgroundWorker1.ReportProgress(50, "创建匿名用户OK" + sp.ElapsedMilliseconds.ToString());
            }
            #endregion

            #region 匿名用户给网站
            {
                backgroundWorker1.ReportProgress(50, "将要 给网站添加匿名用户" + sp.ElapsedMilliseconds.ToString());

                IISConfig.Metabase metabase = new IISConfig.Metabase();
                metabase.OpenLocalMachine();

                IISConfig.IKey key = metabase.GetKeyFromPath("/LM/W3SVC");

                IISConfig.Record recordU = key.GetRecord(6020);
                IISConfig.Record recordP = key.GetRecord(6021);


                for (int i = 0; i < dtUser.Rows.Count; i++)
                {
                    key = metabase.GetKeyFromPath("/LM/W3SVC/" + dtUser.Rows[i]["Id"].ToString() + "/root");
                    //用户名存在时，设置密码
                    recordU.Data = dtUser.Rows[i]["U"].ToString();
                    recordP.Data = dtUser.Rows[i]["P"].ToString();
                    key.SetRecord(recordU);
                    key.SetRecord(recordP);

                }

                backgroundWorker1.ReportProgress(50, "给网站添加匿名用户完成" + sp.ElapsedMilliseconds.ToString());
            }
            #endregion

            #region 取网站路径及对应的用户名，如果路径存在，则加权限
            {
                backgroundWorker1.ReportProgress(50, "将要给目录加权限" + sp.ElapsedMilliseconds.ToString());

                for (int i = 0; i < dtUser.Rows.Count; i++)
                {
                    string NowPath = dtUser.Rows[i]["Path"].ToString();
                    if (Directory.Exists(NowPath))
                    {
                        backgroundWorker1.ReportProgress(50, "正在给目录 “" + NowPath + "” 加权限" + sp.ElapsedMilliseconds.ToString());
                        NTFS.ACL.Add(NowPath, dtUser.Rows[i]["U"].ToString(), NTFS.ACL.Roles.FullControl);
                        NTFS.ACL.DelErr(NowPath);
                    }
                }
                backgroundWorker1.ReportProgress(50, "给目录加权限完成" + sp.ElapsedMilliseconds.ToString());
            }
            #endregion

            sp.Stop();
            backgroundWorker1.ReportProgress(100, "操作完成 共用时：" + sp.ElapsedMilliseconds / 1000 + "s");


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel2.Text = e.UserState.ToString();

        }





        private void btnResetPassword_Click(object sender, EventArgs e)
        {

            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            WinNT.NetUser User = new WinNT.NetUser();
            Dictionary<string, string> AllUsers = new Dictionary<string, string>();

            string MetaBase = File.ReadAllText(Comm.MetaBasePath());
            #region 取得所有匿名用户并重新给他们密码
            {
                MatchCollection _AnonymousUserName = Regex.Matches(MetaBase, @"AnonymousUserName=""(.+?)""");
                for (int i = 0; i < _AnonymousUserName.Count; i++)
                {
                    Match item = _AnonymousUserName[i];
                    if (!AllUsers.ContainsKey(item.Groups[1].Value))
                    {
                        AllUsers.Add(item.Groups[1].Value, Comm.Random(i, 10));
                    }
                }
            }
            #endregion

            #region 改用户密码
            foreach (var item in AllUsers)
            {
                backgroundWorker2.ReportProgress(50, "正在修改用户" + item.Key + "的密码" + sp.ElapsedMilliseconds.ToString());

                User.UserChangePassword(item.Key, item.Value);
            }
            #endregion

            #region 更新网站的匿名用户密码
            {
                backgroundWorker2.ReportProgress(50, "将要 给网站添加匿名用户" + sp.ElapsedMilliseconds.ToString());

                IISConfig.Metabase metabase = new IISConfig.Metabase();
                metabase.OpenLocalMachine();

                IISConfig.IKey key = metabase.GetKeyFromPath("/LM/W3SVC");
                IISConfig.Record record = key.GetRecord(6021);

                //更新"/LM/W3SVC"的默认用户密码
                record.Data = AllUsers[key.GetRecord(6020).Data.ToString()];
                key.SetRecord(record);



                MatchCollection matchs = Regex.Matches(MetaBase, @"Location\s*=\s*""(/LM/W3SVC/\d+/root)""", RegexOptions.IgnoreCase);
                foreach (Match item in matchs)
                {
                    key = metabase.GetKeyFromPath(item.Groups[1].Value);
                    if (key.GetRecord(6020) != null)
                    {
                        //用户名存在时，设置密码
                        record.Data = AllUsers[key.GetRecord(6020).Data.ToString()];
                        key.SetRecord(record);
                    }
                    else
                    {
                        //用户名不存在时，删除密码
                        if (key.GetRecord(6021) != null)
                        {
                            key.DeleteRecord(6021);
                        }
                    }
                }



                backgroundWorker2.ReportProgress(50, "给网站添加匿名用户完成" + sp.ElapsedMilliseconds.ToString());
            }
            #endregion

            sp.Stop();
            backgroundWorker2.ReportProgress(100, "操作完成 共用时：" + sp.ElapsedMilliseconds / 1000 + "s");

        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel2.Text = e.UserState.ToString();
        }


    }
}
