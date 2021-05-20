using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserServices
    {
        Task<List<User>> GetUsersAsync();

        Task<User> GetUsersByIdAsync(int Id);
    }
}