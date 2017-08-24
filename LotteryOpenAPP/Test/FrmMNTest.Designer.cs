namespace Test
{
    partial class FrmMNTest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ckbFandian = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvjj = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKJ = new System.Windows.Forms.Label();
            this.lblLNo5 = new System.Windows.Forms.Label();
            this.lblLNo4 = new System.Windows.Forms.Label();
            this.lblLNo3 = new System.Windows.Forms.Label();
            this.lblLNo2 = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblLNo1 = new System.Windows.Forms.Label();
            this.lblAccountCount = new System.Windows.Forms.Label();
            this.gbLotteryInfo = new System.Windows.Forms.GroupBox();
            this.gbLotteryTime = new System.Windows.Forms.GroupBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvjj)).BeginInit();
            this.gbLotteryInfo.SuspendLayout();
            this.gbLotteryTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // ckbFandian
            // 
            this.ckbFandian.AutoSize = true;
            this.ckbFandian.Checked = true;
            this.ckbFandian.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbFandian.Location = new System.Drawing.Point(692, 143);
            this.ckbFandian.Name = "ckbFandian";
            this.ckbFandian.Size = new System.Drawing.Size(84, 16);
            this.ckbFandian.TabIndex = 158;
            this.ckbFandian.Text = "是否要返点";
            this.ckbFandian.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 12F);
            this.btnStart.Location = new System.Drawing.Point(692, 82);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(86, 28);
            this.btnStart.TabIndex = 156;
            this.btnStart.Text = "投注";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "PayBack2";
            this.Column4.HeaderText = "最高奖金";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PayBack";
            this.dataGridViewTextBoxColumn2.HeaderText = "奖金";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "LotteryPlayName";
            this.dataGridViewTextBoxColumn1.HeaderText = "玩法(2元/注)";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dgvjj
            // 
            this.dgvjj.AllowUserToAddRows = false;
            this.dgvjj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvjj.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvjj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvjj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvjj.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvjj.Location = new System.Drawing.Point(338, 82);
            this.dgvjj.Name = "dgvjj";
            this.dgvjj.ReadOnly = true;
            this.dgvjj.RowHeadersVisible = false;
            this.dgvjj.RowTemplate.Height = 23;
            this.dgvjj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvjj.Size = new System.Drawing.Size(348, 423);
            this.dgvjj.TabIndex = 157;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // lblKJ
            // 
            this.lblKJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblKJ.Font = new System.Drawing.Font("宋体", 16F);
            this.lblKJ.ForeColor = System.Drawing.Color.Red;
            this.lblKJ.Location = new System.Drawing.Point(6, 18);
            this.lblKJ.Name = "lblKJ";
            this.lblKJ.Size = new System.Drawing.Size(366, 50);
            this.lblKJ.TabIndex = 136;
            this.lblKJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.lblLNo5.Text = "0";
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
            this.lblLNo4.Text = "0";
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
            this.lblLNo3.Text = "0";
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
            this.lblLNo2.Text = "0";
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
            this.lblLNo1.Text = "0";
            // 
            // lblAccountCount
            // 
            this.lblAccountCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAccountCount.AutoSize = true;
            this.lblAccountCount.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountCount.Font = new System.Drawing.Font("楷体", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblAccountCount.ForeColor = System.Drawing.Color.Black;
            this.lblAccountCount.Location = new System.Drawing.Point(12, 480);
            this.lblAccountCount.Name = "lblAccountCount";
            this.lblAccountCount.Size = new System.Drawing.Size(42, 27);
            this.lblAccountCount.TabIndex = 151;
            this.lblAccountCount.Text = "00";
            // 
            // gbLotteryInfo
            // 
            this.gbLotteryInfo.BackColor = System.Drawing.Color.White;
            this.gbLotteryInfo.Controls.Add(this.lblKJ);
            this.gbLotteryInfo.Controls.Add(this.lblLNo5);
            this.gbLotteryInfo.Controls.Add(this.lblLNo4);
            this.gbLotteryInfo.Controls.Add(this.lblLNo3);
            this.gbLotteryInfo.Controls.Add(this.lblLNo2);
            this.gbLotteryInfo.Controls.Add(this.lblLNo1);
            this.gbLotteryInfo.Font = new System.Drawing.Font("宋体", 12F);
            this.gbLotteryInfo.ForeColor = System.Drawing.Color.Black;
            this.gbLotteryInfo.Location = new System.Drawing.Point(216, 4);
            this.gbLotteryInfo.Name = "gbLotteryInfo";
            this.gbLotteryInfo.Size = new System.Drawing.Size(378, 72);
            this.gbLotteryInfo.TabIndex = 155;
            this.gbLotteryInfo.TabStop = false;
            this.gbLotteryInfo.Text = "十一选五 第XXX期 开奖号码";
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
            this.gbLotteryTime.Location = new System.Drawing.Point(12, 4);
            this.gbLotteryTime.Name = "gbLotteryTime";
            this.gbLotteryTime.Size = new System.Drawing.Size(203, 72);
            this.gbLotteryTime.TabIndex = 154;
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
            // Column3
            // 
            this.Column3.DataPropertyName = "AgentPercent11X5";
            this.Column3.HeaderText = "返点";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "AccountBalance";
            this.Column2.HeaderText = "余额";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "AccountName";
            this.Column1.HeaderText = "用户名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistory.Location = new System.Drawing.Point(12, 82);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowTemplate.Height = 23;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(282, 395);
            this.dgvHistory.TabIndex = 153;
            this.dgvHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistory_CellClick);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("宋体", 12F);
            this.btnLogin.Location = new System.Drawing.Point(68, 35);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(86, 28);
            this.btnLogin.TabIndex = 148;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("宋体", 12F);
            this.txtUser.Location = new System.Drawing.Point(68, 3);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(128, 26);
            this.txtUser.TabIndex = 137;
            this.txtUser.Text = "test";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(6, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 136;
            this.label5.Text = "用户名";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(596, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 68);
            this.panel1.TabIndex = 152;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(692, 180);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 159;
            this.checkBox1.Text = "自动投注";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(692, 214);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 160;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrmMNTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 516);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ckbFandian);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dgvjj);
            this.Controls.Add(this.lblAccountCount);
            this.Controls.Add(this.gbLotteryInfo);
            this.Controls.Add(this.gbLotteryTime);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMNTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvjj)).EndInit();
            this.gbLotteryInfo.ResumeLayout(false);
            this.gbLotteryInfo.PerformLayout();
            this.gbLotteryTime.ResumeLayout(false);
            this.gbLotteryTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbFandian;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dgvjj;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKJ;
        private System.Windows.Forms.Label lblLNo5;
        private System.Windows.Forms.Label lblLNo4;
        private System.Windows.Forms.Label lblLNo3;
        private System.Windows.Forms.Label lblLNo2;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblLNo1;
        private System.Windows.Forms.Label lblAccountCount;
        private System.Windows.Forms.GroupBox gbLotteryInfo;
        private System.Windows.Forms.GroupBox gbLotteryTime;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

