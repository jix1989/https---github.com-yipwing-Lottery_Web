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
    public partial class FrmAddNum : Form
    {
        Random random = new Random();
        int type;
        public FrmAddNum(int type)
        {
            InitializeComponent();
            this.Icon = global::LotteryOnHookAPP.Properties.Resources.icon2;
            this.type = type;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            txt.Text = "";
            List<int> nList = new List<int>();
            if (checkBox1.Checked)
            {
                while (nList.Count != numericUpDown1.Value)
                {
                    switch (type)
                    {
                        case 0:
                        case 1:
                            var n = random.Next(0, 10);
                            if (!nList.Contains(n))
                            {
                                nList.Add(n);
                            }
                            break;
                    }
                }
            }
            foreach (var item in nList)
            {
                txt.Text += item + " ";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btnCreate.Enabled = checkBox1.Checked;
        }

        private void FrmAddNum_Load(object sender, EventArgs e)
        {

        }
    }
}
