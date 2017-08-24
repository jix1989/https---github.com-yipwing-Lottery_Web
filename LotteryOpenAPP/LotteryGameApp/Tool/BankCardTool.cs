using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LotteryModel;
namespace LotteryGameApp
{
    public class BankCardTool
    {
        static List<CboItem> BankList;
        static List<CboItem> ProvinceList;
        static List<City> CityList;
        public static void BindBank(ComboBox cbo)
        {
            if (BankList == null)
            {
                int i = 0;
                BankList = new List<CboItem>();
                BankList.Add(new CboItem { Id = ++i, Name = "中国工商银行" });
                BankList.Add(new CboItem { Id = ++i, Name = "中国农业银行" });
                BankList.Add(new CboItem { Id = ++i, Name = "中国建设银行" });
                BankList.Add(new CboItem { Id = ++i, Name = "中国招商银行" });
                BankList.Add(new CboItem { Id = ++i, Name = "中国民生银行" });
                BankList.Add(new CboItem { Id = ++i, Name = "中国银行" });
                BankList.Add(new CboItem { Id = ++i, Name = "交通银行" });
                BankList.Add(new CboItem { Id = ++i, Name = "邮政储蓄银行" });
                BankList.Add(new CboItem { Id = ++i, Name = "光大银行" });
                BankList.Add(new CboItem { Id = ++i, Name = "兴业银行" });
                BankList.Add(new CboItem { Id = ++i, Name = "浦发银行" });
                BankList.Add(new CboItem { Id = ++i, Name = "广发银行" });
                BankList.Add(new CboItem { Id = ++i, Name = "中信银行" });
                BankList.Add(new CboItem { Id = ++i, Name = "华夏银行" });
            }
            bindCbo(cbo, BankList);
        }

        public static void BindProvince(ComboBox cbo)
        {
            if (ProvinceList == null)
            {
                ProvinceList = new List<CboItem>();
                ProvinceList.Add(new CboItem { Id = 1, Name = "北京市" });
                ProvinceList.Add(new CboItem { Id = 2, Name = "上海市" });
                ProvinceList.Add(new CboItem { Id = 3, Name = "天津市" });
                ProvinceList.Add(new CboItem { Id = 4, Name = "重庆市" });
                ProvinceList.Add(new CboItem { Id = 5, Name = "内蒙古自治区" });
                ProvinceList.Add(new CboItem { Id = 6, Name = "山西省" });
                ProvinceList.Add(new CboItem { Id = 7, Name = "河北省" });
                ProvinceList.Add(new CboItem { Id = 8, Name = "辽宁省" });
                ProvinceList.Add(new CboItem { Id = 9, Name = "吉林省" });
                ProvinceList.Add(new CboItem { Id = 10, Name = "黑龙江省" });
                ProvinceList.Add(new CboItem { Id = 11, Name = "江苏省" });
                ProvinceList.Add(new CboItem { Id = 12, Name = "安徽省" });
                ProvinceList.Add(new CboItem { Id = 13, Name = "山东省" });
                ProvinceList.Add(new CboItem { Id = 14, Name = "浙江省" });
                ProvinceList.Add(new CboItem { Id = 15, Name = "江西省" });
                ProvinceList.Add(new CboItem { Id = 16, Name = "福建省" });
                ProvinceList.Add(new CboItem { Id = 17, Name = "湖南省" });
                ProvinceList.Add(new CboItem { Id = 18, Name = "湖北省" });
                ProvinceList.Add(new CboItem { Id = 19, Name = "河南省" });
                ProvinceList.Add(new CboItem { Id = 20, Name = "广东省" });
                ProvinceList.Add(new CboItem { Id = 21, Name = "海南省" });
                ProvinceList.Add(new CboItem { Id = 22, Name = "广西壮族自治区" });
                ProvinceList.Add(new CboItem { Id = 23, Name = "贵州省" });
                ProvinceList.Add(new CboItem { Id = 24, Name = "四川省" });
                ProvinceList.Add(new CboItem { Id = 25, Name = "云南省" });
                ProvinceList.Add(new CboItem { Id = 26, Name = "陕西省" });
                ProvinceList.Add(new CboItem { Id = 27, Name = "甘肃省" });
                ProvinceList.Add(new CboItem { Id = 28, Name = "宁夏回族自治区" });
                ProvinceList.Add(new CboItem { Id = 29, Name = "青海省" });
                ProvinceList.Add(new CboItem { Id = 30, Name = "新疆维吾尔自治区" });
                ProvinceList.Add(new CboItem { Id = 31, Name = "西藏自治区" });
            }
            bindCbo(cbo, ProvinceList);
           


        }

