using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class frmLogTimelyView : Form
    {
        public string Id;
        public string Web;
        public string LogFile;
        DataTable dtNow = new DataTable();
        public frmLogTimelyView()
        {
            InitializeComponent();
        }


        private void frmLogTimelyView_Load(object sender, EventArgs e)
        {
            cbxWeb.DisplayMember = "Web";
            cbxWeb.ValueMember = "Id";
            cbxWeb.DataSource = Comm.GetAllWebInfo();

            if (!string.IsNullOrEmpty(Web))
            {
                cbxWeb.Text = Web;
            }

            //dataGridView1.Columns.Add("OptTime", "时间");
            //dataGridView1.Columns.Add("Web", "站点");
            //dataGridView1.Columns.Add("time-taken", "执行时间");
            //dataGridView1.Columns.Add("Remark", "备注");

            dtNow.Columns.Add("时间", typeof(DateTime));
            dtNow.Columns.Add("网址");
            dtNow.Columns.Add("耗时(ms)", typeof(Int32));
            dtNow.Columns.Add("备注");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtNow.Rows.Clear();
            Id = cbxWeb.SelectedValue.ToString();
            Web = cbxWeb.SelectedText;
            LogFile = dtp1.Value.ToString("exyyMMdd") + ".log";
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            try
            {
                List<string> listHeader = new List<string>();
                string _filename = Comm.GetAttributesByPath("/mxh:configuration/mxh:MBProperty/mxh:IIsWebServer[@Location ='/LM/W3SVC/" + Id + "']", "LogFileDirectory");
                if (string.IsNullOrEmpty(_filename))
                {
                    _filename = Comm.GetIIsWebServiceAttributesByPath("LogFileDirectory");

                }
                _filename = _filename + "\\W3SVC" + Id + "\\" + LogFile;

                FileStream fs = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader reader = new StreamReader(fs, System.Text.Encoding.Default);

                int fileIndex = 0;

                while (reader.Peek() > -1)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    if (IsLogHeader(line))
                    {
                        if (line.StartsWith("#Fields:"))
                        {
                            string temp = line.Substring(9).Trim();
                            string[] header = temp.Split(new char[] { ' ' });
                            listHeader.AddRange(header);
                            fileIndex = listHeader.IndexOf("cs-uri-stem");
                        }
                    }
                    else
                    {
                        if (
                            !listHeader.Contains("date") ||
                            !listHeader.Contains("time") ||
                            !listHeader.Contains("cs-uri-stem") ||
                            !listHeader.Contains("time-taken") ||
                            !listHeader.Contains("cs-host")

                            )
                        {
                            continue;
                        }

                        string[] _fieldsItem = line.Split(new char[] { ' ' });

                        if (_fieldsItem[fileIndex].IndexOfAny(Path.GetInvalidPathChars()) == -1 && Path.HasExtension(_fieldsItem[fileIndex]))
                        {
                            string ext = Path.GetExtension(_fieldsItem[fileIndex]).Substring(1);
                            if ("asp|asa|aspx|ascx|php|php2|php3|php4|php5".IndexOf(ext) > -1)
                            {
                                if (Convert.ToDecimal(_fieldsItem[listHeader.IndexOf("time-taken")]) > numericUpDown1.Value)
                                {
                                    dtNow.Rows.Add(
    TimeZone.CurrentTimeZone.ToLocalTime(Convert.ToDateTime(_fieldsItem[listHeader.IndexOf("date")] + " " + _fieldsItem[listHeader.IndexOf("time")])),
    "http://" + _fieldsItem[listHeader.IndexOf("cs-host")] + _fieldsItem[listHeader.IndexOf("cs-uri-stem")],
    _fieldsItem[listHeader.IndexOf("time-taken")]
                                            );
                                }

                            }

                        }

                    }

                }
                fs.Close();
                reader.Close();

            }
            catch (Exception ex)
            {
                dtNow.Rows.Add(null, null, null, ex.Message);
            }


        }

        bool IsLogHeader(string line)
        {
            bool isHeader = false;

            if (string.IsNullOrEmpty(line))
                return isHeader;

            if (line.StartsWith("#"))
                isHeader = true;

            return isHeader;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.DataSource = dtNow;

        }

    }
}
