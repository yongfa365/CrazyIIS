namespace CrazyIIS
{
    partial class frmCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreate));
            this.ServerComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ServerBindings = new System.Windows.Forms.TextBox();
            this.ScriptMaps = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.hosts = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AppPoolId = new System.Windows.Forms.ComboBox();
            this.lblLinkHTML = new System.Windows.Forms.LinkLabel();
            this.LogFileDirectory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLinkASP = new System.Windows.Forms.LinkLabel();
            this.lblLinkASPX = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServerComment
            // 
            this.ServerComment.Location = new System.Drawing.Point(78, 3);
            this.ServerComment.Name = "ServerComment";
            this.ServerComment.Size = new System.Drawing.Size(215, 21);
            this.ServerComment.TabIndex = 0;
            this.ServerComment.TextChanged += new System.EventHandler(this.ServerComment_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "说明/域名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "路径：";
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(78, 30);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(215, 21);
            this.Path.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "主机头：";
            // 
            // ServerBindings
            // 
            this.ServerBindings.Location = new System.Drawing.Point(78, 86);
            this.ServerBindings.Name = "ServerBindings";
            this.ServerBindings.Size = new System.Drawing.Size(327, 21);
            this.ServerBindings.TabIndex = 2;
            // 
            // ScriptMaps
            // 
            this.ScriptMaps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScriptMaps.FormattingEnabled = true;
            this.ScriptMaps.Items.AddRange(new object[] {
            "v2.0.50727",
            "v1.1.4322"});
            this.ScriptMaps.Location = new System.Drawing.Point(299, 112);
            this.ScriptMaps.Name = "ScriptMaps";
            this.ScriptMaps.Size = new System.Drawing.Size(106, 20);
            this.ScriptMaps.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = ".net版本：";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::CrazyIIS.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(303, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 48);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // hosts
            // 
            this.hosts.AutoSize = true;
            this.hosts.Location = new System.Drawing.Point(303, 59);
            this.hosts.Name = "hosts";
            this.hosts.Size = new System.Drawing.Size(90, 16);
            this.hosts.TabIndex = 4;
            this.hosts.Text = "添加到hosts";
            this.hosts.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "应用程序池：";
            // 
            // AppPoolId
            // 
            this.AppPoolId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AppPoolId.FormattingEnabled = true;
            this.AppPoolId.Location = new System.Drawing.Point(78, 112);
            this.AppPoolId.Name = "AppPoolId";
            this.AppPoolId.Size = new System.Drawing.Size(134, 20);
            this.AppPoolId.TabIndex = 3;
            // 
            // lblLinkHTML
            // 
            this.lblLinkHTML.AutoSize = true;
            this.lblLinkHTML.Location = new System.Drawing.Point(76, 138);
            this.lblLinkHTML.Name = "lblLinkHTML";
            this.lblLinkHTML.Size = new System.Drawing.Size(47, 12);
            this.lblLinkHTML.TabIndex = 6;
            this.lblLinkHTML.TabStop = true;
            this.lblLinkHTML.Text = "http://";
            this.lblLinkHTML.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // LogFileDirectory
            // 
            this.LogFileDirectory.Location = new System.Drawing.Point(78, 57);
            this.LogFileDirectory.Name = "LogFileDirectory";
            this.LogFileDirectory.Size = new System.Drawing.Size(215, 21);
            this.LogFileDirectory.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "日志路径：";
            // 
            // lblLinkASP
            // 
            this.lblLinkASP.AutoSize = true;
            this.lblLinkASP.Location = new System.Drawing.Point(76, 159);
            this.lblLinkASP.Name = "lblLinkASP";
            this.lblLinkASP.Size = new System.Drawing.Size(47, 12);
            this.lblLinkASP.TabIndex = 6;
            this.lblLinkASP.TabStop = true;
            this.lblLinkASP.Text = "http://";
            this.lblLinkASP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // lblLinkASPX
            // 
            this.lblLinkASPX.AutoSize = true;
            this.lblLinkASPX.Location = new System.Drawing.Point(76, 180);
            this.lblLinkASPX.Name = "lblLinkASPX";
            this.lblLinkASPX.Size = new System.Drawing.Size(47, 12);
            this.lblLinkASPX.TabIndex = 6;
            this.lblLinkASPX.TabStop = true;
            this.lblLinkASPX.Text = "http://";
            this.lblLinkASPX.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "测试文档：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "测试文档：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "测试文档：";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(342, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "生成测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmCreate
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 197);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LogFileDirectory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLinkASPX);
            this.Controls.Add(this.lblLinkASP);
            this.Controls.Add(this.lblLinkHTML);
            this.Controls.Add(this.hosts);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.AppPoolId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ScriptMaps);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ServerBindings);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ServerComment);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCreate";
            this.Text = "手动建网站";
            this.Load += new System.EventHandler(this.Create_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServerComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ServerBindings;
        private System.Windows.Forms.ComboBox ScriptMaps;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox hosts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AppPoolId;
        private System.Windows.Forms.LinkLabel lblLinkHTML;
        private System.Windows.Forms.TextBox LogFileDirectory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel lblLinkASP;
        private System.Windows.Forms.LinkLabel lblLinkASPX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
    }
}