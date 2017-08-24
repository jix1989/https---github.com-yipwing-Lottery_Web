using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LotteryModel
{
    public class LotteryOpenTool_SSC
    {
        /// <summary>
        /// 判断当期奖金是否超额
        /// </summary>
        public static bool isOutBetMoney(List<BetInfo> BetList, List<int> openCode, bool isLimit, decimal betTotalMoney, decimal abTotalMoney, decimal Prizepool, out decimal backTotalMoney)
        {
            var flag = false;
            List<int> h4 = openCode.ToList(); h4.RemoveAt(0);//四星
            List<int> h3 = openCode.ToList(); h3.RemoveRange(0, 2);//后三
            List<int> z3 = openCode.ToList(); z3.RemoveAt(4); z3.RemoveAt(0);//中三
            List<int> q3 = openCode.ToList(); q3.RemoveRange(3, 2);//前三
            List<int> h2 = openCode.ToList(); h2.RemoveRange(0, 3);//后二
            List<int> q2 = openCode.ToList(); q2.RemoveRange(2, 3);//前二
            int dan = openCode.Count(n => n % 2 == 1);//单号个数
            int da = openCode.Count(n => n > 5);//大号个数
            List<ZXLB> zxlbList = null;
            int bjh = LotteryPlayArithmetic.pd(openCode, out zxlbList);//百家号开奖号类别(120,60,30.....)
            backTotalMoney = 0;//总返奖金额
            foreach (var item in BetList)
            {
                List<int> rxdswz = null; decimal BackMoney = 0;
                if (!string.IsNullOrEmpty(item.ChoicePosition)) rxdswz = item.ChoicePosition.Split(',').Select(n => Convert.ToInt32(n)).ToList();//存在选号位(任选类型)
                item.WinUnit = isWin(item.BetPlayTypeCode, item.BetNum, rxdswz, openCode, h4, h3, z3, q3, h2, q2, dan, da, bjh, zxlbList, out BackMoney);//中奖次数
                if (item.WinUnit > 0)
                {
                    if (!item.IsGetBackPercent)//若不要返点
                    {
                        item.BackMoney = AgentCalculateTool.GetAgentBackMoney_SSC(BackMoney, item.GetBackPercent);
                    }
                    item.BackMoney = item.BackMoney * (item.BetMoney / item.BetUnit / 2);//(item.BetMoney /item.BetUnit/2)=投注单位(元角分厘)*倍数=中奖金额倍数
                    backTotalMoney += item.BackMoney;
                    if (isLimit)//是否按限制开奖
                    {
                        flag = backTotalMoney > (betTotalMoney - abTotalMoney) + (Prizepool < new decimal(0.1) * betTotalMoney ? 0 : Prizepool - new decimal(0.1) * betTotalMoney);
                        if (flag)
                        {
                            break;
                        }
                    }
                }
            }
            return flag;
        }
        static int[] TSHPlayId = { 22, 23, 24, 25, 39, 53, 57, 92, 93, 94, 95 };
        /// <summary>
        /// 开奖判断
        /// </summary>
        /// <param name="rxdswz">任选单式位置</param>
        /// <returns></returns>
        public static int isWin(int BetPlayTypeCode, string betNum, List<int> rxdswz, List<int> openCode, List<int> h4, List<int> h3, List<int> z3, List<int> q3, List<int> h2, List<int> q2, int dan, int da, int bjh, List<ZXLB> zxlbList, out decimal BackMoney)
        {
            if (TSHPlayId.Contains(BetPlayTypeCode))
            {
                betNum = MyTool.ChangeBetNumTSH(betNum);
            }
            int winTimes = 0;
            BackMoney = 0;
            var b1 = new List<List<int>>();//投注号
            //if (BetPlayTypeCode == 1)
            //{
               
            //}
            //else
            if (!LotteryInfo_SSC.LpList().FirstOrDefault(n => n.BetPlayTypeCode == BetPlayTypeCode).LotteryPlayName.Contains("单式"))
            {
                //b1 = betNum.Split('|').Select(
                //        n => n.Split(' ').Select(w => Convert.ToInt32(w)).ToList()
                //        ).ToList();
                if (betNum.IndexOf('|') > -1)
                {
                    foreach (var item in betNum.Split('|'))
                    {
                        if (item.Length > 0)
                        {
                            b1.Add(item.Split(' ').Select(w => Convert.ToInt32(w)).ToList());
                        }
                        else
                        {
                            b1.Add(null);
                        }
                    }
                }
                else 
                {
                    b1.Add(betNum.Split(' ').Select(w => Convert.ToInt32(w)).ToList());
                }
            }
            switch (BetPlayTypeCode)
            {
                #region 定位胆
                case 1://定位胆
                    rxzxfs(b1, out winTimes, openCode, 1);//任选1中1
                    break;
                #endregion
                #region 五星
                case 2://五星直选复式
                    winTimes = b1[0].Contains(openCode[0]) && b1[1].Contains(openCode[1]) && b1[2].Contains(openCode[2]) && b1[3].Contains(openCode[3]) && b1[4].Contains(openCode[4]) ? 1 : 0;
                    break;
                case 3://五星直选单式
                    winTimes = betNum.Contains(string.Format("{0}{1}{2}{3}{4}", openCode[0], openCode[1], openCode[2], openCode[3], openCode[4])) ? 1 : 0;
                    break;
                case 4://五星直选组合
                    Zxzh(BetPlayTypeCode, b1, out winTimes, out BackMoney, openCode);
                    break;
                case 5://五星组选120(全不同号)
                    if (bjh == 120)
                    {
                        winTimes = zxpd(zxlbList, 5, 0, 1, 0, b1[0], null) ? 1 : 0;
                    }
                    break;
                case 6://五星组选60(一对)
                    if (bjh == 60)
                    {
                        winTimes = zxpd(zxlbList, 2, 3, 2, 1, b1[0], b1[1]) ? 1 : 0;
                    }
                    break;
                case 7://五星组选30(两对)
                    if (bjh == 30)
                    {
                        winTimes = zxpd(zxlbList, 4, 1, 2, 1, b1[0], b1[1]) ? 1 : 0;
                    }
                    break;
                case 8://五星组选20(三条)
                    if (bjh == 20)
                    {
                        winTimes = zxpd(zxlbList, 3, 2, 3, 1, b1[0], b1[1]) ? 1 : 0;
                    }
                    break;
                case 9://五星组选10(三带二)
                    if (bjh == 10)
                    {
                        winTimes = zxpd(zxlbList, 3, 2, 3, 2, b1[0], b1[1]) ? 1 : 0;
                    }
                    break;
                case 10://五星组选5(四条)
                    if (bjh == 5)
                    {
                        winTimes = zxpd(zxlbList, 4, 1, 4, 1, b1[0], b1[1]) ? 1 : 0;
                    }
                    break;
                case 11://五星一帆风顺
                case 12://五星好事成双
                case 13://五星三星报喜
                case 14://五星四季发财
                    winTimes = wxts(b1, zxlbList, BetPlayTypeCode - 10);
                    break;
                #endregion
                #region 四星
                case 15://四星直选复式
                    winTimes = b1[0].Contains(openCode[1]) && b1[1].Contains(openCode[2]) && b1[2].Contains(openCode[3]) && b1[3].Contains(openCode[4]) ? 1 : 0;
                    break;
                case 16://四星直选单式
                    winTimes = betNum.Contains(string.Format("{0}{1}{2}{3}", openCode[1], openCode[2], openCode[3], openCode[4])) ? 1 : 0;
                    break;
                case 17://四星直选组合
                    Zxzh(BetPlayTypeCode, b1, out winTimes, out BackMoney, h4);
                    break;
                case 18://四星组选24(全不同号)
                    if (LotteryPlayArithmetic.pd(h4, out zxlbList) == 24)
                    {
                        winTimes = zxpd(zxlbList, 4, 0, 1, 0, b1[0], null) ? 1 : 0;
                    }
                    break;
                case 19://四星组选12(一对)
                    if (LotteryPlayArithmetic.pd(h4, out zxlbList) == 12)
                    {
                        winTimes = zxpd(zxlbList, 2, 2, 2, 1, b1[0], b1[1]) ? 1 : 0;
                    }
                    break;
                case 20://四星组选6(两对)
                    if (LotteryPlayArithmetic.pd(h4, out zxlbList) == 6)
                    {
                        winTimes = zxpd(zxlbList, 4, 0, 2, 0, b1[0], null) ? 1 : 0;
                    }
                    break;
                case 21://四星组选4(三条)
                    if (LotteryPlayArithmetic.pd(h4, out zxlbList) == 4)
                    {
                        winTimes = zxpd(zxlbList, 3, 1, 3, 1, b1[0], b1[1]) ? 1 : 0;
                    }
                    break;
                #endregion
                #region 百家
                case 22://百家重复号
                    foreach (var item in b1[0])
                    {
                        if (bjh >= 0)
                        {
                            switch (item)
                            {
                                case 120://单号
                                    if (bjh == item) winTimes++; BackMoney += LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[item];
                                    break;
                                case 60://一对
                                    if (bjh <= item) winTimes++; BackMoney += LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[item];
                                    break;
                                case 30://两对
                                    if (bjh <= item && bjh != 20) winTimes++; BackMoney += LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[item];
                                    break;
                                case 20://三条
                                    if (bjh <= item) winTimes++; BackMoney += LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[item];
                                    break;
                                case 10://三带二
                                    if (bjh <= item && bjh != 5) winTimes++; BackMoney += LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[item];
                                    break;
                                case 5://四条
                                    if (bjh <= item) winTimes++; BackMoney += LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[item];
                                    break;
                            }
                        }
                    }
                    break;
                case 23://百家顺子号
                    if (bjh == 120)
                    {
                        winTimes = 1;
                        openCode = openCode.OrderBy(n => n).ToList();
                        for (int i = 1; i < openCode.Count; i++)
                        {
                            if (openCode[i] - openCode[i - 1] != 1)
                            {
                                winTimes = 0;
                                break;
                            }
                        }
                    }
                    break;
                case 24://百家单双号
                    if (b1[0].Contains(dan))
                    {
                        winTimes = 1; BackMoney = LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[dan];
                    }
                    break;
                case 25://百家大小号
                    if (b1[0].Contains(da))
                    {
                        winTimes = 1; BackMoney = LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[da];
                    }
                    break;
                #endregion
                #region 后三
                case 26://后三直选复式
                    winTimes = b1[0].Contains(openCode[2]) && b1[1].Contains(openCode[3]) && b1[2].Contains(openCode[4]) ? 1 : 0;
                    break;
                case 27://后三直选单式
                    winTimes = betNum.Contains(string.Format("{0}{1}{2}", openCode[2], openCode[3], openCode[4])) ? 1 : 0;
                    break;
                case 28://后三直选组合
                    Zxzh(BetPlayTypeCode, b1, out winTimes, out BackMoney, h3);
                    break;
                case 29://后三直选和值
                    winTimes = b1[0].Contains(openCode[2] + openCode[3] + openCode[4]) ? 1 : 0;
                    break;
                case 30://后三直选跨度
                    winTimes = b1[0].Contains(h3.Max() - h3.Min()) ? 1 : 0;
                    break;
                case 31://后三组三复式
                    winTimes = LotteryPlayArithmetic.zxfs(b1, zxlbList, 3, 2, h3);
                    break;
                case 32://后三组三单式
                    winTimes = LotteryPlayArithmetic.zxds(betNum, zxlbList, 3, h3);
                    break;
                case 33://后三组六复式
                    winTimes = LotteryPlayArithmetic.zxfs(b1, zxlbList, 6, 3, h3);
                    break;
                case 34://后三组六单式
                    winTimes = LotteryPlayArithmetic.zxds(betNum, zxlbList, 6, h3);
                    break;
                case 35://后三混合组选
                    LotteryPlayArithmetic.hshhzx(BetPlayTypeCode, betNum, zxlbList, out winTimes, out BackMoney, h3);
                    break;
                case 36://后三组选和值
                    LotteryPlayArithmetic.hszxhz(BetPlayTypeCode, b1, zxlbList, out winTimes, out BackMoney, h3);
                    break;
                case 37://后三组选包胆
                    hszxbd(BetPlayTypeCode, b1, zxlbList, out winTimes, out BackMoney, h3);
                    break;
                case 38://后三和值尾数
                    winTimes = b1[0].Contains((openCode[2] + openCode[3] + openCode[4]) % 10) ? 1 : 0;
                    break;
                case 39://后三特殊号
                    hstsh(BetPlayTypeCode, b1, zxlbList, out winTimes, out BackMoney, h3);
                    break;
                #endregion
                #region 中三
                case 40://中三直选复式
                    winTimes = b1[0].Contains(openCode[1]) && b1[1].Contains(openCode[2]) && b1[2].Contains(openCode[3]) ? 1 : 0;
                    break;
                case 41://中三直选单式
                    winTimes = betNum.Contains(string.Format("{0}{1}{2}", openCode[1], openCode[2], openCode[3])) ? 1 : 0;
                    break;
                case 42://中三直选组合
                    Zxzh(BetPlayTypeCode, b1, out winTimes, out BackMoney, z3);
                    break;
                case 43://中三直选和值
                    winTimes = b1[0].Contains(openCode[1] + openCode[2] + openCode[3]) ? 1 : 0;
                    break;
                case 44://中三直选跨度
                    winTimes = b1[0].Contains(z3.Max() - z3.Min()) ? 1 : 0;
                    break;
                case 45://中三组三复式
                    winTimes = LotteryPlayArithmetic.zxfs(b1, zxlbList, 3, 2, z3);
                    break;
                case 46://中三组三单式
                    winTimes = LotteryPlayArithmetic.zxds(betNum, zxlbList, 3, z3);
                    break;
                case 47://中三组六复式
                    winTimes = LotteryPlayArithmetic.zxfs(b1, zxlbList, 6, 3, z3);
                    break;
                case 48://中三组六单式
                    winTimes = LotteryPlayArithmetic.zxds(betNum, zxlbList, 6, z3);
                    break;
                case 49://中三混合组选
                    LotteryPlayArithmetic.hshhzx(BetPlayTypeCode, betNum, zxlbList, out winTimes, out BackMoney, z3);
                    break;
                case 50://中三组选和值
                    LotteryPlayArithmetic.hszxhz(BetPlayTypeCode, b1, zxlbList, out winTimes, out BackMoney, z3);
                    break;
                case 51://中三组选包胆
                    hszxbd(BetPlayTypeCode, b1, zxlbList, out winTimes, out BackMoney, z3);
                    break;
                case 52://中三和值尾数
                    winTimes = b1[0].Contains((openCode[1] + openCode[2] + openCode[3]) % 10) ? 1 : 0;
                    break;
                case 53://中三特殊号
                    hstsh(BetPlayTypeCode, b1, zxlbList, out winTimes, out BackMoney, z3);
                    break;
                #endregion
                #region 前三
                case 54://前三直选复式
                    winTimes = b1[0].Contains(openCode[0]) && b1[1].Contains(openCode[1]) && b1[2].Contains(openCode[2]) ? 1 : 0;
                    break;
                case 55://前三直选单式
                    winTimes = betNum.Contains(string.Format("{0}{1}{2}", openCode[0], openCode[1], openCode[2])) ? 1 : 0;
                    break;
                case 56://前三直选组合
                    Zxzh(BetPlayTypeCode, b1, out winTimes, out BackMoney, q3);
                    break;
                case 57://前三直选和值
                    winTimes = b1[0].Contains(openCode[0] + openCode[1] + openCode[2]) ? 1 : 0;
                    break;
                case 58://前三直选跨度
                    winTimes = b1[0].Contains(q3.Max() - q3.Min()) ? 1 : 0;
                    break;
                case 59://前三组三复式
                    winTimes = LotteryPlayArithmetic.zxfs(b1, zxlbList, 3, 2, q3);
                    break;
                case 60://前三组三单式
                    winTimes = LotteryPlayArithmetic.zxds(betNum, zxlbList, 3, q3);
                    break;
                case 61://前三组六复式
                    winTimes = LotteryPlayArithmetic.zxfs(b1, zxlbList, 6, 3, q3);
                    break;
                case 62://前三组六单式
                    winTimes = LotteryPlayArithmetic.zxds(betNum, zxlbList, 6, q3);
                    break;
                case 63://前三混合组选
                    LotteryPlayArithmetic.hshhzx(BetPlayTypeCode, betNum, zxlbList, out winTimes, out BackMoney, q3);
                    break;
                case 64://前三组选和值
                    LotteryPlayArithmetic.hszxhz(BetPlayTypeCode, b1, zxlbList, out winTimes, out BackMoney, q3);
                    break;
                case 65://前三组选包胆
                    hszxbd(BetPlayTypeCode, b1, zxlbList, out winTimes, out BackMoney, q3);
                    break;
                case 66://前三和值尾数
                    winTimes = b1[0].Contains((openCode[0] + openCode[1] + openCode[2]) % 10) ? 1 : 0;
                    break;
                case 67://前三特殊号
                    hstsh(BetPlayTypeCode, b1, zxlbList, out winTimes, out BackMoney, q3);
                    break;
                #endregion
                #region 后二
                case 68://后二直选复式
                    winTimes = b1[0].Contains(openCode[3]) && b1[1].Contains(openCode[4]) ? 1 : 0;
                    break;
                case 69://后二直选单式
                    winTimes = betNum.Contains(string.Format("{0}{1}", openCode[3], openCode[4])) ? 1 : 0;
                    break;
                case 70://后二直选和值
                    winTimes = b1[0].Contains(openCode[3] + openCode[4]) ? 1 : 0;
                    break;
                case 71://后二直选跨度
                    winTimes = b1[0].Contains(Math.Abs(openCode[3] - openCode[4])) ? 1 : 0;
                    break;
                case 72://后二组选复式
                    winTimes = LotteryPlayArithmetic.zxfs(b1, zxlbList, 1, 2, h2);
                    break;
                case 73://后二组选单式
                    winTimes = LotteryPlayArithmetic.zxds(betNum, zxlbList, 1, h2);
                    break;
                case 74://后二组选和值
                    h2zxhz(b1, out winTimes, h2);
                    break;
                case 75://后二组选包胆
                    h2zxbd(b1, out winTimes, h2);
                    break;
                #endregion
                #region 前二
                case 76://前二直选复式
                    winTimes = b1[0].Contains(openCode[0]) && b1[1].Contains(openCode[1]) ? 1 : 0;
                    break;
                case 77://前二直选单式
                    winTimes = betNum.Contains(string.Format("{0}{1}", openCode[0], openCode[1])) ? 1 : 0;
                    break;
                case 78://前二直选和值
                    winTimes = b1[0].Contains(openCode[0] + openCode[1]) ? 1 : 0;
                    break;
                case 79://前二直选跨度
                    winTimes = b1[0].Contains(Math.Abs(openCode[0] - openCode[1])) ? 1 : 0;
                    break;
                case 80://前二组选复式
                    winTimes = LotteryPlayArithmetic.zxfs(b1, zxlbList, 1, 2, q2);
                    break;
                case 81://前二组选单式
                    winTimes = LotteryPlayArithmetic.zxds(betNum, zxlbList, 1, q2);
                    break;
                case 82://前二组选和值
                    h2zxhz(b1, out winTimes, q2);
                    break;
                case 83://前二组选包胆
                    h2zxbd(b1, out winTimes, q2);
                    break;
                #endregion
                #region 不定位
                case 84://后三一码
                    winTimes = LotteryPlayArithmetic.bdw(b1, 1, h3);
                    break;
                case 85://前三一码
                    winTimes = LotteryPlayArithmetic.bdw(b1, 1, q3);
                    break;
                case 86://后三二码
                    winTimes = LotteryPlayArithmetic.bdw(b1, 2, h3);
                    break;
                case 87://前三二码
                    winTimes = LotteryPlayArithmetic.bdw(b1, 2, q3);
                    break;
                case 88://四星一码
                    winTimes = LotteryPlayArithmetic.bdw(b1, 1, h4);
                    break;
                case 89://四星二码
                    winTimes = LotteryPlayArithmetic.bdw(b1, 2, h4);
                    break;
                case 90://五星二码
                    winTimes = LotteryPlayArithmetic.bdw(b1, 2, openCode);
                    break;
                case 91://五星三码
                    winTimes = LotteryPlayArithmetic.bdw(b1, 3, openCode);
                    break;
                #endregion
                #region 大(6)小(5)单(1)双(0)
                case 92://前二大小单双
                    winTimes = LotteryPlayArithmetic.pd_dxds(openCode[0], b1[0]) && LotteryPlayArithmetic.pd_dxds(openCode[1], b1[1]) ? 1 : 0;
                    break;
                case 93://后二大小单双
                    winTimes = LotteryPlayArithmetic.pd_dxds(openCode[3], b1[0]) && LotteryPlayArithmetic.pd_dxds(openCode[4], b1[1]) ? 1 : 0;
                    break;
                case 94://前三大小单双
                    winTimes = LotteryPlayArithmetic.pd_dxds(openCode[0], b1[0]) && LotteryPlayArithmetic.pd_dxds(openCode[1], b1[1]) && LotteryPlayArithmetic.pd_dxds(openCode[2], b1[2]) ? 1 : 0;
                    break;
                case 95://后三大小单双
                    winTimes = LotteryPlayArithmetic.pd_dxds(openCode[2], b1[0]) && LotteryPlayArithmetic.pd_dxds(openCode[3], b1[1]) && LotteryPlayArithmetic.pd_dxds(openCode[4], b1[2]) ? 1 : 0;
                    break;
                #endregion
                #region 任选二
                case 96://任选二直选复式
                    rxzxfs(b1, out winTimes, openCode, 2);
                    break;
                case 97://任选二直选单式
                    rxzxds(betNum, rxdswz, out winTimes, openCode, 2);
                    break;
                case 98://任选二直选和值
                    foreach (var item in pl_rx(rxdswz, 2))
                    {
                        winTimes += b1[0].Contains(openCode[item[0]] + openCode[item[1]]) ? 1 : 0;
                    }
                    break;
                case 99://任选二组选复式
                    foreach (var item in pl_rx(rxdswz, 2))
                    {
                        winTimes += (openCode[item[0]] != openCode[item[1]]) && b1[0].Contains(openCode[item[0]]) && b1[0].Contains(openCode[item[1]]) ? 1 : 0;
                    }
                    break;
                case 100://任选二组选单式
                    foreach (var item in pl_rx(rxdswz, 2))
                    {
                        var rxzhCode = "";
                        winTimes += (pd_rxzh(rxzhCode, openCode[item[0]], openCode[item[1]]) == 1) && betNum.Contains(rxzhCode) ? 1 : 0;
                    }
                    break;
                case 101://任选二组选和值
                    foreach (var item in pl_rx(rxdswz, 2))
                    {
                        winTimes += (openCode[item[0]] != openCode[item[1]]) && b1[0].Contains(openCode[item[0]] + openCode[item[1]]) ? 1 : 0;
                    }
                    break;
                #endregion
                #region 任选三
                case 102://任选三直选复式
                    rxzxfs(b1, out winTimes, openCode, 3);
                    break;
                case 103://任选三直选单式
                    rxzxds(betNum, rxdswz, out winTimes, openCode, 3);
                    break;
                case 104://任选三直选和值
                    foreach (var item in pl_rx(rxdswz, 3))
                    {
                        winTimes += b1[0].Contains(openCode[item[0]] + openCode[item[1]] + openCode[item[2]]) ? 1 : 0;
                    }
                    break;
                case 105://任选三组三复式
                    foreach (var item in pl_rx(rxdswz, 3))
                    {
                        winTimes += (pd_rxzh("", openCode[item[0]], openCode[item[1]], openCode[item[2]]) == 3) && b1[0].Contains(openCode[item[0]]) && b1[0].Contains(openCode[item[1]]) && b1[0].Contains(openCode[item[2]]) ? 1 : 0;
                    }
                    break;
                case 106://任选三组三单式
                    foreach (var item in pl_rx(rxdswz, 3))
                    {
                        var rxzhCode = "";
                        winTimes += (pd_rxzh(rxzhCode, openCode[item[0]], openCode[item[1]], openCode[item[2]]) == 3) && betNum.Contains(rxzhCode) ? 1 : 0;
                    }
                    break;
                case 107://任选三组六复式
                    foreach (var item in pl_rx(rxdswz, 3))
                    {
                        winTimes += (pd_rxzh("", openCode[item[0]], openCode[item[1]], openCode[item[2]]) == 6) && b1[0].Contains(openCode[item[0]]) && b1[0].Contains(openCode[item[1]]) && b1[0].Contains(openCode[item[2]]) ? 1 : 0;
                    }
                    break;
                case 108://任选三组六单式
                    foreach (var item in pl_rx(rxdswz, 3))
                    {
                        var rxzhCode = "";
                        winTimes += (pd_rxzh(rxzhCode, openCode[item[0]], openCode[item[1]], openCode[item[2]]) == 6) && betNum.Contains(rxzhCode) ? 1 : 0;
                    }
                    break;
                case 109://任选三混合组选
                    foreach (var item in pl_rx(rxdswz, 3))
                    {
                        var rxzhCode = "";
                        var lb1 = pd_rxzh(rxzhCode, openCode[item[0]], openCode[item[1]], openCode[item[2]]);
                        if (lb1 > 0)
                        {
                            winTimes += betNum.Contains(rxzhCode) ? 1 : 0;
                            BackMoney += LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[lb1];
                        }
                    }
                    break;
                case 110://任选三组选和值
                    foreach (var item in pl_rx(rxdswz, 3))
                    {
                        var lb1 = pd_rxzh("", openCode[item[0]], openCode[item[1]], openCode[item[2]]);
                        if (lb1 > 0)
                        {
                            winTimes += b1[0].Contains(openCode[item[0]] + openCode[item[1]] + openCode[item[2]]) ? 1 : 0;
                            BackMoney += LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[lb1];
                        }
                    }
                    break;
                #endregion
                #region 任选四
                case 111://任选四直选复式
                    rxzxfs(b1, out winTimes, openCode, 4);
                    break;
                case 112://任选四直选单式
                    rxzxds(betNum, rxdswz, out winTimes, openCode, 4);
                    break;
                case 113://任选四组选24
                    rszx(b1, rxdswz, openCode, zxlbList, 24, out winTimes);
                    break;
                case 114://任选四组选12
                    rszx(b1, rxdswz, openCode, zxlbList, 12, out winTimes);
                    break;
                case 115://任选四组选6
                    rszx(b1, rxdswz, openCode, zxlbList, 6, out winTimes);
                    break;
                case 116://任选四组选4
                    rszx(b1, rxdswz, openCode, zxlbList, 4, out winTimes);
                    break;
                #endregion
            }
            //不具有奖级玩法类型的中奖金额
            if (LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass == null)
            {
                BackMoney = winTimes * LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PayBack;
            }
            return winTimes;
        }

        #region 判断方法
        /// <summary>
        /// 判断任选号位置，返回升序位置索引集合
        /// </summary>
        /// <param name="rxdswz"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<List<int>> pl_rx(List<int> rxdswz, int count)
        {
            List<string> strList = new List<string>();
            List<List<int>> list = new List<List<int>>();
            switch (count)
            {
                case 2:
                    foreach (var item in (from a in rxdswz
                                          from b in rxdswz
                                          where a != b
                                          select new { a, b }))
                    {
                        var l = new List<int>();
                        l.Add(item.a);
                        l.Add(item.b);
                        l = l.OrderBy(n => n).ToList();
                        var str = l[0] + "," + l[1];
                        if (!strList.Contains(str))
                        {
                            strList.Add(str);
                            list.Add(l);
                        }
                    }
                    break;
                case 3:
                    foreach (var item in (from a in rxdswz
                                          from b in rxdswz
                                          from c in rxdswz
                                          where a != b && b != c
                                          select new { a, b, c }))
                    {
                        var l = new List<int>();
                        l.Add(item.a);
                        l.Add(item.b);
                        l.Add(item.c);
                        l = l.OrderBy(n => n).ToList();
                        var str = l[0] + "," + l[1] + "," + l[2];
                        if (!strList.Contains(str))
                        {
                            strList.Add(str);
                            list.Add(l);
                        }
                    }
                    break;
                case 4:
                    foreach (var item in (from a in rxdswz
                                          from b in rxdswz
                                          from c in rxdswz
                                          from d in rxdswz
                                          where a != b && b != c && c != d
                                          select new { a, b, c, d }))
                    {
                        var l = new List<int>();
                        l.Add(item.a);
                        l.Add(item.b);
                        l.Add(item.c);
                        l.Add(item.d);
                        l = l.OrderBy(n => n).ToList();
                        var str = l[0] + "," + l[1] + "," + l[2] + "," + l[3];
                        if (!strList.Contains(str))
                        {
                            strList.Add(str);
                            list.Add(l);
                        }
                    }
                    break;
            }
            return list;
        }
        #endregion
        #region 通用算法
        /// <summary>
        /// 五星特殊
        /// </summary>
        /// <returns></returns>
        public static int wxts(List<List<int>> b1, List<ZXLB> zxlbList, int sp)
        {
            return (from a in b1[0]
                    from b in zxlbList.Where(n => n.NumType >= sp).GroupBy(n => new { n.NumType, n.NumValue })
                    where a == b.Key.NumValue
                    select a).Count();
        }
        /// <summary>
        /// 直选组合
        /// </summary>
        public static void Zxzh(int BetPlayTypeCode, List<List<int>> b1, out int winTimes, out decimal BackMoney, List<int> openCode)
        {
            winTimes = 0;
            BackMoney = 0;
            for (int i = 1; i <= openCode.Count; i++)
            {
                if (b1[openCode.Count - i].Contains(openCode[openCode.Count - i]))
                {
                    winTimes++;
                    BackMoney += LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[i];
                }
            }
        }
        /// <summary>
        /// 组选复式中奖判断
        /// </summary>
        public static bool zxpd(List<ZXLB> zxlbList, int b1Count, int b2Count, int b1Type, int b2Type, List<int> b1, List<int> b2)
        {
            var flag = (from a in b1
                        from b in zxlbList.Where(n => n.NumType == b1Type)
                        where a == b.NumValue
                        select a).Count() == b1Count;
            if (flag && b2 != null)
            {
                flag = (from a in b2
                        from b in zxlbList.Where(n => n.NumType == b2Type)
                        where a == b.NumValue
                        select a).Count() == b2Count;
            }
            return flag;
        }
        #endregion
        #region 三位号玩法
        /// <summary>
        /// 后三组选包胆
        /// </summary>
        public static void hszxbd(int BetPlayTypeCode, List<List<int>> b1, List<ZXLB> zxlbList, out int winTimes, out decimal BackMoney, List<int> openCode)
        {
            winTimes = 0; BackMoney = 0; var lb = LotteryPlayArithmetic.pd(openCode, out zxlbList);
            if (lb > 0)
            {
                winTimes = openCode.Contains(b1[0][0]) ? 1 : 0;
                BackMoney = winTimes * LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[lb];
            }
        }
        /// <summary>
        /// 后三特殊号
        /// </summary>
        public static void hstsh(int BetPlayTypeCode, List<List<int>> b1, List<ZXLB> zxlbList, out int winTimes, out decimal BackMoney, List<int> openCode)
        {
            winTimes = 0; BackMoney = 0; var lb = LotteryPlayArithmetic.pd(openCode, out zxlbList);
            if (lb == 6 && b1[0].Contains(1))
            {
                var list = openCode.OrderBy(n => n).ToList();
                winTimes = 1;
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i] - list[0] != 1)
                    {
                        winTimes = 0;
                        break;
                    }
                }
            } //顺子1
            else if (lb == 3 && b1[0].Contains(2))//对子2
            {
                winTimes = 1;
            }
            else if (lb == 0 && b1[0].Contains(3))//豹子3
            {
                winTimes = 1;
            }
            switch (lb)
            {
                case 6:
                    lb = 1;
                    break;
                case 3:
                    lb = 2;
                    break;
                case 0:
                    lb = 3;
                    break;
            }
            BackMoney = winTimes * LotteryInfo_SSC.LpList()[BetPlayTypeCode - 1].PrizeClass[lb];
        }
        #endregion
        #region 两位号玩法
        /// <summary>
        /// 后二组选和值
        /// </summary>
        public static void h2zxhz(List<List<int>> b1, out int winTimes, List<int> openCode)
        {
            winTimes = 0;
            if (openCode[0] != openCode[1])
            {
                winTimes = b1[0].Contains(openCode[0] + openCode[1]) ? 1 : 0;
            }
        }
        /// <summary>
        /// 后二组选包胆
        /// </summary>
        public static void h2zxbd(List<List<int>> b1, out int winTimes, List<int> openCode)
        {
            winTimes = 0;
            if (openCode[0] != openCode[1])
            {
                winTimes = openCode.Contains(b1[0][0]) ? 1 : 0;
            }
        }
        #endregion
        #region 任选玩法
        /// <summary>
        /// 任选直选复式
        /// </summary>
        public static void rxzxfs(List<List<int>> b1, out int winTimes, List<int> openCode, int zhongCount)
        {
            winTimes = 0;
            for (int i = 0; i < openCode.Count; i++)
            {
                if(i>=b1.Count)
                {
                    break;
                }
                //if (i<b1.Count-1&& b1[i] != null)
                if (b1[i] != null)
                {
                    winTimes += b1[i].Contains(openCode[i]) ? 1 : 0;
                }
            }
            if (zhongCount > 1)
            {
                if (winTimes >= zhongCount)
                {
                    winTimes = MyTool.CalculateCombination(zhongCount, winTimes);
                }
                else
                {
                    winTimes = 0;
                }
            }
        }
        /// <summary>
        /// 任选直选单式
        /// </summary>
        public static void rxzxds(string betNum, List<int> rxdswz, out int winTimes, List<int> openCode, int zhongCount)
        {
            var rxlist = pl_rx(rxdswz, zhongCount); winTimes = 0;
            foreach (var item in rxlist)
            {
                var str = "";
                for (int i = 0; i < zhongCount; i++)
                {
                    str += openCode[item[i]];
                }
                winTimes += betNum.Contains(str) ? 1 : 0;
            }
        }
        /// <summary>
        /// 任四组选
        /// </summary>
        public static void rszx(List<List<int>> b1, List<int> rxdswz, List<int> openCode, List<ZXLB> zxlbList, int zxlb, out int winTimes)
        {
            winTimes = 0;
            foreach (var item in pl_rx(rxdswz, 4))
            {
                var newCode = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    newCode.Add(openCode[item[i]]);
                }
                var lb = LotteryPlayArithmetic.pd(newCode, out zxlbList);
                if (lb == zxlb)
                {
                    switch (lb)
                    {
                        case 24:
                            winTimes += zxpd(zxlbList, 4, 0, 1, 0, b1[0], null) ? 1 : 0;
                            break;
                        case 12:
                            winTimes += zxpd(zxlbList, 2, 2, 2, 1, b1[0], b1[1]) ? 1 : 0;
                            break;
                        case 6:
                            winTimes += zxpd(zxlbList, 4, 0, 2, 0, b1[0], null) ? 1 : 0;
                            break;
                        case 4:
                            winTimes += zxpd(zxlbList, 3, 1, 3, 1, b1[0], b1[1]) ? 1 : 0;
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// 任选组选单式
        /// </summary>
        public static int pd_rxzh(string rxzhCode, params int[] openCode)
        {
            foreach (var item in openCode.OrderBy(n => n))
            {
                rxzhCode += item;
            }
            if (openCode.Length == 3)
            {
                var i0 = openCode.Count(n => n == openCode[0]);
                var i1 = openCode.Count(n => n == openCode[1]);
                var i2 = openCode.Count(n => n == openCode[2]);
                if (i0 + i1 + i2 == 3)
                {
                    return 6;
                }
                if (i0 + i1 + i2 == 5)
                {
                    return 3;
                }
                if (i0 + i1 + i2 == 9)
                {
                    return 0;
                }
            }
            if (openCode.Length == 2)
            {
                return openCode[0] != openCode[1] ? 1 : 2;
            }

            return -1;
        }
        #endregion
    }
}
