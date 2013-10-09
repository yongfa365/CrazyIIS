using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;



namespace CrazyIIS
{
    public partial class frmRestore : Form
    {
        public frmRestore()
        {
            InitializeComponent();
        }



        private void btnBrowser2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "MetaBase.xml";
            dlg.Filter = "所有文件(*.*)|*.*|IIS备份文件 (*.xml)|*.xml";
            dlg.FilterIndex = 2;


            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtRestore.Text = dlg.FileName;
            }
        }


        private void btnDefault_Click(object sender, EventArgs e)
        {
            string BackUpName = DateTime.Now.ToString("yyyy-MM-dd---HH-mm-ss");
            if (MessageBox.Show("还原IIS大约要15秒，程序会自动为您先做备份", "温馨提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //  Comm.MetaBaseBackup(BackUpName);
                Comm.MetaBaseRestore2Install();
                MessageBox.Show("成功");
            }

        }

        private void btnDefault2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("还原IIS大约要15秒，适用于连IIS都进不去的用户", "温馨提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                IIS.Stop();
                File.Copy(Comm.MetaBaseFirstFileInfo().FullName, Comm.MetaBasePath(), true);
                IIS.Start();
                Comm.MetaBaseRestore2Install();
                MessageBox.Show("成功");
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定还原？", "温馨提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                backgroundWorker1.RunWorkerAsync();
            }

        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!File.Exists(Comm.MetaBasePath()))
            {
                MessageBox.Show("请确认您已经安装IIS 6.0");
                return;
            }

            Stopwatch sp = new Stopwatch();
            sp.Start();

            backgroundWorker1.ReportProgress(5, "正在停止IIS");
            IIS.Stop();


            string MetaBase = File.ReadAllText(Comm.MetaBasePath());
            string MetaBase_BackUp = File.ReadAllText(txtRestore.Text);
            string Defult_AnonymousUserName = Comm.GetDefaultAnonymousUserName();


            WinNT.NetUser User = new WinNT.NetUser();
            Dictionary<string, string> AllUsers = new Dictionary<string, string>();
            DataTable PathUser = new DataTable();
            PathUser.Columns.Add("Path");
            PathUser.Columns.Add("User");


            #region MetaBase_BackUp 前期处理
            {
                //把“机器名\\用户名”处理成“用户名”
                MetaBase_BackUp = Regex.Replace(MetaBase_BackUp, @"AnonymousUserName=""[^""]+\\([^""]+?)""", @"AnonymousUserName=""$1""");
                //有些机器会生成“UNCPassword”自定义结点，影响工作，删除
                MetaBase_BackUp = Regex.Replace(MetaBase_BackUp, @"<Custom[^<>]+?UNCPassword[\s\S]+?/>", "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                MetaBase_BackUp = Regex.Replace(MetaBase_BackUp, @"[a-zA-Z]:\\Windows", Environment.GetEnvironmentVariable("windir"), RegexOptions.IgnoreCase);
            }
            #endregion

            #region 加工 MetaBase_BackUp 一些安全属性为当前属性
            {
                XmlDocument doc_Now = new XmlDocument();
                doc_Now.LoadXml(MetaBase);
                XmlNamespaceManager xnm = new XmlNamespaceManager(doc_Now.NameTable);
                xnm.AddNamespace("mxh", "urn:microsoft-catalog:XML_Metabase_V64_0");

                XmlDocument doc_Bak = new XmlDocument();
                doc_Bak.LoadXml(MetaBase_BackUp);

                //string[] Nodes = "IIsWebService|IIsFilters|IIsApplicationPools|IIsLogModules|IIsFtpService|IIsNNTPService|IIsSMTPService|IIsIMAPService|IIsPOP3Service|IIsMiMeMap".Split('|');
                string[] IIS_Nodes = "IIsWebService|IIsFilters|IIsApplicationPools|IIsLogModules|IIsFtpService".Split('|');
                string[] IIS_Fileds = "AnonymousUserName|AnonymousUserPass|LogOdbcPassword|LogOdbcPassword|WAMUserName|WAMUserPass|AdminACL".Split('|');

                foreach (string item in IIS_Nodes)
                {
                    string xpath = "/mxh:configuration/mxh:MBProperty/mxh:" + item;
                    XmlNode IIS_Now = doc_Now.SelectSingleNode(xpath, xnm);
                    XmlNode IIS_Bak = doc_Bak.SelectSingleNode(xpath, xnm);

                    //如果一个没有这个结点就直接进入下一个结点
                    if (IIS_Now == null || IIS_Bak == null)
                    {
                        continue;
                    }

                    //各属性同步
                    foreach (string item2 in IIS_Fileds)
                    {
                        if (IIS_Now.Attributes[item2] != null && IIS_Bak.Attributes[item2] == null)
                        {
                            ((XmlElement)IIS_Bak).RemoveAttribute(item2);
                        }

                        if (IIS_Now.Attributes[item2] != null && IIS_Bak.Attributes[item2] != null)
                        {
                            IIS_Bak.Attributes[item2].Value = IIS_Now.Attributes[item2].Value;
                        }
                    }
                }

                MetaBase_BackUp = doc_Bak.OuterXml;
            }
            #endregion

            #region IIsMimeMap
            {
                backgroundWorker1.ReportProgress(10, "还原网站配置");
                string temp = Regex.Match(MetaBase_BackUp, "<IIsMimeMap[^<>]+?>").Groups[0].Value;
                MetaBase = Regex.Replace(MetaBase, "<IIsMimeMap[^<>]+?>", temp);
            }
            #endregion

            #region IIsWebService
            {
                backgroundWorker1.ReportProgress(10, "还原网站配置");
                string temp = Regex.Match(MetaBase_BackUp, "<IIsWebService[^<>]+?>").Groups[0].Value;
                MetaBase = Regex.Replace(MetaBase, "<IIsWebService[^<>]+?>", temp);
            }
            #endregion

            #region IIsWebServer
            {
                backgroundWorker1.ReportProgress(15, "还原网站" + sp.ElapsedMilliseconds.ToString());

                string temp = "";
                if (Comm.IsReg())
                {

                    temp = Regex.Match(MetaBase_BackUp, "</IIsWebService>([\\s\\S]+)<IIsApplicationPools").Groups[1].Value;

                }
                else
                {
                    ////////////MatchCollection WebsitesMatches = Regex.Matches(MetaBase_BackUp, "<IIsWebServer\\s+Location=\"/LM/W3SVC/\\d+\"[\\s\\S]+?</IIsWebVirtualDir>",RegexOptions.IgnoreCase);
                    ////////////int TestI = 0;
                    ////////////foreach (Match item in WebsitesMatches)
                    ////////////{
                    ////////////    temp += item.Value;
                    ////////////    TestI++;
                    ////////////    if (TestI == 25)
                    ////////////    {
                    ////////////        break;
                    ////////////    }
                    ////////////}

                    List<string> sss = new List<string>();
                    MatchCollection WebsitesMatches = Regex.Matches(MetaBase_BackUp, "(<IIsWebServer\\s+Location=\"/LM/W3SVC/\\d+\"[\\s\\S]+)<IIsApplicationPools", RegexOptions.IgnoreCase);

                    if (WebsitesMatches.Count > 0)
                    {
                        sss.AddRange(WebsitesMatches[0].Groups[1].Value.Replace("<IIsWebServer", "柳永法<IIsWebServer").Split(new string[] { "柳永法" }, StringSplitOptions.RemoveEmptyEntries));
                    }

                    int TestI = 0;
                    foreach (string item in sss)
                    {
                        temp += item;
                        TestI++;
                        if (TestI == 25)
                        {
                            break;
                        }
                    }
                }

                temp = Regex.Replace(temp, @"(AnonymousUserPass|UNCPassword|AdminACL)\s*=\s*"".+?""", "");
                MetaBase = Regex.Replace(MetaBase, "</IIsWebService>[\\s\\S]+<IIsApplicationPools", "</IIsWebService>" + temp + "<IIsApplicationPools");

            }
            #endregion

            #region IIsApplicationPools
            {
                backgroundWorker1.ReportProgress(20, "还原应用程序池配置" + sp.ElapsedMilliseconds.ToString());
                //"<IIsApplicationPools[\\s\\S]+</IIsApplicationPools>"
                string temp = Regex.Match(MetaBase_BackUp, "<IIsApplicationPools[^<>]+?>").Groups[0].Value;
                //可能会有，所有替换
                temp = Regex.Replace(temp, @"(WAMUserName|WAMUserPass)\s*=\s*"".+?""", "");
                MetaBase = Regex.Replace(MetaBase, "<IIsApplicationPools[^<>]+?>", temp);
            }
            #endregion

            #region ApplicationPool
            {
                backgroundWorker1.ReportProgress(25, "还原应用程序池" + sp.ElapsedMilliseconds.ToString());
                string temp = Regex.Match(MetaBase_BackUp, "</IIsApplicationPools>([\\s\\S]+)</IIsApplicationPool>").Groups[1].Value;
                temp = Regex.Replace(temp, @"(WAMUserName|WAMUserPass)\s*=\s*"".+?""", "");
                MetaBase = Regex.Replace(MetaBase, "</IIsApplicationPools>[\\s\\S]+</IIsApplicationPool>", "</IIsApplicationPools>" + temp + "</IIsApplicationPool>");
            }
            #endregion


            #region IIsLogModules
            {
                backgroundWorker1.ReportProgress(15, "还原LogModules" + sp.ElapsedMilliseconds.ToString());
                string temp = "";
                temp = Regex.Match(MetaBase_BackUp, "<IIsLogModules>([\\s\\S]+)</IIsCustomLogModule>").Groups[1].Value;
                MetaBase = Regex.Replace(MetaBase, "<IIsLogModules>([\\s\\S]+)</IIsCustomLogModule>", temp);
            }
            #endregion

            #region IIsFilters
            {
                backgroundWorker1.ReportProgress(15, "还原LogModules" + sp.ElapsedMilliseconds.ToString());
                string temp = "";
                temp = Regex.Match(MetaBase_BackUp, "<IIsFilters>([\\s\\S]+)</IIsCompressionSchemes>").Groups[1].Value;
                MetaBase = Regex.Replace(MetaBase, "<IIsFilters>([\\s\\S]+)</IIsCompressionSchemes>", temp);
            }
            #endregion

            if (chkFtp.Checked && MetaBase.Contains("<IIsFtpService"))
            {
                #region IIsFtpService
                {
                    backgroundWorker1.ReportProgress(10, "还原网站配置");
                    string temp = Regex.Match(MetaBase_BackUp, "<IIsFtpService[^<>]+?>").Groups[0].Value;
                    MetaBase = Regex.Replace(MetaBase, "<IIsFtpService[^<>]+?>", temp);
                }
                #endregion

                #region IIsFtpService
                {
                    backgroundWorker1.ReportProgress(15, "还原网站" + sp.ElapsedMilliseconds.ToString());
                    string temp = "";
                    temp = Regex.Match(MetaBase_BackUp, "</IIsFtpService>([\\s\\S]+)<IIsFtpInfo").Groups[1].Value;
                    temp = Regex.Replace(temp, @"(AnonymousUserPass|UNCPassword|AdminACL)\s*=\s*"".+?""", "");
                    MetaBase = Regex.Replace(MetaBase, "</IIsFtpService>([\\s\\S]+)<IIsFtpInfo", "</IIsFtpService>" + temp + "<IIsFtpInfo");
                }
                #endregion
            }






            File.WriteAllText(Comm.MetaBasePath(), MetaBase);

            backgroundWorker1.ReportProgress(25, "IIS还原完成，将要创建匿名用户，时间较长" + sp.ElapsedMilliseconds.ToString());

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
                IISConfig.Record record = key.GetRecord(6021);

                //更新"/LM/W3SVC"的默认用户密码
                record.Data = AllUsers[key.GetRecord(6020).Data.ToString()];
                key.SetRecord(record);



                MatchCollection matchs = Regex.Matches(MetaBase, @"Location\s*=\s*""(/LM/W3SVC/\d+/root.*?)""", RegexOptions.IgnoreCase);
                foreach (Match item in matchs)
                {
                    key = metabase.GetKeyFromPath(item.Groups[1].Value);
                    if (key.GetRecord(6020) != null)
                    {
                        //用户名存在时，设置密码
                        record.Data = AllUsers[key.GetRecord(6020).Data.ToString()];
                        key.SetRecord(record);
                        PathUser.Rows.Add(key.GetRecord(3001).Data.ToString(), key.GetRecord(6020).Data.ToString());
                    }
                    else
                    {
                        //用户名不存在时，删除密码
                        if (key.GetRecord(6021) != null)
                        {
                            key.DeleteRecord(6021);
                        }

                        PathUser.Rows.Add(key.GetRecord(3001).Data.ToString(), Defult_AnonymousUserName);
                    }
                }
                metabase.Close();
                backgroundWorker1.ReportProgress(50, "给网站添加匿名用户完成" + sp.ElapsedMilliseconds.ToString());
            }
            #endregion

            #region 取网站路径及对应的用户名，如果路径存在，则加权限
            {
                backgroundWorker1.ReportProgress(50, "将要给目录加权限" + sp.ElapsedMilliseconds.ToString());

                for (int i = 0; i < PathUser.Rows.Count; i++)
                {
                    string NowPath = PathUser.Rows[i][0].ToString();
                    if (chkDir.Checked && !Directory.Exists(NowPath))
                    {
                        Directory.CreateDirectory(NowPath);
                        File.WriteAllText(NowPath + "\\CrazyIIS.html", "hello html");
                        File.WriteAllText(NowPath + "\\CrazyIIS.asp", "<%=1+1%> ASP Test OK");
                        File.WriteAllText(NowPath + "\\CrazyIIS.aspx", "<%=1+1%> ASPX Test OK");
                    }

                    if (Directory.Exists(NowPath))
                    {
                        backgroundWorker1.ReportProgress(50, "正在给目录 “" + NowPath + "” 加权限" + sp.ElapsedMilliseconds.ToString());
                        NTFS.ACL.Add(NowPath, PathUser.Rows[i][1].ToString(), NTFS.ACL.Roles.FullControl);
                        NTFS.ACL.DelErr(NowPath);
                    }
                }
                backgroundWorker1.ReportProgress(50, "给目录加权限完成" + sp.ElapsedMilliseconds.ToString());
            }
            #endregion


            #region 是否写入 hosts
            if (chkHosts.Checked)
            {
                backgroundWorker1.ReportProgress(90, "正在写入hosts" + sp.ElapsedMilliseconds.ToString());
                MatchCollection matchs = Regex.Matches(MetaBase, "ServerComment=\"(.+?)\"", RegexOptions.IgnoreCase);
                string Hosts = "";
                foreach (Match item in matchs)
                {
                    Hosts += ",127.0.0.1," + item.Groups[1].Value;
                }
                Comm.Write2hosts(Hosts.Substring(1).Split(','), true);
            }
            #endregion


            backgroundWorker1.ReportProgress(90, "正在重启IIS" + sp.ElapsedMilliseconds.ToString());

            IIS.Start();

            sp.Stop();
            backgroundWorker1.ReportProgress(100, "操作完成 共用时：" + sp.ElapsedMilliseconds / 1000 + "s");
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel2.Text = e.UserState.ToString();

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetPathUser(false);
        }


        private void FrmBackUpRestore_Load(object sender, EventArgs e)
        {
            string MetaBase = File.ReadAllText(Comm.MetaBasePath());
            if (!MetaBase.Contains("<IIsFtpService"))
            {
                chkFtp.Enabled = false;
            }
        }



        private void btnPathUser_Click(object sender, EventArgs e)
        {
            SetPathUser(true);
        }


        void SetPathUser(bool Alert)
        {

            if (txtRestore.Text == "")
            {
                if (Alert)
                {
                    MessageBox.Show("请先选择要还原的文件");
                }

                return;
            }


            string _Path = Path.GetDirectoryName(txtRestore.Text);
            if (File.Exists(Path.Combine(_Path, "ACL.xml")))
            {
                _Path = Path.Combine(_Path, "ACL.xml");

            }
            else if (_Path.EndsWith("History", true, null) || _Path.EndsWith("MetaBack", true, null))
            {
                string p = _Path.Remove(_Path.LastIndexOf('\\')) + "\\ACL.xml";
                if (File.Exists(p))
                {
                    _Path = p;
                }
                else
                {
                    _Path = string.Empty;
                }
            }
            else
            {
                _Path = string.Empty;
            }


            if (_Path != string.Empty)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(_Path);

                DataView dv = ds.Tables[0].DefaultView;
                dv.RowFilter = " ACL like '%,IIS_WPG,%' or  ACL like '%,NETWORK SERVICE,%' ";

                if (dv.Count > 0)
                {
                    frmPathACL frm = new frmPathACL();
                    frm.dt = ds.Tables[0];
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }

            }
            else
            {
                if (Alert)
                {
                    MessageBox.Show("权限文件不存在");
                }

            }

        }



    }
}
