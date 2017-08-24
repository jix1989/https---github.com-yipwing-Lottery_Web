using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using LotteryModel;
namespace LotteryOffcialOpenApp
{
    public partial class FrmMainOffcial : Form
    {
        LotteryOpenDAL LotteryOpenDAL = new LotteryOpenDAL();
        LotteryOpenInfoDAL LotteryOffcialOpenDAL = new LotteryOpenInfoDAL();
        LotteryOpenOffcialInfoDAL LotteryOpenOffcialInfoDAL = new LotteryOpenOffcialInfoDAL();
        JsonSerializer serializer = new JsonSerializer();
        List<LotteryInfo> cqsscList = new List<LotteryInfo>();
        List<LotteryInfo> tjsscList = new List<LotteryInfo>();
        List<LotteryInfo> xjsscList = new List<LotteryInfo>();
        List<LotteryInfo> gdList = new List<LotteryInfo>();
        List<LotteryInfo> jxList = new List<LotteryInfo>();
        List<LotteryInfo> sdList = new List<LotteryInfo>();
        List<LotteryInfo> fcList = new List<LotteryInfo>();
        Dictionary<string, int> lotteryDic=new Dictionary<string,int>();
        /// <summary>
        /// 按最新查询（带下期）
        /// </summary>
        string newly = "newly.do";
        string newlyP = "?token=28bb85daaf56aa23&code={0}&extend=true&format=json&&rows=1";
        public FrmMainOffcial()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = !btnStart.Enabled;
            timer1_Tick(null, null);
            timer1.Start();
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = !btnStart.Enabled;
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "当前时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if(DateTime.Now.Hour>2&&DateTime.Now.Hour<8||DateTime.Now.Second>0)
            {
                button1_Click(null,null);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //isTimeBe(cbcq, cqsscList, new ThreadStart(bind_cqssc));
            //isTimeBe(cbtj, tjsscList, new ThreadStart(bind_tjssc));
            //isTimeBe(cbxj, xjsscList, new ThreadStart(bind_xjssc));
            //isTimeBe(cbgd, gdList, new ThreadStart(bind_gd11x5));
            //isTimeBe(cbjx, jxList, new ThreadStart(bind_jx11x5));
            //isTimeBe(cbsd, sdList, new ThreadStart(bind_sd11x5));
            //isTimeBe(cbfc, fcList, new ThreadStart(bind_fc3d));
            try
            {
                if (isTimeBe(cbcq, cqsscList)) bind_cqssc();
                if (isTimeBe(cbtj, tjsscList)) bind_tjssc();
                if (isTimeBe(cbxj, xjsscList)) bind_xjssc();
                if (isTimeBe(cbgd, gdList)) bind_gd11x5();
                if (isTimeBe(cbjx, jxList)) bind_jx11x5();
                if (isTimeBe(cbsd, sdList)) bind_sd11x5();
                if (isTimeBe(cbfc, fcList)) bind_fc3d();
            }
            catch (Exception ex)
            {
                logInfo(ex);
            }
        }

        private void FrmMainOffcial_Load(object sender, EventArgs e)
        {
            lotteryDic.Add("gd11x5", EntitiesTool.GetLotteryDic()["gd11x5"].Id);
            lotteryDic.Add("jx11x5", EntitiesTool.GetLotteryDic()["jx11x5"].Id);
            lotteryDic.Add("sd11x5", EntitiesTool.GetLotteryDic()["sd11x5"].Id);
            lotteryDic.Add("cqssc", EntitiesTool.GetLotteryDic()["cqssc"].Id);
            lotteryDic.Add("tjssc", EntitiesTool.GetLotteryDic()["tjssc"].Id);
            lotteryDic.Add("xjssc", EntitiesTool.GetLotteryDic()["xjssc"].Id);
            lotteryDic.Add("fc3d", EntitiesTool.GetLotteryDic()["fc3d"].Id);
        }
        //List<string> logList = new List<string>();
        void addLotteryInfo(List<LotteryInfo> list, string str,string code)
        {
            JArray ja = (JArray)JsonConvert.DeserializeObject(str);
            string ja1a = ja[0].ToString();
            StringReader sr = new StringReader(ja1a);
            var p1 = (LotteryInfo)serializer.Deserialize(new JsonTextReader(sr), typeof(LotteryInfo));
            var f = list.FirstOrDefault(n => n.expect == p1.expect);
            if (f == null)
            {
                list.Add(p1);
               //var ss=string.Format("{0},{1},{2},{3}", code, p1.expect, p1.opencode, p1.opentime);
                //logList.Add(ss);
                dgvLog.Rows.Insert(0, new DataGridViewRow());
                var rows = dgvLog.Rows[0];
                rows.Cells[0].Value = code;
                rows.Cells[1].Value = p1.expect;
                rows.Cells[2].Value = p1.opencode;
                rows.Cells[3].Value = p1.opentime;
            }
            else
            {
                f.opencode = p1.opencode;
                f.opentime = p1.opentime;
                for (int i = 0; i < dgvLog.RowCount; i++)
                {
                    if (dgvLog.Rows[i].Cells[0].Value.ToString() == code &&dgvLog.Rows[i].Cells[1].Value.ToString() == p1.expect)
                    {
                        dgvLog.Rows[i].Cells[2].Value = p1.opencode;
                        dgvLog.Rows[i].Cells[3].Value = p1.opentime;
                    }
                }
            }
        }

