using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using TEST1.SR;
namespace TEST1
{
    public partial class Form1 : Form
    {
        private static CookieContainer cookieContainer = new CookieContainer();
        WebService1SoapClient Client = new WebService1SoapClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cookieContainer.
            //Client.c = cookieContainer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var guid = Guid.NewGuid().ToString();
            var b = Client.LoginOn(guid,"jix007", "a");
            var a = Client.GetAccountInfo(guid);
            var c = Client.GetLotteryPlayList(guid,"ssc");
        }
    }
}
