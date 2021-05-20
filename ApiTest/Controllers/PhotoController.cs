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
    public class PhotoController : Controller
    {
        private readonly ILogger<PhotoController> _logger;
        private readonly IPhotosService _photosServices;
        public PhotoController(ILogger<PhotoController> logger, IPhotosService photosServices)
        {
            _logger = logger;
            _photosServices = photosServices;
        }
        [HttpGet]
        [Route("GetPhotos")]
        public JsonResult Get()
        {
            var ret = _photosServices.GetPhotosAsync();
            return Json(ret.Result);
        }
        [HttpGet]
        [Route("GetPhotosById")]
        public JsonResult GetById(int Id)
        {
            var ret = _photosServices.GetPhotosByIdAsync(Id);
            return Json(ret.Result);
        }
    }
}
