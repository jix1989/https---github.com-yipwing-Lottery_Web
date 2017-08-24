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
    public partial class LotteryChoiceNoControl : UserControl
    {
        /// <summary>
        /// 所选号集合
        /// </summary>
        public List<string> ChoiceList = new List<string>();
        /// <summary>
        /// 最大选号个数
        /// </summary>
        public int MaxChoice = 200;
        public List<Label> Choicelbl = new List<Label>();
        List<string> list;
        string[] type0 = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] type1 = { "大", "小", "单", "双" };
        string[] type2 = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11" };
        string[] type3 = {"5单0双","4单1双","3单2双","2单3双","1单4双","0单5双"};
        string[] type4 = { "3", "4", "5", "6", "7", "8", "9" };
        string[] type5 = { "5大0小", "4大1小", "3大2小", "2大3小", "1大4小", "0大5小" };
        string[] type6 = { "豹子","顺子","对子" };
        string[] type7 = { "4条", "3条", "3带2", "两对", "一对", "全不同号" };
        string[] type8 = { "顺子号" };
        string[] options = { "全", "大", "小", "奇", "偶", "清" };
        int type;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tip">行标签文本</param>
        /// <param name="type">0:0-9;1:大小单双;2:01-11</param>
        /// <param name="show">快捷面板显示</param>
        public LotteryChoiceNoControl(string tip, int type, bool show, string maxChoice)
        {
            InitializeComponent();
            this.lblTip.Text = tip;
            this.plOption.Visible = show;
            if(!show)
            {
                plNum.Size=new Size(plNum.Size.Width+100,plNum.Size.Height);
            }
            this.MaxChoice = maxChoice == "" ? MaxChoice : Convert.ToInt32(maxChoice);
            this.type = type;
            switch (type)
            {
                case 0:
                    list = type0.ToList();
                    break;
                case 1:
                    list = type1.ToList();
                    break;
                case 2:
                    list = type2.ToList();
                    break;
                case 3://定单双
                    list = type3.ToList();
                    break;
                case 4://猜中位
                    list = type4.ToList();
                    break;
                case 5://大小
                    list = type5.ToList();
                    break;
                case 6://特殊号"豹子","顺子","对子"
                    list=type6.ToList();
                    break;
                case 7://百家
                    list = type7.ToList();
                    break;
                case 8://百家顺子
                    list = type8.ToList();
                    break;
            }
        }
        public LotteryChoiceNoControl(string tip, int min,int max, bool show, string maxChoice)
        {
            InitializeComponent();
            this.lblTip.Text = tip;
            this.plOption.Visible = show;
            if (!show)
            {
                plNum.Size = new Size(plNum.Size.Width + 100, plNum.Size.Height);
            }
            this.MaxChoice = maxChoice == "" ? MaxChoice : Convert.ToInt32(maxChoice);
            list = new List<string>();
            for (int i = min; i <= max; i++)
            {
                list.Add(i.ToString());
            }
        }

        private void LotteryChoiceNoControl_Load(object sender, EventArgs e)
        {
            if(list.Count > 11)
            {
                this.Size=new Size(this.Width,this.Height*2);
                plNum.Size=new Size(plNum.Width+150,this.Height*2);
            }
            //生成选号板
            for (int i = 0; i < list.Count; i++)
            {
                if (list.Count > 11 && i == (list.Count / 2))
                {
                    lastLbl = null;
                }
                if (list.Count > 11 && i >= list.Count / 2)
                {
                    
                    addLbl(list[i], 1);
                }
                else 
                {
                    addLbl(list[i], null);
                }
            }
            //是否生成快捷选项版
            if (plOption.Visible)
            {
                for (int i = 0; i < options.Length; i++)
                {
                    addLbl1(options[i], i);
                }
            }
        }
        #region 选号控件
        Label lastLbl;
        void addLbl(string txt,int? y)
        {
            Label lbl = new Label();
            lbl.BackColor = lblDemo.BackColor;
            lbl.Font = lblDemo.Font;
            lbl.ForeColor = lblDemo.ForeColor;
            lbl.Margin = lblDemo.Margin;
            lbl.Padding = lblDemo.Padding;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.AutoSize = true;
            lbl.Size = lblDemo.Size;
            lbl.Text = txt;
            lbl.Click += new EventHandler(label_Click);
            lbl.BorderStyle = lblDemo.BorderStyle;
            lbl.Cursor = lblDemo.Cursor;
            if (y.HasValue)
            {
                lbl.Location = lastLbl == null ? new Point(0, 5+y.Value*27) : new Point(lastLbl.Location.X + 8 + lastLbl.Width, 5+y.Value*(5+lastLbl.Height));
            }
            else 
            {
                lbl.Location = lastLbl == null ? new Point(0, 5) : new Point(lastLbl.Location.X + 8 + lastLbl.Width, 5);
            }
            lastLbl = lbl;
            plNum.Controls.Add(lbl);
        }
        private void label_Click(object sender, EventArgs e)
        {
            ChoiceLbl((Label)sender, null);
            if (UserControlBtnClicked != null)
                UserControlBtnClicked(sender, new EventArgs());//把按钮自身作为参数传递
        }
        /// <summary>
        /// 改变选号label样式
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="flag">是否选中</param>
        public void ChoiceLbl(Label lbl, bool? flag)
        {
            if (!flag.HasValue)
            {
                flag = lbl.BorderStyle != BorderStyle.Fixed3D;
            }
            if (flag.Value)//选中
            {
                lbl.BorderStyle = BorderStyle.Fixed3D;
                lbl.BackColor = Color.FromArgb(192, 0, 0);
                lbl.ForeColor = Color.White;
                if (!ChoiceList.Contains(lbl.Text) && lbl.Visible)
                {
                    ChoiceList.Add(lbl.Text);
                    Choicelbl.Add(lbl);
                }
            }
            else
            {
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Black;
                ChoiceList.Remove(lbl.Text);
                Choicelbl.Remove(lbl);
            }
            if (Choicelbl.Count > MaxChoice)
            {
                var l = Choicelbl[Choicelbl.Count - 2];
                l.BorderStyle = BorderStyle.FixedSingle;
                l.BackColor = Color.White;
                l.ForeColor = Color.Black;
                ChoiceList.Remove(l.Text);
                Choicelbl.Remove(l);
            }
        }
        ///// <summary>
        ///// 通过快捷按钮选号的样式
        ///// </summary>
        ///// <param name="lbl"></param>
        ///// <param name="flag"></param>
        //void ChoiceLbl(Label lbl, bool flag)
        //{
        //    if (flag)
        //    {
        //        lbl.BorderStyle = BorderStyle.Fixed3D;
        //        lbl.BackColor = Color.FromArgb(192, 0, 0);
        //        lbl.ForeColor = Color.White;
        //    }
        //    else
        //    {
        //        lbl.BorderStyle = BorderStyle.FixedSingle;
        //        lbl.BackColor = Color.White;
        //        lbl.ForeColor = Color.Black;
        //    }
        //}
        #endregion

        #region 功能控件
        void addLbl1(string txt, int c)
        {
            Label lbl = new Label();
            lbl.BackColor = lblOption.BackColor;
            lbl.Font = lblOption.Font;
            lbl.ForeColor = lblOption.ForeColor;
            lbl.Margin = lblOption.Margin;
            lbl.Padding = lblOption.Padding;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.AutoSize = false;
            lbl.Size = lblOption.Size;
            lbl.Text = txt;
            lbl.BorderStyle = lblOption.BorderStyle;
            lbl.Cursor = lblOption.Cursor;
            lbl.Location = new Point(lblOption.Location.X + c * 35, 5);
            lbl.MouseEnter += new EventHandler(lblOption_MouseEnter);
            lbl.MouseLeave += new EventHandler(lblOption_MouseLeave);
            lbl.Click += new EventHandler(lblOption_Click);
            plOption.Controls.Add(lbl);
        }

        private void lblOption_MouseEnter(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl.BackColor = Color.FromArgb(192, 0, 0);
            lbl.ForeColor = Color.White;
        }

        private void lblOption_MouseLeave(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl.BackColor = Color.FromArgb(192, 255, 192);
            lbl.ForeColor = Color.Black;
        }
        private void lblOption_Click(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            switch (lbl.Text)
            {
                case "全":
                    foreach (var item in plNum.Controls)
                    {
                        ChoiceLbl((Label)item, true);
                    }
                    break;
                case "大":
                    foreach (var item in plNum.Controls)
                    {
                        var l = (Label)item;
                        if (Convert.ToInt32(l.Text) >= list.Count / 2.0+(type==4?2:0))
                        {
                            ChoiceLbl(l, true);
                        }
                        else 
                        {
                            ChoiceLbl(l, false);
                        }
                    }
                    break;
                case "小":
                    foreach (var item in plNum.Controls)
                    {
                        var l = (Label)item;
                        if (Convert.ToInt32(l.Text) < list.Count / 2.0 + (type == 4 ? 2 : 0))
                        {
                            ChoiceLbl(l, true);
                        }
                        else
                        {
                            ChoiceLbl(l, false);
                        }
                    }
                    break;
                case "奇":
                    foreach (var item in plNum.Controls)
                    {
                        var l = (Label)item;
                        if (Convert.ToInt32(l.Text) % 2 != 0)
                        {
                            ChoiceLbl(l, true);
                        }
                        else
                        {
                            ChoiceLbl(l, false);
                        }
                    }
                    break;
                case "偶":
                    foreach (var item in plNum.Controls)
                    {
                        var l = (Label)item;
                        if (Convert.ToInt32(l.Text) % 2 == 0)
                        {
                            ChoiceLbl(l, true);
                        }
                        else
                        {
                            ChoiceLbl(l, false);
                        }
                    }
                    break;
                case "清":
                    foreach (var item in plNum.Controls)
                    {
                        ChoiceLbl((Label)item, false);
                    }
                    break;
            }
            if (UserControlBtnClicked != null)
                UserControlBtnClicked(sender, new EventArgs());//把按钮自身作为参数传递
        }
        #endregion

        //定义委托
        public delegate void BtnClickHandle(object sender, EventArgs e);
        //定义事件
        public event BtnClickHandle UserControlBtnClicked;
    }
}
