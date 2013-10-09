using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class dlgSelectWeb : Form
    {
        public List<String> Webs = new List<string>();
        public dlgSelectWeb()
        {
            InitializeComponent();
        }

        private void dlgSelectWeb_Load(object sender, EventArgs e)
        {
            dgvOK.Columns.Add("Web", "Web");
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvOK.Rows.Count < 2)
            {
                MessageBox.Show("没选中任何网站");
                return;
            }
            Webs.Clear();

            string _temp = "";
            for (int i = 0; i < dgvOK.Rows.Count - 1; i++)
            {
                _temp = dgvOK["Web", i].Value.ToString();
                if (!string.IsNullOrEmpty(_temp) && !Webs.Contains(_temp))
                {
                    Webs.Add(_temp);
                }
            }
            this.DialogResult = DialogResult.OK;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in localWeb1.dgvWeb.SelectedRows)
            {
                dgvOK.Rows.Add(item.Cells["Web"].Value);
            }
        }


    }
}
