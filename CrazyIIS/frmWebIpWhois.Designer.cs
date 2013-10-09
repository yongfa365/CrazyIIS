namespace CrazyIIS
{
    partial class frmWebIpWhois
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnInFromFile = new System.Windows.Forms.Button();
            this.btnDomain2IP = new System.Windows.Forms.Button();
            this.btnDomain2DNS = new System.Windows.Forms.Button();
            this.btnInFromIIS = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(487, 438);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnInFromFile
            // 
            this.btnInFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInFromFile.Location = new System.Drawing.Point(493, 46);
            this.btnInFromFile.Name = "btnInFromFile";
            this.btnInFromFile.Size = new System.Drawing.Size(129, 23);
            this.btnInFromFile.TabIndex = 2;
            this.btnInFromFile.Text = "从文本文件导入域名";
            this.btnInFromFile.UseVisualStyleBackColor = true;
            this.btnInFromFile.Click += new System.EventHandler(this.btnInFromFile_Click);
            // 
            // btnDomain2IP
            // 
            this.btnDomain2IP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDomain2IP.Location = new System.Drawing.Point(493, 80);
            this.btnDomain2IP.Name = "btnDomain2IP";
            this.btnDomain2IP.Size = new System.Drawing.Size(129, 23);
            this.btnDomain2IP.TabIndex = 3;
            this.btnDomain2IP.Text = "域名-->IP";
            this.btnDomain2IP.UseVisualStyleBackColor = true;
            this.btnDomain2IP.Click += new System.EventHandler(this.btnDomain2IP_Click);
            // 
            // btnDomain2DNS
            // 
            this.btnDomain2DNS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDomain2DNS.Location = new System.Drawing.Point(493, 114);
            this.btnDomain2DNS.Name = "btnDomain2DNS";
            this.btnDomain2DNS.Size = new System.Drawing.Size(129, 23);
            this.btnDomain2DNS.TabIndex = 3;
            this.btnDomain2DNS.Text = "域名-->DNS";
            this.btnDomain2DNS.UseVisualStyleBackColor = true;
            this.btnDomain2DNS.Click += new System.EventHandler(this.btnDomain2DNS_Click);
            // 
            // btnInFromIIS
            // 
            this.btnInFromIIS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInFromIIS.Location = new System.Drawing.Point(493, 12);
            this.btnInFromIIS.Name = "btnInFromIIS";
            this.btnInFromIIS.Size = new System.Drawing.Size(129, 23);
            this.btnInFromIIS.TabIndex = 2;
            this.btnInFromIIS.Text = "从IIS导入域名";
            this.btnInFromIIS.UseVisualStyleBackColor = true;
            this.btnInFromIIS.Click += new System.EventHandler(this.btnInFromIIS_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // frmWebIpWhois
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 438);
            this.Controls.Add(this.btnDomain2DNS);
            this.Controls.Add(this.btnDomain2IP);
            this.Controls.Add(this.btnInFromIIS);
            this.Controls.Add(this.btnInFromFile);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmWebIpWhois";
            this.Text = "域名2IP + 域名2DNS";
            this.Load += new System.EventHandler(this.frmWebIpWhois_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnInFromFile;
        private System.Windows.Forms.Button btnDomain2IP;
        private System.Windows.Forms.Button btnDomain2DNS;
        private System.Windows.Forms.Button btnInFromIIS;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}