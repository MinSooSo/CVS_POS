using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVPos
{
    public partial class StaffNum : Form
    {
        private string formname;
        private SqlConnection con = Connection.GetInstance();
        public string Formname { get => formname; set => formname = value; }

        string empName;
        string empForm;
        string empNum;
        
        public StaffNum()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 로그인 화면 버튼 클릭 시 값에 맞게 텍스트창에 입력된다.
        /// </summary>
        private void StaffNum_Load(object sender, EventArgs e)
        {
            num1.Click += Num1_Click;
            num2.Click += Num2_Click;
            num3.Click += Num3_Click;
            num4.Click += Num4_Click;
            num5.Click += Num5_Click;
            num6.Click += Num6_Click;
            num7.Click += Num7_Click;
            num8.Click += Num8_Click;
            num9.Click += Num9_Click;
            num0.Click += Num0_Click;
            btnClear.Click += BtnClear_Click;
            btnBackspace.Click += BtnBackspace_Click;


        }

        private void BtnBackspace_Click(object sender, EventArgs e)
        {

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtInputEmpNum.Clear();
        }

        private void Num0_Click(object sender, EventArgs e)
        {
            txtInputEmpNum.Text += "0";
        }

        private void Num9_Click(object sender, EventArgs e)
        {
            txtInputEmpNum.Text += "9";
        }

        private void Num8_Click(object sender, EventArgs e)
        {
            txtInputEmpNum.Text += "8";
        }

        private void Num7_Click(object sender, EventArgs e)
        {
            txtInputEmpNum.Text += "7";
        }

        private void Num6_Click(object sender, EventArgs e)
        {
            txtInputEmpNum.Text += "6";
        }

        private void Num5_Click(object sender, EventArgs e)
        {
            txtInputEmpNum.Text += "5";
        }

        private void Num4_Click(object sender, EventArgs e)
        {
            txtInputEmpNum.Text += "4";
        }

        private void Num3_Click(object sender, EventArgs e)
        {
            txtInputEmpNum.Text += "3";
        }

        private void Num2_Click(object sender, EventArgs e)
        {
            txtInputEmpNum.Text += "2";
        }

        private void Num1_Click(object sender, EventArgs e)
        {
            txtInputEmpNum.Text += "1";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 유입된 경로를 확인하고, 아이디를 확인하는 화면입니다.
            // textbox.text 는 DB에서 사원번호를 꺼내오면 됩니다. 
            // string query = "select select SM_employForm from CVS_StaffManagement where empNum = 201501091001";
            
            // 2018.01.10 , 로그인폼 로그기록 남겨놓기.

            using (var cmd = new SqlCommand("ms_checkstaffNum", con))
            {
                con.Open();
                
                string checkStaffNum = txtInputEmpNum.Text.Trim();
                string formText = this.Text;

                cmd.Parameters.AddWithValue("@staffnum", checkStaffNum);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    empName = sdr["SM_name"].ToString();
                    empForm = sdr["SM_employForm"].ToString();
                    empNum = sdr["SM_residentNum"].ToString();
                }

                con.Close();
                

                // 민수랑 상의해볼 부분 : 나는 매장관리 폼만 열어두게 해야 에러가 안뜸 나중에 통합할때 문제될거같음


                if (empForm == "True") // 아르바이트 고용형태가 True일 경우 
                {
                    MakeLogrecod(checkStaffNum, formText);
                    //StoreM sm = new StoreM();
                    //sm.lblempName.Text = empName; // 자식 폼인 staffM에 empName을 넘겨준다.
                    //sm.lblempNum.Text = checkStaffNum; // 입력한 사번 불러오기. 
                    //sm.Show();
                    //this.Close();

                    if (Formname == "sellMonitor")
                    {
                        this.Close();
                        SellMonitor sm = new SellMonitor();
                        sm.Show();
                    }
                    else if (Formname == "store") // 알맞은 사원번호가 있을 시 떠야 되는데.. 
                    {
                        this.Close();
                        StoreM sm = new StoreM();
                        sm.lblempName.Text = empName; // 자식 폼인 staffM에 empName을 넘겨준다.
                        sm.lblempNum.Text = checkStaffNum; // 입력한 사번 불러오기. 
                        sm.Show();
                    }
                    else if (Formname == "stockManagement")
                    {
                        this.Close();
                        FormStoreStock fss = new FormStoreStock();
                        fss.Show();
                    }

                }
                else
                {
                    MessageBox.Show("정상적인 접근 방법이 아니거나, 사원 번호가 올바르지 않습니다 \t\n" +
                        " 혹은, 아르바이트 생은 사용할 수 없는 기능입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void StaffNum_FormClosed(object sender, FormClosedEventArgs e) // 폼이 닫힐 때 . 
        {
            UpdateLogReleaseTime();
        }

        public void UpdateLogReleaseTime()
        {
            using (var cmd = new SqlCommand("ms_releaseTimeUpdate", con))
            {
                con.Open();

                string releaseTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                cmd.Parameters.AddWithValue("@releasedate", releaseTime);

                cmd.CommandType = CommandType.StoredProcedure;

                int check = cmd.ExecuteNonQuery();

                if (check == 1)
                {
                    MessageBox.Show("업데이트 완료"); // 추후 지우시면 됩니당. 
                }
                else
                {
                    MessageBox.Show("헤헤헤"); //  추후 지우기 
                }
            }
            con.Close();
        }

        public void MakeLogrecod(string n, string fn)
        {
            var logcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString);
            var logRecord = new SqlCommand("ms_InsertLogReCord", logcon);

            logcon.Open();

            string nowTime = System.DateTime.Now.ToShortTimeString();

            logRecord.CommandType = CommandType.StoredProcedure;

            logRecord.Parameters.AddWithValue("@empnum", n);
            logRecord.Parameters.AddWithValue("@LRtime", DateTime.Parse(nowTime));
            logRecord.Parameters.AddWithValue("@LRScreen", fn);

            int logRecordRow = logRecord.ExecuteNonQuery();

            if (logRecordRow == 1)
            {
                // MessageBox.Show("로그 업데이트 완료");
            }
            else
            {
                MessageBox.Show("로그 업데이트 오류 발생");
            }
        }
    }
}
