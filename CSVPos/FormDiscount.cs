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
    public partial class FormDiscount : Form
    {
        public FormDiscount()
        {
            InitializeComponent();
        }

        private void btnGiftiOn_Click(object sender, EventArgs e)
        {
            // 누른 버튼이 무엇인지 가져와서
            Button btn = (Button)sender;
            BtnOnOff(gboxGifti, btn);
        }

        private void btnTele_Click(object sender, EventArgs e)
        {
            // 누른 버튼이 무엇인지 가져와서
            Button btn = (Button)sender;
            BtnOnOff(gboxTele, btn);
        }

        /// <summary>
        /// 버튼 눌렀을 때 다른 버튼들 비활성화 하는 메서드
        /// </summary>
        /// <param name="gbox">누른 버튼을 감싸고 있는 그룹박스</param>
        /// <param name="btn">누른 버튼</param>
        public void BtnOnOff(GroupBox gbox, Button btn)
        {
            //MessageBox.Show(btn.Text);

            // 기프티콘 사용여부 그룹박스의 버튼들 중에 누른 버튼을 제외한 버튼 Enable = false;
            foreach (var item in gbox.Controls)
            {
                Button btns = (Button)item;
                if (btns.Text == btn.Text)
                {
                    btns.Enabled = false;
                }
                else
                {
                    btns.Enabled = true;
                }
            }
        }
    }
}
