using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class frmProcess : Form
    {
        ManagementObjectSearcher Searcher = new ManagementObjectSearcher();
        Process[] Processes;
        Dictionary<int, int> DictDGV = new Dictionary<int, int>();
        Dictionary<int, ProcessInfo> OldProcessInfo = new Dictionary<int, ProcessInfo>();
        DateTime lastSysTime = DateTime.Now;//更新最后刷新时间
        int newTimePercent = 0;
        string DefaultAppPoolId = Comm.GetDefaultAppPoolId();


        public frmProcess()
        {
            InitializeComponent();
        }

        private void frmProcess_Load(object sender, EventArgs e)
        {
            dgvProcess.Columns.Add("ProcessId", "PID");
            dgvProcess.Columns.Add("Name", "映像名称");
            dgvProcess.Columns.Add("Intro", "应用程序池");

            dgvProcess.Columns.Add("CPU", "CPU");
            dgvProcess.Columns.Add("Memory", "内存使用");
            Comm.DataGridViewSet(dgvProcess);
            dgvProcess.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProcess.AllowUserToOrderColumns = false;
            dgvProcess.Columns["ProcessId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProcess.Columns["CPU"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProcess.Columns["Memory"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        void Refresh2()
        {
            Dictionary<int, ProcessInfo> NowProcessInfo = new Dictionary<int, ProcessInfo>();
            Processes = Process.GetProcessesByName("w3wp");
            //Processes = Process.GetProcesses();
            foreach (Process instance in Processes)
            {

                if (!OldProcessInfo.ContainsKey(instance.Id))
                {
                    try
                    {
                        ProcessInfo p = new ProcessInfo();
                        p.ProcessId = instance.Id;
                        p.Name = instance.MainModule.ModuleName;
                        p.Memory = instance.WorkingSet64;
                        p.ProcessorTime = instance.TotalProcessorTime.TotalMilliseconds;
                        p.CPU = 0;
                        OldProcessInfo.Add(p.ProcessId, p);
                        NowProcessInfo.Add(p.ProcessId, p);
                    }
                    catch
                    {

                    }

                }
                else
                {
                    #region 计算cpu占用率
                    TimeSpan ts = (TimeSpan)(DateTime.Now - lastSysTime);
                    double sysTimeSpan = ts.TotalMilliseconds;
                    //double processorTimeSpan = (double)Math.Abs(instance.TotalProcessorTime.TotalMilliseconds - NowProcessInfo[instance.Id].ProcessorTime);
                    double processorTimeSpan = (double)Math.Abs(instance.TotalProcessorTime.TotalMilliseconds - OldProcessInfo[instance.Id].ProcessorTime);
                    if (sysTimeSpan != 0)
                    {
                        processorTimeSpan = processorTimeSpan / sysTimeSpan;
                        newTimePercent = (int)(processorTimeSpan * 100 / Environment.ProcessorCount);

                        if (newTimePercent >= 100)
                        {
                            newTimePercent = 99;
                        }
                    }
                    else
                    {
                        newTimePercent = 0;
                    }
                    #endregion

                    OldProcessInfo[instance.Id].CPU = newTimePercent;
                    OldProcessInfo[instance.Id].Memory = instance.WorkingSet64;
                    OldProcessInfo[instance.Id].ProcessorTime = instance.TotalProcessorTime.TotalMilliseconds;

                    NowProcessInfo.Add(instance.Id, OldProcessInfo[instance.Id]);
                }
            }

            Searcher = new ManagementObjectSearcher("root\\CIMV2", "select * from Win32_Process where Name='w3wp.exe'");
            foreach (ManagementObject item in Searcher.Get())
            {
                string app = "DefaultAppPoolId";
                if (item["CommandLine"] != null)
                {
                    Match m = Regex.Match(item["CommandLine"].ToString(), @"-ap\s+""(.+?)""");
                    if (m.Success)
                    {
                        app = m.Groups[1].Value;
                    }
                }


                if (NowProcessInfo.ContainsKey(Convert.ToInt32(item["ProcessId"])))
                {
                    NowProcessInfo[Convert.ToInt32(item["ProcessId"])].Intro = app;
                }

            }

            //更新dgv数据
            foreach (var item in NowProcessInfo.Values)
            {
                if (!DictDGV.ContainsKey(item.ProcessId))
                {
                    int haha = dgvProcess.Rows.Add(item.ProcessId, item.Name, item.Intro, item.CPU, item.Memory);
                    DictDGV.Add(item.ProcessId, haha);
                }
                else
                {
                    dgvProcess["Memory", DictDGV[item.ProcessId]].Value = item.Memory;
                    dgvProcess["CPU", DictDGV[item.ProcessId]].Value = item.CPU;

                }
            }

            foreach (int item in new List<int>(OldProcessInfo.Keys))
            {
                if (!NowProcessInfo.ContainsKey(item))
                {
                    OldProcessInfo.Remove(item);
                }
            }


            //删除过期进程
            foreach (DataGridViewRow item in dgvProcess.Rows)
            {

                if (!NowProcessInfo.ContainsKey(Convert.ToInt32(item.Cells["ProcessId"].Value)))
                {
                    dgvProcess.Rows.Remove(item);
                }
            }

            if (dgvProcess.SortedColumn != null)
            {
                if (dgvProcess.SortOrder == SortOrder.Ascending)
                {
                    dgvProcess.Sort(dgvProcess.SortedColumn, ListSortDirection.Ascending);
                }
                else
                {
                    dgvProcess.Sort(dgvProcess.SortedColumn, ListSortDirection.Descending);
                }

            }

            GetNewList();
            lastSysTime = DateTime.Now;

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //Stopwatch sp = new Stopwatch();
            //sp.Start();

            Refresh2();
            //sp.Stop();
            //MessageBox.Show(sp.ElapsedMilliseconds.ToString());
        }

        private void dgvProcess_Sorted(object sender, EventArgs e)
        {
            GetNewList();
        }

        void GetNewList()
        {
            //重新获取dgv列表

            DictDGV.Clear();
            for (int i = 0; i < dgvProcess.Rows.Count; i++)
            {
                DictDGV.Add(Convert.ToInt32(dgvProcess["ProcessId", i].Value), i);
            }

        }

        private void 结束进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvProcess.Rows.Count == 0)
            {
                return;
            }
            int ProcessId = Convert.ToInt32(dgvProcess["ProcessId", dgvProcess.CurrentCell.RowIndex].Value);
            string Name = dgvProcess["Name", dgvProcess.CurrentCell.RowIndex].Value.ToString();

            DialogResult dr = MessageBox.Show(string.Format("确定要结束进程 {0} {1} 吗？", ProcessId, Name),
                    "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                Process.GetProcessById(ProcessId).Kill();
            }
        }

        private void 拆分应用程序池ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvProcess.Rows.Count == 0)
            {
                return;
            }
            string Intro = dgvProcess["Intro", dgvProcess.CurrentCell.RowIndex].Value.ToString();
            frmWebSites frm = new frmWebSites();
            frm.InAppPoolId = Intro;
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                int ProcessId = Convert.ToInt32(dgvProcess["ProcessId", dgvProcess.CurrentCell.RowIndex].Value);
                Process.GetProcessById(ProcessId).Kill();
            }

        }
        private void 分析应用程序池对应的网站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvProcess.Rows.Count == 0)
            {
                return;
            }
            string Intro = dgvProcess["Intro", dgvProcess.CurrentCell.RowIndex].Value.ToString();
            DataView dv = Comm.GetAllWebInfo().DefaultView;
            dv.RowFilter = " AppPoolId = '" + Intro + "'";
            if (dv.Count > 1)
            {
                MessageBox.Show("此应用程序池有多个站点，\n\n请先折分应用程序池，\n\n保证要分析的网站只在一个应用程序池里");
            }
            frmLogTimelyView frm = new frmLogTimelyView();
            frm.Id = dv[0]["Id"].ToString();
            frm.Web = dv[0]["Web"].ToString();
            frm.ShowDialog();
        }


        private void dgvProcess_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvProcess.ClearSelection();
                dgvProcess.Rows[e.RowIndex].Selected = true;
                dgvProcess.CurrentCell = dgvProcess.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void frmProcess_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void dgvProcess_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string NowColumnName = dgvProcess.Columns[e.ColumnIndex].Name;
            if (NowColumnName == "Memory")
            {
                double NowValue = Convert.ToDouble(e.Value);
                e.Value = (NowValue / 1024).ToString("#,# K");
            }
        }


    }


    class ProcessInfo
    {
        public Int32 ProcessId { get; set; }
        public string Name { get; set; }
        public float CPU { get; set; }
        public long Memory { get; set; }
        public string Intro { get; set; }
        public double ProcessorTime { get; set; }




    }
}
