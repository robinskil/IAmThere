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
        [HttpPost]
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
        [Authorize]
        [Route("GetGroup")]
        public IActionResult GetGroup(Guid groupId)
        {
            string guidstring = User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)?.Value;
            if (groupId != default && Guid.TryParse(guidstring,out Guid accountGuid))
            {
                return Ok(GroupService.GetGroup(groupId, accountGuid));
            }
            return BadRequest();
        }
        [Authorize]
        [Route("GetGroups")]
        public IActionResult GetGroups()
        {
            string guidstring = User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(guidstring, out Guid accountGuid))
            {
                return Ok(GroupService.GetGroups(accountGuid));
            }
            return BadRequest();
        }
        [Authorize]
        [Route("JoinGroup")]
        [HttpPost]
        public IActionResult JoinGroup(Guid groupId)
        {
            string guidstring = User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(guidstring, out Guid accountGuid))
            {
                if (GroupService.JoinGroup(groupId, accountGuid))
                {
                    return Ok();
                }
                return BadRequest("Cant join the group.");
            }
            return BadRequest();
        }
    }
}