using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integration.Interfaces
{
    public interface IPhotosClient
    {
        Task<List<Photo>> GetPhotosAsync();
    }
}