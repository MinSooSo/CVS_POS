using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVPos
{
    public partial class FormPayment : Form
    {
        string zero = "00:00:00"; // 근무시간이 없는 사원의 근무시간 값
        DataTable dt;
        private SqlConnection con = Connection.GetInstance();
     
        
        public FormPayment()
        {
            InitializeComponent();
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            label2.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
            StaffTotalPay();
           
            dgvStaffWork.Hide();
        
        }

        internal void StaffTotalPay()
        {
            using (var cmd = new SqlCommand("yb_totalPay", con))
            {
                con.Open();
               
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        lblTotalPay.Text = @"\ "+  sdr.GetInt32(0).ToString() + "원";

                    }
                }
                con.Close();
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


        private void btnStaffWorkTable_Click(object sender, EventArgs e)
        {
            staffWorkTimeTalbe staffWorkTimeTalbe = new staffWorkTimeTalbe();
            staffWorkTimeTalbe.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvStaffWork.Show();
         
            WorkPayTable(); // DataGridView에 직원의 근무현황을 띄워주는 메서드
           
        }

        internal void WorkPayTable() 
        {
            dgvStaffWork.Update();
            dgvStaffWork.Refresh();

            dgvStaffWork.ScrollBars = ScrollBars.Both;


            con.Open();

            string empNum = lblempNum.Text;

            SqlDataAdapter adapter = new SqlDataAdapter("yb_workTimeTable", con);
            adapter.SelectCommand = new SqlCommand("yb_workTimeTable", con);
            dt = new DataTable();
            adapter.Fill(dt);

            dgvStaffWork.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvStaffWork.Rows.Add();

                for (int i = 0; i < dgvStaffWork.RowCount; i++) // 넘버
                {
                    dgvStaffWork.Rows[n].Cells[0].Value = i;
                }

                dgvStaffWork.Rows[n].Cells[1].Value = item[0].ToString(); // 사번
                dgvStaffWork.Rows[n].Cells[2].Value = item[1].ToString(); // 이름

                if (item[2].ToString() == "True") // 고용형태
                {
                    dgvStaffWork.Rows[n].Cells[3].Value = "점장";
                    // dgvStaffWork.Rows[n].Cells[6].Value = item[5].ToString(); // 점장은 시급이 아님.
                    dgvStaffWork.Rows[n].Cells[7].Value = item[6].ToString(); // 급여
                }

                else
                {
                    dgvStaffWork.Rows[n].Cells[3].Value = "아르바이트";
                    dgvStaffWork.Rows[n].Cells[6].Value = item[5].ToString(); // 시급
                    dgvStaffWork.Rows[n].Cells[7].Value = item[6].ToString(); // 급여
                }

                dgvStaffWork.Rows[n].Cells[4].Value = item[3].ToString(); // 연락처

                dgvStaffWork.Rows[n].Cells[5].Value = item[4].ToString();

                // 시간은 자르고 날짜만 출력
                string provisionDay = item[7].ToString();
                string[] provisionDayArray = provisionDay.Split(' ');
                // MessageBox.Show(provisionDayArray[0]);
                dgvStaffWork.Rows[n].Cells[8].Value = provisionDayArray[0]; // 급여지급일     
            }
            con.Close();

        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            InputPay inputPay = new InputPay();
            inputPay.Show();
        }

        /// <summary>
        /// 작성자 : 위영범
        /// 작성일자 : 2018-01-20
        /// 작업내용 : 근무현황표 GridView에 Cell Click이벤트로, 사원의 사번과 이름 근무시간을 출력해준다.
        /// </summary>

        private void dgvStaffWork_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                lblempNum.Text = dgvStaffWork.CurrentRow.Cells[1].Value.ToString();
                string empNum = lblempNum.Text;

                using (var cmd = new SqlCommand("yb_workTime", con))
                {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empNum", empNum);
                var sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        lblempWorkTime.Text = sdr["worktime"].ToString();

                        if (sdr["worktime"].ToString() == "::")
                        {
                            dgvStaffWork.CurrentRow.Cells[5].Value = zero;
                        }
                        else
                        {
                            dgvStaffWork.CurrentRow.Cells[5].Value = sdr["worktime"].ToString();
                        }

                        lblempName.Text = sdr["SM_name"].ToString();
                        if (this.lblempWorkTime.Text == "::")
                        {
                            this.lblempWorkTime.Text = zero;
                        }
                    }
                }
                con.Close();
            }
                

            }
            catch (Exception)
            {
                // 비어있는 GridView. 선택되도 예외처리가 뜨지 않는다.
            }   
        }

        /// <summary>
        /// 작성자 : 위영범
        /// 작성일 : 2018-01-20
        /// 작업내용 : GridView 셀 클릭 시 사번,이름,근무시간이 띄워진다.

        private void btnEmployee_Click_1(object sender, EventArgs e)
        {
            try
            {
                InputPay inputPay = new InputPay();
                inputPay.Owner = this;
                inputPay.txtempNum.Text = this.lblempNum.Text;
                inputPay.txtempName.Text = this.lblempName.Text;
                inputPay.txtprovisionDay.Text = System.DateTime.Now.ToString("yyyy-MM-dd"); // 급여지급일을 오늘날짜로

                if (this.lblempWorkTime.Text == "::")
                {
                    this.lblempWorkTime.Text = zero;
                    inputPay.txtworkTime.Text = zero;
                }
                else
                {
                    inputPay.txtworkTime.Text = this.lblempWorkTime.Text;
                }

                // dgvStaffWork.CurrentRow.Cells[7].Value.ToString() , GridView의 급여 컬럼이 비어있다면?
                // 이미 급여가 입력된 사원은 다시 입력받지 않게..
                if (dgvStaffWork.CurrentRow.Cells[7].Value.ToString() == "")
                {
                    inputPay.Show();              
                    return;
                }else if(inputPay.txtempName.Text == "이름")
                {
                    MessageBox.Show("사원이 선택되지 않았습니다.", "입력실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show(inputPay.txtempName.Text + " 님은 이미 급여가 입력되어 있습니다. 수정을 원하시면 급여수정 버튼을 클릭하세요.", "입력실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (NullReferenceException)
            {              
                    MessageBox.Show("사원이 선택되지 않았습니다.","입력실패",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;               
            }
            
        }

        /// <summary>
        /// 작성자 : 위영범
        /// 작성날짜 : 2018-01-22
        /// 작업내용 : 급여수정 버튼 클릭 시 GridView 클릭 시 나타나는 사번과, 이름, 기존급여,급여지급일이 
        /// 텍스트창에 입력되어, 로드 된다.
        /// </summary>
   
        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                // datetime 저장을 위해 수정버튼 클릭시 날짜만 출력 (요일(한글) 제외). 
                string payTime = this.dgvStaffWork.CurrentRow.Cells[8].Value.ToString();
                string[] empProvisionDayArray = payTime.Split(' ');
                string Paytimes = empProvisionDayArray[0];
                // MessageBox.Show(Paytimes);       

                UpdatePay updatePay = new UpdatePay();
                updatePay.Owner = this;
                updatePay.txtempNum.Text = this.lblempNum.Text;
                updatePay.txtempName.Text = this.lblempName.Text;
                updatePay.txtDefaultPay.Text = this.dgvStaffWork.CurrentRow.Cells[7].Value.ToString();
                updatePay.txtprovisionDay.Text = Paytimes;

                // dgvStaffWork.CurrentRow.Cells[7].Value.ToString() , GridView의 급여 컬럼이 비어있다면?
                // 이미 급여가 입력된 사원은 다시 입력받지 않게..
                if (dgvStaffWork.CurrentRow.Cells[7].Value.ToString() != "")
                {
                    updatePay.Show();                  
                    return;
                } else if(updatePay.txtempName.Text == "이름")
                {

                    MessageBox.Show("사원이 선택되지 않았습니다.", "수정실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show(updatePay.txtempName.Text + " 님은 입력된 급여가 없습니다. 급여입력을 원하시면 급여입력 버튼을 클릭하세요.", "수정실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("사원이 선택되지 않았습니다.", "수정실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnPayInitialization_Click(object sender, EventArgs e) // 월별 급여 초기화
        {
            

            //파일 저장 위치 선택.
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.InitialDirectory = @"D:\응용SW개발자 양성과정\과정6\windowFormProject\CSVPos_20180110작업본\CVSFILE";
            saveDlg.Filter = "csv (*.csv)|*.csv|txt (*txt)|*.txt|All files (*.*)|*.*";
            if (saveDlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            //파일 저장을 위해 스트림 생성.
            FileStream fs = new FileStream(saveDlg.FileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF32);

            sw.Flush();
            sw.Close();
            fs.Close();




        }
    }
}
