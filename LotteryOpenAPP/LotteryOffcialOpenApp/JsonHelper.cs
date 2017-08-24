using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Configuration;
namespace LotteryOffcialOpenApp
{
    public class JsonHelper
    {
        /// <summary>
        /// API地址
        /// </summary>
        static string ServerUrl = ConfigurationManager.AppSettings["API"];
        //get方法调用接口获取json文件内容
        public static JObject GetFunction(string Method, string StrContent)
        {
            //"?token=28bb85daaf56aa23&code=cqssc&format=json&extend=true"
            var request = (HttpWebRequest)WebRequest.Create(ServerUrl + Method + StrContent);//请求对象
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            var response = (HttpWebResponse)request.GetResponse();//响应对象
            //StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);//响应对象流
            string retString = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();//获取响应文本
            //myStreamReader.Close();
            //myResponseStream.Close();
            //Rsponse.Write(retString);
            //JsonReader reader = new JsonTextReader(new StringReader(retString));
            //List<string> sts = new List<string>();
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader.TokenType + "\t\t" + reader.ValueType + "\t\t" + reader.Value);
            //    sts.Add(Convert.ToString(reader.Value));
            //}
            //return sts[0];
            //解析json
            JObject jo = JObject.Parse(retString);
            return jo;

        }
        ////post方法调用接口获取json文件内容
        public static string PostFunction(string Method, string StrContent)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ServerUrl + Method);

            request.Method = "POST";
            request.ContentType = "application/json";
            //string strContent = @"{""MemberCode"":""Steven"",""MemberPw"":""123456"",""BrowserVersion"":""IE"",""IPAddress"":""192.168.10.31""}";
            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(StrContent);
                dataStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            //解析json
            JObject jo = JObject.Parse(retString);
            return jo.ToString();
        }
        /// <summary>
        /// 获取json解析object对象
        /// </summary>
        /// <param name="Method"></param>
        /// <param name="StrContent"></param>
        /// <returns></returns>
        public static object GetObject(string Method, string StrContent, Type t)
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(PostFunction(Method, StrContent));
            return serializer.Deserialize(new JsonTextReader(sr), t);
        }

        public static JsonSerializer GetJosnSerializer(string Method, string StrContent)
        {
            var str = JsonHelper.PostFunction(Method, StrContent);
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(str);
            return serializer;
        }
        /// <summary>
        /// 对象转json参数
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string GetRegJsonParameters(object p)
        {
            JsonSerializer serializer = new JsonSerializer();
            StringWriter sw = new StringWriter();
            serializer.Serialize(new JsonTextWriter(sw), p);
            return sw.GetStringBuilder().ToString();
        }
    }
}
