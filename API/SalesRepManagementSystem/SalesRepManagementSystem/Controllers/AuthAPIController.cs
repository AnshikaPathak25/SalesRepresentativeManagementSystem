using BusinessLayer.IService;
using BusinessModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SalesRepManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IUserBL _userBL;
        private readonly IConfiguration _configuration;
        public AuthAPIController(IUserBL userBL, IConfiguration configuration)
        {
            _userBL = userBL;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("auth")]
        public IActionResult Authenticate([FromBody] LoginModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                UserModel loggedInUser = _userBL.ValidateUser(loginViewModel);
                if (loggedInUser != null)
                {
                    string token = _userBL.GenerateToken(loggedInUser);
                    return StatusCode(StatusCodes.Status200OK, new { message = "success", token = token });
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "failure" });
            }
            return StatusCode(StatusCodes.Status400BadRequest);

        }
    }
}
