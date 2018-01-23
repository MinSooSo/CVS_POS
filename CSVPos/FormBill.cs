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
        private SqlConnection con;
        private DataTable products;
        private int totalPrice;

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
                        MakeRows(sdr["S_num"].ToString(), sdr["S_sellDate"].ToString(), sdr["S_staff"].ToString(), sdr["S_buyWay"].ToString());
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            object hash = new object();
           
            txtBillPreview.Text = "";

            int test = dataGridView1.SelectedCells[0].RowIndex + 1;
            MessageBox.Show(test.ToString());

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
                        txtBillPreview.Text += sdr["S_productName"].ToString() + "\t\t          ";
                        txtBillPreview.Text += sdr["S_amount"].ToString() + "\t\t\t";
                        txtBillPreview.Text += sdr["S_sellPrice"].ToString() + "\t";
                    }
                    txtBillPreview.Text += "\r\n\r\n";
                }
                con.Close();
            }

            string buyWay = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            if (buyWay == "카드 결제")
            {
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
                            txtBillPreview.Text += "카드 번호 : " + sdr2["CardNumber"].ToString()+"\r\n";
                            txtBillPreview.Text += "카드 회사 : " + sdr2["CardCompanyNum"].ToString() + "\t\t\t            " + sdr2["CardCompanyName"].ToString() + "\r\n";
                            txtBillPreview.Text += "할부 개월 : " + "00\t\t      " + "   승인 번호 : "+ hash.GetHashCode();                           
                        }
                    }
                    txtBillPreview.Text += "------------------------------------------------------\t\n";
                    txtBillPreview.Text += "총 구 매 액 : " + "\r\n"; // 여기에 갯수랑 금액 다 더한거 빼야합니다. 
                    txtBillPreview.Text += "------------------------------------------------------\t\n\r\n";
                    txtBillPreview.Text += "과세물품가액 : " + "\r\n";
                    txtBillPreview.Text += "부   가   세 : " + "\r\n";
                    txtBillPreview.Text += "------------------------------------------------------\t\n";
                    txtBillPreview.Text += "내   실   돈 : " + "\r\n";
                    txtBillPreview.Text += "신 용 카 드 : " + "\r\n";
                    txtBillPreview.Text += "*표시 상품은 부가세 면세 품목 임.\r\n";
                    txtBillPreview.Text += "환불:30일내 영수증/카드 지참시 가능.\r\n";
                    txtBillPreview.Text += "객층...?";
                }
                con.Close();
            }
            else
            {
                txtBillPreview.Text += "********************  현 금 결 제   *********************\t\r\n";
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

            dataGridView1.DataSource = products;
        }

        private void MakeRows(string sellnum, string selldate, string sellstaff, string charge)
        {
            DataRow newRow = products.NewRow();

            products.Rows.Add(newRow);

            newRow["NO"] = sellnum;
            newRow["판매일"] = selldate;
            newRow["판매자"] = sellstaff;

            if (charge == "True")
            {
                newRow["결제 방법"] = "카드 결제";
            }
            else
            {
                newRow["결제 방법"] = "현금 결제";
            }
        }

        private void MakeTxtBasicForm()
        {
            PictureBox pic = new PictureBox();
            pic.Width = 333;
            pic.Height = 60;

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
                        txtBillPreview.Text += "편돌이 편순이 " + sdr["SI_name"].ToString() + "\r\n";
                        txtBillPreview.Text += "사업자등록번호 : " + sdr["SI_ID"].ToString() + "\r\n";

                        txtBillPreview.Text += sdr["SI_address"].ToString() + "\r\n";


                        txtBillPreview.Text += "대표자 : " + sdr["SI_bossName"].ToString();
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
    }
}
