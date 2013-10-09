namespace CrazyIIS
{
    partial class frmConfigs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigs));
            this.label1 = new System.Windows.Forms.Label();
            this.AspMaxRequestEntityAllowed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DefaultDoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LogFileDirectory = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AspEnableParentPaths = new System.Windows.Forms.CheckBox();
            this.ScriptMaps = new System.Windows.Forms.ComboBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.模板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.默认ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.服务器推荐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开发员推荐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.GZIP = new System.Windows.Forms.CheckBox();
            this.FLV = new System.Windows.Forms.CheckBox();
            this.EnableEditWhileRunning = new System.Windows.Forms.CheckBox();
            this.btnSaveMetabase = new System.Windows.Forms.Button();
            this.txtGzipPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASP最大上传：";
            // 
            // AspMaxRequestEntityAllowed
            // 
            this.AspMaxRequestEntityAllowed.Location = new System.Drawing.Point(107, 46);
            this.AspMaxRequestEntityAllowed.Name = "AspMaxRequestEntityAllowed";
            this.AspMaxRequestEntityAllowed.Size = new System.Drawing.Size(102, 21);
            this.AspMaxRequestEntityAllowed.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "默认文档：";
            // 
            // DefaultDoc
            // 
            this.DefaultDoc.Location = new System.Drawing.Point(107, 73);
            this.DefaultDoc.Name = "DefaultDoc";
            this.DefaultDoc.Size = new System.Drawing.Size(296, 21);
            this.DefaultDoc.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "日志存放位置：";
            // 
            // LogFileDirectory
            // 
            this.LogFileDirectory.Location = new System.Drawing.Point(107, 99);
            this.LogFileDirectory.Name = "LogFileDirectory";
            this.LogFileDirectory.Size = new System.Drawing.Size(215, 21);
            this.LogFileDirectory.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = ".net默认为：";
            // 
            // AspEnableParentPaths
            // 
            this.AspEnableParentPaths.AutoSize = true;
            this.AspEnableParentPaths.Location = new System.Drawing.Point(11, 27);
            this.AspEnableParentPaths.Name = "AspEnableParentPaths";
            this.AspEnableParentPaths.Size = new System.Drawing.Size(84, 16);
            this.AspEnableParentPaths.TabIndex = 4;
            this.AspEnableParentPaths.Text = "启用父路径";
            this.AspEnableParentPaths.UseVisualStyleBackColor = true;
            // 
            // ScriptMaps
            // 
            this.ScriptMaps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScriptMaps.FormattingEnabled = true;
            this.ScriptMaps.Items.AddRange(new object[] {
            "v2.0.50727",
            "v4.0.30319",
            "v1.1.4322"});
            this.ScriptMaps.Location = new System.Drawing.Point(108, 153);
            this.ScriptMaps.Name = "ScriptMaps";
            this.ScriptMaps.Size = new System.Drawing.Size(102, 20);
            this.ScriptMaps.TabIndex = 3;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::CrazyIIS.Properties.Resources.Apply;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(328, 100);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 46);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.模板ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(417, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 模板ToolStripMenuItem
            // 
            this.模板ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.默认ToolStripMenuItem,
            this.服务器推荐ToolStripMenuItem,
            this.开发员推荐ToolStripMenuItem});
            this.模板ToolStripMenuItem.Name = "模板ToolStripMenuItem";
            this.模板ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.模板ToolStripMenuItem.Text = "模板";
            // 
            // 默认ToolStripMenuItem
            // 
            this.默认ToolStripMenuItem.Name = "默认ToolStripMenuItem";
            this.默认ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.默认ToolStripMenuItem.Text = "默认";
            this.默认ToolStripMenuItem.Click += new System.EventHandler(this.默认ToolStripMenuItem_Click);
            // 
            // 服务器推荐ToolStripMenuItem
            // 
            this.服务器推荐ToolStripMenuItem.Name = "服务器推荐ToolStripMenuItem";
            this.服务器推荐ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.服务器推荐ToolStripMenuItem.Text = "服务器推荐";
            this.服务器推荐ToolStripMenuItem.Click += new System.EventHandler(this.服务器推荐ToolStripMenuItem_Click);
            // 
            // 开发员推荐ToolStripMenuItem
            // 
            this.开发员推荐ToolStripMenuItem.Name = "开发员推荐ToolStripMenuItem";
            this.开发员推荐ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.开发员推荐ToolStripMenuItem.Text = "开发员推荐";
            this.开发员推荐ToolStripMenuItem.Click += new System.EventHandler(this.开发员推荐ToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "此处默认为：204800即：200K";
            // 
            // GZIP
            // 
            this.GZIP.AutoSize = true;
            this.GZIP.Location = new System.Drawing.Point(107, 27);
            this.GZIP.Name = "GZIP";
            this.GZIP.Size = new System.Drawing.Size(72, 16);
            this.GZIP.TabIndex = 4;
            this.GZIP.Text = "启用GZIP";
            this.GZIP.UseVisualStyleBackColor = true;
            // 
            // FLV
            // 
            this.FLV.AutoSize = true;
            this.FLV.Location = new System.Drawing.Point(197, 27);
            this.FLV.Name = "FLV";
            this.FLV.Size = new System.Drawing.Size(66, 16);
            this.FLV.TabIndex = 4;
            this.FLV.Text = "支持FLV";
            this.FLV.UseVisualStyleBackColor = true;
            // 
            // EnableEditWhileRunning
            // 
            this.EnableEditWhileRunning.AutoSize = true;
            this.EnableEditWhileRunning.Location = new System.Drawing.Point(273, 27);
            this.EnableEditWhileRunning.Name = "EnableEditWhileRunning";
            this.EnableEditWhileRunning.Size = new System.Drawing.Size(132, 16);
            this.EnableEditWhileRunning.TabIndex = 4;
            this.EnableEditWhileRunning.Text = "启用运行时编辑功能";
            this.EnableEditWhileRunning.UseVisualStyleBackColor = true;
            // 
            // btnSaveMetabase
            // 
            this.btnSaveMetabase.Image = global::CrazyIIS.Properties.Resources.Save;
            this.btnSaveMetabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveMetabase.Location = new System.Drawing.Point(231, 153);
            this.btnSaveMetabase.Name = "btnSaveMetabase";
            this.btnSaveMetabase.Size = new System.Drawing.Size(174, 23);
            this.btnSaveMetabase.TabIndex = 6;
            this.btnSaveMetabase.Text = "  保存配置到Metabase.xml";
            this.btnSaveMetabase.UseVisualStyleBackColor = true;
            this.btnSaveMetabase.Click += new System.EventHandler(this.btnSaveMetabase_Click);
            // 
            // txtGzipPath
            // 
            this.txtGzipPath.Location = new System.Drawing.Point(107, 125);
            this.txtGzipPath.Name = "txtGzipPath";
            this.txtGzipPath.Size = new System.Drawing.Size(215, 21);
            this.txtGzipPath.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "GZIP存放位置：";
            // 
            // frmConfigs
            // 
            this.AcceptButton = this.btnEdit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 182);
            this.Controls.Add(this.btnSaveMetabase);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.ScriptMaps);
            this.Controls.Add(this.EnableEditWhileRunning);
            this.Controls.Add(this.FLV);
            this.Controls.Add(this.GZIP);
            this.Controls.Add(this.AspEnableParentPaths);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGzipPath);
            this.Controls.Add(this.LogFileDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DefaultDoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AspMaxRequestEntityAllowed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmConfigs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "IIS综合设置";
            this.Load += new System.EventHandler(this.IIS_Configs_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AspMaxRequestEntityAllowed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DefaultDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LogFileDirectory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox AspEnableParentPaths;
        private System.Windows.Forms.ComboBox ScriptMaps;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 模板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 默认ToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox GZIP;
        private System.Windows.Forms.CheckBox FLV;
        private System.Windows.Forms.CheckBox EnableEditWhileRunning;
        private System.Windows.Forms.Button btnSaveMetabase;
        private System.Windows.Forms.ToolStripMenuItem 服务器推荐ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开发员推荐ToolStripMenuItem;
        private System.Windows.Forms.TextBox txtGzipPath;
        private System.Windows.Forms.Label label6;
    }
}