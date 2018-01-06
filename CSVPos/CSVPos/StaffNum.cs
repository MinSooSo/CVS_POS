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
    public partial class StaffNum : Form
    {
        private string formname;

        public string Formname { get => formname; set => formname = value; }

        public StaffNum()
        {
            InitializeComponent();
        }

        private void StaffNum_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 유입된 경로를 확인하고, 아이디를 확인하는 화면입니다.
            // textbox.text 는 DB에서 사원번호를 꺼내오면 됩니다. 
            if(Formname == "sell" && textBox1.Text == "00")
            {
                this.Close();
                SellMonitor sm = new SellMonitor();
                sm.Show();
                
            }
            else if (Formname == "store" && textBox1.Text == "00")
            {
                this.Close();
                StoreM sm = new StoreM();
                sm.Show();
                
            }
            // 재고 관리 미구현 
            //else if (Formname == "sell" && textBox1.Text == "00")
            //{
            //    this.Close();
            //    SellMonitor sm = new SellMonitor();
            //    sm.Show();
            //}
            else
            {
                MessageBox.Show("정상적인 접근 방법이 아니거나, 사원 번호가 올바르지 않습니다","오류",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
    }
}
