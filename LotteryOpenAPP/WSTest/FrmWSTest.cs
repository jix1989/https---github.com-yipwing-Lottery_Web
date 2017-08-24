using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Windows.Forms;
using WSTest.ServiceReference1;
namespace WSTest
{
    public partial class FrmWSTest : Form
    {
        WebService1SoapClient client = new WebService1SoapClient();
        public FrmWSTest()
        {
            InitializeComponent();
        }
        string guid;
        private void Form1_Load(object sender, EventArgs e)
        {
            guid = Guid.NewGuid().ToString();
            var b = client.LoginOn(ToMD5(DateTime.Now.Date.Ticks.ToString()) ,guid, "jix008", "a");
        }
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            var dic = client.GetLotteryList(guid);
            var a = client.GetBetInfo(guid, 489);
            //button1.Text = ++i+"";
            //WebService1SoapClient client1 = new WebService1SoapClient();
            //var list = client1.GetLotteryList(guid);
            WS_BetInfo[] list=new WS_BetInfo[1];
            list[0] = new WS_BetInfo();
            list[0].BetNum = "0||||";
            list[0].BetPlayTypeCode=93;
            list[0].BetUnit=1;
            list[0].BetMoneyMode="元";
            list[0].BetMoney=2;
            list[0].ChoicePosition="";
            list[0].IsGetBackPercent=false;
            list[0].BetTimes = 1;
            var asb=client.SendBetInfo(guid,1,"20170809117",list);
            Pay_Record record = new Pay_Record
            {
                mchtOrderId = "",
                orderNO = "NO20170810162401",
                orderAmount = 12,
                orderDatetime = "20170810042401",
                payerName = "",
                payerEmail = "",
                payerTelephone = "",
                paydatetime = "",
                payType = 0,
                merchantId = "100020091219001",
                productName = "12123",
                productId = null,
                productDesc = null,
                productNum = 1,
                productPrice = 12,
                ext1 = null,
                ext2 = null
            };
            //var flag = client.AddPayRecord(guid, record);
            // var list1=client.GetBetInfoList1(guid, 1, DateTime.Now, DateTime.Now, null, null, false);
            //  var flag=  client.DonePayRecord("ewd2asr87ghht9rt4wqw78e2qw778wds21x777gjd","NO20170810162401", 1, "20170810200254", 0);
            //var a= client.GetBetInfo(guid, 1664430);
            //var a = client.Withdraw(guid,new decimal(0.1), "6227007102080017916", "中国建设银行");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.RegChildAccount(guid, new Account 
            {
                AccountName ="jix008",
                AccountPwd ="a",
                AccountNickname ="008",
                AgentPercentSSC =1,
                AgentPercent11X5 =1,
                AgentPercentDPC =1,
                AccountMoneyPwd ="a",
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var a = client.GetWS_Accounts_AgentList(guid, "", "", "", 1);
        }

