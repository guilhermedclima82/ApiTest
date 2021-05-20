using EasyMemoryCache;
using Integration.Interfaces;
using Microsoft.Extensions.Logging;
using Model;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class UserService : IUserServices
    {
        private readonly IUserClient _userClient;
        private readonly ICaching _caching;
        private readonly ILogger<IUserClient> _logger;
        private string UserKeyCache => "UserService";

        public UserService(IUserClient userClient, ICaching caching, ILogger<IUserClient> logger)
        {
            _userClient = userClient;
            _caching = caching;
            _userClient = userClient;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                var ret = await _caching.GetOrSetObjectFromCacheAsync(UserKeyCache, 20, GetUsers);
                return ret.Take(500).ToList();
            }
            catch (Exception err)
            {
                logger(err.Message);
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
            catch (Exception err)
            {
                logger(err.Message);
                throw;
            }
        }

        private async Task<List<User>> GetUsers()
        {
            return await _userClient.GetUsersAsync();
        }

        private void logger(string Error)
        {
            _logger.LogInformation(Error);
        }
    }
}