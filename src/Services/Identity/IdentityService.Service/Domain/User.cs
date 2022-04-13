using System;
namespace IdentityService.Application.Domain
{
    public class User
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
    }
}
