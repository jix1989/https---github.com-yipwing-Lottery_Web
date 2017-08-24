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
    public partial class FrmLogin : Form
    {
        AccountDAL AccountDAL = new AccountDAL();

        public FrmLogin()
        {
            InitializeComponent();
            this.Icon = global::LotteryGameApp.Properties.Resources.icon;
            txtName.Text = "jix007";
            txtPwd.Text = "a";
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();
            var pwd = txtPwd.Text;
            StaticInfo.Account = AccountDAL.LoginOn(name, pwd);
            if (StaticInfo.Account != null)
            {
                FrmMain frm = new FrmMain();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败");
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
                btnLogin_Click(null, null);
                return true;
            }
            // true为不能输入，false为可输入
            return false;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //decimal b=0;
            //List<int> b2=new List<int>();
            //b2.Add(1);
            //b2.Add(2);
            //b2.Add(3);
            //b2.Add(4);
            //b2.Add(5);
            //LotteryOpenTool_SSC.isWin(3,"55211 54484 12345",null,b2,b2,b2,b2,b2,b2,b2,0,0,120,out b);
            var a= LotteryOpenTool_3D.LpList();
            var b= LotteryInfo_SSC.LpList();
        }
    }
}
