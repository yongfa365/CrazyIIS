using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class frmLogAnalyzer : Form
    {
        private readonly List<string> Ext_html = new List<string>("css|js|vbs|html|htm|txt".Split('|'));
        private readonly List<string> Ext_Dynamic = new List<string>("asp|asa|aspx|ascx|php|php2|php3|php4|php5".Split('|'));
        private readonly List<string> Ext_Compress = new List<string>("7z|ace|arj|bz2|cab|gz|gzip|hqx|img|iso|jar|lha|lzh|lzo|lzx|rar|tar|uue|zip|zoo".Split('|'));
        private readonly List<string> Ext_Picture = new List<string>("jpg|jpeg|bmp|gif|png".Split('|'));
        private readonly List<string> Ext_Music = new List<string>("mid|mp3|wav|wma".Split('|'));
        private readonly List<string> Ext_Movie = new List<string>("mp4|mov|mpg|mpeg|rm|rmvb|asf|avi|wmv|mkv|flv".Split('|'));
        private Dictionary<string, string> NowWeb = new Dictionary<string, string>();
        public frmLogAnalyzer()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            NowWeb.Clear();
            NowWeb.Add(cbxWeb.Text, cbxWeb.SelectedValue.ToString());
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            Dictionary<string, string> days = new Dictionary<string, string>();

            for (int i = 0; i < (dtp2.Value.Date - dtp1.Value.Date).Days + 1; i++)
            {
                days.Add(dtp1.Value.AddDays(i).ToString("yyyy-MM-dd"), dtp1.Value.AddDays(i).ToString("exyyMMdd") + ".log");
            }

            int NowIndex = -1;
            string NowWeb_Name = new List<string>(NowWeb.Keys)[0];
            string NowWeb_Id = NowWeb[NowWeb_Name];

            foreach (var item in days)
            {
                NowIndex++;

                LogInfo _loginfo = new LogInfo();
                _loginfo.OptTime = item.Key;
                _loginfo.Web = NowWeb_Name;

                try
                {
                    List<string> listHeader = new List<string>();
                    string _filename = Comm.GetAttributesByPath("/mxh:configuration/mxh:MBProperty/mxh:IIsWebServer[@Location ='/LM/W3SVC/" + NowWeb_Id + "']", "LogFileDirectory");
                    if (string.IsNullOrEmpty(_filename))
                    {
                        _filename = Comm.GetIIsWebServiceAttributesByPath("LogFileDirectory");

                    }
                    _filename = _filename + "\\W3SVC" + NowWeb_Id + "\\" + item.Value;

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
                            if (!listHeader.Contains("cs-uri-stem") || !listHeader.Contains("sc-bytes") || !listHeader.Contains("cs-bytes") || !listHeader.Contains("sc-status"))
                            {
                                continue;
                            }

                            string[] _fieldsItem = line.Split(new char[] { ' ' });

                            double _sc_bytes = Convert.ToDouble(_fieldsItem[listHeader.IndexOf("sc-bytes")]);
                            double _cs_bytes = Convert.ToDouble(_fieldsItem[listHeader.IndexOf("cs-bytes")]);
                            if (_fieldsItem[fileIndex].IndexOfAny(Path.GetInvalidPathChars()) == -1 && Path.HasExtension(_fieldsItem[fileIndex]))
                            {
                                string ext = Path.GetExtension(_fieldsItem[fileIndex]).Substring(1);
                                if (Ext_html.IndexOf(ext) > -1)
                                {
                                    _loginfo.HTML += _sc_bytes;
                                }
                                else if (Ext_Dynamic.IndexOf(ext) > -1)
                                {
                                    _loginfo.ASP += _sc_bytes;
                                }
                                else if (Ext_Compress.IndexOf(ext) > -1)
                                {
                                    _loginfo.RAR += _sc_bytes;
                                }
                                else if (Ext_Picture.IndexOf(ext) > -1)
                                {
                                    _loginfo.Pic += _sc_bytes;
                                }
                                else if (Ext_Music.IndexOf(ext) > -1)
                                {
                                    _loginfo.Music += _sc_bytes;
                                }
                                else if (Ext_Movie.IndexOf(ext) > -1)
                                {
                                    _loginfo.Movie += _sc_bytes;
                                }
                                if (_fieldsItem[listHeader.IndexOf("sc-status")] == "500")
                                {
                                    _loginfo.ASP500 = _loginfo.ASP500 + 1;
                                }
                                _loginfo.Down += _sc_bytes;
                                _loginfo.Up += _cs_bytes;

                            }

                        }

                    }
                    fs.Close();
                    reader.Close();


                    if (_loginfo.Down + _loginfo.Up == 0)
                    {
                        _loginfo.Remark = "您的IIS日志不信息不足，请先设置日志记录格式！";
                    }
                    backgroundWorker1.ReportProgress(NowIndex * 100 / days.Count, _loginfo);
                }
                catch (Exception ex)
                {
                    _loginfo.Remark = "错误：" + ex.Message;
                    backgroundWorker1.ReportProgress(NowIndex * 100 / days.Count, _loginfo);
                }


            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            LogInfo _loginfo = e.UserState as LogInfo;
            dataGridView1.Rows.Add(
                           _loginfo.OptTime,
                           _loginfo.Web,
                          _loginfo.Down + _loginfo.Up,
                           _loginfo.Down,
                           _loginfo.Up,
                           _loginfo.Pic,
                           _loginfo.ASP,
                           _loginfo.HTML,
                           _loginfo.RAR,
                           _loginfo.Music,
                           _loginfo.Movie,
                           _loginfo.ASP500,
                           _loginfo.Remark
                           );
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 100;

        }
















        private void frmLogAnalyzer_Load(object sender, EventArgs e)
        {
            cbxWeb.DataSource = Comm.GetAllWebInfo();
            cbxWeb.DisplayMember = "Web";
            cbxWeb.ValueMember = "Id";
            dtp1.Value = dtp1.Value.AddDays(-1);
            dtp2.Value = dtp2.Value.AddDays(-1);

            dataGridView1.Columns.Add("OptTime", "时间");
            dataGridView1.Columns.Add("Web", "站点");
            dataGridView1.Columns.Add("All", "总流量");
            dataGridView1.Columns.Add("Down", "下行");
            dataGridView1.Columns.Add("Up", "上行");
            dataGridView1.Columns.Add("Pic", "图片文件");
            dataGridView1.Columns.Add("ASP", "动态文件");
            dataGridView1.Columns.Add("HTML", "静态文件");
            dataGridView1.Columns.Add("RAR", "压缩软件");
            dataGridView1.Columns.Add("Music", "音频文件");
            dataGridView1.Columns.Add("Movie", "视频文件");
            dataGridView1.Columns.Add("500", "500错误");
            dataGridView1.Columns.Add("Remark", "备注");
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                if ("OptTime,Web,Remark".Contains(item.Name))
                {
                    continue;
                }
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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

        private void 设置日志到CrazyIIS推荐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLog("CrazyIIS", "CrazyIIS推荐");
        }

        private void 设置日志到系统默认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLog("Default", "系统默认");
        }

        private void 设置日志到全部记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLog("All", "全部记录");
        }

        void SetLog(string opt, string tip)
        {
            if (MessageBox.Show(tip, "IIS日志记录模式 将设置到", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            if (opt == "Default")
            {
                DirectoryEntry dir = new DirectoryEntry("IIS://localhost/w3svc");
                dir.Properties["LogExtFileFlags"].Value = 2199519;
                dir.Properties["LogFileLocaltimeRollover"].Value = false;
                dir.Properties["LogFilePeriod"].Value = 1;
                dir.Properties["LogInUTF8"].Value = false;
                dir.Properties["LogPluginClsid"].Value = "{FF160663-DE82-11CF-BC0A-00AA006111E0}";
                dir.Properties["LogType"].Value = 1;
                dir.CommitChanges();
            }
            else if (opt == "CrazyIIS")
            {
                DirectoryEntry dir = new DirectoryEntry("IIS://localhost/w3svc");
                dir.Properties["LogExtFileFlags"].Value = 3178375; //2129799
                dir.Properties["LogFileLocaltimeRollover"].Value = true;
                dir.Properties["LogFilePeriod"].Value = 1;
                dir.Properties["LogInUTF8"].Value = false;
                dir.Properties["LogPluginClsid"].Value = "{FF160663-DE82-11CF-BC0A-00AA006111E0}";
                dir.Properties["LogType"].Value = 1;
                dir.CommitChanges();
            }
            else if (opt == "All")
            {
                DirectoryEntry dir = new DirectoryEntry("IIS://localhost/w3svc");

                dir.Properties["LogExtFileFlags"].Value = 4194303;
                dir.Properties["LogFileLocaltimeRollover"].Value = true;
                dir.Properties["LogFilePeriod"].Value = 1;
                dir.Properties["LogInUTF8"].Value = false;
                dir.Properties["LogPluginClsid"].Value = "{FF160663-DE82-11CF-BC0A-00AA006111E0}";
                dir.Properties["LogType"].Value = 1;
                dir.CommitChanges();
            }
            if (MessageBox.Show("让所有站点日志记录方式继承此模式", "IIS日志记录模式", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                IISConfig.Metabase metabase = new IISConfig.Metabase();
                metabase.OpenLocalMachine();

                string MetaBase = File.ReadAllText(Comm.MetaBasePath());
                MatchCollection matchs = Regex.Matches(MetaBase, @"Location\s*=\s*""(/LM/W3SVC/\d+)""", RegexOptions.IgnoreCase);
                foreach (Match item in matchs)
                {
                    IISConfig.IKey key = metabase.GetKeyFromPath(item.Groups[1].Value);
                    if (key.GetRecord(4013) != null)
                    {
                        key.DeleteRecord(4013);
                    }
                }
            }
            MessageBox.Show("OK,设置完成,明天及以后可以使用此功能");
        }

        private void 查看当前日志记录情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryEntry dir = new DirectoryEntry("IIS://localhost/w3svc");
            MessageBox.Show(dir.Properties["LogExtFileFlags"].Value.ToString());

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string NowColumnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if ("All,Down,Up,Pic,ASP,HTML,RAR,Music,Movie".Contains(NowColumnName))
            {
                double NowValue = Convert.ToDouble(e.Value);
                e.Value = (NowValue / 1024 / 1024).ToString("#,0 M");
            }
        }

    }
    class LogInfo
    {
        public string OptTime { get; set; }
        public string Web { get; set; }
        public double All { get; set; }
        public double Down { get; set; }
        public double Up { get; set; }
        public double Pic { get; set; }
        public double ASP { get; set; }
        public double HTML { get; set; }
        public double RAR { get; set; }
        public double Music { get; set; }
        public double Movie { get; set; }
        public double ASP500 { get; set; }
        public string Remark { get; set; }
    }

}
