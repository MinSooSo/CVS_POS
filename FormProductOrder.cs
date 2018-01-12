using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSVPos
{
    public partial class FormProductOrder : Form
    {
        private DataSet CSVData;
        private List<ProductOrder> proorderlist = new List<ProductOrder>();
        private List<ProductOrder> templist = new List<ProductOrder>();
        private string barcode;
        private int po_num = 1;
        private string po_productName;
        private int po_productPrice;
        private string po_unit;
        private int po_amount;
        private DateTime po_time = DateTime.Now;
        private string po_person;
        private DateTime po_payMentDay = DateTime.Now;
        public FormProductOrder()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 발주 받을 수 있는 상품 폼 로드시 GridView 출력
        /// 2018.01.10 남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormProductOrder_Load(object sender, EventArgs e)
        {
            timeStart();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand("si_selectSupplier", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
               
                    CSVData = new DataSet();
                    adapter.Fill(CSVData);

               
                    dgv_Supplier.ColumnCount = 4;
                    for (int i = 0; i < dgv_Supplier.ColumnCount; i++)
                    {
                        dgv_Supplier.Columns[i].Width = 204;
                    }
                    dgv_Supplier.Columns[0].Name = "바코드";
                    dgv_Supplier.Columns[1].Name = "상품 명";
                    dgv_Supplier.Columns[2].Name = "회사 명";
                    dgv_Supplier.Columns[3].Name = "상품 가격 : 단위(\\)";
                    DataTable suptable = CSVData.Tables[0];

                    DataRowCollection rows = suptable.Rows;

                    foreach (DataRow item in rows)
                    {
                        dgv_Supplier.Rows.Add(item["barCode"], item["SP_productName"], item["SP_companyName"], item["SP_productPrice"].ToString());
                    }
                }
            }
        }
        /// <summary>
        /// 현재시간 함수
        /// </summary>
        public void timeStart()
        {
            label7.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }
        /// <summary>
        /// 타이머
        /// </summary>
        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            Invoke((MethodInvoker)delegate
            {
                label7.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            });
        }
        /// <summary>
        /// 상품 목록에서 추가 하고 싶은 상품 발주리스트에 추가
        /// 2018.01.10 남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProAdd_Click(object sender, EventArgs e)
        {
           
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString);
                
                    con.Open();
                    string query = "Select PO_num from dbo.CVS_ProductOrder";
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(query, con);
                    CSVData = new DataSet();
                    adapter.Fill(CSVData);
                    DataTable table = CSVData.Tables[0];

                    DataRowCollection rows = table.Rows;
                   
                    foreach (DataRow item in rows)
                    {
                        po_num = int.Parse(item["PO_num"].ToString()) + 1;
                    }
                    barcode = dgv_Supplier.CurrentRow.Cells[0].Value.ToString();
                    //po_Pk = po_num + barcode;
                    po_productName = dgv_Supplier.CurrentRow.Cells[1].Value.ToString();
                    po_productPrice = int.Parse(dgv_Supplier.CurrentRow.Cells[3].Value.ToString());
                    po_unit = cboOrderUnit.SelectedItem.ToString();
                    po_amount = int.Parse(txtordernum.Text.ToString());

                    proorderlist.Add(new ProductOrder(po_num, barcode, po_productName, po_productPrice, po_unit, po_amount));


                    ProductListOutput();
                
            }
            catch (Exception)
            {
                ProductListOutput();
                MessageBox.Show("발주 단위 와 발주 갯수를 정해주세요!!");
            }
        }
        /// <summary>
        /// 프로덕트 리스트에 있는 value 표출 
        /// 2018.01.11 남수인
        /// </summary>
        private void ProductListOutput()
        {
            dgv_Order.DataSource = null;
            dgv_Order.DataSource = proorderlist;
            
            //그리드뷰 이름 설정
            string[] str = { "발주 번호", "바코드", "발주 물품", "발주 가격", "발주 단위", "발주 갯수" };
            for (int j = 0; j < str.Length; j++)
            {
                dgv_Order.Columns[j].HeaderText = str[j];
            }
            txtordernum.Text = " ";
            for (int i = 0; i < dgv_Order.Columns.Count-1; i++)
            {
                dgv_Order.Columns[i].ReadOnly = true;
            }
            for (int i = 0; i < dgv_Order.ColumnCount; i++)
            {
                dgv_Order.Columns[i].Width = 136;
            }
        }
        /// <summary>
        /// 카드 인지 현금 인지
        /// 2018.01.10
        /// </summary>
        /// <returns></returns>
        private bool CardCash()
        {
            if (cboCashCard.SelectedItem.ToString() == "카드")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 박스 인지 갯수 단위
        /// 2018.01.10 남수인
        /// </summary>
        /// <returns></returns>
        private bool BoxEabool(string v)
        {
            if (v == "BOX")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 주문갯수 숫자,백스패이스만 가능한 부분
        /// 2018.01.10 남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">누른 키</param>
        private void txtordernum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// 그리드뷰 (productList) 데이터 정보 삭제
        /// 2018.01.11 남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProDel_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < proorderlist.Count; i++)
            {
                if (dgv_Order.CurrentCellAddress.Y != i)
                {
                    templist.Add(new ProductOrder(proorderlist[i].Po_num, proorderlist[i].Barcode, proorderlist[i].Po_productName, proorderlist[i].Po_productPrice, proorderlist[i].Po_unit, proorderlist[i].Po_amount));
                    
                }
            }

            proorderlist.Clear();
            foreach (var item in templist)
            {
                proorderlist.Add(item);
            }
            ProductListOutput();

            templist.Clear();
        }
        /// <summary>
        /// 발주 DB에 발주 목록 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProductOrder_Click(object sender, EventArgs e)
        {
           
            //try { 
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString))
                    {
                for (int i = 0; i < proorderlist.Count; i++)
                    {
                    con.Open();
                    var cmd = new SqlCommand("si_ProductOrderInsert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ponum", proorderlist[i].Po_num);
                    cmd.Parameters.AddWithValue("@barcode", proorderlist[i].Barcode);
                    cmd.Parameters.AddWithValue("@productname", proorderlist[i].Po_productName);
                    cmd.Parameters.AddWithValue("@productprice", proorderlist[i].Po_productPrice);
                    cmd.Parameters.AddWithValue("@unit", BoxEabool(proorderlist[i].Po_unit));
                    cmd.Parameters.AddWithValue("@amount", proorderlist[i].Po_amount);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    }

                con.Open();
                var cmd2 = new SqlCommand("si_OrderInsert", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@ponum", proorderlist[0].Po_num);
                cmd2.Parameters.AddWithValue("@time", po_time);
                cmd2.Parameters.AddWithValue("@person", "남수인");
                cmd2.Parameters.AddWithValue("@payMent", CardCash());
                cmd2.Parameters.AddWithValue("@payMentDay", po_payMentDay);
                cmd2.ExecuteNonQuery();
                con.Close();
                proorderlist.Clear();
            }
            //}
            //catch
            //{
            //    MessageBox.Show("현금인지 카드인지 선택해주세요");
            //}

            MessageBox.Show("발주 되었습니다.");
            dgv_Order.DataSource = null;
            po_num = po_num + 1;
        }
    }
}
