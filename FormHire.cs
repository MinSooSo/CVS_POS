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
        public FormHire()
        {
            InitializeComponent();
        }

        private void FormHire_Load(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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

        /// <summary>
        /// 작성자 : 위영범
        /// 2018-01-11 작업시작
        /// </summary>
        private void btnDiscount_Click(object sender, EventArgs e) // 입력 화면 초기화 
        {
            txtempNum.Text = "";
            txtempName.Text = "";
            txtempAge.Text = "";
            txtempAddress.Text = "";
            txtempResidentNum.Text = "";
            txtempPhoneNum.Text = "";
            lblTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // 라디오버튼 체크 없애는거 찾아서 해볼 것 !
        }

        /// <summary>
        /// 작성자 : 위영범
        /// 2018-01-10 작업시작, 2018-01-11 작업수정
        /// </summary>
        private void btnHire_Click(object sender, EventArgs e) // 직원고용을 위한 버튼 입니다.       
        {
             
            // 고용형태
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
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString))
            {
                using (var cmd = new SqlCommand("yb_employment", con))
                {
                

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
                  
                    con.Open();
                    if (txtempNum.Text == "")
                    {
                        MessageBox.Show("사번은 반드시 입력해주세요", MessageBoxIcon.Warning.ToString());
                    }
                    else
                    {
                        try
                        {
                            int i = cmd.ExecuteNonQuery();
                            if (i == 1)
                            {
                               MessageBox.Show("새로운 사원이 등록되었습니다.", "사원등록 완료");
                                StaffM st = (StaffM)Owner;
                                st.CleardgvEmpInfo(); // 기존 DataGridView 삭제 후 다시 띄우기 (자식폼에서 가져옴)
                                return;
                            }                        
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("이미 존재하는 사번입니다.", MessageBoxIcon.Warning.ToString());
                        }
                    }               
                }              
            }
                      
        }
    }
}
