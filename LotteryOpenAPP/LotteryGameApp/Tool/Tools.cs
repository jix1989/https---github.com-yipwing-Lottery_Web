using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using log4net.Config;
using System.Windows.Forms;
using System.Collections.Generic;
using LotteryModel;
namespace LotteryGameApp
{
    public static class Tools
    {
        #region 更新配置文件
        /// <summary>
        /// 更新配置文件
        /// </summary>
        /// <param name="str"></param>
        public static void UpdateConfig(string key, string str)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //添加
            if (!cfa.AppSettings.Settings.AllKeys.Contains(key))
            {
                cfa.AppSettings.Settings.Add(key, str);
            }
            else
            {
                //修改
                cfa.AppSettings.Settings[key].Value = str;
            }
            //最后调用 
            cfa.Save();
            //当前的配置文件更新成功。
        }
        #endregion

        #region 加密相关
        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        //加密密钥
        private static string encryptKey = "jixjx007";
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }
        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }
        #endregion

        #region 获取本机网卡MAC
        /// <summary>
        /// 获取本机网卡Mac
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddressByNetworkInformation()
        {
            string key = "SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\";
            string macAddress = string.Empty;
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in nics)
                {
                    if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                        && adapter.GetPhysicalAddress().ToString().Length != 0)
                    {
                        string fRegistryKey = key + adapter.Id + "\\Connection";
                        RegistryKey rk = Registry.LocalMachine.OpenSubKey(fRegistryKey, false);
                        if (rk != null)
                        {
                            string fPnpInstanceID = rk.GetValue("PnpInstanceID", "").ToString();
                            int fMediaSubType = Convert.ToInt32(rk.GetValue("MediaSubType", 0));
                            if (fPnpInstanceID.Length > 3 &&
                                fPnpInstanceID.Substring(0, 3) == "PCI")
                            {
                                macAddress = adapter.GetPhysicalAddress().ToString();
                                for (int i = 1; i < 6; i++)
                                {
                                    macAddress = macAddress.Insert(3 * i - 1, ":");
                                }
                                break;
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                //
            }
            return macAddress;
        }
        #endregion

        public static void InitLog4Net()
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "app.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
            //logger.Warn("警告");
            //logger.Error("异常");
            //logger.Fatal("错误");
        }
        /// <summary>
        /// 创建程序所需文件夹
        /// </summary>
        /// <param name="Dirs"></param>
        public static void CreateDir(params string[] Dirs)
        {
            foreach (var item in Dirs)
            {
                var path = Application.StartupPath + "/" + item;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
        /// <summary>
        /// 创建程序所需文件夹
        /// </summary>
        /// <param name="Dir"></param>
        public static void CreateDir(string Dir)
        {
            var path = Application.StartupPath + "/" + Dir;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

        }
        /// <summary>
        /// 创建程序所需文件
        /// </summary>
        /// <param name="Dir"></param>
        public static void CreateFile(string FileName, string txt)
        {
            var path = Application.StartupPath + "/" + FileName;
            if (!File.Exists(path))
            {
                File.WriteAllText(path, txt, Encoding.UTF8);
            }
            else
            {
                File.AppendAllText(path, "\r\n" + txt);
            }
        }
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="Dir"></param>
        public static List<string> ReadFile(string FileName)
        {
            var path = Application.StartupPath + "/" + FileName;
            if (File.Exists(path))
            {
                return File.ReadAllLines(path, Encoding.UTF8).ToList();
            }
            return null;
        }
        /// <summary>
        /// 修改文件
        /// </summary>
        /// <param name="Dir"></param>
        public static bool EditFile(string FileName, List<string> strs)
        {
            var path = Application.StartupPath + "/" + FileName;
            if (File.Exists(path))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < strs.Count; i++)
                {
                    sb.Append(strs[i]+(i!=strs.Count-1?"\r\n":""));
                }
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 验证null和errCode值是否为八个0
        /// </summary>
        /// <param name="ErrCode"></param>
        /// <returns></returns>
        public static bool IsErr0(object obj,string ErrCode) 
        {
            return obj!=null&&ErrCode == "00000000";
        }
        /// <summary>
        /// 设置窗体样式
        /// </summary>
        public static void SetForm(Form f) 
        {
            f.FormBorderStyle = FormBorderStyle.FixedSingle;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowInTaskbar = false;
            f.Icon = global::LotteryGameApp.Properties.Resources.icon;
        }

        public static void ShowFailMsg(string Txt,string errCode) 
        {
            var msg = Txt+"失败！";
            //if (ErrorDic.dic.Keys.FirstOrDefault(n => n == errCode) != null)
            //{
            //    msg += "【" + ErrorDic.dic[errCode] + "】";
            //}
            MessageBox.Show(msg);
        }

        public static void BindCbo(List<CboItem> list,ComboBox cbo)
        {
            cbo.DataSource = list;
            cbo.DisplayMember = "Name";
            cbo.ValueMember = "Id";
            cbo.SelectedIndex = 0;
        }
    }

}
