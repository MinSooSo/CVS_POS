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
    /// <summary>
    /// 2018-01-13 ~ 2018-01-16
    /// 작업 : 위영범
    /// 작업내용 : 현재 매장관리의 사업자번호와 사업자명, 지점명 등등을 불러올 수 있다.
    /// 텍스트창에 수정하고 싶은 내용을 쓰면 수정이 된다. 테이블에도 수정된 내용이 저장됨. 수정버튼 클릭 시
    /// 수정된 내용 역시 바로 로드 된다.
    /// </summary>
    public partial class FormStoreInfo : Form
    {
        SqlDataReader sdr; // 매장관리정보를 불러오는 SqlDataReader 전역 변수
        private SqlConnection con = Connection.GetInstance();

        public FormStoreInfo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("매장 정보 수정을 취소할까요?", "매장 정보 수정 취소", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("매장 정보 수정이 가능합니다.", "매장 정보 수정 재개");
                return;
            }
        }

        private void FormStoreInfo_Load(object sender, EventArgs e)
        {
            InfoShop(); // 폼 로드 시 매장정보를 보여주는 메서드            
        }

        private void InfoShop()
        {
            string SI_ID = lblSI_ID.Text;
            string SI_name = lblname.Text;
            string SI_bossName = lblbossName.Text;
            string SI_address = lbladdress.Text;
            string SI_phoneNum = lblphoneNum.Text;
            
            
            using (var cmd = new SqlCommand("yb_presentShop", con))
                {
                con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SI_ID", SI_ID);
                    cmd.Parameters.AddWithValue("@SI_name", SI_name);
                    cmd.Parameters.AddWithValue("@SI_bossName", SI_bossName);
                    cmd.Parameters.AddWithValue("@SI_address", SI_address);
                    cmd.Parameters.AddWithValue("@SI_phoneNum", SI_phoneNum);

                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            lblSI_ID.Text = "" + sdr.GetString(0).ToString();
                            lblname.Text = "" + sdr.GetString(1).ToString();
                            lblbossName.Text = "" + sdr.GetString(2).ToString();
                            lbladdress.Text = "" + sdr.GetString(3).ToString();
                            lblphoneNum.Text = "" + sdr.GetString(4).ToString();

                            txtNewID.Text = sdr.GetString(0).ToString();
                            txtNewName.Text = sdr.GetString(1).ToString();
                            txtNewBossName.Text = sdr.GetString(2).ToString();
                            txtNewAddress.Text = sdr.GetString(3).ToString();
                            txtNewPhoneNum.Text = sdr.GetString(4).ToString();
                        }
                    }
                con.Close();
            }
          
        }

        private void btnUpdate_Click(object sender, EventArgs e) // 수정버튼 클릭 시
        {
            string SI_ID = txtNewID.Text;
            string SI_name = txtNewName.Text;
            string SI_bossName = txtNewBossName.Text;
            string SI_address = txtNewAddress.Text;
            string SI_phoneNum = txtNewPhoneNum.Text;

            
                using (var cmd = new SqlCommand("yb_updateShopInfo",con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SI_ID", SI_ID);
                    cmd.Parameters.AddWithValue("@SI_name", SI_name);
                    cmd.Parameters.AddWithValue("@SI_bossName", SI_bossName);
                    cmd.Parameters.AddWithValue("@SI_address", SI_address);
                    cmd.Parameters.AddWithValue("@SI_phoneNum", SI_phoneNum);

                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {
                    if (MessageBox.Show("정보를 수정 하시겠습니까?","정보수정", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)  
                    {
                        MessageBox.Show("정보가 수정되었습니다.","정보수정");
                        
                    }
                    con.Close();
                    InfoShop(); // 다시 로드
                }
                
            }


        }
    }
}