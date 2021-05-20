using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAlbumsService
    {
        Task<List<Album>> GetAlbumsAsync();

        Task<Album> GetAlbumsByIdAsync(int Id);

        Task<List<Album>> GetAlbumsByUserIdAsync(int UserId);
    }
}