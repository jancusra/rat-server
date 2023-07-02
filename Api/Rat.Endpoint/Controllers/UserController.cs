using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Rat.Services;
using Rat.Framework.Authentication;

namespace Rat.Endpoint.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public partial class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public virtual IActionResult GetCurrentUserData()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var emailClaim = identity.FindFirst(ClaimTypes.Email);
            var isAdminClaim = identity.FindFirst(CustomClaimTypes.IsAdmin);

            return Ok(new { 
                Email = emailClaim != null ? emailClaim.Value : string.Empty,
                IsAdmin = isAdminClaim != null ? Convert.ToBoolean(isAdminClaim.Value) : false
            });
        }

        [HttpPost]
        public virtual async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            await _userService.RegisterNewUserAsync(model.Email, model.Password, model.PasswordVerify);
            
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public virtual async Task<IActionResult> GetAll()
        {
            var data = await _userService.GetAllAsync();

            return Ok(data);
        }

        public class RegisterModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string PasswordVerify { get; set; }
        }
    }
}
