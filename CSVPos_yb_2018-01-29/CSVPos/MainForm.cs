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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // 판매 관리 버튼 
        {
            StaffNum sn = new StaffNum();
            sn.Formname = "sellMonitor";
            sn.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e) // 재고 관리 버튼 
        {
            //FormStoreStock fss = new FormStoreStock();
            //fss.Show();
            
            StaffNum sn = new StaffNum();
            sn.Formname = "stockManagement";
            sn.Show();
        }

        private void btnStore_Click(object sender, EventArgs e) // 매장 관리 버튼 
        {
            StaffNum sn = new StaffNum();
            sn.Formname = "store";
            sn.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 CVS_POS를 종료하시겠습니까?","POS 종료 확인",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("POS 종료가 취소 되었습니다","POS 종료 취소");
                return;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            HelpInfo hi = new HelpInfo();
            hi.Show();
        }
    }
}
