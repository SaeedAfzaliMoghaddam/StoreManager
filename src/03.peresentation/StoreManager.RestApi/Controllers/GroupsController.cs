using Microsoft.AspNetCore.Mvc;
using StoreManager.Services.Groups.Contracts;
using StoreManager.Services.Groups.Contracts.Dto;

namespace StoreManager.RestApi.Controllers
{
    [Route("Groups")]
    [ApiController]
    public class GroupsController : Controller
    {
        private readonly GroupService _groupService;

        public GroupsController(GroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        public void Add([FromBody] AddGroupsDto dto)
        {
            _groupService.Define(dto);
        }
    }
}
