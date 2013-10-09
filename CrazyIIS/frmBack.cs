using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class frmBack : Form
    {
        public frmBack()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            dlg.Description = "备份文件保存到：";
            dlg.SelectedPath = Application.StartupPath;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBackUp.Text = dlg.SelectedPath + "\\" + GetBackupPath();
            }

            //SaveFileDialog dlg = new SaveFileDialog();
            ////dlg.Title = "备份文件到";
            //dlg.FileName = DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss") + ".xml";
            //dlg.Filter = "所有文件(*.*)|*.*|IIS备份文件 (*.xml)|*.xml";


            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    txtBackUp.Text = dlg.FileName;
            //}
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Comm.MetaBasePath()))
            {
                MessageBox.Show("配置文件不存在，没法备份，请确认您已经安装IIS");
                return;
            }

            string BackUpPath = txtBackUp.Text;
            if (!Path.IsPathRooted(BackUpPath))
            {
                BackUpPath = Path.Combine(Application.StartupPath, BackUpPath);
            }

            if (Directory.Exists(BackUpPath))
            {
                Directory.Delete(BackUpPath, true);
            }
            Directory.CreateDirectory(BackUpPath);

            try
            {

                File.Copy(Comm.MetaBasePath(), Path.Combine(BackUpPath, "MetaBase.xml"), true);

                if (chkHistory.Checked)
                {
                    DirectoryCopy(Environment.SystemDirectory + @"\inetsrv\History", Path.Combine(BackUpPath, "History"), "Metabase*.xml");
                }

                if (chkMetaBack.Checked)
                {
                    DirectoryCopy(Environment.SystemDirectory + @"\inetsrv\MetaBack", Path.Combine(BackUpPath, "MetaBack"), null);
                }

                if (chkACL.Checked)
                {
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    DataTable dt = Comm.GetAllWebInfo();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string _path = dt.Rows[i]["Path"].ToString();
                        if (!dict.ContainsKey(_path))
                        {
                            dict.Add(_path, "," + string.Join(",", NTFS.ACL.List(_path).ToArray()) + ",");
                        }
                    }

                    DataSet ds = new DataSet();

                    DataTable dtNew = new DataTable("CrazyIIS.ACL");
                    dtNew.Columns.Add("Path");
                    dtNew.Columns.Add("ACL");

                    foreach (var item in dict)
                    {
                        dtNew.Rows.Add(item.Key, item.Value);
                    }
                    ds.Tables.Add(dtNew);
                    ds.WriteXml(BackUpPath + "\\ACL.xml");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }



            MessageBox.Show("备份成功");
        }

        private void frmBack_Load(object sender, EventArgs e)
        {
            txtBackUp.Text = GetBackupPath();
        }

        string GetBackupPath()
        {

            return "CrazyIIS.Backup." + DateTime.Now.ToString("yyyy-MM-dd.HH-mm-ss");
        }

        public static void DirectoryCopy(string Src, string Dst, string search)
        {
            String[] Files;

            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst)) Directory.CreateDirectory(Dst);
            if (string.IsNullOrEmpty(search))
            {
                Files = Directory.GetFileSystemEntries(Src);
            }
            else
            {
                Files = Directory.GetFileSystemEntries(Src, search);
            }

            foreach (string Element in Files)
            {
                // Sub directories

                if (Directory.Exists(Element))
                    DirectoryCopy(Element, Dst + Path.GetFileName(Element), null);
                // Files in directory

                else
                    File.Copy(Element, Dst + Path.GetFileName(Element), true);
            }
        }
    }
}
