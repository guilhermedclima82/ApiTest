using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
