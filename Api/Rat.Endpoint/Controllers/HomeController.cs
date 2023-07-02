using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Rat.Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class HomeController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public HomeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public virtual IEnumerable<string> Get()
        {
            return new string[] { "Hello", "api", "world" };
        }
    }
}
