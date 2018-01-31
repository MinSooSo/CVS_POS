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
    public partial class FormHire : Form
    {
        public FormHire()
        {
            InitializeComponent();
        }

        private void FormHire_Load(object sender, EventArgs e)
        {
            label16.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("직원 등록을 취소하시겠습니까?", "직원 등록 취소", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("직원 등록이 계속 가능합니다.", "직원 등록 재개");
                return;
            }
        }

        private void btnDiscount_Click(object sender, EventArgs e) // 입력 화면 초기화 
        {
            // 다 비워주세요. 
        }

        private void btnHire_Click(object sender, EventArgs e) // 정보 입력 
        {
            // 서버로 INSERT 해주세요. 

        }
    }
}
