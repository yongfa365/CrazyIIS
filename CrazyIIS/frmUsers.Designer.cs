namespace CrazyIIS
{
    partial class frmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkNoUse = new System.Windows.Forms.CheckBox();
            this.btnUserDelete = new System.Windows.Forms.Button();
            this.btnUserSelectOther = new System.Windows.Forms.Button();
            this.btnUserSelectAll = new System.Windows.Forms.Button();
            this.btnUserSearch = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnOneWebOneUser = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserNamePre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPasswordNumber = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordNumber)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delete,
            this.UserName});
            this.dgvUsers.Location = new System.Drawing.Point(8, 69);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowTemplate.Height = 23;
            this.dgvUsers.Size = new System.Drawing.Size(272, 243);
            this.dgvUsers.TabIndex = 14;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "删除";
            this.Delete.Name = "Delete";
            this.Delete.Width = 60;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "用户名";
            this.UserName.Name = "UserName";
            this.UserName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chkNoUse
            // 
            this.chkNoUse.AutoSize = true;
            this.chkNoUse.Location = new System.Drawing.Point(9, 47);
            this.chkNoUse.Name = "chkNoUse";
            this.chkNoUse.Size = new System.Drawing.Size(168, 16);
            this.chkNoUse.TabIndex = 13;
            this.chkNoUse.Text = "只列出未被网站使用的用户";
            this.chkNoUse.UseVisualStyleBackColor = true;
            // 
            // btnUserDelete
            // 
            this.btnUserDelete.Image = global::CrazyIIS.Properties.Resources.remove;
            this.btnUserDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserDelete.Location = new System.Drawing.Point(194, 318);
            this.btnUserDelete.Name = "btnUserDelete";
            this.btnUserDelete.Size = new System.Drawing.Size(86, 23);
            this.btnUserDelete.TabIndex = 11;
            this.btnUserDelete.Text = "  删除选中";
            this.btnUserDelete.UseVisualStyleBackColor = true;
            this.btnUserDelete.Click += new System.EventHandler(this.btnUserDelete_Click);
            // 
            // btnUserSelectOther
            // 
            this.btnUserSelectOther.Location = new System.Drawing.Point(66, 318);
            this.btnUserSelectOther.Name = "btnUserSelectOther";
            this.btnUserSelectOther.Size = new System.Drawing.Size(52, 23);
            this.btnUserSelectOther.TabIndex = 12;
            this.btnUserSelectOther.Text = "反选";
            this.btnUserSelectOther.UseVisualStyleBackColor = true;
            this.btnUserSelectOther.Click += new System.EventHandler(this.btnUserSelectOther_Click);
            // 
            // btnUserSelectAll
            // 
            this.btnUserSelectAll.Location = new System.Drawing.Point(8, 318);
            this.btnUserSelectAll.Name = "btnUserSelectAll";
            this.btnUserSelectAll.Size = new System.Drawing.Size(52, 23);
            this.btnUserSelectAll.TabIndex = 10;
            this.btnUserSelectAll.Text = "全选";
            this.btnUserSelectAll.UseVisualStyleBackColor = true;
            this.btnUserSelectAll.Click += new System.EventHandler(this.btnUserSelectAll_Click);
            // 
            // btnUserSearch
            // 
            this.btnUserSearch.Image = global::CrazyIIS.Properties.Resources.search;
            this.btnUserSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserSearch.Location = new System.Drawing.Point(219, 18);
            this.btnUserSearch.Name = "btnUserSearch";
            this.btnUserSearch.Size = new System.Drawing.Size(61, 23);
            this.btnUserSearch.TabIndex = 9;
            this.btnUserSearch.Text = "  查找";
            this.btnUserSearch.UseVisualStyleBackColor = true;
            this.btnUserSearch.Click += new System.EventHandler(this.btnUserSearch_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(55, 20);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(158, 21);
            this.txtUserName.TabIndex = 8;
            this.txtUserName.Text = "IUSR_";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "用户名：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblResult);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvUsers);
            this.groupBox1.Controls.Add(this.btnUserDelete);
            this.groupBox1.Controls.Add(this.chkNoUse);
            this.groupBox1.Controls.Add(this.btnUserSelectOther);
            this.groupBox1.Controls.Add(this.btnUserSearch);
            this.groupBox1.Controls.Add(this.btnUserSelectAll);
            this.groupBox1.Location = new System.Drawing.Point(4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 345);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户管理";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(192, 48);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 12);
            this.lblResult.TabIndex = 15;
            // 
            // btnOneWebOneUser
            // 
            this.btnOneWebOneUser.Image = global::CrazyIIS.Properties.Resources.refresh;
            this.btnOneWebOneUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOneWebOneUser.Location = new System.Drawing.Point(17, 46);
            this.btnOneWebOneUser.Name = "btnOneWebOneUser";
            this.btnOneWebOneUser.Size = new System.Drawing.Size(238, 23);
            this.btnOneWebOneUser.TabIndex = 16;
            this.btnOneWebOneUser.Text = "所有网站使用独立用户";
            this.btnOneWebOneUser.UseVisualStyleBackColor = true;
            this.btnOneWebOneUser.Click += new System.EventHandler(this.btnOneWebOneUser_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Image = global::CrazyIIS.Properties.Resources.refresh;
            this.btnResetPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetPassword.Location = new System.Drawing.Point(17, 91);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(238, 23);
            this.btnResetPassword.TabIndex = 16;
            this.btnResetPassword.Text = "重置所有独立用户密码";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "用户名前缀：";
            // 
            // txtUserNamePre
            // 
            this.txtUserNamePre.Location = new System.Drawing.Point(86, 19);
            this.txtUserNamePre.Name = "txtUserNamePre";
            this.txtUserNamePre.Size = new System.Drawing.Size(58, 21);
            this.txtUserNamePre.TabIndex = 17;
            this.txtUserNamePre.Text = "IUSR_";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "密码位数：";
            // 
            // txtPasswordNumber
            // 
            this.txtPasswordNumber.Location = new System.Drawing.Point(212, 19);
            this.txtPasswordNumber.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.txtPasswordNumber.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.txtPasswordNumber.Name = "txtPasswordNumber";
            this.txtPasswordNumber.Size = new System.Drawing.Size(43, 21);
            this.txtPasswordNumber.TabIndex = 19;
            this.txtPasswordNumber.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtUserNamePre);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnResetPassword);
            this.groupBox3.Controls.Add(this.txtPasswordNumber);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnOneWebOneUser);
            this.groupBox3.Location = new System.Drawing.Point(304, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 345);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "IIS网站用户";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 349);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(582, 22);
            this.statusStrip1.TabIndex = 22;
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(344, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "状态：";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 371);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUsers";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordNumber)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.CheckBox chkNoUse;
        private System.Windows.Forms.Button btnUserDelete;
        private System.Windows.Forms.Button btnUserSelectOther;
        private System.Windows.Forms.Button btnUserSelectAll;
        private System.Windows.Forms.Button btnUserSearch;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOneWebOneUser;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserNamePre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtPasswordNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label lblResult;
    }
}