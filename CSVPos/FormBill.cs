using Barcode128;
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
    public partial class FormBill : Form
    {
        // 영수증에 추후 추가해야 하는 것. 

        // 택배 정보 
        // 카드 할인 정보 
        // 통신사 할인 정보 
        //  뭐ㅅㅂ 뭐 

        // 문제점 발견 : 바코드값은 유동적으로 안바뀌는데 왜때무니죠 

        private SqlConnection con;
        private DataTable products;
        private int totalPrice;
        private int productsPrice;
        private int count = 1;
        private int tax = 0;
        private int amountTaxAfter = 0;
        private int totalStock = 0;
        private int customerCharge = 0;
        private int rechargeMoney = 0;
        SortedList<int, int> priceList = new SortedList<int, int>();
        SortedList<int, string> stockList = new SortedList<int, string>();
        SortedList<int, int> customerChargeList = new SortedList<int, int>();
        SortedList<int, string> billBarcodeList = new SortedList<int, string>();

        public FormBill()
        {
            InitializeComponent();
        }


        private void btnPrint_Click(object sender, EventArgs e) // 해당 영수증 발행을 눌렀을 때
        {
        }

        private void btnSearch_Click(object sender, EventArgs e) // 영수증 조회를 눌렀을 때 
        {

        }

        private void btnReturn_Click(object sender, EventArgs e) // 판매화면으로 돌아가기
        {
            this.Close();
        }

        private void FormBill_Load(object sender, EventArgs e)
        {
            // 바코드 제작을 위한 textbox이지만, 보이지 않아도 되는 정보기 때문에 hide 합니다. 
            txtBarcodeBefore.Hide();
            txtBarcodeAfter.Hide();

            MakeTable();
            timeStart();

            MakeTxtBasicForm();

            con = Connection.GetInstance();

            using (SqlCommand cmd = new SqlCommand("ms_billDataPreview", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        MakeRows(sdr["S_num"].ToString(), sdr["S_sellDate"].ToString(), sdr["S_staff"].ToString(), sdr["S_buyWay"].ToString(), sdr["S_gifticon"].ToString(), sdr["S_billBarcode"].ToString(), sdr["S_teleDiscount"].ToString());
                    }
                }
                con.Close();
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            object hash = new object();
            totalPrice = 0;
            totalStock = 0;
            priceList.Clear();
            stockList.Clear();
            customerChargeList.Clear();
            billBarcodeList.Clear();

            txtBillPreview.Text = "";

            int test = dataGridView1.SelectedCells[0].RowIndex + 1;

            con = Connection.GetInstance();

            using (SqlCommand cmd = new SqlCommand("ms_selectSellRecord_All", con))
            {
                MakeTxtBasicForm();
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@snum", test);

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {

                    while (sdr.Read())
                    {
                        txtBillPreview.Text += "\r\n";
                        txtBillPreview.Text += " " + sdr["S_productName"].ToString() + "\t\t          ";
                        txtBillPreview.Text += sdr["S_amount"].ToString() + "\t\t\t";
                        txtBillPreview.Text += sdr["S_sellPrice"].ToString() + "\t";

                        productsPrice = int.Parse(sdr["S_amount"].ToString()) * int.Parse(sdr["S_sellPrice"].ToString()); // 상품 품목별 총 금액 ( 갯수 * 판매금액 )  = productsPrice

                        priceList.Add(count, productsPrice);
                        stockList.Add(count, sdr["S_amount"].ToString());

                        customerChargeList.Add(count, int.Parse(sdr["S_customerCharge"].ToString()));

                        billBarcodeList.Add(count, sdr["S_billBarcode"].ToString());

                        count++;
                    }
                    txtBillPreview.Text += "\r\n\r\n";

                    // 제너릭 클래스로 선언하여 해당 구현함. 

                    foreach (KeyValuePair<int, int> item in priceList)
                    {
                        totalPrice += item.Value;
                    }

                    foreach (KeyValuePair<int, string> item in stockList)
                    {
                        totalStock += int.Parse(item.Value);
                    }

                    foreach (KeyValuePair<int, int> item in customerChargeList)
                    {
                        int check = item.Key;

                        if (check == 1)
                        {
                            int checkCharge = item.Value;

                            if (checkCharge == 0)
                            {
                                customerCharge = totalPrice;
                            }
                            else
                            {
                                customerCharge = item.Value;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    foreach (KeyValuePair<int, string> item in billBarcodeList)
                    {
                        int check = item.Key;

                        if (check == 1)
                        {
                            txtBarcodeBefore.Text = item.Value;
                        }
                        else
                        {
                            break;
                        }
                    }

                    tax = totalPrice / 10;
                    amountTaxAfter = totalPrice - tax;
                    rechargeMoney = customerCharge - totalPrice;

                    //txtBillPreview.Text += totalPrice.ToString();

                    for (int i = 0; i < count; i++)
                    {
                        priceList.Remove(i);
                    }
                }
                con.Close();
            }

            string buyWay = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string gifticon = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string discount = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            txtBarcodeBefore.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            if (discount == "할인 적용")
            {
                txtBillPreview.Text += "********************  할 인 정 보   *********************\t\r\n\r\n";

                using (SqlCommand cmd2 = new SqlCommand("ms_insertBillCardInfo", con))
                {
                    con.Open();


                }
            }
            else if (discount == "할인 미적용" || discount == "사용 불가")
            {
                return;
            }

            if (buyWay == "카드 결제")
            { // 카드 결제시 처리해야하는 부분. 
                txtBillPreview.Text += "********************  신 용 카 드   *********************\t\r\n\r\n";

                using (SqlCommand cmd2 = new SqlCommand("ms_insertBillCardInfo", con))
                {
                    con.Open();
                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.AddWithValue("@cardNum", "1111-1111-1111-1111");

                    SqlDataReader sdr2 = cmd2.ExecuteReader();

                    if (sdr2.HasRows)
                    {
                        while (sdr2.Read())
                        {
                            txtBillPreview.Text += " 카드 번호 : " + sdr2["CardNumber"].ToString() + "\r\n";
                            txtBillPreview.Text += " 카드 회사 : " + sdr2["CardCompanyNum"].ToString() + "\t\t\t           " + sdr2["CardCompanyName"].ToString() + "\r\n";
                            txtBillPreview.Text += " 할부 개월 : " + "00\t\t      " + "   승인 번호 : " + hash.GetHashCode();
                        }
                    }
                    totalStocknPrice();

                    txtBillPreview.Text += " 내   실   돈 : \t\t\t\t " + totalPrice.ToString() + "\r\n";
                    txtBillPreview.Text += " 신 용 카 드 : \t\t\t\t " + totalPrice.ToString() + "\r\n";
                    txtBillPreview.Text += "------------------------------------------------------\t\n\r\n";
                    txtBillPreview.Text += " *표시 상품은 부가세 면세 품목 임.\r\n";
                    txtBillPreview.Text += " 환불:30일내 영수증/카드 지참시 가능.\r\n";
                }
                con.Close();
            }
            else
            { // 현금 결제시 처리해야하는 코드 부분 . 
                txtBillPreview.Text += "********************  현 금 결 제   *********************\t\n\r\n";

                if (gifticon == "사용")
                {
                    totalStocknPrice();

                    txtBillPreview.Text += " 기프티콘 사용 여부 : \t\t\t " + gifticon.ToString() + "\r\n";
                    txtBillPreview.Text += " 기프티콘 사용 금액 : \t\t\t " + totalPrice.ToString() + "\r\n";
                    txtBillPreview.Text += "------------------------------------------------------\t\n\r\n";
                    txtBillPreview.Text += " 내   실   돈 : \t\t\t\t " + totalPrice.ToString() + "\r\n";
                    txtBillPreview.Text += " 내   신   돈 : \t\t\t\t " + "면 제" + "\r\n";
                    txtBillPreview.Text += " 거  스  름  돈 : \t\t\t\t " + "0" + "\r\n";
                    txtBillPreview.Text += "------------------------------------------------------\t\n\r\n";
                    txtBillPreview.Text += " *표시 상품은 부가세 면세 품목 임.\r\n";
                    txtBillPreview.Text += " 환불:30일내 영수증/카드 지참시 가능.\r\n";
                }
                else
                {
                    totalStocknPrice();

                    txtBillPreview.Text += "\r\n 내   실   돈 : \t\t\t\t " + totalPrice.ToString() + "\r\n";
                    txtBillPreview.Text += " 내   신   돈 : \t\t\t\t " + customerCharge.ToString() + "\r\n";
                    txtBillPreview.Text += " 거  스  름  돈 : \t\t\t\t " + rechargeMoney.ToString() + "\r\n";
                    txtBillPreview.Text += "------------------------------------------------------\t\n\r\n";
                    txtBillPreview.Text += " *표시 상품은 부가세 면세 품목 임.\r\n";
                    txtBillPreview.Text += " 환불:30일내 영수증/카드 지참시 가능.\r\n";
                }
            }
        }

        /* 메서드 모음 */

        private void MakeTable()
        {
            products = new DataTable();

            products.Columns.Add("NO");
            products.Columns.Add("판매일");
            products.Columns.Add("판매자");
            products.Columns.Add("결제 방법");
            products.Columns.Add("기프티콘 여부");
            products.Columns.Add("바코드");
            products.Columns.Add("할인 여부");

            dataGridView1.DataSource = products;
        }

        private void MakeRows(string sellnum, string selldate, string sellstaff, string charge, string giftiCon, string barCode, string discount)
        {
            DataRow newRow = products.NewRow();

            products.Rows.Add(newRow);

            newRow["NO"] = sellnum;
            newRow["판매일"] = selldate;
            newRow["판매자"] = sellstaff;
            newRow["바코드"] = barCode;
            //newRow["할인 여부"] = discount;

            if (charge == "True")
            {
                newRow["결제 방법"] = "카드 결제";

                newRow["기프티콘 여부"] = "사용 불가";
                
                if(discount == "True")
                {
                    newRow["할인 여부"] = "할인 적용";
                }
                else
                {
                    newRow["할인 여부"] = "할인 미적용";
                }
            }
            else
            {
                newRow["결제 방법"] = "현금 결제";

                if (giftiCon == "True")
                {
                    newRow["기프티콘 여부"] = "사용";
                    newRow["할인 여부"] = "사용 불가";
                }
                else
                {
                    newRow["기프티콘 여부"] = "미사용";

                    if (discount != null)
                    {
                        newRow["할인 여부"] = "할인 적용";
                    }
                    else if(discount == null)
                    {
                        newRow["할인 여부"] = "할인 미적용";
                    }
                }
            }
        }
        

        private void MakeTxtBasicForm()
        {
            PictureBox pic = new PictureBox();
            pic.Width = 333;
            pic.Height = 60;

            // bitmap graphics 지원함. 

            pic.Image = new Bitmap(@"C:\Users\Minsoo.so\source\repos\CSVPos\CSVPos\mainTitle.PNG");
            txtBillPreview.Controls.Add(pic);

            txtBillPreview.Text += "\r\n\r\n\r\n\r\n\r\n";
            txtBillPreview.Text += "******************************************************\t\n";
            txtBillPreview.Text += "***************  최근 영수증 발행 인쇄  ****************\t\n";
            txtBillPreview.Text += "******************************************************\t\n";


            con = Connection.GetInstance();

            using (SqlCommand cmd = new SqlCommand("ms_loadstoreInfomation", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                txtBillPreview.Text += "\r\n";
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        txtBillPreview.Text += " 편돌이 편순이 " + sdr["SI_name"].ToString() + "\r\n";
                        txtBillPreview.Text += " 사업자등록번호 : " + sdr["SI_ID"].ToString() + "\r\n";

                        txtBillPreview.Text += sdr["SI_address"].ToString() + "\r\n";


                        txtBillPreview.Text += " 대표자 : " + sdr["SI_bossName"].ToString();
                        txtBillPreview.Text += "  TEL : " + sdr["SI_phoneNum"].ToString() + "\r\n";
                    }
                }
                txtBillPreview.Text += "\r\n";
                txtBillPreview.Text += "******************************************************\r\n";

                txtBillPreview.Text += "정부 방침에 의해 12년 07월 01일 부터 현금 결제 취소시, 영수증이 없으면 교환/ 환불이 불가합니다. \r\n\r\n";

                con.Close();
            }

            using (SqlCommand cmd2 = new SqlCommand("ms_selectPosInfo", con))
            {
                con.Open();
                cmd2.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = cmd2.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        txtBillPreview.Text += sdr["pos_num"].ToString() + "\t\t";
                        txtBillPreview.Text += DateTime.Now.ToString("yyyy/MM/dd").ToString() + "(" + DateTime.Now.Date.ToString("ddd") + ")\t\t";

                        txtBillPreview.Text += sdr["pos_nickname"].ToString() + "\r\n";
                    }
                }
                con.Close();
            }
        }


        public void timeStart()
        {
            label5.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            Invoke((MethodInvoker)delegate
            {
                label5.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            });
        }

        private void totalStocknPrice()
        {

            // txtBillPreview.Text += "------------------------------------------------------\t\n\r\n";
            txtBillPreview.Text += " 총 구 매 액 : \t\t" + totalStock.ToString() + " \t\t " + totalPrice.ToString() + "\r\n\r\n"; // 여기에 갯수랑 금액 다 더한거 빼야합니다. 
            txtBillPreview.Text += "------------------------------------------------------\t\n";
            txtBillPreview.Text += " 과세물품가액 : \t\t\t\t " + amountTaxAfter.ToString() + "\r\n";
            txtBillPreview.Text += " 부   가   세 : \t\t\t\t " + tax.ToString() + "\r\n";
            txtBillPreview.Text += "------------------------------------------------------\t\n";
        }

        // 바코드 출력 테스트. 
        private void txtTest_TextChanged(object sender, EventArgs e)
        {
            string txtTestLength = txtBarcodeBefore.Text.Trim();

            //MessageBox.Show(txtTestLength.Length.ToString());
            if (txtTestLength.Length == 18)
            {
                //MessageBox.Show("18자리 확인 완료");
                claBarcode bcTemp = new claBarcode();

                txtBarcodeAfter.Text = bcTemp.strBarcode(txtBarcodeBefore.Text, 0);
                txtBarcodeAfter.Text = bcTemp.strBarcodeToBar(txtBarcodeAfter.Text);

                GdiOutput(txtBarcodeAfter.Text);
            }

        }

        private void GdiOutput(string strBarData)
        {
            // 바데이터를 생성 -> 그래픽으로 제작하는 메서드 
            int intW = 1;

            Graphics graphics = pictureBox1.CreateGraphics();            

            // 펜 색 지정해주기, 흰색 , 검은색 
            Pen BlackPen = new Pen(Color.Black, intW);
            Pen WhitePen = new Pen(Color.White, intW);

            Brush BlackBrush = new SolidBrush(Color.Black);

            // 형 변환된 자료를 바코드로 표현
            for (int i = 0; i < strBarData.Length; ++i)
            {
                int intTemp = Convert.ToInt32(strBarData.Substring(i, 1));

                if (intTemp == 1)
                {
                    //검정색 출력
                    graphics.DrawLine(BlackPen, 30 + (i * intW), 10, 30 + (i * intW), 60);
                }
                else
                {
                    //하얀색 출력
                    graphics.DrawLine(WhitePen, 30 + (i * intW), 10, 30 + (i * intW), 60);
                }
            }

            // 바코드 텍스트 박스 안에 해주셈 

            //PictureBox pic2 = new PictureBox();

            //pic2.Width = 333;
            //pic2.Height = 60;
            //pic2.Image = new Bitmap()
            //textBox1.Controls.Add(pic2);

            //pic2.Show();

            txtBarcodeBefore.Text = txtBarcodeAfter.Text = txtBillBarCode.Text = "";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GdiOutput(txtBarcodeAfter.Text);
        }
    }
}
