using Notice.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notice.DAL
{
    public class DataAcess
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public List<aNotice> GetNoticesData()
        {
            /*
            List<Author> authors = new List<Author>
                {
                    new Author { Name = "Mahesh Chand", Book = "Apress", Price = 49.95 },
                    new Author { Name = "Neel Beniwal", Book = "Apress", Price = 19.95 },
                    new Author { Name = "Chris Love", Book = "PakT", Price = 29.95 }
                };
            */
            return null;

        }
        public List<Admin> GetAdmins()
        {

            var objStu = new Admin();
            List<Admin> resut = new List<Admin>();


            string query = string.Format("Select * From Admin");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Admin obj = new Admin();

                    obj.Name = "worked";
    
                    resut.Add(obj);

                }
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();

            return resut;
        }

    
    public List<Categories> GetCategories()
        {

            var objStu = new Categories();
            List<Categories> resut = new List<Categories>();


            string query = string.Format("Select * From Categories");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Categories obj = new Categories
                    {
                        ID = Convert.ToInt32(dataReader["CategoryID"].ToString()),
                        name = dataReader["CategoryName"].ToString()
                    };
                    resut.Add(obj);

                }
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();

            return resut;
        }

        public void InsertCategory(Categories obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Categories(CategoryName) VALUES(@name)";

                    command.Parameters.AddWithValue("@name", obj.name);
                    command.ExecuteNonQuery();
                }
            }

        }
        public void UpdateCategory(Categories obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Update  Categories SET CategoryName=@name where CategoryID";

                    command.Parameters.AddWithValue("@name", obj.name);
                    command.ExecuteNonQuery();
                }
            }

        }
        public void InsertAdmin(Admin obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Admin (Name,Surname,Email,Password,DepartID,Cellphone) VALUES(@n,@s,@e,@p,@d,@c)";

                    command.Parameters.AddWithValue("@n", obj.Name);
                    command.Parameters.AddWithValue("@s", obj.Surname);
                    command.Parameters.AddWithValue("@e", obj.Email);
                    command.Parameters.AddWithValue("@p", obj.Password);
                    command.Parameters.AddWithValue("@d", obj.DepartID);
                    command.Parameters.AddWithValue("@c", obj.Cellphone);
                    command.ExecuteNonQuery();
                }
            }

        }
        public void UpdateAdmin(Admin obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Update  Admin set Name=@n,Surname=@s,Email=@e Password=@p,DepartID=@d,Cellphone=@c  where AdminID=@id";

                    command.Parameters.AddWithValue("@n", obj.Name);
                    command.Parameters.AddWithValue("@s", obj.Surname);
                    command.Parameters.AddWithValue("@e", obj.Email);
                    command.Parameters.AddWithValue("@p", obj.Password);
                    command.Parameters.AddWithValue("@d", obj.DepartID);
                    command.Parameters.AddWithValue("@c", obj.Cellphone);
                    command.Parameters.AddWithValue("@id", obj.AdminID);
                    command.ExecuteNonQuery();
                }
            }

        }
        public void InsertNotice(aNotice obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Notices(DateAndTime_p,DateAndTime_Expire,DateAndTime_Show,Title,Description,CategoryID,AdminID,Picture,HasImage) VALUES(@dp,@de,@ds,@t,@d,@c,@a,@p,@h)";
                    //VALUES(@dp,@de,@ds,@t,@d,@c,@a,@p,@h)";

                    command.Parameters.AddWithValue("@dp", obj.DateAndTime_p);
                    command.Parameters.AddWithValue("@de", obj.DateAndTime_Expire);
                    command.Parameters.AddWithValue("@ds", obj.DateAndTime_Show);
                    command.Parameters.AddWithValue("@t", obj.Title);
                    command.Parameters.AddWithValue("@d", obj.Description);
                    command.Parameters.AddWithValue("@c", obj.CategoryID);
                    command.Parameters.AddWithValue("@a", obj.AdminID);
                    command.Parameters.AddWithValue("@p", obj.Picture);
                    command.Parameters.AddWithValue("@h", obj.HasImage);


                    command.ExecuteNonQuery();
                }
            }

        }

        public void UpdateNotice(aNotice obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Update Notices set DateAndTime_Expire=@de,DateAndTime_Show=@ds,Title=@t,Description=@d,CategoryID=@c,AdminID=@a,Picture=@p,HasImage=@h where NoticeID=@id";
                    //VALUES(@dp,@de,@ds,@t,@d,@c,@a,@p,@h)";

                    command.Parameters.AddWithValue("@dp", obj.DateAndTime_p);
                    command.Parameters.AddWithValue("@de", obj.DateAndTime_Expire);
                    command.Parameters.AddWithValue("@ds", obj.DateAndTime_Show);
                    command.Parameters.AddWithValue("@t", obj.Title);
                    command.Parameters.AddWithValue("@d", obj.Description);
                    command.Parameters.AddWithValue("@c", obj.CategoryID);
                    command.Parameters.AddWithValue("@a", obj.AdminID);
                    command.Parameters.AddWithValue("@p", obj.Picture);
                    command.Parameters.AddWithValue("@h", obj.HasImage);
                    command.Parameters.AddWithValue("@id", obj.NoticeID);
                    command.ExecuteNonQuery();
                }
            }

        }
    }
}
