using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVPos
{
    public partial class StaffM : Form
    {

        private SqlConnection con = Connection.GetInstance();
        SqlDataAdapter adapter;
        public StaffM()
        {
            InitializeComponent();
        }

        private void StaffM_Load(object sender, EventArgs e)
        {
            timeStart();
            labelLoginTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // 2018-01-11 ~ 2018-01-16
            // 작업자 : 위영범
            // 작업내용 : 직원관리 폼 띄울 때 DataGridView(dgvEmpInfo)에 전체 직원 띄어주기 
          
            DatagridviewLoad(); // DataGridView에 띄우는 메서드

        }


        internal void DatagridviewLoad()
        {
            dgvEmpInfo.Update();
    
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString))
            {         
            con.Open();
            adapter = new SqlDataAdapter("yb_allStaffInfo", con);
            adapter.SelectCommand = new SqlCommand("yb_allStaffInfo", con);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            // MessageBox.Show(dgvEmpInfo.Rows.Count.ToString());
            dgvEmpInfo.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvEmpInfo.Rows.Add();

                for (int i = 0; i < dgvEmpInfo.RowCount; i++) // 넘버
                {
                    dgvEmpInfo.Rows[n].Cells[0].Value = i;

                }

                dgvEmpInfo.Rows[n].Cells[1].Value = item[0].ToString(); // 사번
                dgvEmpInfo.Rows[n].Cells[2].Value = item[1].ToString(); // 이름
                dgvEmpInfo.Rows[n].Cells[3].Value = item[2].ToString(); // 나이


                if (item[3].ToString() == "True") // 성별
                {
                    dgvEmpInfo.Rows[n].Cells[4].Value = "여자";
                }
                else
                {
                    dgvEmpInfo.Rows[n].Cells[4].Value = "남자";
                }
                dgvEmpInfo.Rows[n].Cells[5].Value = item[4].ToString(); // 주민번호
                dgvEmpInfo.Rows[n].Cells[6].Value = item[5].ToString(); // 연락처
                dgvEmpInfo.Rows[n].Cells[7].Value = item[6].ToString(); // 주소
                dgvEmpInfo.Rows[n].Cells[8].Value = item[7].ToString(); // 입사일
                                                                        // MessageBox.Show(dgvEmpInfo.Rows[1].Cells[8].Value.ToString() + dgvEmpInfo.Rows[2].Cells[8].Value.ToString());
                dgvEmpInfo.Rows[n].Cells[9].Value = item[8].ToString(); // 퇴사일


                if (item[9].ToString() == "True") // 고용형태
                {
                    dgvEmpInfo.Rows[n].Cells[10].Value = "점장";
                }
                else
                {
                    dgvEmpInfo.Rows[n].Cells[10].Value = "아르바이트";
                }
                dgvEmpInfo.Rows[n].Cells[11].Value = item[10].ToString(); // 고용인

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

        private void btnhireStaff_Click(object sender, EventArgs e) // 직원 고용 눌렀을 때
        {
            FormHire fh = new FormHire();
            fh.Owner = this; // 직원고용폼(자식)의 부모가 직원관리폼이라는 것을 알려줌

            // 고용인 정보
            fh.lblCallupNam.Text = lbluserName.Text;
            fh.lblemployee.Text = lbluserName.Text;
            fh.Show();

        }

        // 2018-01-11 ~ 2018-01-16
        // 작업자 : 위영범
        // 작업내용 : 직원해고 버튼 클릭 시 퇴사일 컬럼에 현재날짜가 출력된다.
        // 해고 후 바로 dataGridView가 초기화 되고 재로드 된다. 

        internal void CleardgvEmpInfo() 
        {
            
              DatagridviewLoad();         
        }

        private void btnFiredate_Click(object sender, EventArgs e) // 직원해고
        {
            string empName = dgvEmpInfo.CurrentRow.Cells[2].Value.ToString(); // 이름
            string firedate = dgvEmpInfo.CurrentRow.Cells[9].Value.ToString(); // 퇴사일
            string masterNum = dgvEmpInfo.CurrentRow.Cells[1].Value.ToString(); //점장의 사번

            try
            {
                if (firedate != "")
                {
                    MessageBox.Show("이미 퇴사처리된 직원입니다.");
                    return;
                }

                if (lbluserEmpNum.Text == masterNum)
                {
                    if (MessageBox.Show("사원번호 : " + masterNum + " " + empName + " 님 께서는 현재 점장으로 근무하고 있습니다. 정말 퇴사를 원하십니까?", "퇴사 신청", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show("귀하의 노고에 진심으로 감사드립니다.", "퇴사완료");
                        fireCommit();
                    }
                }
                else if (dgvEmpInfo.CurrentRow.Cells[10].Value.ToString() == "점장")
                {
                    MessageBox.Show("다른 점장은 해고 할 수 없습니다. 본인 점장 사번으로 로그인 후 직접 퇴사 할 수 있습니다.");
                }

                else if (MessageBox.Show(empName + " 님을 해고하시겠습니까?", "퇴사", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    fireCommit();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("사원이 선택되지 않았습니다.", "퇴사실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void fireCommit() // 퇴사 완료 시  실행될 메서드 
        {
            string empNum = dgvEmpInfo.CurrentRow.Cells[1].Value.ToString();
            string presentTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string empName = dgvEmpInfo.CurrentRow.Cells[2].Value.ToString(); // 이름
            string firedate = dgvEmpInfo.CurrentRow.Cells[9].Value.ToString(); // 퇴사일
            string masterNum = dgvEmpInfo.CurrentRow.Cells[1].Value.ToString(); //점장의 사번


            using (var cmd = new SqlCommand("yb_updateFiredate", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SM_empNum", empNum);
                cmd.Parameters.AddWithValue("@SM_presentTime", presentTime);
                con.Open();

                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show(empName + " 님이 퇴사처리 되었습니다.", "퇴사");
                    dgvEmpInfo.Rows.Clear(); // dataGridView의 행을 지우고.
                    con.Close();
                    DatagridviewLoad(); // dataGridView를 재로드 
                }

            }


            // 해고시 급여 테이블에서 사번 삭제. 

            using (var cmd = new SqlCommand("yb_deleteSalaryEmpNum", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empNum1", empNum);

                var sdr = cmd.ExecuteNonQuery();
                if (sdr == 1)
                {
                    // 급여테이블에서 사번 삭제
                }
            }
            con.Close();
        }
    }
}
