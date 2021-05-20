using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoController : Controller
    {
        private readonly IPhotosService _photosServices;

        public PhotoController(IPhotosService photosServices)
        {
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