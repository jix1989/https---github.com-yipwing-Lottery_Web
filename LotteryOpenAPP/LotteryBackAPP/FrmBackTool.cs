using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LotteryModel;
using System.Threading;
namespace LotteryBackAPP
{
    public partial class FrmBackTool : Form
    {
        List<BackDgvInfo> list = new List<BackDgvInfo>();
        LotteryOpenInfoDAL LotteryOpenInfoDAL = new LotteryOpenInfoDAL();
        int totalWin = 0;
        public FrmBackTool()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = !btnStart.Enabled;
            timer1.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = !btnStart.Enabled;
            timer1.Stop();
        }
        bool flag=true;
        bool flagBack = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
                Thread t = new Thread(new ThreadStart(backStart));
                t.Start();
                t.Join();
                if (flag)
                {
                    flag = false;
                    //LotteryOpenInfoDAL.BackWinMoney_11x5();
                    //LotteryOpenInfoDAL.BackWinMoney_SSC();
                    totalWin+=LotteryOpenInfoDAL.UpdateAccountMoney();
                    flag = true;
                }
                lblTotalWin.Text = "已返奖：" + totalWin;
                //if(DateTime.Now.Second==0)
                //{
                //    if (flagBack) 
                //    {
                //        flagBack = false;
                //        LotteryOpenInfoDAL.UpdateAccountMoney();
                //        flagBack = true;
                //    }
                //}
            //}
            //catch (Exception ex)
            //{
            //    flag = true;
            //    throw ex;
            //}
        }
        void backStart() 
        {
           LotteryOpenInfoDAL.BackWinMoney(null, null);
           //totalWin+=LotteryOpenInfoDAL.BackWinMoney_11x5_pro();
        }
    }
}
