using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : Controller
    {
        private readonly ILogger<AlbumsController> _logger;
        private readonly IAlbumsService _albumsService;
        public AlbumsController(ILogger<AlbumsController> logger, IAlbumsService albumsService)
        {
            _logger = logger;
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
    }
}
