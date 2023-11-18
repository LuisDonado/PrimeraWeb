using Microsoft.Data.SqlClient;
using PrimeraWeb.Models;
using System.Data;

namespace PrimeraWeb.Consultas
{
	public class UserConsulta
	{

		private readonly IConfiguration configuration;

		private string conn;

		public UserConsulta(IConfiguration configuration)
		{
			conn = configuration.GetConnectionString("SupermarketDb");
		}

		public IEnumerable<User> GetByValue(string value)
		{
			var userList = new List<User>();
			string email = value;
			using (var connection = new SqlConnection(conn))
			using (var command = new SqlCommand())
			{
				connection.Open();
				command.Connection = connection;
				command.CommandText = @"SELECT * FROM Users
                                        WHERE Email LIKE @name+ '%'";
				command.Parameters.Add("@name", SqlDbType.NVarChar).Value = email;
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var user = new User();
						user.Email = reader["Email"].ToString();
						user.Password = reader["Password"].ToString();
						userList.Add(user);
					}
				}

			}
			return userList;

		}
	}
}
