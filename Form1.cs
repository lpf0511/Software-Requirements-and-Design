using Newtonsoft.Json.Linq;

namespace PiggyNLP_2
{
    public partial class Form1 : Form
    {
        String API_KEY = "at6NgaWDPtU29NW2fVb5pQ3w";
        String SECRET_KEY = "cuSCKXY6rE9o5s21UEricZSWUXNPi0SI";
        //  Baidu.Aip.Nlp.Nlp client;
        Baidu.Aip.Ocr.Ocr client;

        public Form1()
        {
            try
            {
                client = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
                client.Timeout = 60000;
            }
            catch
            {
                MessageBox.Show("初始化百度接口出错", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InitializeComponent();
        }

        //通用版
        public void GeneralBasicDemo()
        {
            textBox2.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            //   var options = new Dictionary<string, object> { };
            if (checkBox2.Checked)
            {//含方向
                var options = new Dictionary<string, object>{
                   {"language_type", "CHN_ENG"},
                   {"detect_direction", "true"},
                                 };
                // 带参数调用通用文字识别, 图片参数为本地图片
                var result = client.GeneralBasic(image, options);
                textBox2.Text += "方向: " + (String)result["direction"] + "\r\n";
                JArray items = (JArray)result["words_result"];
                foreach (JObject it in items)
                {

                    textBox2.Text += (String)it["words"] + "\r\n";
                }

            }
            else
            {
                var options = new Dictionary<string, object>{
                {"language_type", "CHN_ENG"},
                                            };
                // 带参数调用通用文字识别, 图片参数为本地图片
                var result = client.GeneralBasic(image, options);
                JArray items = (JArray)result["words_result"];
                foreach (JObject it in items)
                {
                    textBox2.Text += (String)it["words"] + "\r\n";
                }
            }


        }
        //通用含位置
        public void GeneralDemo()
        {
            textBox2.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            if (checkBox2.Checked)
            {//含方向
                var options = new Dictionary<string, object>{
        {"detect_direction", "true"}, };
                var result = client.General(image, options);
                textBox2.Text += "方向: " + (String)result["direction"] + "\r\n";
                JArray items = (JArray)result["words_result"];
                foreach (JObject it in items)
                {
                    textBox2.Text += "[" + "l: " + (String)it["location"]["left"] + ", t: " + (String)it["location"]["top"] + ", w: " + (String)it["location"]["width"] + ", h: " + (String)it["location"]["height"] + " ]";
                    textBox2.Text += (String)it["words"] + "\r\n";
                }
            }
            else
            {
                // 调用通用文字识别（含位置信息版）, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
                var result = client.General(image);
                JArray items = (JArray)result["words_result"];
                foreach (JObject it in items)
                {
                    textBox2.Text += "[ " + "l:" + (String)it["location"]["left"] + ", t:" + (String)it["location"]["top"] + ", w:" + (String)it["location"]["width"] + ", h:" + (String)it["location"]["height"] + "]";
                    textBox2.Text += (String)it["words"] + "\r\n";
                }

            }
        }
        //高精度
        public void AccurateBasicDemo()
        {
            textBox2.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            if (checkBox2.Checked)
            {//含方向
             // 带参数调用通用文字识别（高精度版）
                var options = new Dictionary<string, object>{
        {"detect_direction", "true"}  };
                var result = client.AccurateBasic(image, options);
                textBox2.Text += "方向: " + (String)result["direction"] + "\r\n";
                JArray items = (JArray)result["words_result"];
                foreach (JObject it in items)
                {
                    textBox2.Text += (String)it["words"] + "\r\n";
                }
            }
            else
            {//不含方向

                var result = client.AccurateBasic(image);
                JArray items = (JArray)result["words_result"];
                foreach (JObject it in items)
                {
                    textBox2.Text += (String)it["words"] + "\r\n";
                }
            }

        }
        //含位置高精度
        public void AccurateDemo()
        {
            textBox2.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            if (checkBox2.Checked)
            {//含方向
                var options = new Dictionary<string, object>{
        {"detect_direction", "true"}     };
                var result = client.Accurate(image, options);
                textBox2.Text += "方向:" + (String)result["direction"] + "\r\n";
                JArray items = (JArray)result["words_result"];
                foreach (JObject it in items)
                {
                    textBox2.Text += "[" + "l:" + (String)it["location"]["left"] + ", t:" + (String)it["location"]["top"] + ", w:" + (String)it["location"]["width"] + ", h:" + (String)it["location"]["height"] + "]";
                    textBox2.Text += (String)it["words"] + "\r\n";
                }
            }
            else
            {
                var result = client.Accurate(image);
                JArray items = (JArray)result["words_result"];
                foreach (JObject it in items)
                {
                    textBox2.Text += "[" + "l:" + (String)it["location"]["left"] + ", t:" + (String)it["location"]["top"] + ", w:" + (String)it["location"]["width"] + ", h:" + (String)it["location"]["height"] + "]";
                    textBox2.Text += (String)it["words"] + "\r\n";
                }
            }
        }

        //网络图片文字识别
        public void WebImageDemo()
        {
            textBox3.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            // 调用网络图片文字识别, 图片参数为本地图片
            var result = client.WebImage(image);
            JArray items = (JArray)result["words_result"];
            foreach (JObject it in items)
            {
                textBox3.Text += (String)it["words"] + "\r\n";
            }
        }
        //身份证识别
        public void IdcardDemo()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            var idCardSide = "front";
            // 调用身份证识别，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.Idcard(image, idCardSide);
            var items = result["words_result"];
            textBox4.Text += "姓名: " + (String)items["姓名"]["words"] + "\r\n";
            textBox4.Text += "民族: " + (String)items["民族"]["words"] + "\r\n";
            textBox4.Text += "住址: " + (String)items["住址"]["words"] + "\r\n";
            textBox4.Text += "公民身份号码: " + (String)items["公民身份号码"]["words"] + "\r\n";
            textBox4.Text += "出生: " + (String)items["出生"]["words"] + "\r\n";
            textBox4.Text += "性别: " + (String)items["性别"]["words"] + "\r\n";

        }
        public void IdcardDemo2()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            var idCardSide = "back";
            // 调用身份证识别，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.Idcard(image, idCardSide);
            var items = result["words_result"];
            textBox4.Text += "失效日期: " + (String)items["失效日期"]["words"] + "\r\n";
            textBox4.Text += "签发机关: " + (String)items["签发机关"]["words"] + "\r\n";
            textBox4.Text += "签发日期: " + (String)items["签发日期"]["words"] + "\r\n";
        }
        //银行卡
        public void BankcardDemo()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            var result = client.Bankcard(image);
            textBox4.Text += "方向: " + result["direction"] + "\r\n";
            textBox4.Text += "有效期: " + result["result"]["valid_date"] + "\r\n";
            textBox4.Text += "银行卡号: " + result["result"]["bank_card_number"] + "\r\n";
            textBox4.Text += "银行名称: " + result["result"]["bank_name"] + "\r\n";
            textBox4.Text += "银行卡类型: " + result["result"]["bank_card_type"] + "\r\n";
            textBox4.Text += "持卡人姓名: " + result["result"]["holder_name"] + "\r\n";
        }
        // 营业执照识别
        public void BusinessLicenseDemo()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            var result = client.BusinessLicense(image);
            //textBox4.Text += result;
            var items = result["words_result"];
            textBox4.Text += "方向: " + result["direction"] + "\r\n";
            textBox4.Text += "经营范围: " + items["经营范围"]["words"] + "\r\n";
            textBox4.Text += "组成形式: " + items["组成形式"]["words"] + "\r\n";
            textBox4.Text += "法人: " + items["法人"]["words"] + "\r\n";
            textBox4.Text += "证件编号: " + items["证件编号"]["words"] + "\r\n";
            textBox4.Text += "注册资本: " + items["注册资本"]["words"] + "\r\n";
            textBox4.Text += "单位名称: " + items["单位名称"]["words"] + "\r\n";
            textBox4.Text += "有效期: " + items["有效期"]["words"] + "\r\n";
            textBox4.Text += "社会信用代码: " + items["社会信用代码"]["words"] + "\r\n";
            textBox4.Text += "实收资本:" + items["实收资本"]["words"] + "\r\n";
            textBox4.Text += "核准日期: " + items["核准日期"]["words"] + "\r\n";
            textBox4.Text += "成立日期: " + items["成立日期"]["words"] + "\r\n";
            textBox4.Text += "税务登记号: " + items["税务登记号"]["words"] + "\r\n";
            textBox4.Text += "地址: " + items["地址"]["words"] + "\r\n";
            textBox4.Text += "登记机关: " + items["登记机关"]["words"] + "\r\n";
            textBox4.Text += "类型: " + items["类型"]["words"] + "\r\n";


        }
        // 驾驶证识别
        public void DrivingLicenseDemo()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);

            // 如果有可选参数
            var options = new Dictionary<string, object>{
        {"detect_direction", "true"}
    };
            // 带参数调用驾驶证识别
            var result = client.DrivingLicense(image, options);
            textBox4.Text += "方向:" + result["direction"] + "\r\n";
            var items = result["words_result"];
            textBox4.Text += "姓名: " + items["姓名"]["words"] + "\r\n";
            textBox4.Text += "有效起始日期: " + items["有效期限"]["words"] + "\r\n";
            textBox4.Text += "失效日期: " + items["至"]["words"] + "\r\n";
            textBox4.Text += "出生日期: " + items["出生日期"]["words"] + "\r\n";
            textBox4.Text += "证号: " + items["证号"]["words"] + "\r\n";
            textBox4.Text += "住址: " + items["住址"]["words"] + "\r\n";
            textBox4.Text += "发证单位: " + items["发证单位"]["words"] + "\r\n";
            textBox4.Text += "国籍: " + items["国籍"]["words"] + "\r\n";
            textBox4.Text += "准驾车型: " + items["准驾车型"]["words"] + "\r\n";
            textBox4.Text += "性别: " + items["性别"]["words"] + "\r\n";
        }
        // 行驶证识别
        public void VehicleLicenseDemo()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            // 调用行驶证识别，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.VehicleLicense(image);
            var items = result["words_result"];
            textBox4.Text += "车辆识别代号: " + items["车辆识别代号"]["words"] + "\r\n";
            textBox4.Text += "住址: " + items["住址"]["words"] + "\r\n";
            textBox4.Text += "发证单位: " + items["发证单位"]["words"] + "\r\n";
            textBox4.Text += "车辆类型: " + items["车辆类型"]["words"] + "\r\n";
            textBox4.Text += "品牌型号: " + items["品牌型号"]["words"] + "\r\n";
            textBox4.Text += "发证日期: " + items["发证日期"]["words"] + "\r\n";
            textBox4.Text += "所有人: " + items["所有人"]["words"] + "\r\n";
            textBox4.Text += "号牌号码: " + items["号牌号码"]["words"] + "\r\n";
            textBox4.Text += "使用性质: " + items["使用性质"]["words"] + "\r\n";
            textBox4.Text += "发动机号码: " + items["发动机号码"]["words"] + "\r\n";
            textBox4.Text += "注册日期: " + items["注册日期"]["words"] + "\r\n";
        }
        // 车牌识别
        public void LicensePlateDemo()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            // 调用车牌识别，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.LicensePlate(image);
            textBox4.Text = "车牌号码: " + result["words_result"]["number"] + "\r\n" + "车牌颜色: " + result["words_result"]["color"] + "\r\n";

        }
        // 表格文字识别
        public void TableRecognitionRequestDemo()
        {
            button5.Enabled= false;
            var image = File.ReadAllBytes(textBox1.Text);   
            var result = client.TableRecognitionRequest(image);           
            var items = result["result"][0]["request_id"];          
            var requestId =(string)items;
          //  TableRecognitionGetResultDemo(requestId);
            var result2 = client.TableRecognitionToJson(image, 30000);
            while (result2 == null) {
                result2 = client.TableRecognitionToJson(image, 30000);
                Thread.Sleep(1000);
            }
            TableRecognitionGetResultDemo(requestId);

        }

        //获取结果
        public void TableRecognitionGetResultDemo(string requestId)
        {
            textBox5.Clear();
            // 如果有可选参数
            var options = new Dictionary<string, object>{
        {"result_type", "json"}
                    };
            // 带参数调用表格识别结果 
            var result = client.TableRecognitionGetResult(requestId, options);
            textBox5.Text += result;
            button5.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "选择文件";
            fdlg.FilterIndex = 2;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = System.IO.Path.GetFullPath(fdlg.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked && !checkBox1.Checked)
            {
                GeneralBasicDemo();//通用
            }
            else if (radioButton2.Checked && !checkBox1.Checked)
            {
                AccurateBasicDemo();//高精度
            }
            else if (radioButton1.Checked && checkBox1.Checked)
            {
                GeneralDemo();//通用含位置
            }
            else if (radioButton2.Checked && checkBox1.Checked)
            {
                AccurateDemo();//高精度含位置
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WebImageDemo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                IdcardDemo();
            }
            else if (radioButton4.Checked)
            {
                IdcardDemo2();
            }
            else if (radioButton5.Checked)
            {
                BankcardDemo();
            }
            else if (radioButton6.Checked)
            {
                BusinessLicenseDemo();
            }
            else if (radioButton7.Checked)
            {
                DrivingLicenseDemo();
            }
            else if (radioButton8.Checked)
            {
                VehicleLicenseDemo();
            }
            else if (radioButton9.Checked)
            {
                LicensePlateDemo();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TableRecognitionRequestDemo();
        }
    }
}