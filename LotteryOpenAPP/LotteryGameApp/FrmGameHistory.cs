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
    public partial class FrmGameHistory : Form
    {
        GameDAL GameDAL = new GameDAL();
        int? Status;
        int? GameId;
        int BetId;
        public FrmGameHistory()
        {
            InitializeComponent();
            Tools.BindCbo(MyTool.GetLotteryItems(), cboGame);
            cboStatus.SelectedIndex = 0;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dgvInfo.Rows.Clear();
            if (cboStatus.SelectedIndex != 0)
            {
                switch (cboStatus.Text)
                {
                    case "等待开奖":
                        Status = 2;
                        break;
                    case "开奖中":
                        Status = 0;
                        break;
                    case "等待派彩":
                        Status = -2;
                        break;
                    case "未中奖":
                        Status = -1;
                        break;
                    case "中奖":
                        Status = 1;
                        break;
                }
            }
            if(cboGame.SelectedIndex!=0)
            {
                GameId =(int)cboGame.SelectedValue;
            }
            if(!int.TryParse(txtBetId.Text,out BetId))
            {
                BetId = 0;
            }
            var list = GameDAL.GetBetList(StaticInfo.Account.Id, dtStart.Value, dtEnd.Value, Status, GameId, BetId, cbZH.Checked);
            lblTotal.Text = string.Format("投注：{0} RMB，中奖：{1} RMB",list.Sum(n=>n.BetMoney),list.Sum(n=>n.BackMoney));
            foreach (var item in list)
            {
                var r = dgvInfo.Rows[dgvInfo.Rows.Add()];
                r.Cells[0].Value = item.Accounts.AccountName;
                r.Cells[1].Value = item.LotteryOpenInfo.Lotterys.LotteryName;
                r.Cells[2].Value = MyTool.GetLotteryPlayList(item.LotteryOpenInfo.Lotterys.LotteryType)[item.BetPlayTypeCode-1].LotteryPlayName;
                r.Cells[3].Value = item.CreateTime.ToString();
                r.Cells[4].Value = item.LotteryOpenInfo.Expect;
                r.Cells[5].Value = "否";
                r.Cells[6].Value = item.BetMoney;
                r.Cells[7].Value = item.BackMoney;
                r.Cells[8].Value = EnumTool.GetBetResultType(item.ResultType);
                r.Cells[9].Value = "查看";
                r.Cells[9].Tag = item.Id;
            }
        }

        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 9)
            {
                var id = Convert.ToInt32(dgvInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag);
                FrmBetInfo frm = new FrmBetInfo(id);
                frm.ShowDialog();
            }
        }
    }
}
