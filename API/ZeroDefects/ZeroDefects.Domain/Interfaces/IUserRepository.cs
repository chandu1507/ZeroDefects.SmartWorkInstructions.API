using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroDefects.Domain.Entities;

namespace ZeroDefects.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUsernAsync(string id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task<string?> DeleteUserAsync(string id);
        Task<User?> UpdateUserAsync(User user);

        Task<string> Authenticate(string username, string password);
    }
}
