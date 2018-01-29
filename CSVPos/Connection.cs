using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CSVPos
{
    class Connection
    {
        private static SqlConnection sqlcon;
        private Connection()
        {

        }
        public static SqlConnection GetInstance()
        {
            if (sqlcon == null)
            {
                sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CVS_POS"].ConnectionString);
            }
            return sqlcon;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 11b071ab2186251cd137529d3214724db9fe8c53
