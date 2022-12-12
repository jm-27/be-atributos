using AutoMapper;
using be_atributos.DTOs;
using be_atributos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace be_atributos.Controllers
{
    [ApiController]
    [Route("/api/groups")]
    public class GroupsController : Controller
    {
        private readonly MyDBContext myDBContext;
        private readonly MyLogContext myLogContext;
        private readonly IMapper mapper;
        public GroupsController(DbContexts dbContexts, IMapper mapper) {
            var demo = dbContexts;
            this.myDBContext= dbContexts[typeof(MyDBContextFactory).ToString()] as MyDBContext ;
            this.mapper=mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<GroupOutboundDTO>>> getGroups()
        {
            var groupsResult =  await myDBContext.Groups.ToListAsync();
            if (groupsResult.Count > 0)
            {
                var groupsOutboundDTO = this.mapper.Map<List<GroupOutboundDTO>>(groupsResult);
                return Ok(groupsOutboundDTO);
            }
            return Ok("No Items.");
        }

        [HttpPost]
        [Route("add",Name ="addGroup")]
        public async Task<ActionResult<Group>> postGroup(GroupInboundDTO groupInboundDTO)
        {
            var newGroup = mapper.Map<Group>(groupInboundDTO);
            await myDBContext.Groups.AddAsync(newGroup);
            await myDBContext.SaveChangesAsync();
            return CreatedAtRoute("addGroup", newGroup);
        }


    }
}
