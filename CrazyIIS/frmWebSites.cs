using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class frmWebSites : Form
    {
        public string InAppPoolId = "";
        public bool Changed = false;
        public frmWebSites()
        {
            InitializeComponent();
        }

        private void FrmWebSites_Load(object sender, EventArgs e)
        {
            Fill();
            if (InAppPoolId != "")
            {
                localWeb1.SetAppPoolId(InAppPoolId);
            }
        }

        void Fill()
        {

            string[] AppPools = Comm.GetAppPools().ToArray();


            localWeb1.FillAppPools(AppPools);


            AppPoolId2.Items.Clear();
            AppPoolId2.Items.AddRange(AppPools);
            AppPoolId2.SelectedIndex = 0;

            chkListBox_S.Items.Clear();
            chkListBox_S.Items.AddRange(AppPools);

            chkListBox_D.Items.Clear();
            chkListBox_D.Items.AddRange(AppPools);

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (localWeb1.dgvWeb.SelectedRows.Count == 0)
            {
                MessageBox.Show("没选择网站");
                return;
            }

            IISConfig.Metabase metabase = new IISConfig.Metabase();
            metabase.OpenLocalMachine();

            IISConfig.Record record = new IISConfig.Record();
            record.DataType = IISConfig.Record.DataTypes.String;
            record.UserType = IISConfig.Record.UserTypes.Server;
            record.Identifier = 9101;
            record.ChangeAttribute(IISConfig.Record.AttributeList.Inherit, true);

            foreach (DataGridViewRow item in localWeb1.dgvWeb.SelectedRows)
            {
                record.Data = AppPoolId2.Text;
                metabase.GetKeyFromPath("/LM/W3SVC/" + item.Cells["Id"].Value + "/root").SetRecord(record);
            }
            metabase.Close();
            Comm.MetaBaseSave();
            localWeb1.FillWeb();
            Changed = true;
        }

        private void btnHe_Click(object sender, EventArgs e)
        {
            if (chkListBox_S.CheckedItems.Count == 0 || chkListBox_D.CheckedItems.Count == 0)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in chkListBox_S.CheckedItems)
            {
                sb.AppendFormat(",'{0}'", item);
            }

            DataView dv = Comm.GetAllWebInfo().DefaultView;
            dv.RowFilter = string.Format(" AppPoolId in({0})", sb.ToString().Substring(1));

            IISConfig.Metabase metabase = new IISConfig.Metabase();
            metabase.OpenLocalMachine();

            IISConfig.Record record = new IISConfig.Record();
            record.DataType = IISConfig.Record.DataTypes.String;
            record.UserType = IISConfig.Record.UserTypes.Server;
            record.Identifier = 9101;
            record.ChangeAttribute(IISConfig.Record.AttributeList.Inherit, true);

            Double p = dv.Count / chkListBox_D.CheckedItems.Count;
            for (int i = 0; i < dv.Count; i++)
            {
                int NumberPer = int.Parse(Math.Floor(i / p).ToString());

                if (NumberPer == chkListBox_D.CheckedItems.Count)
                {
                    NumberPer = chkListBox_D.CheckedItems.Count - 1;
                }
                record.Data = chkListBox_D.CheckedItems[NumberPer];
                metabase.GetKeyFromPath("/LM/W3SVC/" + dv[i]["Id"] + "/root").SetRecord(record);
            }
            metabase.Close();
            MessageBox.Show("OK");
        }


        private void btnDeleteAllNoUsed_Click(object sender, EventArgs e)
        {
            Comm.MetaBaseSave();
            List<string> listUsed = Comm.GetAppPoolsUsed();
            List<string> listNow = Comm.GetAppPools();

            IISConfig.Metabase metabase = new IISConfig.Metabase();
            metabase.OpenLocalMachine();

            foreach (var item in listNow)
            {
                if (!listUsed.Contains(item) && item != "DefaultAppPool")
                {
                    metabase.GetKeyFromPath("/LM/W3SVC/AppPools").DeleteSubkey(item);
                }
            }
            metabase.Close();
            Fill();
        }


        private void btnAddPool_Click(object sender, EventArgs e)
        {

            IISConfig.Metabase metabase = new IISConfig.Metabase();
            metabase.OpenLocalMachine();

            IISConfig.Record record = new IISConfig.Record();
            record.DataType = IISConfig.Record.DataTypes.String;
            record.UserType = IISConfig.Record.UserTypes.Server;
            record.Identifier = 1002;

            StringBuilder sb = new StringBuilder();
            foreach (var item in txtNewPool.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    IISConfig.IKey key = metabase.GetKeyFromPath("/LM/W3SVC/AppPools").AddSubkey(item);
                    record.Data = "IIsApplicationPool";
                    key.SetRecord(record);
                }
                catch (Exception ex)
                {
                    sb.AppendFormat("{0}\r\n", ex.Message);
                }
            }

            metabase.Close();
            Fill();

        }

        private void btnOneWebOnePool_Click(object sender, EventArgs e)
        {
            if (localWeb1.dgvWeb.SelectedRows.Count == 0)
            {
                MessageBox.Show("没选择网站");
                return;
            }

            IISConfig.Metabase metabase = new IISConfig.Metabase();
            metabase.OpenLocalMachine();

            #region 先建应用程序池
            {
                IISConfig.Record pool = new IISConfig.Record();
                pool.DataType = IISConfig.Record.DataTypes.String;
                pool.UserType = IISConfig.Record.UserTypes.Server;
                pool.Identifier = 1002;
                foreach (DataGridViewRow item in localWeb1.dgvWeb.SelectedRows)
                {
                    try
                    {
                        IISConfig.IKey key = metabase.GetKeyFromPath("/LM/W3SVC/AppPools").AddSubkey(item.Cells["Web"].Value.ToString());
                        pool.Data = "IIsApplicationPool";
                        key.SetRecord(pool);
                    }
                    catch
                    {

                    }
                }
            }
            #endregion

            IISConfig.Record record = new IISConfig.Record();
            record.DataType = IISConfig.Record.DataTypes.String;
            record.UserType = IISConfig.Record.UserTypes.Server;
            record.Identifier = 9101;

            record.ChangeAttribute(IISConfig.Record.AttributeList.Inherit, true);

            foreach (DataGridViewRow item in localWeb1.dgvWeb.SelectedRows)
            {
                record.Data = item.Cells["Web"].Value;
                metabase.GetKeyFromPath("/LM/W3SVC/" + item.Cells["Id"].Value + "/root").SetRecord(record);
            }
            metabase.Close();
            Fill();
            localWeb1.FillWeb();
            Changed = true;
        }

        private void lblSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < chkListBox_S.Items.Count; i++)
            {
                chkListBox_S.SetItemChecked(i, true);
            }
        }

        private void lblSelectOther_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < chkListBox_S.Items.Count; i++)
            {
                chkListBox_S.SetItemChecked(i, !chkListBox_S.GetItemChecked(i));
            }
        }

        private void frmWebSites_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Changed)
            {
                this.DialogResult = DialogResult.Yes;
            }
        }

        private void btnResetFolderACL_Click(object sender, EventArgs e)
        {
            string MetaBase = File.ReadAllText(Comm.MetaBasePath());
            IISConfig.Metabase metabase = new IISConfig.Metabase();
            metabase.OpenLocalMachine();

            IISConfig.IKey key;
            string NowPath = "";
            string NowUserName = "";
            string Default_AnonymousUserName = Comm.GetDefaultAnonymousUserName();

            foreach (DataGridViewRow item in localWeb1.dgvWeb.SelectedRows)
            {
                key = metabase.GetKeyFromPath("/LM/W3SVC/" + item.Cells["Id"].Value + "/root");
                NowPath = key.GetRecord(3001).Data.ToString();

                if (key.GetRecord(6020) != null)
                {
                    NowUserName = key.GetRecord(6020).Data.ToString();
                }
                else
                {
                    NowUserName = Default_AnonymousUserName;
                }

                if (Directory.Exists(NowPath))
                {
                    NTFS.ACL.Add(NowPath, NowUserName, NTFS.ACL.Roles.FullControl);
                    NTFS.ACL.DelErr(NowPath);
                }
            }
            MessageBox.Show("OK");
        }


    }
}
