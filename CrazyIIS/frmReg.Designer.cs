namespace CrazyIIS
{
    partial class frmReg
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
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIntro = new System.Windows.Forms.TextBox();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUnLock = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtU = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(61, 230);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(394, 21);
            this.txtCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "机器码：";
            // 
            // txtIntro
            // 
            this.txtIntro.Location = new System.Drawing.Point(12, 12);
            this.txtIntro.Multiline = true;
            this.txtIntro.Name = "txtIntro";
            this.txtIntro.ReadOnly = true;
            this.txtIntro.Size = new System.Drawing.Size(525, 212);
            this.txtIntro.TabIndex = 0;
            this.txtIntro.Text = "本软件大多功能是免费的，您可以放心使用\r\n\r\n注册本软件可以享受以下服务：\r\n\r\n1.解除只能还原25个站点的限制。\r\n\r\n2.解除只能随机监控25个站点的限制\r" +
                "\n\r\n3.解除监控网站时不能根据需要选择字段的限制\r\n\r\n4.解除分析历史记录，每次只能分析三条的限制\r\n\r\n5.软件以后所有新增功能免费使用\r\n\r\n6.一年内" +
                "免费更换三次序列号的服务";
            // 
            // txtSN
            // 
            this.txtSN.Location = new System.Drawing.Point(61, 280);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(394, 21);
            this.txtSN.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "序列号：";
            // 
            // btnUnLock
            // 
            this.btnUnLock.Location = new System.Drawing.Point(461, 229);
            this.btnUnLock.Name = "btnUnLock";
            this.btnUnLock.Size = new System.Drawing.Size(76, 71);
            this.btnUnLock.TabIndex = 2;
            this.btnUnLock.Text = "解锁";
            this.btnUnLock.UseVisualStyleBackColor = true;
            this.btnUnLock.Click += new System.EventHandler(this.btnUnLock_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "公司名：";
            // 
            // txtU
            // 
            this.txtU.Location = new System.Drawing.Point(61, 255);
            this.txtU.Name = "txtU";
            this.txtU.Size = new System.Drawing.Size(394, 21);
            this.txtU.TabIndex = 0;
            // 
            // frmReg
            // 
            this.AcceptButton = this.btnUnLock;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 307);
            this.Controls.Add(this.txtU);
            this.Controls.Add(this.txtSN);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUnLock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIntro);
            this.Name = "frmReg";
            this.Text = "注册";
            this.Load += new System.EventHandler(this.frmReg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIntro;
        private System.Windows.Forms.TextBox txtSN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUnLock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtU;
    }
}