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
    public partial class FrmAgent : Form
    {
        AccountDAL AccountDAL = new AccountDAL();
        public FrmAgent()
        {
            InitializeComponent();
        }

        private void FrmAgent_Load(object sender, EventArgs e)
        {
            addCbo(cbo11x5, StaticInfo.Account.AgentPercent11X5);
            addCbo(cboDPC, StaticInfo.Account.AgentPercentDPC);
            addCbo(cboSSC, StaticInfo.Account.AgentPercentSSC);
            cboPX.SelectedIndex = 0;
            cboHYFW.SelectedIndex = 0;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();
            if (name.Length < 5)
            {
                MessageBox.Show("用户名不能小于5个字符");
                return;
            }
            if (txtPwd.Text != txtPwd1.Text)
            {
                MessageBox.Show("两次输入密码不一致");
                return;
            }
            //注册下级
            try
            {
                AccountDAL.RegChildAccount(new Accounts
                    {
                        AccountName = name,
                        AccountNickname = txtNickName.Text.Trim(),
                        AccountParentId = StaticInfo.Account.Id,
                        AccountPwd = txtPwd.Text,
                        //CreateTime = EntitiesTool.GetDateTimeNow(),
                        AccountStatus = (int)Enum_AccountStatus.Normal,
                        AgentPercent11X5 = Convert.ToDecimal(cbo11x5.Text),
                        AgentPercentDPC = Convert.ToDecimal(cboDPC.Text),
                        AgentPercentSSC = Convert.ToDecimal(cboSSC.Text),
                        AccountMoneyPwd=txtPwd.Text,
                    });
                MessageBox.Show("注册成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void addCbo(ComboBox cbo, decimal percent)
        {
            while (percent >= 0)
            {
                cbo.Items.Add(percent);
                percent = percent - new decimal(0.1);
            }
            cbo.SelectedIndex = cbo.Items.Count - 1;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            var list = AccountDAL.GetAll(StaticInfo.Account.Id, txtAccountName.Text.Trim(), txtBalance1.Text, txtBalance2.Text, txtSSCFD1.Text, txtSSCFD2.Text, cboHYFW.SelectedIndex);
            switch (cboPX.SelectedIndex)
            {
                case 0://注册时间顺序
                    list = list.OrderByDescending(n => n.CreateTime).ToList();
                    break;
                case 1://注册时间逆序
                    list = list.OrderBy(n => n.CreateTime).ToList();
                    break;
                case 2://余额从大到小
                    list = list.OrderByDescending(n => n.AccountBalance).ToList();
                    break;
                case 3://余额从小到大
                    list = list.OrderBy(n => n.AccountBalance).ToList();
                    break;
                case 4://登录次数从大到小
                    list = list.OrderByDescending(n => n.LoginCount).ToList();
                    break;
                case 5://返点从大到小
                    list = list.OrderByDescending(n => n.AgentPercentSSC).ToList();
                    break;
            }
            dgvInfo.Rows.Clear();
            foreach (var item in list)
            {
                var row=dgvInfo.Rows[dgvInfo.Rows.Add()];
                int i=0;
                row.Cells[i++].Value = item.AccountName;
                row.Cells[i++].Value = item.AccountBalance;
                row.Cells[i++].Value = item.AgentPercentSSC;
                row.Cells[i++].Value = item.CreateTime;
                row.Cells[i++].Value = item.LastLogin;
                row.Cells[i++].Value = item.LoginCount;
                row.Cells[i++].Value = item.AccountParentId;
                row.Cells[i++].Value = item.AccountStatus;
                row.Cells[i++].Value = "编辑,投注";
            }
        }
    }
}
