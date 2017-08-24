using LotteryOnHookAPP.JIX_SR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace LotteryOnHookAPP
{
    public static class Tools
    {
        public static WebService1SoapClient client = new WebService1SoapClient();
        public static string ToMD5(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile("A1.@a%2DFA" + str, "MD5");
        }
        public static string GetJm()
        {
            return ToMD5(DateTime.Now.Date.Date.Ticks.ToString());
        }
        public static string AddZero(object obj,int Length) 
        {
            var str = obj.ToString();
            while(str.Length<Length)
            {
               str=str.Insert(0, "0");
            }
            return str;
        }
    }
}
