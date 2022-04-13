using System;
using System.Threading.Tasks;
using Dapper;
using IdentityService.Application.Domain;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace IdentityService.Application.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        //private readonly string daConnection = "Server=localhost;Port=5432;Database=ArbeitzeitDb;User Id=admin;Password=admin1234";
        private readonly IConfiguration _configuration;
        public LoginRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<User> CheckIfValidUserAsync(string userid, string password)
        {
            try
            {
                using var connection = new NpgsqlConnection(_configuration.GetSection("DatabaseSettings:ConnectionString").Value);
                string commandText = $"SELECT * FROM users WHERE loginid='{userid}' and password ='{password}'";
                var user = await connection.QueryFirstOrDefaultAsync<User>(commandText);

                return user;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> CreateLogAsync(int employeeId)
        {
            try
            {
                using var connection = new NpgsqlConnection(_configuration.GetSection("DatabaseSettings:ConnectionString").Value);
                string commandText = $"INSERT INTO userlog (employeeId, logintime) VALUES('{employeeId}',current_timestamp)";
                var isInserted = await connection.ExecuteAsync(commandText);

                return isInserted == 0 ? false : true;
            }
            catch
            {
                return false;
            }
           
        }

    }
}
