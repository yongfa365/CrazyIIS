using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace CrazyIIS
{
    public partial class frmReg : Form
    {
        public frmReg()
        {
            InitializeComponent();
        }

        private void frmReg_Load(object sender, EventArgs e)
        {
            while (string.IsNullOrEmpty(frmMain.CPUID))
            {
                Thread.Sleep(1000);
            }
            txtCode.Text = Comm.Encrypt(frmMain.CPUID, "柳永法'CrazyIIS.http://www.yongfa365.com/");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("CrazyIIS.xml");

            txtU.Text = xmlDoc.SelectSingleNode("//Reg/UserName").InnerText;
            txtSN.Text = xmlDoc.SelectSingleNode("//Reg/SN").InnerText;
        }



        private void btnUnLock_Click(object sender, EventArgs e)
        {
            if (txtU.Text == "" || txtSN.Text.Trim().Length < 12)
            {
                return;
            }

            bool isreg = Regex.Replace(Comm.Encrypt(txtCode.Text + txtU.Text.Trim(), "柳永法的CrazyIIS"), "(.{4})", "-$1").Substring(1) == txtSN.Text.Trim().Substring(10);
            if (isreg)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("CrazyIIS.xml");
                xmlDoc.SelectSingleNode("//Reg/PC").InnerText = txtCode.Text.Trim();
                xmlDoc.SelectSingleNode("//Reg/UserName").InnerText = txtU.Text.Trim();
                xmlDoc.SelectSingleNode("//Reg/SN").InnerText = txtSN.Text.Trim();
                xmlDoc.Save("CrazyIIS.xml");
                MessageBox.Show("注册成功");
            }


        }
    }
}
