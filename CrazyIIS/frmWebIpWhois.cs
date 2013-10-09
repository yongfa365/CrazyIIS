using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class frmWebIpWhois : Form
    {
        public frmWebIpWhois()
        {
            InitializeComponent();
        }

        private void frmWebIpWhois_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Domain", "域名");
            dataGridView1.Columns.Add("IP", "IP");
            dataGridView1.Columns.Add("DNS", "DNS");

        }

        string GetWhois(string webname)
        {
            List<string> list = new List<string>();
            // whois : http://network-tools.com/default.asp?prog=whois&host=yongfa365.com "utf-8"
            //http://www.whois-search.com/whois/ "iso-8859-1"
            // https://www.iwhois.com/whois/yongfa365.com iso-8859-1
            string str = Comm.GetHtmlSource("https://www.iwhois.com/whois/" + webname.Trim(), Encoding.GetEncoding("iso-8859-1"));
            foreach (Match item in Regex.Matches(str, "Name Server:(.{4,})"))
            {
                list.Add(item.Groups[1].Value.Trim().ToLower());
            }


            if (list.Count == 0)
            {
                return "没找到DNS信息";
            }
            else
            {
                return string.Join(",", list.ToArray());
            }

        }

        private void btnDomain2DNS_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string s = GetWhois(dataGridView1[0, i].Value.ToString());
                backgroundWorker1.ReportProgress(0, new string[] { i.ToString(), s });
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string[] s = e.UserState as string[];
            dataGridView1[2, Convert.ToInt32(s[0])].Value = s[1];
        }




        private void btnDomain2IP_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                try
                {
                    Ping myPing = new Ping();
                    myPing.PingCompleted += new PingCompletedEventHandler(_myPing_PingCompleted);
                    string hostName = dataGridView1[0, i].Value.ToString();
                    myPing.SendAsync(hostName, 1, i);
                }
                catch
                {

                }

            }
        }

        private void _myPing_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            if (e.Reply == null)
            {
                dataGridView1[1, Convert.ToInt32(e.UserState)].Value = "不存在或超时";
            }
            else// if (e.Reply.Status == IPStatus.Success)
            {
                dataGridView1[1, Convert.ToInt32(e.UserState)].Value = e.Reply.Address.ToString();
            }

        }

        private void btnInFromIIS_Click(object sender, EventArgs e)
        {
            foreach (DataRowView item in Comm.GetAllWebInfo().DefaultView)
            {
                dataGridView1.Rows.Add(item["Web"].ToString());
            }
            MessageBox.Show("OK");
        }

        private void btnInFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string[] str = File.ReadAllLines(dlg.FileName);
                foreach (var item in str)
                {
                    dataGridView1.Rows.Add(item);
                }

            }

        }




    }
}
