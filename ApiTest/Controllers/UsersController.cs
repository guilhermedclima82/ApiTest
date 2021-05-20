using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interfaces;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserServices _userService;

        public UsersController(ILogger<UsersController> logger, IUserServices userServices)
        {
            _logger = logger;
            _userService = userServices;
        }

        [HttpGet]
        [Route("GetUsers")]
        public JsonResult Get()
        {
            var ret = _userService.GetUsersAsync();
            return Json(ret.Result);
        }

        [HttpGet]
        [Route("GetUserById")]
        public JsonResult GetById(int Id)
        {
            var ret = _userService.GetUsersByIdAsync(Id);
            return Json(ret.Result);
        }
    }
}