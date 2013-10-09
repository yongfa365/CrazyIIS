namespace CrazyIIS
{
    partial class frmBack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBack));
            this.txtBackUp = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.chkHistory = new System.Windows.Forms.CheckBox();
            this.chkMetaBack = new System.Windows.Forms.CheckBox();
            this.chkACL = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBackUp
            // 
            this.txtBackUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackUp.Location = new System.Drawing.Point(12, 12);
            this.txtBackUp.Name = "txtBackUp";
            this.txtBackUp.Size = new System.Drawing.Size(415, 21);
            this.txtBackUp.TabIndex = 3;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowser.Image = global::CrazyIIS.Properties.Resources.search;
            this.btnBrowser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowser.Location = new System.Drawing.Point(433, 12);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(59, 23);
            this.btnBrowser.TabIndex = 4;
            this.btnBrowser.Text = "  浏览";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnBackUp
            // 
            this.btnBackUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackUp.Image = global::CrazyIIS.Properties.Resources.Save;
            this.btnBackUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackUp.Location = new System.Drawing.Point(506, 12);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(59, 23);
            this.btnBackUp.TabIndex = 5;
            this.btnBackUp.Text = "  备份";
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 63);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(556, 277);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "此过程主要是复制\n“C:\\WINDOWS\\system32\\inetsrv\\MetaBase.xml”\n到您选择的路径，所以，速度很快\n\n当然，您也可以根据实际情" +
                "况（如：进不了系统了，硬盘挂在别的机器上），直接复制这个文件，以实现手工备份\n\n文件夹权限：\t备份 当前所有站点的文件夹权限\n\nHistory：\t备份 IIS历" +
                "史文件\n\nMetaBack：\t备份 IIS备份文件";
            // 
            // chkHistory
            // 
            this.chkHistory.AutoSize = true;
            this.chkHistory.Location = new System.Drawing.Point(189, 41);
            this.chkHistory.Name = "chkHistory";
            this.chkHistory.Size = new System.Drawing.Size(66, 16);
            this.chkHistory.TabIndex = 9;
            this.chkHistory.Text = "History";
            this.chkHistory.UseVisualStyleBackColor = true;
            // 
            // chkMetaBack
            // 
            this.chkMetaBack.AutoSize = true;
            this.chkMetaBack.Location = new System.Drawing.Point(277, 41);
            this.chkMetaBack.Name = "chkMetaBack";
            this.chkMetaBack.Size = new System.Drawing.Size(72, 16);
            this.chkMetaBack.TabIndex = 9;
            this.chkMetaBack.Text = "MetaBack";
            this.chkMetaBack.UseVisualStyleBackColor = true;
            // 
            // chkACL
            // 
            this.chkACL.AutoSize = true;
            this.chkACL.Checked = true;
            this.chkACL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkACL.Location = new System.Drawing.Point(83, 41);
            this.chkACL.Name = "chkACL";
            this.chkACL.Size = new System.Drawing.Size(84, 16);
            this.chkACL.TabIndex = 9;
            this.chkACL.Text = "文件夹权限";
            this.chkACL.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "同时备份：";
            // 
            // frmBack
            // 
            this.AcceptButton = this.btnBackUp;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 350);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkACL);
            this.Controls.Add(this.chkMetaBack);
            this.Controls.Add(this.chkHistory);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtBackUp);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.btnBackUp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBack";
            this.Text = "IIS备份";
            this.Load += new System.EventHandler(this.frmBack_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBackUp;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox chkHistory;
        private System.Windows.Forms.CheckBox chkMetaBack;
        private System.Windows.Forms.CheckBox chkACL;
        private System.Windows.Forms.Label label1;
    }
}