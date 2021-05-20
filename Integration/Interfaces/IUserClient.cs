using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integration.Interfaces
{
    public interface IUserClient
    {
        Task<List<User>> GetUsersAsync();
    }
}