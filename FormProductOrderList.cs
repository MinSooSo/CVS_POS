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
    public partial class FormProductOrderList : Form
    {
        private DataSet Data;
        private SqlConnection con = Connection.GetInstance();
        public FormProductOrderList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 발주 신청 목록 폼 로드시 데이터 로드
        /// 2018.01.19 남수인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormProductOrderList_Load(object sender, EventArgs e)
        {
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("si_JoinSupAndProdO", con);
            Data = new DataSet();
            adapter.Fill(Data);

            string[] str = { "바코드", "상품 명", "상품 가격 : 단위(\\)", "발주 수량" };
            dgvProdOrderList.ColumnCount = 4;
            for (int i = 0; i < dgvProdOrderList.ColumnCount; i++)
            {
                dgvProdOrderList.Columns[i].HeaderText = str[i];
                dgvProdOrderList.Columns[i].Width = 140;
            }

            DataTable table = Data.Tables[0];
            DataRowCollection rows = table.Rows;
            foreach (DataRow item in rows)
            {
                dgvProdOrderList.Rows.Add(item["바코드"], item["상품 명"], item["상품 가격"], item["발주 수량"]);
            }
            con.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
