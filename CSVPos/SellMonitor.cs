using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVPos
{
    public partial class SellMonitor : Form
    {
        /// <summary>
        /// 판매 완료 시 SellRecord에 기록되는 내용 중 변수로 있어야 할 것 
        /// 판매번호 : DB에서 Select 해온 후 +1 (첫번째 판매의 경우 생각해봐야함)
        /// 판매 경로 (카드/현금), 카드번호 : 카드결제, 현금결제 시 변수 true or false
        /// 할인가 : 할인 폼에서 가져옴
        /// 기프티콘 : 기프티콘 폼에서 작업 후 bool 타입 or string
        /// 고객 연령, 성별 : 객층 선택 폼에서 가져온 후 연령과 성별 분리
        /// </summary>
        private SqlConnection con; // SqlConnection 싱글톤
        private DataTable products; // 판매 그리드뷰에 쓰이는 데이터테이블
        private int proNum = 1; // 상품 번호
        private int eaCount = 1; // 상품 수량
        private bool newProduct = false; // 새 물건 바코드가 찍힐 경우 사용할 변수
        private int giftiNum; // 기프티콘 번호
        private bool buyCash = false;
        //private bool teleDc = false;
        private string teleDC = "";
        private bool UseGifti = false;
        private bool useCard = false;
        private bool gender = false;
        int allPrice = 0; // 총 결제 해야할 금액
        int sellNum; // 판매 번호
        string cardNum = "0";
        FormDiscount fd; // 할인 폼
        FormGifti fg; // 기프티콘 폼
        CustomerAgeGender cas; // 객층 선택 폼

        public string CardNum
        {
            get { return cardNum; }
            set { cardNum = value; }
        }
        public bool UseCard
        {
            get { return useCard; }
            set { useCard = value; }
        }

        public string TeleDC
        {
            get { return teleDC; }
            set { teleDC = value; }
        }

        public SellMonitor()
        {
            InitializeComponent();
        }

        private void SellMonitor_Load(object sender, EventArgs e)
        {
            timeStart();
            label4.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            MakeTable();

        }

        private void MakeTable()
        {
            products = new DataTable();
            products.Columns.Add("NO");
            products.Columns.Add("바코드");
            products.Columns.Add("상품명");
            products.Columns.Add("단가", typeof(int));
            products.Columns.Add("수량", typeof(int));
            products.Columns.Add("금액", typeof(double));
            products.Columns.Add("할인");
            products.Columns.Add("비고");

            dataGridView1.DataSource = products;
            dataGridView1.Columns["바코드"].Visible = false;
        }

        public void timeStart()
        {
            label2.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            Invoke((MethodInvoker)delegate
            {
                label2.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            });
        }

        private void btnGohome_Click(object sender, EventArgs e) // 직원 교대 테이블 
        {
            // 꺼졌다가 켜지는 부분 자연스럽게 가능한가염 아몰랑

            StaffNum sn = new StaffNum();
            sn.Formname = "sell";
            sn.Show();
            this.Close();

        }

        private void btnExit_Click(object sender, EventArgs e) // 판매 완료를 눌렀을 때 (현금 결제 버튼으로 바뀜)
        {
            buyCash = true;
            // datagidview랑 각종 textbox 지우세요. datasource 등등

            // 객층 선택 키 숨겨둠 ==> 카드 결제, 기프티콘 결제 이후에 작동 2018.01.16 (x)
            // 판매 완료 버튼은 현금 판매 버튼 2018.01.22

            // 판매 번호, 판매 날짜, 판매자, 판매 경로, 카드번호, 할인가, 기프티콘 정보를 넘겨?

            // 객층 선택 메서드
            SelectAgeGender();
        }

        private void SelectAgeGender()
        {
            cas = new CustomerAgeGender();

            // 객층 선택 버튼 10개에 동일한 클릭 이벤트 적용

            // DB에도 Insert 하세요 ( 버튼클릭이벤트)
            cas.btn10Fm.Click += Btn_Click;
            cas.btn10M.Click += Btn_Click;
            cas.btn20Fm.Click += Btn_Click;
            cas.btn20M.Click += Btn_Click;
            cas.btn30Fm.Click += Btn_Click;
            cas.btn30M.Click += Btn_Click;
            cas.btn40Fm.Click += Btn_Click;
            cas.btn40M.Click += Btn_Click;
            cas.btn50Fm.Click += Btn_Click;
            cas.btn50M.Click += Btn_Click;

            cas.ShowDialog();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            sellNum = FindSellNumber(); // 판매번호
            sellNum++; // 다음 판매니까 
            //MessageBox.Show(sellNum.ToString());

            // SellRecord, SellProduct 테이블에 insert 되야함.
            // 고객 연령과 성별을 나누어서 

            Button btn = (Button)sender;
            //MessageBox.Show(btn.Text.Split('대')[0].ToString());
            string age = btn.Text.Split('대')[0].ToString();

            //MessageBox.Show(btn.Text.Split('대')[1].Length.ToString());
            if (btn.Text.Split('대')[1].Length == 7) // 50대 이상 객층일 경우
            {
                if (btn.Text.Split('대')[1].Split('상')[1].ToString().Trim() == "남성")
                {
                    gender = true;
                }
                else
                {
                    gender = false;
                }
            }
            else
            {
                //MessageBox.Show(btn.Text.Split('대')[1].ToString());
                if (btn.Text.Split('대')[1].ToString().Trim() == "남성")
                {
                    gender = true;
                }
                else
                {
                    gender = false;
                }

            }

            //MessageBox.Show(sellNum.ToString());
            //MessageBox.Show("나이 : " + age + " 성별 : " + gender);
            if (UseGifti) // 기프티콘 결제일경우
            {
                InsertSellRecord("False", age, gender, "0");
                InsertSellProduct();

                MessageBox.Show("기프티콘으로 상품 결제 되었습니다");
                UseGifti = false;
                cas.Close();
            }
            else // 기프티콘 결제가 아닌 현금 / 카드 결제일 경우 
            {
                if (buyCash)
                {
                    if (txtCash.Text == "")
                    {
                        InsertSellRecord("False", age, gender, txtPrice.Text); // 현금결제라는 뜻
                    }
                    else
                    {
                        InsertSellRecord("False", age, gender, txtCash.Text); // 현금결제라는 뜻
                    }

                    InsertSellProduct(); // 영수증을 위해 만든 테이블에 row insert

                    MessageBox.Show("현금 결제 완료");

                    buyCash = false;
                    btnGifti.Enabled = true;
                    cas.Close();
                }
                else
                {
                    InsertSellRecord("True", age, gender, "0");
                    InsertSellProduct();

                    MessageBox.Show("카드 결제 완료");

                    useCard = false;
                    btnGifti.Enabled = true;
                    cas.Close();
                }
            }
        }

        // 판매 완료 -> 객층 선택 후 판매 추가
        private void InsertSellRecord(string way, string age, bool gender, string cash)
        {
            //MessageBox.Show(teleDC);
            //MessageBox.Show(gender.ToString());
            DateTime sellDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd ") + DateTime.Now.ToLongTimeString()); // 판매날짜
            string staff = "최승수"; // 판매자
            string buyWay = ""; // 판매경로
            buyWay = way;
            bool gifti;

            // 카드번호는 프로퍼티 사용
            if (!UseCard) // 카드를 사용했을 때
            {
                CardNum = "0";
            }

            // 기프티콘을 사용했을 경우
            if (giftiNum != 0)
            {
                gifti = true;
            }
            else // 기프티콘을 사용하지 않은 경우
            {
                gifti = false;
            }
            string billBarcode = "987654321234567890";

            con = Connection.GetInstance();
            using (SqlCommand cmd = new SqlCommand("ss_insertSellRecord", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sellNum", sellNum);
                cmd.Parameters.AddWithValue("@sellDate", sellDate);
                cmd.Parameters.AddWithValue("@staff", staff);
                cmd.Parameters.AddWithValue("@buyWay", buyWay);
                cmd.Parameters.AddWithValue("@cardNum", CardNum);
                cmd.Parameters.AddWithValue("@teleDiscount", teleDC);
                cmd.Parameters.AddWithValue("@gifticon", gifti);
                cmd.Parameters.AddWithValue("@custAge", age);
                cmd.Parameters.AddWithValue("@custGender", gender);
                cmd.Parameters.AddWithValue("@billBarcode", billBarcode);
                cmd.Parameters.AddWithValue("@customerCharge", cash);

                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    MessageBox.Show("판매 오류가 발생하였습니다. 다시 시도해주세요");
                }
            }
            con.Close();
        }

        private void InsertSellProduct() // ex) 판매번호 1의 상품이 3개 있으면 3개의 row가 SellProduct 테이블에 삽입되어야함
        {
            // 데이터테이블에 있는 한개의 DataRow마다 SellProduct 테이블에 insert.
            // 판매번호는 전역변수 sellNum 사용

            // 판매 번호를 제외한 나머지 값은 전부 데이터 테이블에서 뽑아와서 SellProduct 테이블에 insert 시키면 된다.

            con = Connection.GetInstance();
            foreach (DataRow row in products.Rows)
            {
                using (SqlCommand cmd = new SqlCommand("ss_insertSellProduct", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@sellNum", sellNum);
                    cmd.Parameters.AddWithValue("@barcode", row["바코드"].ToString());
                    cmd.Parameters.AddWithValue("@pName", row["상품명"].ToString());
                    cmd.Parameters.AddWithValue("@sPrice", row["단가"].ToString());
                    cmd.Parameters.AddWithValue("@sAmount", row["수량"].ToString());

                    int result = cmd.ExecuteNonQuery();
                    if (result == 0)
                    {
                        MessageBox.Show("판매 오류가 발생하였습니다. 다시 시도해주세요");
                    }
                }

                con.Close();
            }

            ComponentInit();
        }

        private int FindSellNumber()
        {
            int result;
            con = Connection.GetInstance();
            using (SqlCommand cmd = new SqlCommand("ss_FindSNum", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                result = (int)cmd.ExecuteScalar();

                // 가장 최근의 판매번호가 몇번인지 못찾았을 경우가 발생한다면 if나 try-catch로 처리.
            }
            con.Close();

            return result;
        }

        private void pictureBox1_Click(object sender, EventArgs e) // 종료 picture을 눌렀을 때 
        {
            if (MessageBox.Show("판매 관리창에서 바로 종료할 수 없습니다. \t\n 확인 버튼을 누르시면 메인화면으로 이동합니다.", "판매 종료 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnTakbae_Click(object sender, EventArgs e) // 택배 접수 버튼을 눌렀을 때
        {
            ComponentInit();
            //frmPost fp = new frmPost();
            //fp.Show();
        }

        private void ComponentInit()
        {
            // datagridview 초기화
            products.Rows.Clear();

            // 판매 폼의 텍스트박스 초기화
            foreach (var item in this.Controls)
            {
                if (item.GetType().ToString().EndsWith("GroupBox"))
                {
                    GroupBox gbox = (GroupBox)item;
                    foreach (var txtbox in gbox.Controls)
                    {
                        if (txtbox.GetType().ToString().EndsWith("TextBox"))
                        {
                            TextBox txt = (TextBox)txtbox;
                            txt.Text = "";
                        }
                    }
                }
            }
            dataGridView1.DataSource = products;
            dataGridView1.Columns["바코드"].Visible = false;
        }

        private void btnDiscount_Click(object sender, EventArgs e) // 할인 사용 여부를 눌렀을 때 
        {
            // 폼 사이의 데이터 이동을 위해 전역변수로 선언. 2018.01.19
            fd = new FormDiscount();
            fd.Owner = this;

            fd.txtBeforeDC.Text = allPrice.ToString();
            txtPrice.Text = fd.SendPrice().ToString();  // 결제 필요 금액
            txtDiscount.Text = fd.SendPercent().ToString(); // 할인받은 금액

            fd.ShowDialog();

        }

        private void btnCredit_Click(object sender, EventArgs e) // 카드 결제를 눌렀을 때
        {
            PayCredit pc = new PayCredit();
            pc.Owner = this;

            // 카드 결제 폼이 닫힌 후 객층 선택 폼 실행
            pc.FormClosing += Pc_FormClosing;


            pc.ShowDialog();
        }

        private void Pc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UseCard)
            {
                // 객층 선택 메서드
                SelectAgeGender();
            }
        }

        private void btnBill_Click(object sender, EventArgs e)// 영수증 발급을 눌렀을 때
        {
            FormBill fb = new FormBill();
            fb.Show();
        }

        private void btnGifti_Click(object sender, EventArgs e) // 기프티콘 결제 버튼을 눌렀을 때
        {
            fg = new FormGifti();

            fg.btnGifticonUse.Click += BtnGifticonUse_Click;
            fg.ShowDialog();
        }

        /// <summary>
        /// 2018.01.22 // 기프티콘 폼에서의 기프티콘 적용 버튼을 눌렀을 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGifticonUse_Click(object sender, EventArgs e)
        {
            UseGifti = true;
            double price = 0;
            giftiNum = int.Parse(fg.txtGifti.Text);
            // 데이터 테이블에 있는 상품 중 이름이 같으면 수량, 금액 조절 후 비고란에 기프티콘 추가, 
            // 사용한 기프티콘은 Useable = false 처리.

            if (txtProduct.Text == fg.txtProduct.Text) // 기프티콘 대상 상품과 현재 바코드 찍은 상품의 이름이 같다면
            { // 이름으로 비교할게 아니라 기프티콘에도 상품 바코드를 넣을것이면 컬럼만 추가하도록 하자. 2018.01.22
                for (int i = 0; i < products.Rows.Count; i++)
                {
                    if (products.Rows[i]["상품명"].ToString() == txtProduct.Text)
                    {
                        // 수량 안건드리겠습니다. 2018.01.24
                        //int count = (int)products.Rows[i]["수량"];
                        //products.Rows[i]["수량"] = count - 1;

                        //MessageBox.Show(products.Rows[i]["금액"].GetType().ToString());
                        price = (double)products.Rows[i]["금액"] - (int)products.Rows[i]["단가"];
                        products.Rows[i]["금액"] = price;
                        products.Rows[i]["비고"] = "기프티콘 사용";

                        // 기프티콘 테이블의 Useable 컬럼 값 변경 메서드
                        GiftiUseAbleFalse();
                        SelectAgeGender();
                    }
                }
                txtPrice.Text = price.ToString();

                fg.Close();
                ComponentInit();


            }
            else
            {
                MessageBox.Show("기프티콘 적용 대상이 없습니다.");
                fg.Close();
            }
        }

        /// <summary>
        /// 2018.01.22 // 기프티콘 적용 후 테이블 로우 수정
        /// </summary>
        private void GiftiUseAbleFalse()
        {
            con = Connection.GetInstance();
            using (SqlCommand cmd = new SqlCommand("ss_ChangeGiftiUseable", con))
            {
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@giftiNum", giftiNum);

                //MessageBox.Show(giftiNum.ToString());
                int result = cmd.ExecuteNonQuery();

                if (result == 0)
                {
                    MessageBox.Show("기프티콘 오류가 발생하였습니다. 다시 시도해주세요");
                }
                //if (result == 1)
                //{
                //    MessageBox.Show("기프티콘이 사용되었습니다. \r\n 객층 선택창으로 이동합니다.");
                //}
                //MessageBox.Show(result.ToString());
            }
            con.Close();
        }

        // 바코드 입력
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            // 화면 그리드뷰에 바코드 찍은 판매할 물건을 표시해주고
            // 이후에 할인, 기프티콘 결제 기능 작동하게 2018.01.18 txtBarcode.Text.Length == 8 || 
            if (txtBarcode.Text.Length == 13)
            {
                con = Connection.GetInstance();
                // 발주 테이블에서 맞는 바코드가 있으면 모든 정보를 출력해주는 저장프로시저
                //MessageBox.Show("바코드 입력 cmd 실행 전" + con.ConnectionString);
                using (SqlCommand cmd = new SqlCommand("ms_SelectStock", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text);


                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            MakeRows(proNum, sdr["barCode"].ToString(), sdr["PS_productName"].ToString(), sdr["PS_sellPrice"].ToString(), sdr["PS_warehousingDay"].ToString());
                            //gifti = sdr["PS_event"].ToString(); // 기프티콘 여부 조회? (DB랑 비교 2018.01.19.01:32)
                            txtBarcode.Text = "";
                            txtBarcode.Focus();
                        }
                    }
                }
                con.Close();
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = products;
            dataGridView1.Columns["바코드"].Visible = false;
        }

        private void MakeRows(int proNum, string barcode, string name, string price, string day)
        {

            //MessageBox.Show(proNum + " , " + name + " , " + price + " , " + ea);
            if (products.Rows.Count == 0) // 바코드를 처음 찍을 때
            {
                eaCount = 1;
                //MessageBox.Show("현재 바코드 없음");
                DataRow newRow = products.NewRow();
                products.Rows.Add(newRow);
                newRow["NO"] = proNum;
                newRow["바코드"] = barcode;
                newRow["상품명"] = name;
                newRow["단가"] = price;
                newRow["수량"] = eaCount;
                newRow["금액"] = int.Parse(price) * eaCount;
                newRow["할인"] = 0;

                txtProduct.Text = name;
                txtEA.Text = eaCount.ToString();
                allPrice = int.Parse(price);
                txtPrice.Text = allPrice.ToString();
                txtTime.Text = day;
            }
            else // 이미 찍힌 바코드가 있을 때
            {
                proNum++;
                foreach (DataRow row in products.Rows)
                {
                    //MessageBox.Show("행 추가하기 전 row : " + products.Rows.Count);
                    if (row["상품명"].ToString() != name) // 새로운 상품을 찍을 때
                    {
                        //MessageBox.Show(row["상품명"].ToString() + "검사 : " + name + "에 대한 새로운 상품 등록 필요");
                        newProduct = true;
                    }
                    else // 기존 상품을 찍을 때 (수량, 금액이 증가)
                    {
                        newProduct = false;
                        //MessageBox.Show(row["상품명"].ToString() + "검사 : 기존 상품 수량 증가");
                        // 접근하자 2018.01.18 20:34
                        eaCount = int.Parse(row["수량"].ToString()); // A 상품 찍고 B 상품의 수량을 늘릴 때 B 상품 기존 수량 가져오기
                        eaCount++;// 수량 증가를 위한 전역변수 값 증가
                        row["수량"] = eaCount;
                        row["금액"] = eaCount * int.Parse(price);

                        txtProduct.Text = name;
                        txtEA.Text = eaCount.ToString();
                        allPrice += (int)row["단가"];
                        txtPrice.Text = allPrice.ToString();
                        txtTime.Text = day;
                        return;
                    }
                }
                if (newProduct)
                {
                    //MessageBox.Show("바코드가 이미 찍혀있고 새로운 상품을 등록시킬 때");
                    eaCount = 1;
                    //MessageBox.Show("Test");
                    //MessageBox.Show(products.Rows.Count.ToString());
                    DataRow newRow = products.NewRow();
                    products.Rows.Add(newRow);
                    newRow["NO"] = proNum;
                    newRow["바코드"] = barcode;
                    newRow["상품명"] = name;
                    newRow["단가"] = price;
                    newRow["수량"] = eaCount;
                    newRow["금액"] = int.Parse(price) * eaCount;
                    newRow["할인"] = 0;

                    txtProduct.Text = name;
                    txtEA.Text = eaCount.ToString();
                    allPrice += int.Parse(price);
                    txtPrice.Text = allPrice.ToString();
                    txtTime.Text = day;
                }
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtBarcode_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = "";
            //txtProduct.Text = "";
            //txtTime.Text = "";
            //txtEA.Text = "";
            //txtPrice.Text = "";
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            if (txtCash.Text != "") // 안에 값이 채워져있을때에만 실행
            {
                int change = int.Parse(txtPrice.Text) - int.Parse(txtCash.Text);
                txtChange.Text = Math.Abs(change).ToString();
            }
            else
            {
                txtChange.Text = "";
            }
        }
    }
}