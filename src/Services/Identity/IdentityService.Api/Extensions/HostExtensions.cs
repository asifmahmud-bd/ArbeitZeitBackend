using System;
using Dapper;
using IdentityService.Api.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace IdentityService.Api.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
        {
            using (var scop = host.Services.CreateScope())
            {
                var service = scop.ServiceProvider;
                var configuration = service.GetRequiredService<IConfiguration>();

                var logger = service.GetRequiredService<ILogger<TContext>>();

                try
                {
                    logger.LogInformation("Migrating User Table to postgresql");

                    using var connection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                    connection.Open();

                    using var command = new NpgsqlCommand
                    {
                        Connection = connection
                    };

                    //TODO: Users
                    //command.CommandText = "DROP TABLE IF EXISTS Users";
                    //command.ExecuteNonQuery();

                    //command.CommandText = @"CREATE TABLE Users(Id SERIAL PRIMARY KEY,
                    //                                          EmployeeId VARCHAR(24) NOT NULL,
                    //                                          FirstName VARCHAR(24) NULL,
                    //                                          LastName VARCHAR(24) NULL,
                    //                                          LoginId VARCHAR(24) NOT NULL,
                    //                                          Password VARCHAR(24) NOT NULL)";
                    //command.ExecuteNonQuery();

                    //command.CommandText = "INSERT INTO Users(EmployeeId, FirstName, LastName, LoginId, Password)VALUES('1234', 'FName 1', 'LName 1', 'user1', 'pass1')";
                    //command.CommandText = "INSERT INTO Users(EmployeeId, FirstName, LastName, LoginId, Password)VALUES('2345', 'FName 2', 'LName 2', 'user2', 'pass2')";
                    //command.ExecuteNonQuery();

                    //logger.LogInformation("Migration done in PostgraySQL database");

                    ////TODO: Userlog
                    //command.CommandText = "DROP TABLE IF EXISTS Userlog";
                    //command.ExecuteNonQuery();

                    //command.CommandText = @"CREATE TABLE Userlog(Id SERIAL PRIMARY KEY,
                    //                                                EmployeeId VARCHAR(24) NOT NULL,
                    //                                                LoginTime TIMESTAMP NOT NULL)";
                    //command.ExecuteNonQuery();
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
