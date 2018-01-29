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
        private DataSet supData;
       // private DataSet pOrderData;
        private List<ProductOrder> prodOrderList = new List<ProductOrder>();
        private List<ProductOrder> templist = new List<ProductOrder>();
        private List<ProductOrder> EaSumList = new List<ProductOrder>();
        SqlConnection con = Connection.GetInstance();
        private string barcode;
        private string po_productName;
        private int po_productPrice;
        private int eaSum;
        private int bit = 0;
        private bool truFal;
        private int po_ea;
        private DateTime po_time = DateTime.Now;
        //private string po_person;
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
            con.Open();
            var cmd = new SqlCommand("si_selectSupplier", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = cmd;

            supData = new DataSet();
            adapter.Fill(supData);
            dgv_Supplier.ColumnCount = 4;
            string[] str = { "바코드", "상품 명", "회사 명", "상품 가격 : 단위(\\)" };
            for (int i = 0; i < dgv_Supplier.ColumnCount; i++)
            {
                dgv_Supplier.Columns[i].Width = 204;
                dgv_Supplier.Columns[i].Name = str[i];
            }

            DataTable suptable = supData.Tables[0];

            DataRowCollection rows = suptable.Rows;
            
            foreach (DataRow item in rows)
            {
                dgv_Supplier.Rows.Add(item["barCode"], item["SP_productName"], item["SP_companyName"], item["SP_productPrice"].ToString());
            }
            
            con.Close();
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
        /// 2018.01.10 ~ 2018.01.19  남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProAdd_Click(object sender, EventArgs e)
        {

            try
            {
                AddOrderlist();
                ProductListOutput();
            }
            catch (Exception)
            {
                MessageBox.Show("발주신청 할 수량을 기입 해주세요 ");
            }
            
        }
        /// <summary>
        /// 발주 리스트에 상품 추가
        /// 2018.01.11 ~ 2018.01.19 남수인
        /// </summary>
        private void AddOrderlist()
        {
            barcode = dgv_Supplier.CurrentRow.Cells[0].Value.ToString();
            po_productName = dgv_Supplier.CurrentRow.Cells[1].Value.ToString();
            po_productPrice = int.Parse(dgv_Supplier.CurrentRow.Cells[3].Value.ToString());
            po_ea = int.Parse(txtordernum.Text.ToString());
            int rowindex = dgv_Supplier.CurrentRow.Index;
            if (bit == 0)
            {
                prodOrderList.Add(new ProductOrder(barcode, po_productName, po_productPrice, po_ea));
                bit = 1;
            }
            else
            {
                for (int i = 0; i < prodOrderList.Count; i++)
                {
                    if (prodOrderList[i].Barcode != barcode)
                    {
                        truFal = true;

                    }
                    else if (prodOrderList[i].Barcode == barcode)
                    {
                        prodOrderList[i].Po_ea += po_ea;
                        truFal = false;
                        return;
                    }
                }
                if (truFal)
                {
                    prodOrderList.Add(new ProductOrder(barcode, po_productName, po_productPrice, po_ea));
                }
            }
            txtordernum.Text = null;
            txtordernum.Focus();
        }
        /// <summary>
        /// 프로덕트 리스트에 있는 value 표출 
        /// 2018.01.11 ~ 2018.01.19  남수인
        /// </summary>
        private void ProductListOutput()
        {
            dgv_Order.DataSource = null;
            dgv_Order.DataSource = prodOrderList;            
            //그리드뷰 이름 설정
            string[] str = {"바코드", "발주 물품", "발주 가격", "발주 갯수" };
            for (int j = 0; j < str.Length; j++)
            {
                dgv_Order.Columns[j].HeaderText = str[j];
            }
            for (int i = 0; i < dgv_Order.ColumnCount; i++)
            {
                dgv_Order.Columns[i].Width = 136;
            }
        }
        
        /// <summary>
        /// 주문갯수 숫자,백스패이스만 가능한 부분
        ///2018.01.11 ~ 2018.01.19  남수인
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
        /// 2018.01.11 ~ 2018.01.19  남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProDel_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < prodOrderList.Count; i++)
            {
                if (dgv_Order.CurrentCellAddress.Y == i)
                {
                    dgv_Order.CurrentRow.Cells[3].Value = 0;
                }
                if (dgv_Order.CurrentCellAddress.Y != i)
                {
                    templist.Add(new ProductOrder(prodOrderList[i].Barcode, prodOrderList[i].Po_productName, prodOrderList[i].Po_productPrice, prodOrderList[i].Po_ea));
                } 
            }

            prodOrderList.Clear();
            foreach (var item in templist)
            {
                prodOrderList.Add(item);
            }
            ProductListOutput();

            templist.Clear();
        }
        /// <summary>
        /// 발주 DB에 발주 목록 저장
        /// 2018.01.14 ~ 2018.01.19 남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProductOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("발주 하시겠습니까? 현 발주목록이 업데이트 됩니다.", "발주 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                con.Open();
                for (int i = 0; i < prodOrderList.Count; i++)
                {
                    var countcmd = new SqlCommand("si_SelectProductOrder", con);
                    countcmd.CommandType = CommandType.StoredProcedure;
                    countcmd.Parameters.AddWithValue("@barcode", prodOrderList[i].Barcode);
                    var count = countcmd.ExecuteScalar();
                    if (count.ToString() == "1")
                    {
                        var updatecmd = new SqlCommand("si_UpdateProductOrder", con);
                        updatecmd.CommandType = CommandType.StoredProcedure;
                        updatecmd.Parameters.AddWithValue("@barcode", prodOrderList[i].Barcode);
                        updatecmd.Parameters.AddWithValue("@ea", prodOrderList[i].Po_ea);
                        updatecmd.ExecuteNonQuery();
                    }
                    if (count.ToString() == "0")
                    {
                        var cmd = new SqlCommand("si_ProductOrderInsert", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@barcode", prodOrderList[i].Barcode);
                        cmd.Parameters.AddWithValue("@ea", prodOrderList[i].Po_ea);
                        cmd.ExecuteNonQuery();
                    }

                }
                MessageBox.Show("발주 되었습니다.");
            }
            else
            {
                MessageBox.Show("취소 되었습니다.");
            }
            
            
            dgv_Order.DataSource = null;
            //po_num = po_num + 1;
            con.Close();
        }

        /// <summary>
        /// 발주를 신청한 목록을 조회 한다.
        /// 2018.01.09 남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutput_Click(object sender, EventArgs e)
        {
            FormProductOrderList fpol = new FormProductOrderList();
            fpol.Show();
        }
    }
}
