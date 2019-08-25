using Notice.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

namespace Notice.DAL
{
    public class DataAcess
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        ///catagories_____________________________________________________________________________________________________
        ///
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
                        Name = dataReader["CategoryName"].ToString(),
                        description = dataReader["CategoryDescription"].ToString()
                    };
                    resut.Add(obj);

                }
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();

            return resut;
        }

        public int InsertCategory(Categories obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Categories(CategoryName,CategoryDescription) VALUES(@Name,@description)";

                    command.Parameters.AddWithValue("@Name", obj.Name);
                    command.Parameters.AddWithValue("@description", obj.description);
                    command.ExecuteNonQuery();
                    return 1;
                }
            }
            

        }
   
        public string UpdateCategory(Categories obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Update  Categories SET CategoryName=@nm,CategoryDescription=@dec where CategoryID=@id";
                    command.Parameters.AddWithValue("@id", obj.ID);
                    command.Parameters.AddWithValue("@nm", obj.Name);
                    command.Parameters.AddWithValue("@dec", obj.description);
                    command.ExecuteNonQuery();
                    return "";
                }
            }

        }

        public void DeleteCategory(Categories ob)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand comm = connection.CreateCommand())
                {
                    comm.CommandText = "Delete from Categories where CategoryID=" + ob.ID;
                    comm.ExecuteNonQuery();
                }
            }
        }

        ///Admins_______________________________________________________________________________________________________
        ///
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
                    Admin obj = new Admin
                    {
                        AdminID = Convert.ToInt32(dataReader["AdminID"].ToString()),
                        Name = dataReader["Name"].ToString(),
                        Surname = dataReader["Surname"].ToString(),
                        Email = dataReader["Email"].ToString(),
                        Password = dataReader["Password"].ToString(),
                        DepartID = dataReader["DepartID"].ToString(),
                        Cellphone = dataReader["Cellphone"].ToString()
                    };
                    resut.Add(obj);

                }

            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();

            return resut;
        }


        public string InsertAdmin(Admin obj)
        {
            //Generate a random password
            string guid = Guid.NewGuid().ToString().Replace("-", "");
            obj.Password = guid.Substring(0, 8);
            var password = "";//Encrypt

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
                    try
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("leonlungelo@gmail.com");
                        mail.To.Add("leonlunge@gmail.com");
                        mail.To.Add(obj.Email);
                        mail.Subject = "Registration Successful";
                        mail.Body += " <html>";
                        mail.Body += "<body>";
                        mail.Body += "<table>";
                        mail.Body += "<tr>";
                        mail.Body += "<td>Dear "+obj.Name+" "+obj.Surname+"";
                        mail.Body += "</tr>";

                        mail.Body += "<tr>";
                        mail.Body += "<td>You have been successfully registered as the System Admin";
                        mail.Body += "</tr>";
                        mail.Body += "<tr>";
                        mail.Body += "<td>Your password is "+obj.Password + ". Change your password on log in.</td>";
                        mail.Body += "</tr>";
                        mail.Body += "<tr>";
                        mail.Body += "<td></td>";
                        mail.Body += "</tr>";
                        mail.Body += "<tr>";
                        mail.Body += "<td>Kind Regards,</td>";
                        mail.Body += "</tr>";
                        mail.Body += "<tr>";
                        mail.Body += "<td>Super Admin </td>";
                        mail.Body += "</tr>";
                        mail.Body += "</table>";
                        mail.Body += "</body>";
                        mail.Body += "</html>";
                        mail.IsBodyHtml = true;
                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("leonlungelo@gmail.com", "61342286");
                        SmtpServer.EnableSsl = true;
                        SmtpServer.Send(mail);
                        return "Admin Successfully Registered!!!";
                    }
                    catch
                    {
                        return "Please Check your Internet Connection,There are services that require internet connection";
                    }
                   
                }

            }

        }

        int i = 0;
        public string UpdateAdmin(Admin obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Update  Admin set Name=@n,Surname=@s,Email=@e,Password=@p,DepartID=@d,Cellphone=@c  where AdminID=@id";

                    command.Parameters.AddWithValue("@id", obj.AdminID);
                    command.Parameters.AddWithValue("@n", obj.Name);
                    command.Parameters.AddWithValue("@s", obj.Surname);
                    command.Parameters.AddWithValue("@e", obj.Email);
                    command.Parameters.AddWithValue("@p", obj.Password);
                    command.Parameters.AddWithValue("@d", obj.DepartID);
                    command.Parameters.AddWithValue("@c", obj.Cellphone);
                    
                    i = command.ExecuteNonQuery();
                    return "";
                }
            }
           

        }

        public void DeleteAdmin(Admin ad)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand comm = connection.CreateCommand())
                {
                    comm.CommandText = "Delete from Admins where AdminID=@AdminID";
                    comm.Parameters.AddWithValue("@AdminID", ad.AdminID);
                    comm.ExecuteNonQuery();
                }
            }
        }

        ///Notices_______________________________________________________________________________________________________
        ///

        public List<aNotice> GetNoticesData()
        {

            var objStu = new aNotice();
            List<aNotice> resut = new List<aNotice>();


            string query = string.Format("Select * From Notices");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    aNotice obj = new aNotice
                    {
                        NoticeID = Convert.ToInt32(dataReader["NoticeID"].ToString()),
                        DateAndTime_p = Convert.ToDateTime(dataReader["DateAndTime_p"].ToString()),
                        Title = dataReader["Title"].ToString(),
                        Description = dataReader["Description"].ToString()
                      

                    };
                    resut.Add(obj);

                }
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();

            return resut;

        }

       
        public List<aNotice> GetNoticeTitle()
        {
            
            var objStu = new aNotice();
            List<aNotice> resut = new List<aNotice>();
            

            string query = string.Format("Select * From Notices");
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    aNotice obj = new aNotice
                    {

                        Title = dataReader["Title"].ToString(),
                        Description = dataReader["Description"].ToString(),
                    };
                    resut.Add(obj);

                }
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();

            return resut;

        }






        //public void InsertNotice(aNotice obj)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        using (SqlCommand command = connection.CreateCommand())
        //        {
        //            command.CommandText = "INSERT INTO Notices(DateAndTime_p,DateAndTime_Expire,DateAndTime_Show,Title,Description,CategoryID,AdminID,Picture,HasImage) VALUES(@dp,@de,@ds,@t,@d,@c,@a,@p,@h)";
        //            //VALUES(@dp,@de,@ds,@t,@d,@c,@a,@p,@h)";

        //            command.Parameters.AddWithValue("@dp", obj.DateAndTime_p);
        //            command.Parameters.AddWithValue("@de", obj.DateAndTime_Expire);
        //            command.Parameters.AddWithValue("@ds", obj.DateAndTime_Show);
        //            command.Parameters.AddWithValue("@t", obj.Title);
        //            command.Parameters.AddWithValue("@d", obj.Description);
        //            command.Parameters.AddWithValue("@c", obj.CategoryID);
        //            command.Parameters.AddWithValue("@a", obj.AdminID);
        //            command.Parameters.AddWithValue("@p", obj.Picture);
        //            command.Parameters.AddWithValue("@h", obj.HasImage);


        //            command.ExecuteNonQuery();
        //        }
        //    }

        //}

        public string InsertNotice(aNotice obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Notices(DateAndTime_p,DateAndTime_Expire,DateAndTime_Show,Title,Description,CategoryID,AdminID,Picture,HasImage) VALUES(@dp,@de,@ds,@t,@d,@c,@a,@p,@h)";

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
                    return "";
                }
            }


        }


        public string UpdateNotice(aNotice obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Update Notices set DateAndTime_p=@dp,DateAndTime_Expire=@de,DateAndTime_Show=@ds,Title=@t,Description=@d,CategoryID=@c,AdminID=@a,Attachment=@p,HasImage=@h where NoticeID=@id";
                    //VALUES(@dp,@de,@ds,@t,@d,@c,@a,@p,@h)";
                    command.Parameters.AddWithValue("@id", obj.NoticeID);
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
                    return "";
                }
            }

        }

        public void DeleteNotice(aNotice ad)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand comm = connection.CreateCommand())
                {
                    comm.CommandText = "Delete ON Notices where NoticeID=@NoticeID";
                    comm.ExecuteNonQuery();
                }
            }
        }


        //Password Generator
        
        private int randomNumber(int min,int max)
        {
            Random ran = new Random();
            

            return ran.Next(min, max);
        }

        private string randomString(int length)
        {
            StringBuilder sb = new StringBuilder();
            Random ran = new Random();
            char value;
            for(int i = 0; i < length;i++)
            {
                value = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * ran.NextDouble() + 65)));
                sb.Append(value);

                
            }

            return sb.ToString();

        }
       


       
       

    }
}
