using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSVPos
{
    public partial class ViewEmpInfo : Form
    {
        SqlConnection con = Connection.GetInstance(); 

        public ViewEmpInfo()
        {
            InitializeComponent();
        }

        private void ViewEmpInfo_Load(object sender, EventArgs e)
        {
            string empNum = lblempNum.Text;

            using (var cmd = new SqlCommand("yb_onePersonWorkTime",con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("empNum", empNum);

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvOnePersonWorkTable.Rows.Add();

                    dgvOnePersonWorkTable.Rows[n].Cells[0].Value = item[0].ToString(); // 사번
                    dgvOnePersonWorkTable.Rows[n].Cells[1].Value = item[1].ToString(); // 이름
                    if (item[2].ToString() == "True") // 고용형태
                    {
                        dgvOnePersonWorkTable.Rows[n].Cells[2].Value = "점장";
                    }
                    else
                    {
                        dgvOnePersonWorkTable.Rows[n].Cells[2].Value = "아르바이트";
                    }

                    dgvOnePersonWorkTable.Rows[n].Cells[3].Value = item[3].ToString(); // 출근시간                  
                    dgvOnePersonWorkTable.Rows[n].Cells[4].Value = item[4].ToString(); // 퇴근시간
                    dgvOnePersonWorkTable.Rows[n].Cells[5].Value = item[5].ToString(); // 근무시간 
                    lbltotalWorkTime.Text = item[6].ToString();

                }
                con.Close();
            }
        }
    }
}
