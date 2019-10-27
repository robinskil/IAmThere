using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAmThereApi.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IAmThereApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        public IActionResult UpdateLocation(UpdateLocationModel location)
        {
            return Ok(location);
        }
    }
}