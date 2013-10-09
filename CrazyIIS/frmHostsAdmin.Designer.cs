namespace CrazyIIS
{
    partial class frmHostsAdmin
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOpenNotePad = new System.Windows.Forms.Button();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(365, 518);
            this.textBox1.TabIndex = 0;
            // 
            // btnOpenNotePad
            // 
            this.btnOpenNotePad.Location = new System.Drawing.Point(387, 24);
            this.btnOpenNotePad.Name = "btnOpenNotePad";
            this.btnOpenNotePad.Size = new System.Drawing.Size(89, 23);
            this.btnOpenNotePad.TabIndex = 1;
            this.btnOpenNotePad.Text = "打开目录";
            this.btnOpenNotePad.UseVisualStyleBackColor = true;
            this.btnOpenNotePad.Click += new System.EventHandler(this.btnOpenNotePad_Click);
            // 
            // btnToLeft
            // 
            this.btnToLeft.Location = new System.Drawing.Point(387, 71);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(89, 23);
            this.btnToLeft.TabIndex = 2;
            this.btnToLeft.Text = "导入到左侧";
            this.btnToLeft.UseVisualStyleBackColor = true;
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(387, 100);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存左侧";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmHostsAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 518);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnToLeft);
            this.Controls.Add(this.btnOpenNotePad);
            this.Controls.Add(this.textBox1);
            this.Name = "frmHostsAdmin";
            this.Text = "HostsAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnOpenNotePad;
        private System.Windows.Forms.Button btnToLeft;
        private System.Windows.Forms.Button btnSave;
    }
}