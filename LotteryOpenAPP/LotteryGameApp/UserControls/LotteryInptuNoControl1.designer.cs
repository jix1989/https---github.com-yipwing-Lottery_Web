namespace LotteryGameApp
{
    partial class LotteryInptuNoControl1
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
            this.btnclear = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnDelRepeat = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnclear
            // 
            this.btnclear.Font = new System.Drawing.Font("宋体", 12F);
            this.btnclear.Location = new System.Drawing.Point(541, 148);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(130, 28);
            this.btnclear.TabIndex = 159;
            this.btnclear.Text = "清  空";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("宋体", 12F);
            this.btnImport.Location = new System.Drawing.Point(541, 78);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(130, 28);
            this.btnImport.TabIndex = 158;
            this.btnImport.Text = "导入文件";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDelRepeat
            // 
            this.btnDelRepeat.Font = new System.Drawing.Font("宋体", 12F);
            this.btnDelRepeat.Location = new System.Drawing.Point(541, 25);
            this.btnDelRepeat.Name = "btnDelRepeat";
            this.btnDelRepeat.Size = new System.Drawing.Size(130, 28);
            this.btnDelRepeat.TabIndex = 156;
            this.btnDelRepeat.Text = "删除重复号码";
            this.btnDelRepeat.UseVisualStyleBackColor = true;
            this.btnDelRepeat.Click += new System.EventHandler(this.btnDelRepeat_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(557, 19);
            this.label5.TabIndex = 157;
            this.label5.Text = "每一个号码之间请用一个 空格[ ]、逗号[,] 或者 分号[;] 隔开";
            // 
            // txtNo
            // 
            this.txtNo.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNo.Location = new System.Drawing.Point(12, 25);
            this.txtNo.Multiline = true;
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(511, 151);
            this.txtNo.TabIndex = 155;
            this.txtNo.Text = "1 2\r\n12 13\r\n123 124\r\n1234 1235\r\n12345 12346\r\n";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // LotteryInptuNoControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnDelRepeat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNo);
            this.Name = "LotteryInptuNoControl1";
            this.Size = new System.Drawing.Size(736, 183);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnDelRepeat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.TextBox txtNo;
    }
}
