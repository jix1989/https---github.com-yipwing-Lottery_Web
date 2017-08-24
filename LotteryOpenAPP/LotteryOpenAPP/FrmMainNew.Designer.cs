namespace LotteryOpenAPP
{
    partial class FrmMainNew
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tm1s = new System.Windows.Forms.Timer(this.components);
            this.dgvLottery = new System.Windows.Forms.DataGridView();
            this.LotteryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbLotteryInfo = new System.Windows.Forms.GroupBox();
            this.lblLNo = new System.Windows.Forms.Label();
            this.gbLotteryTime = new System.Windows.Forms.GroupBox();
            this.lblRemainderTime = new System.Windows.Forms.Label();
            this.tmOpen = new System.Windows.Forms.Timer(this.components);
            this.lblPool = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnXZ = new System.Windows.Forms.RadioButton();
            this.rbtnYK = new System.Windows.Forms.RadioButton();
            this.rbtnGD = new System.Windows.Forms.RadioButton();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.txtNo5 = new System.Windows.Forms.TextBox();
            this.txtNo4 = new System.Windows.Forms.TextBox();
            this.txtNo3 = new System.Windows.Forms.TextBox();
            this.txtNo2 = new System.Windows.Forms.TextBox();
            this.txtNo1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblYKJH = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLottery)).BeginInit();
            this.gbLotteryInfo.SuspendLayout();
            this.gbLotteryTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("宋体", 12F);
            this.btnStop.Location = new System.Drawing.Point(319, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(107, 35);
            this.btnStop.TabIndex = 179;
            this.btnStop.Text = "停止开奖";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 12F);
            this.btnStart.Location = new System.Drawing.Point(206, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 35);
            this.btnStart.TabIndex = 178;
            this.btnStart.Text = "启动开奖";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.EnabledChanged += new System.EventHandler(this.btnStart_EnabledChanged);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tm1s
            // 
            this.tm1s.Interval = 1000;
            this.tm1s.Tick += new System.EventHandler(this.tm1s_Tick);
            // 
            // dgvLottery
            // 
            this.dgvLottery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLottery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLottery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLottery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LotteryCode,
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLottery.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLottery.Location = new System.Drawing.Point(12, 12);
            this.dgvLottery.MultiSelect = false;
            this.dgvLottery.Name = "dgvLottery";
            this.dgvLottery.ReadOnly = true;
            this.dgvLottery.RowHeadersVisible = false;
            this.dgvLottery.RowTemplate.Height = 23;
            this.dgvLottery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLottery.Size = new System.Drawing.Size(178, 288);
            this.dgvLottery.TabIndex = 180;
            this.dgvLottery.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLottery_CellClick);
            // 
            // LotteryCode
            // 
            this.LotteryCode.DataPropertyName = "LotteryCode";
            this.LotteryCode.HeaderText = "LotteryCode";
            this.LotteryCode.Name = "LotteryCode";
            this.LotteryCode.ReadOnly = true;
            this.LotteryCode.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "LotteryName";
            this.Column1.HeaderText = "彩种名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // gbLotteryInfo
            // 
            this.gbLotteryInfo.BackColor = System.Drawing.Color.White;
            this.gbLotteryInfo.Controls.Add(this.lblLNo);
            this.gbLotteryInfo.Font = new System.Drawing.Font("宋体", 10F);
            this.gbLotteryInfo.ForeColor = System.Drawing.Color.Black;
            this.gbLotteryInfo.Location = new System.Drawing.Point(468, 53);
            this.gbLotteryInfo.Name = "gbLotteryInfo";
            this.gbLotteryInfo.Size = new System.Drawing.Size(310, 72);
            this.gbLotteryInfo.TabIndex = 182;
            this.gbLotteryInfo.TabStop = false;
            this.gbLotteryInfo.Text = "十一选五 第XXX期 开奖号码";
            // 
            // lblLNo
            // 
            this.lblLNo.AutoSize = true;
            this.lblLNo.BackColor = System.Drawing.Color.Transparent;
            this.lblLNo.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblLNo.ForeColor = System.Drawing.Color.Red;
            this.lblLNo.Location = new System.Drawing.Point(50, 28);
            this.lblLNo.Name = "lblLNo";
            this.lblLNo.Size = new System.Drawing.Size(27, 27);
            this.lblLNo.TabIndex = 131;
            this.lblLNo.Text = "*";
            // 
            // gbLotteryTime
            // 
            this.gbLotteryTime.BackColor = System.Drawing.Color.White;
            this.gbLotteryTime.Controls.Add(this.lblRemainderTime);
            this.gbLotteryTime.Font = new System.Drawing.Font("宋体", 12F);
            this.gbLotteryTime.ForeColor = System.Drawing.Color.Black;
            this.gbLotteryTime.Location = new System.Drawing.Point(206, 53);
            this.gbLotteryTime.Name = "gbLotteryTime";
            this.gbLotteryTime.Size = new System.Drawing.Size(256, 72);
            this.gbLotteryTime.TabIndex = 181;
            this.gbLotteryTime.TabStop = false;
            this.gbLotteryTime.Text = "距离001期开奖";
            // 
            // lblRemainderTime
            // 
            this.lblRemainderTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemainderTime.AutoSize = true;
            this.lblRemainderTime.BackColor = System.Drawing.Color.Transparent;
            this.lblRemainderTime.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRemainderTime.ForeColor = System.Drawing.Color.Black;
            this.lblRemainderTime.Location = new System.Drawing.Point(23, 28);
            this.lblRemainderTime.Name = "lblRemainderTime";
            this.lblRemainderTime.Size = new System.Drawing.Size(42, 27);
            this.lblRemainderTime.TabIndex = 132;
            this.lblRemainderTime.Text = "00";
            // 
            // tmOpen
            // 
            this.tmOpen.Interval = 1000;
            this.tmOpen.Tick += new System.EventHandler(this.tmOpen_Tick);
            // 
            // lblPool
            // 
            this.lblPool.AutoSize = true;
            this.lblPool.Font = new System.Drawing.Font("宋体", 12F);
            this.lblPool.ForeColor = System.Drawing.Color.Red;
            this.lblPool.Location = new System.Drawing.Point(539, 21);
            this.lblPool.Name = "lblPool";
            this.lblPool.Size = new System.Drawing.Size(16, 16);
            this.lblPool.TabIndex = 198;
            this.lblPool.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(476, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 197;
            this.label1.Text = "奖金池：";
            // 
            // rbtnXZ
            // 
            this.rbtnXZ.AutoSize = true;
            this.rbtnXZ.Checked = true;
            this.rbtnXZ.Font = new System.Drawing.Font("宋体", 12F);
            this.rbtnXZ.Location = new System.Drawing.Point(234, 143);
            this.rbtnXZ.Name = "rbtnXZ";
            this.rbtnXZ.Size = new System.Drawing.Size(138, 20);
            this.rbtnXZ.TabIndex = 196;
            this.rbtnXZ.TabStop = true;
            this.rbtnXZ.Text = "按限制规则开奖";
            this.rbtnXZ.UseVisualStyleBackColor = true;
            // 
            // rbtnYK
            // 
            this.rbtnYK.AutoSize = true;
            this.rbtnYK.Font = new System.Drawing.Font("宋体", 12F);
            this.rbtnYK.Location = new System.Drawing.Point(234, 189);
            this.rbtnYK.Name = "rbtnYK";
            this.rbtnYK.Size = new System.Drawing.Size(138, 20);
            this.rbtnYK.TabIndex = 195;
            this.rbtnYK.Text = "按预开奖号开奖";
            this.rbtnYK.UseVisualStyleBackColor = true;
            // 
            // rbtnGD
            // 
            this.rbtnGD.AutoSize = true;
            this.rbtnGD.Font = new System.Drawing.Font("宋体", 12F);
            this.rbtnGD.Location = new System.Drawing.Point(234, 233);
            this.rbtnGD.Name = "rbtnGD";
            this.rbtnGD.Size = new System.Drawing.Size(122, 20);
            this.rbtnGD.TabIndex = 194;
            this.rbtnGD.Text = "按固定开奖号";
            this.rbtnGD.UseVisualStyleBackColor = true;
            this.rbtnGD.CheckedChanged += new System.EventHandler(this.rbtnGD_CheckedChanged);
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.dataGridViewTextBoxColumn1,
            this.Column10,
            this.Column9,
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Column11});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInfo.Location = new System.Drawing.Point(3, 310);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.ReadOnly = true;
            this.dgvInfo.RowHeadersVisible = false;
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(966, 292);
            this.dgvInfo.TabIndex = 200;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Id";
            this.Column7.HeaderText = "系统Id";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 66;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OpenNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "开奖期号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 78;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "预开奖时间";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 90;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "预开奖号码";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 90;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "OpenTime";
            this.Column6.HeaderText = "开奖时间";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 78;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "OpenNum";
            this.Column2.HeaderText = "开奖号码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 78;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TotalBetMoney";
            this.Column3.HeaderText = "总投注金额";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 90;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "fjb";
            this.Column8.HeaderText = "总返水金额";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 90;
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
            // Column11
            // 
            this.Column11.HeaderText = "投返中比例";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 90;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 2;
            this.numericUpDown2.Location = new System.Drawing.Point(496, 142);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(75, 21);
            this.numericUpDown2.TabIndex = 201;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown2.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // txtNo5
            // 
            this.txtNo5.Enabled = false;
            this.txtNo5.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNo5.Location = new System.Drawing.Point(530, 232);
            this.txtNo5.MaxLength = 2;
            this.txtNo5.Name = "txtNo5";
            this.txtNo5.Size = new System.Drawing.Size(29, 26);
            this.txtNo5.TabIndex = 206;
            this.txtNo5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNo5.TextChanged += new System.EventHandler(this.txtNo1_TextChanged);
            // 
            // txtNo4
            // 
            this.txtNo4.Enabled = false;
            this.txtNo4.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNo4.Location = new System.Drawing.Point(495, 232);
            this.txtNo4.MaxLength = 2;
            this.txtNo4.Name = "txtNo4";
            this.txtNo4.Size = new System.Drawing.Size(29, 26);
            this.txtNo4.TabIndex = 205;
            this.txtNo4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNo4.TextChanged += new System.EventHandler(this.txtNo1_TextChanged);
            // 
            // txtNo3
            // 
            this.txtNo3.Enabled = false;
            this.txtNo3.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNo3.Location = new System.Drawing.Point(460, 232);
            this.txtNo3.MaxLength = 2;
            this.txtNo3.Name = "txtNo3";
            this.txtNo3.Size = new System.Drawing.Size(29, 26);
            this.txtNo3.TabIndex = 204;
            this.txtNo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNo3.TextChanged += new System.EventHandler(this.txtNo1_TextChanged);
            // 
            // txtNo2
            // 
            this.txtNo2.Enabled = false;
            this.txtNo2.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNo2.Location = new System.Drawing.Point(424, 232);
            this.txtNo2.MaxLength = 2;
            this.txtNo2.Name = "txtNo2";
            this.txtNo2.Size = new System.Drawing.Size(29, 26);
            this.txtNo2.TabIndex = 203;
            this.txtNo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNo2.TextChanged += new System.EventHandler(this.txtNo1_TextChanged);
            // 
            // txtNo1
            // 
            this.txtNo1.Enabled = false;
            this.txtNo1.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNo1.Location = new System.Drawing.Point(389, 232);
            this.txtNo1.MaxLength = 2;
            this.txtNo1.Name = "txtNo1";
            this.txtNo1.Size = new System.Drawing.Size(29, 26);
            this.txtNo1.TabIndex = 202;
            this.txtNo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNo1.TextChanged += new System.EventHandler(this.txtNo1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(386, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 207;
            this.label2.Text = "返奖比例小于";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(577, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 208;
            this.label3.Text = "%";
            // 
            // lblYKJH
            // 
            this.lblYKJH.AutoSize = true;
            this.lblYKJH.Font = new System.Drawing.Font("宋体", 12F);
            this.lblYKJH.Location = new System.Drawing.Point(386, 191);
            this.lblYKJH.Name = "lblYKJH";
            this.lblYKJH.Size = new System.Drawing.Size(88, 16);
            this.lblYKJH.TabIndex = 209;
            this.lblYKJH.Text = "预开奖号：";
            // 
            // FrmMainNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 614);
            this.Controls.Add(this.lblYKJH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNo5);
            this.Controls.Add(this.txtNo4);
            this.Controls.Add(this.txtNo3);
            this.Controls.Add(this.txtNo2);
            this.Controls.Add(this.txtNo1);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.dgvInfo);
            this.Controls.Add(this.lblPool);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtnXZ);
            this.Controls.Add(this.rbtnYK);
            this.Controls.Add(this.rbtnGD);
            this.Controls.Add(this.gbLotteryInfo);
            this.Controls.Add(this.gbLotteryTime);
            this.Controls.Add(this.dgvLottery);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "FrmMainNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "私彩开奖器";
            this.Load += new System.EventHandler(this.FrmMainNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLottery)).EndInit();
            this.gbLotteryInfo.ResumeLayout(false);
            this.gbLotteryInfo.PerformLayout();
            this.gbLotteryTime.ResumeLayout(false);
            this.gbLotteryTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer tm1s;
        private System.Windows.Forms.DataGridView dgvLottery;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotteryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.GroupBox gbLotteryInfo;
        private System.Windows.Forms.Label lblLNo;
        private System.Windows.Forms.GroupBox gbLotteryTime;
        private System.Windows.Forms.Label lblRemainderTime;
        private System.Windows.Forms.Timer tmOpen;
        private System.Windows.Forms.Label lblPool;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnXZ;
        private System.Windows.Forms.RadioButton rbtnYK;
        private System.Windows.Forms.RadioButton rbtnGD;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.TextBox txtNo5;
        private System.Windows.Forms.TextBox txtNo4;
        private System.Windows.Forms.TextBox txtNo3;
        private System.Windows.Forms.TextBox txtNo2;
        private System.Windows.Forms.TextBox txtNo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblYKJH;
    }
}