        public static void BindCity(ComboBox cbo, int ProvinceId)
        {
            if (CityList == null)
            {
                int i = 0;
                CityList = new List<City>();
                addCity(1, ++i, "北京市");
                addCity(2, ++i, "上海市");
                addCity(3, ++i, "天津市");
                addCity(4, ++i, "重庆市");
                #region 内蒙古自治区
                addCity(5, ++i, "呼和浩特市");
                addCity(5, ++i, "包头市");
                addCity(5, ++i, "乌海市");
                addCity(5, ++i, "赤峰市");
                addCity(5, ++i, "丰镇市");
                addCity(5, ++i, "锡林浩特市");
                addCity(5, ++i, "二连浩特市");
                addCity(5, ++i, "满洲里市");
                addCity(5, ++i, "牙克石市");
                addCity(5, ++i, "扎兰屯市");
                addCity(5, ++i, "通辽市");
                addCity(5, ++i, "霍林郭勒市");
                addCity(5, ++i, "乌兰浩特市");
                addCity(5, ++i, "鄂尔多斯市");
                addCity(5, ++i, "呼伦贝尔市");
                addCity(5, ++i, "巴彦淖尔市");
                addCity(5, ++i, "乌兰察布市");
                addCity(5, ++i, "兴安盟");
                addCity(5, ++i, "锡林郭勒盟");
                addCity(5, ++i, "阿拉善盟");
                addCity(5, ++i, "根河市");
                addCity(5, ++i, "额尔古纳市");
                addCity(5, ++i, "阿尔山市");
                #endregion
                #region 山西省
                addCity(6, ++i, "大同市");
                addCity(6, ++i, "太原市");
                addCity(6, ++i, "阳泉市");
                addCity(6, ++i, "长治市");
                addCity(6, ++i, "晋城市");
                addCity(6, ++i, "朔州市");
                addCity(6, ++i, "古交市");
                addCity(6, ++i, "忻州市");
                addCity(6, ++i, "临汾市"); 
                addCity(6, ++i, "霍州市"); 
                addCity(6, ++i, "运城市"); 
                addCity(6, ++i, "潞城市");
                addCity(6, ++i, "高平市");
                addCity(6, ++i, "原平市");
                addCity(6, ++i, "介休市");
                addCity(6, ++i, "汾阳市");
                addCity(6, ++i, "孝义市");
                addCity(6, ++i, "河津市");
                addCity(6, ++i, "永济市");
                addCity(6, ++i, "侯马市");
                addCity(6, ++i, "晋中市");
                addCity(6, ++i, "吕梁市");
                #endregion
                #region 河北省
                addCity(7, ++i, "石家庄市");
                addCity(7, ++i, "邯郸市");
                addCity(7, ++i, "保定市");
                addCity(7, ++i, "张家口市");
                addCity(7, ++i, "承德市");
                addCity(7, ++i, "唐山市");
                addCity(7, ++i, "秦皇岛市");
                addCity(7, ++i, "沧州市");
                addCity(7, ++i, "廊坊市");
                addCity(7, ++i, "武安市");
                addCity(7, ++i, "霸州市");
                addCity(7, ++i, "泊头市");
                addCity(7, ++i, "任丘市");
                addCity(7, ++i, "黄骅市");
                addCity(7, ++i, "河间市");
                addCity(7, ++i, "衡水市");
                addCity(7, ++i, "迁安市");
                addCity(7, ++i, "遵化市");
                addCity(7, ++i, "三河市");
                addCity(7, ++i, "定州市");
                addCity(7, ++i, "安国市");
                addCity(7, ++i, "涿州市");
                addCity(7, ++i, "高碑店市");
                addCity(7, ++i, "辛集市");
                addCity(7, ++i, "晋州市");
                addCity(7, ++i, "藁城市");
                addCity(7, ++i, "新乐市");
                addCity(7, ++i, "南宫市");
                addCity(7, ++i, "冀州市");
                addCity(7, ++i, "深州市");
                #endregion
                #region 辽宁省
                addCity(8, ++i, "沈阳市");
                addCity(8, ++i, "大连市");
                addCity(8, ++i, "鞍山市");
                addCity(8, ++i, "抚顺市");
                addCity(8, ++i, "本溪市");
                addCity(8, ++i, "丹东市");
                addCity(8, ++i, "锦州市");
                addCity(8, ++i, "葫芦岛市");
                addCity(8, ++i, "营口市");
                addCity(8, ++i, "阜新市");
                addCity(8, ++i, "辽阳市");
                addCity(8, ++i, "铁岭市");
                addCity(8, ++i, "瓦房店市");
                addCity(8, ++i, "海城市");
                addCity(8, ++i, "兴城市");
                addCity(8, ++i, "调兵山市");
                addCity(8, ++i, "北票市");
                addCity(8, ++i, "开原市");
                addCity(8, ++i, "新民市");
                addCity(8, ++i, "庄河市");
                addCity(8, ++i, "凤城市");
                addCity(8, ++i, "北镇市");
                addCity(8, ++i, "灯塔市");
                addCity(8, ++i, "凌源市");
                addCity(8, ++i, "盘锦市");
                addCity(8, ++i, "盖州市");
                addCity(8, ++i, "东港市");
                addCity(8, ++i, "普兰店市");
                addCity(8, ++i, "临海市");
                addCity(8, ++i, "大石桥市");
                #endregion
                #region 吉林省
                addCity(9, ++i, "长春市");
                addCity(9, ++i, "吉林市");
                addCity(9, ++i, "四平市");
                addCity(9, ++i, "辽源市");
                addCity(9, ++i, "通化市");
                addCity(9, ++i, "公主岭市");
                addCity(9, ++i, "梅河口市");
                addCity(9, ++i, "集安市");
                addCity(9, ++i, "九台市");
                addCity(9, ++i, "桦甸市");
                addCity(9, ++i, "蛟河市");
                addCity(9, ++i, "榆树市");
                addCity(9, ++i, "白城市");
                addCity(9, ++i, "洮南市");
                addCity(9, ++i, "大安市");
                addCity(9, ++i, "延吉市");
                addCity(9, ++i, "图们市");
                addCity(9, ++i, "敦化市");
                addCity(9, ++i, "龙井市");
                addCity(9, ++i, "珲春市");
                addCity(9, ++i, "德惠市");
                addCity(9, ++i, "磐石市");
                addCity(9, ++i, "舒兰市");
                addCity(9, ++i, "双辽市");
                addCity(9, ++i, "和龙市");
                addCity(9, ++i, "白山市");
                addCity(9, ++i, "松原市");
                addCity(9, ++i, "临江市");
                addCity(9, ++i, "延边朝鲜族自治州");
                #endregion
                #region 黑龙江省
                addCity(10, ++i, "哈尔滨市");
                addCity(10, ++i, "齐齐哈尔市");
                addCity(10, ++i, "鹤岗市");
                addCity(10, ++i, "双鸭山市");
                addCity(10, ++i, "鸡西市");
                addCity(10, ++i, "大庆市");
                addCity(10, ++i, "伊春市");
                addCity(10, ++i, "牡丹江市");
                addCity(10, ++i, "佳木斯市");
                addCity(10, ++i, "七台河市");
                addCity(10, ++i, "绥芬河市");
                addCity(10, ++i, "同江市");
                addCity(10, ++i, "富锦市");
                addCity(10, ++i, "铁力市");
                addCity(10, ++i, "密山市");
                addCity(10, ++i, "绥化市");
                addCity(10, ++i, "安达市");
                addCity(10, ++i, "肇东市");
                addCity(10, ++i, "海伦市");
                addCity(10, ++i, "黑河市");
                addCity(10, ++i, "北安市");
                addCity(10, ++i, "五大连池市");
                addCity(10, ++i, "尚志市");
                addCity(10, ++i, "双城市");
                addCity(10, ++i, "讷河市");
                addCity(10, ++i, "海林市");
                addCity(10, ++i, "穆棱市");
                addCity(10, ++i, "虎林市");
                addCity(10, ++i, "宁安市");
                addCity(10, ++i, "五常市");
                addCity(10, ++i, "大兴安岭地区");
                #endregion
                #region 江苏省
                addCity(11, ++i, "南京市");
                addCity(11, ++i, "徐州市");
                addCity(11, ++i, "连云港市");
                addCity(11, ++i, "盐城市");
                addCity(11, ++i, "扬州市");
                addCity(11, ++i, "南通市");
                addCity(11, ++i, "镇江市");
                addCity(11, ++i, "常州市");
                addCity(11, ++i, "无锡市");
                addCity(11, ++i, "苏州市");
                addCity(11, ++i, "泰州市");
                addCity(11, ++i, "仪征市");
                addCity(11, ++i, "常熟市");
                addCity(11, ++i, "张家港市");
                addCity(11, ++i, "江阴市");
                addCity(11, ++i, "宿迁市");
                addCity(11, ++i, "丹阳市");
                addCity(11, ++i, "东台市");
                addCity(11, ++i, "兴化市");
                addCity(11, ++i, "淮安市");
                addCity(11, ++i, "宜兴市");
                addCity(11, ++i, "昆山市");
                addCity(11, ++i, "启东市");
                addCity(11, ++i, "新沂市");
                addCity(11, ++i, "溧阳市");
                addCity(11, ++i, "大丰市");
                addCity(11, ++i, "泰兴市");
                addCity(11, ++i, "江都市");
                addCity(11, ++i, "靖江市");
                addCity(11, ++i, "高邮市");
                addCity(11, ++i, "如皋市");
                addCity(11, ++i, "海门市");
                addCity(11, ++i, "句容市");
                addCity(11, ++i, "扬中市");
                addCity(11, ++i, "金坛市");
                addCity(11, ++i, "吴江市");
                addCity(11, ++i, "太仓市");
                addCity(11, ++i, "通州市");
                addCity(11, ++i, "邳州市");
                addCity(11, ++i, "姜堰市");
                #endregion
                #region 安徽省
                addCity(12, ++i, "合肥市");
                addCity(12, ++i, "淮南市");
                addCity(12, ++i, "淮北市");
                addCity(12, ++i, "芜湖市");
                addCity(12, ++i, "铜陵市");
                addCity(12, ++i, "蚌埠市");
                addCity(12, ++i, "马鞍山市");
                addCity(12, ++i, "安庆市");
                addCity(12, ++i, "黄山市");
                addCity(12, ++i, "宿州市");
                addCity(12, ++i, "滁州市");
                addCity(12, ++i, "巢湖市");
                addCity(12, ++i, "六安市");
                addCity(12, ++i, "阜阳市");
                addCity(12, ++i, "毫州市");
                addCity(12, ++i, "界首市");
                addCity(12, ++i, "桐城市");
                addCity(12, ++i, "天长市");
                addCity(12, ++i, "宁国市");
                addCity(12, ++i, "明光市");
                addCity(12, ++i, "宣城市");
                addCity(12, ++i, "池州市");
                #endregion
                #region 山东省
                addCity(13, ++i, "济南市");
                addCity(13, ++i, "青岛市");
                addCity(13, ++i, "淄博市");
                addCity(13, ++i, "枣庄市");
                addCity(13, ++i, "东营市");
                addCity(13, ++i, "烟台市");
                addCity(13, ++i, "威海市");
                addCity(13, ++i, "济宁市");
                addCity(13, ++i, "泰安市");
                addCity(13, ++i, "日照市");
                addCity(13, ++i, "青州市");
                addCity(13, ++i, "龙口市");
                addCity(13, ++i, "曲阜市");
                addCity(13, ++i, "莱芜市");
                addCity(13, ++i, "新泰市");
                addCity(13, ++i, "胶州市");
                addCity(13, ++i, "诸城市");
                addCity(13, ++i, "莱阳市");
                addCity(13, ++i, "莱州市");
                addCity(13, ++i, "滕州市");
                addCity(13, ++i, "文登市");
                addCity(13, ++i, "荣成市");
                addCity(13, ++i, "即墨市");
                addCity(13, ++i, "平度市");
                addCity(13, ++i, "莱西市");
                addCity(13, ++i, "胶南市");
                addCity(13, ++i, "德州市");
                addCity(13, ++i, "乐陵市");
                addCity(13, ++i, "滨州市");
                addCity(13, ++i, "临沂市");
                addCity(13, ++i, "聊城市");
                addCity(13, ++i, "临清市");
                addCity(13, ++i, "章丘市");
                addCity(13, ++i, "昌邑市");
                addCity(13, ++i, "高密市");
                addCity(13, ++i, "安丘市");
                addCity(13, ++i, "寿光市");
                addCity(13, ++i, "招远市");
                addCity(13, ++i, "栖霞市");
                addCity(13, ++i, "海阳市");
                addCity(13, ++i, "蓬莱市");
                addCity(13, ++i, "乳山市");
                addCity(13, ++i, "兖州市");
                addCity(13, ++i, "肥城市");
                addCity(13, ++i, "禹城市");
                addCity(13, ++i, "潍坊市");
                addCity(13, ++i, "菏泽市");
                addCity(13, ++i, "邹城市");
                #endregion
                #region 浙江省
                addCity(14, ++i, "杭州市");
                addCity(14, ++i, "宁波市");
                addCity(14, ++i, "温州市");
                addCity(14, ++i, "嘉兴市");
                addCity(14, ++i, "湖州市");
                addCity(14, ++i, "绍兴市");
                addCity(14, ++i, "金华市");
                addCity(14, ++i, "衢州市");
                addCity(14, ++i, "舟山市");
                addCity(14, ++i, "余姚市");
                addCity(14, ++i, "海宁市");
                addCity(14, ++i, "兰溪市");
                addCity(14, ++i, "瑞安市");
                addCity(14, ++i, "江山市");
                addCity(14, ++i, "东阳市");
                addCity(14, ++i, "义乌市");
                addCity(14, ++i, "慈溪市");
                addCity(14, ++i, "奉化市");
                addCity(14, ++i, "诸暨市");
                addCity(14, ++i, "临海市");
                addCity(14, ++i, "丽水市");
                addCity(14, ++i, "龙泉市");
                addCity(14, ++i, "临安市");
                addCity(14, ++i, "富阳市"); 
                addCity(14, ++i, "建德市");
                addCity(14, ++i, "乐清市");
                addCity(14, ++i, "平湖市");
                addCity(14, ++i, "桐乡市");
                addCity(14, ++i, "上虞市");
                addCity(14, ++i, "永康市");
                addCity(14, ++i, "温岭市");
                addCity(14, ++i, "台州市");
                addCity(14, ++i, "嵊州市");
                #endregion
                #region 江西省
                addCity(15, ++i, "南昌市");
                addCity(15, ++i, "景德镇市");
                addCity(15, ++i, "萍乡市");
                addCity(15, ++i, "新余市");
                addCity(15, ++i, "九江市");
                addCity(15, ++i, "鹰潭市");
                addCity(15, ++i, "瑞昌市");
                addCity(15, ++i, "上饶市");
                addCity(15, ++i, "德兴市");
                addCity(15, ++i, "宜春市");
                addCity(15, ++i, "丰城市");
                addCity(15, ++i, "樟树市");
                addCity(15, ++i, "吉安市");
                addCity(15, ++i, "赣州市");
                addCity(15, ++i, "乐平市");
                addCity(15, ++i, "贵溪市");
                addCity(15, ++i, "南康市");
                addCity(15, ++i, "瑞金市");
                addCity(15, ++i, "井冈山市");
                addCity(15, ++i, "抚州市");
                #endregion
                #region 福建省
                addCity(16, ++i, "福州市");
                addCity(16, ++i, "厦门市");
                addCity(16, ++i, "三明市");
                addCity(16, ++i, "莆田市");
                addCity(16, ++i, "泉州市");
                addCity(16, ++i, "漳州市");
                addCity(16, ++i, "永安市");
                addCity(16, ++i, "石狮市");
                addCity(16, ++i, "福清市");
                addCity(16, ++i, "南平市");
                addCity(16, ++i, "邵武市");
                addCity(16, ++i, "武夷山市");
                addCity(16, ++i, "宁德市");
                addCity(16, ++i, "福安市");
                addCity(16, ++i, "龙岩市");
                addCity(16, ++i, "漳平市");
                addCity(16, ++i, "长乐市");
                addCity(16, ++i, "南安市");
                addCity(16, ++i, "晋江市");
                addCity(16, ++i, "龙海市");
                addCity(16, ++i, "建阳市");
                addCity(16, ++i, "建瓯市");
                addCity(16, ++i, "福鼎市");
                #endregion
                #region 湖南省
                addCity(17, ++i, "长沙市");
                addCity(17, ++i, "株洲市");
                addCity(17, ++i, "湘潭市");
                addCity(17, ++i, "衡阳市");
                addCity(17, ++i, "岳阳市");
                addCity(17, ++i, "常德市");
                addCity(17, ++i, "张家界市");
                addCity(17, ++i, "醴陵市");
                addCity(17, ++i, "湘乡市");
                addCity(17, ++i, "津市市");
                addCity(17, ++i, "韶山市");
                addCity(17, ++i, "郴州市");
                addCity(17, ++i, "资兴市");
                addCity(17, ++i, "永州市");
                addCity(17, ++i, "娄底市");
                addCity(17, ++i, "冷水江市");
                addCity(17, ++i, "涟源市");
                addCity(17, ++i, "怀化市");
                addCity(17, ++i, "洪江市");
                addCity(17, ++i, "益阳市");
                addCity(17, ++i, "沅江市");
                addCity(17, ++i, "吉首市");
                addCity(17, ++i, "浏阳市");
                addCity(17, ++i, "武冈市");
                addCity(17, ++i, "邵阳市");
                addCity(17, ++i, "临湘市");
                addCity(17, ++i, "耒阳市");
                addCity(17, ++i, "常宁市");
                addCity(17, ++i, "湘西土家族苗族自治州");
                addCity(17, ++i, "汨罗市");
                #endregion
                #region 湖北省
                addCity(18, ++i, "武汉市");
                addCity(18, ++i, "黄石市");
                addCity(18, ++i, "襄樊市");
                addCity(18, ++i, "荆州市");
                addCity(18, ++i, "荆门市");
                addCity(18, ++i, "鄂州市");
                addCity(18, ++i, "随州市");
                addCity(18, ++i, "老河口市");
                addCity(18, ++i, "枣阳市");
                addCity(18, ++i, "孝感市");
                addCity(18, ++i, "应城市");
                addCity(18, ++i, "安陆市");
                addCity(18, ++i, "广水市");
                addCity(18, ++i, "麻城市");
                addCity(18, ++i, "武穴市");
                addCity(18, ++i, "咸宁市");
                addCity(18, ++i, "仙桃市");
                addCity(18, ++i, "石首市");
                addCity(18, ++i, "天门市");
                addCity(18, ++i, "洪湖市");
                addCity(18, ++i, "潜江市");
                addCity(18, ++i, "宜昌市");
                addCity(18, ++i, "当阳市");
                addCity(18, ++i, "十堰市");
                addCity(18, ++i, "丹江口市");
                addCity(18, ++i, "恩施市");
                addCity(18, ++i, "利川市");
                addCity(18, ++i, "神农架林区");
                addCity(18, ++i, "汉川市");
                addCity(18, ++i, "钟祥市");
                addCity(18, ++i, "松滋市");
                addCity(18, ++i, "枝江市");
                addCity(18, ++i, "大冶市");
                addCity(18, ++i, "黄冈市");
                addCity(18, ++i, "恩施土家族苗族自治州");
                addCity(18, ++i, "宜都市");
                addCity(18, ++i, "赤壁市");
                #endregion
                #region 河南省
                addCity(19, ++i, "郑州市");
                addCity(19, ++i, "开封市");
                addCity(19, ++i, "洛阳市");
                addCity(19, ++i, "平顶山市");
                addCity(19, ++i, "焦作市");
                addCity(19, ++i, "鹤壁市");
                addCity(19, ++i, "新乡市");
                addCity(19, ++i, "安阳市");
                addCity(19, ++i, "濮阳市");
                addCity(19, ++i, "许昌市");
                addCity(19, ++i, "漯河市");
                addCity(19, ++i, "三门峡市");
                addCity(19, ++i, "义马市");
                addCity(19, ++i, "汝州市");
                addCity(19, ++i, "济源市");
                addCity(19, ++i, "禹州市");
                addCity(19, ++i, "卫辉市");
                addCity(19, ++i, "沁阳市");
                addCity(19, ++i, "舞钢市");
                addCity(19, ++i, "商丘市");
                addCity(19, ++i, "周口市");
                addCity(19, ++i, "驻马店市");
                addCity(19, ++i, "信阳市");
                addCity(19, ++i, "南阳市");
                addCity(19, ++i, "邓州市");
                addCity(19, ++i, "荥阳市");
                addCity(19, ++i, "登封市");
                addCity(19, ++i, "新郑市");
                addCity(19, ++i, "偃师市");
                addCity(19, ++i, "长葛市");
                addCity(19, ++i, "灵宝市");
                addCity(19, ++i, "永城市");
                addCity(19, ++i, "项城市");
                addCity(19, ++i, "巩义市");
                addCity(19, ++i, "林州市");
                addCity(19, ++i, "新密市");
                addCity(19, ++i, "孟州市");
                #endregion
                #region 广东省
                addCity(20, ++i, "广州市");
                addCity(20, ++i, "深圳市");
                addCity(20, ++i, "珠海市");
                addCity(20, ++i, "汕头市");
                addCity(20, ++i, "韶关市");
                addCity(20, ++i, "河源市");
                addCity(20, ++i, "梅州市");
                addCity(20, ++i, "惠州市");
                addCity(20, ++i, "汕尾市");
                addCity(20, ++i, "东莞市");
                addCity(20, ++i, "中山市");
                addCity(20, ++i, "江门市");
                addCity(20, ++i, "佛山市");
                addCity(20, ++i, "阳江市");
                addCity(20, ++i, "湛江市");
                addCity(20, ++i, "茂名市");
                addCity(20, ++i, "肇庆市");
                addCity(20, ++i, "清远市");
                addCity(20, ++i, "潮州市");
                addCity(20, ++i, "从化市");
                addCity(20, ++i, "增城市");
                addCity(20, ++i, "揭阳市");
                addCity(20, ++i, "南雄市");
                addCity(20, ++i, "乐昌市");
                addCity(20, ++i, "兴宁市");
                addCity(20, ++i, "陆丰市");
                addCity(20, ++i, "台山市");
                addCity(20, ++i, "开平市");
                addCity(20, ++i, "恩平市");
                addCity(20, ++i, "鹤山市");
                addCity(20, ++i, "阳春市");
                addCity(20, ++i, "吴川市");
                addCity(20, ++i, "廉江市");
                addCity(20, ++i, "高州市");
                addCity(20, ++i, "信宜市");
                addCity(20, ++i, "化州市");
                addCity(20, ++i, "高要市");
                addCity(20, ++i, "四会市");
                addCity(20, ++i, "罗定市");
                addCity(20, ++i, "云浮市");
                addCity(20, ++i, "英德市");
                addCity(20, ++i, "连州市");
                addCity(20, ++i, "普宁市");
                addCity(20, ++i, "雷州市");
                #endregion
                #region 海南省
                addCity(21, ++i, "海口市");
                addCity(21, ++i, "三亚市");
                addCity(21, ++i, "五指山市");
                addCity(21, ++i, "文昌市");
                addCity(21, ++i, "琼海市");
                addCity(21, ++i, "万宁市");
                addCity(21, ++i, "东方市");
                addCity(21, ++i, "儋州市");
                #endregion
                #region 广西壮族自治区
                addCity(22, ++i, "南宁市");
                addCity(22, ++i, "柳州市");
                addCity(22, ++i, "桂林市");
                addCity(22, ++i, "梧州市");
                addCity(22, ++i, "北海市");
                addCity(22, ++i, "凭祥市");
                addCity(22, ++i, "合山市");
                addCity(22, ++i, "玉林市");
                addCity(22, ++i, "贵港市");
                addCity(22, ++i, "百色市");
                addCity(22, ++i, "河池市");
                addCity(22, ++i, "崇左市");
                addCity(22, ++i, "来宾市");
                addCity(22, ++i, "岑溪市");
                addCity(22, ++i, "贺州市");
                addCity(22, ++i, "桂平市");
                addCity(22, ++i, "北流市");
                addCity(22, ++i, "钦州市");
                addCity(22, ++i, "防城港市");
                addCity(22, ++i, "宜州市");
                addCity(22, ++i, "东兴市");
                #endregion
                #region 贵州省
                addCity(23, ++i, "贵阳市");
                addCity(23, ++i, "六盘水市");
                addCity(23, ++i, "遵义市");
                addCity(23, ++i, "赤水市");
                addCity(23, ++i, "铜仁市");
                addCity(23, ++i, "安顺市");
                addCity(23, ++i, "兴义市");
                addCity(23, ++i, "凯里市");
                addCity(23, ++i, "都匀市");
                addCity(23, ++i, "仁怀市");
                addCity(23, ++i, "毕节市");
                addCity(23, ++i, "清镇市");
                addCity(23, ++i, "福泉市");
                addCity(23, ++i, "黔西南布依族苗族自治州");
                addCity(23, ++i, "黔东南苗族侗族自治州");
                addCity(23, ++i, "黔南布依族苗族自治州");
                addCity(23, ++i, "铜仁地区");
                addCity(23, ++i, "毕节地区");
                #endregion
                #region 四川省
                addCity(24, ++i, "成都市");
                addCity(24, ++i, "自贡市");
                addCity(24, ++i, "攀枝花市");
                addCity(24, ++i, "泸州市");
                addCity(24, ++i, "德阳市");
                addCity(24, ++i, "绵阳市");
                addCity(24, ++i, "广元市");
                addCity(24, ++i, "遂宁市");
                addCity(24, ++i, "内江市");
                addCity(24, ++i, "乐山市");
                addCity(24, ++i, "南充市");
                addCity(24, ++i, "宜宾市");
                addCity(24, ++i, "广安市");
                addCity(24, ++i, "广汉市");
                addCity(24, ++i, "西昌市");
                addCity(24, ++i, "江油市");
                addCity(24, ++i, "彭州市");
                addCity(24, ++i, "崇州市");
                addCity(24, ++i, "都江堰市");
                addCity(24, ++i, "巴中市");
                addCity(24, ++i, "雅安市");
                addCity(24, ++i, "眉山市");
                addCity(24, ++i, "阿坝藏族羌族自治州");
                addCity(24, ++i, "甘孜藏族自治州");
                addCity(24, ++i, "凉山彝族自治州");
                addCity(24, ++i, "邛崃市");
                addCity(24, ++i, "峨眉山市");
                addCity(24, ++i, "简阳市");
                addCity(24, ++i, "绵竹市");
                addCity(24, ++i, "什邡市");
                addCity(24, ++i, "资阳市");
                addCity(24, ++i, "达州市");
                addCity(24, ++i, "阆中市");
                addCity(24, ++i, "华蓥市");
                addCity(24, ++i, "万源市");
                #endregion
                #region 云南省
                addCity(25, ++i, "昆明市");
                addCity(25, ++i, "昭通市");
                addCity(25, ++i, "曲靖市");
                addCity(25, ++i, "玉溪市");
                addCity(25, ++i, "保山市");
                addCity(25, ++i, "个旧市");
                addCity(25, ++i, "开远市");
                addCity(25, ++i, "楚雄市");
                addCity(25, ++i, "大理市");
                addCity(25, ++i, "安宁市");
                addCity(25, ++i, "宣威市");
                addCity(25, ++i, "普洱市");
                addCity(25, ++i, "临沧市");
                addCity(25, ++i, "丽江市");
                addCity(25, ++i, "景洪市");
                addCity(25, ++i, "潞西市");
                addCity(25, ++i, "瑞丽市");
                addCity(25, ++i, "西双版纳傣族自治州");
                addCity(25, ++i, "德宏傣族景颇族自治州");
                addCity(25, ++i, "怒江傈僳族自治州");
                addCity(25, ++i, "迪庆藏族自治州");
                addCity(25, ++i, "文山壮族苗族自治州");
                addCity(25, ++i, "红河哈尼族彝族自治州");
                addCity(25, ++i, "楚雄彝族自治州");
                addCity(25, ++i, "大理白族自治州");
                #endregion
                #region 陕西省
                addCity(26, ++i, "西安市");
                addCity(26, ++i, "宝鸡市");
                addCity(26, ++i, "咸阳市");
                addCity(26, ++i, "榆林市");
                addCity(26, ++i, "延安市");
                addCity(26, ++i, "渭南市");
                addCity(26, ++i, "韩城市");
                addCity(26, ++i, "华阴市");
                addCity(26, ++i, "安康市");
                addCity(26, ++i, "汉中市");
                addCity(26, ++i, "兴平市");
                addCity(26, ++i, "铜川市");
                addCity(26, ++i, "商洛市");
                #endregion
                #region 甘肃省
                addCity(27, ++i, "兰州市");
                addCity(27, ++i, "金昌市");
                addCity(27, ++i, "白银市");
                addCity(27, ++i, "天水市");
                addCity(27, ++i, "嘉峪关市");
                addCity(27, ++i, "平凉市");
                addCity(27, ++i, "武威市");
                addCity(27, ++i, "张掖市");
                addCity(27, ++i, "玉门市");
                addCity(27, ++i, "酒泉市");
                addCity(27, ++i, "临夏市");
                addCity(27, ++i, "定西市");
                addCity(27, ++i, "庆阳市");
                addCity(27, ++i, "陇南市");
                addCity(27, ++i, "临夏回族自治州");
                addCity(27, ++i, "甘南藏族自治州");
                addCity(27, ++i, "合作市");
                addCity(27, ++i, "敦煌市");
                #endregion
                #region 宁夏回族自治区
                addCity(28, ++i, "银川市");
                addCity(28, ++i, "石嘴山市");
                addCity(28, ++i, "吴忠市");
                addCity(28, ++i, "青铜峡市");
                addCity(28, ++i, "灵武市");
                addCity(28, ++i, "中卫市");
                addCity(28, ++i, "固原市");
                #endregion
                #region 青海省
                addCity(29, ++i, "西宁市");
                addCity(29, ++i, "格尔木市");
                addCity(29, ++i, "德令哈市");
                addCity(29, ++i, "海东地区");
                addCity(29, ++i, "海北藏族自治州");
                addCity(29, ++i, "黄南藏族自治州");
                addCity(29, ++i, "果洛藏族自治州");
                addCity(29, ++i, "玉树藏族自治州");
                addCity(29, ++i, "海西蒙古族藏族自治州");
                addCity(29, ++i, "冷湖行委");
                #endregion
                #region 新疆维吾尔自治区
                addCity(30, ++i, "乌鲁木齐市");
                addCity(30, ++i, "克拉玛依市");
                addCity(30, ++i, "石河子市");
                addCity(30, ++i, "吐鲁番市");
                addCity(30, ++i, "哈密市");
                addCity(30, ++i, "和田市");
                addCity(30, ++i, "阿克苏市");
                addCity(30, ++i, "喀什市");
                addCity(30, ++i, "阿图什市");
                addCity(30, ++i, "库尔勒市");
                addCity(30, ++i, "昌吉市");
                addCity(30, ++i, "博乐市");
                addCity(30, ++i, "伊宁市");
                addCity(30, ++i, "塔城市");
                addCity(30, ++i, "阿勒泰市");
                addCity(30, ++i, "阜康市");
                addCity(30, ++i, "乌苏市");
                addCity(30, ++i, "奎屯市");
                addCity(30, ++i, "五家渠市");
                addCity(30, ++i, "阿拉尔市");
                addCity(30, ++i, "博尔塔拉蒙古自治州");
                addCity(30, ++i, "巴音郭楞蒙古自治州");
                addCity(30, ++i, "克孜勒苏柯尔克孜自治州");
                addCity(30, ++i, "伊犁哈萨克自治州");
                addCity(30, ++i, "图木舒克市");
                addCity(30, ++i, "吐鲁番地区");
                addCity(30, ++i, "哈密地区");
                addCity(30, ++i, "和田地区");
                addCity(30, ++i, "阿克苏地区");
                addCity(30, ++i, "喀什地区");
                addCity(30, ++i, "昌吉回族自治州");
                addCity(30, ++i, "塔城地区");
                addCity(30, ++i, "阿勒泰地区");
                addCity(30, ++i, "吐鲁番地区");
                #endregion
                #region 西藏自治区
                addCity(31, ++i, "拉萨市");
                addCity(31, ++i, "日喀则市");
                addCity(31, ++i, "那曲县");
                addCity(31, ++i, "昌都县");
                addCity(31, ++i, "林芝县");
                addCity(31, ++i, "山南地区");
                addCity(31, ++i, "阿里地区");
                addCity(31, ++i, "林芝地区");
                addCity(31, ++i, "日喀则地区");
                addCity(31, ++i, "那曲地区");
                addCity(31, ++i, "昌都地区");
                #endregion
            }
            bindCbo(cbo, CityList.Where(n => n.ProvinceId == ProvinceId).Select(n => new CboItem { Id = n.CityId, Name = n.CityName }).ToList());
        }
        
        static void addCity(int pId, int cId, string cName) 
        {
            CityList.Add(new City { ProvinceId = pId, CityId = cId, CityName = cName });
        }
        public static void bindCbo(ComboBox cbo, List<CboItem> items)
        {
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "Name";
            cbo.DataSource = items;
            cbo.SelectedIndex = 0;
        }
    }

    public class City
    {
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
