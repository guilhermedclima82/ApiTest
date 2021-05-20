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
    public class PhotosService : IPhotosService
    {
        private readonly IPhotosClient _photosClient;
        private readonly ICaching _caching;
        private readonly ILogger<PhotosService> _logger;
        private string PhotoKeyCache => "PhotoService";

        public PhotosService(IPhotosClient photoClient, ICaching caching, ILogger<PhotosService> logger)
        {
            _photosClient = photoClient;
            _caching = caching;
            _logger = logger;
        }

        public async Task<List<Photo>> GetPhotosAsync()
        {
            try
            {
                return await _caching.GetOrSetObjectFromCacheAsync(PhotoKeyCache, 20, GetPhotos);
            }
            catch (Exception err)
            {
                logger(err.Message);
                throw;
            }
        }

        public async Task<Photo> GetPhotosByIdAsync(int Id)
        {
            try
            {
                var objPhoto = await _caching.GetOrSetObjectFromCacheAsync(PhotoKeyCache, 20, GetPhotos);
                return objPhoto.FirstOrDefault(s => s.Id == Id);
            }
            catch (Exception err)
            {
                logger(err.Message);
                throw;
            }
        }

        public async Task<Photo> GetPhotosByAlbumIdAsync(int AlbumId)
        {
            try
            {
                var objPhoto = await _caching.GetOrSetObjectFromCacheAsync(PhotoKeyCache, 20, GetPhotos);
                return objPhoto.FirstOrDefault(s => s.AlbumId == AlbumId);
            }
            catch (Exception err)
            {
                logger(err.Message);
                throw;
            }
        }

        private async Task<List<Photo>> GetPhotos()
        {
            return await _photosClient.GetPhotosAsync();
        }

        private void logger(string Error)
        {
            _logger.LogInformation(Error);
        }
    }
}