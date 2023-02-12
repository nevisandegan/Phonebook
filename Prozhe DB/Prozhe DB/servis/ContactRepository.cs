using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Prozhe_DB
{
    class ContactRepository : IContactRepository
    {
        private string connectionstring = "Data Source=LAPTOP-1B6P4LNI;Initial catalog=porozhe db;Integrated security=true";
        public bool Delete(int contactid)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                string query = "Delete From Mycontact Where ContactID=@ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactid);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool insert(string name, string family, string mobile, string email)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                string query = "Insert Into Mycontact (Name,Family,Mobile,Email) values (@Name,@Family,@Mobile,@Email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable search(string parameter)
        {
            string query = "select * From Mycontact Where Name like @Parameter or Family like @Parameter";
            SqlConnection connection = new SqlConnection(connectionstring);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@Parameter", "%" + parameter + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll()
        {
            string query = "select * From Mycontact";
            SqlConnection connection = new SqlConnection(connectionstring);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int contactid)
        {
            string query = "select * From Mycontact Where ContactID=" + contactid;
            SqlConnection connection = new SqlConnection(connectionstring);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(int contactid, string name, string family, string mobile, string email)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                string query = "Update Mycontact Set Name=@Name,Family=@Family,Mobile=@Mobile,Email=@Email Where ContactID=@ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactid);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
