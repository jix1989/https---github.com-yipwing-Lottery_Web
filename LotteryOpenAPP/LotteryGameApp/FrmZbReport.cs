using LotteryModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LotteryGameApp
{
    public partial class FrmZbReport : Form
    {
        AccountDAL AccountDAL = new AccountDAL();
        int accountId;
        string accountName;
        public FrmZbReport()
        {
            InitializeComponent();
            this.accountId = StaticInfo.Account.Id;
            this.accountName = StaticInfo.Account.AccountName;
        }

        private void FrmZbReport_Load(object sender, EventArgs e)
        {
            dgvInfo.AutoGenerateColumns = false;
            dgvInfo2.AutoGenerateColumns = false;
            cboType.SelectedIndex = 0;
            cboType2.SelectedIndex = 0;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dgvInfo.Rows.Clear();
            var list=AccountDAL.GetAccountBusiness(accountId,txtBetId.Text,txtBusinessId.Text,dtStart.Value.Date,dtEnd.Value.Date.AddDays(1),cboType.SelectedIndex);
            foreach (var item in list)
            {
                int i = dgvInfo.Rows.Add();
                dgvInfo.Rows[i].Cells[0].Value = item.Id;
                dgvInfo.Rows[i].Cells[1].Value = accountName;
                dgvInfo.Rows[i].Cells[2].Value = item.CreateTime.ToString("MM-dd HH:mm:ss");
                dgvInfo.Rows[i].Cells[3].Value = cboType.Items[item.BusinessTypeId];
                dgvInfo.Rows[i].Cells[4].Value = item.PayIn;
                dgvInfo.Rows[i].Cells[5].Value = item.PayOut;
                dgvInfo.Rows[i].Cells[6].Value = item.PayBefore;
                dgvInfo.Rows[i].Cells[7].Value = item.PayAfter;
                dgvInfo.Rows[i].Cells[8].Value = "查看";
                dgvInfo.Rows[i].Cells[8].Tag = item.EventId;
            }
        }

        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>-1&&e.ColumnIndex==8)
            {
                var id =Convert.ToInt32(dgvInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag);
                FrmBetInfo frm = new FrmBetInfo(id);
                frm.ShowDialog();
            }
        }
        /// <summary>
        /// 窗口快捷键定义
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // 转换快捷键到业务功能操作
            if (keyData == Keys.Enter)
            {
                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        btnQuery_Click(null, null);
                        break;
                    case 1:
                        btnQuery2_Click(null, null);
                        break;
                    case 2:
                        break;
                }
                
                return true;
            }
            // true为不能输入，false为可输入
            return false;
        }

        private void btnQuery2_Click(object sender, EventArgs e)
        {
            var list = AccountDAL.GetAccountBusiness(accountId, dtStart2.Value.Date, dtEnd2.Value.Date.AddDays(1));
            var query = list.GroupBy(n => n.Accounts.AccountName).Select(item => new
            {
                Name = item.Key,
                Recharge=item.Where(n => n.BusinessTypeId == (int)Enum_AccountBusinessType.Recharge).Sum(n => n.PayIn),
                Withdraw = item.Where(n => n.BusinessTypeId == (int)Enum_AccountBusinessType.Withdraw).Sum(n => n.PayOut),
                Bet = item.Where(n => n.BusinessTypeId == (int)Enum_AccountBusinessType.Bet).Sum(n => n.PayOut),
                BackPercent = item.Where(n => n.BusinessTypeId == (int)Enum_AccountBusinessType.BackPercent).Sum(n => n.PayIn),
                Win = item.Where(n => n.BusinessTypeId == (int)Enum_AccountBusinessType.Win).Sum(n => n.PayIn),
                Activity = item.Where(n => n.BusinessTypeId == (int)Enum_AccountBusinessType.Activity).Sum(n => n.PayIn),
            });
            switch (cboType2.SelectedIndex)
            {
                case 0:
                    query = query.OrderByDescending(n => n.Bet);
                    break;
                case 1:
                    query = query.OrderByDescending(n => n.BackPercent);
                    break;
                case 2:
                    query = query.OrderByDescending(n => n.Win);
                    break;
                case 3:
                    query = query.OrderByDescending(n => n.Activity);
                    break;
                case 4:
                    query = query.OrderByDescending(n => n.Recharge);
                    break;
                case 5:
                    query = query.OrderByDescending(n => n.Withdraw);
                    break;
            }
            dgvInfo2.Rows.Clear();
            foreach (var item in query)
            {
                var row = dgvInfo2.Rows[dgvInfo2.Rows.Add()];
                row.Cells[0].Value = item.Name;
                row.Cells[1].Value = item.Recharge;
                row.Cells[2].Value = item.Withdraw;
                row.Cells[3].Value = item.Bet;
                row.Cells[4].Value = item.BackPercent;
                row.Cells[5].Value = item.Win;
                row.Cells[6].Value = item.Activity;
                row.Cells[7].Value = item.Activity + item.Win + item.BackPercent - item.Bet;
            }
            
        }
    }
}
