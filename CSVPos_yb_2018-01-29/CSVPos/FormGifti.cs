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
    public partial class FormGifti : Form
    {
        // 2018.01.22 txtGifti ==> internal
        private SqlConnection con;
        public FormGifti()
        {
            InitializeComponent();
        }

        // 기프티콘 번호 텍스트박스에 커서 올려놓고 바코드 찍었을 경우
        // 9자리까지 입력되도록 프로퍼티에서 값 설정했음
        private void txtGifti_TextChanged(object sender, EventArgs e)
        {
            if (txtGifti.Text.Length == 9)
            {
                // 바코드 번호와 기프티콘 테이블에 있는 번호가 맞은 경우 출력.
                con = Connection.GetInstance();
                //MessageBox.Show("기프티콘 바코드입력" + con.ConnectionString);
                using (SqlCommand cmd = new SqlCommand("ss_SelectGifti", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@giftiNum", int.Parse(txtGifti.Text));

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            txtProduct.Text = sdr["G_giftiConName"].ToString();
                            // 상품명은 internal 처리하여 기프티콘 적용 버튼을 눌렀을 때 SellMonitor 폼에서 알아서 가져다 쓰자.

                            string useAble = sdr["G_giftiConUseable"].ToString();

                            if (useAble == "True")
                            {
                                txtUseable.Text = "사용 가능";
                                btnGifticonUse.Enabled = true;
                            }
                            else
                            {
                                txtUseable.Text = "사용 불가능";
                                btnGifticonUse.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("잘못된 바코드 정보입니다.");
                    }
                    sdr.Close();
                }
                con.Close();
                //MessageBox.Show("Test");
                //try
                //{

                //}
                //catch (SqlException)
                //{
                //    // 알맞은 바코드가 아닌 경우
                //    // 바코드 텍스트 박스를 비워줘야 하는데 그 경우 다시 TextChanged 이벤트 실행됨
                //    MessageBox.Show("잘못된 바코드 정보입니다.");
                //}
                //finally
                //{
                //    con.Close();
                //}
            }
        }

        //private void btnSelect_Click(object sender, EventArgs e) // 조회 버튼 눌렀을 경우
        //{
        //    try
        //    {
        //        // 바코드 번호와 기프티콘 테이블에 있는 번호가 맞은 경우 출력.
        //        con = Connection.GetInstance();
        //        con.Open();
        //        using (SqlCommand cmd = new SqlCommand("ss_SelectGifti", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@giftiNum", int.Parse(txtGifti.Text));

        //            SqlDataReader sdr = cmd.ExecuteReader(); // select문 실행
        //            while (sdr.Read())
        //            {
        //                MessageBox.Show(sdr["G_giftiConName"].ToString());
        //            }

        //            sdr.Close();
        //        }
        //    }
        //    catch (SqlException)
        //    {
        //        // 알맞은 바코드가 아닌 경우
        //        // 바코드 텍스트 박스를 비워줘야 하는데 그 경우 다시 TextChanged 이벤트 실행됨
        //        MessageBox.Show("잘못된 바코드 정보입니다.");
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        private void txtGifti_KeyPress(object sender, KeyPressEventArgs e) // 숫자만 가능하도록 유효성 검사
        {
            if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtGifti_Click(object sender, EventArgs e) // 기프티콘 번호 텍스트박스 클릭 시 모든 텍스트박스 내용 초기화
        {
            txtGifti.Text = "";
            txtProduct.Text = "";
            txtUseable.Text = "";
            btnGifticonUse.Enabled = false;
        }
        
    }
}
