using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService _albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            _albumsService = albumsService;
        }

        [HttpGet]
        [Route("GetAlbums")]
        public JsonResult Get()
        {
            var ret = _albumsService.GetAlbumsAsync();
            return Json(ret.Result);
        }

        [HttpGet]
        [Route("GetAlbumsById")]
        public JsonResult GetById(int Id)
        {
            var ret = _albumsService.GetAlbumsByIdAsync(Id);
            return Json(ret.Result);
        }

        [HttpGet]
        [Route("GetAlbumsByUserId")]
        public JsonResult GetAlbumsByUserId(int UserId)
        {
            var ret = _albumsService.GetAlbumsByUserIdAsync(UserId);
            return Json(ret.Result);
        }
    }
}