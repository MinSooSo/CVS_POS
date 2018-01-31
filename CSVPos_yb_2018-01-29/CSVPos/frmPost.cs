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
    public partial class frmPost : Form
    {
        public frmPost()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("택배 접수를 취소 하시겠습니까? ", "택배 접수 취소", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
           
        }

        private void frmPost_Load(object sender, EventArgs e)
        {
            textBox4.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void btnTakbaego_Click(object sender, EventArgs e)
        {
            // DB에 쿼리 날려주세요. 
            MessageBox.Show("택배 접수 성공적! ", "택배 접수 결과",MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
