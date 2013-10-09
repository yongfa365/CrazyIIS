using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace CrazyIIS
{
    public partial class frmConfigs : Form
    {
        public frmConfigs()
        {
            InitializeComponent();
        }

        private void IIS_Configs_Load(object sender, EventArgs e)
        {
            Comm.MetaBaseSave();
            XmlDocument doc = new XmlDocument();
            doc.Load(Comm.MetaBasePath());
            XmlNamespaceManager xnm = new XmlNamespaceManager(doc.NameTable);
            xnm.AddNamespace("mxh", "urn:microsoft-catalog:XML_Metabase_V64_0");

            XmlNode NowNode = doc.SelectSingleNode("/mxh:configuration/mxh:MBProperty/mxh:IIsWebService", xnm);

            AspMaxRequestEntityAllowed.Text = NowNode.Attributes["AspMaxRequestEntityAllowed"].Value;
            DefaultDoc.Text = NowNode.Attributes["DefaultDoc"].Value;
            LogFileDirectory.Text = NowNode.Attributes["LogFileDirectory"].Value;
            AspEnableParentPaths.Checked = Convert.ToBoolean(NowNode.Attributes["AspEnableParentPaths"].Value);
            ScriptMaps.SelectedItem = Regex.Match(NowNode.Attributes["ScriptMaps"].Value, @"Framework\\(.+?)\\aspnet", RegexOptions.IgnoreCase).Groups[1].Value;

            NowNode = doc.SelectSingleNode("/mxh:configuration/mxh:MBProperty/mxh:IIsCompressionSchemes", xnm);

            if (
                Convert.ToBoolean(NowNode.Attributes["HcDoDynamicCompression"].Value)
                && Convert.ToBoolean(NowNode.Attributes["HcDoOnDemandCompression"].Value)
                && Convert.ToBoolean(NowNode.Attributes["HcDoStaticCompression"].Value)
                )
            {
                GZIP.Checked = true;
            }
            else
            {
                GZIP.Checked = false;
            }
            txtGzipPath.Text = NowNode.Attributes["HcCompressionDirectory"].Value;

            NowNode = doc.SelectSingleNode("/mxh:configuration/mxh:MBProperty/mxh:IIsComputer", xnm);
            EnableEditWhileRunning.Checked = NowNode.Attributes["EnableEditWhileRunning"].Value == "1" ? true : false;

            NowNode = doc.SelectSingleNode("/mxh:configuration/mxh:MBProperty/mxh:IIsMimeMap", xnm);
            FLV.Checked = NowNode.Attributes["MimeMap"].Value.ToLower().Contains(".flv,");


        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            DirectoryEntry dir = new DirectoryEntry("IIS://localhost/w3svc");
            dir.Properties["AspMaxRequestEntityAllowed"].Value = AspMaxRequestEntityAllowed.Text;
            dir.Properties["DefaultDoc"].Value = DefaultDoc.Text;
            dir.Properties["LogFileDirectory"].Value = LogFileDirectory.Text;
            dir.Properties["AspEnableParentPaths"].Value = AspEnableParentPaths.Checked;

            dir.Properties["ScriptMaps"].Value = Comm.GetScriptMaps(ScriptMaps.Text);

            dir.CommitChanges();

            SET_GZIP(GZIP.Checked, txtGzipPath.Text.Trim());


            SetMimeTypeProperty("IIS://localhost/MimeMap", ".flv", "flv-application/octet-stream", FLV.Checked);

            DirectoryEntry dir2 = new DirectoryEntry("IIS://localhost");
            dir2.Properties["EnableEditWhileRunning"].Value = EnableEditWhileRunning.Checked ? "1" : "0";
            dir2.CommitChanges();
            dir2.Invoke("SaveData", new object[0]);//保存配置到MetaBase.xml
            //dir2.Invoke("Backup", new object[3]{"haha", 1,1});
            //dir2.Invoke("Backup", new object[3] { "haha", 2, 1 });
            //dir2.Invoke("Backup", new object[3] { "haha", 3, 2 });
            //dir2.Invoke("Backup", new object[3] { "haha2", 1,1 });
            //dir2.Invoke("Restore",new object[3] { "haha2", 1,0 });
            btnEdit.Enabled = true;
            MessageBox.Show("OK");

        }

        void SET_GZIP(bool Enable, string HcCompressionDirectory)
        {
            if (Enable)
            {
                DirectoryEntry dir2 = new DirectoryEntry("IIS://localhost/w3svc/Filters/Compression/deflate");
                dir2.Properties["HcCompressionDll"].Value = Environment.SystemDirectory + @"\inetsrv\gzip.dll";
                dir2.Properties["HcCreateFlags"].Value = 0;
                dir2.Properties["HcDoDynamicCompression"].Value = true;
                dir2.Properties["HcDoOnDemandCompression"].Value = true;
                dir2.Properties["HcDoStaticCompression"].Value = true;
                dir2.Properties["HcDynamicCompressionLevel"].Value = 9;
                dir2.Properties["HcFileExtensions"].Value = "htm,html,txt,js,xml,css".Split(',');
                dir2.Properties["HcOnDemandCompLevel"].Value = 9;
                dir2.Properties["HcPriority"].Value = 1;
                dir2.Properties["HcScriptFileExtensions"].Value = "asp,dll,exe,aspx,asmx".Split(',');
                dir2.CommitChanges();

                DirectoryEntry dir3 = new DirectoryEntry("IIS://localhost/w3svc/Filters/Compression/GZIP");
                dir3.Properties["HcCompressionDll"].Value = Environment.SystemDirectory + @"\inetsrv\gzip.dll";
                dir3.Properties["HcCreateFlags"].Value = 1;
                dir3.Properties["HcDoDynamicCompression"].Value = true;
                dir3.Properties["HcDoOnDemandCompression"].Value = true;
                dir3.Properties["HcDoStaticCompression"].Value = true;
                dir3.Properties["HcDynamicCompressionLevel"].Value = 9;
                dir3.Properties["HcFileExtensions"].Value = "htm,html,txt,js,xml,css".Split(',');
                dir3.Properties["HcOnDemandCompLevel"].Value = 9;
                dir3.Properties["HcPriority"].Value = 1;
                dir3.Properties["HcScriptFileExtensions"].Value = "asp,dll,exe,aspx,asmx".Split(',');
                dir3.CommitChanges();


                DirectoryEntry dir4 = new DirectoryEntry("IIS://localhost/w3svc/Filters/Compression/Parameters");
                dir4.Properties["HcCacheControlHeader"].Value = "max-age=86400";
                dir4.Properties["HcCompressionBufferSize"].Value = 102400;
                dir4.Properties["HcCompressionDirectory"].Value = HcCompressionDirectory == null ? Environment.GetEnvironmentVariable("windir") + @"\IIS Temporary Compressed Files" : HcCompressionDirectory;
                dir4.Properties["HcDoDiskSpaceLimiting"].Value = false;
                dir4.Properties["HcDoDynamicCompression"].Value = true;
                dir4.Properties["HcDoOnDemandCompression"].Value = true;
                dir4.Properties["HcDoStaticCompression"].Value = true;
                dir4.Properties["HcExpiresHeader"].Value = "Wed, 01 Jan 1997 12:00:00 GMT";
                dir4.Properties["HcFilesDeletedPerDiskFree"].Value = 256;
                dir4.Properties["HcIoBufferSize"].Value = 102400;
                dir4.Properties["HcMaxDiskSpaceUsage"].Value = 0;
                dir4.Properties["HcMaxQueueLength"].Value = 1000;
                dir4.Properties["HcMinFileSizeForComp"].Value = 1;
                dir4.Properties["HcNoCompressionForHttp10"].Value = false;
                dir4.Properties["HcNoCompressionForProxies"].Value = false;
                dir4.Properties["HcNoCompressionForRange"].Value = false;
                dir4.Properties["HcSendCacheHeaders"].Value = false;
                dir4.CommitChanges();
            }
            else
            {
                DirectoryEntry dir4 = new DirectoryEntry("IIS://localhost/w3svc/Filters/Compression/Parameters");
                dir4.Properties["HcDoDynamicCompression"].Value = false;
                dir4.Properties["HcDoOnDemandCompression"].Value = false;
                dir4.Properties["HcDoStaticCompression"].Value = false;
                dir4.CommitChanges();
            }
        }

        private void 默认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AspMaxRequestEntityAllowed.Text = "204800";
            DefaultDoc.Text = "Default.htm,Default.asp,index.htm,Default.aspx";
            LogFileDirectory.Text = Environment.SystemDirectory + @"\LogFiles";
            AspEnableParentPaths.Checked = false;
            ScriptMaps.SelectedItem = "v1.1.4322";
            txtGzipPath.Text = Environment.GetEnvironmentVariable("windir") + @"\IIS Temporary Compressed Files";
            GZIP.Checked = false;
            EnableEditWhileRunning.Checked = false;
            FLV.Checked = false;
        }


        private void 服务器推荐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AspMaxRequestEntityAllowed.Text = "20480000";
            DefaultDoc.Text = "Index.htm,Index.html,Index.asp,Default.aspx";
            LogFileDirectory.Text = @"D:\WWW\Log";
            AspEnableParentPaths.Checked = true;
            ScriptMaps.SelectedItem = "v1.1.4322";
            txtGzipPath.Text = @"D:\WWW\Gzip";
            GZIP.Checked = true;
            EnableEditWhileRunning.Checked = false;
            FLV.Checked = true;
        }

        private void 开发员推荐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AspMaxRequestEntityAllowed.Text = "20480000";
            DefaultDoc.Text = "Index.htm,Index.html,Index.asp,Default.aspx";
            LogFileDirectory.Text = Environment.SystemDirectory + @"\LogFiles";
            AspEnableParentPaths.Checked = true;
            ScriptMaps.SelectedItem = "v2.0.50727";
            txtGzipPath.Text = Environment.GetEnvironmentVariable("windir") + @"\IIS Temporary Compressed Files";
            GZIP.Checked = false;
            EnableEditWhileRunning.Checked = true;
            FLV.Checked = true;
        }

        void SetMimeTypeProperty(string metabasePath, string newExtension, string newMimeType, bool isReset)
        {
            IISConfig.Metabase metabase = new IISConfig.Metabase();
            metabase.OpenLocalMachine();

            IISConfig.IKey key = metabase.GetKeyFromPath("LM/MimeMap");
            IISConfig.Record record = key.GetRecord(6015);

            List<String> list = new List<string>();
            foreach (var item in record.Data as string[])
            {
                if (!item.StartsWith(newExtension + ","))
                {
                    list.Add(item);
                }
            }
            if (isReset)
            {
                list.Add(newExtension + "," + newMimeType);
            }
            record.Data = list.ToArray();
            key.SetRecord(record);
            metabase.Close();
        }

        private void btnSaveMetabase_Click(object sender, EventArgs e)
        {
            Comm.MetaBaseSave();
            MessageBox.Show("OK");
        }


    }
}
