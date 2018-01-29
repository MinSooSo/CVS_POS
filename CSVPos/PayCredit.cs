using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVPos
{
    public partial class PayCredit : Form
    {

        private string cardNum;
        private string cardCompanyName;
        // 카드 결제에 관한 클래스. 
        // 카드 결제 5만원 이상일 시 사인 추가 예정
        
        // 카드결제 : 카드번호만 받아서 DB연동 후 카드가 현재 있는 카드인지 없는카드인지 조회.
        //            결제를 누르면 판매 완료 버튼이 눌려야 함(mbox 띄워주면서 니가 결제를 누르면 자동으로 판매완료가 되므로, 
        //            할인 적용을 먼저 하라는 mbox를 띄워라)

        // 시뮬레이션 : 물건 값이 2000원이다(1000원 x2) 이 상황에서 기프티콘하나를 사용하여 1000원이 남았다.
        //              그 이후 할인으로 15%를 받아서 850원을 내야 하는데 카드결제를 한다.
        //              근데 카드결제 시 할인이 10%가 된다고 하면 850원에서 85원을 빼야 함.그 알고리즘 생각.
        // 위의 시뮬레이션은 답이없다 .

        public PayCredit()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {

            MessageBox.Show("카드 정보가 일치합니다.");
            this.Close();

            // ==> 이번 프로젝트에서 바코드는 읽을 수 있지만 카드를 읽는것이 가능한가? (추후 수정)
            //MessageBox.Show(txtCardNum.Text);

            // 결제 버튼 클릭 시 입력한 카드번호가 CVS_Card 테이블에 있는지 Select
            // 있다면 카드번화와 카드회사명을 조회한 값을 DataSet에 저장. 
            // 없다면 결제 안되게 return
            SelectCard(txtCardNum.Text);

            SellMonitor sm = (SellMonitor)Owner;
            sm.CardNum = this.txtCardNum.Text;
            sm.UseCard = true;

            this.Close();
        }

        // 카드 조회 메서드(저장 프로시저 사용)
        private void SelectCard(string cardNumber)
        {
            //MessageBox.Show("카드 조회 프로시저 시작하세요");
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ss_CheckCardNum", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cardNum", cardNumber);

                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            //MessageBox.Show(sdr["CardNumber"].ToString() + " , " + sdr["CardCompanyName"].ToString());
                            cardNum = sdr["CardNumber"].ToString();
                            cardCompanyName = sdr["CardCompanyName"].ToString();

                            MessageBox.Show(cardNum + " , " + cardCompanyName);
                        }
                        sdr.Close();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("등록되지 않은 카드입니다.");

                        txtCardNum.Text = "";
                        txtCardNum.Focus();
                        sdr.Close();
                    }
                }
            }

        }
    }
}
