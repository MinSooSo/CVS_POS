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
        private string empNum;
        private string empName;
        private SqlConnection con;
        private DataTable products;
        private int proNum = 1;
        private int eaCount = 1;
        private bool newProduct = false;
        int allPrice = 0;


        string afterDC;
        FormDiscount fd;

        public string EmpNum { get => empNum; set => empNum = value; }
        public string EmpName { get => empName; set => empName = value; }

        public SellMonitor()
        {
            InitializeComponent();
        }

        private void SellMonitor_Load(object sender, EventArgs e)
        {
            timeStart();
            label4.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            label11.Text = EmpName;
            label12.Text = EmpNum;
            MakeTable();

        }

        private void MakeTable()
        {
            products = new DataTable();
            products.Columns.Add("NO");
            products.Columns.Add("상품명");
            products.Columns.Add("단가", typeof(int));
            products.Columns.Add("수량", typeof(int));
            products.Columns.Add("금액", typeof(double));
            products.Columns.Add("할인");

            dataGridView1.DataSource = products;
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
          
            staffNum sn = new staffNum();
            sn.Formname = "sell";
            sn.Show();
            this.Close();
          
        }

        private void btnExit_Click(object sender, EventArgs e) // 판매 완료를 눌렀을 때
        {
            // datagidview랑 각종 textbox 지우세요. datasource 등등
            // DB에도 Insert 하세요 

            // 객층 선택 키 숨겨둠 ==> 카드 결제, 기프티콘 결제 이후에 작동 2018.01.16
            CustomerAgeSex cas = new CustomerAgeSex();
            cas.ShowDialog();

            if (txtTakeMoney.Text == "")
            {
                txtTakeMoney.Text = txtPrice.Text; 

               
            }
            else
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) // 종료 picture을 눌렀을 때 
        {
            if(MessageBox.Show("판매 관리창에서 바로 종료할 수 없습니다. \t\n 확인 버튼을 누르시면 메인화면으로 이동합니다.","판매 종료 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)== DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnTakbae_Click(object sender, EventArgs e) // 택배 접수 버튼을 눌렀을 때
        {
            frmPost fp = new frmPost();
            fp.Show();
        }

        private void btnDiscount_Click(object sender, EventArgs e) // 할인 사용 여부를 눌렀을 때 
        {
            // 폼 사이의 데이터 이동을 위해 전역변수로 선언. 2018.01.19
            fd = new FormDiscount();

            fd.txtBeforeDC.Text = allPrice.ToString();
            fd.ShowDialog();

            txtPrice.Text = fd.SendPrice().ToString();
            txtDiscount.Text = fd.SendPercent().ToString();
        }

        private void btnCredit_Click(object sender, EventArgs e) // 카드 결제를 눌렀을 때
        {
            PayCredit pc = new PayCredit();
            pc.ShowDialog();
        }

        private void btnBill_Click(object sender, EventArgs e)// 영수증 발급을 눌렀을 때
        {
            FormBill fb = new FormBill();
            fb.Show();
        }

        private void btnGifti_Click(object sender, EventArgs e) // 기프티콘 결제 버튼을 눌렀을 때
        {
            //FormGifti fg = new FormGifti();
            //fg.ShowDialog();
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {            
            if (txtBarcode.Text.Length == 8 || txtBarcode.Text.Length == 13)
            {
                con = Connection.GetInstance();
                
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
                            MakeRows(proNum, sdr["PS_productName"].ToString(), sdr["PS_sellPrice"].ToString());

                            txtBarcode.Text = "";
                            txtBarcode.Focus();
                        }
                    }
                }
                con.Close();
               
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = products;            
        }

        private void MakeRows(int proNum, string name, string price)
        {
            if (products.Rows.Count == 0) // 바코드를 처음 찍을 때
            {
                eaCount = 1;
               
                DataRow newRow = products.NewRow();
                products.Rows.Add(newRow);
                newRow["NO"] = proNum;
                newRow["상품명"] = name;
                newRow["단가"] = price;
                newRow["수량"] = eaCount;
                newRow["금액"] = int.Parse(price) * eaCount;
                newRow["할인"] = 0;

                txtProduct.Text = name;
                txtEA.Text = eaCount.ToString();
                allPrice = int.Parse(price);
                txtPrice.Text = allPrice.ToString();
            }
            else // 이미 찍힌 바코드가 있을 때
            {
                proNum++;
                
                foreach (DataRow row in products.Rows)
                {
                   
                    if (row["상품명"].ToString() != name)
                    {
                        newProduct = true;
                    }
                    else 
                    {
                        newProduct = false;                        
                        eaCount = int.Parse(row["수량"].ToString()); 
                        eaCount++;
                        row["수량"] = eaCount;                  
                        row["금액"] = eaCount * int.Parse(price);
                        txtProduct.Text = name;
                        txtEA.Text = eaCount.ToString();
                        allPrice += (int)row["단가"];
                        txtPrice.Text = allPrice.ToString();
                        return;
                    }
                }
                   
                if (newProduct)
                {
                    eaCount = 1;
                    
                    DataRow newRow = products.NewRow();
                    products.Rows.Add(newRow);
                    newRow["NO"] = proNum;
                    newRow["상품명"] = name;
                    newRow["단가"] = price;
                    newRow["수량"] = eaCount;
                    newRow["금액"] = int.Parse(price) * eaCount;
                    newRow["할인"] = 0;

                    txtProduct.Text = name;
                    txtEA.Text = eaCount.ToString();
                    allPrice += int.Parse(price);
                    txtPrice.Text = allPrice.ToString();                    
                }
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtBarcode_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = "";
          
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            //int calcPrice = int.Parse(txtPrice.Text) - int.Parse(txtDiscount.Text);
            //txtTakeMoney.Text = calcPrice.ToString();
        }
    }
}
