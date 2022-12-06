using AutoMapper;
using be_atributos.DTOs;
using be_atributos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be_atributos.Controllers
{
    [ApiController]
    [Route("/api/groups")]
    public class GroupsController : Controller
    {
        private readonly MyDBContext dbContext;
        private readonly IMapper mapper;
        public GroupsController(MyDBContext dBContext, IMapper mapper) {
            this.dbContext= dBContext;
            this.mapper=mapper;
        }


        [HttpGet("",Name ="groups")]
        public async Task<ActionResult<List<GroupOutboundDTO>>> getGroups()
        {
            var groupsResult =  await dbContext.Groups.ToListAsync();
            var groupsOutboundDTO = this.mapper.Map<List<GroupOutboundDTO>>(groupsResult);
            return CreatedAtRoute("groups", groupsOutboundDTO);
        }


    }
}
