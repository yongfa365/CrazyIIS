using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Management;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class frmMonitor : Form
    {
        Dictionary<string, Int32> List = new Dictionary<string, Int32>();
        public string Fields;
        public List<String> Webs = new List<string>();
        // public MatchCollection matchFields;
        public Dictionary<string, string> ShowFields = new Dictionary<string, string>();
        public frmMonitor()
        {
            InitializeComponent();
        }

        private void FrmMonitor_Load(object sender, EventArgs e)
        {
            Comm.DataGridViewSet(dataGridView1);
            FirstFill();

        }

        void FirstFill()
        {
            ShowFields.Clear();
            ShowFields.Add("Name", "网站名称");
            ShowFields.Add("ServiceUptime", "启动时间");
            ShowFields.Add("BytesReceivedPersec", "接收/秒");
            ShowFields.Add("BytesSentPersec", "发送/秒");
            ShowFields.Add("BytesTotalPersec", "收发/秒");
            ShowFields.Add("TotalBytesSent", "WEB发送");
            ShowFields.Add("TotalBytesReceived", "WEB接收");

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshDetails();
        }



        void RefreshDetails()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_W3SVC_WebService");

            if (dataGridView1.Columns.Count == 0 || dataGridView1.Rows.Count == 0)
            {
                SetColumns();
                SetRows();
            }
            else
            {
                foreach (ManagementObject queryObj in searcher.Get())
                {

                    if (Webs.Count == 0 || Webs.Contains(queryObj["Name"].ToString()))
                    {
                        foreach (var item in ShowFields)
                        {
                            dataGridView1[item.Key, List[queryObj["Name"].ToString()]].Value = queryObj[item.Key];

                        }
                    }

                }

                if (dataGridView1.SortedColumn != null)
                {
                    if (dataGridView1.SortOrder == SortOrder.Ascending)
                    {
                        dataGridView1.Sort(dataGridView1.SortedColumn, ListSortDirection.Ascending);
                    }
                    else
                    {
                        dataGridView1.Sort(dataGridView1.SortedColumn, ListSortDirection.Descending);
                    }
                    GetNewList();
                }

            }



        }
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            GetNewList();
        }
        void SetColumns()
        {
            dataGridView1.Columns.Clear();
            foreach (var item in ShowFields)
            {
                dataGridView1.Columns.Add(item.Key, item.Value);
            }

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].Name != "Name")
                {
                    dataGridView1.Columns[i].ValueType = typeof(Double);
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }

        }

        void SetRows()
        {
            dataGridView1.Rows.Clear();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_W3SVC_WebService");
            ManagementObjectCollection asss = searcher.Get();

            foreach (ManagementObject queryObj in asss)
            {

                if (Webs.Count == 0 || Webs.Contains(queryObj["Name"].ToString()))
                {
                    string s = "";
                    foreach (var item in ShowFields)
                    {
                        s += "," + queryObj[item.Key].ToString();
                    }
                    dataGridView1.Rows.Add(s.Substring(1).Split(','));
                }
            }
            GetNewList();
        }

        void GetNewList()
        {
            List.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                List.Add(dataGridView1["Name", i].Value.ToString(), i);
            }
        }

        private void btnSelectFields_Click(object sender, EventArgs e)
        {
            dlgSelectMonitorFields dlg = new dlgSelectMonitorFields();
            dlg.StartPosition = FormStartPosition.CenterParent;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowFields = dlg.MonitorFields;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                SetColumns();
            }
        }

        private void btnSelectWeb_Click(object sender, EventArgs e)
        {
            dlgSelectWeb dlg = new dlgSelectWeb();
            dlg.StartPosition = FormStartPosition.CenterParent;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Webs = dlg.Webs;
                if (Webs.Count > 0)
                {
                    if (dataGridView1.Columns.Count != 0)
                    {
                        dataGridView1.Rows.Clear();
                        foreach (string item in Webs)
                        {
                            int i = dataGridView1.Rows.Add();
                            dataGridView1["Name", i].Value = item;
                        }
                        GetNewList();
                    }
                }
                else
                {
                    SetRows();
                }

            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            RefreshDetails();
            timer1.Interval = Convert.ToInt32(textBox1.Text) * 1000;
            btnStart.Enabled = false;
            btnSelectFields.Enabled = false;
            btnSelectWeb.Enabled = false;
            timer1.Enabled = true;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnSelectFields.Enabled = true;
            btnSelectWeb.Enabled = true;
            timer1.Enabled = false;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string NowColumnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (NowColumnName.Contains("Bytes") && NowColumnName.Contains("Total") && !NowColumnName.Contains("Persec"))
            {
                double NowValue = Convert.ToDouble(e.Value);
                e.Value = (NowValue / 1024 / 1024).ToString("#,0 M");
            }
            else if (NowColumnName.Contains("Bytes"))
            {
                double NowValue = Convert.ToDouble(e.Value);
                e.Value = (NowValue / 1024).ToString("#,0 K");
            }
            if (NowColumnName == "ServiceUptime")
            {
                double NowValue = Convert.ToDouble(e.Value);
                e.Value = (NowValue / 60 / 60).ToString("00.00 小时");
            }
        }

        private void frmMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //不加这个，他还一直运行，太邪恶了
            timer1.Enabled = false;
        }
    }
}
