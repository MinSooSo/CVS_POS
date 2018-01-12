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
        string name; // 해고 시 이름 띄우는 전역변수
        string firedate; // 퇴사일 알려주는 전역변수 

        DataTable dt;
        SqlDataAdapter adapter;
        public StaffM()
        {
            InitializeComponent();
        }

        private void StaffM_Load(object sender, EventArgs e)
        {       
            timeStart();
            labelLoginTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // 2018-01-11 
            // 작업자 : 위영범
            // 작업내용 : 직원관리 폼 띄울 때 DataGridView(dgvEmpInfo)에 전체 직원 띄어주기 
            DatagridviewLoad(); // DataGridView에 띄우는 메서드
        }
        internal void DatagridviewLoad()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString))
            {
                
                con.Open();
                adapter = new SqlDataAdapter("yb_allStaffInfo", con);
                adapter.SelectCommand = new SqlCommand("yb_allStaffInfo", con);
                dt = new DataTable();

                adapter.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvEmpInfo.Rows.Add();
                    for (int i = 0; i < dgvEmpInfo.RowCount; i++)
                    {
                        dgvEmpInfo.Rows[n].Cells[0].Value = i;
                    }
                    dgvEmpInfo.Rows[n].Cells[1].Value = item[0].ToString();
                    name = item[1].ToString();
                    dgvEmpInfo.Rows[n].Cells[3].Value = name;

                    dgvEmpInfo.Rows[n].Cells[2].Value = item[1].ToString();

                    if (item[3].ToString() == "True")
                    {
                        dgvEmpInfo.Rows[n].Cells[4].Value = "여자";
                    }
                    else
                    {
                        dgvEmpInfo.Rows[n].Cells[4].Value = "남자";
                    }
                    dgvEmpInfo.Rows[n].Cells[5].Value = item[4].ToString();
                    dgvEmpInfo.Rows[n].Cells[6].Value = item[5].ToString();
                    dgvEmpInfo.Rows[n].Cells[7].Value = item[6].ToString();
                    dgvEmpInfo.Rows[n].Cells[8].Value = item[7].ToString();

                    firedate = item[8].ToString(); // 퇴사일
                    dgvEmpInfo.Rows[n].Cells[9].Value = firedate;


                    if (item[9].ToString() == "True")
                    {
                        dgvEmpInfo.Rows[n].Cells[10].Value = "점장";
                    }
                    else
                    {
                        dgvEmpInfo.Rows[n].Cells[10].Value = "아르바이트";
                    }
                    dgvEmpInfo.Rows[n].Cells[11].Value = item[10].ToString();
                    
                }
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
            fh.Show();        
        }

        // 2018-01-11 
        // 작업자 : 위영범
        // 작업내용 : 직원해고 버튼 클릭 시 퇴사일 컬럼에 현재날짜가 출력된다.

        private void btnFiredate_Click(object sender, EventArgs e) // 직원 해고 눌렀을 때
        {
            if (MessageBox.Show("정말로 " + name + " 님을 해고하시겠습니까?", "퇴사", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (firedate != "")
                {
                    MessageBox.Show("이미 해고된 직원입니다.");
                    return;
                }

                string empNum = lbluserEmpNum.Text; // 임시테스트 실제 lbluserEmpNum에는 로그인한 사번의 이름을 가져와야함
                string presentTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                dgvEmpInfo.Click += DgvEmpInfo_Click;
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("yb_updateFiredate", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SM_empNum", empNum);
                        cmd.Parameters.AddWithValue("@SM_presentTime", presentTime);
                        con.Open();

                        int i = cmd.ExecuteNonQuery();
                        if (i == 1)
                        {
                     
                            MessageBox.Show(name + " 님이 해고 되었습니다.", "퇴사");
                        }
                    }
                }            
            }        
        }
        internal void CleardgvEmpInfo()
        {
            
            dgvEmpInfo.Refresh();
            DatagridviewLoad();
           
        }
        private void DgvEmpInfo_Click(object sender, EventArgs e)
        {
            
        }

 
    }
}
