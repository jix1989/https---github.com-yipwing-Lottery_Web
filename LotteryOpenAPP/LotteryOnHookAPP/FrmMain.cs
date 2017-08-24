using LotteryOnHookAPP.JIX_SR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LotteryOnHookAPP
{
    public partial class FrmMain : Form
    {
        string LogGuid;
        int LotteryId;
        Account Account;
        Random random = new Random();
        DateTime dtNow;
        TimeSpan betweenExcept;
        TimeSpan _1s = new TimeSpan(TimeSpan.TicksPerSecond);
        WS_LotteryOffcialSchedule NextOpenInfo;
        WS_LotteryOpenInfo LastOpenInfo;
        //string[] czList = { "重庆时时彩", "新疆时时彩", "天津时时彩", "山东十一选五", "广东十一选五", "江西十一选五" };
        void showLastOpenInfo()
        {
            var openNum = LastOpenInfo.OpenCode.Split(',');
            if (openNum.Length == 5)
            {
                lblOpenNum1.Text = openNum[0];
                lblOpenNum2.Text = openNum[1];
                lblOpenNum3.Text = openNum[2];
                lblOpenNum4.Text = openNum[3];
                lblOpenNum5.Text = openNum[4];
                if (openNum[0].Length > 1)
                {
                    lblOpenNum1.Location = new Point(75-12, 52);
                    lblOpenNum2.Location = new Point(75 + 90 * 1 - 12, 52);
                    lblOpenNum3.Location = new Point(75 + 90 * 2 - 12, 52);
                    lblOpenNum4.Location = new Point(75 + 90 * 3 - 12, 52);
                    lblOpenNum5.Location = new Point(75 + 90 * 4 - 12, 52);
                }
                else 
                {
                    lblOpenNum1.Location = new Point(75, 52);
                    lblOpenNum2.Location = new Point(75+90*1, 52);
                    lblOpenNum3.Location = new Point(75 + 90 * 2, 52);
                    lblOpenNum4.Location = new Point(75 + 90 * 3, 52);
                    lblOpenNum5.Location = new Point(75 + 90 * 4, 52);
                }
            }
            lblLastExceptInfo.Text = string.Format("第{0}-{1}期 开奖号码", LastOpenInfo.Expect.Substring(0, 8), LastOpenInfo.Expect.Substring(8));
        }
        void showNextOpenInfo()
        {
            var idList = new ArrayOfInt();
            idList.Add(LotteryId);
            var next = Tools.client.GetLotteryNextInfo(LogGuid, idList);
            if (next != null && next.Count > 0)
            {
                if (NextOpenInfo == null || NextOpenInfo.Expect != next[0].Expect)
                {
                    NextOpenInfo = next[0];
                }
                else
                {
                    return;
                }
                lblNextExceptInfo.Text = string.Format("{0}-{1} 距离开奖时间还剩", NextOpenInfo.Expect.Substring(0, 8), NextOpenInfo.Expect.Substring(8));
                dtNow = Tools.client.GetDateTimeNow();
                betweenExcept = (next[0].ScheduleOpenTime - dtNow);
                showDJS();
                tmDJS.Start();
            }
        }
        void showDJS()
        {
            lblSec.Text =Tools.AddZero(betweenExcept.Seconds,2);
            lblMin.Text = Tools.AddZero(betweenExcept.Minutes,2);
            lblHours.Text = Tools.AddZero(betweenExcept.Hours,2);
        }
        public FrmMain()
        {
            this.Icon = global::LotteryOnHookAPP.Properties.Resources.icon2;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            cbopt.SelectedIndex = 0;
            cbocz.DataSource = Tools.client.GetLotteryList(Tools.GetJm());
            cbocz.DisplayMember = "LotteryName";
            cbocz.ValueMember = "Id";
            cbocz.Text = "多乐分分彩";
            cboxx1.SelectedIndex = 0;
            cboxx2.SelectedIndex = 0;
            cboxx3.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogGuid = Guid.NewGuid().ToString();
            var name = txtName.Text.Trim();
            var pwd = txtPwd.Text.Trim();
            if (name == "" || pwd == "")
            {
                return;
            }
            if (Tools.client.LoginOn(Tools.GetJm(), LogGuid, name, pwd) == "true")
            {
                LotteryId = (int)cbocz.SelectedValue;
                plLog.Visible = false;
                Account = Tools.client.GetAccountInfo(LogGuid);
                if (Account != null)
                {
                    lblname.Text = Account.AccountName;
                    lblmoney.Text = Account.AccountBalance + "(元)";
                    lblpt.Text = cbopt.Text;
                    lblcz.Text = cbocz.Text;
                    var list = Tools.client.GetLotteryHistroyInfo(LogGuid, 20, LotteryId);
                    dgvHistoryNum.Rows.Clear();
                    foreach (var item in list)
                    {
                        var row = dgvHistoryNum.Rows[dgvHistoryNum.Rows.Add()];
                        row.Cells[0].Value = item.Expect;
                        row.Cells[1].Value = item.OpenCode;
                    }
                    if (list != null && list.Count > 0)
                    {
                        LastOpenInfo = list[0];
                        showLastOpenInfo();
                    }
                    showNextOpenInfo();
                }
            }
        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            tmDJS.Stop();
            dgvHistoryNum.Rows.Clear();
            Account = null;
            plLog.Visible = true;
            NextOpenInfo=null;
            LastOpenInfo = null;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            txtpkjj.Enabled = checkBox6.Checked;
        }

        private void cboxx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxx2.Visible = cboxx1.SelectedIndex != 0;
        }

        private void btnfanganzengjia_Click(object sender, EventArgs e)
        {
            var r = dgvfangan.Rows[dgvfangan.Rows.Add()];
            r.Cells[0].Value = "方案" + (dgvfangan.Rows.Count);
            r.Cells[1].Value = "定位胆";
            r.Cells[2].Value = "元";
            r.Tag = "万位";
            dgvfangan_CellClick(null, null);
        }

        private void dgvfangan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvfangan.SelectedRows.Count > 0)
            {
                btnSave.Enabled = true;
                btnxxzengjiaa.Enabled = true;
                cboxx1.Text = dgvfangan.SelectedRows[0].Cells[1].Value.ToString();
                cboxx2.Text = dgvfangan.SelectedRows[0].Tag.ToString();
                cboxx3.Text = dgvfangan.SelectedRows[0].Cells[2].Value.ToString();
            }
            else
            {
                btnSave.Enabled = false;
                btnxxzengjiaa.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvfangan.SelectedRows[0].Cells[1].Value = cboxx1.Text;
            dgvfangan.SelectedRows[0].Tag = cboxx2.Text;
            dgvfangan.SelectedRows[0].Cells[2].Value = cboxx3.Text;
        }
        Dictionary<int, DataGridViewRow> dic = new Dictionary<int, DataGridViewRow>();
        private void btnxxzengjiaa_Click(object sender, EventArgs e)
        {
            FrmAddNum frm = new FrmAddNum(cboxx1.SelectedIndex);
            frm.ShowDialog();
        }

        private void label38_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label35_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void plLog_VisibleChanged(object sender, EventArgs e)
        {
            plLogInfo.Visible = !plLog.Visible;
        }
        /// <summary>
        /// 可开始获取上一期信息
        /// </summary>
        bool getFlag;
        private void tmDJS_Tick(object sender, EventArgs e)
        {
            betweenExcept = betweenExcept.Add(-_1s);
            if (betweenExcept.TotalSeconds <= 0)
            {
                showNextOpenInfo();
                getFlag = true;
            }
            else
            {
                showDJS();
            }
            if (getFlag&&((int)betweenExcept.TotalSeconds) % 3 == 0)
            {
                var list = Tools.client.GetLotteryHistroyInfo(LogGuid, 1, LotteryId);
                if (list != null && list.Count > 0)
                {
                    if (list[0].Expect != LastOpenInfo.Expect)
                    {
                        LastOpenInfo = list[0];
                        showLastOpenInfo();
                        dgvHistoryNum.Rows.Insert(0, 1);
                        dgvHistoryNum.Rows[0].Cells[0].Value = LastOpenInfo.Expect;
                        dgvHistoryNum.Rows[0].Cells[1].Value = LastOpenInfo.OpenCode;
                        getFlag = false;
                    }
                }
            }
        }

        #region 自定义窗体移动
        private void plTitle_MouseDown(object sender, MouseEventArgs e)
        {
            //将鼠标坐标赋给窗体左上角坐标  
            beginMove = true;
            currentXPosition = MousePosition.X;
            currentYPosition = MousePosition.Y;
            this.Refresh();
        }

        private void plTitle_MouseLeave(object sender, EventArgs e)
        {
            //设置初始状态  
            currentXPosition = 0;
            currentYPosition = 0;
            beginMove = false;
        }

        private void plTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                //根据鼠标X坐标确定窗体X坐标  
                this.Left += MousePosition.X - currentXPosition;
                //根据鼠标Y坐标确定窗体Y坐标  
                this.Top += MousePosition.Y - currentYPosition;
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }

        private void plTitle_MouseUp(object sender, MouseEventArgs e)
        {
            beginMove = false;
        }
        bool beginMove = false;
        int currentXPosition;
        int currentYPosition; 
        #endregion
    }
}
