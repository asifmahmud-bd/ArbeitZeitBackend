using System.Threading.Tasks;
using IdentityService.Application.Domain;

namespace IdentityService.Application.Repositories
{
    public interface ILoginRepository
    {
        Task<bool> CreateLogAsync(int employeeId);
        Task<User> CheckIfValidUserAsync(string username, string password);
    }
}
