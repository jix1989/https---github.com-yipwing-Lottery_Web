using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryModel
{
    public static class EntitiesTool
    {
        static LotteryAPPEntities e = new LotteryAPPEntities();
        static Dictionary<string, Lotterys> LotteryDic = new Dictionary<string, Lotterys>();
        static Dictionary<string, List<LotteryPlays>> LotteryPlayDic = new Dictionary<string, List<LotteryPlays>>();
        static List<Lotterys> LotteryList = new List<Lotterys>();
        static List<LotteryPlays> LotteryPlayList = new List<LotteryPlays>();
        static List<Provinces> ProvincesList = new List<Provinces>();
        static List<Cities> CitiesList = new List<Cities>();
        /// <summary>
        /// 获取DB当前时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDateTimeNow(LotteryAPPEntities e)
        {
            try
            {
                var dt = e.Set<vie_NowTime>().Select(s => DateTime.Now).FirstOrDefault();
                if (dt == null)
                {
                    dt = DateTime.Now;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取DB当前时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDateTimeNow()
        {
            try
            {
                var dt = e.Set<vie_NowTime>().Select(s => DateTime.Now).FirstOrDefault();
                if (dt == null)
                {
                    dt = DateTime.Now;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取所有彩票种类
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Lotterys> GetLotteryDic()
        {
            try
            {

                if (LotteryDic.Count == 0)
                {
                    var query = e.Lotterys.ToList();
                    foreach (var item in query)
                    {
                        LotteryDic.Add(item.LotteryCode, new Lotterys
                        {
                            Id = item.Id,
                            BetweenMinute = item.BetweenMinute,
                            ExceptLength = item.ExceptLength,
                            ExceptOneDay = item.ExceptOneDay,
                            IsPrivate = item.IsPrivate,
                            LotteryCode = item.LotteryCode,
                            LotteryName = item.LotteryName,
                            LotteryType = item.LotteryType,
                            TimeEnd = item.TimeEnd,
                            TimeStart = item.TimeStart,
                        });
                    }
                }
                return LotteryDic;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<LotteryPlays> GetLotteryPlayList(string type)
        {
            if (LotteryPlayDic.Count == 0)
            {
                foreach (var item in e.LotteryPlays.ToList())
                {
                    if (!LotteryPlayDic.ContainsKey(item.LotteryType))
                    {
                        LotteryPlayDic.Add(item.LotteryType, new List<LotteryPlays>());
                    }
                    LotteryPlayDic[item.LotteryType].Add(item);
                }
            }
            return LotteryPlayDic[type];
        }

        public static List<Provinces> GetProvincesList()
        {
            if (ProvincesList.Count == 0)
            {
                using (e = new LotteryAPPEntities())
                {
                    ProvincesList = e.Provinces.ToList();
                }
            }
            return ProvincesList;
        }

        public static List<Cities> GetCitiesList()
        {
            if (CitiesList.Count == 0)
            {
                using (e = new LotteryAPPEntities())
                {
                    CitiesList = e.Cities.ToList();
                }
            }
            return CitiesList;
        }
        /// <summary>
        /// 递归获取所有关联上级
        /// </summary>
        /// <param name="AccountId"></param>
        /// <returns></returns>
        public static List<Accounts> GetAllParentAccount(int AccountId, LotteryAPPEntities e)
        {
            List<Accounts> listAccounts = null;
            listAccounts = e.Accounts.ToList();
            List<Accounts> list = new List<Accounts>();
            while (true)
            {
                var pId = listAccounts.FirstOrDefault(n => n.Id == AccountId);
                list.Add(pId);
                if (pId.AccountParentId == 0)
                {
                    break;
                }
                AccountId = pId.AccountParentId;
            }
            return list;
        }
        /// <summary>
        /// 获取所有彩票种类
        /// </summary>
        /// <returns></returns>
        public static List<Lotterys> GetLotteryList()
        {
            try
            {
                if (LotteryList.Count == 0)
                {
                    LotteryList = e.Lotterys.ToList();
                }
                return LotteryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取彩票玩法
        /// </summary>
        /// <returns></returns>
        public static List<LotteryPlays> GetLotteryPlayList()
        {
            try
            {
                if (LotteryPlayList.Count == 0)
                {
                    LotteryPlayList = e.LotteryPlays.ToList();
                }
                return LotteryPlayList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
