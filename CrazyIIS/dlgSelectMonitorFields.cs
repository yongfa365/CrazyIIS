using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class dlgSelectMonitorFields : Form
    {
        public Dictionary<string, string> MonitorFields = new Dictionary<string, string>();
        public dlgSelectMonitorFields()
        {
            InitializeComponent();
        }


        private void dlgSelectMonitorFields_Load(object sender, EventArgs e)
        {


        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            dgvFeilds.Rows.Clear();
            dgvFeilds.Rows.Add("Name", "网站名称");
            dgvFeilds.Rows.Add("BytesReceivedPersec", "接收/秒");
            dgvFeilds.Rows.Add("BytesSentPersec", "发送/秒");
        }

        private void btnBest1_Click(object sender, EventArgs e)
        {
            dgvFeilds.Rows.Clear();
            dgvFeilds.Rows.Add("Name", "网站名称");
            dgvFeilds.Rows.Add("ServiceUptime", "启动时间");
            dgvFeilds.Rows.Add("BytesReceivedPersec", "接收/秒");
            dgvFeilds.Rows.Add("BytesSentPersec", "发送/秒");
            dgvFeilds.Rows.Add("BytesTotalPersec", "收发/秒");
            dgvFeilds.Rows.Add("TotalBytesSent", "WEB发送");
            dgvFeilds.Rows.Add("TotalBytesReceived", "WEB接收");
            dgvFeilds.Rows.Add("TotalBytesTransfered", "WEB总收发");
        }


        private void btnBest_Click(object sender, EventArgs e)
        {
            dgvFeilds.Rows.Clear();
            dgvFeilds.Rows.Add("Name", "网站名称");
            dgvFeilds.Rows.Add("ServiceUptime", "IIS启动了多久");
            dgvFeilds.Rows.Add("BytesReceivedPersec", "接收/秒");
            dgvFeilds.Rows.Add("BytesSentPersec", "发送/秒");
            dgvFeilds.Rows.Add("BytesTotalPersec", "收发/秒");
            dgvFeilds.Rows.Add("FilesPersec", "文件数/秒");
            dgvFeilds.Rows.Add("FilesReceivedPersec", "接收文件/秒");
            dgvFeilds.Rows.Add("FilesSentPersec", "发送文件/秒");
            dgvFeilds.Rows.Add("GetRequestsPersec", "GET请求/秒");
            dgvFeilds.Rows.Add("PostRequestsPersec", "POST请求/秒");
            dgvFeilds.Rows.Add("HeadRequestsPersec", "HEAD请求/秒");
            dgvFeilds.Rows.Add("NonAnonymousUsersPersec", "匿名用户请求/秒");
            dgvFeilds.Rows.Add("NotFoundErrorsPersec", "404请求/秒");
            dgvFeilds.Rows.Add("TotalBytesSent", "WEB发送");
            dgvFeilds.Rows.Add("TotalBytesReceived", "WEB接收");
            dgvFeilds.Rows.Add("TotalBytesTransfered", "WEB总收发");
            dgvFeilds.Rows.Add("TotalFilesSent", "发送文件数");
            dgvFeilds.Rows.Add("TotalFilesReceived", "接收文件数");
            dgvFeilds.Rows.Add("TotalFilesTransferred", "总文件数");
            dgvFeilds.Rows.Add("CurrentAnonymousUsers", "当前匿名请求数");
            dgvFeilds.Rows.Add("TotalAnonymousUsers", "匿名请求总数");
            dgvFeilds.Rows.Add("CurrentConnections", "当前连接数");
            dgvFeilds.Rows.Add("MaximumConnections", "最大连接数");
            dgvFeilds.Rows.Add("TotalGetRequests", "GET请求数");
            dgvFeilds.Rows.Add("TotalPostRequests", "POST请求数");
            dgvFeilds.Rows.Add("TotalMethodRequests", "总HTTP请求数");
            dgvFeilds.Rows.Add("TotalNotFoundErrors", "总404错误数");
            dgvFeilds.Rows.Add("TotalHeadRequests", "HEAD请求数");
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            string Fields = @"
AnonymousUsersPersec
BytesReceivedPersec
BytesSentPersec
BytesTotalPersec
Caption
CGIRequestsPersec
ConnectionAttemptsPersec
CopyRequestsPersec
CurrentAnonymousUsers
CurrentBlockedAsyncIORequests
Currentblockedbandwidthbytes
CurrentCALcountforauthenticatedusers
CurrentCALcountforSSLconnections
CurrentCGIRequests
CurrentConnections
CurrentISAPIExtensionRequests
CurrentNonAnonymousUsers
DeleteRequestsPersec
Description
FilesPersec
FilesReceivedPersec
FilesSentPersec
Frequency_Object
Frequency_PerfTime
Frequency_Sys100NS
GetRequestsPersec
HeadRequestsPersec
ISAPIExtensionRequestsPersec
LockedErrorsPersec
LockRequestsPersec
LogonAttemptsPersec
MaximumAnonymousUsers
MaximumCALcountforauthenticatedusers
MaximumCALcountforSSLconnections
MaximumCGIRequests
MaximumConnections
MaximumISAPIExtensionRequests
MaximumNonAnonymousUsers
MeasuredAsyncIOBandwidthUsage
MkcolRequestsPersec
MoveRequestsPersec
Name
NonAnonymousUsersPersec
NotFoundErrorsPersec
OptionsRequestsPersec
OtherRequestMethodsPersec
PostRequestsPersec
PropfindRequestsPersec
ProppatchRequestsPersec
PutRequestsPersec
SearchRequestsPersec
ServiceUptime
Timestamp_Object
Timestamp_PerfTime
Timestamp_Sys100NS
TotalAllowedAsyncIORequests
TotalAnonymousUsers
TotalBlockedAsyncIORequests
Totalblockedbandwidthbytes
TotalBytesReceived
TotalBytesSent
TotalBytesTransfered
TotalCGIRequests
TotalConnectionAttemptsallinstances
TotalCopyRequests
TotalcountoffailedCALrequestsforauthenticatedusers
TotalcountoffailedCALrequestsforSSLconnections
TotalDeleteRequests
TotalFilesReceived
TotalFilesSent
TotalFilesTransferred
TotalGetRequests
TotalHeadRequests
TotalISAPIExtensionRequests
TotalLockedErrors
TotalLockRequests
TotalLogonAttempts
TotalMethodRequests
TotalMethodRequestsPersec
TotalMkcolRequests
TotalMoveRequests
TotalNonAnonymousUsers
TotalNotFoundErrors
TotalOptionsRequests
TotalOtherRequestMethods
TotalPostRequests
TotalPropfindRequests
TotalProppatchRequests
TotalPutRequests
TotalRejectedAsyncIORequests
TotalSearchRequests
TotalTraceRequests
TotalUnlockRequests
TraceRequestsPersec
UnlockRequestsPersec
";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvFeilds.Rows.Count < 2)
            {
                MessageBox.Show("没有选中任何字段");
                return;
            }

            MonitorFields.Clear();
            for (int i = 0; i < dgvFeilds.Rows.Count - 1; i++)
            {
                string intro = "";
                if (dgvFeilds[1, i].Value == null || dgvFeilds[1, i].Value.ToString().Trim().Length == 0)
                {
                    intro = dgvFeilds[0, i].Value.ToString();
                }
                else
                {

                    intro = dgvFeilds[1, i].Value.ToString();
                }


                if (!MonitorFields.ContainsKey(dgvFeilds[0, i].Value.ToString()))
                {
                    MonitorFields.Add(dgvFeilds[0, i].Value.ToString(), intro);
                }
            }
            if (!MonitorFields.ContainsKey("Name"))
            {
                MessageBox.Show("必须包含\"Name\"列");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }


    }
}
