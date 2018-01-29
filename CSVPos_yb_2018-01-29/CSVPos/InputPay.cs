using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSVPos
{
    public partial class InputPay : Form
    {
       private SqlConnection con = Connection.GetInstance();

        public InputPay()
        {
            InitializeComponent();
        }

        private void InputPay_Load(object sender, EventArgs e)
        {
           int horlyWage =  int.Parse(txthorlyWage.Text = "7530");           
        }
        /// <summary>
        /// 작성자 : 위영범
        /// 작성일 : 2018-01-20
        /// 작업내용 : 정해져있는 시급과, 근무시간을 계산한 급여출력
        /// </summary>
       
        private void btnPay_Click(object sender, EventArgs e)
        {           
            int minutes = 125; // 계산식은 125.5

            string worktime = txtworkTime.Text;
            string[] worktimeArray = worktime.Split(':');
            int time =int.Parse(worktimeArray[0]); 

            int horlyWage = int.Parse(txthorlyWage.Text); // 시당 급여
            int minutesPay = int.Parse(worktimeArray[1]); // 분당 급여
          
            //MessageBox.Show(time * horlyWage + minutesPay*minutes + "");
            //MessageBox.Show(time * horlyWage + "");
            //MessageBox.Show(minutesPay * minutes + "");

            txtmonthPay.Text = time * horlyWage + minutesPay * minutes +""; // 시급 + 분당위 급여
        }

        /// <summary>
        /// 작성자 : 위영범
        /// 작성일 : 2018-01-21
        /// 작업내용 : 입력 버튼 클릭 시 사원번호에 맞는 사원의 근무시간,시급,급여,급여지급일이 DB에 저장 
        /// 된 후 DataGridView에 띄워진다.
        /// </summary>
      
        private void btninputPay_Click(object sender, EventArgs e)
        {
            string empNum = txtempNum.Text;
            string workTime = txtworkTime.Text;
            string horlyWage = txthorlyWage.Text;
            string monthPay = txtmonthPay.Text;
            string provisionDay = txtprovisionDay.Text;

          
                using (var cmd = new SqlCommand("yb_updateInputPay", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empNum", empNum);
                    cmd.Parameters.AddWithValue("@workTime", (workTime));
                    cmd.Parameters.AddWithValue("@horlyWage", horlyWage);
                    cmd.Parameters.AddWithValue("@monthPay", monthPay);
                    cmd.Parameters.AddWithValue("@provisionDay", (provisionDay));

                    var i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {
                        if (MessageBox.Show(txtempName.Text + " 님의 급여를 입력하시겠습니까?", "급여입력", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            MessageBox.Show(txtempName.Text + " 님의 급여가 저장되었습니다.");

                            FormPayment formPayment = (FormPayment)Owner;
                        con.Close();
                        formPayment.WorkPayTable();
                        formPayment.StaffTotalPay();
                            this.Close();
                        }
                   
                    }                    
                }
            
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("취소 하시겠습니까?","입력 취소",MessageBoxButtons.YesNo,MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}