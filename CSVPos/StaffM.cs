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
    public partial class StaffM : Form
    {
        public StaffM()
        {
            InitializeComponent();
        }

        private void StaffM_Load(object sender, EventArgs e)
        {
            timeStart();

            labelLoginTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void btnReturn_Click(object sender, EventArgs e) // 매장관리로 돌아가기
        {
            this.Close();
        }

        private void btnhireStaff_Click(object sender, EventArgs e) // 직원 고용 눌렀을 떄
        {
            FormHire fh = new FormHire();
            fh.Show();
        }

        private void btnFiredate_Click(object sender, EventArgs e) // 직원 해고 눌렀을 때
        {
            // 해고 날자에 UPDATE를 날려주세요. 
        }
    }
}
