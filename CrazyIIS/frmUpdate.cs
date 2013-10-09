using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class frmUpdate : Form
    {

        // from http://www.harde.com.cn/SoftUpdate/
        public string URL;
        public string UpdateMessage;
        public string errmsg = "下载地址不正确，请联系 技术组-柳永法，或过会再试\n";
        public frmUpdate()
        {
            InitializeComponent();
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            lblUpdateMessages.Text = UpdateMessage;
            Download(URL);
        }

        private void Download(string fileurl)
        {
            try
            {

                string filename = Path.GetFileName(URL);
                // File.Delete(filename);
                progressBar1.Value = 0;

                WebClient wc = new WebClient();
                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(OnDownloadProgressChanged);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(OnDownloadFileCompleted);

                wc.DownloadFileAsync(new Uri(fileurl), filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(errmsg + ex.Message);
                Application.Exit();
            }


        }

        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Value = e.ProgressPercentage;
                lbl_msg.Text = "已下载" + e.BytesReceived + "字节/总计" + e.TotalBytesToReceive + "字节 完成:" + e.ProgressPercentage + "%";

            }
            catch (Exception ex)
            {
                MessageBox.Show(errmsg + ex.Message);
                Application.Exit();
            }

        }

        private void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                Process.Start(Path.GetFileName(URL));
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(errmsg + ex.Message);
                Application.Exit();
            }

        }


    }
}
