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
    public class AlbumsService : IAlbumsService
    {
        private readonly IAlbumsClient _albumsClient;
        private readonly ICaching _caching;
        private readonly ILogger<AlbumsService> _logger;

        private string AlbumsKeyCache => "AlbumService";

        public AlbumsService(IAlbumsClient albumsClient, ICaching caching, ILogger<AlbumsService> logger)
        {
            _albumsClient = albumsClient;
            _caching = caching;
            _logger = logger;
        }

        public async Task<List<Album>> GetAlbumsAsync()
        {
            try
            {
                return await _caching.GetOrSetObjectFromCacheAsync(AlbumsKeyCache, 20, GetAlbums);
            }
            catch (Exception err)
            {
                logger(err.Message);
                throw;
            }
        }

        public async Task<Album> GetAlbumsByIdAsync(int Id)
        {
            try
            {
                var objAlbums = await _caching.GetOrSetObjectFromCacheAsync(AlbumsKeyCache, 20, GetAlbums);
                return objAlbums.FirstOrDefault(s => s.Id == Id);
            }
            catch (Exception err)
            {
                logger(err.Message);
                throw;
            }
        }

        public async Task<Album> GetAlbumsByUserIdAsync(int UserId)
        {
            try
            {
                var objAlbums = await _caching.GetOrSetObjectFromCacheAsync(AlbumsKeyCache, 20, GetAlbums);
                return objAlbums.FirstOrDefault(s => s.UserId == UserId);
            }
            catch (Exception err)
            {
                logger(err.Message);
                throw;
            }
        }

        private async Task<List<Album>> GetAlbums()
        {
            return await _albumsClient.GetAlbumsAsync();
        }

        private void logger(string Error)
        {
            _logger.LogInformation(Error);
        }
    }
}