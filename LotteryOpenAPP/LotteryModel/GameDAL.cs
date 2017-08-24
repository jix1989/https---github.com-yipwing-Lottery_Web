using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryModel
{
    public class GameDAL
    {
        LotteryAPPEntities e;
        public List<BetInfo> GetBetList(int AccountId, DateTime DtStart, DateTime DtEnd, int? Status, int? GameId, int BetId, bool IsZH) 
        {
            e = new LotteryAPPEntities();
            
                DtStart=DtStart.Date;
                DtEnd=DtEnd.Date.AddDays(1);
                var query = e.BetInfo.Where(n => n.AccountId == AccountId && n.CreateTime >= DtStart && n.CreateTime < DtEnd);
                if(Status.HasValue)
                {
                    query = query.Where(n => n.ResultType == Status);
                }
                if(GameId.HasValue)
                {
                    query = query.Where(n => n.LotteryOpenInfo.LotteryId == GameId);
                }
                if (BetId!=0) 
                {
                    query = query.Where(n => n.Id == BetId);
                }
                return query.ToList();
        }
    }
}
