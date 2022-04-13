using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Attendance.Application.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Attendance.Application.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        //private readonly string dbconnection = "Server=localhost;Port=5432;Database=ArbeitzeitDb;User Id=admin;Password=admin1234";
        private readonly IConfiguration _configuration;
        public AttendanceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CreateAttendanceIn(int employeeId)
        {
            try
            {
                using var connection = new NpgsqlConnection(_configuration.GetSection("DatabaseSettings:ConnectionString").Value);

                string commandText = $"INSERT INTO Attendance(EmployeeId, EntryDate, TimeIn, TimeOut) VALUES('{employeeId}', now(), current_timestamp, NULL)";

                var isInserted = await connection.ExecuteAsync(commandText);

                return isInserted == 0 ? false : true;
            }
            catch (Exception ex)
            {
                //Logg exception
                return false;
            }

        }

        public async Task<bool> UpdateAttendanceOut(int employeeId)
        {
            try
            {
                using var connection = new NpgsqlConnection(_configuration.GetSection("DatabaseSettings:ConnectionString").Value);

                var commandText = $"UPDATE attendance SET timeout = current_timestamp WHERE employeeId = '{employeeId}'";

                var isUpdated = await connection.ExecuteAsync(commandText);

                return isUpdated == 0 ? false : true;

            }
            catch (Exception ex)
            {
                //Logg exception
                return false;
            }
        }

        public async Task<IEnumerable<EmployeeAttendance>> GetMonthlyAttendance(int employeeId)
        {
            try
            {
                using var connection = new NpgsqlConnection(_configuration.GetSection("DatabaseSettings:ConnectionString").Value);

                string commandText = $"select * from attendance where entrydate >= date_trunc('month', current_timestamp) and entrydate<date_trunc('month', current_timestamp) +interval '1 month' and employeeId = '{employeeId}'";

                return await connection.QueryAsync<EmployeeAttendance>(commandText);

            }
            catch (Exception ex)
            {
                //Logg exception
                return null;
            }

        }
    }
}
