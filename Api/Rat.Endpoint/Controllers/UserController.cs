using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rat.Contracts.Models.User;
using Rat.Framework.Authentication;
using Rat.Services;

namespace Rat.Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public partial class UserController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        private readonly IUserService _userService;

        public UserController(
            ILanguageService languageService,
            IUserService userService)
        {
            _languageService = languageService;
            _userService = userService;
        }

        public virtual async Task<IActionResult> GetCurrentUserData()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var emailClaim = identity.FindFirst(ClaimTypes.Email);
            var isAdminClaim = identity.FindFirst(CustomClaimTypes.IsAdmin);

            return Ok(new { 
                Email = emailClaim != null ? emailClaim.Value : string.Empty,
                IsAdmin = isAdminClaim != null ? Convert.ToBoolean(isAdminClaim.Value) : false,
                Languages = await _languageService.GetAllAsync()
            });
        }

        [HttpPost]
        public virtual async Task<IActionResult> Register([FromBody]RegisterDto model)
        {
            await _userService.RegisterNewUserAsync(model.Email, model.Password, model.PasswordVerify);
            
            return Ok();
        }
    }
}
