using System;
using System.Windows.Forms;

namespace CSVPos
{
    public partial class FormStoreStock : Form
    {
        private string EmpName;

        public string EmpName1 { get => EmpName; set => EmpName = value; }
        
        public FormStoreStock()
        {
            InitializeComponent();
        }

        private void FormStoreStock_Load(object sender, EventArgs e)
        {
            timeStart();
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

        private void btnPayment_Click(object sender, EventArgs e) // 상품 폐기 등록을 눌렀을 때
        {
            FormStockDisposal fsd = new FormStockDisposal();
            fsd.Show();
        }

        private void btnStoreManage_Click(object sender, EventArgs e) // 상품 반납 등록을 눌렀을 때
        {

        }

        private void btnMoveMain_Click(object sender, EventArgs e) // 상품 재고 수정, 직접 하기 
        {

        }

        private void btnTotalSales_Click(object sender, EventArgs e) // 매장 내부의 모든 재고 확인하기 
        {

        }
    }
}
