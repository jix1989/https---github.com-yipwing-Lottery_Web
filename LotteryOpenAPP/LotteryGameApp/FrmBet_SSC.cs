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
    public partial class FrmBet_SSC : Form
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

        public FrmBet_SSC(string lname)
        {
            InitializeComponent();
            this.BackgroundImage = global::LotteryGameApp.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            switch (lname)
            {
                case "重庆":
                    lottery = EntitiesTool.GetLotteryDic()["cqssc"];
                    lblLname2.Text = string.Format(lblLname2.Text, "CHONGQING", "10/5", 120);
                    break;
                case "新疆":
                    lblLname2.Text = string.Format(lblLname2.Text, "XINJIANG", 10, 84);
                    lottery = EntitiesTool.GetLotteryDic()["xjssc"];
                    break;
                case "天津":
                    lblLname2.Text = string.Format(lblLname2.Text, "TIANJING", 10, 84);
                    lottery = EntitiesTool.GetLotteryDic()["tjssc"];
                    break;
                case "多乐":
                    lottery = EntitiesTool.GetLotteryDic()["1m_ssc"];
                    lblLname2.Text = string.Format(lblLname2.Text, "DUOLE", lottery.BetweenMinute, lottery.ExceptOneDay);
                    break;
            }
            this.Text = lottery.LotteryName;
            lblLname.Text = this.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtLoad = EntitiesTool.GetDateTimeNow();
            tbc_5x_SelectedIndexChanged(null, null);
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
            //ChoiceLpc = ((Label)sender).Parent.Parent.Parent as LotteryChoiceNoControl;
            calculate();
        }
        /// <summary>
        /// 下注面板点击触发委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_Click1(object sender, EventArgs e)
        {
            //ChoiceLpc = ((CheckBox)sender).Parent.Parent as LotteryChoiceNoControl;
            calculate();
        }
        #region tbc事件:当玩法改变时
        private void tbcPlay_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcPlay.SelectedIndex)
            {
                case 0:
                    tbc_5x_SelectedIndexChanged(tbc_5x, null);
                    break;
                case 1://四星
                    tbc_2m_SelectedIndexChanged(tbc_2m, null);
                    break;
                case 2://百家
                    tbc_bdw_SelectedIndexChanged(tbc_bdw, null);
                    break;
                case 3://后三
                    tbc_h3_SelectedIndexChanged(tbc_h3, null);
                    break;
                case 4://中三
                    tbc_z3_SelectedIndexChanged(tbc_z3, null);
                    break;
                case 5://前三
                    tbc_q3_SelectedIndexChanged(tbc_q3, null);
                    break;
                case 6://后二
                    tbc_rxds_SelectedIndexChanged(tbc_rxds, null);
                    break;
                case 7://前二
                    tbc_q2_SelectedIndexChanged(tbc_q2, null);
                    break;
                case 8://定位胆
                    tbc_dwd_SelectedIndexChanged(tbc_dwd, null);
                    break;
                case 9://不定位
                    tbc_bdw1_SelectedIndexChanged(tbc_bdw1, null);
                    break;
                case 10://大小单双
                    tbc_dxds_SelectedIndexChanged(tbc_dxds, null);
                    break;
                case 11:
                    tbc_r2_SelectedIndexChanged(tbc_r2, null);
                    break;
                case 12:
                    tbc_r3_SelectedIndexChanged(tbc_r3, null);
                    break;
                case 13:
                    tbc_r4_SelectedIndexChanged(tbc_r4, null);
                    break;
            }
        }
        private void tbc_5x_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage(tbc_5x))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "五星直选复式":
                        string[] s1 = { "万位,0,true,", "千位,0,true,", "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s1);
                        break;
                    case "五星直选单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "五星组合":
                        string[] s2 = { "万位,0,true,", "千位,0,true,", "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s2);
                        break;
                    case "组选120":
                        string[] s3 = { "组选120,0,true," };
                        addLpc(s3);
                        break;
                    case "组选60":
                        string[] s4 = { "二重号,0,true,", "单 号,0,true,", };
                        addLpc(s4);
                        break;
                    case "组选30":
                        string[] s5 = { "二重号,0,true,", "单 号,0,true,", };
                        addLpc(s5);
                        break;
                    case "组选20":
                        string[] s6 = { "三重号,0,true,", "单 号,0,true,", };
                        addLpc(s6);
                        break;
                    case "组选10":
                        string[] s7 = { "三重号,0,true,", "二重号,0,true,", };
                        addLpc(s7);
                        break;
                    case "组选5":
                        string[] s8 = { "四重号,0,true,", "单 号,0,true,", };
                        addLpc(s8);
                        break;
                    case "一帆风顺":
                        string[] s9 = { "一帆风顺,0,true," };
                        addLpc(s9);
                        break;
                    case "好事成双":
                        string[] s10 = { "好事成双,0,true," };
                        addLpc(s10);
                        break;
                    case "三星报喜":
                        string[] s11 = { "三星报喜,0,true," };
                        addLpc(s11);
                        break;
                    case "四季发财":
                        string[] s12 = { "四季发财,0,true," };
                        addLpc(s12);
                        break;
                }
            }
        }
        //四星
        private void tbc_2m_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage(tbc_2m))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "四星直选复式":
                        string[] s1 = { "千位,0,true,", "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s1);
                        break;
                    case "四星直选单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "四星组合":
                        string[] s2 = { "千位,0,true,", "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s2);
                        break;
                    case "组选24":
                        string[] s3 = { "组选24,0,true," };
                        addLpc(s3);
                        break;
                    case "组选12":
                        string[] s4 = { "二重号,0,true,", "单 号,0,true,", };
                        addLpc(s4);
                        break;
                    case "组选6":
                        string[] s5 = { "二重号,0,true," };
                        addLpc(s5);
                        break;
                    case "组选4":
                        string[] s6 = { "三重号,0,true,", "单 号,0,true,", };
                        addLpc(s6);
                        break;
                }
            }

        }
        //百家
        private void tbc_bdw_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage((TabControl)sender))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "重复号":
                        string[] s1 = { "百家,7,false," };
                        addLpc(s1);
                        break;
                    case "顺子号":
                        string[] s2 = { "百家,8,false," };
                        addLpc(s2);
                        break;
                    case "单双号":
                        string[] s3 = { "百家,3,false," };
                        addLpc(s3);
                        break;
                    case "大小号":
                        string[] s4 = { "百家,5,false," };
                        addLpc(s4);
                        break;
                }
            }
        }
        private void tbc_h3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage((TabControl)sender))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "后三直选复式":
                        string[] s1 = { "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s1);
                        break;
                    case "后三直选单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "后三组合":
                        string[] s2 = { "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s2);
                        break;
                    case "后三直选和值":
                        string[] s22 = { "和值,0,27,false," };
                        addLpc(s22);
                        break;
                    case "后三直选跨度":
                        string[] s23 = { "跨度,0,true,", };
                        addLpc(s23);
                        break;
                    case "组三复式":
                        string[] s3 = { "组三,0,true," };
                        addLpc(s3);
                        break;
                    case "组三单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "组六复式":
                        string[] s5 = { "组六,0,true," };
                        addLpc(s5);
                        break;
                    case "组六单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "混合组选":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "组选和值":
                        string[] s8 = { "和值,1,26,false," };
                        addLpc(s8);
                        break;
                    case "组选包胆":
                        string[] s9 = { "包胆,0,false,1" };
                        addLpc(s9);
                        break;
                    case "和值尾数":
                        string[] s10 = { "和值尾数,0,true," };
                        addLpc(s10);
                        break;
                    case "特殊号":
                        string[] s11 = { "特殊号,6,false," };
                        addLpc(s11);
                        break;
                }
            }
        }
        private void tbc_z3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage((TabControl)sender))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "中三直选复式":
                        string[] s1 = { "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s1);
                        break;
                    case "中三直选单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "中三组合":
                        string[] s2 = { "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s2);
                        break;
                    case "中三直选和值":
                        string[] s22 = { "和值,0,27,false," };
                        addLpc(s22);
                        break;
                    case "中三直选跨度":
                        string[] s23 = { "跨度,0,true,", };
                        addLpc(s23);
                        break;
                    case "组三复式":
                        string[] s3 = { "组三,0,true," };
                        addLpc(s3);
                        break;
                    case "组三单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "组六复式":
                        string[] s5 = { "组六,0,true," };
                        addLpc(s5);
                        break;
                    case "组六单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "混合组选":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "组选和值":
                        string[] s8 = { "和值,1,26,false," };
                        addLpc(s8);
                        break;
                    case "组选包胆":
                        string[] s9 = { "包胆,0,false,1" };
                        addLpc(s9);
                        break;
                    case "和值尾数":
                        string[] s10 = { "和值尾数,0,true," };
                        addLpc(s10);
                        break;
                    case "特殊号":
                        string[] s11 = { "特殊号,6,false," };
                        addLpc(s11);
                        break;
                }
            }
        }
        private void tbc_q3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage((TabControl)sender))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "前三直选复式":
                        string[] s1 = { "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s1);
                        break;
                    case "前三直选单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "前三组合":
                        string[] s2 = { "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s2);
                        break;
                    case "前三直选和值":
                        string[] s22 = { "和值,0,27,false," };
                        addLpc(s22);
                        break;
                    case "前三直选跨度":
                        string[] s23 = { "跨度,0,true,", };
                        addLpc(s23);
                        break;
                    case "组三复式":
                        string[] s3 = { "组三,0,true," };
                        addLpc(s3);
                        break;
                    case "组三单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "组六复式":
                        string[] s5 = { "组六,0,true," };
                        addLpc(s5);
                        break;
                    case "组六单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "混合组选":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "组选和值":
                        string[] s8 = { "和值,1,26,false," };
                        addLpc(s8);
                        break;
                    case "组选包胆":
                        string[] s9 = { "包胆,0,false,1" };
                        addLpc(s9);
                        break;
                    case "和值尾数":
                        string[] s10 = { "和值尾数,0,true," };
                        addLpc(s10);
                        break;
                    case "特殊号":
                        string[] s11 = { "特殊号,6,false," };
                        addLpc(s11);
                        break;
                }
            }
        }
        //后二
        private void tbc_rxds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage((TabControl)sender))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "后二直选复式":
                        string[] s1 = { "十位,0,true,", "个位,0,true,", };
                        addLpc(s1);
                        break;
                    case "后二直选单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "后二直选和值":
                        string[] s22 = { "和值,0,18,false," };
                        addLpc(s22);
                        break;
                    case "后二直选跨度":
                        string[] s23 = { "跨度,0,true,", };
                        addLpc(s23);
                        break;
                    case "后二组选复式":
                        string[] s3 = { "组选,0,true," };
                        addLpc(s3);
                        break;
                    case "后二组选单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "后二组选和值":
                        string[] s8 = { "和值,1,17,false," };
                        addLpc(s8);
                        break;
                    case "后二组选包胆":
                        string[] s9 = { "包胆,0,false,1" };
                        addLpc(s9);
                        break;
                }
            }
        }
        private void tbc_q2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage((TabControl)sender))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "前二直选复式":
                        string[] s1 = { "万位,0,true,", "千位,0,true,", };
                        addLpc(s1);
                        break;
                    case "前二直选单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "前二直选和值":
                        string[] s22 = { "和值,0,18,false," };
                        addLpc(s22);
                        break;
                    case "前二直选跨度":
                        string[] s23 = { "跨度,0,true,", };
                        addLpc(s23);
                        break;
                    case "前二组选复式":
                        string[] s3 = { "组选,0,true," };
                        addLpc(s3);
                        break;
                    case "前二组选单式":
                        addLpc2(ChoiceTabPage.Text);
                        break;
                    case "前二组选和值":
                        string[] s8 = { "和值,1,17,false," };
                        addLpc(s8);
                        break;
                    case "前二组选包胆":
                        string[] s9 = { "包胆,0,false,1" };
                        addLpc(s9);
                        break;
                }
            }
        }
        private void tbc_dwd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage((TabControl)sender))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "定位胆":
                        string[] s1 = { "万位,0,true,", "千位,0,true,", "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s1);
                        break;
                }
            }
        }
        private void tbc_bdw1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage((TabControl)sender))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "后三一码":
                        string[] s1 = { "不定位,0,true," };
                        addLpc(s1);
                        break;
                    case "前三一码":
                        string[] s0 = { "不定位,0,true," };
                        addLpc(s0);
                        break;
                    case "后三二码":
                        string[] s2 = { "不定位,0,true," };
                        addLpc(s2);
                        break;
                    case "前三二码":
                        string[] s22 = { "不定位,0,true," };
                        addLpc(s22);
                        break;
                    case "四星一码":
                        string[] s41 = { "不定位,0,true," };
                        addLpc(s41);
                        break;
                    case "四星二码":
                        string[] s42 = { "不定位,0,true," };
                        addLpc(s42);
                        break;
                    case "五星二码":
                        string[] s52 = { "不定位,0,true," };
                        addLpc(s52);
                        break;
                    case "五星三码":
                        string[] s53 = { "不定位,0,true," };
                        addLpc(s53);
                        break;
                }
            }
        }
        private void tbc_dxds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage((TabControl)sender))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "前二大小单双":
                        string[] s1 = { "万位,1,false,", "千位,1,false,", };
                        addLpc(s1);
                        break;
                    case "后二大小单双":
                        string[] s2 = { "十位,1,false,", "个位,1,false,", };
                        addLpc(s2);
                        break;
                    case "前三大小单双":
                        string[] s3 = { "百位,1,false,", "十位,1,false,", "个位,1,false,", };
                        addLpc(s3);
                        break;
                    case "后三大小单双":
                        string[] s4 = { "万位,1,false,", "千位,1,false,", "百位,1,false,", };
                        addLpc(s4);
                        break;
                }
            }
        }
        private void tbc_r2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage((TabControl)sender))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "任二直选复式":
                        string[] s1 = { "万位,0,true,", "千位,0,true,", "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s1);
                        break;
                    case "任二直选单式":
                        addLpc2(ChoiceTabPage.Text);
                        addLpc3(2);
                        break;
                    case "任二直选和值":
                        string[] s22 = { "和值,0,18,false," };
                        addLpc(s22);
                        addLpc3(2);
                        break;
                    case "任二组选复式":
                        string[] s3 = { "组选,0,true," };
                        addLpc(s3);
                        addLpc3(2);
                        break;
                    case "任二组选单式":
                        addLpc2(ChoiceTabPage.Text);
                        addLpc3(2);
                        break;
                    case "任二组选和值":
                        string[] s8 = { "和值,1,17,false," };
                        addLpc(s8);
                        addLpc3(2);
                        break;
                }
            }
        }
        private void tbc_r3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage((TabControl)sender))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "任三直选复式":
                        string[] s1 = { "万位,0,true,", "千位,0,true,", "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s1);
                        break;
                    case "任三直选单式":
                        addLpc2(ChoiceTabPage.Text);
                        addLpc3(3);
                        break;
                    case "任三直选和值":
                        string[] s22 = { "和值,0,27,false," };
                        addLpc(s22);
                        addLpc3(3);
                        break;
                    case "任三组三复式":
                        string[] s3 = { "组选,0,true," };
                        addLpc(s3);
                        addLpc3(3);
                        break;
                    case "任三组三单式":
                        addLpc2(ChoiceTabPage.Text);
                        addLpc3(3);
                        break;
                    case "任三组六复式":
                        string[] s4 = { "组选,0,true," };
                        addLpc(s4);
                        addLpc3(3);
                        break;
                    case "任三组六单式":
                        addLpc2(ChoiceTabPage.Text);
                        addLpc3(3);
                        break;
                    case "任三混合组选":
                        addLpc2(ChoiceTabPage.Text);
                        addLpc3(3);
                        break;
                    case "任三组选和值":
                        string[] s8 = { "和值,1,26,false," };
                        addLpc(s8);
                        addLpc3(3);
                        break;
                }
            }
        }
        private void tbc_r4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChoiceTabPage((TabControl)sender))
            {
                switch (ChoiceTabPage.Text)
                {
                    case "任四直选复式":
                        string[] s1 = { "万位,0,true,", "千位,0,true,", "百位,0,true,", "十位,0,true,", "个位,0,true,", };
                        addLpc(s1);
                        break;
                    case "任四直选单式":
                        addLpc2(ChoiceTabPage.Text);
                        addLpc3(4);
                        break;
                    case "组选24":
                        string[] s22 = { "组选24,0,true," };
                        addLpc(s22);
                        addLpc3(4);
                        break;
                    case "组选12":
                        string[] s3 = { "二重号,0,true,", "单 号,0,true,", };
                        addLpc(s3);
                        addLpc3(4);
                        break;
                    case "组选6":
                        string[] s5 = { "二重号,0,true," };
                        addLpc(s5);
                        addLpc3(4);
                        break;
                    case "组选4":
                        string[] s6 = { "三重号,0,true,", "单 号,0,true,", };
                        addLpc(s6);
                        addLpc3(4);
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
            LotteryInptuNoControl1 tb1 = null;
            foreach (var item in ChoiceTabPage.Controls)
            {
                if (item.GetType() == typeof(LotteryInptuNoControl))
                {
                    tb = (LotteryInptuNoControl)item;
                    break;
                }
                if (item.GetType() == typeof(LotteryInptuNoControl1))
                {
                    tb1 = (LotteryInptuNoControl1)item;
                    break;
                }
            }
            if (tb != null)
            {
                var betStr = tb.GetBetNo();
                var bet = betStr == "" ? 0 : betStr.Split('|').Length;
                lblTotal.Tag = bet + " " + ChoiceTabPage.Parent.Tag + ChoiceTabPage.Tag;
                lblTotal.Text = BetCalculateTool.GetTotalMoney(bet, (int)nudBS.Value, cboDW.SelectedIndex);
                MessageBox.Show("自动剔除不符合规范号码");
                tb1.txtNo.Text = betStr;
                txtBetNo.Text = betStr;
            }
            else if (tb1 != null)
            {
                var betStr = tb1.GetBetNo();
                foreach (var item in ChoiceTabPage.Controls)
                {
                    var lw = item as LotteryPositionCbk;
                    if (lw != null)
                    {
                        wzList.AddRange(lw.wzList);
                    }
                }
                var bet = betStr == "" ? 0 : betStr.Split(' ').Length;//单式注数计算(Todo)
                var p = ChoiceTabPage.Controls.Find("LotteryPositionCbk", false).FirstOrDefault() as LotteryPositionCbk;
                switch (ChoiceTabPage.Parent.Parent.Text)
                {
                    case "任选二":
                        bet = bet * MyTool.CalculateCombination(2, p.wzList.Count);
                        break;
                    case "任选三":
                        bet = bet * MyTool.CalculateCombination(3, p.wzList.Count);
                        break;
                    case "任选四":
                        bet = bet * MyTool.CalculateCombination(4, p.wzList.Count);
                        break;
                }
                lblTotal.Tag = bet + " " + ChoiceTabPage.Parent.Tag + ChoiceTabPage.Tag;
                lblTotal.Text = BetCalculateTool.GetTotalMoney(bet, (int)nudBS.Value, cboDW.SelectedIndex);
                tb1.txtNo.Text = betStr;
                txtBetNo.Text = betStr;
                MessageBox.Show("自动剔除不符合规范号码");

            }
            else
            {
                calculate();
            }
            #region 下注
            if (lblTotal.Tag == null)
            {
                return;
            }
            var sp = lblTotal.Tag.ToString().Split(' ');
            if (sp[0] == "0")
            {
                return;
            }
            var lp = LotteryInfo_SSC.LpList()[Convert.ToInt32(sp[1]) - 1];
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
                GetBackPercent = account.AgentPercentSSC,
                IsGetBackPercent = cboFandian.SelectedIndex != 0,
            };
                b.BetNum = txtBetNo.Text;
                b.MaxBackMoney = (b.IsGetBackPercent ? lp.PayBack : AgentCalculateTool.GetAgentBackMoney_SSC(lp.PayBack, account.AgentPercentSSC)) * (b.BetMoney / b.BetUnit / 2);//根据是否要返点产生中奖金额
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
            if (dtOne.TotalSeconds <= (lottery.IsPrivate ? 3 : 60))
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
                dgvBet.DataSource = AccountDAL.GetBetHistory(account.Id, lottery, dtLoad);
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
                //var lp = LotteryInfo_SSC.LpList().FirstOrDefault(n => n.LotteryPlayName == sp[1]);
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

        private void nudBS_ValueChanged(object sender, EventArgs e)
        {
            calculate();
        }

        private void cboDW_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculate();
        }

        #region 私有方法
        LotteryChoiceNoControl ChoiceLpc;
        /// 当前选中选项页
        /// </summary>
        TabPage ChoiceTabPage;
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
        /// 任选玩法位置集合
        /// </summary>
        List<int> wzList = new List<int>();
        void bindCbofandian()
        {
            if (account != null)
            {
                var code = Convert.ToInt32(ChoiceTabPage.Tag);//LotteryInfo_SSC.LpList().FirstOrDefault(n => n.LotteryPlayName == ChoiceTabPage.Parent.Tag + ChoiceTabPage.Text).BetPlayTypeCode;
                cboFandian.DataSource = AccountDAL.GetAgentBackMoneyByCode(code, account.AgentPercentSSC, lottery.LotteryType);
                if (ChoiceTabPage.Text.Contains("组合") || ChoiceTabPage.Parent.Text.Contains("百家"))
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
        /// 计算注数和金额
        /// </summary>
        void calculate()
        {
            //tListLabel.Clear();
            tList.Clear();
            wzList.Clear();
            List<bool> dwd = new List<bool>(); ;
            foreach (var item in ChoiceTabPage.Controls)
            {
                var lc = item as LotteryChoiceNoControl;
                var lw = item as LotteryPositionCbk;
                if (lc != null && lc.ChoiceList.Count > 0)
                {
                    tList.Add(lc.ChoiceList);
                    //tListLabel.Add(lc.Choicelbl);
                    dwd.Add(lc.ChoiceList.Count != 0);
                }
                else if (lw != null)
                {
                    wzList.AddRange(lw.wzList);
                }
                else
                {
                    if (ChoiceTabPage.Text != "定位胆" && !ChoiceTabPage.Text.Contains("任"))
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
            var n = tList.Count > 0 ? tList[0].Count : 0;
            var m = tList.Count > 1 ? tList[1].Count : 0;
            var x = tList.Count > 1 ? tList[1].Count(w => tList[0].Contains(w)) : 0;
            var a = tList[0].Count;
            var b = tList.Count > 1 ? tList[1].Count : 0;
            var c = tList.Count > 2 ? tList[2].Count : 0;
            var d = tList.Count > 3 ? tList[3].Count : 0;
            var e = tList.Count > 4 ? tList[4].Count : 0;
            switch (Convert.ToInt32(ChoiceTabPage.Tag))
            {
                #region 定位胆
                case 1://定位胆
                    bet = BetCalculateTool.CalculateN(tList);
                    break;
                #endregion
                #region 五星
                case 2://五星直选复式
                    bet = a * b * c * d * e;
                    break;
                case 4://五星直选组合
                    bet = a * b * c * d * e * 5;
                    break;
                case 5://五星组选120(全不同号)
                    bet = MyTool.CalculateCombination(5, tList.Sum(w => w.Count));
                    break;
                case 6://五星组选60(一对)
                    bet = (n - x) * MyTool.CalculateCombination(3, m) + x * MyTool.CalculateCombination(3, m - 1);
                    break;
                case 7://五星组选30(两对)
                    bet = (m - x) * MyTool.CalculateCombination(2, n) + x * MyTool.CalculateCombination(2, n - 1);
                    break;
                case 8://五星组选20(三条)
                    bet = (n - x) * MyTool.CalculateCombination(2, m) + x * MyTool.CalculateCombination(2, m - 1);
                    break;
                case 9://五星组选10(三带二)
                //bet = (n-x)*c(1,m)+x*C(1,m-1)
                //break;
                case 10://五星组选5(四条)
                    bet = (n - x) * MyTool.CalculateCombination(1, m) + x * MyTool.CalculateCombination(1, m - 1);
                    break;
                case 11://五星一帆风顺
                case 12://五星好事成双
                case 13://五星三星报喜
                case 14://五星四季发财
                    bet = BetCalculateTool.CalculateN(tList);
                    break;
                #endregion
                #region 四星
                case 15://四星直选复式
                    bet = a * b * c * d;
                    break;
                case 17://四星直选组合
                    bet = a * b * c * d * 4;
                    break;
                case 18://四星组选24(全不同号)
                    bet = MyTool.CalculateCombination(4, tList.Sum(w => w.Count));
                    break;
                case 19://四星组选12(一对)
                    bet = (n - x) * MyTool.CalculateCombination(2, m) + x * MyTool.CalculateCombination(2, m - 1);
                    break;
                case 20://四星组选6(两对)
                    bet = MyTool.CalculateCombination(2, tList.Sum(w => w.Count));
                    break;
                case 21://四星组选4(三条)
                    bet = (n - x) * MyTool.CalculateCombination(1, m) + x * MyTool.CalculateCombination(1, m - 1);
                    break;
                #endregion
                #region 百家
                case 22://百家重复号
                case 23://百家顺子号
                case 24://百家单双号
                case 25://百家大小号
                    bet = BetCalculateTool.CalculateN(tList);
                    break;
                #endregion
                #region 后三
                case 26://后三直选复式
                    bet = a * b * c;
                    break;
                case 28://后三直选组合
                    bet = a * b * c * 3;
                    break;
                case 29://后三直选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxhz(3, Convert.ToInt32(item));
                    }
                    break;
                case 30://后三直选跨度
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxkd(3, Convert.ToInt32(item));
                    }
                    break;
                case 31://后三组三复式
                    bet = a * (a - 1);
                    break;
                case 33://后三组六复式
                    bet = MyTool.CalculateCombination(3, a);
                    break;
                case 36://后三组选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zuxhz(3, Convert.ToInt32(item));
                    }
                    break;
                case 37://后三组选包胆
                    bet = 54;
                    break;
                case 38://后三和值尾数
                case 39://后三特殊号
                    bet = BetCalculateTool.CalculateN(tList);
                    break;
                #endregion
                #region 中三
                case 40://中三直选复式
                    bet = a * b * c;
                    break;
                case 42://中三直选组合
                    bet = a * b * c * 3;
                    break;
                case 43://中三直选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxhz(3, Convert.ToInt32(item));
                    }
                    break;
                case 44://中三直选跨度
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxkd(3, Convert.ToInt32(item));
                    }
                    break;
                case 45://中三组三复式
                    bet = a * (a - 1);
                    break;
                case 47://中三组六复式
                    bet = MyTool.CalculateCombination(3, a);
                    break;
                case 50://中三组选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zuxhz(3, Convert.ToInt32(item));
                    }
                    break;
                case 51://中三组选包胆
                    bet = 54;
                    break;
                case 52://中三和值尾数
                case 53://中三特殊号
                    bet = BetCalculateTool.CalculateN(tList);
                    break;
                #endregion
                #region 前三
                case 54://前三直选复式
                    bet = a * b * c;
                    break;
                case 56://前三直选组合
                    bet = a * b * c * 3;
                    break;
                case 57://前三直选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxhz(3, Convert.ToInt32(item));
                    }
                    break;
                case 58://前三直选跨度
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxkd(3, Convert.ToInt32(item));
                    }
                    break;
                case 59://前三组三复式
                    bet = a * (a - 1);
                    break;
                case 61://前三组六复式
                    bet = MyTool.CalculateCombination(3, a);
                    break;
                case 64://前三组选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zuxhz(3, Convert.ToInt32(item));
                    }
                    break;
                case 65://前三组选包胆
                    bet = 54;
                    break;
                case 66://前三和值尾数
                case 67://前三特殊号
                    bet = BetCalculateTool.CalculateN(tList);
                    break;
                #endregion
                #region 后二
                case 68://后二直选复式
                    bet = a * b;
                    break;
                case 69://后二直选单式

                    break;
                case 70://后二直选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxhz(2, Convert.ToInt32(item));
                    }
                    break;
                case 71://后二直选跨度
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxkd(2, Convert.ToInt32(item));
                    }
                    break;
                case 72://后二组选复式
                    bet = MyTool.CalculateCombination(2, a);
                    break;
                case 73://后二组选单式

                    break;
                case 74://后二组选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zuxhz(2, Convert.ToInt32(item));
                    }
                    break;
                case 75://后二组选包胆
                    bet = 9;
                    break;
                #endregion
                #region 前二
                case 76://前二直选复式
                    bet = a * b;
                    break;
                case 77://前二直选单式

                    break;
                case 78://前二直选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxhz(2, Convert.ToInt32(item));
                    }
                    break;
                case 79://前二直选跨度
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxkd(2, Convert.ToInt32(item));
                    }
                    break;
                case 80://前二组选复式
                    bet = MyTool.CalculateCombination(2, a);
                    break;
                case 81://前二组选单式

                    break;
                case 82://前二组选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zuxhz(2, Convert.ToInt32(item));
                    }
                    break;
                case 83://前二组选包胆
                    bet = 9;
                    break;
                #endregion
                #region 不定位
                case 84://后三一码
                case 85://前三一码
                    bet = BetCalculateTool.CalculateN(tList);
                    break;
                case 86://后三二码
                case 87://前三二码
                    bet = MyTool.CalculateCombination(2, a);
                    break;
                case 88://四星一码
                    bet = BetCalculateTool.CalculateN(tList);
                    break;
                case 89://四星二码
                case 90://五星二码
                    bet = MyTool.CalculateCombination(2, a);
                    break;
                case 91://五星三码
                    bet = MyTool.CalculateCombination(3, a);
                    break;
                #endregion
                #region 大(6)小(5)单(1)双(0)
                case 92://前二大小单双
                case 93://后二大小单双
                    bet = a * b;
                    break;
                case 94://前三大小单双
                case 95://后三大小单双
                    bet = a * b * c;
                    break;
                #endregion
                #region 任选二
                case 96://任选二直选复式
                    bet = a * (b + c + d + e) + b * (c + d + e) + c * (d + e) + d * e;
                    break;
                case 97://任选二直选单式
                    break;
                case 98://任选二直选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxhz(2, Convert.ToInt32(item));
                    }
                    bet *= MyTool.CalculateCombination(2, wzList.Count);//乘以c(2,勾选项数)
                    break;
                case 99://任选二组选复式
                    bet = MyTool.CalculateCombination(2, tList[0].Count) * MyTool.CalculateCombination(2, wzList.Count);
                    break;
                case 100://任选二组选单式

                    break;
                case 101://任选二组选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zuxhz(2, Convert.ToInt32(item));
                    }
                    bet *= MyTool.CalculateCombination(2, wzList.Count);
                    break;
                #endregion
                #region 任选三
                case 102://任选三直选复式
                    bet = a * b * (c + d + e) + a * c * (d + e) + a * d * e + b * c * (d + e) + b * d * e + c * d * e;
                    break;
                case 103://任选三直选单式
                    break;
                case 104://任选三直选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zxhz(3, Convert.ToInt32(item));
                    }
                    bet *= MyTool.CalculateCombination(3, wzList.Count);
                    break;
                case 105://任选三组三复式
                    bet = a * (a - 1) * MyTool.CalculateCombination(3, wzList.Count);
                    break;
                case 106://任选三组三单式
                    break;
                case 107://任选三组六复式
                    bet = MyTool.CalculateCombination(3, tList[0].Count) * MyTool.CalculateCombination(3, wzList.Count);
                    break;
                case 108://任选三组六单式
                    break;
                case 109://任选三混合组选
                    break;
                case 110://任选三组选和值
                    foreach (var item in tList[0])
                    {
                        bet += bet_zuxhz(3, Convert.ToInt32(item));
                    }
                    bet *= MyTool.CalculateCombination(3, wzList.Count);
                    break;
                #endregion
                #region 任选四
                case 111://任选四直选复式
                    bet = a * b * c * (d + e) + a * d * e * (b + c) + b * c * d * e;
                    break;
                case 112://任选四直选单式
                    break;
                case 113://任选四组选24
                    bet = MyTool.CalculateCombination(4, tList.Sum(w => w.Count));
                    bet *= MyTool.CalculateCombination(4, wzList.Count);
                    break;
                case 114://任选四组选12
                    bet = (n - x) * MyTool.CalculateCombination(2, m) + x * MyTool.CalculateCombination(2, m - 1);
                    bet *= MyTool.CalculateCombination(4, wzList.Count);
                    break;
                case 115://任选四组选6
                    bet = MyTool.CalculateCombination(2, tList.Sum(w => w.Count));
                    bet *= MyTool.CalculateCombination(4, wzList.Count);
                    break;
                case 116://任选四组选4
                    bet = (n - x) * MyTool.CalculateCombination(1, m) + x * MyTool.CalculateCombination(1, m - 1);
                    bet *= MyTool.CalculateCombination(4, wzList.Count);
                    break;
                #endregion
            }
            lblTotal.Text = BetCalculateTool.GetTotalMoney(bet, (int)nudBS.Value, cboDW.SelectedIndex);
            lblTotal.Tag = bet + " " + ChoiceTabPage.Parent.Tag + ChoiceTabPage.Tag;
            //在文本框显示号码
            var betNo = "";
            if (bet > 0)
            {
                if (ChoiceTabPage.Text != "定位胆")
                {
                    for (int i = 0; i < tList.Count; i++)
                    {
                        foreach (var item in tList[i].OrderBy(w => w))
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
                        foreach (var item in tList[i - j].OrderBy(w => w))
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
        /// <summary>
        /// 获取所选中的选项卡
        /// </summary>
        /// <param name="tabpage"></param>
        bool getChoiceTabPage(TabControl tc)
        {
            ChoiceTabPage = tc.SelectedTab;
            var Pt = ChoiceTabPage.Text + ChoiceTabPage.Tag;
            bindCbofandian();
            if (lpList.Contains(Pt))
            {
                calculate();
                return false;
            }
            else if (!Pt.Contains("单式"))
            {
                calculate();
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
                LotteryChoiceNoControl lc1 = s.Length == 4 ? new LotteryChoiceNoControl(s[0], Convert.ToInt32(s[1]), Convert.ToBoolean(s[2]), s[3]) : new LotteryChoiceNoControl(s[0], Convert.ToInt32(s[1]), Convert.ToInt32(s[2]), Convert.ToBoolean(s[3]), s[4]);
                lc1.Location = new Point(5, 5 + l_Y);
                lc1.UserControlBtnClicked += new LotteryGameApp.LotteryChoiceNoControl.BtnClickHandle(UC_Click);
                ChoiceTabPage.Controls.Add(lc1);
                l_Y += lc1.Height;
            }

        }
        void addLpc2(string type)
        {
            LotteryInptuNoControl1 lc1 = new LotteryInptuNoControl1(type);
            lc1.Location = new Point(5, 5);
            ChoiceTabPage.Controls.Add(lc1);
        }

        void addLpc3(int need)
        {
            LotteryPositionCbk lc1 = new LotteryPositionCbk(need);
            lc1.Location = new Point(5, 180);
            lc1.UserControlBtnClicked += new LotteryGameApp.LotteryPositionCbk.BtnClickHandle(UC_Click1);
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
                lblLNo1.Text = nList[0];
                lblLNo2.Text = nList[1];
                lblLNo3.Text = nList[2];
                lblLNo4.Text = nList[3];
                lblLNo5.Text = nList[4];
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

        int[] NumListSSC = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        /// <summary>
        /// 直选和值
        /// </summary>
        /// <returns></returns>
        int bet_zxhz(int ws, int hezhi)
        {
            int zhu = 0;
            if (ws == 3)
            {
                var query = from a in NumListSSC
                            from b in NumListSSC
                            from c in NumListSSC
                            select new { a, b, c };
                zhu = query.Count(item => item.a + item.b + item.c == hezhi);
            }
            else
            {
                var query = from a in NumListSSC
                            from b in NumListSSC
                            select new { a, b };
                zhu = query.Count(item => item.a + item.b == hezhi);
            }
            return zhu;
        }
        /// <summary>
        /// 直选跨度
        /// </summary>
        /// <returns></returns>
        int bet_zxkd(int ws, int kuazhi)
        {
            int zhu = 0;
            if (ws == 3)
            {
                var query = from a in NumListSSC
                            from b in NumListSSC
                            from c in NumListSSC
                            select new { a, b, c };
                foreach (var item in query)
                {
                    int[] l = { item.a, item.b, item.c };
                    l = l.OrderBy(n => n).ToArray();
                    if (l[2] - l[0] == kuazhi)
                    {
                        zhu++;
                    }
                }
            }
            else
            {
                var query = from a in NumListSSC
                            from b in NumListSSC
                            select new { a, b };
                zhu = query.Count(item => Math.Abs(item.a - item.b) == kuazhi);
            }
            return zhu;
        }
        int[] zuxhzArray = { 1, 2, 2, 4, 5, 6, 8, 10, 11, 13, 14, 14, 15 };
        /// <summary>
        /// 组选和值
        /// </summary>
        /// <returns></returns>
        int bet_zuxhz(int ws, int hezhi)
        {
            int zhu = 0;
            List<int> list = new List<int>();
            if (ws == 3)
            {
                if (hezhi < 14)
                {
                    zhu = zuxhzArray[hezhi - 1];
                }
                else
                {
                    zhu = zuxhzArray[27 - hezhi - 1];
                }
            }
            else
            {
                var query = from a in NumListSSC
                            from b in NumListSSC
                            where a != b
                            select new { a, b };
                zhu = query.Count(item => item.a + item.b == hezhi) / 2;
            }
            return zhu;
        }
        #endregion






    }
}
