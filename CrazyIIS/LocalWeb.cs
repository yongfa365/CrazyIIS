using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class LocalWeb : UserControl
    {
        public DataGridView dgvWeb;
        public LocalWeb()
        {
            InitializeComponent();
        }

        public void SetAppPoolId(string app)
        {
            AppPoolId.SelectedItem = app;
            FillWeb();

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillWeb();
        }
        private void LocalWeb_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            //dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersWidth = 20;
            //dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;

            FillAppPools();
            FillServerAutoStart();
            dgvWeb = dataGridView1;
        }



        public void FillWeb()
        {


            DataView dv = Comm.GetAllWebInfo().DefaultView;
            string filter = " Id<>0 ";
            if (AppPoolId.Text != "全部")
            {
                filter += " and AppPoolId = '" + AppPoolId.Text + "'";
            }

            if (txtWeb.Text.Trim() != "")
            {
                filter += " and Web like '%" + txtWeb.Text.Trim() + "%'";
            }

            if (ServerAutoStart.SelectedValue.ToString() != "-1")
            {
                filter += " and ServerAutoStart = " + ServerAutoStart.SelectedValue;
            }


            dv.RowFilter = filter;
            dataGridView1.DataSource = dv;


            lblOK.Text = "总共：" + dataGridView1.Rows.Count + "条";
            lblOK.ForeColor = Color.Red;
            dgvWeb = dataGridView1;
        }

        public void FillAppPools(string[] s)
        {
            AppPoolId.Items.Clear();
            AppPoolId.Items.Add("全部");
            AppPoolId.Items.AddRange(s);
            AppPoolId.SelectedIndex = 0;
        }

        void FillAppPools()
        {
            AppPoolId.Items.AddRange(Comm.GetAppPools().ToArray());
            AppPoolId.SelectedIndex = AppPoolId.Items.Count - 1;
        }

        void FillServerAutoStart()
        {
            DataTable _dt = new DataTable();
            _dt.Columns.Add("Id");
            _dt.Columns.Add("Name");
            _dt.Rows.Add(-1, "全部");
            _dt.Rows.Add(true, "正常");
            _dt.Rows.Add(false, "关闭");
            ServerAutoStart.DataSource = _dt;
            ServerAutoStart.DisplayMember = "Name";
            ServerAutoStart.ValueMember = "Id";


        }
    }
}
