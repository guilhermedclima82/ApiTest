using EasyMemoryCache;
using Integration.Interfaces;
using Model;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class UserService : IUserServices
    {
        private readonly IUserClient _userClient;
        private readonly ICaching _caching;
        private string UserKeyCache => "UserService";
        public UserService(IUserClient userClient, ICaching caching)
        {
            _userClient = userClient;
            _caching = caching;
        }
        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await _caching.GetOrSetObjectFromCacheAsync(UserKeyCache, 20, GetUsers);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> GetUsersByIdAsync(int Id)
        {
            try
            {
                var objUsers = await _caching.GetOrSetObjectFromCacheAsync(UserKeyCache, 20, GetUsers);
                return objUsers.FirstOrDefault(s => s.Id == Id);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        private async Task<List<User>> GetUsers()
        {
            return await _userClient.GetUsersAsync();
        }
    }
}
