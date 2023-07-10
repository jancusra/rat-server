using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rat.Contracts.Models.User;
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
            var userClaims = _userService.GetCurrentUserClaims();

            return Ok(new { 
                userClaims.Email,
                userClaims.IsAdmin,
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
