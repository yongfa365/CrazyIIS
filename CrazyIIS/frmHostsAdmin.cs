using System;
using System.IO;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class frmHostsAdmin : Form
    {
        private string hostsPath = Environment.SystemDirectory + @"\drivers\etc\hosts";
        public frmHostsAdmin()
        {
            InitializeComponent();
        }

        private void btnOpenNotePad_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\drivers\etc");
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(hostsPath);
            //FileInfo f = new FileInfo(hostsPath);
            //f.IsReadOnly = false;
            //File.WriteAllText(hostsPath, hostsCnt + hostsNew);
            //f.IsReadOnly = true;


            //string hostsNew = "";
            //string hostsCnt = "";
            //if (Delete)
            //{
            //    hostsCnt = "127.0.0.1 localhost";
            //}
            //else
            //{
            //    hostsCnt = File.ReadAllText(hostsPath);
            //}


            //for (int i = 0; i < Hosts.Length; i = i + 2)
            //{
            //    string IP = Hosts[i];
            //    string Domain = Hosts[i + 1];
            //    if (!Regex.IsMatch(hostsCnt, IP + "\\s+" + Domain))
            //    {
            //        hostsNew += "\n" + IP + " " + Domain;
            //    }

            //}
            //FileInfo f = new FileInfo(hostsPath);
            //f.IsReadOnly = false;
            //File.WriteAllText(hostsPath, hostsCnt + hostsNew);
            //f.IsReadOnly = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FileInfo f = new FileInfo(hostsPath);
            f.IsReadOnly = false;
            File.WriteAllText(hostsPath, textBox1.Text);
            f.IsReadOnly = true;
        }
    }
}
