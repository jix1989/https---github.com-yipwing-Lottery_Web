namespace LotteryGameApp
{
    partial class LotteryChoiceNoControl
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel6 = new System.Windows.Forms.Panel();
            this.plOption = new System.Windows.Forms.Panel();
            this.lblOption = new System.Windows.Forms.Label();
            this.plNum = new System.Windows.Forms.Panel();
            this.lblDemo = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.panel6.SuspendLayout();
            this.plOption.SuspendLayout();
            this.plNum.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.plOption);
            this.panel6.Controls.Add(this.plNum);
            this.panel6.Controls.Add(this.lblTip);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Font = new System.Drawing.Font("宋体", 14F);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(780, 30);
            this.panel6.TabIndex = 95;
            // 
            // plOption
            // 
            this.plOption.Controls.Add(this.lblOption);
            this.plOption.Location = new System.Drawing.Point(562, 0);
            this.plOption.Name = "plOption";
            this.plOption.Size = new System.Drawing.Size(217, 30);
            this.plOption.TabIndex = 103;
            // 
            // lblOption
            // 
            this.lblOption.AutoSize = true;
            this.lblOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblOption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOption.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.lblOption.Location = new System.Drawing.Point(3, 5);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(31, 21);
            this.lblOption.TabIndex = 96;
            this.lblOption.Text = "全";
            this.lblOption.Visible = false;
            this.lblOption.Click += new System.EventHandler(this.lblOption_Click);
            this.lblOption.MouseEnter += new System.EventHandler(this.lblOption_MouseEnter);
            this.lblOption.MouseLeave += new System.EventHandler(this.lblOption_MouseLeave);
            // 
            // plNum
            // 
            this.plNum.Controls.Add(this.lblDemo);
            this.plNum.Location = new System.Drawing.Point(96, 0);
            this.plNum.Name = "plNum";
            this.plNum.Size = new System.Drawing.Size(463, 30);
            this.plNum.TabIndex = 102;
            // 
            // lblDemo
            // 
            this.lblDemo.AutoSize = true;
            this.lblDemo.BackColor = System.Drawing.Color.White;
            this.lblDemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDemo.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.lblDemo.Location = new System.Drawing.Point(1, 5);
            this.lblDemo.Name = "lblDemo";
            this.lblDemo.Size = new System.Drawing.Size(22, 21);
            this.lblDemo.TabIndex = 19;
            this.lblDemo.Text = "0";
            this.lblDemo.Visible = false;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(5, 6);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(85, 19);
            this.lblTip.TabIndex = 93;
            this.lblTip.Text = "万位万位";
            // 
            // LotteryChoiceNoControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel6);
            this.Name = "LotteryChoiceNoControl";
            this.Size = new System.Drawing.Size(780, 30);
            this.Load += new System.EventHandler(this.LotteryChoiceNoControl_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.plOption.ResumeLayout(false);
            this.plOption.PerformLayout();
            this.plNum.ResumeLayout(false);
            this.plNum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.Label lblDemo;
        private System.Windows.Forms.Panel plNum;
        private System.Windows.Forms.Panel plOption;
        public System.Windows.Forms.Label lblTip;
    }
}
