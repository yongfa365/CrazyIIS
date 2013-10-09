namespace CrazyIIS
{
    partial class frmRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRestore));
            this.txtRestore = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.chkWeb = new System.Windows.Forms.CheckBox();
            this.chkFtp = new System.Windows.Forms.CheckBox();
            this.chkHosts = new System.Windows.Forms.CheckBox();
            this.chkDir = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPathUser = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnDefault2 = new System.Windows.Forms.Button();
            this.btnBrowser2 = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRestore
            // 
            this.txtRestore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRestore.Location = new System.Drawing.Point(12, 12);
            this.txtRestore.Name = "txtRestore";
            this.txtRestore.Size = new System.Drawing.Size(391, 21);
            this.txtRestore.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 328);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(580, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(41, 17);
            this.toolStripStatusLabel1.Text = "进度：";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(180, 16);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(342, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "状态：";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // chkWeb
            // 
            this.chkWeb.AutoSize = true;
            this.chkWeb.Checked = true;
            this.chkWeb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWeb.Enabled = false;
            this.chkWeb.Location = new System.Drawing.Point(120, 39);
            this.chkWeb.Name = "chkWeb";
            this.chkWeb.Size = new System.Drawing.Size(72, 16);
            this.chkWeb.TabIndex = 6;
            this.chkWeb.Text = "Web+Pool";
            this.chkWeb.UseVisualStyleBackColor = true;
            // 
            // chkFtp
            // 
            this.chkFtp.AutoSize = true;
            this.chkFtp.Location = new System.Drawing.Point(204, 39);
            this.chkFtp.Name = "chkFtp";
            this.chkFtp.Size = new System.Drawing.Size(42, 16);
            this.chkFtp.TabIndex = 6;
            this.chkFtp.Text = "Ftp";
            this.chkFtp.UseVisualStyleBackColor = true;
            // 
            // chkHosts
            // 
            this.chkHosts.AutoSize = true;
            this.chkHosts.Location = new System.Drawing.Point(346, 39);
            this.chkHosts.Name = "chkHosts";
            this.chkHosts.Size = new System.Drawing.Size(54, 16);
            this.chkHosts.TabIndex = 6;
            this.chkHosts.Text = "Hosts";
            this.chkHosts.UseVisualStyleBackColor = true;
            // 
            // chkDir
            // 
            this.chkDir.AutoSize = true;
            this.chkDir.Checked = true;
            this.chkDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDir.Location = new System.Drawing.Point(262, 39);
            this.chkDir.Name = "chkDir";
            this.chkDir.Size = new System.Drawing.Size(78, 16);
            this.chkDir.TabIndex = 6;
            this.chkDir.Text = "Dir+Files";
            this.chkDir.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 65);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(556, 211);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnPathUser);
            this.groupBox1.Controls.Add(this.btnDefault);
            this.groupBox1.Controls.Add(this.btnDefault2);
            this.groupBox1.Location = new System.Drawing.Point(12, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 45);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "可能会用到的辅助功能";
            // 
            // btnPathUser
            // 
            this.btnPathUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPathUser.Image = global::CrazyIIS.Properties.Resources.add;
            this.btnPathUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPathUser.Location = new System.Drawing.Point(9, 16);
            this.btnPathUser.Name = "btnPathUser";
            this.btnPathUser.Size = new System.Drawing.Size(82, 23);
            this.btnPathUser.TabIndex = 10;
            this.btnPathUser.Text = "   路径权限";
            this.btnPathUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPathUser.UseVisualStyleBackColor = true;
            this.btnPathUser.Click += new System.EventHandler(this.btnPathUser_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefault.Image = global::CrazyIIS.Properties.Resources.refresh;
            this.btnDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDefault.Location = new System.Drawing.Point(240, 16);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(139, 23);
            this.btnDefault.TabIndex = 7;
            this.btnDefault.Text = "   还原IIS到初始状态";
            this.btnDefault.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnDefault2
            // 
            this.btnDefault2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefault2.Image = global::CrazyIIS.Properties.Resources.refresh;
            this.btnDefault2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDefault2.Location = new System.Drawing.Point(385, 16);
            this.btnDefault2.Name = "btnDefault2";
            this.btnDefault2.Size = new System.Drawing.Size(165, 23);
            this.btnDefault2.TabIndex = 8;
            this.btnDefault2.Text = "   终极修复IIS到初始状态";
            this.btnDefault2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDefault2.UseVisualStyleBackColor = true;
            this.btnDefault2.Click += new System.EventHandler(this.btnDefault2_Click);
            // 
            // btnBrowser2
            // 
            this.btnBrowser2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowser2.Image = global::CrazyIIS.Properties.Resources.search;
            this.btnBrowser2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowser2.Location = new System.Drawing.Point(409, 10);
            this.btnBrowser2.Name = "btnBrowser2";
            this.btnBrowser2.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser2.TabIndex = 1;
            this.btnBrowser2.Text = "  浏览";
            this.btnBrowser2.UseVisualStyleBackColor = true;
            this.btnBrowser2.Click += new System.EventHandler(this.btnBrowser2_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Image = global::CrazyIIS.Properties.Resources.refresh;
            this.btnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestore.Location = new System.Drawing.Point(490, 10);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "  还原";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "同时做以下操作：";
            // 
            // frmRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 350);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.chkDir);
            this.Controls.Add(this.chkHosts);
            this.Controls.Add(this.chkFtp);
            this.Controls.Add(this.chkWeb);
            this.Controls.Add(this.txtRestore);
            this.Controls.Add(this.btnBrowser2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnRestore);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRestore";
            this.Text = "IIS备份还原";
            this.Load += new System.EventHandler(this.FrmBackUpRestore_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRestore;
        private System.Windows.Forms.Button btnBrowser2;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox chkWeb;
        private System.Windows.Forms.CheckBox chkFtp;
        private System.Windows.Forms.CheckBox chkHosts;
        private System.Windows.Forms.CheckBox chkDir;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnDefault2;
        private System.Windows.Forms.Button btnPathUser;
        private System.Windows.Forms.Label label1;
    }
}