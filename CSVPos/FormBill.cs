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
    public partial class FormBill : Form
    {
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
            timeStart();
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
    }
}
