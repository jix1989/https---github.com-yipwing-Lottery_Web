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
    public partial class FrmAddBankCard : Form
    {
        bool flag = false;
        AccountDAL AccountDAL = new AccountDAL();
        public FrmAddBankCard()
        {
            InitializeComponent();
        }

        private void FrmAddBankCard_Load(object sender, EventArgs e)
        {
            BankCardTool.BindBank(cbo1);
            BankCardTool.BindProvince(cbo2);
        }

        private void cbo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BankCardTool.BindCity(cbo3, (int)cbo2.SelectedValue);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtMoneyPwd.Text != AccountDAL.GetAccount(StaticInfo.Account.Id).AccountMoneyPwd)
            {
                MessageBox.Show("资金密码输入错误！");
                return;
            }
            var name=txtName.Text.Trim();
            if(string.IsNullOrEmpty(name))
            {
                MessageBox.Show("开户名不能为空！");
                return;
            }
            if (txtCardNo.Text.Length > 19 || txtCardNo.Text.Length <16)
            {
                MessageBox.Show("银行卡号长度不正确！");
                return;
            }
            if(txtCardNo.Text!=txtCardNo2.Text)
            {
                MessageBox.Show("两次银行卡号输入不正确！");
                return;
            }
            BankCard BankCard = new BankCard 
            {
                AccountId=StaticInfo.Account.Id,
                BankName=cbo1.Text,
                CardNo=txtCardNo.Text,
                City=cbo3.Text,
                Province=cbo2.Text,
                OpenCardName=txtName.Text,
            };
            try
            {
                AccountDAL.BindBankCard(BankCard);
                flag = true;
                MessageBox.Show("绑定成功!");
                txtCardNo.Text = "";
                txtCardNo2.Text = "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FrmAddBankCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(flag)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
