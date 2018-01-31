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
    public partial class checkLog : Form
    {
        public checkLog()
        {
            InitializeComponent();
        }

        private void btnSelectLog_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString);

            con.Open();

            using (var cmd = new SqlCommand("ms_selectLogPro", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand = cmd;
                DataSet dataset = new DataSet();
                sda.Fill(dataset);

                DataTable dt = dataset.Tables[0];
                dataGridView1.DataSource = dt;

                con.Close();
            }
        }
    }
}
