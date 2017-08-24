using LotteryModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LotteryGameApp
{
    public partial class FrmBet_11x5 : Form
    {
        //LotteryOpenDAL LotteryOpenDAL = new LotteryOpenDAL();
        DateTime dtLoad;
        Lotterys lottery;
        LotteryOpenInfoDAL LotteryOpenInfoDAL = new LotteryOpenInfoDAL();
        LotteryOpenOffcialInfoDAL LotteryOpenOffcialInfoDAL = new LotteryOpenOffcialInfoDAL();
        AccountDAL AccountDAL = new AccountDAL();
        Accounts account = StaticInfo.Account;
        /// <summary>
        /// 每期间隔
        /// </summary>
        TimeSpan dtOne;
        TimeSpan _1s = new TimeSpan(TimeSpan.TicksPerSecond);
        bool jix_test = false;
        string lblTotalTxt = "选择0注，共￥0元";
        /// <summary>
        /// 上期开奖期号
        /// </summary>
        LotteryOpenInfo lastOpen;
        /// <summary>
        /// 下一期开奖号码
        /// </summary>
        LotteryOffcialSchedule nextOpen;

        public FrmBet_11x5(string lname)
        {
            InitializeComponent();
            this.BackgroundImage = global::LotteryGameApp.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Text = lname + "十一选五";
            lblLname.Text = this.Text;
            switch (lname)
            {
                case "山东":
                    lottery = EntitiesTool.GetLotteryDic()["sd11x5"];
                    lblLname2.Text = string.Format(lblLname2.Text, "SHANDONG", 10, 87);
                    break;
                case "江西":
                    lblLname2.Text = string.Format(lblLname2.Text, "JIANGXI", 10, 84);
                    lottery = EntitiesTool.GetLotteryDic()["jx11x5"];
                    break;
                case "广东":
                    lblLname2.Text = string.Format(lblLname2.Text, "GUANGDONG", 10, 84);
                    lottery = EntitiesTool.GetLotteryDic()["gd11x5"];
                    break;
                case "多乐":
                    lottery = EntitiesTool.GetLotteryDic()["1m_11x5"];
                    lblLname2.Text = string.Format(lblLname2.Text, "DUOLE", lottery.BetweenMinute, lottery.ExceptOneDay);
                    break;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtLoad = EntitiesTool.GetDateTimeNow();
            tbc_3m_SelectedIndexChanged(null, null);
            cboDW.SelectedIndex = 0;
            dgvHistory.AutoGenerateColumns = false;
            dgvBet.AutoGenerateColumns = false;
            dgvHistory.DataSource = LotteryOpenInfoDAL.LastOpen_Count(20, lottery.Id).Select(n => new { OpenNo = n.Expect, OpenNum = n.OpenCode }).ToList();

            lblMoney.Text = account.AccountBalance + "元";
            lblName.Text = account.AccountName;

            nextOpen = LotteryOpenOffcialInfoDAL.NextOpenNo(lottery.Id);
            lastOpen = LotteryOpenInfoDAL.LastOpenNo(lottery.Id);
            showOpenInfo();
            timer1.Start();
        }

        /// <summary>
        /// 下注面板点击触发委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_Click(object sender, EventArgs e)
        {
            ChoiceLpc = ((Label)sender).Parent.Parent.Parent as LotteryChoiceNoControl;
            calculate();
        }
        #region tbc事件:当玩法改变时
        private void tbcPlay_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcPlay.SelectedIndex)
            {
                case 0:
                    tbc_3m_SelectedIndexChanged(null, null);
                    break;
                case 1://二码
                    tbc_2m_SelectedIndexChanged(null, null);
                    break;
                case 2://不定位
                    if (getChoiceTabPage(tbc_bdw))
                    {
                        string[] s1 = { "前三位,2,true," };
                        addLpc(s1);
                    }
                    break;
                case 3://定位胆
                    if (getChoiceTabPage(tbc_dwd))
                    {
                        string[] s1 = { "第一位,2,true,", "第二位,2,true,", "第三位,2,true," };
                        addLpc(s1);
                    }
                    break;
                case 4://趣味型
                    tbc_qwx_SelectedIndexChanged(null, null);
                    break;
                case 5://任选复式
                    tbc_rxfs_SelectedIndexChanged(null, null);
                    break;
                case 6://任选单式
                    tbc_rxds_SelectedIndexChanged(null, null);
                    break;
                case 7://任选胆拖
                    tbc_rxdt_SelectedIndexChanged(null, null);
                    break;
            }
        }
        private void tbc_3m_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage(tbc_3m))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "前三直选复式":
                        string[] s1 = { "第一位,2,true,", "第二位,2,true,", "第三位,2,true," };
                        addLpc(s1);
                        break;
                    case "前三直选单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "前三组选复式":
                        string[] s2 = { "组选,2,true," };
                        addLpc(s2);
                        break;
                    case "前三组选单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "前三组选胆拖":
                        string[] s3 = { "胆码,2,false,2", "拖码,2,true," };
                        addLpc(s3);
                        break;
                }
            }
        }
        private void tbc_2m_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage(tbc_2m))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "前二直选复式":
                        string[] s1 = { "第一位,2,true,", "第二位,2,true," };
                        addLpc(s1);
                        break;
                    case "前二直选单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "前二组选复式":
                        string[] s2 = { "组选,2,true," };
                        addLpc(s2);
                        break;
                    case "前二组选单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "前二组选胆拖":
                        string[] s3 = { "胆码,2,false,1", "拖码,2,true," };
                        addLpc(s3);
                        break;
                }
            }

        }
        private void tbc_qwx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage(tbc_qwx))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "趣味定_单双":
                        string[] s1 = { "定单双,3,false," };
                        addLpc(s1);
                        break;
                    case "趣味猜_中位":
                        string[] s2 = { "猜中位,4,true," };
                        addLpc(s2);
                        break;
                }
            }
        }
        private void tbc_rxfs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage(tbc_rxfs))
            {
                string[] s1 = { ChoiceTabPage.Text.Substring(1) + ",2,true," };
                addLpc(s1);
            }
        }
        private void tbc_rxds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage(tbc_rxds))
            {
                addLpc2(ChoiceTabPage.Text);
            }
        }
        private void tbc_rxdt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage(tbc_rxdt))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "任选二中二":
                        string[] s1 = { "胆码,2,false,1", "拖码,2,true," };
                        addLpc(s1);
                        break;
                    case "任选三中三":
                        string[] s2 = { "胆码,2,false,2", "拖码,2,true," };
                        addLpc(s2);
                        break;
                    case "任选四中四":
                        string[] s3 = { "胆码,2,false,3", "拖码,2,true," };
                        addLpc(s3);
                        break;
                    case "任选五中五":
                        string[] s4 = { "胆码,2,false,4", "拖码,2,true," };
                        addLpc(s4);
                        break;
                    case "任选六中五":
                        string[] s5 = { "胆码,2,false,5", "拖码,2,true," };
                        addLpc(s5);
                        break;
                    case "任选七中五":
                        string[] s6 = { "胆码,2,false,6", "拖码,2,true," };
                        addLpc(s6);
                        break;
                    case "任选八中五":
                        string[] s7 = { "胆码,2,false,7", "拖码,2,true," };
                        addLpc(s7);
                        break;
                }

            }
        }
        #endregion
        /// <summary>
        /// 刷新注数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            LotteryInptuNoControl tb = null;
            foreach (var item in ChoiceTabPage.Controls)
            {
                if (item.GetType() == typeof(LotteryInptuNoControl))
                {
                    tb = (LotteryInptuNoControl)item;
                    break;
                }
            }
            if (tb != null)
            {
                var betStr = tb.GetBetNo();
                var bet = betStr == "" ? 0 : betStr.Split('|').Length;
                lblTotal.Tag = bet + " " + ChoiceTabPage.Parent.Tag + ChoiceTabPage.Text;
                lblTotal.Text = BetCalculateTool.GetTotalMoney(bet, (int)nudBS.Value, cboDW.SelectedIndex);
                MessageBox.Show("自动剔除不符合规范号码");
            }
            else
            {
                calculate();
            }
            #region 下注
            if (lblTotal.Tag==null) 
            {
                return;
            }
            var sp = lblTotal.Tag.ToString().Split(' ');
            if (sp[0] == "0")
            {
                return;
            }
            var lp = LotteryOpenTool_11x5.LpList().FirstOrDefault(n => n.LotteryPlayName == sp[1]);
            BetInfo b = new BetInfo
            {
                BetPlayTypeCode = lp.BetPlayTypeCode,
                BetTimes = Convert.ToInt32(nudBS.Value),
                BetUnit = Convert.ToInt32(sp[0]),
                BetMoney = Convert.ToDecimal(lblTotal.Text.Substring(lblTotal.Text.IndexOf("￥") + 1, lblTotal.Text.IndexOf("元") - lblTotal.Text.IndexOf("￥") - 1)),
                AccountId = account.Id,
                CreateTime = EntitiesTool.GetDateTimeNow(),
                //LotteryOpenId = nextOpen.Id,
                ResultType = (int)Enum_ResultType.Wait,
                GetBackPercent =  account.AgentPercent11X5,
                IsGetBackPercent = cboFandian.SelectedIndex != 0,
            };
            if (sp[1].Contains("趣味定_"))
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in txtBetNo.Text.Split(' '))
                {
                    sb.Append(' ' + item[0].ToString());
                }
                b.BetNum = sb.ToString().Trim();
            }
            else
            {
                b.BetNum = txtBetNo.Text;
            }

            b.MaxBackMoney = (b.IsGetBackPercent?AgentCalculateTool.GetAgentBackMoney_11x5(lp.PayBack, account.AgentPercent11X5):lp.PayBack ) * (b.BetMoney / b.BetUnit / 2);//根据是否要返点产生中奖金额
            if (string.IsNullOrEmpty(b.BetNum)) 
            {
                return;
            }
            wBetList.Add(b);
            #endregion
            var row = dgvwBet.Rows[dgvwBet.Rows.Add()];
            row.Cells[0].Value = sp[1];
            row.Cells[1].Value = b.BetNum;
            row.Cells[2].Value = b.BetUnit;
            row.Cells[3].Value = b.BetTimes;
            row.Cells[4].Value = b.BetMoney;
            row.Cells[5].Value = "X";
        }
        List<BetInfo> wBetList = new List<BetInfo>();

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtOne = dtOne.Add(-_1s);
            if (dtOne.TotalSeconds <= (lottery.IsPrivate ? 2 : 60))
            {
                lblKJ.Text = "截止投注，准备开奖";
                lblKJ.Visible = true;
                btnAddBet.Enabled = false;
            }
            if (dtOne.TotalSeconds <= 0)
            {
                lblKJ.Text = "正在开奖，请稍等";
                nextOpen = LotteryOpenOffcialInfoDAL.NextOpenNo(lottery.Id);
                if (nextOpen == null)
                {
                    dtOne = _1s;
                    return;
                }
                else 
                {
                    gbLotteryTime.Text = string.Format("距离{0}期开奖：", nextOpen.Expect);
                    var s = (nextOpen.ScheduleOpenTime - EntitiesTool.GetDateTimeNow()).TotalSeconds;
                    dtOne = new TimeSpan(TimeSpan.TicksPerSecond * Convert.ToInt32(s));
                    btnAddBet.Enabled = true;

                }
                var last = LotteryOpenInfoDAL.LastOpenNo(lottery.Id);//如果下一期有了，上期才会刷新
                if (last.Id == lastOpen.Id)//每秒获取开奖信息
                {
                    dtOne = _1s;
                    return;
                }
                else 
                {
                    lastOpen = last;
                    showOpenInfo();
                }
                //重置计时器
                //nextOpen = LotteryOpenDAL.NextOpenNo();

                //if (jix_test)
                //{
                //    btnAddBet_Click(null, null);
                //}
            }
            #region 获取返奖结果
            if (dtOne.TotalSeconds % 5 == 0 && account != null)
            {
                if (lblKJ.Visible == true && btnAddBet.Enabled == true)
                {
                    lastOpen = LotteryOpenInfoDAL.LastOpenNo(lottery.Id);
                    if (lastOpen != null && !string.IsNullOrEmpty(lastOpen.OpenCode))
                    {
                        var nList = lastOpen.OpenCode.Split(',');
                        lblLNo1.Text = MyTool.AddZeroStr(nList[0], 2);
                        lblLNo2.Text = MyTool.AddZeroStr(nList[1], 2);
                        lblLNo3.Text = MyTool.AddZeroStr(nList[2], 2);
                        lblLNo4.Text = MyTool.AddZeroStr(nList[3], 2);
                        lblLNo5.Text = MyTool.AddZeroStr(nList[4], 2);
                        gbLotteryInfo.Text = string.Format("第{0}期 开奖号码", lastOpen.Expect);
                        lblKJ.Visible = false;
                        dgvHistory.DataSource = LotteryOpenInfoDAL.LastOpen_Count(20, lottery.Id).Select(n => new { OpenNo = n.Expect, OpenNum = n.OpenCode }).ToList();
                    }
                }
                dgvBet.DataSource =AccountDAL.GetBetHistory(account.Id, lottery, dtLoad) ;
                account = AccountDAL.GetAccount(account.Id);
                lblMoney.Text = account.AccountBalance + "元";
            }
            #endregion
            lblHours.Text = MyTool.AddZeroStr(dtOne.Hours, 2);
            lblMin.Text = MyTool.AddZeroStr(dtOne.Minutes, 2);
            lblSec.Text = MyTool.AddZeroStr(dtOne.Seconds, 2);
        }
        private void btnAddBet_Click(object sender, EventArgs e)
        {
            if ((dtOne.TotalSeconds > 1 || jix_test) && wBetList.Count > 0)
            {
                //bList.Clear();
                var sp = lblTotal.Tag.ToString().Split(' ');
                if (sp[0] == "0")
                {
                    return;
                }
                account = AccountDAL.GetAccount(account.Id);
                if (account.AccountBalance < wBetList.Sum(n => n.BetMoney))
                {
                    lblMoney.Text = account.AccountBalance + "元";
                    MessageBox.Show("投注金额大于账户余额");
                    return;
                }
                #region 下注，数据更改
                var lp = LotteryOpenTool_11x5.LpList().FirstOrDefault(n => n.LotteryPlayName == sp[1]);
                wBetList.ForEach(n => n.LotteryOpenId = nextOpen.Id);
                //下注&扣款
                account = AccountDAL.BalanceChange(account.Id, wBetList);
                #endregion
                dgvBet.DataSource = AccountDAL.GetBetHistory(account.Id, lottery, dtLoad);
                wBetList.Clear();
                dgvwBet.Rows.Clear();
                MessageBox.Show("投注成功");
            }
            if (!jix_test)
            {
                txtBetNo.Text = "";
            }
            lblMoney.Text = account.AccountBalance + "元";
        }

        #region 私有方法
        void bindCbofandian()
        {
            if (account != null)
            {
                var code = LotteryOpenTool_11x5.LpList().FirstOrDefault(n => n.LotteryPlayName == ChoiceTabPage.Parent.Tag + ChoiceTabPage.Text).BetPlayTypeCode;
                cboFandian.DataSource = AccountDAL.GetAgentBackMoneyByCode(code, account.AgentPercent11X5,lottery.LotteryType);
                if (ChoiceTabPage.Text.Contains("趣味"))
                {
                    cboFandian.Visible = false;
                    cboFandian.SelectedIndex = 1;
                }
                else
                {
                    cboFandian.Visible = true;
                    cboFandian.SelectedIndex = 0;
                }
            }
        }
        /// <summary>
        /// 已创建tabpage
        /// </summary>
        List<string> lpList = new List<string>();
        /// <summary>
        /// 选号集合(文本)
        /// </summary>
        List<List<string>> tList = new List<List<string>>();
        /// <summary>
        /// 选号集合(label)
        /// </summary>
        List<List<Label>> tListLabel = new List<List<Label>>();
        /// <summary>
        /// 计算注数和金额
        /// </summary>
        void calculate()
        {
            tListLabel.Clear();
            tList.Clear();
            List<bool> dwd = new List<bool>(); ;
            foreach (var item in ChoiceTabPage.Controls)
            {
                var lc = item as LotteryChoiceNoControl;
                dwd.Add(lc.ChoiceList.Count != 0);
                if (lc != null && lc.ChoiceList.Count > 0)
                {
                    tList.Add(lc.ChoiceList);
                    tListLabel.Add(lc.Choicelbl);

                }
                else
                {
                    if (ChoiceTabPage.Text != "定位胆")
                    {
                        lblTotal.Text = lblTotalTxt;
                        txtBetNo.Text = "";
                        return;
                    }
                }
            }
            if (tList.Count == 0)
            {
                lblTotal.Text = lblTotalTxt;
                txtBetNo.Text = "";
                return;
            }
            var bet = 0;
            switch (ChoiceTabPage.Parent.Tag + ChoiceTabPage.Text)
            {
                case "前三直选复式":
                case "前二直选复式":
                    bet = BetCalculateTool.CalculateNoRepeatBet(tList);
                    break;
                case "前三直选单式":
                    break;
                case "前三组选复式":
                    bet = MyTool.CalculateCombination(3, tList[0].Count);
                    break;
                case "前三组选单式":
                    break;
                case "前三组选胆拖":
                    bet = getDT(3); ;
                    break;
                case "前二组选复式":
                    bet = MyTool.CalculateCombination(2, tList[0].Count);
                    break;
                case "前二组选胆拖":
                    bet = getDT(2); ;
                    break;
                case "不定位":
                case "定位胆":
                case "趣味定_单双":
                case "趣味猜_中位":
                    bet = BetCalculateTool.CalculateN(tList);
                    break;
                case "胆拖任选二中二":
                    bet = getDT(2);
                    break;
                case "胆拖任选三中三":
                    bet = getDT(3);
                    break;
                case "胆拖任选四中四":
                    bet = getDT(4);
                    break;
                case "胆拖任选五中五":
                    bet = getDT(5);
                    break;
                case "胆拖任选六中五":
                    bet = getDT(6);
                    break;
                case "胆拖任选七中五":
                    bet = getDT(7);
                    break;
                case "胆拖任选八中五":
                    bet = getDT(8);
                    break;
                case "任选一中一":
                    bet = MyTool.CalculateCombination(1, tList[0].Count);
                    break;
                case "任选二中二":
                    bet = MyTool.CalculateCombination(2, tList[0].Count);
                    break;
                case "任选三中三":
                    bet = MyTool.CalculateCombination(3, tList[0].Count);
                    break;
                case "任选四中四":
                    bet = MyTool.CalculateCombination(4, tList[0].Count);
                    break;
                case "任选五中五":
                    bet = MyTool.CalculateCombination(5, tList[0].Count);
                    break;
                case "任选六中五":
                    bet = MyTool.CalculateCombination(6, tList[0].Count);
                    break;
                case "任选七中五":
                    bet = MyTool.CalculateCombination(7, tList[0].Count);
                    break;
                case "任选八中五":
                    bet = MyTool.CalculateCombination(8, tList[0].Count);
                    break;
            }
            lblTotal.Text = BetCalculateTool.GetTotalMoney(bet, (int)nudBS.Value, cboDW.SelectedIndex);
            lblTotal.Tag = bet + " " + ChoiceTabPage.Parent.Tag + ChoiceTabPage.Text;
            //在文本框显示号码
            var betNo = "";
            if (bet > 0)
            {
                if (ChoiceTabPage.Text != "定位胆")
                {
                    for (int i = 0; i < tList.Count; i++)
                    {
                        foreach (var item in tList[i].OrderBy(n => n))
                        {
                            betNo += item + " ";
                        }
                        if (betNo.Length > 0)
                        {
                            betNo = betNo.Remove(betNo.Length - 1);
                        }
                        betNo += "|";
                    }
                    betNo = betNo.Remove(betNo.Length - 1);
                }
                else
                {
                    var j = 0;
                    for (int i = 0; i < dwd.Count; i++)
                    {
                        if (!dwd[i])
                        {
                            betNo += "|";
                            j++;
                            continue;
                        }
                        foreach (var item in tList[i - j].OrderBy(n => n))
                        {
                            betNo += item + " ";
                        }
                        if (betNo.Length > 0)
                        {
                            betNo = betNo.Remove(betNo.Length - 1);
                        }
                        betNo += "|";
                    }
                    betNo = betNo.Remove(betNo.Length - 1);
                }
            }
            txtBetNo.Text = betNo;
        }
        LotteryChoiceNoControl ChoiceLpc;
        /// <summary>
        /// 选X中Y胆拖算法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        int getDT(int x)
        {

            if (ChoiceLpc.lblTip.Text == "胆码")
            {
                foreach (var item in tList[0])
                {
                    tList[1].Remove(item);
                    #region 去除拖码冲突号
                    var l = tListLabel[1].FirstOrDefault(a => a.Text == item);
                    if (l != null)
                    {
                        var lpc = l.Parent.Parent.Parent as LotteryChoiceNoControl;
                        if (lpc != null)
                        {
                            lpc.ChoiceLbl(l, null);
                        }
                    }
                    #endregion
                }
            }
            else if (ChoiceLpc.lblTip.Text == "拖码")
            {
                foreach (var item in tList[1])
                {
                    tList[0].Remove(item);
                    #region 去除胆码冲突号
                    var l = tListLabel[0].FirstOrDefault(a => a.Text == item);
                    if (l != null)
                    {
                        var lpc = l.Parent.Parent.Parent as LotteryChoiceNoControl;
                        if (lpc != null)
                        {
                            lpc.ChoiceLbl(l, null);
                        }
                    }
                    #endregion
                }
            }
            if (tList[0].Count * tList[1].Count == 0)
            {
                return 0;
            }
            var n = x - tList[0].Count;
            var m = tList[1].Count;
            return MyTool.CalculateCombination(n, m);
        }
        /// <summary>
        /// 当前选中选项页
        /// </summary>
        TabPage ChoiceTabPage;
        /// <summary>
        /// 获取所选中的选项卡
        /// </summary>
        /// <param name="tabpage"></param>
        bool getChoiceTabPage(TabControl tc)
        {
            ChoiceTabPage = tc.SelectedTab;
            var Pt = ChoiceTabPage.Text + tc.Tag;
            bindCbofandian();
            if (!Pt.Contains("单式") && lpList.Contains(Pt))
            {
                calculate();
                return false;
            }
            else
            {
                txtBetNo.Text = "";
            }
            lblTotal.Text = lblTotalTxt;
            lpList.Add(Pt);
            return true;
        }
        /// <summary>
        /// 添加下注号面板
        /// </summary>
        /// <param name="str"></param>
        void addLpc(string[] str)
        {
            int l_Y = 0;
            foreach (var item in str)
            {
                var s = item.Split(',');
                LotteryChoiceNoControl lc1 = new LotteryChoiceNoControl(s[0], Convert.ToInt32(s[1]), Convert.ToBoolean(s[2]), s[3]);
                lc1.Location = new Point(5, 5 + l_Y);
                lc1.UserControlBtnClicked += new LotteryGameApp.LotteryChoiceNoControl.BtnClickHandle(UC_Click);
                ChoiceTabPage.Controls.Add(lc1);
                l_Y += lc1.Height;
            }

        }
        void addLpc2(string type)
        {
            LotteryInptuNoControl lc1 = new LotteryInptuNoControl(type);
            lc1.Location = new Point(5, 5);
            ChoiceTabPage.Controls.Add(lc1);
        }
        /// <summary>
        /// 显示开奖相关信息
        /// </summary>
        void showOpenInfo()
        {
            if (lastOpen != null && !string.IsNullOrEmpty(lastOpen.OpenCode))
            {
                var nList = lastOpen.OpenCode.Split(',');
                lblLNo1.Text = MyTool.AddZeroStr(nList[0], 2);
                lblLNo2.Text = MyTool.AddZeroStr(nList[1], 2);
                lblLNo3.Text = MyTool.AddZeroStr(nList[2], 2);
                lblLNo4.Text = MyTool.AddZeroStr(nList[3], 2);
                lblLNo5.Text = MyTool.AddZeroStr(nList[4], 2);
                gbLotteryInfo.Text = string.Format("第{0}期 开奖号码", lastOpen.Expect);
                lblKJ.Visible = false;
                dgvHistory.DataSource = LotteryOpenInfoDAL.LastOpen_Count(20, lottery.Id).Select(n => new { OpenNo = n.Expect, OpenNum = n.OpenCode }).ToList();
            }
            if (nextOpen != null)
            {
                gbLotteryTime.Text = string.Format("距离{0}期开奖：", nextOpen.Expect);
                var s = (nextOpen.ScheduleOpenTime - EntitiesTool.GetDateTimeNow()).TotalSeconds;
                dtOne = new TimeSpan(TimeSpan.TicksPerSecond * Convert.ToInt32(s));
                btnAddBet.Enabled = true;
            }
        }
        #endregion

        private void nudBS_ValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void cboDW_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculate();
        }

    }
}
