namespace LotteryGameApp
{
    partial class FrmRechargeWithdraw
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nudRechargeMoney = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtn3 = new System.Windows.Forms.RadioButton();
            this.rbtn2 = new System.Windows.Forms.RadioButton();
            this.rbtn1 = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnRecharge = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvRechargeInfo = new System.Windows.Forms.DataGridView();
            this.btnRechargeQuery = new System.Windows.Forms.Button();
            this.dtREnd = new System.Windows.Forms.DateTimePicker();
            this.dtRStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCanWithdraw = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nudWithdrawMoney = new System.Windows.Forms.NumericUpDown();
            this.txtMoneyPwd = new System.Windows.Forms.TextBox();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvWithdraw = new System.Windows.Forms.DataGridView();
            this.btnWithdrawQuery = new System.Windows.Forms.Button();
            this.dtWEnd = new System.Windows.Forms.DateTimePicker();
            this.dtWStart = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRechargeMoney)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechargeInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWithdrawMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWithdraw)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(735, 394);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnRecharge);
            this.tabPage1.Controls.Add(this.nudRechargeMoney);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.rbtn3);
            this.tabPage1.Controls.Add(this.rbtn2);
            this.tabPage1.Controls.Add(this.rbtn1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(727, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "充值";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // nudRechargeMoney
            // 
            this.nudRechargeMoney.Location = new System.Drawing.Point(274, 136);
            this.nudRechargeMoney.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRechargeMoney.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudRechargeMoney.Name = "nudRechargeMoney";
            this.nudRechargeMoney.Size = new System.Drawing.Size(87, 26);
            this.nudRechargeMoney.TabIndex = 6;
            this.nudRechargeMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRechargeMoney.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(373, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "(单次充值最低100，最高10000)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "充值金额：";
            // 
            // rbtn3
            // 
            this.rbtn3.AutoSize = true;
            this.rbtn3.Location = new System.Drawing.Point(450, 68);
            this.rbtn3.Name = "rbtn3";
            this.rbtn3.Size = new System.Drawing.Size(106, 20);
            this.rbtn3.TabIndex = 2;
            this.rbtn3.Text = "银行卡转账";
            this.rbtn3.UseVisualStyleBackColor = true;
            // 
            // rbtn2
            // 
            this.rbtn2.AutoSize = true;
            this.rbtn2.Location = new System.Drawing.Point(280, 68);
            this.rbtn2.Name = "rbtn2";
            this.rbtn2.Size = new System.Drawing.Size(90, 20);
            this.rbtn2.TabIndex = 1;
            this.rbtn2.Text = "在线支付";
            this.rbtn2.UseVisualStyleBackColor = true;
            // 
            // rbtn1
            // 
            this.rbtn1.AutoSize = true;
            this.rbtn1.Checked = true;
            this.rbtn1.Location = new System.Drawing.Point(109, 68);
            this.rbtn1.Name = "rbtn1";
            this.rbtn1.Size = new System.Drawing.Size(90, 20);
            this.rbtn1.TabIndex = 0;
            this.rbtn1.TabStop = true;
            this.rbtn1.Text = "微信支付";
            this.rbtn1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dgvRechargeInfo);
            this.tabPage2.Controls.Add(this.btnRechargeQuery);
            this.tabPage2.Controls.Add(this.dtREnd);
            this.tabPage2.Controls.Add(this.dtRStart);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(727, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "充值记录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnWithdraw);
            this.tabPage3.Controls.Add(this.txtMoneyPwd);
            this.tabPage3.Controls.Add(this.nudWithdrawMoney);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.cboBank);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.lblCanWithdraw);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.lblTip);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(727, 364);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "提现";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.dgvWithdraw);
            this.tabPage4.Controls.Add(this.btnWithdrawQuery);
            this.tabPage4.Controls.Add(this.dtWEnd);
            this.tabPage4.Controls.Add(this.dtWStart);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(727, 364);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "提现记录";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnRecharge
            // 
            this.btnRecharge.Location = new System.Drawing.Point(256, 231);
            this.btnRecharge.Name = "btnRecharge";
            this.btnRecharge.Size = new System.Drawing.Size(136, 39);
            this.btnRecharge.TabIndex = 7;
            this.btnRecharge.Text = "立即充值";
            this.btnRecharge.UseVisualStyleBackColor = true;
            this.btnRecharge.Click += new System.EventHandler(this.btnRecharge_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(286, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 156;
            this.label3.Text = "至";
            // 
            // dgvRechargeInfo
            // 
            this.dgvRechargeInfo.AllowUserToAddRows = false;
            this.dgvRechargeInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRechargeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRechargeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRechargeInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRechargeInfo.Location = new System.Drawing.Point(6, 44);
            this.dgvRechargeInfo.Name = "dgvRechargeInfo";
            this.dgvRechargeInfo.ReadOnly = true;
            this.dgvRechargeInfo.RowHeadersVisible = false;
            this.dgvRechargeInfo.RowTemplate.Height = 23;
            this.dgvRechargeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRechargeInfo.Size = new System.Drawing.Size(713, 312);
            this.dgvRechargeInfo.TabIndex = 162;
            // 
            // btnRechargeQuery
            // 
            this.btnRechargeQuery.Font = new System.Drawing.Font("宋体", 12F);
            this.btnRechargeQuery.Location = new System.Drawing.Point(483, 9);
            this.btnRechargeQuery.Name = "btnRechargeQuery";
            this.btnRechargeQuery.Size = new System.Drawing.Size(139, 28);
            this.btnRechargeQuery.TabIndex = 161;
            this.btnRechargeQuery.Text = "查询";
            this.btnRechargeQuery.UseVisualStyleBackColor = true;
            this.btnRechargeQuery.Click += new System.EventHandler(this.btnRechargeQuery_Click);
            // 
            // dtREnd
            // 
            this.dtREnd.Location = new System.Drawing.Point(317, 11);
            this.dtREnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtREnd.Name = "dtREnd";
            this.dtREnd.Size = new System.Drawing.Size(139, 26);
            this.dtREnd.TabIndex = 159;
            // 
            // dtRStart
            // 
            this.dtRStart.Location = new System.Drawing.Point(138, 11);
            this.dtRStart.Margin = new System.Windows.Forms.Padding(4);
            this.dtRStart.Name = "dtRStart";
            this.dtRStart.Size = new System.Drawing.Size(139, 26);
            this.dtRStart.TabIndex = 153;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(61, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 155;
            this.label4.Text = "充值时间：";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("宋体", 12F);
            this.lblTip.Location = new System.Drawing.Point(83, 0);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(560, 96);
            this.lblTip.TabIndex = 1;
            this.lblTip.Text = "\r\n使用提示：1、每天限提现 6 次，今天您已经成功发起了 {0} 次提现申请。。\r\n\r\n          2、全天 24小时 提现。\r\n\r\n         " +
    " 3、新绑定的提现银行卡需要超过 6 小时才能正常提款。";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(125, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "可提现金额：";
            // 
            // lblCanWithdraw
            // 
            this.lblCanWithdraw.AutoSize = true;
            this.lblCanWithdraw.Font = new System.Drawing.Font("宋体", 12F);
            this.lblCanWithdraw.ForeColor = System.Drawing.Color.Red;
            this.lblCanWithdraw.Location = new System.Drawing.Point(235, 127);
            this.lblCanWithdraw.Name = "lblCanWithdraw";
            this.lblCanWithdraw.Size = new System.Drawing.Size(104, 16);
            this.lblCanWithdraw.TabIndex = 3;
            this.lblCanWithdraw.Text = " 64.6181 RMB";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(95, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "收款银行卡信息：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(143, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "提现金额：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.Location = new System.Drawing.Point(144, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "资金密码：";
            // 
            // cboBank
            // 
            this.cboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Items.AddRange(new object[] {
            "全部",
            "投注扣款",
            "奖金派发",
            "游戏返点"});
            this.cboBank.Location = new System.Drawing.Point(238, 170);
            this.cboBank.Margin = new System.Windows.Forms.Padding(4);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(296, 24);
            this.cboBank.TabIndex = 163;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F);
            this.label10.Location = new System.Drawing.Point(333, 227);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(360, 16);
            this.label10.TabIndex = 164;
            this.label10.Text = "元 ( 最小提现金额 100 RMB / 最大 49999 RMB )";
            // 
            // nudWithdrawMoney
            // 
            this.nudWithdrawMoney.Location = new System.Drawing.Point(240, 222);
            this.nudWithdrawMoney.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudWithdrawMoney.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudWithdrawMoney.Name = "nudWithdrawMoney";
            this.nudWithdrawMoney.Size = new System.Drawing.Size(87, 26);
            this.nudWithdrawMoney.TabIndex = 165;
            this.nudWithdrawMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudWithdrawMoney.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // txtMoneyPwd
            // 
            this.txtMoneyPwd.Location = new System.Drawing.Point(238, 266);
            this.txtMoneyPwd.Name = "txtMoneyPwd";
            this.txtMoneyPwd.Size = new System.Drawing.Size(160, 26);
            this.txtMoneyPwd.TabIndex = 166;
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(262, 309);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(136, 39);
            this.btnWithdraw.TabIndex = 167;
            this.btnWithdraw.Text = "提交";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(286, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 16);
            this.label6.TabIndex = 165;
            this.label6.Text = "至";
            // 
            // dgvWithdraw
            // 
            this.dgvWithdraw.AllowUserToAddRows = false;
            this.dgvWithdraw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWithdraw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWithdraw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWithdraw.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvWithdraw.Location = new System.Drawing.Point(6, 44);
            this.dgvWithdraw.Name = "dgvWithdraw";
            this.dgvWithdraw.ReadOnly = true;
            this.dgvWithdraw.RowHeadersVisible = false;
            this.dgvWithdraw.RowTemplate.Height = 23;
            this.dgvWithdraw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWithdraw.Size = new System.Drawing.Size(713, 312);
            this.dgvWithdraw.TabIndex = 168;
            // 
            // btnWithdrawQuery
            // 
            this.btnWithdrawQuery.Font = new System.Drawing.Font("宋体", 12F);
            this.btnWithdrawQuery.Location = new System.Drawing.Point(483, 9);
            this.btnWithdrawQuery.Name = "btnWithdrawQuery";
            this.btnWithdrawQuery.Size = new System.Drawing.Size(139, 28);
            this.btnWithdrawQuery.TabIndex = 167;
            this.btnWithdrawQuery.Text = "查询";
            this.btnWithdrawQuery.UseVisualStyleBackColor = true;
            this.btnWithdrawQuery.Click += new System.EventHandler(this.btnWithdrawQuery_Click);
            // 
            // dtWEnd
            // 
            this.dtWEnd.Location = new System.Drawing.Point(317, 11);
            this.dtWEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtWEnd.Name = "dtWEnd";
            this.dtWEnd.Size = new System.Drawing.Size(139, 26);
            this.dtWEnd.TabIndex = 166;
            // 
            // dtWStart
            // 
            this.dtWStart.Location = new System.Drawing.Point(138, 11);
            this.dtWStart.Margin = new System.Windows.Forms.Padding(4);
            this.dtWStart.Name = "dtWStart";
            this.dtWStart.Size = new System.Drawing.Size(139, 26);
            this.dtWStart.TabIndex = 163;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F);
            this.label11.Location = new System.Drawing.Point(61, 17);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 164;
            this.label11.Text = "充值时间：";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "No";
            this.dataGridViewTextBoxColumn1.HeaderText = "序号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OrderNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "提款编号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Money";
            this.dataGridViewTextBoxColumn3.HeaderText = "提款金额";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CreateTime";
            this.dataGridViewTextBoxColumn4.HeaderText = "申请时间";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Remarks";
            this.dataGridViewTextBoxColumn6.HeaderText = "备注";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "StatusStr";
            this.dataGridViewTextBoxColumn7.HeaderText = "状态";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "No";
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Type";
            this.Column2.HeaderText = "类型";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "OrderNo";
            this.Column3.HeaderText = "编号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Money";
            this.Column4.HeaderText = "金额";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CreateTime";
            this.Column5.HeaderText = "时间";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Remarks";
            this.Column6.HeaderText = "备注";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "StatusStr";
            this.Column7.HeaderText = "状态";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // FrmRechargeWithdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 394);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRechargeWithdraw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "银行充提";
            this.Load += new System.EventHandler(this.FrmRechargeWithdraw_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRechargeMoney)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechargeInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWithdrawMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWithdraw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RadioButton rbtn3;
        private System.Windows.Forms.RadioButton rbtn2;
        private System.Windows.Forms.RadioButton rbtn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudRechargeMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRecharge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvRechargeInfo;
        private System.Windows.Forms.Button btnRechargeQuery;
        private System.Windows.Forms.DateTimePicker dtREnd;
        private System.Windows.Forms.DateTimePicker dtRStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCanWithdraw;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudWithdrawMoney;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.TextBox txtMoneyPwd;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvWithdraw;
        private System.Windows.Forms.Button btnWithdrawQuery;
        private System.Windows.Forms.DateTimePicker dtWEnd;
        private System.Windows.Forms.DateTimePicker dtWStart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}