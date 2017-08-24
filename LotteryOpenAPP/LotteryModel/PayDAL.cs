using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace LotteryModel
{
    public class PayDAL
    {
        static Dictionary<int, string> PayTypeDic;
        static Dictionary<int, string> GetPayTypeDic()
        {
            if (PayTypeDic == null)
            {
                PayTypeDic = new Dictionary<int, string>();
                PayTypeDic.Add(22, "支付宝");
                PayTypeDic.Add(20, "微信支付");
                PayTypeDic.Add(99, "银联支付");
                PayTypeDic.Add(11, "信用卡支付");
            }
            return PayTypeDic;
        }
        LotteryAPPEntities e;
        public bool AddPayRecord(Pay_Record pay)
        {
            using (e = new LotteryAPPEntities())
            {
                using (var tran = new TransactionScope())
                {
                    pay.creation_time = EntitiesTool.GetDateTimeNow(e);
                    e.Pay_Record.Add(pay);
                    var ar = new AccountRecharge
                    {
                        AccountId = pay.userId,
                        CreateTime = pay.creation_time,
                        Money = pay.orderAmount / 100,
                        OrderNo = pay.orderNO,
                        Status = pay.pay_status,
                        Remarks = "",
                    };
                    if (pay.payType.HasValue)
                    {
                        if (GetPayTypeDic().ContainsKey(pay.payType.Value))
                        {
                            ar.Type = GetPayTypeDic()[pay.payType.Value];
                        }
                        else
                        {
                            ar.Type = pay.payType.Value + "";
                        }
                    }
                    else
                    {
                        ar.Type = "";
                    }
                    e.AccountRecharge.Add(ar);
                    if (e.SaveChanges() == 2)
                    {
                        tran.Complete();
                        return true;
                    }
                }
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNO"></param>
        /// <param name="pay_status">0：未支付 1：成功 2:失败</param>
        /// <param name="paydatetime"></param>
        /// <returns></returns>
        public bool DonePayRecord(string orderNO, int pay_status, string paydatetime, int payType)
        {
            using (e = new LotteryAPPEntities())
            {
                using (var tran = new TransactionScope())
                {
                    var f = e.Pay_Record.FirstOrDefault(n => n.orderNO == orderNO && n.pay_status == 0);//1
                    if (f == null)
                    {
                        return false;
                    }
                    if (f.pay_status != 0)
                    {
                        return false;
                    }
                    var flag = false;
                    f.paydatetime = paydatetime;
                    f.pay_status = pay_status;
                    f.payType = payType;
                    var ar = e.AccountRecharge.FirstOrDefault(n => n.OrderNo == orderNO);//2
                    if (ar == null)
                    {
                        return false;
                    }
                    ar.Type = payType.ToString();
                    ar.Status = pay_status;
                    if (pay_status == 1)
                    {
                        var account = e.Accounts.FirstOrDefault(n => n.Id == f.userId);//3
                        if (account == null)
                        {
                            return false;
                        }
                        var ab = new AccountBusiness
                        {
                            AccountId = account.Id,
                            BusinessTypeId = (int)Enum_AccountBusinessType.Recharge,
                            CreateTime = EntitiesTool.GetDateTimeNow(e),
                            EventId = ar.Id,
                            PayBefore = account.AccountBalance,
                            PayIn = f.orderAmount / 100,
                            PayAfter = account.AccountBalance + f.orderAmount / 100,
                        };
                        account.AccountBalance = ab.PayAfter;
                        e.AccountBusiness.Add(ab);//4.投注业务单
                        var add = e.SaveChanges();
                        flag = add == 4;
                    }
                    else
                    {
                        flag = e.SaveChanges() == 2;
                    }
                    if (flag)
                    {
                        tran.Complete();
                    }
                    return flag;
                }
            }
        }
    }
}
