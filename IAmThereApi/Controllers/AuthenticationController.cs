using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IAmThereApi.RequestModels;
using IAmThereApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IAmThereApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public IAuthService AuthService { get; }
        public AuthenticationController(IAuthService authService)
        {
            AuthService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (TryValidateModel(loginModel))
            {
                ClaimsPrincipal principal = AuthService.LoginUser(loginModel);
                if (principal != null)
                {
                    await HttpContext.SignInAsync(principal);
                    return Ok();
                }
                return Unauthorized();
            }
            return BadRequest();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }
    }
}