using InventarioConSistemaDePrestamos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data.SqlClient;

namespace InventarioConSistemaDePrestamos.BD
{
    internal class BD
    {
        private readonly string _connection; 

        public string Connection => _connection;


        public BD()
        {
            _connection = @"Server=DESKTOP-HA4P84J\\SQLEXPRESS; Database=DB_Users; Trusted_Conecction=true";
        }

        internal ObservableCollection<UserModel> GetUsers()
        {
            ObservableCollection<UserModel> lstResult = new ObservableCollection<UserModel>();
            string query = "SELECT FROM * users";

            using (SqlConnection cn = new SqlConnection(Connection))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lstResult.Add(new UserModel()
                    {
                        Id = (string)reader["ID_user"],
                        Firstname = (string)reader["FIRSTNAME_user"],
                        Lastname = (string)reader["LASTNAME_user"],
                        Email = (string)reader["EMAIL_user"]
                    });
                }
                reader.Close();
                cn.Close();
            }
            return lstResult;
        }

        internal void AddUser(UserModel user)
        {
            string query = "INSERT INTO users VALUES (@id, @firstname, @lastname, @email)";
            using (SqlConnection cn = new SqlConnection(Connection))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@firstname", user.Firstname);
                cmd.Parameters.AddWithValue("@lastname", user.Lastname);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        internal void DeleteUser(UserModel user)
        {
            string query = "DELETE FROM users WHERE ID_user = @id";
            using (SqlConnection cn = new SqlConnection(Connection))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        internal void Edit(UserModel user)
        {
            string query = "UPDATE users SET ID_user = @id, FIRSTNAME_user = @firstname, LASTNAME_user = @lastname, EMAIL_user = @email";
            using (SqlConnection cn = new SqlConnection(Connection))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@firstname", user.Firstname);
                cmd.Parameters.AddWithValue("@lastname", user.Lastname);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
