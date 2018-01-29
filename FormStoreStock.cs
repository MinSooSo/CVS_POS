using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSVPos
{
    public partial class FormStoreStock : Form
    {
        SqlConnection con = Connection.GetInstance();
        DataSet StockData;
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
        /// </summary>
        internal void PStockOutput()
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("si_SelectProductStock", con);
            StockData = new DataSet();
            adapter.Fill(StockData);

            string[] str = { "바코드", "상품 명", "공급 가격", "판매 가격", "현 재고", "실 재고", "입고 날짜", "유통기한", "반납/폐기", "도난/분실", "이벤트", "카테고리" };
            dgvStockList.ColumnCount = 12;
            for (int i = 0; i < dgvStockList.ColumnCount; i++)
            {
                dgvStockList.Columns[i].HeaderText = str[i];
                dgvStockList.Columns[i].Width = 100;
                if (i == 5 || i == 9 || i == 10)
                {
                    dgvStockList.Columns[i].ReadOnly = false;
                }
                else
                {
                    dgvStockList.Columns[i].ReadOnly = true;
                }
            }
           
            DataTable table = StockData.Tables[0];
            DataRowCollection rows = table.Rows;
            foreach (DataRow item in rows)
            {

                dgvStockList.Rows.Add(item["barCode"].ToString(), item["PS_productName"].ToString(), item["PS_orderPrice"].ToString(), item["PS_sellPrice"].ToString(), item["PS_persent"].ToString(), item["PS_actuality"].ToString(), item["PS_warehousingDay"].ToString(), item["PS_expiration"].ToString(), DisposalReturn(item["PS_abandon"].ToString()), item["PS_loss"].ToString(), item["eventNum"].ToString(), item["CategoryName"].ToString());
            }
            con.Close();
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
                return "반납";
            }
            else
            {
                return "폐기";
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
        }

        private void btnMoveMain_Click(object sender, EventArgs e) // 상품 재고 수정, 직접 하기 
        {

        }
        
    }
}
