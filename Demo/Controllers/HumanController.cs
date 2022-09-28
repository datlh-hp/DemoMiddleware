using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HumanController : ControllerBase
    {

        [HttpGet]
        public String nguoi()
        {
            return "Human";

        }
    }
}
