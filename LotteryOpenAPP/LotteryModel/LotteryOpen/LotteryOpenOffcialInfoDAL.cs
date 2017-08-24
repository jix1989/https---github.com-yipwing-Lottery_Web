using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryModel
{
    public class LotteryOpenOffcialInfoDAL
    {
        LotteryAPPEntities e;
        //TransactionScope tran;
        /// <summary>
        /// 初始化开奖信息
        /// </summary>
        public void InitialTodayInfo(Lotterys Lottery)
        {
            
            using (e = new LotteryAPPEntities())
            {
                var dt = EntitiesTool.GetDateTimeNow(e);
                var dtDel=dt.AddDays(-1);
                e.LotteryOffcialSchedule.RemoveRange(e.LotteryOffcialSchedule.Where(n => n.LotteryId == Lottery.Id && n.ScheduleOpenTime <= dtDel));//删除前一天的时刻表
                var sp = Lottery.TimeStart.Value.ToString().Split('.');
                var dtS = dt.Date.AddHours(Convert.ToInt32(sp[0]));
                if (sp.Length > 1)
                {
                    dtS = dtS.AddMinutes(Convert.ToInt32(sp[1]));
                }
                var dtE = dtS.AddDays(3);
                var query = e.LotteryOffcialSchedule.Where(n => n.LotteryId == Lottery.Id && n.ScheduleOpenTime >= dtS && n.ScheduleOpenTime < dtE).ToList();
                if (query.Count >= Lottery.ExceptOneDay * 2)
                {
                    return;//至少保留两天预设期
                }
                int j = -1;
                var sdt = dtS;
                var openList = new List<LotteryOffcialSchedule>();
                if (Lottery.LotteryCode == "cqssc")
                {
                    for (int i = 0; i < Lottery.ExceptOneDay * 3; i++)
                    {
                        if (i > 0 && i % Lottery.ExceptOneDay.Value == 0)
                        {
                            dtS = dtS.AddDays(1);
                            sdt = dtS;
                            j = -1;
                        }
                        j++;
                        var ex = j + 24 > 120 ? j + 24 - 120 : j + 24;
                        if (ex ==1)
                        {
                            dt = dt.AddDays(1);
                        }
                        var expect = dt.Date.ToString("yyyyMMdd") + MyTool.AddZeroStr(ex, Lottery.ExceptLength.Value);
                        if (query.Exists(n => n.Expect == expect))
                        {
                            continue;
                        }
                        if (ex >= 97 || ex <= 23)
                        {
                            sdt = sdt.AddMinutes(5);
                        }
                        else if(ex>24)
                        {
                            sdt = sdt.AddMinutes((int)Lottery.BetweenMinute.Value);
                        }
                        var open = new LotteryOffcialSchedule
                        {
                            LotteryId = Lottery.Id,
                            ScheduleOpenTime = sdt,//间隔多少时间一期
                            Expect = expect,
                        };
                        openList.Add(open);
                    }
                }
                else
                {
                    for (int i = 0; i < Lottery.ExceptOneDay * 3; i++)
                    {
                        if (i > 0 && i % Lottery.ExceptOneDay.Value == 0)
                        {
                            dt = dt.AddDays(1);
                            dtS = dtS.AddDays(1);
                            j = -1;
                        }
                        j++;
                        var expect = dt.Date.ToString("yyyyMMdd") + MyTool.AddZeroStr(j + 1, Lottery.ExceptLength.Value);
                        if (query.Exists(n => n.Expect == expect))
                        {
                            continue;
                        }
                        var open = new LotteryOffcialSchedule
                        {
                            LotteryId = Lottery.Id,
                            ScheduleOpenTime = dtS.AddSeconds(Convert.ToDouble(j * Lottery.BetweenMinute.Value*60)),//间隔多少时间一期
                            Expect = expect,
                        };
                        if(Lottery.IsPrivate)
                        {
                            open.ScheduleOpenCode = CreateOpenCode(Lottery.LotteryType);//TODO
                        }
                        openList.Add(open);
                    }
                }
                e.LotteryOffcialSchedule.AddRange(openList);
                e.SaveChanges();
            }
        }
        static string[] NumList11x5_Normal = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11" };
        static string[] NumListSSC_Normal = { "0","1", "2", "3", "4", "5", "6", "7", "8", "9"};
        static Random Random = new Random(); 
        string CreateOpenCode(string type) 
        {
            var code="";
            switch(type)
            {
                case"ssc":
                    code = string.Format("{0},{1},{2},{3},{4}", NumListSSC_Normal[Random.Next(0, NumListSSC_Normal.Length)], NumListSSC_Normal[Random.Next(0, NumListSSC_Normal.Length)], NumListSSC_Normal[Random.Next(0, NumListSSC_Normal.Length)], NumListSSC_Normal[Random.Next(0, NumListSSC_Normal.Length)], NumListSSC_Normal[Random.Next(0, NumListSSC_Normal.Length)]);
                    break;
                case"11x5":
                    var list = NumList11x5_Normal.ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        var j=Random.Next(0, list.Count);
                        code += list[j]+",";
                        list.RemoveAt(j);
                    }
                    code = code.Remove(code.Length - 1);
                    break;
            }
            return code;
        }

        public List<LotteryOffcialSchedule> NextOpenNo(List<int> LotteryId)
        {
            
            using (e = new LotteryAPPEntities())
            {
                var dt = EntitiesTool.GetDateTimeNow(e);
                var query = new List<LotteryOffcialSchedule>();
                foreach (var item in LotteryId)
                {
                    query.Add(e.LotteryOffcialSchedule.Where(n => item == n.LotteryId && n.ScheduleOpenTime > dt).OrderBy(n => n.ScheduleOpenTime).FirstOrDefault());
                }
                return query;
            }
        }
        public LotteryOffcialSchedule NextOpenNo(int LotteryId)
        {
           
            using (e = new LotteryAPPEntities())
            {
                var dt = EntitiesTool.GetDateTimeNow(e);
                return e.LotteryOffcialSchedule.Where(n => LotteryId == n.LotteryId && n.ScheduleOpenTime > dt).OrderBy(n => n.ScheduleOpenTime).FirstOrDefault();
            }
        }
        /// <summary>
        /// 获取指定数量的预开奖信息
        /// </summary>
        /// <param name="LotteryId"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public List<LotteryOffcialSchedule> GetLotteryOffcialScheduleList(int LotteryId,int Count) 
        {
            using(e=new LotteryAPPEntities())
            {
                var dt = EntitiesTool.GetDateTimeNow(e);
                var query = e.LotteryOffcialSchedule.Where(n => n.LotteryId == LotteryId&&n.ScheduleOpenTime>dt).Take(Count).ToList();
                //query.ForEach(n => n.ScheduleOpenCode = "");
                return query;
            }
            
        }
    }
}
