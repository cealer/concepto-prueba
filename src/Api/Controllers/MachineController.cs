using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("machine")]
    [Authorize]
    public class MachineController : ControllerBase
    {

        public IActionResult GetMachineToMachine()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
