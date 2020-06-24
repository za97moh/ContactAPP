using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Conntact_App
{
    class contactClass
    {
        public int ContactID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string ContactNO { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        //static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        public string conString = "Data Source=DESKTOP-B8TG6GO\\SQLEXPRESS;Initial Catalog=Econtact;Integrated Security=True";
        public DataTable Select()
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
            SqlConnection conn = new SqlConnection(conString);
            DataTable dt = new DataTable(); 
            try
            {
                string sql = "SELECT * FROM tbl_contact";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        //insert data into database
        public bool insert(contactClass c)
        {
            //var  connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
            
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                string sql = "INSERT INTO tbl_contact(FirstName,LastName,ContactNO,Address,Gender) VALUES (@FirstName,@LastName,@ContactNO,@Address,@Gender)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNO", c.ContactNO);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                conn.Open();
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                   isSuccess = true;
                }
                else
                {
                   isSuccess = true;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public bool Update(contactClass c)
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                string sql = "UPDATE tbl_contact SET FirstName=@FirstName,LastName=@LastName,ContactNO=@ContactNO,Address=@Address,Gender=@Gender WHERE ContactID=@ContactID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNO", c.ContactNO);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                conn.Open();
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public bool Delete(contactClass c)
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                string sql = "DELETE FROM tbl_contact WHERE ContactID=@ContactID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                conn.Open();
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

    }
}