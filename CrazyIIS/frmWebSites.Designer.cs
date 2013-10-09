namespace CrazyIIS
{
    partial class frmWebSites
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWebSites));
            this.AppPoolId2 = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSelectOther = new System.Windows.Forms.LinkLabel();
            this.lblSelectAll = new System.Windows.Forms.LinkLabel();
            this.btnAddPool = new System.Windows.Forms.Button();
            this.txtNewPool = new System.Windows.Forms.TextBox();
            this.chkListBox_S = new System.Windows.Forms.CheckedListBox();
            this.chkListBox_D = new System.Windows.Forms.CheckedListBox();
            this.btnHe = new System.Windows.Forms.Button();
            this.btnDeleteAllNoUsed = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOneWebOnePool = new System.Windows.Forms.Button();
            this.btnResetFolderACL = new System.Windows.Forms.Button();
            this.localWeb1 = new CrazyIIS.LocalWeb();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AppPoolId2
            // 
            this.AppPoolId2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.AppPoolId2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.AppPoolId2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AppPoolId2.FormattingEnabled = true;
            this.AppPoolId2.Location = new System.Drawing.Point(41, 14);
            this.AppPoolId2.Name = "AppPoolId2";
            this.AppPoolId2.Size = new System.Drawing.Size(128, 20);
            this.AppPoolId2.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::CrazyIIS.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(175, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 24);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "执行";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(529, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 526);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.lblSelectOther);
            this.groupBox3.Controls.Add(this.lblSelectAll);
            this.groupBox3.Controls.Add(this.btnAddPool);
            this.groupBox3.Controls.Add(this.txtNewPool);
            this.groupBox3.Controls.Add(this.chkListBox_S);
            this.groupBox3.Controls.Add(this.chkListBox_D);
            this.groupBox3.Controls.Add(this.btnHe);
            this.groupBox3.Controls.Add(this.btnDeleteAllNoUsed);
            this.groupBox3.Location = new System.Drawing.Point(6, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 379);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "应用程序池操作";
            // 
            // lblSelectOther
            // 
            this.lblSelectOther.AutoSize = true;
            this.lblSelectOther.BackColor = System.Drawing.Color.White;
            this.lblSelectOther.Location = new System.Drawing.Point(181, 220);
            this.lblSelectOther.Name = "lblSelectOther";
            this.lblSelectOther.Size = new System.Drawing.Size(29, 12);
            this.lblSelectOther.TabIndex = 16;
            this.lblSelectOther.TabStop = true;
            this.lblSelectOther.Text = "反选";
            this.lblSelectOther.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSelectOther_LinkClicked);
            // 
            // lblSelectAll
            // 
            this.lblSelectAll.AutoSize = true;
            this.lblSelectAll.BackColor = System.Drawing.Color.White;
            this.lblSelectAll.Location = new System.Drawing.Point(146, 220);
            this.lblSelectAll.Name = "lblSelectAll";
            this.lblSelectAll.Size = new System.Drawing.Size(29, 12);
            this.lblSelectAll.TabIndex = 16;
            this.lblSelectAll.TabStop = true;
            this.lblSelectAll.Text = "全选";
            this.lblSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSelectAll_LinkClicked);
            // 
            // btnAddPool
            // 
            this.btnAddPool.Image = global::CrazyIIS.Properties.Resources.add;
            this.btnAddPool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPool.Location = new System.Drawing.Point(155, 22);
            this.btnAddPool.Name = "btnAddPool";
            this.btnAddPool.Size = new System.Drawing.Size(75, 65);
            this.btnAddPool.TabIndex = 15;
            this.btnAddPool.Text = "  创建";
            this.btnAddPool.UseVisualStyleBackColor = true;
            this.btnAddPool.Click += new System.EventHandler(this.btnAddPool_Click);
            // 
            // txtNewPool
            // 
            this.txtNewPool.Location = new System.Drawing.Point(8, 22);
            this.txtNewPool.Multiline = true;
            this.txtNewPool.Name = "txtNewPool";
            this.txtNewPool.Size = new System.Drawing.Size(141, 65);
            this.txtNewPool.TabIndex = 14;
            this.txtNewPool.Text = "Stop\r\nNet1_1\r\nNet2_0";
            // 
            // chkListBox_S
            // 
            this.chkListBox_S.CheckOnClick = true;
            this.chkListBox_S.FormattingEnabled = true;
            this.chkListBox_S.Location = new System.Drawing.Point(6, 137);
            this.chkListBox_S.Name = "chkListBox_S";
            this.chkListBox_S.Size = new System.Drawing.Size(224, 100);
            this.chkListBox_S.TabIndex = 12;
            // 
            // chkListBox_D
            // 
            this.chkListBox_D.CheckOnClick = true;
            this.chkListBox_D.FormattingEnabled = true;
            this.chkListBox_D.Location = new System.Drawing.Point(6, 272);
            this.chkListBox_D.Name = "chkListBox_D";
            this.chkListBox_D.Size = new System.Drawing.Size(224, 100);
            this.chkListBox_D.TabIndex = 11;
            // 
            // btnHe
            // 
            this.btnHe.Image = global::CrazyIIS.Properties.Resources.Apply;
            this.btnHe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHe.Location = new System.Drawing.Point(6, 243);
            this.btnHe.Name = "btnHe";
            this.btnHe.Size = new System.Drawing.Size(224, 23);
            this.btnHe.TabIndex = 13;
            this.btnHe.Text = "↑选中池中的站点 合并或平分 到↓";
            this.btnHe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHe.UseVisualStyleBackColor = true;
            this.btnHe.Click += new System.EventHandler(this.btnHe_Click);
            // 
            // btnDeleteAllNoUsed
            // 
            this.btnDeleteAllNoUsed.Image = global::CrazyIIS.Properties.Resources.remove;
            this.btnDeleteAllNoUsed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteAllNoUsed.Location = new System.Drawing.Point(6, 93);
            this.btnDeleteAllNoUsed.Name = "btnDeleteAllNoUsed";
            this.btnDeleteAllNoUsed.Size = new System.Drawing.Size(224, 23);
            this.btnDeleteAllNoUsed.TabIndex = 10;
            this.btnDeleteAllNoUsed.Text = "删除所有未使用的应用程序池";
            this.btnDeleteAllNoUsed.UseVisualStyleBackColor = true;
            this.btnDeleteAllNoUsed.Click += new System.EventHandler(this.btnDeleteAllNoUsed_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnResetFolderACL);
            this.groupBox2.Controls.Add(this.AppPoolId2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnOneWebOnePool);
            this.groupBox2.Location = new System.Drawing.Point(6, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 101);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选中站点操作";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "放到：";
            // 
            // btnOneWebOnePool
            // 
            this.btnOneWebOnePool.Image = global::CrazyIIS.Properties.Resources.Apply;
            this.btnOneWebOnePool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOneWebOnePool.Location = new System.Drawing.Point(8, 41);
            this.btnOneWebOnePool.Name = "btnOneWebOnePool";
            this.btnOneWebOnePool.Size = new System.Drawing.Size(222, 23);
            this.btnOneWebOnePool.TabIndex = 10;
            this.btnOneWebOnePool.Text = "使用独立应用程序池";
            this.btnOneWebOnePool.UseVisualStyleBackColor = true;
            this.btnOneWebOnePool.Click += new System.EventHandler(this.btnOneWebOnePool_Click);
            // 
            // btnResetFolderACL
            // 
            this.btnResetFolderACL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetFolderACL.Image = global::CrazyIIS.Properties.Resources.refresh;
            this.btnResetFolderACL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetFolderACL.Location = new System.Drawing.Point(8, 70);
            this.btnResetFolderACL.Name = "btnResetFolderACL";
            this.btnResetFolderACL.Size = new System.Drawing.Size(222, 23);
            this.btnResetFolderACL.TabIndex = 11;
            this.btnResetFolderACL.Text = "  修复匿名用户及文件夹权限";
            this.btnResetFolderACL.UseVisualStyleBackColor = true;
            this.btnResetFolderACL.Click += new System.EventHandler(this.btnResetFolderACL_Click);
            // 
            // localWeb1
            // 
            this.localWeb1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.localWeb1.Location = new System.Drawing.Point(0, 0);
            this.localWeb1.Name = "localWeb1";
            this.localWeb1.Size = new System.Drawing.Size(524, 528);
            this.localWeb1.TabIndex = 10;
            // 
            // frmWebSites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 533);
            this.Controls.Add(this.localWeb1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWebSites";
            this.Text = "网站应用程序池调整";
            this.Load += new System.EventHandler(this.FrmWebSites_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWebSites_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox AppPoolId2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOneWebOnePool;
        private System.Windows.Forms.Label label1;
        private LocalWeb localWeb1;
        private System.Windows.Forms.Button btnHe;
        private System.Windows.Forms.CheckedListBox chkListBox_D;
        private System.Windows.Forms.CheckedListBox chkListBox_S;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDeleteAllNoUsed;
        private System.Windows.Forms.Button btnAddPool;
        private System.Windows.Forms.TextBox txtNewPool;
        private System.Windows.Forms.LinkLabel lblSelectOther;
        private System.Windows.Forms.LinkLabel lblSelectAll;
        private System.Windows.Forms.Button btnResetFolderACL;
    }
}