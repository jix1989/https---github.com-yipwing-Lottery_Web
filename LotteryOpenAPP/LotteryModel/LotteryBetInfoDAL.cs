using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryModel
{
    public class LotteryBetInfoDAL
    {
        LotteryAPPEntities e;
        public BetInfo GetBetInfoById(int id) 
        {
            e = new LotteryAPPEntities();
            return e.BetInfo.Where(n => n.Id == id).FirstOrDefault();
        }
        public List<WS_BetInfoDgv> GetBetInfoList(int AccountId, int LotteryId, string Execpt,DateTime betTime)
        {
            using (e = new LotteryAPPEntities())
            {
                //游戏。奖期。玩法。赔率。方案。注单金额。开奖号码。状态。中奖金额。操作
                var query = (from a in e.BetInfo
                            from b in e.Accounts
                            from c in e.Lotterys
                            from d in e.LotteryPlays
                             where a.LotteryExcept == Execpt && a.LotteryId == LotteryId &&
                               a.CreateTime >= betTime && a.AccountId==AccountId&&
                               a.AccountId == b.Id && a.LotteryId == c.Id && a.BetPlayTypeCode == d.LotteryPlayId&&c.LotteryType==d.LotteryType
                            select new WS_BetInfoDgv
                            {
                                AccountName = b.AccountName,
                                BackMoney = a.BackMoney,
                                BackTime = a.BackTime,
                                BetMoney = a.BetMoney,
                                BetNum = a.BetNum,
                                BetTimes = a.BetTimes,
                                BetUnit = a.BetUnit,
                                ChoicePosition = a.ChoicePosition,
                                CreateTime = a.CreateTime,
                                GetBackPercent = a.GetBackPercent,
                                IsGetBackPercent = a.IsGetBackPercent,
                                Id = a.Id,
                                LotteryExcept = a.LotteryExcept,
                                LotteryId = a.LotteryId,
                                LotteryName = c.LotteryName,
                                PlayName = d.LotteryPlayName,
                                ResultType = a.ResultType,
                                WinMoney = a.WinMoney,
                                WinUnit = a.WinUnit,
                            }).ToList();
                if (query.Count>0)
                {
                    query.ForEach(n=>n.ResultTypeStr=EnumTool.GetBetResultType(n.ResultType));
                    var open = e.LotteryOpenInfo.FirstOrDefault(n => n.LotteryId == LotteryId && n.Expect == Execpt);
                    if (open != null)
                    {
                        query.ForEach(n => n.OpenCode = open.OpenCode);
                    } 
                }
                return query;
            }
        }
        public List<WS_BetInfoDgv> GetBetInfoList(int AccountId, int? LotteryId, DateTime StartTime, DateTime EndTime, int? ResultType, string BetInfoId, bool isIncludeChaseNumber)
        {
            EndTime = EndTime.Date.AddDays(1);
            StartTime = StartTime.Date;
            using (e = new LotteryAPPEntities())
            {
                //var betInfo=e.BetInfo.AsEnumerable();
                //var lotterys = e.Lotterys.AsEnumerable();
                //if(!string.IsNullOrEmpty(BetInfoId))
                //{
                //    long No=0;
                //    if(long.TryParse(BetInfoId,out No))
                //    betInfo=betInfo.Where(n=>n.Id==No);
                //}
                //if(!isIncludeChaseNumber)
                //{
                //    betInfo=betInfo.Where(n=>n.IsAddNum.HasValue&&n.IsAddNum==false);
                //}
                //if(ResultType.HasValue)
                //{
                //    betInfo=betInfo.Where(n=>n.ResultType==ResultType.Value);
                //}
                var query = (from a in e.BetInfo
                             from b in e.Accounts
                             from c in e.Lotterys
                             from d in e.LotteryPlays
                             where
                               a.CreateTime >= StartTime && a.CreateTime <=EndTime&&a.AccountId==AccountId&&
                               a.AccountId == b.Id && a.LotteryId == c.Id && a.BetPlayTypeCode == d.LotteryPlayId && c.LotteryType == d.LotteryType
                               select new {a,b,c,d});
                if(LotteryId.HasValue)
                {
                    query=query.Where(n=>n.a.LotteryId == LotteryId);
                }
                if(!string.IsNullOrEmpty(BetInfoId))
                {
                    long No=0;
                    if(long.TryParse(BetInfoId,out No))
                    query=query.Where(n=>n.a.Id==No);
                }
                if(!isIncludeChaseNumber)
                {
                    query=query.Where(n=>string.IsNullOrEmpty(n.a.AddNumNo));
                }
                if(ResultType.HasValue)
                {
                    query=query.Where(n=>n.a.ResultType==ResultType.Value);
                }
                var list=(from q in query
                         select new WS_BetInfoDgv
                             {
                                 AccountName = q.b.AccountName,
                                 BackMoney =q. a.BackMoney,
                                 BackTime = q.a.BackTime,
                                 BetMoney =q. a.BetMoney,
                                 BetNum = q.a.BetNum,
                                 BetTimes =q. a.BetTimes,
                                 BetUnit = q.a.BetUnit,
                                 ChoicePosition = q.a.ChoicePosition,
                                 CreateTime =q. a.CreateTime,
                                 GetBackPercent =q. a.GetBackPercent,
                                 IsGetBackPercent =q. a.IsGetBackPercent,
                                 Id = q.a.Id,
                                 LotteryExcept = q.a.LotteryExcept,
                                 LotteryId = q.a.LotteryId,
                                 LotteryName =q. c.LotteryName,
                                 PlayName = q.d.LotteryPlayName,
                                 ResultType =q. a.ResultType,
                                 WinMoney =q. a.WinMoney,
                                 WinUnit = q.a.WinUnit,
                                 IsChaseNumber = string.IsNullOrEmpty(q.a.AddNumNo) ? "否" : "是",
                             }).ToList();
                if (list.Count > 0)
                {
                    list.ForEach(n => n.ResultTypeStr = EnumTool.GetBetResultType(n.ResultType));
                }
                return list;
            }
        }
        public WS_BetInfoDgv GetBetInfo(long id) 
        {
            using (e = new LotteryAPPEntities())
            {
               
                var query = (from a in e.BetInfo
                             from b in e.Accounts
                             from c in e.Lotterys
                             from d in e.LotteryPlays
                             where a.AccountId == b.Id && a.LotteryId == c.Id && a.BetPlayTypeCode == d.LotteryPlayId &&
                             a.Id == id && c.LotteryType == d.LotteryType
                             select new WS_BetInfoDgv
                             {
                                 AccountName = b.AccountName,
                                 BackMoney = a.BackMoney,
                                 BackTime = a.BackTime,
                                 BetMoney = a.BetMoney,
                                 BetNum = a.BetNum,
                                 BetTimes = a.BetTimes,
                                 BetUnit = a.BetUnit,
                                 ChoicePosition = a.ChoicePosition,
                                 CreateTime = a.CreateTime,
                                 GetBackPercent = a.GetBackPercent,
                                 IsGetBackPercent = a.IsGetBackPercent,
                                 Id = a.Id,
                                 LotteryExcept = a.LotteryExcept,
                                 LotteryId=a.LotteryId,
                                 LotteryName = c.LotteryName,
                                 PlayName = d.LotteryPlayName,
                                 ResultType=a.ResultType,
                                 WinMoney = a.WinMoney,
                                 WinUnit = a.WinUnit,
                             }).FirstOrDefault();
                if (query!=null)
                {
                    query.ResultTypeStr = EnumTool.GetBetResultType(query.ResultType);
                    query.ChoicePosition = query.ChoicePosition.Replace("0", "万位").Replace("1", "千位").Replace("2", "百位").Replace("3", "十位").Replace("4", "个位");
                    var open = e.LotteryOpenInfo.FirstOrDefault(n => n.LotteryId == query.LotteryId && n.Expect == query.LotteryExcept);
                    if (open != null)
                    {
                        query.OpenCode = open.OpenCode;
                    } 
                }
                return query;
            }
        }

    }
}
