using EasyMemoryCache;
using Integration.Interfaces;
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
        private string AlbumsKeyCache => "AlbumService";

        public AlbumsService(IAlbumsClient albumsClient, ICaching caching)
        {
            _albumsClient = albumsClient;
            _caching = caching;
        }

        public async Task<List<Album>> GetAlbumsAsync()
        {
            try
            {
                return await _caching.GetOrSetObjectFromCacheAsync(AlbumsKeyCache, 20, GetAlbums);
            }
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<List<Album>> GetAlbums()
        {
            return await _albumsClient.GetAlbumsAsync();
        }
    }
}