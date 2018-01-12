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
    public partial class FormPayment : Form
    {
        public FormPayment()
        {
            InitializeComponent();
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("급여 등록 & 수정을 취소하시겠습니까?", "급여 등록 취소", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("급여 등록 & 수정이 계속 가능합니다.", "급여 등록 재개");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e) // 전체 직원 조회
        {
            dataGridView1.Show();
        }
    }
}
