namespace LotteryGameApp
{
    partial class FrmAddBankCard
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
            this.cbo1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo2 = new System.Windows.Forms.ComboBox();
            this.cbo3 = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCardNo2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMoneyPwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbo1
            // 
            this.cbo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo1.FormattingEnabled = true;
            this.cbo1.Location = new System.Drawing.Point(217, 3);
            this.cbo1.Name = "cbo1";
            this.cbo1.Size = new System.Drawing.Size(167, 24);
            this.cbo1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "开户银行：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "开户银行省份：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "开户银行城市：";
            // 
            // cbo2
            // 
            this.cbo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo2.FormattingEnabled = true;
            this.cbo2.Location = new System.Drawing.Point(218, 37);
            this.cbo2.Name = "cbo2";
            this.cbo2.Size = new System.Drawing.Size(167, 24);
            this.cbo2.TabIndex = 9;
            this.cbo2.SelectedIndexChanged += new System.EventHandler(this.cbo2_SelectedIndexChanged);
            // 
            // cbo3
            // 
            this.cbo3.DropDownHeight = 200;
            this.cbo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo3.FormattingEnabled = true;
            this.cbo3.IntegralHeight = false;
            this.cbo3.Location = new System.Drawing.Point(217, 71);
            this.cbo3.MaxDropDownItems = 20;
            this.cbo3.Name = "cbo3";
            this.cbo3.Size = new System.Drawing.Size(167, 24);
            this.cbo3.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(218, 105);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(167, 26);
            this.txtName.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(106, 111);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "开户人姓名：";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(217, 141);
            this.txtCardNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(167, 26);
            this.txtCardNo.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "银行卡号码：";
            // 
            // txtCardNo2
            // 
            this.txtCardNo2.Location = new System.Drawing.Point(217, 177);
            this.txtCardNo2.Margin = new System.Windows.Forms.Padding(4);
            this.txtCardNo2.Name = "txtCardNo2";
            this.txtCardNo2.Size = new System.Drawing.Size(167, 26);
            this.txtCardNo2.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 181);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "确认银行卡号码：";
            // 
            // txtMoneyPwd
            // 
            this.txtMoneyPwd.Location = new System.Drawing.Point(217, 213);
            this.txtMoneyPwd.Margin = new System.Windows.Forms.Padding(4);
            this.txtMoneyPwd.Name = "txtMoneyPwd";
            this.txtMoneyPwd.PasswordChar = '*';
            this.txtMoneyPwd.Size = new System.Drawing.Size(167, 26);
            this.txtMoneyPwd.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 216);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "资金密码：";
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(391, 213);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(158, 26);
            this.btn1.TabIndex = 19;
            this.btn1.Text = "绑定";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10F);
            this.label7.Location = new System.Drawing.Point(381, 111);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 14);
            this.label7.TabIndex = 11;
            this.label7.Text = " (只允许中文)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10F);
            this.label8.Location = new System.Drawing.Point(388, 147);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 14);
            this.label8.TabIndex = 11;
            this.label8.Text = "\t(长度在16位至19位之间)";
            // 
            // FrmAddBankCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 262);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.txtMoneyPwd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCardNo2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCardNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbo3);
            this.Controls.Add(this.cbo2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAddBankCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加银行卡";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAddBankCard_FormClosed);
            this.Load += new System.EventHandler(this.FrmAddBankCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo2;
        private System.Windows.Forms.ComboBox cbo3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCardNo2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMoneyPwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}