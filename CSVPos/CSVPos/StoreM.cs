using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVPos
{
    public partial class StoreM : Form
    {
        private string empName;

        public string EmpName { get => empName; set => empName = value; }

        public StoreM()
        {
            InitializeComponent();
        }

        private void StoreM_Load(object sender, EventArgs e)
        {
            labelStaff.Text = empName + "님 오늘도 수고하세요!!";
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 CVS_POS를 종료하시겠습니까?", "POS 종료 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("POS 종료가 취소 되었습니다", "POS 종료 취소");
                return;
            }
        }

        private void btnMoveMain_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEmployee_Click(object sender, EventArgs e) // 직원관리 버튼 
        {
            StaffM staffManager = new StaffM();
            staffManager.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e) // 급여 관리 
        {
            FormPayment fp = new FormPayment();
            fp.Show();
        }

        private void btnStoreManage_Click(object sender, EventArgs e) // 매장 관리 
        {
            FormStoreInfo fsi = new FormStoreInfo();
            fsi.ShowDialog();
        }

        private void btnTotalSales_Click(object sender, EventArgs e) // 매출 정보 클릭했을 떄
        {
            FormSalesInfo formSales = new FormSalesInfo();
            formSales.Show();
        }
    }
}
