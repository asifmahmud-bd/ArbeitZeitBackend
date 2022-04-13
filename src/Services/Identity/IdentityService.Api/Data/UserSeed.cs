using System;
using System.Collections.Generic;
using IdentityService.Application.Domain;

namespace IdentityService.Api.Data
{
    public static class UserSeed
    {
        public static IEnumerable<User> GetPreconfigureUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    EmployeeId = 123,
                     FirstName ="FName 1",
                     LastName ="LName 1",
                     LoginId ="user1",
                     Password ="pass1"
                },

                new User()
                {
                     EmployeeId = 234,
                     FirstName ="FName 2",
                     LastName ="LName 2",
                     LoginId ="user2",
                     Password ="pass2"
                }

            };
        }
    }
}
