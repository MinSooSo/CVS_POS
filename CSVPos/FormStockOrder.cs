using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSVPos
{
    public partial class FormStockOrder : Form
    {
        SqlConnection con = Connection.GetInstance();
        List<ProductOrder> list = new List<ProductOrder>();
        List<string> CategoryList = new List<string>();
        List<string> ExpList = new List<string>();
        DataSet OrderData;
        
        private string barcode;
        private string dgvObarcode;
        private string productName;
        private int productPrice;
        private int dgvOrderEA;
        //private int Stockea;
        private int bit = 0;
        private string ProductCategory;
        private bool bb;
        private int dgvexpDate;
        private int abandon;
        string[] cateArr = { };

        public FormStockOrder()
        {
            InitializeComponent();
        }
        //시간 표시
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
        /// <summary>
        /// 폼 로드 될때 발주 정보 그리드뷰 출력
        /// 2018.01.22 남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormStockOrder_Load(object sender, EventArgs e)
        {
            timeStart();
            con.Open();
            // 발주한 정보 그리드뷰 표현
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("si_JoinSupAndProdO", con);
            OrderData = new DataSet();
            adapter.Fill(OrderData);

            string[] str = {"바코드", "상품 명", "상품 가격 : 단위(\\)", "발주 수량" };
            dgvOrderState.ColumnCount = 4;
            for (int i = 0; i < dgvOrderState.ColumnCount; i++)
            {
                dgvOrderState.Columns[i].HeaderText = str[i];
                dgvOrderState.Columns[i].Width = 201;
            }
            
            DataTable table = OrderData.Tables[0];
            DataRowCollection rows = table.Rows;
            foreach (DataRow item in rows)
            {
                dgvOrderState.Rows.Add(item["바코드"], item["상품 명"], item["상품 가격"], item["발주 수량"]);
            }
            con.Close();
            CategorylistAdd();
        }
        /// <summary>
        /// 카테고리 정보를 리스트에 추가
        /// 2018.01.24 남수인
        /// </summary>
        private void CategorylistAdd()
        {
            con.Open();
            var cmd = new SqlCommand("si_SelectCategoryNN", con);
            var sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    CategoryList.Add(sdr["CategoryNum"].ToString() + ":" + sdr["CategoryName"].ToString() + ":" + sdr["Expirationdate"].ToString());
                }
            }
            foreach (var item in CategoryList)
            {
                cboCate.Items.Add(item.Split(':')[0] + ":" + item.Split(':')[1]);
            }
            con.Close();
        }
        /// <summary>
        /// 카테고리테이블에 있는 유통기한 정보를 받아 옵니다.
        /// </summary>
        private void CategoryVerify()
        {
            if (cboCate.SelectedItem != null)
            {
                ProductCategory = cboCate.SelectedItem.ToString();
                for (int i = 0; i < CategoryList.Count; i++)
                {
                    if (ProductCategory.Split(':')[0].ToString() == CategoryList[i].Split(':')[0])
                    {
                        dgvexpDate = int.Parse(CategoryList[i].Split(':')[2]);
                    }
                }
            }
            else
            {
                MessageBox.Show("카테고리를 확인 해주세요");
            }
        }
        /// <summary>
        /// 발주 테이블에서 재고테이블에 넣기 위한 정보를 그리드뷰에 표시
        /// 2018.01.22 남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStockAdd_Click(object sender, EventArgs e)
        {
            if (dgvOrderState.RowCount == 1)
            {
                MessageBox.Show("발주 목록이 존재하지 않습니다.");
            }
            else
            {
                CategoryVerify();
                StockGridHeaderView();
                AddStock();
                EaNonExPress();
            }  
        }
        /// <summary> 
        ///  그리드뷰 헤더 표시 
        ///  2018.01.23 남수인
        /// </summary>
        private void StockGridHeaderView()
        {

            string[] str = { "카테고리", "바코드", "상품 명", "상품 가격(\\)", "재고 추가 수량" ,"유통기한(일) " };
            dgvStockState.ColumnCount = 6;
            for (int j = 0; j < str.Length; j++)
            {
                dgvStockState.Columns[j].HeaderText = str[j];
            }
            for (int i = 0; i < dgvStockState.ColumnCount; i++)
            {
                dgvStockState.Columns[i].Width = 134;
            }
        }
        /// <summary>
        /// Stock 그리드 뷰에 추가 
        /// 2018.01.23 남수인
        /// </summary>
        private void AddStock()
        {
            dgvObarcode = dgvOrderState.CurrentRow.Cells[0].Value.ToString();
            
            productName = dgvOrderState.CurrentRow.Cells[1].Value.ToString();
            productPrice = (int)dgvOrderState.CurrentRow.Cells[2].Value;
            dgvOrderEA = int.Parse(dgvOrderState.CurrentRow.Cells[3].Value.ToString());
           

            if (txtStockEa.Text == "" && cboCate.SelectedItem != null)
            {
                MessageBox.Show("수량을 확인해주세요");
            }
            else if(txtStockEa.Text != "" && cboCate.SelectedItem != null)
            {
                ProductCategory = cboCate.SelectedItem.ToString();
                int Stockea = int.Parse(txtStockEa.Text);
                if (bit == 0)
                {
                    if (Stockea > dgvOrderEA)
                    {
                        MessageBox.Show("수주 가능 갯수를 초과 했습니다.");
                        txtStockEa.Text = null;
                        txtStockEa.Focus();
                    }
                    else
                    {
                        dgvStockState.Rows.Add(ProductCategory, dgvObarcode, productName, productPrice, Stockea, dgvexpDate);
                        bit = 1;
                    }
                }
                else if (bit == 1)
                {
                    if (Stockea > dgvOrderEA)
                    {
                        MessageBox.Show("수주 가능 갯수를 초과 했습니다.");
                        txtStockEa.Text = null;
                        txtStockEa.Focus();
                    }
                    else
                    {
                        for (int i = 0; i < dgvStockState.Rows.Count - 1; i++)
                        {
                            if (dgvStockState.Rows[i].Cells[1].Value.ToString() != dgvObarcode)
                            {

                                bb = true;
                            }
                            else if (dgvStockState.Rows[i].Cells[1].Value.ToString() == dgvObarcode)
                            {
                                dgvStockState.Rows[i].Cells[4].Value = (int)dgvStockState.Rows[i].Cells[4].Value + Stockea;

                                bb = false;
                                return;
                            }
                        }
                        if (bb)
                        {
                            dgvStockState.Rows.Add(ProductCategory, dgvObarcode, productName, productPrice, Stockea, dgvexpDate);
                            bb = false;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 발주 받은 갯수보다 초과 되면 발주받은 값으로 초기화 
        /// 2018.01.23 남수인
        /// </summary>
        private void EaNonExPress()
        {
            int rowindex = dgvOrderState.CurrentRow.Index;
            for (int i = 0; i < dgvStockState.Rows.Count - 1; i++)
            {
                // MessageBox.Show(rowindex.ToString());
                if (dgvStockState.Rows[i].Cells[1].Value.ToString() == dgvObarcode)
                {
                    if ((int)dgvStockState.Rows[i].Cells[4].Value > (int)dgvOrderState.Rows[rowindex].Cells[3].Value)
                    {
                        dgvStockState.Rows[i].Cells[4].Value = (int)dgvOrderState.Rows[rowindex].Cells[3].Value;
                        MessageBox.Show("발주받은 갯수 보다 큽니다.");
                    }
                }
            }
        }
        
        /// <summary>
        /// 재고 그리드뷰에 추가한 상품을 제거 합니다.
        /// 2018.01.24 남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            if (dgvStockState.Rows.Count > 1)
            {
                int i = dgvStockState.CurrentRow.Index;
                dgvStockState.Rows.RemoveAt(i);
                if (dgvStockState.Rows.Count == 1)
                {
                    bit = 0;
                }
            }
        }
        /// <summary>
        /// 재고 테이블에 업데이트를 진행 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddComplete_Click(object sender, EventArgs e)
        {
            if (dgvStockState.RowCount == 0)
            {
                MessageBox.Show("수주 받은 물품 이 없습니다.");
            }
            else
            {
                if (MessageBox.Show("재고에 등록 하시겠습니까?", "재고 등록 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    con.Open();
                    for (int i = 0; i < dgvStockState.RowCount - 1; i++)
                    {
                        barcode = dgvStockState.Rows[i].Cells[1].Value.ToString();
                        var countcmd = new SqlCommand("si_ProductStockCount", con);
                        countcmd.CommandType = CommandType.StoredProcedure;
                        countcmd.Parameters.AddWithValue("@barcode", barcode);
                        var count = countcmd.ExecuteScalar();

                        if ((int)count == 0)
                        { // 상품이 테이블에 없음으로 재고에 추가

                            InsertStockTable();
                            ClearProductOrder();

                        }
                        else if ((int)count == 1)
                        {// 상품이 테이블에 있음으로 재고에서 수량 업데이트  
                            UpdateStocktable(i);
                            ClearProductOrder();

                        }
                    }
                    con.Close();
                }
            }
        }
        /// <summary>
        /// 재고에 없음으로 재고 추가
        /// </summary>
        /// <param name="i"></param>
        private void InsertStockTable()
        {
            for (int i = 0; i < dgvStockState.RowCount - 1; i++)
            {
                int category = int.Parse(dgvStockState.Rows[i].Cells[0].Value.ToString().Split(':')[0]);
                int expiration = int.Parse(dgvStockState.Rows[i].Cells[5].Value.ToString());
                int ea = int.Parse(dgvStockState.Rows[i].Cells[4].Value.ToString());
                int price = int.Parse(dgvStockState.Rows[i].Cells[3].Value.ToString());
                barcode = dgvStockState.Rows[i].Cells[1].Value.ToString();
                DateTime now = DateTime.Now;
                TimeSpan exp = new TimeSpan(expiration, 0, 0, 0); ;
                DateTime expirationDate = now.Add(exp);
                abandon = 0;
                if (category == 30 || category == 50 || category == 60 || category == 70)
                {
                    abandon = 1;
                }
                var insertcmd = new SqlCommand("si_InsertProductStock", con);
                insertcmd.CommandType = CommandType.StoredProcedure;
                insertcmd.Parameters.AddWithValue("@barCode", barcode);
                insertcmd.Parameters.AddWithValue("@PS_productName", dgvStockState.Rows[i].Cells[2].Value.ToString());
                insertcmd.Parameters.AddWithValue("@PS_orderPrice", price);
                insertcmd.Parameters.AddWithValue("@PS_sellPrice", (price * 3.5));
                insertcmd.Parameters.AddWithValue("@PS_persent", ea);
                insertcmd.Parameters.AddWithValue("@PS_actuality", ea);
                insertcmd.Parameters.AddWithValue("@PS_warehousingDay", now);
                insertcmd.Parameters.AddWithValue("@PS_expiration", expirationDate);
                insertcmd.Parameters.AddWithValue("@PS_abandon", abandon);
                insertcmd.Parameters.AddWithValue("@PS_CategoryNum", category);
                insertcmd.ExecuteNonQuery();
            }            
        }
        /// <summary>
        /// 재고에 상품이 있음으로 상품 수량 업데이트
        /// </summary>
        /// <param name="i"></param>
        private void UpdateStocktable(int i)
        {
            int ea = int.Parse(dgvStockState.Rows[i].Cells[4].Value.ToString());
            int expiration = int.Parse(dgvStockState.Rows[i].Cells[5].Value.ToString());
            DateTime now = DateTime.Now;
            TimeSpan exp = new TimeSpan(expiration, 0, 0, 0);
            DateTime expirationDate = now.Add(exp);
            var updatecmd = new SqlCommand("si_UpdateStockEa", con);
            updatecmd.CommandType = CommandType.StoredProcedure;
            updatecmd.Parameters.AddWithValue("@barCode", barcode);
            updatecmd.Parameters.AddWithValue("@ea", ea);
            updatecmd.Parameters.AddWithValue("@PS_warehousingDay", now);
            updatecmd.Parameters.AddWithValue("@PS_expiration", expirationDate);
            updatecmd.ExecuteNonQuery();
        }
        /// <summary>
        /// //수주 완료 했으니가 발주 테이블 초기화
        /// </summary>
        private void ClearProductOrder()
        {
            var pordercmd = new SqlCommand("si_productOrderReset", con);
            pordercmd.CommandType = CommandType.StoredProcedure;
            pordercmd.ExecuteNonQuery();
            dgvStockState.Rows.Clear();
            MessageBox.Show("재고에 등록 완료 했습니다.");
        }

        private void FormStockOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormStoreStock fss = new FormStoreStock();
            fss.Show();
        }
        /// <summary>
        /// 갯수 숫자, 백스페이스만 가능하게
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStockEa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
    }
}
