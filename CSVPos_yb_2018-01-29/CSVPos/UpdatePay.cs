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
    public partial class UpdatePay : Form
    {
        private SqlConnection con = Connection.GetInstance();

        public UpdatePay()
        {
            InitializeComponent();
        }



        private void btninputPay_Click(object sender, EventArgs e)
        {
            string empNum = txtempNum.Text;
            string empUpdatePay = txtUpdatePay.Text;
            string empProvisionDay = txtprovisionDay.Text;
 
                con.Open();
                using (var cmd = new SqlCommand("yb_payUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empNum", empNum);
                    cmd.Parameters.AddWithValue("@monthPay", empUpdatePay);
                    cmd.Parameters.AddWithValue("@provisionDay", empProvisionDay);


                    int i = cmd.ExecuteNonQuery();

                    if (i==1)
                    {
                        if (MessageBox.Show(txtempName.Text + " 님의 급여를 수정하시겠습니까?", "급여수정", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            MessageBox.Show(txtempName.Text + " 님의 급여가 수정되었습니다.");

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
            if (MessageBox.Show("취소 하시겠습니까?", "수정 취소", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
