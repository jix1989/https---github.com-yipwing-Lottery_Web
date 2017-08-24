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
    public partial class FrmMyAccount : Form
    {
        AccountDAL AccountDAL = new AccountDAL();
        public FrmMyAccount()
        {
            InitializeComponent();
        }

        private void FrmMyAccount_Load(object sender, EventArgs e)
        {
            dgvBankCard.AutoGenerateColumns = false;
            tabControl1_SelectedIndexChanged(null, null);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var account = AccountDAL.GetAccount(StaticInfo.Account.Id);
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    lbl11x5.Text = account.AgentPercent11X5 + "%";
                    lblBalance.Text = account.AccountBalance + "元";
                    lblCT.Text = account.CreateTime.ToString("yyyy-MM-dd");
                    lbldpc.Text = account.AgentPercentDPC + "%";
                    lblName.Text = account.AccountName;
                    lblNickName.Text = account.AccountNickname;
                    lblssc.Text = account.AgentPercentSSC + "%";
                    break;
                case 1:
                    dgvBankCard.DataSource = AccountDAL.GetBankCard(StaticInfo.Account.Id);
                    btnBindCard.Visible = !account.BankCardLockStatus;
                    btnLockCard.Visible = !account.BankCardLockStatus;
                    lblTip.Text = string.Format(lblTip.Text, dgvBankCard.RowCount);
                    break;
                case 2:
                    txtNickName.Text = account.AccountNickname;
                    break;
            }
        }
        private void binBindCard_Click(object sender, EventArgs e)
        {
            if (AccountDAL.GetBankCard(StaticInfo.Account.Id).Count >= 5)
            {
                MessageBox.Show("当前已绑定五张银行卡,无法再添加");
                return;
            }
            FrmAddBankCard frm = new FrmAddBankCard();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvBankCard.DataSource = AccountDAL.GetBankCard(StaticInfo.Account.Id);
            }
        }

        private void btnLockCard_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认：是否【锁定银行卡】，锁定之后将不能再添加提款银行卡?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                AccountDAL.LockBankCard(StaticInfo.Account.Id);
                MessageBox.Show("锁定成功！");
                tabControl1_SelectedIndexChanged(null, null);
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (AccountDAL.EditNickName(StaticInfo.Account.Id, txtNickName.Text.Trim()))
            {
                MessageBox.Show("昵称修改成功");
                this.TopLevelControl.Text = string.Format("欢迎您，{0}", txtNickName.Text.Trim());
            }
            else 
            {
                MessageBox.Show("昵称修改失败");
            }
        }
        /// <summary>
        /// 修改资金密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtNewMoneyPwd1.Text != txtNewMoneyPwd2.Text)
            {
                MessageBox.Show("两次新资金密码不一致");
                return;
            }
            if (AccountDAL.EditMoneyPwd(StaticInfo.Account.Id, txtOldMoneyPwd.Text, txtNewMoneyPwd1.Text))
            {
                MessageBox.Show("资金密码修改成功!");
                txtNewMoneyPwd1.Text = "";
                txtNewMoneyPwd2.Text = "";
                txtOldMoneyPwd.Text = "";
            }
            else
            {
                MessageBox.Show("旧资金密码有误，修改失败");
            }
        }
        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtNewLoginPwd1.Text != txtNewLoginPwd2.Text)
            {
                MessageBox.Show("两次新登录密码不一致");
                return;
            }
            if (AccountDAL.EditLoginPwd(StaticInfo.Account.Id, txtOldLoginPwd.Text, txtNewLoginPwd1.Text))
            {
                MessageBox.Show("登录密码修改成功,请重新登录");
                Application.Restart();
            }
            else 
            {
                MessageBox.Show("旧登录密码有误，修改失败");
            }
        }

        private void btnQuery1_Click(object sender, EventArgs e)
        {
            tabControl1_SelectedIndexChanged(null, null);
        }


    }
}
