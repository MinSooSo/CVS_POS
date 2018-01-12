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

        // 영수증 발행을 눌렀을 때 실행 이벤트
        // PrintDialog 클래스 참고하여 폼 좌측의 텍스트박스에 표시된 영수증 내용을 프린트로 출력.
        private void btnPrint_Click(object sender, EventArgs e) // 해당 영수증 발행을 눌렀을 때
        {

        }

        // 영수증 조회 버튼 
        // 물품의 바코드를 찍고 조회를 눌렀을 때 해당 기간에 포함되는 물건의 판매 내역을 하단의 그리드 뷰에 출력해야 한다.
        private void btnSearch_Click(object sender, EventArgs e) // 영수증 조회를 눌렀을 때 
        {
            //txtBarCode
            //dateTimePicker1
            //dateTimePicker2
        }

        private void btnReturn_Click(object sender, EventArgs e) // 판매화면으로 돌아가기
        {
            this.Close();
        }

        private void FormBill_Load(object sender, EventArgs e)
        {
            TimeStart();
        }

        /// <summary>
        /// 민수형이 만듬 - 폼 상단에 현재 시각을 출력해주는 메서드
        /// </summary>
        public void TimeStart()
        {
            label5.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer); // 타이머가 1초(1000ms)씩 증가할 때마다 발생하는 이벤트핸들러
            timer.Start();
        }

        // 이벤트핸들러
        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            Invoke((MethodInvoker)delegate
            {
                label5.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            });
        }
    }
}
