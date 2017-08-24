namespace LotteryOpenAPP
{
    partial class FrmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbFixed = new System.Windows.Forms.CheckBox();
            this.txtNo5 = new System.Windows.Forms.TextBox();
            this.txtNo4 = new System.Windows.Forms.TextBox();
            this.txtNo3 = new System.Windows.Forms.TextBox();
            this.txtNo2 = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtNo1 = new System.Windows.Forms.TextBox();
            this.gbLotteryInfo = new System.Windows.Forms.GroupBox();
            this.lblLNo5 = new System.Windows.Forms.Label();
            this.lblLNo4 = new System.Windows.Forms.Label();
            this.lblLNo3 = new System.Windows.Forms.Label();
            this.lblLNo2 = new System.Windows.Forms.Label();
            this.lblLNo1 = new System.Windows.Forms.Label();
            this.gbLotteryTime = new System.Windows.Forms.GroupBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbLotteryInfo.SuspendLayout();
            this.gbLotteryTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFixed
            // 
            this.cbFixed.AutoSize = true;
            this.cbFixed.Font = new System.Drawing.Font("宋体", 12F);
            this.cbFixed.Location = new System.Drawing.Point(12, 6);
            this.cbFixed.Name = "cbFixed";
            this.cbFixed.Size = new System.Drawing.Size(115, 20);
            this.cbFixed.TabIndex = 171;
            this.cbFixed.Text = "开奖固定号:";
            this.cbFixed.UseVisualStyleBackColor = true;
            this.cbFixed.CheckedChanged += new System.EventHandler(this.cbFixed_CheckedChanged);
            // 
            // txtNo5
            // 
            this.txtNo5.Enabled = false;
            this.txtNo5.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNo5.Location = new System.Drawing.Point(274, 5);
            this.txtNo5.MaxLength = 2;
            this.txtNo5.Name = "txtNo5";
            this.txtNo5.Size = new System.Drawing.Size(29, 26);
            this.txtNo5.TabIndex = 170;
            this.txtNo5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNo4
            // 
            this.txtNo4.Enabled = false;
            this.txtNo4.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNo4.Location = new System.Drawing.Point(239, 5);
            this.txtNo4.MaxLength = 2;
            this.txtNo4.Name = "txtNo4";
            this.txtNo4.Size = new System.Drawing.Size(29, 26);
            this.txtNo4.TabIndex = 169;
            this.txtNo4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNo3
            // 
            this.txtNo3.Enabled = false;
            this.txtNo3.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNo3.Location = new System.Drawing.Point(204, 5);
            this.txtNo3.MaxLength = 2;
            this.txtNo3.Name = "txtNo3";
            this.txtNo3.Size = new System.Drawing.Size(29, 26);
            this.txtNo3.TabIndex = 168;
            this.txtNo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNo2
            // 
            this.txtNo2.Enabled = false;
            this.txtNo2.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNo2.Location = new System.Drawing.Point(168, 5);
            this.txtNo2.MaxLength = 2;
            this.txtNo2.Name = "txtNo2";
            this.txtNo2.Size = new System.Drawing.Size(29, 26);
            this.txtNo2.TabIndex = 167;
            this.txtNo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("宋体", 12F);
            this.btnStop.Location = new System.Drawing.Point(457, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(107, 35);
            this.btnStop.TabIndex = 166;
            this.btnStop.Text = "停止开奖";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 12F);
            this.btnStart.Location = new System.Drawing.Point(327, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 35);
            this.btnStart.TabIndex = 165;
            this.btnStart.Text = "启动开奖";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtNo1
            // 
            this.txtNo1.Enabled = false;
            this.txtNo1.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNo1.Location = new System.Drawing.Point(133, 5);
            this.txtNo1.MaxLength = 2;
            this.txtNo1.Name = "txtNo1";
            this.txtNo1.Size = new System.Drawing.Size(29, 26);
            this.txtNo1.TabIndex = 164;
            this.txtNo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbLotteryInfo
            // 
            this.gbLotteryInfo.BackColor = System.Drawing.Color.White;
            this.gbLotteryInfo.Controls.Add(this.lblLNo5);
            this.gbLotteryInfo.Controls.Add(this.lblLNo4);
            this.gbLotteryInfo.Controls.Add(this.lblLNo3);
            this.gbLotteryInfo.Controls.Add(this.lblLNo2);
            this.gbLotteryInfo.Controls.Add(this.lblLNo1);
            this.gbLotteryInfo.Font = new System.Drawing.Font("宋体", 12F);
            this.gbLotteryInfo.ForeColor = System.Drawing.Color.Black;
            this.gbLotteryInfo.Location = new System.Drawing.Point(221, 78);
            this.gbLotteryInfo.Name = "gbLotteryInfo";
            this.gbLotteryInfo.Size = new System.Drawing.Size(378, 72);
            this.gbLotteryInfo.TabIndex = 161;
            this.gbLotteryInfo.TabStop = false;
            this.gbLotteryInfo.Text = "十一选五 第XXX期 开奖号码";
            // 
            // lblLNo5
            // 
            this.lblLNo5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLNo5.AutoSize = true;
            this.lblLNo5.BackColor = System.Drawing.Color.Transparent;
            this.lblLNo5.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblLNo5.ForeColor = System.Drawing.Color.Red;
            this.lblLNo5.Location = new System.Drawing.Point(292, 28);
            this.lblLNo5.Name = "lblLNo5";
            this.lblLNo5.Size = new System.Drawing.Size(27, 27);
            this.lblLNo5.TabIndex = 135;
            this.lblLNo5.Text = "*";
            // 
            // lblLNo4
            // 
            this.lblLNo4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLNo4.AutoSize = true;
            this.lblLNo4.BackColor = System.Drawing.Color.Transparent;
            this.lblLNo4.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblLNo4.ForeColor = System.Drawing.Color.Red;
            this.lblLNo4.Location = new System.Drawing.Point(239, 28);
            this.lblLNo4.Name = "lblLNo4";
            this.lblLNo4.Size = new System.Drawing.Size(27, 27);
            this.lblLNo4.TabIndex = 134;
            this.lblLNo4.Text = "*";
            // 
            // lblLNo3
            // 
            this.lblLNo3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLNo3.AutoSize = true;
            this.lblLNo3.BackColor = System.Drawing.Color.Transparent;
            this.lblLNo3.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblLNo3.ForeColor = System.Drawing.Color.Red;
            this.lblLNo3.Location = new System.Drawing.Point(186, 28);
            this.lblLNo3.Name = "lblLNo3";
            this.lblLNo3.Size = new System.Drawing.Size(27, 27);
            this.lblLNo3.TabIndex = 133;
            this.lblLNo3.Text = "*";
            // 
            // lblLNo2
            // 
            this.lblLNo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLNo2.AutoSize = true;
            this.lblLNo2.BackColor = System.Drawing.Color.Transparent;
            this.lblLNo2.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblLNo2.ForeColor = System.Drawing.Color.Red;
            this.lblLNo2.Location = new System.Drawing.Point(133, 28);
            this.lblLNo2.Name = "lblLNo2";
            this.lblLNo2.Size = new System.Drawing.Size(27, 27);
            this.lblLNo2.TabIndex = 132;
            this.lblLNo2.Text = "*";
            // 
            // lblLNo1
            // 
            this.lblLNo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLNo1.AutoSize = true;
            this.lblLNo1.BackColor = System.Drawing.Color.Transparent;
            this.lblLNo1.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblLNo1.ForeColor = System.Drawing.Color.Red;
            this.lblLNo1.Location = new System.Drawing.Point(80, 28);
            this.lblLNo1.Name = "lblLNo1";
            this.lblLNo1.Size = new System.Drawing.Size(27, 27);
            this.lblLNo1.TabIndex = 131;
            this.lblLNo1.Text = "*";
            // 
            // gbLotteryTime
            // 
            this.gbLotteryTime.BackColor = System.Drawing.Color.White;
            this.gbLotteryTime.Controls.Add(this.lblHours);
            this.gbLotteryTime.Controls.Add(this.lblSec);
            this.gbLotteryTime.Controls.Add(this.lblMin);
            this.gbLotteryTime.Controls.Add(this.label3);
            this.gbLotteryTime.Controls.Add(this.label4);
            this.gbLotteryTime.Font = new System.Drawing.Font("宋体", 12F);
            this.gbLotteryTime.ForeColor = System.Drawing.Color.Black;
            this.gbLotteryTime.Location = new System.Drawing.Point(12, 78);
            this.gbLotteryTime.Name = "gbLotteryTime";
            this.gbLotteryTime.Size = new System.Drawing.Size(203, 72);
            this.gbLotteryTime.TabIndex = 160;
            this.gbLotteryTime.TabStop = false;
            this.gbLotteryTime.Text = "距离001期开奖";
            // 
            // lblHours
            // 
            this.lblHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHours.AutoSize = true;
            this.lblHours.BackColor = System.Drawing.Color.Transparent;
            this.lblHours.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHours.ForeColor = System.Drawing.Color.Black;
            this.lblHours.Location = new System.Drawing.Point(17, 28);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(42, 27);
            this.lblHours.TabIndex = 132;
            this.lblHours.Text = "00";
            // 
            // lblSec
            // 
            this.lblSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSec.AutoSize = true;
            this.lblSec.BackColor = System.Drawing.Color.Transparent;
            this.lblSec.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblSec.ForeColor = System.Drawing.Color.Black;
            this.lblSec.Location = new System.Drawing.Point(141, 28);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(42, 27);
            this.lblSec.TabIndex = 131;
            this.lblSec.Text = "00";
            // 
            // lblMin
            // 
            this.lblMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMin.AutoSize = true;
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMin.ForeColor = System.Drawing.Color.Black;
            this.lblMin.Location = new System.Drawing.Point(80, 28);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(42, 27);
            this.lblMin.TabIndex = 130;
            this.lblMin.Text = "00";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(57, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 27);
            this.label3.TabIndex = 133;
            this.label3.Text = "：";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(114, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 27);
            this.label4.TabIndex = 134;
            this.label4.Text = "：";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column8,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInfo.Location = new System.Drawing.Point(1, 156);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.ReadOnly = true;
            this.dgvInfo.RowHeadersVisible = false;
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(687, 225);
            this.dgvInfo.TabIndex = 172;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Id";
            this.Column7.HeaderText = "系统Id";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 66;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "OpenNo";
            this.Column1.HeaderText = "开奖期号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 78;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "OpenNum";
            this.Column2.HeaderText = "开奖号码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 78;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "fjb";
            this.Column8.HeaderText = "返奖比";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 66;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TotalBetMoney";
            this.Column3.HeaderText = "总投注金额";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 90;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TotalBackMoney";
            this.Column4.HeaderText = "总中奖金额";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 90;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "WinMoney";
            this.Column5.HeaderText = "盈亏状况";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 78;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "OpenTime";
            this.Column6.HeaderText = "开奖时间";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 78;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 381);
            this.Controls.Add(this.dgvInfo);
            this.Controls.Add(this.cbFixed);
            this.Controls.Add(this.txtNo5);
            this.Controls.Add(this.txtNo4);
            this.Controls.Add(this.txtNo3);
            this.Controls.Add(this.txtNo2);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtNo1);
            this.Controls.Add(this.gbLotteryInfo);
            this.Controls.Add(this.gbLotteryTime);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "开奖器";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.gbLotteryInfo.ResumeLayout(false);
            this.gbLotteryInfo.PerformLayout();
            this.gbLotteryTime.ResumeLayout(false);
            this.gbLotteryTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbFixed;
        private System.Windows.Forms.TextBox txtNo5;
        private System.Windows.Forms.TextBox txtNo4;
        private System.Windows.Forms.TextBox txtNo3;
        private System.Windows.Forms.TextBox txtNo2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtNo1;
        private System.Windows.Forms.GroupBox gbLotteryInfo;
        private System.Windows.Forms.Label lblLNo5;
        private System.Windows.Forms.Label lblLNo4;
        private System.Windows.Forms.Label lblLNo3;
        private System.Windows.Forms.Label lblLNo2;
        private System.Windows.Forms.Label lblLNo1;
        private System.Windows.Forms.GroupBox gbLotteryTime;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}

