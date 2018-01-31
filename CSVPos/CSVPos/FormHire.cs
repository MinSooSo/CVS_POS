using System;
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
    public partial class FormHire : Form
    {
        private SqlConnection con = Connection.GetInstance();
        public FormHire()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 작성자 : 위영범
        /// 2018-01-16 작업시작. 당일 작업완료
        /// 작업내용 : 현직원수, 총 직원수 띄워주기. 직원 고용 정보입력 버튼클릭 시 바뀐 직원 수가 바로 로드 됨. 
        /// </summary>

        private void FormHire_Load(object sender, EventArgs e)
        {
            memberNum();    
        }

        private void memberNum() // 현재 직원, 총 직원 수 뽑아주는 메서드 
        {
            lblTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string empTotalNum = lbltotalEmp.Text;
            string empPresentNum = lblpresentEmp.Text;

            using (var cmd = new SqlCommand("yb_empPresentNum", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@presendMemberNum", empPresentNum);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    lblpresentEmp.Text = sdr.GetInt32(0).ToString();
                }
                con.Close();
            }


            using (var cmd = new SqlCommand("yb_empTotalNum", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@totalMemberNum", empPresentNum);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    lbltotalEmp.Text = sdr.GetInt32(0).ToString();
                }
                con.Close();
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("직원 등록을 취소하시겠습니까?", "직원 등록 취소", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("직원 등록이 계속 가능합니다.", "직원 등록 재개");
                return;
            }
        }

        private void btnDiscount_Click(object sender, EventArgs e) // 입력 화면 초기화 
        {
            InputInitialization(); // 입력화면 초기화 메서드

            txtempNum.Text = "";
            txtempName.Text = "";
            txtempAge.Text = "";
            txtempAddress.Text = "";
            txtempResidentNum.Text = "";
            txtempPhoneNum.Text = "";
            lblTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }

        private void InputInitialization()
        {
            txtempNum.Text = "";
            txtempName.Text = "";
            txtempAge.Text = "";
            txtempAddress.Text = "";
            txtempResidentNum.Text = "";
            txtempPhoneNum.Text = "";
            lblTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 작성자 : 위영범
        /// 2018-01-10 ~ 2018-01-16
        /// 작업내용 : 정보입력 버튼 클릭 시 새로운 사원의 정보가 DB에 저장된다. DB에 저장됨과 동시에 부모 폼에 있는
        /// dataGridView에 사원의 정보가 띄어진다. 텍스트창에 모두 입력해야 정보입력을 할 수 있다.
        /// </summary>
        private void btnHire_Click(object sender, EventArgs e) // 직원고용을 위한 버튼 입니다.       
        {
            // 고용형태
            try
            {
                bool alba = true;
                if (lblemployee.Text == "아르바이트")
                {
                    alba = false;
                }
                string empalba = alba.ToString();
                string empForm = null;
                if (empalba == "True")
                {
                    empForm = "0";
                }
                else if (empalba == "False")
                {
                    empForm = "1";
                }

                string empNum = txtempNum.Text; // 사번
                string empName = txtempName.Text; // 이름
                string empAge = txtempAge.Text; // 나이
                string empResidentNum = txtempResidentNum.Text; // 주민등록번호

                bool sex = true;
                if (radioMan.Checked)
                {
                    sex = false;

                }
                else if (radioWoman.Checked)
                {
                    sex = true;
                }

                string empGender = sex.ToString(); // 성별
                string empPhoneNum = txtempPhoneNum.Text; // 휴대폰번호
                string empAddress = txtempAddress.Text; // 주소(일단 테스트)
                string empEmployee = lblemployee.Text; // 고용인
                string empHiredate = lblTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // 고용시간

                using (var cmd = new SqlCommand("yb_employment", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SM_employForm", empForm);
                    cmd.Parameters.AddWithValue("@empNum", empNum);
                    cmd.Parameters.AddWithValue("@SM_name", empName);
                    cmd.Parameters.AddWithValue("@SM_age", empAge);
                    cmd.Parameters.AddWithValue("@SM_residentNum", empResidentNum);
                    cmd.Parameters.AddWithValue("@SM_gender", empGender);
                    cmd.Parameters.AddWithValue("@SM_phoneNum", empPhoneNum);
                    cmd.Parameters.AddWithValue("@SM_address", empAddress);
                    cmd.Parameters.AddWithValue("@SM_employeer", empEmployee);
                    cmd.Parameters.AddWithValue("@SM_hiredate", empHiredate);

                   
                    if (txtempNum.Text == "")
                    {
                        MessageBox.Show("사번은 반드시 입력해주세요", MessageBoxIcon.Warning.ToString());
                    }

                    else if (txtempName.Text == "" || txtempAddress.Text == "" || txtempAge.Text == "" || txtempResidentNum.Text == "" || !radioMan.Checked && !radioWoman.Checked)
                    {
                        MessageBox.Show("입력하지 않은 텍스란이 있는지 확인하세요.", "경고");
                    }

                    else
                    {
                        try
                        {
                            int i = cmd.ExecuteNonQuery();
                            if (i == 1)
                            {

                                MessageBox.Show("새로운 사원이 등록되었습니다.", "사원등록 완료");

                                using (var con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString))
                                {                             
                                using (var cmd1 = new SqlCommand("yb_salaryAddempNum", con1))
                                {
                                        con1.Open();
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.Parameters.AddWithValue("@empNum1", empNum);
                                    var sdr = cmd1.ExecuteNonQuery();

                                    if (sdr == 1)
                                    {
                                        // 급여 테이블에도 사번 저장하기
                                    }
                                    con1.Close();
                                    StaffM st = (StaffM)Owner;
                                    st.CleardgvEmpInfo(); // 기존 DataGridView 삭제 후 다시 띄우기 (자식폼에서 가져옴)
                                                          // 직원수와 시간을 초기화 시킨 후 다시 멤버 수와 시간을 불러온다.
                                    lblTime.Text = "";
                                    lbltotalEmp.Text = "";
                                    lblpresentEmp.Text = "";
                                    con.Close();
                                    memberNum();
                                    InputInitialization();
                                    return;
                                }
                            }                              
                           }
                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                            MessageBox.Show("이미 존재하는 사번입니다.", MessageBoxIcon.Warning.ToString());
                            return;
                        }
                    }
                    con.Close();
                }
             
                // 급여 테이블에도 사번 저장하기. 

              
            }
            catch (System.Data.SqlClient.SqlException)
            {
                // 예외처리 
            }
        }
    }
}
