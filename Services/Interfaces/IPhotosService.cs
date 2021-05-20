using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPhotosService
    {
        Task<List<Photo>> GetPhotosAsync();

        Task<Photo> GetPhotosByIdAsync(int Id);

        Task<Photo> GetPhotosByAlbumIdAsync(int AlbumId);
    }
}