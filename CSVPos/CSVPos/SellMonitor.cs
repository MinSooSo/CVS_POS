﻿using System;
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
    public partial class SellMonitor : Form
    {
        private string EmpName;
        private string EmpNum;

        public string EmpName1 { get => EmpName; set => EmpName = value; }
        public string EmpNum1 { get => EmpNum; set => EmpNum = value; }

        staffNum sn = new staffNum();

        public SellMonitor()
        {
            InitializeComponent();
        }

        private void SellMonitor_Load(object sender, EventArgs e)
        {
            timeStart();
            string formname = this.Text;
            // 폼이 켜질때 자연스럽게 가능한지?
            label4.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            label11.Text = EmpName;
            label12.Text = EmpNum;
            
            sn.MakeLogrecod(EmpNum, formname);
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

        private void btnGohome_Click(object sender, EventArgs e) // 직원 교대 테이블 
        {
            // 꺼졌다가 켜지는 부분 자연스럽게 가능한가염 아몰랑          
            //staffNum sn = new staffNum();
            //sn.Formname = "sell";
            //sn.Show();
            //this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e) // 판매 완료를 눌렀을 때 
        {
            // datagidview랑 각종 textbox 지우세요. datasource 등등
            // DB에도 Insert 하세요 
            int change  = int.Parse(txtDiscountAfterMoney.Text) - int.Parse(txtNeedMoney.Text);
            txtchange.Text = change.ToString();

            //CustomerAgeSex cas = new CustomerAgeSex();
            //cas.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e) // 종료 picture을 눌렀을 때 
        {
            if(MessageBox.Show("판매 관리창에서 바로 종료할 수 없습니다. \t\n 확인 버튼을 누르시면 메인화면으로 이동합니다.","판매 종료 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)== DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnTakbae_Click(object sender, EventArgs e) // 택배 접수 버튼을 눌렀을 때
        {
            frmPost fp = new frmPost();
            fp.Show();
        }

        private void btnDiscount_Click(object sender, EventArgs e) // 할인 , 기프티콘 사용 여부를 눌렀을 때 
        {
            FormDiscount fd = new FormDiscount();
            fd.ShowDialog();
        }

        private void btnCredit_Click(object sender, EventArgs e) // 카드 결제를 눌렀을 때
        {
            PayCredit pc = new PayCredit();
            pc.ShowDialog();
        }

        private void btnBill_Click(object sender, EventArgs e)// 영수증 발급을 눌렀을 때
        {
            FormBill fb = new FormBill();
            fb.Show();
        }

        private void SellMonitor_FormClosed(object sender, FormClosedEventArgs e) // 폼이 닫혓을때 로그 기록에 종료 시간을 찍어야 합니다. 
        {
            // 프로시저를 별도로 만들어서 그것에 대하여 찍어야합니다. 

        }
    }
}
