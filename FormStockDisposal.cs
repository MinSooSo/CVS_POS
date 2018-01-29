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
    
    public partial class FormStockDisposal : Form
    {
        private int allAbandonPrice;
        private string DisandRe;
        private string barcode;
        private string proName;
        private string waredate;
        private string actuality;
        private int barcodeCount = 0;
        private int DisposalCount;
        SqlConnection con = Connection.GetInstance();
        public FormStockDisposal()
        {
            InitializeComponent();
        }
        public FormStockDisposal(string DisandRe, string barcode, string proName, string actuality, string waredate, string abandonea) : this()
        {
            lblDisRe.Text = DisandRe;
            lblBarcode.Text = barcode;
            lblProductName.Text = proName;
            lblwaredate.Text = waredate;
            lblAbanEa.Text = abandonea;
        }

        public void LabeltxboxReflash()
        {
            txtBarcode.Text = null;
            lblBarcode.Text = null;
            lblProductName.Text = null;
            lblwaredate.Text = null;
            lblAbanEa.Text = null;
            txtBarcode.Focus();
        }
        /// <summary>
        /// 폐기 상품 인지 확인
        /// 남수인 
        /// 2018.01.25
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
           
            try
            {
                con.Open();
                var cmd = new SqlCommand("si_SelectStockDisposal", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                var sdr = cmd.ExecuteReader();
                if (!sdr.HasRows)
                {
                    MessageBox.Show("재고등록 상품이 아닙니다.");
                    LabeltxboxReflash();
                }
                else
                {
                    while (sdr.Read())
                    {
                        if (sdr["PS_abandon"].ToString() == "False")
                        {
                            MessageBox.Show("반납 상품 입니다.");
                            DisandRe = "반납 상품";
                        }
                        else
                        {
                            MessageBox.Show("폐기 상품 입니다.");
                            DisandRe = "폐기 상품";
                        }
                        barcode = sdr["barCode"].ToString();
                        proName = sdr["PS_productName"].ToString();
                        waredate = sdr["PS_warehousingDay"].ToString();
                        actuality = sdr["PS_actuality"].ToString();
                    }
                    FormAbandon fad = new FormAbandon(DisandRe,barcode, proName, actuality, waredate);
                    fad.Show();
                    this.Close();
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("바코드를 입력해주세요");
                con.Close();
            }
            
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("폐기/반납 하시겠습니까?", "페기/반납 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                con.Open();
                var cmd = new SqlCommand("si_insertAbandon", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@barCode", lblBarcode.Text.Trim());
                cmd.Parameters.AddWithValue("@productName", lblProductName.Text.Trim());
                cmd.Parameters.AddWithValue("@waredate", DateTime.Parse(lblwaredate.Text));
                cmd.Parameters.AddWithValue("@abandondate", DateTime.Now);
                cmd.Parameters.AddWithValue("@abandonEa", int.Parse(lblAbanEa.Text.Trim()));
                cmd.Parameters.AddWithValue("@DisReturn", DisReturn(lblDisRe.Text));
                cmd.ExecuteNonQuery();

                var cmd2 = new SqlCommand("si_UpdateStockAbandon", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@barCode", lblBarcode.Text.Trim());
                cmd2.Parameters.AddWithValue("@abandonEa", int.Parse(lblAbanEa.Text.Trim()));
                cmd2.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("완료 되었습니다.");
            }
            else
            {
                MessageBox.Show("취소 되었습니다.");
                LabeltxboxReflash();
            }   
           
        }
        private bool DisReturn(string dr)
        {
            if (dr == "반납 상품")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnReflash_Click(object sender, EventArgs e)
        {
            LabeltxboxReflash();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormStoreStock fss = new FormStoreStock();
            fss.Show();
            this.Close();
        }
        /// <summary>
        /// 바코드가 하나씩 찍힘으로 키다운 이벤트 이용하여 바코드 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {

            barcodeCount = barcodeCount + 1;
            for (int i = 0; i < barcodeCount; i++)
            {
                txtBarcode.Text = sender.ToString().Split(':')[1].Trim();
            }
        }
        /// <summary>
        ///  바코드 텍스트 창에 숫자와 백스페이스를 제외한 나머지를 바로 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))   
            {
                e.Handled = true;
            }
        }

        private void FormStockDisposal_Load(object sender, EventArgs e)
        {
            timeStart();
            con.Open();
           
            string query = "select a.barCode as 바코드,a.productName as '상품 명',s.SP_productPrice as 금액,a.abandonEa as 폐기갯수 from dbo.CVS_Supplier s inner join dbo.CVS_Abandon a on s.barCode = a.barCode";
            var stockpricecmd = new SqlCommand(query, con);
            var stockpricesdr = stockpricecmd.ExecuteReader();
            if (stockpricesdr.HasRows)
            {
                while (stockpricesdr.Read())
                {
                    allAbandonPrice += (int)stockpricesdr["금액"] * (int)stockpricesdr["폐기갯수"];
                    DisposalCount += 1; 
                }
                lblDisposalEa.Text = DisposalCount.ToString() + "개";
                lblMorePrice.Text = allAbandonPrice.ToString() + "원";
            }
            con.Close();
        }
        public void timeStart()
        {
            lbltime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            Invoke((MethodInvoker)delegate
            {
                lbltime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            });
        }
    }
}
