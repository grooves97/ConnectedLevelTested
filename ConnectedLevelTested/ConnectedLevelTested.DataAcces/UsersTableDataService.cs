using System;
using ConnectedLevelTested.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConnectedLevelTested.DataAcces
{
    public class UsersTableDataService
    {

        readonly string _connectionString;

        public UsersTableDataService()
        {
            _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\НурсеитовА.CORP.000\Source\Repos\ConnectedLevelTested\ConnectedLevelTested\ConnectedLevelTested.DataAcces\Database.mdf;Integrated Security=True";
        }

        public List<User> GetAll()
        {
            var data = new List<User>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = "select* from Users";

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["Id"];
                        string login = dataReader["Login"].ToString();
                        string password = dataReader["Password"].ToString();

                        data.Add(new User
                        {
                            Id = id,
                            Login = login,
                            Password = password
                        });
                    }
                    dataReader.Close();
                }
                catch (SqlException exception)
                {//TODO
                    throw;
                }
                catch (Exception exception)
                {//TODO
                    throw;
                }

            }
            return data;
        }

        public void Add(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = $"insert into Users values('{user.Login}','{user.Password}')";

                    var affectedRows = command.ExecuteNonQuery();
                    if (affectedRows < 1) throw new Exception("No rows affected");
                }
                catch (SqlException exception)
                {//TODO
                    throw;
                }
                catch (Exception exception)
                {//TODO
                    throw;
                }
            }
        }

        public void DeleteById(int id)
        {

        }

        public void Update(User user)
        {

        }
    }
}
