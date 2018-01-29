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
    public partial class staffNum : Form
    {
        private string formname;

        public string Formname { get => formname; set => formname = value; }

        string empName;
        string empForm;
        string empNum;

        public staffNum()
        {
            InitializeComponent();
        }

        private void StaffNum_Load(object sender, EventArgs e)
        {
                     
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 유입된 경로를 확인하고, 아이디를 확인하는 화면입니다.
            // textbox.text 는 DB에서 사원번호를 꺼내오면 됩니다. 
            // string query = "select select SM_employForm from CVS_StaffManagement where empNum = 201501091001";

            // 2018.01.10 로그인폼 로그기록 남겨놓기.
            // 2018.01.12 로그인폼 (판매화면으로 넘어갈때 사원쪽으로 넘어갈 수 있도록 하세요. 
            // 2018.01.12 로그인폼 (판매화면같은경우 교대라는 변수가 존재하는데 그거 뽑을 수 잇도록 하세요)
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString);

            using (var cmd = new SqlCommand("ms_checkstaffNum", con))
            {
                con.Open();

                string checkStaffNum = textBox1.Text.Trim();
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

                if (empForm == "True")
                {
                    MakeLogrecod(checkStaffNum, formText);
                    if (Formname == "sellMonitor")
                    {
                        this.Close();
                        SellMonitor sm = new SellMonitor();
                        sm.EmpName = empName;
                        sm.EmpNum = checkStaffNum;
                        sm.Show();
                    }
                    else if (Formname == "storeManagement")
                    {
                        this.Close();
                        StoreM sm = new StoreM();
                        sm.EmpName = empName;
                        sm.Show();
                    }
                    else if (Formname == "stockManagement")
                    {
                        this.Close();
                        FormStoreStock fss = new FormStoreStock();
                        fss.EmpName1 = empName;
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
        private void num1_Click(object sender, EventArgs e)
        {
            textBox1.Text += num1.Text;
        }

        private void num2_Click(object sender, EventArgs e)
        {
            textBox1.Text += num2.Text;
        }

        private void num3_Click(object sender, EventArgs e)
        {
            textBox1.Text += num3.Text;
        }

        private void num4_Click(object sender, EventArgs e)
        {
            textBox1.Text += num4.Text;
        }

        private void num5_Click(object sender, EventArgs e)
        {
            textBox1.Text += num5.Text;
        }

        private void num6_Click(object sender, EventArgs e)
        {
            textBox1.Text += num6.Text;
        }

        private void num7_Click(object sender, EventArgs e)
        {
            textBox1.Text += num7.Text;
        }

        private void num8_Click(object sender, EventArgs e)
        {
            textBox1.Text += num8.Text;
        }

        private void num9_Click(object sender, EventArgs e)
        {
            textBox1.Text += num9.Text;
        }

        private void num0_Click(object sender, EventArgs e)
        {
            textBox1.Text += num0.Text;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void StaffNum_FormClosed(object sender, FormClosedEventArgs e) // 폼이 닫힐 때 . 
        {
            UpdateLogReleaseTime();           
        }

        public void UpdateLogReleaseTime()
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString);

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
        }


        public void MakeLogrecod(string n, string fn )
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