        void bindGgv(string code, List<LotteryInfo> list, DataGridView dgv)
        {
            try
            {
                var jo = JsonHelper.GetFunction(newly, string.Format(newlyP, code));
                addLotteryInfo(list, jo["next"].ToString(),code);
                addLotteryInfo(list, jo["open"].ToString(),code);
                dgv.DataSource = list.OrderByDescending(n => n.expect).ToList();
            }
            catch (Exception ex)
            {
                logInfo(ex);
            }

        }
        /// <summary>
        /// 到时更新
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        bool isTimeBe(CheckBox cb, List<LotteryInfo> list)
        {
            bool flag = false;
            if (list.Count > 0 && cb.Checked)
            {
                var maxDt = Convert.ToDateTime(list.Where(n=>string.IsNullOrEmpty(n.opencode)).Min(n => n.opentime));
                flag = DateTime.Now > maxDt;
            }
            else if (list.Count == 0 && cb.Checked)
            {
                flag = true;
            }
            return flag;
        }

        void bind_cqssc()
        {
            bindGgv("cqssc", cqsscList, dgvcqssc);
            LotteryOffcialOpenDAL.Add(cqsscList.Select(n => new LotteryOpenInfo { LotteryId = lotteryDic["cqssc"], Expect = n.expect, OpenCode = n.opencode == null ? "" : n.opencode, OpenTime = Convert.ToDateTime(n.opentime), OpenDate = Convert.ToDateTime(n.opentime).Date }).ToList());
        }
        void bind_tjssc()
        {
            bindGgv("tjssc", tjsscList, dgvtjssc);
            LotteryOffcialOpenDAL.Add(tjsscList.Select(n => new LotteryOpenInfo { LotteryId = lotteryDic["tjssc"], Expect = n.expect, OpenCode = n.opencode == null ? "" : n.opencode, OpenTime = Convert.ToDateTime(n.opentime), OpenDate = Convert.ToDateTime(n.opentime).Date }).ToList());
        }
        void bind_xjssc()
        {
            bindGgv("xjssc", xjsscList, dgvxjssc);
            LotteryOffcialOpenDAL.Add(xjsscList.Select(n => new LotteryOpenInfo { LotteryId = lotteryDic["xjssc"], Expect = n.expect, OpenCode = n.opencode == null ? "" : n.opencode, OpenTime = Convert.ToDateTime(n.opentime), OpenDate = Convert.ToDateTime(n.opentime).Date }).ToList());
        }
        void bind_gd11x5()
        {
            bindGgv("gd11x5", gdList, dgvgd);
            LotteryOffcialOpenDAL.Add(gdList.Select(n => new LotteryOpenInfo { LotteryId = lotteryDic["gd11x5"], Expect = n.expect, OpenCode = n.opencode == null ? "" : n.opencode, OpenTime = Convert.ToDateTime(n.opentime), OpenDate = Convert.ToDateTime(n.opentime).Date }).ToList());
        }
        void bind_jx11x5()
        {
            bindGgv("jx11x5", jxList, dgvjx);
            LotteryOffcialOpenDAL.Add(jxList.Select(n => new LotteryOpenInfo { LotteryId = lotteryDic["jx11x5"], Expect = n.expect, OpenCode = n.opencode == null ? "" : n.opencode, OpenTime = Convert.ToDateTime(n.opentime), OpenDate = Convert.ToDateTime(n.opentime).Date }).ToList());
        }
        void bind_sd11x5()
        {
            bindGgv("sd11x5", sdList, dgvsd);
            LotteryOffcialOpenDAL.Add(sdList.Select(n => new LotteryOpenInfo { LotteryId = lotteryDic["sd11x5"], Expect = n.expect, OpenCode = n.opencode == null ? "" : n.opencode, OpenTime = Convert.ToDateTime(n.opentime), OpenDate = Convert.ToDateTime(n.opentime).Date }).ToList());
        }
        void bind_fc3d()
        {
            bindGgv("fc3d", fcList, dgvfc);
            LotteryOffcialOpenDAL.Add(fcList.Select(n => new LotteryOpenInfo { LotteryId = lotteryDic["fc3d"], Expect = n.expect, OpenCode = n.opencode == null ? "" : n.opencode, OpenTime = Convert.ToDateTime(n.opentime), OpenDate = Convert.ToDateTime(n.opentime).Date }).ToList());
        }

        void isTimeBe(CheckBox cb, List<LotteryInfo> list, ThreadStart ts)
        {
            bool flag = false;
            if (list.Count > 0 && cb.Checked)
            {
                var maxDt = Convert.ToDateTime(list.Max(n => n.opentime));
                flag = DateTime.Now > maxDt;
            }
            else if (list.Count == 0)
            {
                flag = true;
            }
            if (flag)
            {
                try
                {
                    Thread t = new Thread(ts);
                    t.Start();
                    t.Join();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void FrmMainOffcial_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                notifyIcon1.Visible = true;
            }
            else 
            {
                notifyIcon1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var i = DateTime.Now.Second % 10;
            if (i>0&&i<=6)
            {
                LotteryOpenOffcialInfoDAL.InitialTodayInfo(EntitiesTool.GetLotteryDic().Values.FirstOrDefault(n => n.Id == i)); 
            }
        }
        void logInfo(Exception ex) 
        {
            var path = "log";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllText(path + "/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt", ex.Message); 
        }
    }
    class LotteryInfo
    {
        public string expect { get; set; }
        public string opencode { get; set; }
        public string opentime { get; set; }
    }
}
