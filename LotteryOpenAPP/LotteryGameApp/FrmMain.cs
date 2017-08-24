using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LotteryGameApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            //AppStaticInfo.InitialLtPlay();
            this.Icon = global::LotteryGameApp.Properties.Resources.icon;
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //panel3.Hide();
            //FrmLotteryMain frm = new FrmLotteryMain("cqssc");
            //frm.MdiParent = this;
            //frm.Show();
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1_Tick(null, null);
            Tools.CreateDir("Accounts", "Scheme", "OpenData");
            this.Text = string.Format("欢迎您，{0}", StaticInfo.Account.AccountNickname);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var value = NetHelper.GetPingValue();
                lblPing.Text = "当前网速：" + value + (value != null ? "ms" : "超时");
            }
            catch (Exception)
            {

            }
           
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            this.BackgroundImage = LotteryGameApp.Properties.Resources.Banner2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        private void 山东十一选五ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBet_11x5 frm = new FrmBet_11x5(((ToolStripMenuItem)sender).Text.Substring(0, 2));
            frm.MdiParent = this;
            frm.Show();
        }

        private void 多乐十一选五ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show(new FrmBet_11x5(((ToolStripMenuItem)sender).Text.Substring(0, 2)));
        }

        private void 江西十一选五ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show(new FrmBet_11x5(((ToolStripMenuItem)sender).Text.Substring(0, 2)));
        }

        private void 广东十一选五ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show(new FrmBet_11x5(((ToolStripMenuItem)sender).Text.Substring(0, 2)));
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            show(new FrmZbReport());
        }

        void show(Form frm) 
        {
            frm.Icon = global::LotteryGameApp.Properties.Resources.icon;
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            show(new FrmAgent());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            show(new FrmMyAccount());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            show(new FrmRechargeWithdraw());
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            show(new FrmGameHistory());
        }

        private void 多乐分分彩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show(new FrmBet_SSC(((ToolStripMenuItem)sender).Text.Substring(0, 2)));
        }

        private void 重庆时时彩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show(new FrmBet_SSC(((ToolStripMenuItem)sender).Text.Substring(0, 2)));
        }

        private void 新疆时时彩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show(new FrmBet_SSC(((ToolStripMenuItem)sender).Text.Substring(0, 2)));
        }

        private void 天津时时彩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show(new FrmBet_SSC(((ToolStripMenuItem)sender).Text.Substring(0, 2)));
        }
    }
}
