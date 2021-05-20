using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integration.Interfaces
{
    public interface IAlbumsClient
    {
        Task<List<Album>> GetAlbumsAsync();
    }
}