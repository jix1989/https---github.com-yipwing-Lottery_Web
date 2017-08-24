using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LotteryModel;
namespace LotteryGameApp
{
    public partial class FrmBetInfo : Form
    {
        LotteryBetInfoDAL LotteryBetInfoDAL = new LotteryBetInfoDAL();
        int betInfoId;
        public FrmBetInfo(int betInfoId)
        {
            InitializeComponent();
            this.betInfoId = betInfoId;
        }

        private void FrmBetInfo_Load(object sender, EventArgs e)
        {
            var info = LotteryBetInfoDAL.GetBetInfoById(betInfoId);
            lblId.Text = info.Id.ToString();
            lblName.Text = info.Accounts.AccountName;
            lblOpenNo.Text = info.LotteryOpenInfo.Expect;
            lblBackMoney.Text = "￥"+info.BackMoney;
            lblBetMoney.Text = "￥"+info.BetMoney;
            lblbetTime.Text = info.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
            lblBetTimes.Text = info.BetTimes+"倍";
            lblBetUnit.Text = info.BetUnit+"注";
            lblOpenNum.Text = info.LotteryOpenInfo.OpenCode;
            lblPercent.Text = info.GetBackPercent.ToString();
            lblStatus.Text = EnumTool.GetBetResultType(info.ResultType);
            lblText.Text = string.Format("[{0}]{1}",MyTool.GetLotteryPlayList(info.LotteryOpenInfo.Lotterys.LotteryType)[info.BetPlayTypeCode-1].LotteryPlayName , info.BetNum.Length > 17 ? info.BetNum.Substring(0, 17) : info.BetNum);
            lblWinUnit.Text = info.WinUnit+"注";
            txtNum.Text = info.BetNum;
            lblGameName.Text = info.LotteryOpenInfo.Lotterys.LotteryName;
        }

    }
}
