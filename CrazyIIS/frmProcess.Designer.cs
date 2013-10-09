namespace CrazyIIS
{
    partial class frmProcess
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.结束进程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拆分应用程序池ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分析应用程序池对应的网站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvProcess = new CrazyIIS.DoubleBufferListView();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.结束进程ToolStripMenuItem,
            this.拆分应用程序池ToolStripMenuItem,
            this.分析应用程序池对应的网站ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 70);
            // 
            // 结束进程ToolStripMenuItem
            // 
            this.结束进程ToolStripMenuItem.Name = "结束进程ToolStripMenuItem";
            this.结束进程ToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.结束进程ToolStripMenuItem.Text = "结束进程";
            this.结束进程ToolStripMenuItem.Click += new System.EventHandler(this.结束进程ToolStripMenuItem_Click);
            // 
            // 拆分应用程序池ToolStripMenuItem
            // 
            this.拆分应用程序池ToolStripMenuItem.Name = "拆分应用程序池ToolStripMenuItem";
            this.拆分应用程序池ToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.拆分应用程序池ToolStripMenuItem.Text = "拆分应用程序池";
            this.拆分应用程序池ToolStripMenuItem.Click += new System.EventHandler(this.拆分应用程序池ToolStripMenuItem_Click);
            // 
            // 分析应用程序池对应的网站ToolStripMenuItem
            // 
            this.分析应用程序池对应的网站ToolStripMenuItem.Name = "分析应用程序池对应的网站ToolStripMenuItem";
            this.分析应用程序池对应的网站ToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.分析应用程序池对应的网站ToolStripMenuItem.Text = "分析应用程序池对应的网站";
            this.分析应用程序池对应的网站ToolStripMenuItem.Click += new System.EventHandler(this.分析应用程序池对应的网站ToolStripMenuItem_Click);
            // 
            // dgvProcess
            // 
            this.dgvProcess.AllowUserToAddRows = false;
            this.dgvProcess.AllowUserToDeleteRows = false;
            this.dgvProcess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProcess.Location = new System.Drawing.Point(0, 0);
            this.dgvProcess.Name = "dgvProcess";
            this.dgvProcess.ReadOnly = true;
            this.dgvProcess.RowTemplate.Height = 23;
            this.dgvProcess.Size = new System.Drawing.Size(734, 546);
            this.dgvProcess.TabIndex = 0;
            this.dgvProcess.Sorted += new System.EventHandler(this.dgvProcess_Sorted);
            this.dgvProcess.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProcess_CellMouseDown);
            this.dgvProcess.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProcess_CellFormatting);
            // 
            // frmProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 546);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.dgvProcess);
            this.Name = "frmProcess";
            this.Text = "进程管理";
            this.Load += new System.EventHandler(this.frmProcess_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProcess_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 结束进程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拆分应用程序池ToolStripMenuItem;
        private DoubleBufferListView dgvProcess;
        private System.Windows.Forms.ToolStripMenuItem 分析应用程序池对应的网站ToolStripMenuItem;


    }
}