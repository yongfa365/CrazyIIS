using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.IO;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace CrazyIIS
{
    public partial class frmCreate : Form
    {
        public frmCreate()
        {
            InitializeComponent();
        }

        private void ServerComment_TextChanged(object sender, EventArgs e)
        {
            Path.Text = @"D:\WWW\Web\" + ServerComment.Text;
            LogFileDirectory.Text = @"D:\WWW\Log\" + ServerComment.Text;
            ServerBindings.Text = ":80:" + ServerComment.Text + ",:80:www." + ServerComment.Text;
            lblLinkHTML.Text = "http://" + ServerComment.Text.Trim() + "/CrazyIIS.html";
            lblLinkASP.Text = "http://" + ServerComment.Text.Trim() + "/CrazyIIS.asp";
            lblLinkASPX.Text = "http://" + ServerComment.Text.Trim() + "/CrazyIIS.aspx";
        }

        private void Create_Load(object sender, EventArgs e)
        {
            DirectoryEntry dir = new DirectoryEntry("IIS://localhost/w3svc");
            hosts.Checked = true;
            ScriptMaps.SelectedItem = Regex.Match(Comm.GetPropertyValue(dir, "ScriptMaps"), @"Framework\\(.+?)\\aspnet").Groups[1].Value;

            AppPoolId.Items.AddRange(Comm.GetAppPools().ToArray());
            AppPoolId.SelectedIndex = 0;
            AppPoolId.SelectedItem = "DefaultAppPool";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string AnonymousUserName = "IUSR_" + Regex.Replace(ServerComment.Text, @"\.|-", "_");
            string AnonymousUserPass = Comm.Random(20);
            if (AnonymousUserName.Length > 20)
            {
                AnonymousUserName = AnonymousUserName.Substring(0, 20);
            }
            WinNT.User.Del(AnonymousUserName);
            WinNT.User.Add(AnonymousUserName, AnonymousUserPass);


            if (!Directory.Exists(Path.Text))
            {
                Directory.CreateDirectory(Path.Text);
                File.WriteAllText(Path.Text + "\\CrazyIIS.html", "hello html");
                File.WriteAllText(Path.Text + "\\CrazyIIS.asp", "<%=1+1%>..OK");
                File.WriteAllText(Path.Text + "\\CrazyIIS.aspx", "<%=1+1%>..OK");
            }


            DirectoryEntry dir = new DirectoryEntry("IIS://localhost/w3svc");

            List<Int32> AllWebSiteId = Comm.GetAllWebSiteID();
            string NewWebSiteId = Comm.GetNewWebSiteID(AllWebSiteId);
            AllWebSiteId.Add(Convert.ToInt32(NewWebSiteId));

            DirectoryEntry web = dir.Children.Add(NewWebSiteId, "IIsWebServer");
            web.Properties["AuthFlags"].Value = 0;
            web.Properties["ServerAutoStart"].Value = true;
            web.Properties["ServerBindings"].Value = ServerBindings.Text.Split(',');
            web.Properties["ServerComment"].Value = ServerComment.Text;
            web.Properties["LogFileDirectory"].Value = LogFileDirectory.Text;

            web.CommitChanges();

            DirectoryEntry root = web.Children.Add("root", "IIsWebVirtualDir");
            root.Properties["Path"].Value = Path.Text;

            //root.Invoke("AppCreate", true);//创建应用程序

            root.Properties["EnableDirBrowsing"][0] = false;
            root.Properties["AccessExecute"][0] = false;
            root.Properties["AccessWrite"][0] = false;
            root.Properties["AccessRead"][0] = true; //设置读取权限
            root.Properties["AccessScript"][0] = true;//执行权限
            root.Properties["AuthFlags"].Value = 1;//0表示不允许匿名访问,1表示就可以3为基本身份验证，7为windows继承身份验证


            root.Properties["AnonymousUserName"].Value = AnonymousUserName;
            root.Properties["AnonymousUserPass"].Value = AnonymousUserPass;
            root.Properties["AppFriendlyName"].Value = ServerComment.Text;
            root.Properties["AppPoolId"].Value = AppPoolId.Text;
            root.Properties["AppIsolated"].Value = 2;
            root.Properties["AppRoot"].Value = string.Format("/LM/W3SVC/{0}/Root", NewWebSiteId);

            root.CommitChanges();

            if (hosts.Checked)
            {

                Comm.Write2hosts(("127.0.0.1," + ServerComment.Text + ",127.0.0.1,www." + ServerComment.Text).Split(','), false);
            }

            NTFS.ACL.Add(Path.Text, AnonymousUserName, FileSystemRights.FullControl);
            NTFS.ACL.Add(Path.Text, "NETWORK SERVICE", FileSystemRights.FullControl);
            MessageBox.Show("OK");
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start((sender as LinkLabel).Text);
        }

        #region Test
        delegate void RunTestDelegate(object domain);
        RunTestDelegate runTest;
        void RunTest(object domain)
        {
            ServerComment.Text = domain.ToString();
            btnAdd.PerformClick();
        }

        void Run()
        {
            #region List

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("1234567.com.cn", "天天基金网");
            dict.Add("126.com", "126免费邮箱");
            dict.Add("139.com", "139");
            dict.Add("1518.com", "星座命程");
            dict.Add("163.com", "网易");
            dict.Add("17173.com", "17173");
            dict.Add("1ting.com", "一听音乐");
            dict.Add("360.cn", "360安全卫士");
            dict.Add("360quan.com", "360圈");
            dict.Add("365rili.com", "万年历");
            dict.Add("3839.com", "3839小游戏");
            dict.Add("39.net", "39健康");
            dict.Add("4399.com", "4399");
            dict.Add("51.com", "51个人空间");
            dict.Add("51job.com", "前程无忧");
            dict.Add("51mole.com", "摩尔庄园");
            dict.Add("520music.com", "我爱音乐");
            dict.Add("528.com.cn", "528招聘");
            dict.Add("55bbs.com", "我爱打折网");
            dict.Add("6.cn", "六间房");
            dict.Add("7k7k.com", "7K7K");
            dict.Add("91wan.com", "91wan");
            dict.Add("QVOD.com", "快播");
            dict.Add("abang.com", "阿邦网");
            dict.Add("abchina.com", "农业银行");
            dict.Add("aion.sdo.com", "永恒之塔");
            dict.Add("aiting.com", "爱听音乐");
            dict.Add("amazon.cn", "卓越亚马逊");
            dict.Add("anjuke.com", "安居客");
            dict.Add("astro.lady.qq.com", "腾讯星座");
            dict.Add("astro.sina.com.cn", "新浪网星座");
            dict.Add("astro.women.sohu.com", "搜狐星相");
            dict.Add("autohome.com.cn", "汽车之家");
            dict.Add("baidu.com", "百度");
            dict.Add("baihe.com", "百合网");
            dict.Add("bankcomm.com", "交通银行");
            dict.Add("bankrate.com.cn", "银率网");
            dict.Add("bitauto.com", "易车网");
            dict.Add("blog.163.com", "网易博客");
            dict.Add("blog.sina.com.cn", "新浪博客");
            dict.Add("blog.sohu.com", "搜狐博客");
            dict.Add("bobo.com.cn", "买手机网");
            dict.Add("boc.cn", "中国银行");
            dict.Add("bokee.com", "博客网");
            dict.Add("book.sina.com.cn", "新浪读书");
            dict.Add("ccb.com", "建设银行");
            dict.Add("cctv.com", "中央电视台");
            dict.Add("chashouji.com", "手机位置");
            dict.Add("che168.com", "车168");
            dict.Add("cheshi.com", "网上车市");
            dict.Add("china.alibaba.com", "阿里巴巴");
            dict.Add("china.com", "中华网");
            dict.Add("china.com.cn", "中国网");
            dict.Add("china.nba.com", "NBA中文网");
            dict.Add("chinaamc.com", "华夏基金");
            dict.Add("chinahr.com", "中华英才网");
            dict.Add("chinamobile.com", "中国移动");
            dict.Add("chinanews.com.cn", "中国新闻网");
            dict.Add("ci123.com", "育儿网");
            dict.Add("cib.com.cn", "兴业银行");
            dict.Add("cjol.com", "中国人才热线");
            dict.Add("cmbchina.com", "招商银行");
            dict.Add("cn.allrecipes.com", "十全菜谱");
            dict.Add("cn.astrology.yahoo.com", "雅虎星座");
            dict.Add("cn.msn.com", "MSN中文网");
            dict.Add("cn.yahoo.com", "雅虎");
            dict.Add("cnfol.com", "中金在线");
            dict.Add("cnmo.com", "手机中国");
            dict.Add("crsky.com", "霏凡下载");
            dict.Add("ctrip.com", "携程");
            dict.Add("d1xz.net", "第一星座");
            dict.Add("dangdang.com", "当当网");
            dict.Add("danqoo.com", "短趣网");
            dict.Add("daodao.com", "到到旅游网");
            dict.Add("daqi.com", "大旗网");
            dict.Add("dianping.com", "大众点评");
            dict.Add("download.tech.qq.com", "腾讯QQ");
            dict.Add("duowan.com", "多玩");
            dict.Add("dzh.mop.com", "猫扑大杂烩　");
            dict.Add("earth.google.com", "谷歌地球");
            dict.Add("eastmoney.com", "东方财富网");
            dict.Add("eladies.sina.com.cn", "新浪女性");
            dict.Add("ellechina.com", "ELLE");
            dict.Add("elong.com", "艺龙旅行网");
            dict.Add("fantong.com", "饭统网");
            dict.Add("fh21.com.cn", "飞华健康网");
            dict.Add("finance.qq.com", "腾讯财经");
            dict.Add("finance.sina.com.cn", "新浪基金");
            dict.Add("flashget.com", "快车flashget");
            dict.Add("fund.eastmoney.com", "基金净值");
            dict.Add("fund.jrj.com.cn", "金融界基金");
            dict.Add("fx120.net", "放心120网");
            dict.Add("game.zol.com.cn", "中关村游戏");
            dict.Add("games.sina.com.cn", "新浪游戏");
            dict.Add("gffunds.com.cn", "广发基金");
            dict.Add("gmail.com", "Gmail");
            dict.Add("google.cn", "免费短信");

            dict.Add("google.com", "帮助论坛");
            dict.Add("gov.cn", "中国政府网");
            dict.Add("haodf.com", "好大夫在线");
            dict.Add("haoting.com", "好听音乐网");
            dict.Add("health.sohu.com", "搜狐健康");
            dict.Add("hexun.com", "和讯网");
            dict.Add("hi.baidu.com", "百度空间");
            dict.Add("home.woool.sdo.com", "传奇世界");
            dict.Add("hongxiu.com", "红袖添香");
            dict.Add("hoopchina.com", "虎扑NBA");
            dict.Add("hotmail.com", "Hotmail");
            dict.Add("icbc.com.cn", "工商银行");
            dict.Add("ifeng.com", "凤凰网");
            dict.Add("images.google.cn", "图片");
            dict.Add("imobile.com.cn", "手机之家");
            dict.Add("ipart.cn", "爱情公寓");
            dict.Add("it.com.cn", "IT世界网");
            dict.Add("it168.com", "IT168");
            dict.Add("izhufu.com", "主妇网");
            dict.Add("j.cn", "简单网");
            dict.Add("jiayuan.com", "世纪佳缘");
            dict.Add("jipiao.kuxun.cn", "机票预定");
            dict.Add("jjwxc.net", "晋江原创");
            dict.Add("joy.cn", "激动网");
            dict.Add("jrj.com.cn", "金融界");
            dict.Add("jsfund.cn", "嘉实基金");
            dict.Add("junshi.xilu.com", "西陆军事");
            dict.Add("kaixin001.com", "开心网");
            dict.Add("koubei.com", "口碑网");
            dict.Add("ku6.com", "酷6视频");
            dict.Add("kuwo.cn", "酷我音乐盒");
            dict.Add("lady.163.com", "网易女人");
            dict.Add("lady8844.com", "爱美网");
            dict.Add("laiba.tianya.cn", "天涯来吧");
            dict.Add("lottery.gov.cn", "体育彩票");
            dict.Add("m.google.cn", "手机地图");
            dict.Add("mail.163.com", "163免费邮箱");
            dict.Add("mail.google.com", "免费邮箱");
            dict.Add("mail.sina.com.cn", "新浪邮箱");
            dict.Add("marry5.com", "嫁我网");
            dict.Add("maxthon.cn", "傲游浏览器");
            dict.Add("mil.huanqiu.com", "环球网军事");
            dict.Add("mil.news.sina.com.cn", "新浪军事");
            dict.Add("military.china.com", "中华网军事");
            dict.Add("mobile.pcpop.com", "泡泡手机");
            dict.Add("mobile.sina.com.cn", "新浪手机");
            dict.Add("mobile.zol.com.cn", "中关村手机");
            dict.Add("mop.com", "猫扑");
            dict.Add("mosh.cn", "魔时网");
            dict.Add("mpdaogou.com", "名品导购网");
            dict.Add("mydown.com", "天极下载");
            dict.Add("myspace.cn", "聚友网");
            dict.Add("news.google.cn", "资讯");
            dict.Add("news.ifeng.com", "凤凰资讯");
            dict.Add("news.sina.com.cn", "新浪新闻");
            dict.Add("one.cn.yahoo.com", "雅虎");
            dict.Add("onlinedown.net", "华军软件");
            dict.Add("pcauto.com.cn", "太平洋汽车");
            dict.Add("pchome.net", "电脑之家");
            dict.Add("pclady.com.cn", "太平洋女性网");
            dict.Add("pconline.com.cn", "太平洋电脑");
            dict.Add("pcpop.com", "泡泡网");
            dict.Add("people.com.cn", "人民网");
            dict.Add("ppstream.com", "PPS网络电视");
            dict.Add("product.cheshi.com", "汽车报价");
            dict.Add("pstatic.xunlei.com", "迅雷");
            dict.Add("qidian.com", "起点中文");
            dict.Add("qihoo.com", "奇虎网");
            dict.Add("qq.com", "腾讯QQ");
            dict.Add("qq163.com", "QQ163音乐");
            dict.Add("qunar.com", "去哪儿");
            dict.Add("qzone.qq.com", "QQ空间");
            dict.Add("rayli.com.cn", "瑞丽女性网");
            dict.Add("readnovel.com", "小说阅读");
            dict.Add("renren.com", "人人网");
            dict.Add("rising.com.cn", "瑞星");
            dict.Add("shenghuo.google.cn", "列车时刻");
            dict.Add("sina.com.cn", "新浪");
            dict.Add("skycn.com", "天空软件");
            dict.Add("sohu.com", "搜狐");
            dict.Add("soufun.com", "搜房网");
            dict.Add("sports.163.com", "网易体育");
            dict.Add("sports.sina.com.cn", "新浪体育");
            dict.Add("sports.sohu.com", "搜狐体育");
            dict.Add("sports.tom.com", "TOM体育");
            dict.Add("stockstar.com", "证券之星");
            dict.Add("taobao.com", "淘宝网");
            dict.Add("tech.sina.com.cn", "新浪下载");
            dict.Add("tianya.cn", "天涯社区");
            dict.Add("tiexue.net", "铁血军事");
            dict.Add("tl.sohu.com", "天龙八部");
            dict.Add("tom.com", "TOM");
            dict.Add("toolbar.google.com", "谷歌工具栏");
            dict.Add("tudou.com", "土豆网");
            dict.Add("tv.sohu.com", "搜狐视频");
            dict.Add("union.360buy.com", "京东网上商城");
            dict.Add("update.microsoft.com", "Windows更新");
            dict.Add("uusee.tv", "UUsee");
            dict.Add("video.google.cn", "视频");
            dict.Add("video.sina.com.cn", "新浪视频");
            dict.Add("wealink.com", "若邻网");
            dict.Add("wenda.tianya.cn", "在线问答");
            dict.Add("women.sohu.com", "搜狐女人");
            dict.Add("wooha.com", "呼哈网");
            dict.Add("xcar.com.cn", "爱卡");
            dict.Add("xiaoyouxi.com", "小游戏网");
            dict.Add("xiazai.zol.com.cn", "中关村下载");
            dict.Add("xici.net", "西祠胡同");
            dict.Add("xinhuanet.com", "新华网");
            dict.Add("xuanxuan.com", "萱萱小游戏");
            dict.Add("xunlei.com", "迅雷在线");
            dict.Add("xxsy.net", "潇湘书院");
            dict.Add("xywy.com", "寻医问药网");
            dict.Add("yaolan.com", "摇篮网");
            dict.Add("yesky.com", "天极网");
            dict.Add("yingjiesheng.com", "应届生求职网");
            dict.Add("yoka.com", "YOKA时尚网");
            dict.Add("youku.com", "优酷网");
            dict.Add("zaobao.com", "早报网");
            dict.Add("zhaopin.com", "智联招聘");
            dict.Add("zhcw.com", "中彩网");
            dict.Add("zhibo8.com", "直播吧");
            dict.Add("zhulang.com", "逐浪小说");
            dict.Add("zol.com.cn", "中关村在线");


            #endregion

            foreach (var item in dict)
            {
                this.Invoke(runTest, item.Key);
                Thread.Sleep(10);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            runTest = new RunTestDelegate(RunTest);

            Thread t = new Thread(Run);
            t.IsBackground = true;
            t.Start();
        }
        #endregion





    }
}
