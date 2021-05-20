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
    public class PhotosService : IPhotosService
    {
        private readonly IPhotosClient _photosClient;
        private readonly ICaching _caching;
        private string PhotoKeyCache => "PhotoService";

        public PhotosService(IPhotosClient photoClient, ICaching caching)
        {
            _photosClient = photoClient;
            _caching = caching;
        }

        public async Task<List<Photo>> GetPhotosAsync()
        {
            try
            {
                return await _caching.GetOrSetObjectFromCacheAsync(PhotoKeyCache, 20, GetPhotos);
            }
            catch (Exception)
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<List<Photo>> GetPhotos()
        {
            return await _photosClient.GetPhotosAsync();
        }
    }
}