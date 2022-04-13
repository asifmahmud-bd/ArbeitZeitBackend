using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Attendance.Api.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
        {
            int retryValue = retry.Value;

            using (var scop = host.Services.CreateScope())
            {
                var service = scop.ServiceProvider;
                var configuration = service.GetRequiredService<IConfiguration>();
                var logger = service.GetRequiredService<ILogger<TContext>>();

                try
                {
                    logger.LogInformation("Migrating Attendence Table to postgresql");

                    using var connection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                    connection.Open();

                    using var command = new NpgsqlCommand
                    {
                        Connection = connection
                    };

                    ////TODO: Testing
                    //command.CommandText = "DROP TABLE IF EXISTS Attendance";
                    //command.ExecuteNonQuery();

                    //command.CommandText = @"CREATE TABLE Attendance(Id SERIAL PRIMARY KEY,
                    //                                                EmployeeId VARCHAR(24) NOT NULL,
                    //                                                EntryDate DATE NOT NULL,
                    //                                                TimeIn TIMESTAMP NULL,
                    //                                                TimeOut TIMESTAMP NULL)";
                    //command.ExecuteNonQuery();

                    //commandAtt.CommandText = "INSERT INTO Attendance(EmployeeId, EntryDate, TimeIn, TimeOut)VALUES('1234', now(), current_timestamp, current_timestamp)";
                    //commandAtt.ExecuteNonQuery();


                    //logger.LogInformation("Migrated PostgraySQL database");
                }
                catch (Exception ex)
                {
                    logger.LogInformation("Some Exception occured");
                    throw;
                }
            }

            return host;
        }
    }
}
