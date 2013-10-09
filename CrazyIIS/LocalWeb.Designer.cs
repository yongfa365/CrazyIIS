namespace CrazyIIS
{
    partial class LocalWeb
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblOK = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.AppPoolId = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ServerAutoStart = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOK
            // 
            this.lblOK.AutoSize = true;
            this.lblOK.Location = new System.Drawing.Point(207, 42);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(41, 12);
            this.lblOK.TabIndex = 22;
            this.lblOK.Text = "结果：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(451, 323);
            this.dataGridView1.TabIndex = 21;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::CrazyIIS.Properties.Resources.refresh;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(366, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(77, 45);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "  刷新";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // AppPoolId
            // 
            this.AppPoolId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.AppPoolId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.AppPoolId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AppPoolId.FormattingEnabled = true;
            this.AppPoolId.Items.AddRange(new object[] {
            "全部"});
            this.AppPoolId.Location = new System.Drawing.Point(87, 17);
            this.AppPoolId.Name = "AppPoolId";
            this.AppPoolId.Size = new System.Drawing.Size(114, 20);
            this.AppPoolId.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "应用程序池：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "网站：";
            // 
            // txtWeb
            // 
            this.txtWeb.Location = new System.Drawing.Point(246, 16);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(114, 21);
            this.txtWeb.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ServerAutoStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.AppPoolId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtWeb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.lblOK);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 63);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查找";
            // 
            // ServerAutoStart
            // 
            this.ServerAutoStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerAutoStart.FormattingEnabled = true;
            this.ServerAutoStart.Location = new System.Drawing.Point(87, 39);
            this.ServerAutoStart.Name = "ServerAutoStart";
            this.ServerAutoStart.Size = new System.Drawing.Size(114, 20);
            this.ServerAutoStart.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "网 站 状态：";
            // 
            // LocalWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LocalWeb";
            this.Size = new System.Drawing.Size(457, 391);
            this.Load += new System.EventHandler(this.LocalWeb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOK;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox AppPoolId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ServerAutoStart;
        private System.Windows.Forms.Label label2;
    }
}
