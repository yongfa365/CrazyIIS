using System;
using System.ComponentModel;
using System.Windows.Forms;
//互动服务 


namespace CrazyIIS
{
    public partial class frmMain : Form
    {
        public static string CPUID = "";

        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            #region 取得版本号,及要下载的文件地址, 升级
            //{
            //    string NowVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //    string NewVersion = string.Empty;
            //    string UpdateFileUrl = string.Empty;
            //    string[] UpdateUrls = { 
            //                          "http://www.yongfa365.com/Update/",
            //                          "http://www.yongfa365.com/Update/CrazyIIS/",
            //                      };

            //    foreach (string UpdateUrl in UpdateUrls)
            //    {
            //        string VersionFile = UpdateUrl + "Update.txt";
            //        if (!Comm.RemoteFileExists(VersionFile))
            //        {
            //            continue;
            //        }

            //        WebClient wc = new WebClient();
            //        string NewVersonTemp = wc.DownloadString(VersionFile);
            //        if (string.IsNullOrEmpty(NewVersonTemp))
            //        {
            //            continue;
            //        }
            //        NewVersonTemp = NewVersonTemp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
            //        string UpdateFileUrlTemp = UpdateUrl + NewVersonTemp + "/CrazyIIS.Update.exe";
            //        if (!Comm.RemoteFileExists(UpdateFileUrlTemp))
            //        {
            //            continue;
            //        }

            //        NewVersion = NewVersonTemp;
            //        UpdateFileUrl = UpdateFileUrlTemp;
            //        break;
            //    }

            //    //升级
            //    if (!string.IsNullOrEmpty(NewVersion))
            //    {
            //        if (NowVersion != NewVersion)
            //        {
            //            this.Hide();

            //            frmUpdate Update = new frmUpdate();
            //            Update.URL = UpdateFileUrl;
            //            Update.UpdateMessage = string.Format("{0} --> {1}", NowVersion, NewVersion);
            //            Update.ShowDialog();
            //        }
            //    }

            //    Text = "CrazyIIS(疯狂的IIS) V" + NowVersion;
            //}
            #endregion


            //IIS设置|tsbtnConfigs
            //IIS备份|tsbtnBackup
            //IIS还原|tsbtnRestore
            //匿名用户|tsbtnUsers
            //网站流量|tsbtnMonitor
            //历史流量|tsbtnLogAnalyzer
            //安全设置|tsbtnSecurity
            //添加网站|tsbtnCreateWeb

            backgroundWorker1.RunWorkerAsync();

        }



        private void btnAppPoolIds_Click(object sender, EventArgs e)
        {
            frmWebSites frm = new frmWebSites();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            frmProcess frm = new frmProcess();
            frm.Show();
        }


        private void tsbtnConfigs_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmConfigs());
        }

        private void tsbtnBackup_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmBack());
        }

        private void tsbtnRestore_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmRestore());
        }

        private void tsbtnUsers_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmUsers());
        }

        private void tsbtnMonitor_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmMonitor());
        }
        private void tsbtnLogAnalyzer_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmLogAnalyzer());
        }
        private void tsbtnCreateWeb_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmCreate());
        }
        private void LoadfrmLogAnalyzer()
        {
            LoadForm2(new frmLogAnalyzer());
        }
        private void tsbtnProcess_Click(object sender, EventArgs e)
        {
            LoadForm(new frmProcess(), true);
        }

        private void tsbtnWeb_AppPool_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmWebSites());
        }

        private void LoadForm(Form frm, bool kill)
        {

            foreach (Form ftemp in this.MdiChildren)
            {
                if (ftemp.Name == frm.Name)
                {
                    if (kill)
                    {
                        ftemp.Close();
                    }
                    else
                    {
                        ftemp.Activate();
                        return;
                    }

                }
            }

            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            frm.Activate();
            webBrowser1.Hide();


        }
        private void LoadForm2(Form frm)
        {
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {

                webBrowser1.Url = new Uri("http://www.yongfa365.com/");
                CPUID = Comm.GetCpuID();
            }
            catch
            {

            }
        }

        private void IIS设置_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmConfigs());
        }

        private void IIS备份_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmBack());
        }

        private void IIS还原_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmRestore());
        }

        private void 网站实时流量_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmMonitor());
        }

        private void 网站历史流量_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmLogAnalyzer());
        }

        private void 网站及应用程序池管理_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmWebSites());
        }

        private void 匿名用户管理_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmUsers());
        }

        private void 手动建网站_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmCreate());
        }

        private void 进程分析_Click(object sender, EventArgs e)
        {
            LoadForm(new frmProcess(), true);
        }

        private void hosts管理_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmHostsAdmin());
        }

        private void 网站IP及Whois批量查询_Click(object sender, EventArgs e)
        {
            LoadForm2(new frmWebIpWhois());
        }

        private void 注册本软件_Click(object sender, EventArgs e)
        {
            frmReg frm = new frmReg();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void 官方网站_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.yongfa365.com/?r=CrazyIIS.exe");
        }

        private void 软件启动页ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form ftemp in this.MdiChildren)
            {
                ftemp.Close();
            }
            webBrowser1.Show();
        }



    }
}
