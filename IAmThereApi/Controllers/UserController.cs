using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAmThereApi.Models;
using IAmThereApi.RequestModels;
using IAmThereApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IAmThereApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [Route("Register")]
        public IActionResult Register(UserRegisterModel userRegisterModel)
        {
            if (TryValidateModel(userRegisterModel))
            {
                _userService.AddUser(userRegisterModel);
            }
            return BadRequest();
        }

        [Route("DeleteAccount")]
        public IActionResult DeleteAccount(UserDeleteModel userDeleteModel)
        {
            if (TryValidateModel(userDeleteModel))
            {
                if (_userService.RemoveUser(userDeleteModel.Email, userDeleteModel.Password))
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}