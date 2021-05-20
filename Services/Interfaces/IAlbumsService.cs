using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAlbumsService
    {
        Task<List<Album>> GetAlbumsAsync();
        Task<Album> GetAlbumsByIdAsync(int Id);
        Task<Album> GetAlbumsByUserIdAsync(int UserId);
    }
}
