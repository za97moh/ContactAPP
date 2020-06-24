using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conntact_App
{
    class D
    {
        public int ContactID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string ContactNO { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        //var connectionString = ConfigurationManager.ConnectionStrings["WingtipToys"].ConnectionString; 
        public DataTable Select()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["WingtipToys"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM tbl_contact";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //conn.Open();
                //adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
               // conn.Close();
            }
            return dt;
        }

    }
}
