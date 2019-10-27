using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IAmThereApi.Models;
using IAmThereApi.RequestModels;
using IAmThereApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IAmThereApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private IGroupService GroupService { get; }
        public GroupController(IGroupService groupService)
        {
            GroupService = groupService;
        }

        [Authorize]
        [Route("CreateGroup")]
        public IActionResult CreateGroup(CreateGroupModel createGroupModel)
        {
            string email = User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Email)?.Value;
            if (TryValidateModel(createGroupModel) && !string.IsNullOrEmpty(email))
            {
                if (GroupService.CreateGroup(createGroupModel,email))
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}