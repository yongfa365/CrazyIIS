namespace CrazyIIS
{
    partial class dlgSelectMonitorFields
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvFeilds = new System.Windows.Forms.DataGridView();
            this.Fields = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Intro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnBest = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnBest1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeilds)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFeilds
            // 
            this.dgvFeilds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFeilds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeilds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fields,
            this.Intro});
            this.dgvFeilds.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvFeilds.Location = new System.Drawing.Point(0, 0);
            this.dgvFeilds.Name = "dgvFeilds";
            this.dgvFeilds.RowTemplate.Height = 23;
            this.dgvFeilds.Size = new System.Drawing.Size(472, 336);
            this.dgvFeilds.TabIndex = 0;
            // 
            // Fields
            // 
            this.Fields.HeaderText = "Fields";
            this.Fields.Items.AddRange(new object[] {
            "AnonymousUsersPersec",
            "BytesReceivedPersec",
            "BytesSentPersec",
            "BytesTotalPersec",
            "Caption",
            "CGIRequestsPersec",
            "ConnectionAttemptsPersec",
            "CopyRequestsPersec",
            "CurrentAnonymousUsers",
            "CurrentBlockedAsyncIORequests",
            "Currentblockedbandwidthbytes",
            "CurrentCALcountforauthenticatedusers",
            "CurrentCALcountforSSLconnections",
            "CurrentCGIRequests",
            "CurrentConnections",
            "CurrentISAPIExtensionRequests",
            "CurrentNonAnonymousUsers",
            "DeleteRequestsPersec",
            "Description",
            "FilesPersec",
            "FilesReceivedPersec",
            "FilesSentPersec",
            "Frequency_Object",
            "Frequency_PerfTime",
            "Frequency_Sys100NS",
            "GetRequestsPersec",
            "HeadRequestsPersec",
            "ISAPIExtensionRequestsPersec",
            "LockedErrorsPersec",
            "LockRequestsPersec",
            "LogonAttemptsPersec",
            "MaximumAnonymousUsers",
            "MaximumCALcountforauthenticatedusers",
            "MaximumCALcountforSSLconnections",
            "MaximumCGIRequests",
            "MaximumConnections",
            "MaximumISAPIExtensionRequests",
            "MaximumNonAnonymousUsers",
            "MeasuredAsyncIOBandwidthUsage",
            "MkcolRequestsPersec",
            "MoveRequestsPersec",
            "Name",
            "NonAnonymousUsersPersec",
            "NotFoundErrorsPersec",
            "OptionsRequestsPersec",
            "OtherRequestMethodsPersec",
            "PostRequestsPersec",
            "PropfindRequestsPersec",
            "ProppatchRequestsPersec",
            "PutRequestsPersec",
            "SearchRequestsPersec",
            "ServiceUptime",
            "Timestamp_Object",
            "Timestamp_PerfTime",
            "Timestamp_Sys100NS",
            "TotalAllowedAsyncIORequests",
            "TotalAnonymousUsers",
            "TotalBlockedAsyncIORequests",
            "Totalblockedbandwidthbytes",
            "TotalBytesReceived",
            "TotalBytesSent",
            "TotalBytesTransfered",
            "TotalCGIRequests",
            "TotalConnectionAttemptsallinstances",
            "TotalCopyRequests",
            "TotalcountoffailedCALrequestsforauthenticatedusers",
            "TotalcountoffailedCALrequestsforSSLconnections",
            "TotalDeleteRequests",
            "TotalFilesReceived",
            "TotalFilesSent",
            "TotalFilesTransferred",
            "TotalGetRequests",
            "TotalHeadRequests",
            "TotalISAPIExtensionRequests",
            "TotalLockedErrors",
            "TotalLockRequests",
            "TotalLogonAttempts",
            "TotalMethodRequests",
            "TotalMethodRequestsPersec",
            "TotalMkcolRequests",
            "TotalMoveRequests",
            "TotalNonAnonymousUsers",
            "TotalNotFoundErrors",
            "TotalOptionsRequests",
            "TotalOtherRequestMethods",
            "TotalPostRequests",
            "TotalPropfindRequests",
            "TotalProppatchRequests",
            "TotalPutRequests",
            "TotalRejectedAsyncIORequests",
            "TotalSearchRequests",
            "TotalTraceRequests",
            "TotalUnlockRequests",
            "TraceRequestsPersec",
            "UnlockRequestsPersec"});
            this.Fields.Name = "Fields";
            // 
            // Intro
            // 
            this.Intro.HeaderText = "Intro";
            this.Intro.Name = "Intro";
            // 
            // btnMin
            // 
            this.btnMin.Location = new System.Drawing.Point(488, 12);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(75, 23);
            this.btnMin.TabIndex = 1;
            this.btnMin.Text = "最小";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnBest
            // 
            this.btnBest.Location = new System.Drawing.Point(488, 95);
            this.btnBest.Name = "btnBest";
            this.btnBest.Size = new System.Drawing.Size(75, 23);
            this.btnBest.TabIndex = 2;
            this.btnBest.Text = "方案2";
            this.btnBest.UseVisualStyleBackColor = true;
            this.btnBest.Click += new System.EventHandler(this.btnBest_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(488, 136);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 3;
            this.btnAll.Text = "全部";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Visible = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::CrazyIIS.Properties.Resources.Apply;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(488, 274);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 50);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "  确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnBest1
            // 
            this.btnBest1.Location = new System.Drawing.Point(488, 52);
            this.btnBest1.Name = "btnBest1";
            this.btnBest1.Size = new System.Drawing.Size(75, 23);
            this.btnBest1.TabIndex = 1;
            this.btnBest1.Text = "方案1";
            this.btnBest1.UseVisualStyleBackColor = true;
            this.btnBest1.Click += new System.EventHandler(this.btnBest1_Click);
            // 
            // dlgSelectMonitorFields
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 336);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnBest);
            this.Controls.Add(this.btnBest1);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.dgvFeilds);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dlgSelectMonitorFields";
            this.Text = "请选择要监控的字段";
            this.Load += new System.EventHandler(this.dlgSelectMonitorFields_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeilds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFeilds;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnBest;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnBest1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Fields;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intro;
    }
}