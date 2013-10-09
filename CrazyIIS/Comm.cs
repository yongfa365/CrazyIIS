using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.IO;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;


namespace CrazyIIS
{
    class WebAllInfo
    {
        public Int32 Id { get; set; }
        public string Web { get; set; }
        public string AppPoolId { get; set; }
        public string Path { get; set; }
        public bool ServerAutoStart { get; set; }
        public string ServerBindings { get; set; }

    }


    class Comm
    {

        public static bool IsReg()
        {
            return true;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("CrazyIIS.xml");
                return Regex.Replace(Encrypt(xmlDoc.SelectSingleNode("//Reg/PC").InnerText + xmlDoc.SelectSingleNode("//Reg/UserName").InnerText, "柳永法的CrazyIIS"), "(.{4})", "-$1").Substring(1) == xmlDoc.SelectSingleNode("//Reg/SN").InnerText.Trim().Substring(10);
            }
            catch
            {
                return false;
            }

        }

        public static string Encrypt(string strEncrypt, string strKey)
        {
            try
            {
                byte[] keyArray = UTF8Encoding.UTF8.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strKey, "md5"));
                byte[] strEncryptArray = UTF8Encoding.UTF8.GetBytes(strEncrypt);
                byte[] resultArray = null;

                using (RijndaelManaged rDel = new RijndaelManaged())
                {
                    rDel.Key = keyArray;
                    rDel.Mode = CipherMode.ECB;
                    rDel.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = rDel.CreateEncryptor();

                    resultArray = cTransform.TransformFinalBlock(strEncryptArray, 0, strEncryptArray.Length);

                }
                //return Convert.ToBase64String(resultArray, 0, resultArray.Length);

                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Convert.ToBase64String(resultArray, 0, resultArray.Length), "MD5");
            }
            catch
            {
                return null;
            }
        }


        public static bool RemoteFileExists(string furl)
        {
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(furl);
                HttpWebResponse myRes = (HttpWebResponse)myReq.GetResponse();
                if (myRes.ContentLength > 0)
                {
                    myRes.Close();
                    return true;
                }
                else
                {
                    myRes.Close();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        #region MetaBase
        public static string MetaBasePath()
        {
            return Environment.SystemDirectory + @"\inetsrv\MetaBase.xml";
        }

        public static string MetaBaseSave()
        {
            try
            {
                DirectoryEntry dir = new DirectoryEntry("IIS://localhost");
                dir.Invoke("SaveData", new object[0]);//保存配置到MetaBase.xml
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static void MetaBaseBackup(string name)
        {
            Comm.MetaBaseSave();
            DirectoryEntry dir = new DirectoryEntry("IIS://localhost");
            dir.Invoke("Backup", new object[3] { name, 1, 1 });
        }

        public static string MetaBaseRestore(string name)
        {
            try
            {
                DirectoryEntry dir = new DirectoryEntry("IIS://localhost");
                dir.Invoke("Restore", new object[3] { name, 1, 0 });
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static void MetaBaseRestore2Install()
        {
            MetaBaseRestore(MetaBaseFirstFileInfo().Name.Split('.')[0]);
        }

        public static FileInfo MetaBaseFirstFileInfo()
        {
            FileInfo FirstFile = null;
            foreach (FileInfo item in new DirectoryInfo(Environment.SystemDirectory + @"\inetsrv\MetaBack\").GetFiles("*.MD1"))
            {

                if (FirstFile == null)
                {
                    FirstFile = item;
                }
                else
                {
                    if (item.LastWriteTime < FirstFile.LastWriteTime)
                    {
                        FirstFile = item;
                    }
                }
            }
            return FirstFile;
        }


        #endregion

        public static DataTable GetAllWebInfo()
        {

            DataTable WebInfo = new DataTable();
            WebInfo.Columns.Add("Id");
            WebInfo.Columns.Add("Web");
            WebInfo.Columns.Add("AppPoolId");
            WebInfo.Columns.Add("Path");
            WebInfo.Columns.Add("ServerAutoStart");
            WebInfo.Columns.Add("ServerBindings");

            WebInfo.Columns["Id"].DataType = typeof(Int32);
            WebInfo.Columns["ServerAutoStart"].DataType = typeof(Boolean);

            Dictionary<string, WebAllInfo> dict = GetAllWebInfoDict();

            foreach (var item in dict.Values)
            {
                WebInfo.Rows.Add(item.Id, item.Web, item.AppPoolId, item.Path, item.ServerAutoStart, item.ServerBindings);
            }
            return WebInfo;
        }

        public static Dictionary<string, WebAllInfo> GetAllWebInfoDict()
        {
            MetaBaseSave();
            XmlDocument doc = new XmlDocument();
            doc.Load(Comm.MetaBasePath());
            XmlNamespaceManager xnm = new XmlNamespaceManager(doc.NameTable);
            xnm.AddNamespace("mxh", "urn:microsoft-catalog:XML_Metabase_V64_0");
            string Default_AppPoolId = doc.SelectSingleNode("/mxh:configuration/mxh:MBProperty/mxh:IIsWebService", xnm).Attributes["AppPoolId"].Value;

            XmlNodeList IIsWebServer = doc.SelectNodes("/mxh:configuration/mxh:MBProperty/mxh:IIsWebServer", xnm);
            XmlNodeList IIsWebVirtualDir = doc.SelectNodes("/mxh:configuration/mxh:MBProperty/mxh:IIsWebVirtualDir", xnm);

            Dictionary<string, WebAllInfo> _WebAllInfo = new Dictionary<string, WebAllInfo>();

            foreach (XmlNode item in IIsWebServer)
            {
                Match m = Regex.Match(item.Attributes["Location"].Value, "/LM/W3SVC/(\\d+)", RegexOptions.IgnoreCase);
                if (!m.Success)
                {
                    continue;
                }
                string Id = m.Groups[1].Value;

                WebAllInfo info = new WebAllInfo();
                info.Id = Convert.ToInt32(Id);
                info.Web = item.Attributes["ServerComment"].Value;
                info.ServerAutoStart = item.Attributes["ServerAutoStart"] == null ? true : Convert.ToBoolean(item.Attributes["ServerAutoStart"].Value);
                info.ServerBindings = item.Attributes["ServerBindings"].Value.Replace("\r\n", ",");
                _WebAllInfo.Add(Id, info);
            }

            foreach (XmlNode item in IIsWebVirtualDir)
            {
                Match m = Regex.Match(item.Attributes["Location"].Value, "/LM/W3SVC/(\\d+)/root", RegexOptions.IgnoreCase);
                if (!m.Success)
                {
                    continue;
                }
                string Id = m.Groups[1].Value;

                _WebAllInfo[Id].AppPoolId = item.Attributes["AppPoolId"] == null ? Default_AppPoolId : item.Attributes["AppPoolId"].Value;
                _WebAllInfo[Id].Path = item.Attributes["Path"].Value;

            }
            return _WebAllInfo;
        }

        //public static DataTable GetAllWebInfo2()
        //{

        //    //速度慢
        //    DataTable WebInfo = new DataTable();
        //    WebInfo.Columns.Add("Id");
        //    WebInfo.Columns.Add("Web");
        //    WebInfo.Columns.Add("AppPoolId");
        //    WebInfo.Columns.Add("Path");
        //    WebInfo.Columns.Add("ServerAutoStart");
        //    WebInfo.Columns.Add("ServerBindings");

        //    WebInfo.Columns["Id"].DataType = typeof(Int32);
        //    WebInfo.Columns["ServerAutoStart"].DataType = typeof(Boolean);


        //    IISConfig.Metabase metabase = new IISConfig.Metabase();
        //    metabase.OpenLocalMachine();

        //    IISConfig.IKey key = metabase.GetKeyFromPath("/LM/W3SVC");

        //    foreach (var item in key.Subkeys)
        //    {
        //        if (item.GetRecord(1002).Data.ToString() == "IIsWebServer")
        //        {

        //            WebInfo.Rows.Add(
        //                item.Name,
        //                item.GetRecord(1015).Data,
        //                item.Subkeys[0].GetRecord(9101).Data,
        //                item.Subkeys[0].GetRecord(3001).Data,
        //                item.GetRecord(1017) == null ? true : false,
        //                string.Join(",", item.GetRecord(1023).Data as string[])
        //                );

        //        }
        //    }

        //    return WebInfo;

        //}


        #region NewWebSiteId
        public static string GetNewWebSiteID(List<Int32> List)
        {

            List.Sort();
            int i = 1;
            foreach (int j in List)
            {
                if (i == j)
                {
                    i++;
                }
                else
                {
                    break;
                }

            }
            return i.ToString();
        }


        public static List<Int32> GetAllWebSiteID()
        {
            List<Int32> list = new List<Int32>();
            //DirectoryEntry dir = new DirectoryEntry("IIS://localhost/w3svc");

            //foreach (DirectoryEntry child in dir.Children)
            //{
            //    if (child.SchemaClassName == "IIsWebServer")
            //    {
            //        list.Add(Convert.ToInt32(child.Name));
            //    }
            //}
            MetaBaseSave();
            string MetaBase = File.ReadAllText(Comm.MetaBasePath());
            foreach (Match item in Regex.Matches(MetaBase, "W3SVC/(\\d+)\""))
            {
                list.Add(Convert.ToInt32(item.Groups[1].Value));
            }
            list.Sort();
            return list;

        }
        #endregion


        #region AppPoolId
        public static List<string> GetAppPoolsUsed()
        {
            Comm.MetaBaseSave();
            List<string> list = new List<string>();
            string MetaBase = File.ReadAllText(Comm.MetaBasePath());
            foreach (Match item in Regex.Matches(MetaBase, @"AppPoolId=""(.+?)"""))
            {
                if (!list.Contains(item.Groups[1].Value))
                {
                    list.Add(item.Groups[1].Value);
                }
            }
            return list;
        }

        public static List<string> GetAppPools()
        {
            List<string> list = new List<string>();
            IISConfig.Metabase metabase = new IISConfig.Metabase();
            metabase.OpenLocalMachine();

            IISConfig.IKey key = metabase.GetKeyFromPath("/LM/W3SVC/AppPools");
            foreach (var item in key.Subkeys)
            {
                list.Add(item.Name);
            }
            metabase.Close();
            return list;
        }


        //public static List<string> GetAppPools2()
        //{
        //    DirectoryEntry dir = new DirectoryEntry("IIS://localhost/w3svc/AppPools");
        //    List<string> list = new List<string>();
        //    foreach (DirectoryEntry child in dir.Children)
        //    {
        //        list.Add(child.Name);
        //    }
        //    return list;
        //}

        //public static List<string> GetAppPools()
        //{
        //    Comm.MetaBaseSave();
        //    List<string> list = new List<string>();
        //    string MetaBase = File.ReadAllText(Comm.MetaBasePath());
        //    foreach (Match item in Regex.Matches(MetaBase, @"/LM/W3SVC/AppPools/(.+?)"""))
        //    {
        //        list.Add(item.Groups[1].Value);
        //    }
        //    return list;
        //}



        #endregion


        #region Attributes
        public static string GetPropertyValue(DirectoryEntry dir, string Properties)
        {
            string split = "柳永法";
            PropertyValueCollection s = dir.Properties[Properties];

            if (s.Count == 0)
            {
                return s[0].ToString();
            }
            else
            {

                string temp = "";
                for (int i = 0; i < s.Count; i++)
                {
                    temp += split + s[i].ToString();
                }
                return temp.Substring(split.Length);
            }

        }
        public static string[] GetPropertyValueCollection(string str)
        {
            string split = "柳永法";
            return Regex.Split(str, split);
        }


        public static string GetDefaultAnonymousUserName()
        {
            return GetAttributesByPath("/mxh:configuration/mxh:MBProperty/mxh:IIsWebService", "AnonymousUserName");
        }

        public static string GetDefaultAppPoolId()
        {
            return GetIIsWebServiceAttributesByPath("AppPoolId");
        }

        public static string GetIIsWebServiceAttributesByPath(string Attributes)
        {
            return GetAttributesByPath("/mxh:configuration/mxh:MBProperty/mxh:IIsWebService", Attributes);
        }

        public static string GetAttributesByPath(string Path, string Attributes)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Comm.MetaBasePath());
            XmlNamespaceManager xnm = new XmlNamespaceManager(doc.NameTable);
            xnm.AddNamespace("mxh", "urn:microsoft-catalog:XML_Metabase_V64_0");
            if (doc.SelectSingleNode(Path, xnm).Attributes[Attributes] == null)
            {
                return null;
            }
            else
            {
                return doc.SelectSingleNode(Path, xnm).Attributes[Attributes].Value;
            }

        }

        #endregion



        public static string[] GetScriptMaps(string ver)
        {
            //如果他有一些其它脚本映射，如：php,jsp,就会出问题
            string s = "";
            switch (ver.ToLower())
            {

                case "v1.1.4322":
                    s = @".asp,C:\WINDOWS\system32\inetsrv\asp.dll,5,GET,HEAD,POST,TRACE
                            .cer,C:\WINDOWS\system32\inetsrv\asp.dll,5,GET,HEAD,POST,TRACE
                            .cdx,C:\WINDOWS\system32\inetsrv\asp.dll,5,GET,HEAD,POST,TRACE
                            .asa,C:\WINDOWS\system32\inetsrv\asp.dll,5,GET,HEAD,POST,TRACE
                            .idc,C:\WINDOWS\system32\inetsrv\httpodbc.dll,5,GET,POST
                            .shtm,C:\WINDOWS\system32\inetsrv\ssinc.dll,5,GET,POST
                            .shtml,C:\WINDOWS\system32\inetsrv\ssinc.dll,5,GET,POST
                            .stm,C:\WINDOWS\system32\inetsrv\ssinc.dll,5,GET,POST
                            .asax,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .ascx,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .ashx,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .asmx,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .aspx,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .axd,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .vsdisco,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .rem,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .soap,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .config,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .cs,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .csproj,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .vb,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .vbproj,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .webinfo,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .licx,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .resx,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .resources,C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG";
                    break;

                case "v2.0.50727":
                    s = @".asp,c:\WINDOWS\system32\inetsrv\asp.dll,5,GET,HEAD,POST,TRACE
                            .cer,C:\WINDOWS\system32\inetsrv\asp.dll,5,GET,HEAD,POST,TRACE
                            .cdx,C:\WINDOWS\system32\inetsrv\asp.dll,5,GET,HEAD,POST,TRACE
                            .asa,C:\WINDOWS\system32\inetsrv\asp.dll,5,GET,HEAD,POST,TRACE
                            .idc,C:\WINDOWS\system32\inetsrv\httpodbc.dll,5,GET,POST
                            .shtm,C:\WINDOWS\system32\inetsrv\ssinc.dll,5,GET,POST
                            .shtml,C:\WINDOWS\system32\inetsrv\ssinc.dll,5,GET,POST
                            .stm,C:\WINDOWS\system32\inetsrv\ssinc.dll,5,GET,POST
                            .asax,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .ascx,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .ashx,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .asmx,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .aspx,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .axd,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .vsdisco,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .rem,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .soap,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .config,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .cs,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .csproj,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .vb,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .vbproj,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .webinfo,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .licx,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .resx,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .resources,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .master,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .skin,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .compiled,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .browser,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .mdb,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .jsl,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .vjsproj,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .sitemap,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .msgx,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .ad,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .dd,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .ldd,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .sd,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .cd,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .adprototype,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .lddprototype,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .sdm,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .sdmDocument,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .ldb,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .svc,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,1,GET,HEAD,POST,DEBUG
                            .mdf,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .ldf,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .java,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .exclude,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG
                            .refresh,C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll,5,GET,HEAD,POST,DEBUG";
                    break;
                default:
                    break;
            }
            s = Regex.Replace(s, @"C:\\WINDOWS", Environment.GetEnvironmentVariable("windir").ToUpper(), RegexOptions.IgnoreCase);
            return Regex.Split(s, "\\s+");
        }



        /// <summary>
        /// 取得网页源码
        /// </summary>
        /// <param name="url">网页地址，eg: "http://www.yongfa365.com/" </param> 
        /// <param name="charset">网页编码，eg: Encoding.UTF8</param>
        /// <returns>返回网页源文件</returns>
        public static string GetHtmlSource(string url, Encoding charset)
        {
            //处理内容
            string html = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "Get";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2;)";
                request.Accept = "text/html";
                request.Referer = url;
                request.KeepAlive = true;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, charset);
                html = reader.ReadToEnd();
                stream.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return html;
        }


        public static void Write2hosts(string[] Hosts, bool Delete)
        {
            string hostsPath = Environment.SystemDirectory + @"\drivers\etc\hosts";
            string hostsNew = "";
            string hostsCnt = "";
            if (Delete)
            {
                hostsCnt = "127.0.0.1 localhost";
            }
            else
            {
                hostsCnt = File.ReadAllText(hostsPath);
            }


            for (int i = 0; i < Hosts.Length; i = i + 2)
            {
                string IP = Hosts[i];
                string Domain = Hosts[i + 1];
                if (!Regex.IsMatch(hostsCnt, IP + "\\s+" + Domain))
                {
                    hostsNew += "\r\n" + IP + " " + Domain;
                }

            }
            if (!File.Exists(hostsPath))
            {
                File.WriteAllText(hostsPath, "");
            }
            FileInfo f = new FileInfo(hostsPath);
            f.IsReadOnly = false;
            File.WriteAllText(hostsPath, hostsCnt + hostsNew);
            f.IsReadOnly = true;

        }












        public static void DataGridViewSet(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = true;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersWidth = 20;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ReadOnly = true;
        }


        //取CPU编号
        public static string GetCpuID()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    return mo.Properties["ProcessorId"].Value.ToString();
                }
                return "";
            }
            catch
            {
                return "";
            }

        }
        public static string Random(int length)
        {
            return Random((int)DateTime.Now.Ticks, length);
        }
        public static string Random(int zj, int length)
        {
            string Vchar = @"~!@#$%^&*()_+{}:""<>?/.,';][=-\|0123456789ABCDEFGHIJKLMNPQRSTUVWXYZabcdefghijklmnpqrstuvwxyz";
            Random rand = new Random(zj);
            string result = "";
            for (int i = 0; i < length; i++)
            {
                int t = rand.Next(Vchar.Length);
                result += Vchar[t];
            }
            return result;
        }

        public static string RandomNumber(int zj, int length)
        {
            string Vchar = "0123456789";
            Random rand = new Random(zj);
            string result = "";
            for (int i = 0; i < length; i++)
            {
                int t = rand.Next(Vchar.Length);
                result += Vchar[t];
            }
            return result;
        }

        public static string Random2(int length)
        {
            string Vchar = @"0123456789ABCDEFGHIJKLMNPQRSTUVWXYZ";
            Random rand = new Random();
            string result = "";
            for (int i = 0; i < length; i++)
            {
                int t = rand.Next(Vchar.Length);
                result += Vchar[t];
            }
            return result;
        }


    }
}
