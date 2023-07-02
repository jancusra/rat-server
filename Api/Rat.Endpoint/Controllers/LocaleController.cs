using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Rat.Endpoint.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public partial class LocaleController : ControllerBase
    {
        public LocaleController()
        {
        }

        [HttpPost]
        public virtual IActionResult Get()
        {
            return Ok(GetWebLocales());
        }

        [HttpPost]
        public virtual IActionResult GetAdmin()
        {
            return Ok(GetAdminLocales());
        }

        private Dictionary<string, string> GetWebLocales()
        {
            return new Dictionary<string, string>
            {
                { "Administration", "Administrace" },
                { "Login", "Přihlásit" },
                { "Register", "Registrovat" },
                { "Email", "E-mail" },
                { "Password", "Heslo" },
                { "PasswordVerify", "Heslo znova" }
            };
        }

        private Dictionary<string, string> GetAdminLocales()
        {
            return new Dictionary<string, string>
            {
                { "Administration", "Administrace" },
                { "Email", "E-mail" },
                { "Password", "Heslo" },
                { "Users", "Uživatelé" }
            };
        }
    }
}
