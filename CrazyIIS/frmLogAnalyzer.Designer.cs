namespace CrazyIIS
{
    partial class frmLogAnalyzer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogAnalyzer));
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.cbxWeb = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置日志到CrazyIIS推荐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置日志到系统默认ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置日志到全部记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看当前日志记录情况ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp1
            // 
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(243, 4);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(106, 21);
            this.dtp1.TabIndex = 0;
            // 
            // dtp2
            // 
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp2.Location = new System.Drawing.Point(386, 4);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(106, 21);
            this.dtp2.TabIndex = 0;
            // 
            // cbxWeb
            // 
            this.cbxWeb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxWeb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxWeb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWeb.FormattingEnabled = true;
            this.cbxWeb.Location = new System.Drawing.Point(43, 4);
            this.cbxWeb.MaxDropDownItems = 20;
            this.cbxWeb.Name = "cbxWeb";
            this.cbxWeb.Size = new System.Drawing.Size(159, 20);
            this.cbxWeb.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::CrazyIIS.Properties.Resources.log_small;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(502, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "  分析";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(787, 397);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "网站：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "从：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "到：";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.ContextMenuStrip = this.contextMenuStrip1;
            this.linkLabel1.Location = new System.Drawing.Point(594, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(131, 12);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "右击 设置日志记录格式";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置日志到CrazyIIS推荐ToolStripMenuItem,
            this.设置日志到系统默认ToolStripMenuItem,
            this.设置日志到全部记录ToolStripMenuItem,
            this.查看当前日志记录情况ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(191, 92);
            // 
            // 设置日志到CrazyIIS推荐ToolStripMenuItem
            // 
            this.设置日志到CrazyIIS推荐ToolStripMenuItem.Name = "设置日志到CrazyIIS推荐ToolStripMenuItem";
            this.设置日志到CrazyIIS推荐ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.设置日志到CrazyIIS推荐ToolStripMenuItem.Text = "适合CrazyIIS";
            this.设置日志到CrazyIIS推荐ToolStripMenuItem.Click += new System.EventHandler(this.设置日志到CrazyIIS推荐ToolStripMenuItem_Click);
            // 
            // 设置日志到系统默认ToolStripMenuItem
            // 
            this.设置日志到系统默认ToolStripMenuItem.Name = "设置日志到系统默认ToolStripMenuItem";
            this.设置日志到系统默认ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.设置日志到系统默认ToolStripMenuItem.Text = "系统默认";
            this.设置日志到系统默认ToolStripMenuItem.Click += new System.EventHandler(this.设置日志到系统默认ToolStripMenuItem_Click);
            // 
            // 设置日志到全部记录ToolStripMenuItem
            // 
            this.设置日志到全部记录ToolStripMenuItem.Name = "设置日志到全部记录ToolStripMenuItem";
            this.设置日志到全部记录ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.设置日志到全部记录ToolStripMenuItem.Text = "全部记录";
            this.设置日志到全部记录ToolStripMenuItem.Click += new System.EventHandler(this.设置日志到全部记录ToolStripMenuItem_Click);
            // 
            // 查看当前日志记录情况ToolStripMenuItem
            // 
            this.查看当前日志记录情况ToolStripMenuItem.Name = "查看当前日志记录情况ToolStripMenuItem";
            this.查看当前日志记录情况ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.查看当前日志记录情况ToolStripMenuItem.Text = "查看当前日志记录情况";
            this.查看当前日志记录情况ToolStripMenuItem.Click += new System.EventHandler(this.查看当前日志记录情况ToolStripMenuItem_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 6;
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(554, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "状态：";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmLogAnalyzer
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 453);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbxWeb);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.dtp1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogAnalyzer";
            this.Text = "日志分析";
            this.Load += new System.EventHandler(this.frmLogAnalyzer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.ComboBox cbxWeb;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置日志到系统默认ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置日志到CrazyIIS推荐ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置日志到全部记录ToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem 查看当前日志记录情况ToolStripMenuItem;
    }
}