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
    public partial class FormDiscount : Form
    {
        private SqlConnection con;
        private double percentDC; // 할인 금액 (얼마나 할인해주는지)
        private int beforeDC; // 할인 전 가격
        private int afterDC; // 할인 후 가격
        public FormDiscount()
        {
            InitializeComponent();
        }

        private void txtTelecom_TextChanged(object sender, EventArgs e)
        {
            if (txtTelecom.Text.Length == 16)
            {
                con = Connection.GetInstance();
                using (SqlCommand cmd = new SqlCommand("ss_SelectTelecom", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@membershipNum", txtTelecom.Text);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            lblMembership.Text = sdr["Tgrade"].ToString();
                            lblDiscount.Text = sdr["Tdiscount"].ToString() + "%";
                            percentDC = double.Parse(sdr["Tdiscount"].ToString());
                        }
                    } 
                    else
                    {
                        MessageBox.Show("유효한 번호가 아닙니다.");
                    }

                    sdr.Close();
                }
                con.Close();

                // 할인 적용
                // 할인 전 가격 - (할인 전 가격 * 할인율)
                beforeDC = int.Parse(txtBeforeDC.Text);

                // 할인 가격 
                percentDC = percentDC * 0.01;
                percentDC = (beforeDC * percentDC);
                afterDC = beforeDC - (int)percentDC;
                txtAfterDC.Text = afterDC.ToString();
            }            
        }

        public double SendPercent()
        {
            return percentDC;
        }

        public int SendPrice()
        {
            #region 2018.01.22 수정 / 멤버십 입력 없을 때 적용하면 원가 들어가도록
            if (txtTelecom.Text == "")
            {
                return int.Parse(txtBeforeDC.Text);
            }
            else
            {
                return afterDC;
            } 
            #endregion
        }

        private void txtTelecom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtTelecom_Click(object sender, EventArgs e) // 멤버십 번호 텍스트박스 클릭 시 멤버십 번호, 할인율 내용 초기화
        {
            txtTelecom.Text = "";
            lblMembership.Text = "";
            lblDiscount.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SellMonitor sm = (SellMonitor)Owner;
            sm.TeleDC = txtTelecom.Text;
            sm.btnGifti.Enabled = false;

            
            SendPrice();
            SendPercent();
            this.Close();
        }
    }
}
