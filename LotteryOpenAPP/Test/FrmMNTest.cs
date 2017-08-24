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

namespace Test
{
    public partial class FrmMNTest : Form
    {
        Lotterys Lottery = EntitiesTool.GetLotteryDic()["1m_11x5"];
        AccountDAL AccountDAL = new AccountDAL();
        //LotteryOpenDAL LotteryOpenDAL = new LotteryOpenDAL();
        LotteryOpenInfoDAL LotteryOpenInfoDAL = new LotteryOpenInfoDAL();
        /// <summary>
        /// 上期开奖期号
        /// </summary>
        LotteryOpenInfo lastOpen;
        /// <summary>
        /// 下一期开奖号码
        /// </summary>
        LotteryOpenInfo nextOpen;
        public FrmMNTest()
        {
            InitializeComponent();
            dgvHistory.AutoGenerateColumns = false;
            dgvjj.AutoGenerateColumns = false;
        }
        List<Accounts> aList;
        static Random random = new Random();
        static int[] NumList11x5_Normal = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        private void Form1_Load(object sender, EventArgs e)
        {
            lastOpen = LotteryOpenInfoDAL.LastOpenNo(Lottery.Id);
            nextOpen = LotteryOpenInfoDAL.NextOpenNo(Lottery.Id);
            showOpenInfo();
            timer1.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (var account in aList.Take((int)numericUpDown1.Value))
            {
                for (int i = 0; i < LotteryOpenTool_11x5.LpList().Count; i++)
                {
                    var b = bet(nextOpen.Id, account, i + 1);//生成投注单
                    AccountDAL.BalanceChange(account.Id, b);
                }
            }
            aList = AccountDAL.LoginOnTest(txtUser.Text);
            dgvHistory.DataSource = aList;
            MessageBox.Show("投注完成");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUser.Text))
            {
                aList = AccountDAL.LoginOnTest(txtUser.Text);
                dgvHistory.DataSource = aList;
                lblAccountCount.Text = aList.Count.ToString();
            }
        }
        /// <summary>
        /// 每期间隔
        /// </summary>
        TimeSpan dtOne;
        TimeSpan _1s = new TimeSpan(TimeSpan.TicksPerSecond);
        bool flag;
        private void timer1_Tick(object sender, EventArgs e)
        {
            dtOne = dtOne.Add(-_1s);
            if (dtOne.TotalSeconds <= 2)
            {
                lblKJ.Text = "截止投注，准备开奖";
                lblKJ.Visible = true;
            }
            if (dtOne.TotalSeconds <= 0)
            {
                nextOpen = LotteryOpenInfoDAL.NextOpenNo(Lottery.Id);
                if (nextOpen == null)
                {
                    dtOne = _1s;
                    return;
                }
                var last = LotteryOpenInfoDAL.LastOpenNo(Lottery.Id);
                if (last.Id == lastOpen.Id)//每秒获取开奖信息
                {
                    dtOne = _1s;
                    return;
                }
                //重置计时器
                lastOpen = last;
                showOpenInfo();
                flag = true;
            }
            if (checkBox1.Checked && flag && dtOne.TotalSeconds == 55)//模拟投注
            {
                flag = false;
                try
                {
                    Thread t = new Thread(new ThreadStart(betStart));
                    t.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            lblHours.Text = MyTool.AddZeroStr(dtOne.Hours, 2);
            lblMin.Text = MyTool.AddZeroStr(dtOne.Minutes, 2);
            lblSec.Text = MyTool.AddZeroStr(dtOne.Seconds, 2);
        }
        
        void betStart()
        {
            try
            {
                foreach (var account in aList.Take((int)numericUpDown1.Value))
                {
                    for (int i = 0; i < LotteryOpenTool_11x5.LpList().Count; i++)
                    {
                        var b = bet(nextOpen.Id, account, i + 1);//生成投注单
                        AccountDAL.BalanceChange(account.Id, b);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
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
                gbLotteryInfo.Text = string.Format("十一选五 第{0}期 开奖号码", MyTool.AddZeroStr(lastOpen.Expect, 3));
                lblKJ.Visible = false;
            }
            if (nextOpen != null)
            {
                gbLotteryTime.Text = string.Format("距离{0}期开奖：", MyTool.AddZeroStr(nextOpen.Expect, 3));
                var s = (nextOpen.OpenTime - EntitiesTool.GetDateTimeNow()).TotalSeconds;
                dtOne = new TimeSpan(TimeSpan.TicksPerSecond * Convert.ToInt32(s));
            }
            if (!string.IsNullOrEmpty(txtUser.Text))
            {
                aList = AccountDAL.LoginOnTest(txtUser.Text);
                dgvHistory.DataSource = aList;
            }
        }
        #region 模拟
        BetInfo bet(long OpenId, Accounts account, int code)
        {
            var betInfo = new BetInfo()
            {
                AccountId = account.Id,
                LotteryOpenId = OpenId,
                ResultType = (int)Enum_ResultType.Wait,
                CreateTime = EntitiesTool.GetDateTimeNow(),
                BetNum = createNum(code),
                BetPlayTypeCode = code,
                BetTimes = 1,
                BetUnit = code == 12 ? 3 : 1,
                BetMoney = code == 12 ? 6 : 2,
                GetBackPercent = account.AgentPercent11X5,
                IsGetBackPercent = ckbFandian.Checked,
                MaxBackMoney = LotteryOpenTool_11x5.LpList()[code - 1].PrizeClass == null ? LotteryOpenTool_11x5.LpList()[code - 1].PayBack : LotteryOpenTool_11x5.LpList()[code - 1].PrizeClass.Max(n => n.Value),//根据是否要返点产生中奖金额
            };
            return betInfo;
        }

        /// <summary>
        /// 生成投注号码
        /// </summary>
        /// <param name="count">至少选号个数</param>
        /// <param name="sp"></param>
        /// <returns></returns>
        static string createNum(int count, char? sp)
        {
            var list = NumList11x5_Normal.ToList();
            StringBuilder betNum = new StringBuilder();
            if (!sp.HasValue)
            {
                var r = random.Next(0, list.Count);
                betNum.Append(MyTool.AddZeroStr(list[r], 2) + '|');
                list.RemoveAt(r);
            }
            while (list.Count != 11 - count)
            {
                var r = random.Next(0, list.Count);
                betNum.Append(MyTool.AddZeroStr(list[r], 2) + (sp.HasValue ? sp : ' '));
                list.RemoveAt(r);
            }
            return betNum.Remove(betNum.Length - 1, 1).ToString();
        }
        static string createNum(int code)
        {
            var num = "";
            switch (code)
            {
                #region 前三
                case 1://"前三直选复式"
                    num = createNum(3, '|');
                    break;
                case 2://"前三直选单式":
                case 3://"前三组选复式":
                case 4://"前三组选单式":
                    num = createNum(3, ' ');
                    break;
                case 5://"前三组选胆拖":
                    num = createNum(3, null);
                    break;
                #endregion
                #region 前二
                case 6://"前二直选复式":
                    num = createNum(2, '|');
                    break;
                case 7://"前二直选单式":
                case 8://"前二组选复式":
                case 9://"前二组选单式":
                    num = createNum(2, ' ');
                    break;
                case 10://"前二组选胆拖":
                    num = createNum(2, null);
                    break;
                #endregion
                #region 不定位，定位胆，趣味型
                case 11://"不定位"://前三位
                    num = createNum(1, ' ');
                    break;
                case 12://"定位胆"://前三位
                    num = NumList11x5_Normal[random.Next(0, NumList11x5_Normal.Length)] + "|" + NumList11x5_Normal[random.Next(0, NumList11x5_Normal.Length)] + "|" + NumList11x5_Normal[random.Next(0, NumList11x5_Normal.Length)];
                    break;
                //"趣味定_单双":
                case 13:
                    num = random.Next(0,6).ToString();
                    break;
                //"趣味猜_中位":
                case 14:
                    num = random.Next(3,10).ToString();
                    break;
                #endregion
                #region 任选X中X
                case 15://"任选一中一":
                case 16://"任选二中二":
                case 17://"任选三中三":
                case 18://"任选四中四":
                case 19://"任选五中五":
                case 20://"任选六中五":
                case 21://"任选七中五":
                case 22://"任选八中五":
                    num = createNum(code - 14, ' ');
                    break;
                #endregion
                #region 单式任选X中X
                case 23://"单式任选一中一":  
                case 24://"单式任选二中二":
                case 25://"单式任选三中三":
                case 26://"单式任选四中四":
                case 27://"单式任选五中五":
                case 28://"单式任选六中五":
                case 29://"单式任选七中五":
                case 30://"单式任选八中五":
                    num = createNum(code - 22, ' ');
                    break;
                #endregion
                #region 任选胆拖X中X
                case 31://"胆拖任选二中二":
                case 32://"胆拖任选三中三":
                case 33://"胆拖任选四中四":
                case 34://"胆拖任选五中五":
                case 35://"胆拖任选六中五":
                case 36://"胆拖任选七中五":
                case 37://"胆拖任选八中五":
                    num = createNum(code - 29, null);
                    break;
                #endregion
            }
            return num;

        }
        #endregion

        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHistory.SelectedRows.Count > 0)
            {
                var percent = Convert.ToDecimal(dgvHistory.SelectedRows[0].Cells[2].Value);
                dgvjj.DataSource = AgentCalculateTool.GetAgentBackMoney(percent);
            }
        }
    }
}
