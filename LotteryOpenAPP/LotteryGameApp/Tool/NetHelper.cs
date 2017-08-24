using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;

namespace LotteryGameApp
{
    public static class NetHelper
    {
        /// <summary>
        /// 获取内网IP
        /// </summary>
        /// <returns></returns>
        public static string GetInternalIP()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
        ///// <summary>
        ///// 获取外网IP
        ///// </summary>
        ///// <returns></returns>
        //public static string GetExternalIP()
        //{
        //    string tempip = "";
        //    try
        //    {
        //        WebRequest wr = WebRequest.Create("http://www.ip138.com/ips138.asp");
        //        Stream s = wr.GetResponse().GetResponseStream();
        //        StreamReader sr = new StreamReader(s, Encoding.UTF8);
        //        string all = sr.ReadToEnd(); //读取网站的数据

        //        int start = all.IndexOf("您的IP地址是：[") + 9;
        //        int end = all.IndexOf("]", start);
        //        tempip = all.Substring(start, end - start);
        //        sr.Close();
        //        s.Close();
        //    }
        //    catch
        //    {
        //    }
        //    string tempIP = string.Empty;
        //    if (System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.Length > 1) 
        //    {
        //        var ipHE = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        //        tempIP = ipHE.AddressList[1].ToString();
        //    }

        //    return tempIP;
        //}

        /// <summary>
        /// 获取ping百度的Value
        /// </summary>
        /// <returns></returns>
        public static string GetPingValue()
        {
            //远程服务器IP  
            string ipStr = "www.baidu.com";
            //构造Ping实例  
            Ping pingSender = new Ping();
            //Ping 选项设置  
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            //测试数据  
            string data = "test";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            //设置超时时间  
            int timeout = 1000;
            //调用同步 send 方法发送数据,将返回结果保存至PingReply实例  
            PingReply reply = pingSender.Send(ipStr, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                return reply.RoundtripTime.ToString();
            }
            else
            {
                return null;
            }

        }
    }

  
}
