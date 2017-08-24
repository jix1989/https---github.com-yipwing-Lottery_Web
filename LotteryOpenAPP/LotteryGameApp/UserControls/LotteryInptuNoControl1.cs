using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LotteryGameApp
{
    public partial class LotteryInptuNoControl1 : UserControl
    {
        string type;
        public LotteryInptuNoControl1(string type)
        {
            InitializeComponent();
            this.type = type;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtNo.Text = "";
        }

        private void btnDelRepeat_Click(object sender, EventArgs e)
        {
            var str = txtNo.Text.Replace(",", " ").Replace(";", " ").Replace("，", " ").Replace("；", " ").Replace("\r\n", " ");
            var str1 = str.Split(' ').Distinct();
            txtNo.Text = "";
            foreach (var item in str1)
            {
                txtNo.Text += item + ' ';
            }
            txtNo.Text = txtNo.Text.Remove(txtNo.Text.Length - 1, 1);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtNo.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.Default);
            }
        }
        List<List<int>> iList = new List<List<int>>();
        public string GetBetNo()
        {
            var str = txtNo.Text.Replace(",", " ").Replace(";", " ").Replace("，", " ").Replace("；", " ").Replace("\r\n", " ");
            int needLenth = 0;
            switch (type)
            {
                case "五星直选单式":
                    needLenth = 5;
                    break;
                case "四星直选单式":
                case "任四直选单式":
                    needLenth = 4;
                    break;
                case "后三直选单式":
                case "中三直选单式":
                case "前三直选单式":
                case "混合组选":
                case "组六单式":
                case "组三单式":
                case "任三组三单式":
                case "任三组六单式":
                case "任三混合组选":
                case "任三直选单式":
                    needLenth = 3;
                    break;
                case "后二直选单式":
                case "后二组选单式":
                case "前二直选单式":
                case "前二组选单式":
                case "任二直选单式":
                case "任二组选单式":
                    needLenth = 2;
                    break;
            }
            var str1 = str.Split(' ').Select(n => n.Trim()).Distinct().Where(n => n.Length == needLenth);
            StringBuilder sb = new StringBuilder();
            int a = 0;
            foreach (var item in str1)
            {
                bool flag = false;
                if (item == "")
                {
                    continue;
                }
                foreach (var item1 in item)
                {
                    if (!int.TryParse(item1.ToString(), out a) || a < 0 || a > 9)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    continue;
                }
                else
                {
                    List<int> aList = new List<int>();
                    foreach (var item1 in item)
                    {
                        if (int.TryParse(item1.ToString(), out a))
                        {
                            aList.Add(a);
                        }
                    }
                    iList.Add(aList);
                }
                if (type.Contains("组三"))
                {
                    foreach (var itemList in iList)
                    {
                        if (itemList.Distinct().Count() == 2)
                        {
                            var str2 = "";
                            foreach (var item2 in itemList.OrderBy(n => n))
                            {
                                str2 += item2;
                            }
                            if (!sb.ToString().Contains(str2))
                            {
                                sb.Append(str2 + ' ');
                            }
                        } 
                    }
                }
                else if (type.Contains("组六"))
                {
                    foreach (var itemList in iList)
                    {
                        if (itemList.Distinct().Count() ==3)
                        {
                            var str2 = "";
                            foreach (var item2 in itemList.OrderBy(n => n))
                            {
                                str2 += item2;
                            }
                            if (!sb.ToString().Contains(str2))
                            {
                                sb.Append(str2 + ' ');
                            }
                        } 
                    }
                }
                else if (type.Contains("组"))
                {
                    foreach (var itemList in iList)
                    {
                        if (itemList.Distinct().Count() >= 2)
                        {
                            var str2 = "";
                            foreach (var item2 in itemList.OrderBy(n => n))
                            {
                                str2 += item2;
                            }
                            if (!sb.ToString().Contains(str2))
                            {
                                sb.Append(str2 + ' ');
                            }
                        }
                    }
                }
                else
                {
                    sb.Append(item + ' ');
                }
            }
            str = sb.Length > 1 ? sb.Remove(sb.Length - 1, 1).ToString() : "";
            return str;
        }
    }
}
