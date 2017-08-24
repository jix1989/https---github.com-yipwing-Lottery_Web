using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LotteryModel;
namespace LotteryOpenAPP
{
    public partial class FrmMain : Form
    {
        LotteryOpenDAL LotteryOpenDAL = new LotteryOpenDAL();
        /// <summary>
        /// 每期间隔
        /// </summary>
        TimeSpan dtOne;
        TimeSpan _1s = new TimeSpan(TimeSpan.TicksPerSecond);
        /// <summary>
        /// 上期开奖期号
        /// </summary>
        LotteryOpen lastOpen=null;
        /// <summary>
        /// 下一期开奖号码
        /// </summary>
        LotteryOpen nextOpen=null;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = !btnStart.Enabled;
            //LotteryOpenDAL.InitialTodayInfo();
            //LotteryOpenDAL.SetNextOpenNo();
            //nextOpen = LotteryOpenDAL.NextOpenNo();
            //if (nextOpen != null)
            //{
            //    lastOpen = LotteryOpenDAL.LastOpenNo(nextOpen.Id);
            //}
            showOpenInfo();
            timer1.Start();
            
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //nextOpen = LotteryOpenDAL.NextOpenNo();
            //if (nextOpen!=null)
            //{
            //    lastOpen = LotteryOpenDAL.LastOpenNo(nextOpen.Id); 
            //}
            showOpenInfo();
        }

        /// <summary>
        /// 显示开奖相关信息
        /// </summary>
        void showOpenInfo()
        {
            if (lastOpen != null)
            {
                gbLotteryInfo.Text = string.Format("十一选五 第{0}期 开奖号码", MyTool.AddZeroStr(lastOpen.Expect,3));
            }
            if (nextOpen != null)
            {
                gbLotteryTime.Text = string.Format("距离{0}期开奖：", MyTool.AddZeroStr(nextOpen.Expect,3));
                var dtNow=EntitiesTool.GetDateTimeNow();
                if(dtNow>nextOpen.OpenTime)
                {
                   // nextOpen = LotteryOpenDAL.NextOpenNo();
                }
                dtOne = new TimeSpan(TimeSpan.TicksPerSecond* Convert.ToInt32((nextOpen.ScheduleOpenTime -dtNow).TotalSeconds));
            }
            if (lastOpen != null && nextOpen != null&&lastOpen.Id != nextOpen.Id)
            {
                var nList = lastOpen.OpenCode.Split(',');
                lblLNo1.Text = MyTool.AddZeroStr(nList[0],2);
                lblLNo2.Text = MyTool.AddZeroStr(nList[1], 2);
                lblLNo3.Text = MyTool.AddZeroStr(nList[2], 2);
                lblLNo4.Text = MyTool.AddZeroStr(nList[3], 2);
                lblLNo5.Text = MyTool.AddZeroStr(nList[4], 2);
            }
        }
        bool openflag = false;
        List<long> idList = new List<long>();
        private void timer1_Tick(object sender, EventArgs e)
        {
            dtOne = dtOne.Add(-_1s);
            lblHours.Text = MyTool.AddZeroStr(dtOne.Hours,2);
            lblMin.Text = MyTool.AddZeroStr(dtOne.Minutes,2);
            lblSec.Text = MyTool.AddZeroStr(dtOne.Seconds,2);
            if (openflag)//若开奖则进行返奖计算
            {
                openflag = false;
                //LotteryOpenDAL.BackWinMoney(lastOpen.Id);//返奖(考虑新进程？)
                idList.Add(lastOpen.Id);
                //var bList=LotteryOpenDAL.GetBetInfoById(idList);
                //var loList = LotteryOpenDAL.GetLotteryOpenById(idList);
                //var query = (from a in loList
                //             join b in bList on a.Id equals b.LotteryOpenId into t
                //             from tt in t.DefaultIfEmpty()
                //             group tt by new { a.Id, a.Expect, a.OpenNum, a.OpenTime } into g
                //             select new
                //             {
                //                 g.Key.Id,
                //                 g.Key.Expect,
                //                 g.Key.OpenNum,
                //                 g.Key.OpenTime,
                //                 TotalBackMoney =g.Sum(n =>n==null?0:n.TotalBackMoney),
                //                 TotalBetMoney = g.Sum(n => n == null ? 0 : n.TotalBetMoney),
                //                 WinMoney = g.Sum(n => n == null ? 0 : n.WinMoney)
                //             }).ToList();
                //var query = loList.Select(n => new 
                //    {
                //        n.Id,n.Expect,n.OpenNum,n.OpenTime,
                //        TotalBackMoney=bList.Where(w=>w.LotteryOpenId==n.Id).Sum(w=>w.TotalBackMoney),
                //        TotalBetMoney = bList.Where(w => w.LotteryOpenId == n.Id).Sum(w => w.TotalBetMoney),
                //        WinMoney = bList.Where(w => w.LotteryOpenId == n.Id).Sum(w => w.WinMoney),
                //    }).ToList();
                //dgvInfo.DataSource = LotteryOpenDAL.GetBetInfoById(idList);
            }
            if (dtOne.TotalSeconds == 0)
            {
               // LotteryOpenDAL.OpeningNo(nextOpen.Id, cbFixed.Checked, txtNo1.Text.Trim(), txtNo2.Text.Trim(), txtNo3.Text.Trim(), txtNo4.Text.Trim(), txtNo5.Text.Trim());//开奖
                //重置计时器
                //nextOpen = LotteryOpenDAL.NextOpenNo();
                //if (nextOpen != null)
                //{
                //    lastOpen = LotteryOpenDAL.LastOpenNo(nextOpen.Id);
                //}
                showOpenInfo();
                openflag = true;
            }
            
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = !btnStart.Enabled;
            timer1.Stop();
        }

        private void cbFixed_CheckedChanged(object sender, EventArgs e)
        {
            txtNo1.Enabled = cbFixed.Checked;
            txtNo2.Enabled = cbFixed.Checked;
            txtNo3.Enabled = cbFixed.Checked;
            txtNo4.Enabled = cbFixed.Checked;
            txtNo5.Enabled = cbFixed.Checked;
        }
    }
}
