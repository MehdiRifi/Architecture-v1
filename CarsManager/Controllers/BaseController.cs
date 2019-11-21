using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsManager.Controllers
{
    [Route("api")]
    [ApiController]
    public abstract class BaseController:ControllerBase
    {
    }
}
