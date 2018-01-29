using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSVPos
{
    public partial class FormAbandon : Form
    {
        FormStockDisposal fsd;
        private string DisandRe;
        private string barcode;
        private string proName;
        private string actuality;
        private string waredate;
        public FormAbandon()
        {
            InitializeComponent();
        }
        public FormAbandon(string DisandRe,string barcode, string proName, string actuality, string waredate) : this()
        {
            this.DisandRe = DisandRe;
            this.barcode = barcode;
            this.proName = proName;
            this.actuality = actuality;
            this.waredate = waredate;
        }
        private void FormAbandon_Load(object sender, EventArgs e)
        {
            lblDisandRe.Text = DisandRe;
            lblbarCode.Text = barcode;
            lblproname.Text = proName;
            lblActEa.Text = actuality;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (int.Parse(actuality) < int.Parse(txtabandonea.Text))
            {
                MessageBox.Show("재고량 보다 많습니다.");
                txtabandonea.Text = null;
                txtabandonea.Focus();
            }
            else
            {
                string ea = txtabandonea.Text;
                fsd = new FormStockDisposal(DisandRe,barcode, proName, actuality, waredate, ea);
                fsd.Show();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            fsd = new FormStockDisposal();
            fsd.Show();
            this.Close();
        }
    }
}
