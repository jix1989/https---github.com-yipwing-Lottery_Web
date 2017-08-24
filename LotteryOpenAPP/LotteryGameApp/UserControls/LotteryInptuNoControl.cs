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
    public partial class LotteryInptuNoControl : UserControl
    {
        string type;
        public LotteryInptuNoControl(string type)
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
            var str = txtNo.Text.Replace(",", "|").Replace(";", "|").Replace("，", "|").Replace("；", "|").Replace("\r\n","|");
            var str1=str.Split('|').Distinct();
            txtNo.Text = "";
            foreach (var item in str1)
            {
                txtNo.Text += item + ';';
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

        public string GetBetNo() 
        {
            var str = txtNo.Text.Replace(",", "|").Replace(";", "|").Replace("，", "|").Replace("；", "|").Replace("\r\n", "|");
            int needLenth = 0;
            switch (type) 
            {
                case "任选一中一":
                    needLenth = 1;
                    break;
                case "任选二中二":
                case "前二直选单式":
                case "前二组选单式":
                    needLenth = 2;
                    break;
                case "任选三中三":
                case "前三直选单式":
                case "前三组选单式":
                    needLenth = 3;
                    break;
                case "任选四中四":
                    needLenth = 4;
                    break;
                case "任选五中五":
                    needLenth = 5;
                    break;
                case "任选六中五":
                    needLenth = 6;
                    break;
                case "任选七中五":
                    needLenth = 7;
                    break;
                case "任选八中五":
                    needLenth = 8;
                    break;
            }
            var str1 = str.Split('|').Select(n=>n.Trim()).Distinct().Where(n=>n.Length==needLenth*3-1);
            str = "";
            int a=0;
            foreach (var item in str1)
            {
                bool flag = false;
                if(item=="")
                {
                    continue;
                }
                foreach (var item1 in item.Split(' '))
                {
                    if (!int.TryParse(item1, out a) || a < 1 || a > 11)
                    {
                        flag = true;
                        break;
                    } 
                }
                if (flag)
                {
                    continue;
                }
                str += item + '|';
            }
            str = str.Length>1?str.Remove(str.Length - 1, 1):"";
            return str;
        }
    }
}
