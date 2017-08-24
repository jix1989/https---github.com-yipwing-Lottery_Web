namespace LotteryGameApp
{
    partial class LotteryPositionCbk
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
            this.cbk0 = new System.Windows.Forms.CheckBox();
            this.cbk1 = new System.Windows.Forms.CheckBox();
            this.cbk2 = new System.Windows.Forms.CheckBox();
            this.cbk3 = new System.Windows.Forms.CheckBox();
            this.cbk4 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbk0
            // 
            this.cbk0.AutoSize = true;
            this.cbk0.Font = new System.Drawing.Font("宋体", 12F);
            this.cbk0.Location = new System.Drawing.Point(1, 11);
            this.cbk0.Name = "cbk0";
            this.cbk0.Size = new System.Drawing.Size(59, 20);
            this.cbk0.TabIndex = 0;
            this.cbk0.Text = "万位";
            this.cbk0.UseVisualStyleBackColor = true;
            this.cbk0.CheckedChanged += new System.EventHandler(this.cbk0_CheckedChanged);
            // 
            // cbk1
            // 
            this.cbk1.AutoSize = true;
            this.cbk1.Font = new System.Drawing.Font("宋体", 12F);
            this.cbk1.Location = new System.Drawing.Point(62, 11);
            this.cbk1.Name = "cbk1";
            this.cbk1.Size = new System.Drawing.Size(59, 20);
            this.cbk1.TabIndex = 1;
            this.cbk1.Text = "千位";
            this.cbk1.UseVisualStyleBackColor = true;
            // 
            // cbk2
            // 
            this.cbk2.AutoSize = true;
            this.cbk2.Font = new System.Drawing.Font("宋体", 12F);
            this.cbk2.Location = new System.Drawing.Point(123, 11);
            this.cbk2.Name = "cbk2";
            this.cbk2.Size = new System.Drawing.Size(59, 20);
            this.cbk2.TabIndex = 2;
            this.cbk2.Text = "百位";
            this.cbk2.UseVisualStyleBackColor = true;
            // 
            // cbk3
            // 
            this.cbk3.AutoSize = true;
            this.cbk3.Font = new System.Drawing.Font("宋体", 12F);
            this.cbk3.Location = new System.Drawing.Point(184, 11);
            this.cbk3.Name = "cbk3";
            this.cbk3.Size = new System.Drawing.Size(59, 20);
            this.cbk3.TabIndex = 3;
            this.cbk3.Text = "十位";
            this.cbk3.UseVisualStyleBackColor = true;
            // 
            // cbk4
            // 
            this.cbk4.AutoSize = true;
            this.cbk4.Font = new System.Drawing.Font("宋体", 12F);
            this.cbk4.Location = new System.Drawing.Point(245, 11);
            this.cbk4.Name = "cbk4";
            this.cbk4.Size = new System.Drawing.Size(59, 20);
            this.cbk4.TabIndex = 4;
            this.cbk4.Text = "个位";
            this.cbk4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(307, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "温馨提示：你选择了 4 个位置，系统自动根据位置组合成 1 个方案。";
            // 
            // LotteryPositionCbk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbk4);
            this.Controls.Add(this.cbk3);
            this.Controls.Add(this.cbk2);
            this.Controls.Add(this.cbk1);
            this.Controls.Add(this.cbk0);
            this.Name = "LotteryPositionCbk";
            this.Size = new System.Drawing.Size(745, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbk0;
        private System.Windows.Forms.CheckBox cbk1;
        private System.Windows.Forms.CheckBox cbk2;
        private System.Windows.Forms.CheckBox cbk3;
        private System.Windows.Forms.CheckBox cbk4;
        private System.Windows.Forms.Label label1;
    }
}