        Dictionary<string, int> BetNum_TSH;
        string ChangeBetNumTSH(string betNum)
        {
            if (BetNum_TSH == null)
            {
                BetNum_TSH = new Dictionary<string, int>();
                #region 时时彩
                BetNum_TSH.Add("4条", 5);
                BetNum_TSH.Add("3条", 20);
                BetNum_TSH.Add("3带2", 10);
                BetNum_TSH.Add("两对", 30);
                BetNum_TSH.Add("一对", 60);
                BetNum_TSH.Add("全不同", 120);
                BetNum_TSH.Add("顺子号", 120);
                BetNum_TSH.Add("全单", 5);
                BetNum_TSH.Add("全双", 0);
                BetNum_TSH.Add("4单1双", 4);
                BetNum_TSH.Add("1单4双", 1);
                BetNum_TSH.Add("3单2双", 3);
                BetNum_TSH.Add("2单3双", 2);
                BetNum_TSH.Add("全大", 5);
                BetNum_TSH.Add("全小", 0);
                BetNum_TSH.Add("4大1小", 4);
                BetNum_TSH.Add("1大4小", 1);
                BetNum_TSH.Add("3大2小", 3);
                BetNum_TSH.Add("2大3小", 2);
                BetNum_TSH.Add("豹子", 3);
                BetNum_TSH.Add("顺子", 1);
                BetNum_TSH.Add("对子", 2);
                BetNum_TSH.Add("大", 6);
                BetNum_TSH.Add("小", 5);
                BetNum_TSH.Add("单", 1);
                BetNum_TSH.Add("双", 0);
                #endregion
                #region 十一选五
                BetNum_TSH.Add("5单0双", 5);
                //BetNum_TSH.Add("4单1双", 4);
                //BetNum_TSH.Add("3单2双", 3);
                //BetNum_TSH.Add("2单3双", 2);
                //BetNum_TSH.Add("1单4双", 1);
                BetNum_TSH.Add("0单5双", 0);
                #endregion
            }
            var betNumNew = new StringBuilder();
            foreach (var l1 in betNum.Split('|'))
            {
                foreach (var item in l1.Split(' '))
                {
                    if (BetNum_TSH.ContainsKey(item))
                    {
                        betNumNew.Append(BetNum_TSH[item]);
                    }
                    else
                    {
                        betNumNew.Append(item);
                    }
                    betNumNew.Append(' ');
                }
                betNumNew.Remove(betNumNew.Length - 1, 1);
                betNumNew.Append('|');
            }
            betNumNew.Remove(betNumNew.Length - 1, 1);
            return betNumNew.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text=ChangeBetNumTSH(textBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var a = client.GetGroupMoney(guid);
        }

        public static string ToMD5(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile("A1.@a%2DFA" + str, "MD5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var a = client.GetLotteryOffcialScheduleList(guid, 1, 10);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var lotteryId=9;
            var a = client.GetLotteryOffcialScheduleList(guid, lotteryId, 10);
            var list = new List<WS_ZHInfo>();
            list.Add(new WS_ZHInfo
                    {
                        BetMoney = 2,
                        BetMoneyMode = "元",
                        BetNum = "0|0|0|0|0",
                        BetPlayTypeCode = 2,
                        BetTimes = 1,
                        BetUnit = 1,
                        ChoicePosition = "",
                        IsGetBackPercent = true,
                        Except=a[0].Expect,
                    });
            list.Add(new WS_ZHInfo
            {
                BetMoney = 6,
                BetMoneyMode = "角",
                BetNum = "0 1 2|0 1 2",
                BetPlayTypeCode = 116,
                BetTimes = 1,
                BetUnit = 30,
                ChoicePosition = "0,1,2,3,4",
                IsGetBackPercent = true,
                Except = a[0].Expect,
            });
            list.Add(new WS_ZHInfo
            {
                BetMoney = 2,
                BetMoneyMode = "元",
                BetNum = "0|0|0|0|0",
                BetPlayTypeCode = 2,
                BetTimes = 1,
                BetUnit = 1,
                ChoicePosition = "",
                IsGetBackPercent = true,
                Except = a[1].Expect,
            });
            list.Add(new WS_ZHInfo
            {
                BetMoney = 6,
                BetMoneyMode = "角",
                BetNum = "0 1 2|0 1 2",
                BetPlayTypeCode = 116,
                BetTimes = 1,
                BetUnit = 30,
                ChoicePosition = "0,1,2,3,4",
                IsGetBackPercent = true,
                Except = a[1].Expect,
            });
            list.Add(new WS_ZHInfo
            {
                BetMoney = 50,
                BetMoneyMode = "元",
                BetNum = "0 1 2 3 4 5 6 7 8 9|0 1 2 3 4 5 6 7 8 9|0 1 2 3 4 5 6 7 8 9|0 1 2 3 4 5 6 7 8 9|0 1 2 3 4 5 6 7 8 9",
                BetPlayTypeCode = 1,
                BetTimes = 1,
                BetUnit = 50,
                ChoicePosition = "",
                IsGetBackPercent = true,
                Except = a[0].Expect,
            });
            list.Add(new WS_ZHInfo
            {
                BetMoney = 50,
                BetMoneyMode = "元",
                BetNum = "0 1 2 3 4 5 6 7 8 9|0 1 2 3 4 5 6 7 8 9|0 1 2 3 4 5 6 7 8 9|0 1 2 3 4 5 6 7 8 9|0 1 2 3 4 5 6 7 8 9",
                BetPlayTypeCode = 1,
                BetTimes = 1,
                BetUnit = 50,
                ChoicePosition = "",
                IsGetBackPercent = true,
                Except = a[1].Expect,
            });
            var str = client.SendBetInfo_ZH(guid, lotteryId, true, list.ToArray());

        }
    }
}
