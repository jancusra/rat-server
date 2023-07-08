using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Rat.Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class HomeController : ControllerBase
    {
        [HttpGet]
        public virtual IEnumerable<string> Get()
        {
            return new string[] { "Hello", "api", "world" };
        }
    }
}
