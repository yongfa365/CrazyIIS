using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class frmPathACL : Form
    {
        public DataTable dt = new DataTable();
        public frmPathACL()
        {
            InitializeComponent();
        }

        private void frmPathACL_Load(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = " ACL like '%,IIS_WPG,%' or  ACL like '%,NETWORK SERVICE,%' ";

            dataGridView1.DataSource = dv.ToTable();
            dataGridView1.Columns[0].HeaderText = "路径";
            dataGridView1.Columns[1].HeaderText = "要添加的组或用户名";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1[1, i].Value = cbxGroups.Text;
            }
        }

        private void btnPathUser_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string _Path = dataGridView1[0, i].Value.ToString();
                string _ACL = dataGridView1[1, i].Value.ToString();

                if (Directory.Exists(_Path))
                {
                    foreach (string item in _ACL.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        NTFS.ACL.Add(_Path, item, NTFS.ACL.Roles.FullControl);
                    }
                }
            }
            MessageBox.Show("OK");
        }
    }
}
