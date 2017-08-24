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

namespace LotteryOpenAPP
{
    public partial class FrmMainNew : Form
    {
        Lotterys Lottery;
        //LotteryOpenDAL LotteryOpenDAL = new LotteryOpenDAL();
        //LotteryOpenPrivateInfoDAL LotteryOpenPrivateInfoDAL = new LotteryOpenPrivateInfoDAL();
        LotteryOpenInfoDAL LotteryOpenInfoDAL = new LotteryOpenInfoDAL();
        LotteryOpenOffcialInfoDAL LotteryOpenOffcialInfoDAL = new LotteryOpenOffcialInfoDAL();
        LotteryOffcialSchedule NextExcept;
        LotteryOpenInfo LastExcept;
        TimeSpan tsRemainderTime;
        bool beginGetLast;
        LotteryOffcialSchedule openNext;
        TimeSpan _1s = new TimeSpan(TimeSpan.TicksPerSecond);
        public FrmMainNew()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dgvLottery.SelectedRows.Count>0)
            {
                lblLNo.Text = "*,*,*,*,*";
                Lottery = EntitiesTool.GetLotteryDic()[dgvLottery.SelectedRows[0].Cells["LotteryCode"].Value.ToString()];
                LotteryOpenOffcialInfoDAL.InitialTodayInfo(Lottery);
                NextExcept = LotteryOpenOffcialInfoDAL.NextOpenNo(Lottery.Id);
                gbLotteryInfo.Text = string.Format("{0} 第XXX期 开奖号码", Lottery.LotteryName);
                if (NextExcept!=null)
                {
                    tsRemainderTime = NextExcept.ScheduleOpenTime - EntitiesTool.GetDateTimeNow();
                    gbLotteryTime.Text = string.Format("距离{0}期开奖",NextExcept.Expect);
                    lblYKJH.Text = "预开奖号：" + NextExcept.ScheduleOpenCode;
                    LastExcept = LotteryOpenInfoDAL.LastOpenNo(Lottery.Id);
                    if(LastExcept!=null)
                    {
                        gbLotteryInfo.Text = string.Format("{0} 第{1}期 开奖号码", Lottery.LotteryName,LastExcept.Expect);
                        lblLNo.Text = LastExcept.OpenCode;
                    }
                    btnStart.Enabled = false; 
                }
            }
        }

        private void FrmMainNew_Load(object sender, EventArgs e)
        {
            dgvLottery.DataSource = EntitiesTool.GetLotteryDic().Where(n=>n.Value.IsPrivate&&n.Value.ExceptOneDay.HasValue).Select(n => new { n.Value.LotteryName,n.Value.LotteryCode}).ToList();
        }
        
        private void tm1s_Tick(object sender, EventArgs e)
        {
            lblRemainderTime.Text = getRemainderTime();
            tsRemainderTime=tsRemainderTime.Add(-_1s);
            if(tsRemainderTime.TotalSeconds<=0)
            {
                tmOpen.Start();
                openNext = new LotteryOffcialSchedule 
                {
                    Expect=NextExcept.Expect,
                    LotteryId=NextExcept.LotteryId,
                    ScheduleOpenCode=NextExcept.ScheduleOpenCode,
                };
                var next = LotteryOpenOffcialInfoDAL.NextOpenNo(Lottery.Id);
                if (next!=null&&next.Expect != NextExcept.Expect)//新一期
                {
                    NextExcept = next;
                    tsRemainderTime = NextExcept.ScheduleOpenTime - EntitiesTool.GetDateTimeNow();
                    gbLotteryTime.Text = string.Format("距离{0}期开奖", NextExcept.Expect);
                    lblYKJH.Text = "预开奖号：" + NextExcept.ScheduleOpenCode;
                    beginGetLast = true;
                }
            }
            if (beginGetLast) 
            {
                var last = LotteryOpenInfoDAL.LastOpenNo(Lottery.Id);
                if (last != null && (LastExcept==null||last.Expect != LastExcept.Expect))
                {
                    gbLotteryInfo.Text = string.Format("{0} 第{1}期 开奖号码", Lottery.LotteryName, last.Expect);
                    lblLNo.Text = last.OpenCode;
                    beginGetLast = false;
                    LastExcept = last;
                }
            }
            if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour <= 7 && DateTime.Now.Minute % 10 == 0 && DateTime.Now.Second == 0)
            {
                LotteryOpenOffcialInfoDAL.InitialTodayInfo(Lottery);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
        }

        private void btnStart_EnabledChanged(object sender, EventArgs e)
        {
            if (btnStart.Enabled == true)
            {
                tm1s.Stop();
            }
            else 
            {
                tm1s.Start();
            }
            btnStop.Enabled = !btnStart.Enabled;
            dgvLottery.Enabled = btnStart.Enabled;
        }

        string getRemainderTime() 
        {
            var sec = (int)tsRemainderTime.TotalSeconds;
            var hour = sec  / 3600;
            var minute = (sec - 3600 * hour) / 60;
            var seconde = sec - 3600 * hour - 60 * minute;
            return (hour < 10 ? "0" + hour : "" + hour) + "：" + (minute < 10 ? "0" + minute : "" + minute) + "：" + (seconde < 10 ? "0" + seconde : "" + seconde);
        }

        void OpenCode(LotteryOffcialSchedule next) 
        {
            
        }

        private void tmOpen_Tick(object sender, EventArgs e)
        {
            //#region 线程开奖
            //Thread t1 = new Thread(new ThreadStart());
            //t1.IsBackground = true;
            //t1.Start(); 
            //#endregion
            tmOpen.Stop();
            //开始开奖
            var info = new LotteryOpenInfo
            {
                Expect = openNext.Expect,
                LotteryId = openNext.LotteryId,
                OpenTime = DateTime.Now,
                OpenDate = DateTime.Now.Date,
                OpenCode = openNext.ScheduleOpenCode,
            };
            if(rbtnXZ.Checked)
            {

            }
            else if(rbtnGD.Checked)
            {
                var o = info.OpenCode.Split(',');
                if(txtNo1.Text!="")
                {
                    o[0] = txtNo1.Text;
                }
                if (txtNo2.Text != "")
                {
                    o[1] = txtNo2.Text;
                }
                if (txtNo3.Text != "")
                {
                    o[2] = txtNo3.Text;
                }
                if (txtNo4.Text != "")
                {
                    o[3] = txtNo4.Text;
                }
                if (txtNo5.Text != "")
                {
                    o[4] = txtNo5.Text;
                }
                
                info.OpenCode = string.Format("{0},{1},{2},{3},{4}", o[0], o[1], o[2], o[3], o[4]);
            }
            LotteryOpenInfoDAL.Add(info);
            LotteryOpenInfoDAL.BackWinMoney(Lottery.Id, info.Expect);
        }
        static string[] NumList11x5_Normal = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11" };
        Dictionary<string, int> NoDic = new Dictionary<string, int>();
        private void txtNo1_TextChanged(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            int No = 0;
            if(!int.TryParse(txt.Text,out No))
            {
                txt.Text = "";
            }
            switch (Lottery.LotteryType)
            {
                case "ssc":
                    if(No<0||No>9)
                    {
                        txt.Text = "";
                    }
                    break;
                case "11x5":
                    if (No < 0 || No > 11)
                    {
                        txt.Text = "";
                    }
                    //if (!NoDic.ContainsKey(txt.Name))
                    //{
                    //    if (!NoDic.ContainsValue(No))
                    //    {
                    //        NoDic.Add(txt.Name, No);
                    //    }
                    //    else
                    //    {
                    //        txt.Text = "";
                    //    }
                    //}
                    //else 
                    //{
                    //    if (!NoDic.ContainsValue(No))
                    //    {
                    //        NoDic[txt.Name]= No;
                    //    }
                    //    else
                    //    {
                    //        if (NoDic[txt.Name]!=No)
                    //        {
                    //            txt.Text = ""; 
                    //        }
                    //    }
                    //}
                    break;
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

        private void dgvLottery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Lottery = EntitiesTool.GetLotteryDic()[dgvLottery.SelectedRows[0].Cells["LotteryCode"].Value.ToString()];
        }
    }
}
