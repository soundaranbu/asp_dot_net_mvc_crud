using ASPMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ASPMVC.Manager
{
    public class UserManager
    {
        public static UserManager Instance = new UserManager();

        public List<User> GetAllUsers()
        {
            List<User> Users = new List<User>();
            try
            {
                DataBase.Instance.Connection.Open();
                SqlCommand cmd = new SqlCommand(@"select * from users", DataBase.Instance.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToInt64(reader["id"]);
                    user.UserName = Convert.ToString(reader["username"]);
                    user.FullName = Convert.ToString(reader["fullname"]);
                    user.Mobile = Convert.ToInt64(reader["mobile"]);
                    user.Email = Convert.ToString(reader["email"]);
                    user.TimeCreated = Convert.ToInt64(reader["timecreated"]);
                    user.TimeModified = Convert.ToInt64(reader["timemodified"]);

                    Users.Add(user);
                }
            }
            catch(Exception e)
            {
                
            }
            finally
            {
                DataBase.Instance.Connection.Close();
            }
            return Users;            
        }

        public User GetUserById(long id)
        {
            User user = new User();
            try
            {
                DataBase.Instance.Connection.Open();
                String sql = @"select * from users where id = @Userid";
                SqlParameter param = new SqlParameter();
                SqlCommand cmd = new SqlCommand(sql, DataBase.Instance.Connection);
                cmd.Parameters.AddWithValue("@Userid", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.Id = Convert.ToInt64(reader["id"]);
                        user.UserName = Convert.ToString(reader["username"]);
                        user.FullName = Convert.ToString(reader["fullname"]);
                        user.Email = Convert.ToString(reader["email"]);
                        user.Mobile = Convert.ToInt64(reader["mobile"]);
                        user.TimeCreated = Convert.ToInt64(reader["timecreated"]);
                        user.TimeModified = Convert.ToInt64(reader["timemodified"]);
                    }
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                DataBase.Instance.Connection.Close();
            }
            return user;
        }

        public bool UpdateOrCreateUser(User user)
        {
            int status = 0;
            try
            {
                DataBase.Instance.Connection.Open();
                string sql = "";
                if(user.Id > 0)
                {
                    sql = @"UPDATE users 
                            SET username = @UserName, fullname = @FullName, email = @Email, mobile = @Mobile, timemodified = @TimeModified 
                            WHERE id = @UserId";
                }
                else
                {
                    sql = @"INSERT INTO users (username, fullname, email, mobile, timecreated, timemodified) 
                                 VALUES (@UserName, @FullName, @Email, @Mobile, @TimeCreated, @TimeModified)"; 
                }

                SqlCommand cmd = new SqlCommand(sql, DataBase.Instance.Connection);
                cmd.Parameters.AddWithValue("@UserId", user.Id);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Mobile", user.Mobile);

                long unixtime = Convert.ToInt64(DateTimeOffset.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                cmd.Parameters.AddWithValue("@TimeCreated", unixtime);
                cmd.Parameters.AddWithValue("@TimeModified", unixtime);

                status = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {

            }
            finally
            {
                DataBase.Instance.Connection.Close();
            }

            return status > 0 ? true : false;
        } 

        public bool DeleteUserById(long id)
        {
            int status = 0;
            if(id > 0)
            {
                try
                {
                    DataBase.Instance.Connection.Open();
                    string sql = @"DELETE FROM users WHERE id = @UserId";
                    SqlCommand cmd = new SqlCommand(sql, DataBase.Instance.Connection);
                    cmd.Parameters.AddWithValue("@UserId", id);
                    status = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
                finally
                {
                    DataBase.Instance.Connection.Close();
                }
            }

            return status > 0 ? true : false;
        }
    }
}