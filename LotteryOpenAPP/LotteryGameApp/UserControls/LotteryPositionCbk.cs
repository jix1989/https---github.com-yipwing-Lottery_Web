using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LotteryGameApp
{
    public partial class LotteryPositionCbk : UserControl
    {
       
        int need;
        public LotteryPositionCbk(int need)
        {
            InitializeComponent();
            switch (need) 
            {
                case 4:
                    cbk1.Checked = true;
                    cbk2.Checked = true;
                    cbk3.Checked = true;
                    cbk4.Checked = true;
                    break;
                case 3:
                    cbk2.Checked = true;
                    cbk3.Checked = true;
                    cbk4.Checked = true;
                    break;
                case 2:
                    cbk3.Checked = true;
                    cbk4.Checked = true;
                    break;
            }
            this.need = need;
            GetwzList();
            label1.Text = string.Format("温馨提示：你选择了 {0} 个位置，系统自动根据位置组合成 {1} 个方案。", wzList.Count, CalculateCombination(need, wzList.Count));
            this.cbk0.CheckedChanged += new System.EventHandler(this.cbk0_CheckedChanged);
            this.cbk1.CheckedChanged += new System.EventHandler(this.cbk0_CheckedChanged);
            this.cbk2.CheckedChanged += new System.EventHandler(this.cbk0_CheckedChanged);
            this.cbk3.CheckedChanged += new System.EventHandler(this.cbk0_CheckedChanged);
            this.cbk4.CheckedChanged += new System.EventHandler(this.cbk0_CheckedChanged);
        }
        public List<int> wzList = new List<int>();
        public void GetwzList() 
        {
            wzList.Clear();
            if(cbk0.Checked)
            {
                wzList.Add(0);
            }
            if (cbk1.Checked)
            {
                wzList.Add(1);
            }
            if (cbk2.Checked)
            {
                wzList.Add(2);
            }
            if (cbk3.Checked)
            {
                wzList.Add(3);
            }
            if (cbk4.Checked)
            {
                wzList.Add(4);
            }
            //return wzList;
        }

        private void cbk0_CheckedChanged(object sender, EventArgs e)
        {
            GetwzList();
            label1.Text = string.Format("温馨提示：你选择了 {0} 个位置，系统自动根据位置组合成 {1} 个方案。", wzList.Count, CalculateCombination(need, wzList.Count));
            if (UserControlBtnClicked != null)
                UserControlBtnClicked(sender, new EventArgs());//把按钮自身作为参数传递
        }

        //定义委托
        public delegate void BtnClickHandle(object sender, EventArgs e);
        //定义事件
        public event BtnClickHandle UserControlBtnClicked;

        #region 组合计算
        /// <summary>
        /// 组合计算字典
        /// </summary>
        static Dictionary<string, int> ccDic = new Dictionary<string, int>();
        /// <summary>
        /// 组合运算C(n,m)
        /// </summary>
        /// <param name="n">选择数</param>
        /// <param name="m">总数</param>
        /// <returns></returns>
        static int CalculateCombination(int n, int m)
        {
            if (n == m) return 1;
            if (n <= 0) return 0;
            if (n > m) return 0;
            var c = n + "," + m;
            if (!ccDic.Keys.Contains(c)) //不存在则计算结果后储存字典
            {
                int r1 = m;
                int r2 = n;
                for (int i = 1; i < n; i++)
                {
                    r1 *= m - i;
                    r2 *= n - i;
                }
                ccDic.Add(c, r1 / r2);
            }
            return ccDic[c];
        }
        #endregion

    }
}
