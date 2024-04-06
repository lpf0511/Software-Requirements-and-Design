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
                MessageBox.Show("��ʼ���ٶȽӿڳ���", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InitializeComponent();
        }

        //ͨ�ð�
        public void GeneralBasicDemo()
        {
            textBox2.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            //   var options = new Dictionary<string, object> { };
            if (checkBox2.Checked)
            {//������
                var options = new Dictionary<string, object>{
                   {"language_type", "CHN_ENG"},
                   {"detect_direction", "true"},
                                 };
                // ����������ͨ������ʶ��, ͼƬ����Ϊ����ͼƬ
                var result = client.GeneralBasic(image, options);
                textBox2.Text += "����: " + (String)result["direction"] + "\r\n";
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
                // ����������ͨ������ʶ��, ͼƬ����Ϊ����ͼƬ
                var result = client.GeneralBasic(image, options);
                JArray items = (JArray)result["words_result"];
                foreach (JObject it in items)
                {
                    textBox2.Text += (String)it["words"] + "\r\n";
                }
            }


        }
        //ͨ�ú�λ��
        public void GeneralDemo()
        {
            textBox2.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            if (checkBox2.Checked)
            {//������
                var options = new Dictionary<string, object>{
        {"detect_direction", "true"}, };
                var result = client.General(image, options);
                textBox2.Text += "����: " + (String)result["direction"] + "\r\n";
                JArray items = (JArray)result["words_result"];
                foreach (JObject it in items)
                {
                    textBox2.Text += "[" + "l: " + (String)it["location"]["left"] + ", t: " + (String)it["location"]["top"] + ", w: " + (String)it["location"]["width"] + ", h: " + (String)it["location"]["height"] + " ]";
                    textBox2.Text += (String)it["words"] + "\r\n";
                }
            }
            else
            {
                // ����ͨ������ʶ�𣨺�λ����Ϣ�棩, ͼƬ����Ϊ����ͼƬ�����ܻ��׳�������쳣����ʹ��try/catch����
                var result = client.General(image);
                JArray items = (JArray)result["words_result"];
                foreach (JObject it in items)
                {
                    textBox2.Text += "[ " + "l:" + (String)it["location"]["left"] + ", t:" + (String)it["location"]["top"] + ", w:" + (String)it["location"]["width"] + ", h:" + (String)it["location"]["height"] + "]";
                    textBox2.Text += (String)it["words"] + "\r\n";
                }

            }
        }
        //�߾���
        public void AccurateBasicDemo()
        {
            textBox2.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            if (checkBox2.Checked)
            {//������
             // ����������ͨ������ʶ�𣨸߾��Ȱ棩
                var options = new Dictionary<string, object>{
        {"detect_direction", "true"}  };
                var result = client.AccurateBasic(image, options);
                textBox2.Text += "����: " + (String)result["direction"] + "\r\n";
                JArray items = (JArray)result["words_result"];
                foreach (JObject it in items)
                {
                    textBox2.Text += (String)it["words"] + "\r\n";
                }
            }
            else
            {//��������

                var result = client.AccurateBasic(image);
                JArray items = (JArray)result["words_result"];
                foreach (JObject it in items)
                {
                    textBox2.Text += (String)it["words"] + "\r\n";
                }
            }

        }
        //��λ�ø߾���
        public void AccurateDemo()
        {
            textBox2.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            if (checkBox2.Checked)
            {//������
                var options = new Dictionary<string, object>{
        {"detect_direction", "true"}     };
                var result = client.Accurate(image, options);
                textBox2.Text += "����:" + (String)result["direction"] + "\r\n";
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

        //����ͼƬ����ʶ��
        public void WebImageDemo()
        {
            textBox3.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            // ��������ͼƬ����ʶ��, ͼƬ����Ϊ����ͼƬ
            var result = client.WebImage(image);
            JArray items = (JArray)result["words_result"];
            foreach (JObject it in items)
            {
                textBox3.Text += (String)it["words"] + "\r\n";
            }
        }
        //���֤ʶ��
        public void IdcardDemo()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            var idCardSide = "front";
            // �������֤ʶ�𣬿��ܻ��׳�������쳣����ʹ��try/catch����
            var result = client.Idcard(image, idCardSide);
            var items = result["words_result"];
            textBox4.Text += "����: " + (String)items["����"]["words"] + "\r\n";
            textBox4.Text += "����: " + (String)items["����"]["words"] + "\r\n";
            textBox4.Text += "סַ: " + (String)items["סַ"]["words"] + "\r\n";
            textBox4.Text += "������ݺ���: " + (String)items["������ݺ���"]["words"] + "\r\n";
            textBox4.Text += "����: " + (String)items["����"]["words"] + "\r\n";
            textBox4.Text += "�Ա�: " + (String)items["�Ա�"]["words"] + "\r\n";

        }
        public void IdcardDemo2()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            var idCardSide = "back";
            // �������֤ʶ�𣬿��ܻ��׳�������쳣����ʹ��try/catch����
            var result = client.Idcard(image, idCardSide);
            var items = result["words_result"];
            textBox4.Text += "ʧЧ����: " + (String)items["ʧЧ����"]["words"] + "\r\n";
            textBox4.Text += "ǩ������: " + (String)items["ǩ������"]["words"] + "\r\n";
            textBox4.Text += "ǩ������: " + (String)items["ǩ������"]["words"] + "\r\n";
        }
        //���п�
        public void BankcardDemo()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            var result = client.Bankcard(image);
            textBox4.Text += "����: " + result["direction"] + "\r\n";
            textBox4.Text += "��Ч��: " + result["result"]["valid_date"] + "\r\n";
            textBox4.Text += "���п���: " + result["result"]["bank_card_number"] + "\r\n";
            textBox4.Text += "��������: " + result["result"]["bank_name"] + "\r\n";
            textBox4.Text += "���п�����: " + result["result"]["bank_card_type"] + "\r\n";
            textBox4.Text += "�ֿ�������: " + result["result"]["holder_name"] + "\r\n";
        }
        // Ӫҵִ��ʶ��
        public void BusinessLicenseDemo()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            var result = client.BusinessLicense(image);
            //textBox4.Text += result;
            var items = result["words_result"];
            textBox4.Text += "����: " + result["direction"] + "\r\n";
            textBox4.Text += "��Ӫ��Χ: " + items["��Ӫ��Χ"]["words"] + "\r\n";
            textBox4.Text += "�����ʽ: " + items["�����ʽ"]["words"] + "\r\n";
            textBox4.Text += "����: " + items["����"]["words"] + "\r\n";
            textBox4.Text += "֤�����: " + items["֤�����"]["words"] + "\r\n";
            textBox4.Text += "ע���ʱ�: " + items["ע���ʱ�"]["words"] + "\r\n";
            textBox4.Text += "��λ����: " + items["��λ����"]["words"] + "\r\n";
            textBox4.Text += "��Ч��: " + items["��Ч��"]["words"] + "\r\n";
            textBox4.Text += "������ô���: " + items["������ô���"]["words"] + "\r\n";
            textBox4.Text += "ʵ���ʱ�:" + items["ʵ���ʱ�"]["words"] + "\r\n";
            textBox4.Text += "��׼����: " + items["��׼����"]["words"] + "\r\n";
            textBox4.Text += "��������: " + items["��������"]["words"] + "\r\n";
            textBox4.Text += "˰��ǼǺ�: " + items["˰��ǼǺ�"]["words"] + "\r\n";
            textBox4.Text += "��ַ: " + items["��ַ"]["words"] + "\r\n";
            textBox4.Text += "�Ǽǻ���: " + items["�Ǽǻ���"]["words"] + "\r\n";
            textBox4.Text += "����: " + items["����"]["words"] + "\r\n";


        }
        // ��ʻ֤ʶ��
        public void DrivingLicenseDemo()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);

            // ����п�ѡ����
            var options = new Dictionary<string, object>{
        {"detect_direction", "true"}
    };
            // ���������ü�ʻ֤ʶ��
            var result = client.DrivingLicense(image, options);
            textBox4.Text += "����:" + result["direction"] + "\r\n";
            var items = result["words_result"];
            textBox4.Text += "����: " + items["����"]["words"] + "\r\n";
            textBox4.Text += "��Ч��ʼ����: " + items["��Ч����"]["words"] + "\r\n";
            textBox4.Text += "ʧЧ����: " + items["��"]["words"] + "\r\n";
            textBox4.Text += "��������: " + items["��������"]["words"] + "\r\n";
            textBox4.Text += "֤��: " + items["֤��"]["words"] + "\r\n";
            textBox4.Text += "סַ: " + items["סַ"]["words"] + "\r\n";
            textBox4.Text += "��֤��λ: " + items["��֤��λ"]["words"] + "\r\n";
            textBox4.Text += "����: " + items["����"]["words"] + "\r\n";
            textBox4.Text += "׼�ݳ���: " + items["׼�ݳ���"]["words"] + "\r\n";
            textBox4.Text += "�Ա�: " + items["�Ա�"]["words"] + "\r\n";
        }
        // ��ʻ֤ʶ��
        public void VehicleLicenseDemo()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            // ������ʻ֤ʶ�𣬿��ܻ��׳�������쳣����ʹ��try/catch����
            var result = client.VehicleLicense(image);
            var items = result["words_result"];
            textBox4.Text += "����ʶ�����: " + items["����ʶ�����"]["words"] + "\r\n";
            textBox4.Text += "סַ: " + items["סַ"]["words"] + "\r\n";
            textBox4.Text += "��֤��λ: " + items["��֤��λ"]["words"] + "\r\n";
            textBox4.Text += "��������: " + items["��������"]["words"] + "\r\n";
            textBox4.Text += "Ʒ���ͺ�: " + items["Ʒ���ͺ�"]["words"] + "\r\n";
            textBox4.Text += "��֤����: " + items["��֤����"]["words"] + "\r\n";
            textBox4.Text += "������: " + items["������"]["words"] + "\r\n";
            textBox4.Text += "���ƺ���: " + items["���ƺ���"]["words"] + "\r\n";
            textBox4.Text += "ʹ������: " + items["ʹ������"]["words"] + "\r\n";
            textBox4.Text += "����������: " + items["����������"]["words"] + "\r\n";
            textBox4.Text += "ע������: " + items["ע������"]["words"] + "\r\n";
        }
        // ����ʶ��
        public void LicensePlateDemo()
        {
            textBox4.Clear();
            var image = File.ReadAllBytes(textBox1.Text);
            // ���ó���ʶ�𣬿��ܻ��׳�������쳣����ʹ��try/catch����
            var result = client.LicensePlate(image);
            textBox4.Text = "���ƺ���: " + result["words_result"]["number"] + "\r\n" + "������ɫ: " + result["words_result"]["color"] + "\r\n";

        }
        // �������ʶ��
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

        //��ȡ���
        public void TableRecognitionGetResultDemo(string requestId)
        {
            textBox5.Clear();
            // ����п�ѡ����
            var options = new Dictionary<string, object>{
        {"result_type", "json"}
                    };
            // ���������ñ��ʶ���� 
            var result = client.TableRecognitionGetResult(requestId, options);
            textBox5.Text += result;
            button5.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "ѡ���ļ�";
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
                GeneralBasicDemo();//ͨ��
            }
            else if (radioButton2.Checked && !checkBox1.Checked)
            {
                AccurateBasicDemo();//�߾���
            }
            else if (radioButton1.Checked && checkBox1.Checked)
            {
                GeneralDemo();//ͨ�ú�λ��
            }
            else if (radioButton2.Checked && checkBox1.Checked)
            {
                AccurateDemo();//�߾��Ⱥ�λ��
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