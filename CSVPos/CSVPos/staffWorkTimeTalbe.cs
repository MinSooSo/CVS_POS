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
    public partial class staffWorkTimeTalbe : Form
    {
        private SqlConnection con = Connection.GetInstance();
    
        public staffWorkTimeTalbe()
        {
            InitializeComponent();
        }

        private void staffWorkTimeTalbe_Load(object sender, EventArgs e)
        {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("yb_empWorkTable", con);
                adapter.SelectCommand = new SqlCommand("yb_empWorkTable", con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvWorkTable.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvWorkTable.Rows.Add();

                    dgvWorkTable.Rows[n].Cells[0].Value = item[0].ToString(); // 사번
                    dgvWorkTable.Rows[n].Cells[1].Value = item[1].ToString(); // 이름
                    if (item[2].ToString() == "True") // 고용형태
                    {
                        dgvWorkTable.Rows[n].Cells[2].Value = "점장";
                    }
                    else
                    {
                        dgvWorkTable.Rows[n].Cells[2].Value = "아르바이트";
                    }

                    dgvWorkTable.Rows[n].Cells[3].Value = item[3].ToString(); // 출근시간                  
                    dgvWorkTable.Rows[n].Cells[4].Value = item[4].ToString(); // 퇴근시간
                    dgvWorkTable.Rows[n].Cells[5].Value = item[5].ToString(); // 근무시간 
                 

                  
                }
                con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 CVS_POS를 종료하시겠습니까?", "POS 종료 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
               
            }
            else
            {
                MessageBox.Show("POS 종료가 취소 되었습니다", "POS 종료 취소");
                return;
            }
        }

        private void btnViewEmpNum_Click(object sender, EventArgs e)
        { 
            ViewEmpInfo viewEmpInfo = new ViewEmpInfo();
            viewEmpInfo.Owner = this;
            string empNum = txtViewEmpNum.Text;
            using (var cmd = new SqlCommand("yb_onePersonWorkTime", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empNum", empNum);

                SqlDataReader sdr = cmd.ExecuteReader();
                if (txtViewEmpNum.Text == "")
                {
                    MessageBox.Show("사번을 입력한 뒤 검색하세요.","검색실패",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    con.Close();
                }
                else if(!sdr.HasRows)
                {
                    MessageBox.Show("사번이 존재하지 않거나, 근무시간이 없는 사원입니다. 다시 확인 후 검색하세요","검색실패",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    con.Close();
                }
                else
                {              
                    while (sdr.Read())
                    {
                        // 사번과 이름을 ViewEmpInfo 폼으로 넘겨줌.
                        viewEmpInfo.lblempNum.Text = sdr.GetString(0).ToString(); // 사번
                        viewEmpInfo.lblempName.Text = sdr.GetString(1).ToString(); // 이름;
                    }
                    con.Close();
                    viewEmpInfo.Show();
                }

                
                
            }
          
        }
    }
}
