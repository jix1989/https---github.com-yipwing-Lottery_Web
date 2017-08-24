using LotteryModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace LotteryOpenAPP
{
    public partial class FrmOpen1m_11x5 : Form
    {
        Lotterys Lottery = EntitiesTool.GetLotteryDic()["1m_11x5"];
        LotteryOpenDAL LotteryOpenDAL = new LotteryOpenDAL();
        LotteryOpenPrivateInfoDAL LotteryOpenPrivateInfoDAL = new LotteryOpenPrivateInfoDAL();
        /// <summary>
        /// 每期间隔
        /// </summary>
        TimeSpan dtOne;
        TimeSpan _1s = new TimeSpan(TimeSpan.TicksPerSecond);
        /// <summary>
        /// 上期开奖期号
        /// </summary>
        LotteryOpen lastOpen;
        /// <summary>
        /// 下一期开奖号码
        /// </summary>
        LotteryOpen nextOpen;
        public FrmOpen1m_11x5()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var dt = EntitiesTool.GetDateTimeNow();
            LotteryOpenPrivateInfoDAL.InitialTodayInfo(Lottery, dt);
           // LotteryOpenDAL.InitialTodayInfo(Lottery, dt.AddDays(1));
           // LotteryOpenDAL.SetNextOpenNo(Lottery.Id);
            btnStart.Enabled = false;
            btnStop.Enabled = !btnStart.Enabled;
            showOpenInfo();
            timer1.Start();
        }
        /// <summary>
        /// 显示开奖相关信息
        /// </summary>
        void showOpenInfo()
        {
            lastOpen = LotteryOpenDAL.LastOpenNo(Lottery.Id);
            if (lastOpen != null)
            {
                gbLotteryInfo.Text = string.Format("{0} 第{1}期 开奖号码", this.Text.Substring(0, this.Text.IndexOf("开奖器")), lastOpen.Expect);
                var nList = (lastOpen.OpenCode==null?lastOpen.ScheduleOpenCode:lastOpen.OpenCode).Split(',');
                lblLNo1.Text = MyTool.AddZeroStr(nList[0], 2);
                lblLNo2.Text = MyTool.AddZeroStr(nList[1], 2);
                lblLNo3.Text = MyTool.AddZeroStr(nList[2], 2);
                lblLNo4.Text = MyTool.AddZeroStr(nList[3], 2);
                lblLNo5.Text = MyTool.AddZeroStr(nList[4], 2);
                var pm = LotteryOpenDAL.GetPrizePoolMoney(Lottery.Id);
                if (pm!=null)
                {
                    lblPool.Text = pm.PoolMoney + "元"; 
                }
            }
            nextOpen = LotteryOpenDAL.NextOpenNo(Lottery.Id);
            if (nextOpen != null)
            {
                var dtNow=EntitiesTool.GetDateTimeNow();
                while (dtNow > nextOpen.OpenTime)
                {
                    nextOpen = LotteryOpenDAL.NextOpenNo(Lottery.Id);
                }
                gbLotteryTime.Text = string.Format("距离{0}期开奖：", nextOpen.Expect);
                dtOne = new TimeSpan(TimeSpan.TicksPerSecond * Convert.ToInt32((nextOpen.ScheduleOpenTime - dtNow).TotalSeconds));
                dgvInfo.Rows.Insert(0,  new DataGridViewRow());
                var row = dgvInfo.Rows[0];
                row.Cells[0].Value = nextOpen.Id;
                row.Cells[1].Value = nextOpen.Expect;
                row.Cells[2].Value = nextOpen.ScheduleOpenTime;
                row.Cells[3].Value = nextOpen.ScheduleOpenCode;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = !btnStart.Enabled;
            timer1.Stop();
        }
        bool flag = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            dtOne = dtOne.Add(-_1s);
            lblHours.Text = MyTool.AddZeroStr(dtOne.Hours, 2);
            lblMin.Text = MyTool.AddZeroStr(dtOne.Minutes, 2);
            lblSec.Text = MyTool.AddZeroStr(dtOne.Seconds, 2);
            if (flag && dtOne.TotalSeconds%3==0) 
            {
                lastOpen = LotteryOpenDAL.LastOpenNo(Lottery.Id);
                if (lastOpen != null && lastOpen.OpenCode != null)
                {
                    gbLotteryInfo.Text = string.Format("{0} 第{1}期 开奖号码", this.Text.Substring(0, this.Text.IndexOf("开奖器")), lastOpen.Expect);
                    var nList = lastOpen.OpenCode.Split(',');
                    lblLNo1.Text = MyTool.AddZeroStr(nList[0], 2);
                    lblLNo2.Text = MyTool.AddZeroStr(nList[1], 2);
                    lblLNo3.Text = MyTool.AddZeroStr(nList[2], 2);
                    lblLNo4.Text = MyTool.AddZeroStr(nList[3], 2);
                    lblLNo5.Text = MyTool.AddZeroStr(nList[4], 2);
                    var pm = LotteryOpenDAL.GetPrizePoolMoney(Lottery.Id);
                    var pi = LotteryOpenDAL.GetPrizePoolInfo(lastOpen.Id);
                    for (int i = 0; i < dgvInfo.RowCount; i++)
                    {
                        if ((long)dgvInfo.Rows[i].Cells[0].Value == lastOpen.Id)
                        {
                            dgvInfo.Rows[i].Cells[4].Value = lastOpen.OpenTime;
                            dgvInfo.Rows[i].Cells[5].Value = lastOpen.OpenCode;
                            if (pi != null)
                            {
                                dgvInfo.Rows[i].Cells[6].Value = pi.TotalBet;
                                dgvInfo.Rows[i].Cells[7].Value = pi.TotalAgenBack;
                                dgvInfo.Rows[i].Cells[8].Value = pi.TotalBack;
                                dgvInfo.Rows[i].Cells[9].Value = pi.TotalBet - pi.TotalAgenBack - pi.TotalBack;
                                if (pi.TotalBet>0)
                                {
                                    dgvInfo.Rows[i].Cells[10].Value = Math.Round((pi.TotalAgenBack + pi.TotalBack) * 100 / pi.TotalBet, 2) + "%";  
                                }
                            }
                        }
                    }
                    if (pm != null)
                    {
                        lblPool.Text = pm.PoolMoney + "元";
                    }
                    flag = false;
                }
            }
            if (dtOne.TotalSeconds == 1)
            {
                //LotteryOpenDAL.SetNextOpenNo(Lottery.Id);
                //开奖
                try
                {
                    Thread t = new Thread(new ThreadStart(open));
                    t.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            if(dtOne.TotalSeconds==0)
            {
                nextOpen = LotteryOpenDAL.NextOpenNo(Lottery.Id);
                if (nextOpen != null)
                {
                    var dtNow = EntitiesTool.GetDateTimeNow();
                    while (dtNow > nextOpen.OpenTime)
                    {
                        nextOpen = LotteryOpenDAL.NextOpenNo(Lottery.Id);
                    }
                    gbLotteryTime.Text = string.Format("距离{0}期开奖：", nextOpen.Expect);
                    dtOne = new TimeSpan(TimeSpan.TicksPerSecond * Convert.ToInt32((nextOpen.ScheduleOpenTime - dtNow).TotalSeconds));
                    dgvInfo.Rows.Insert(0, new DataGridViewRow());
                    var row = dgvInfo.Rows[0];
                    row.Cells[0].Value = nextOpen.Id;
                    row.Cells[1].Value = nextOpen.Expect;
                    row.Cells[2].Value = nextOpen.ScheduleOpenTime;
                    row.Cells[3].Value = nextOpen.ScheduleOpenCode;
                }
                flag = true;
            }
            if (DateTime.Now.Hour == 6 && DateTime.Now.Minute==0&&DateTime.Now.Second==0)
            {
                var dt = EntitiesTool.GetDateTimeNow();
                LotteryOpenPrivateInfoDAL.InitialTodayInfo(Lottery, dt.AddDays(1));
            }
            if(dtOne.TotalSeconds<0)
            {
                btnStop_Click(null, null);
            }
        }

        private void rbtnGD_CheckedChanged(object sender, EventArgs e)
        {
            txtNo1.Enabled = rbtnGD.Checked;
            txtNo2.Enabled = rbtnGD.Checked;
            txtNo3.Enabled = rbtnGD.Checked;
            txtNo4.Enabled = rbtnGD.Checked;
            txtNo5.Enabled = rbtnGD.Checked;
        }

        void open() 
        {
            LotteryOpenPrivateInfoDAL.OpeningNo(nextOpen.Id, rbtnXZ.Checked, rbtnYK.Checked, rbtnGD.Checked, txtNo1.Text.Trim(), txtNo2.Text.Trim(), txtNo3.Text.Trim(), txtNo4.Text.Trim(), txtNo5.Text.Trim());//开奖
        }
    }
}
