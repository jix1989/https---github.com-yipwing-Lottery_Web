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
    public partial class FrmRechargeWithdraw : Form
    {
        AccountDAL AccountDAL = new AccountDAL();
        public FrmRechargeWithdraw()
        {
            InitializeComponent();
        }

        private void btnRecharge_Click(object sender, EventArgs e)
        {
            var type="";
            var orderNo="";
            if(rbtn1.Checked)
            {
                type=rbtn1.Text;
                orderNo="WXCZ"+DateTime.Now.Ticks.ToString().Substring(0,10);
            }
            else if (rbtn2.Checked)
            {
                type = rbtn2.Text;
                orderNo = "ZXZF" + DateTime.Now.Ticks.ToString().Substring(0, 10);
            }
            else 
            {
                type = rbtn3.Text;
                orderNo = "YHKZF" + DateTime.Now.Ticks.ToString().Substring(0, 10);
            }
            AccountDAL.Recharge(StaticInfo.Account.Id, type, nudRechargeMoney.Value, orderNo);
            MessageBox.Show("充值成功！");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex==2)
            {
                var count = AccountDAL.TodayWithdrawCount(StaticInfo.Account.Id);
                var account = AccountDAL.GetAccount(StaticInfo.Account.Id);
                var bankList = AccountDAL.GetBankCard(StaticInfo.Account.Id).Select(n => new CboItem 
                {
                    Id=n.No,
                    Name=n.BankName+"|银行卡尾号:"+n.CardNo.Substring(n.CardNo.Length-4),
                }).ToList();
                if(count>=6)
                {
                    btnWithdraw.Enabled = false;
                }
                lblTip.Text = string.Format(lblTip.Text, count);
                lblCanWithdraw.Text = account.AccountBalance + " RMB";
                BankCardTool.bindCbo(cboBank, bankList);
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMoneyPwd.Text))
            {
                MessageBox.Show("请输入资金密码！");
                return;
            }
            var account = AccountDAL.GetAccount(StaticInfo.Account.Id);
            if (nudWithdrawMoney.Value > account.AccountBalance || nudWithdrawMoney.Value > 49999 || nudWithdrawMoney.Value<100)
            {
                MessageBox.Show("提现金额超出范围！");
                return;
            }
            if(account.AccountMoneyPwd!=txtMoneyPwd.Text)
            {
                MessageBox.Show("资金密码错误！");
                return;
            }
            //AccountDAL.Withdraw(StaticInfo.Account.Id, nudWithdrawMoney.Value, "TX" + DateTime.Now.Ticks.ToString().Substring(0, 10), (int)cboBank.SelectedValue);
            MessageBox.Show("提现成功！");
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void FrmRechargeWithdraw_Load(object sender, EventArgs e)
        {
            dgvRechargeInfo.AutoGenerateColumns = false;
            dgvWithdraw.AutoGenerateColumns = false;
        }

        private void btnRechargeQuery_Click(object sender, EventArgs e)
        {
            dgvRechargeInfo.DataSource = AccountDAL.GetAccountRechargeByDate(StaticInfo.Account.Id, dtRStart.Value, dtREnd.Value);
        }

        private void btnWithdrawQuery_Click(object sender, EventArgs e)
        {
            dgvWithdraw.DataSource = AccountDAL.GetAccountWithdrawByDate(StaticInfo.Account.Id, dtWStart.Value, dtWEnd.Value);
        }
    }
}
