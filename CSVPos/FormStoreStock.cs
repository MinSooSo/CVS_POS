using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
using System.Drawing;

namespace CSVPos
{
    public partial class FormStoreStock : Form
    {
        SqlConnection con = Connection.GetInstance();
        DataSet StockData;
        DataTable table;
        private string barCode;
        private DateTime excelcount = DateTime.Now;
        private int PS_actualityEa;
        private int productEvent;
        private int barcodeCount = 0;
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        public FormStoreStock()
        {
            InitializeComponent();
        }
        
        
        private void FormStoreStock_Load(object sender, EventArgs e)
        {
            timeStart();
            PStockOutput();
            
        }
        /// <summary>
        /// 재고 테이블 정보 가져오기
        /// 2018.01.26
        /// </summary>
        private void PStockOutput()
        {
            dgvStockList.Rows.Clear();
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("si_SelectProductStock", con);
            StockData = new DataSet();
            adapter.Fill(StockData);

            DgvView();
           
            table = StockData.Tables[0];
            DataRowCollection rows = table.Rows;
            foreach (DataRow item in rows)
            {
                dgvStockList.Rows.Add(item["barCode"].ToString(), item["PS_productName"].ToString(), item["PS_orderPrice"].ToString(), item["PS_sellPrice"].ToString(), item["PS_persent"].ToString(), item["PS_actuality"].ToString(), item["PS_warehousingDay"].ToString(), item["PS_expiration"].ToString(), DisposalReturn(item["PS_abandon"].ToString()), item["eventNum"].ToString(), item["CategoryName"].ToString());
                
                source.AddRange(
                        new string[] { item["PS_productName"].ToString() }
                        );
            }
            txtSearch.AutoCompleteCustomSource = source;
            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            con.Close();
        }
        public void DgvView()
        {
            string[] str = { "바코드", "상품 명", "공급 가격", "판매 가격", "현 재고", "실 재고", "입고 날짜", "유통기한", "반납/폐기", "이벤트", "카테고리" };
            dgvStockList.ColumnCount = 11;
            for (int i = 0; i < dgvStockList.ColumnCount; i++)
            {
                dgvStockList.Columns[i].HeaderText = str[i];
                dgvStockList.Columns[i].Width = 100;
                if (i == 5 || i ==10)
                {
                    dgvStockList.Columns[i].ReadOnly = false;
                }
                else
                {
                    dgvStockList.Columns[i].ReadOnly = true;
                }
            }
        }
        /// <summary>
        /// 폐기인지 반납인지 
        /// 2018.01.26 남수인
        /// </summary>
        /// <param name="tf"></param>
        /// <returns></returns>
        private string DisposalReturn(string tf)
        {
            if (tf == "False")
            {
                return "반납 상품";
            }
            else
            {
                return "폐기 상품";
            }
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

        private void btnEmployee_Click(object sender, EventArgs e) // 상품 발주 버튼을 눌렀을 때 
        {
            FormProductOrder fpo = new FormProductOrder();
            fpo.Show();
        }

        // 이거 3개 합칠까... 말까아....

        private void btnPayment_Click(object sender, EventArgs e) // 상품 폐기/반납 등록을 눌렀을 때
        {
            FormStockDisposal fsd = new FormStockDisposal();
            fsd.Show();
            this.Close();
        }
        //발주 받은 상품 재고에 수주 받기
        private void btnStockOrder_Click(object sender, EventArgs e)
        {
            FormStockOrder fso = new FormStockOrder();
            fso.Show();
            this.Close();
        }
        /// <summary>
        /// 재고 수정 하기 실재고 갯수, 이벤트 여부
        /// 2018.01.27 남수인
        /// eventNum 기본 Null 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveMain_Click(object sender, EventArgs e) // 상품 재고 수정, 직접 하기 
        {
            if (MessageBox.Show("재고를 수정 하시겠습니까? 재고가 업데이트 됩니다..", "재고수정 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                con.Open();
                for (int i = 0; i < dgvStockList.RowCount - 1; i++)
                {
                    barCode = dgvStockList.Rows[i].Cells[0].Value.ToString();
                    PS_actualityEa = int.Parse(dgvStockList.Rows[i].Cells[5].Value.ToString());
                    var cmd = new SqlCommand("si_UpdateProductStock", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@barCode", barCode);
                    cmd.Parameters.AddWithValue("@PS_actuality", PS_actualityEa);
                    if (!string.IsNullOrEmpty(dgvStockList.Rows[i].Cells[9].Value.ToString()))
                    {
                        productEvent = int.Parse(dgvStockList.Rows[i].Cells[9].Value.ToString());
                        cmd.Parameters.AddWithValue("eventNum", productEvent);
                    }
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                PStockOutput();
                MessageBox.Show("재고 수정을 완료하였습니다.");
            }
            else
            {
                MessageBox.Show("재고 수정을 취소하였습니다.");
                
            }
        }

        /// <summary>
        /// 재고 수요에 대한 엑셀 파일로 저장 하기 
        /// 2018.01.30 남수인
        /// </summary>
        /// <param name="table"></param>
        private void ExportDataSetToExcel(DataTable table)
        {
            string path = @"C:\Users\gd3-11\Desktop\CSVPos\CSVPos\ProductInfo" + excelcount.ToShortDateString();
            Excel.Application excelApp = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;

            // Excel 첫번째 워크시트 가져오기                
            excelApp = new Excel.Application();
            wb = excelApp.Workbooks.Add();
            ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;

            // 데이타 넣기
            DataRowCollection rows = table.Rows;
           
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].ItemArray.Length; j++)
                {
                    ws.Cells[1, j + 1] = dgvStockList.Columns[j].HeaderText;
                    ws.Cells[i + 2, j + 1] = rows[i].ItemArray[j].ToString();
                }
            }

            // 엑셀파일 저장
            wb.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal);
            wb.Close(true);
            excelApp.Quit();
        }
        private void btnExcelSave_Click(object sender, EventArgs e)
        {
            ExportDataSetToExcel(table);
            MessageBox.Show("저장 되었습니다.");
        }
        /// <summary>
        /// 검색 버튼 클릭시  검색
        /// 2018.01.30 남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProductSearch();
          
        }
        /// <summary>
        /// 검색창에서 엔터 눌렀을때 검색 
        /// 2018.01.30 남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProductSearch();
            }
            else
            {
                barcodeCount = barcodeCount + 1;
                for (int i = 0; i < barcodeCount; i++)
                {
                    txtSearch.Text = sender.ToString().Split(':')[1].Trim();
                }
            }
        }
        //검색 함수
        private void ProductSearch()
        {
            dgvStockList.Rows.Clear();
            
            con.Open();
            var cmd = new SqlCommand("si_SearchStoreStock", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", txtSearch.Text.Trim());
            cmd.Parameters.AddWithValue("@barcode", txtSearch.Text.Trim());
            var src = cmd.ExecuteReader();

            if (src.HasRows)
            {
               
                while (src.Read())
                {
                    dgvStockList.Rows.Add(src["barCode"].ToString(), src["PS_productName"].ToString(), src["PS_orderPrice"].ToString(), src["PS_sellPrice"].ToString(), src["PS_persent"].ToString(), src["PS_actuality"].ToString(), src["PS_warehousingDay"].ToString(), src["PS_expiration"].ToString(), DisposalReturn(src["PS_abandon"].ToString()), src["eventNum"].ToString(), src["CategoryName"].ToString());
                }
                
            }
            // AutoCompleteCustomSource에 추가 부분
            
            txtSearch.Text = null;
            txtSearch.Focus();
            con.Close();
        }
        /// <summary>
        /// 재고 모든 테이블 보기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStockView_Click(object sender, EventArgs e)
        {
            PStockOutput();
        }

       
    }
}
