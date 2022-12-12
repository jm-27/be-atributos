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
        private ILogger<GroupsController> logger;
        public GroupsController(MyDBContext myDBContext, MyLogContext logDBContext, 
            IMapper mapper, ILogger<GroupsController> logger)
        {
            this.myDBContext = myDBContext;
            this.myLogContext = logDBContext;
            this.mapper = mapper;
            this.logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<List<GroupOutboundDTO>>> getGroups()
        {
            var groupsResult = await myDBContext.Groups.ToListAsync();
            if (groupsResult.Count > 0)
            {
                var groupsOutboundDTO = this.mapper.Map<List<GroupOutboundDTO>>(groupsResult);
                return Ok(groupsOutboundDTO);
            }
            return Ok("No Items.");
        }

        [HttpPost]
        [Route("add", Name = "addGroup")]
        public async Task<ActionResult<Group>> postGroup(GroupInboundDTO groupInboundDTO)
        {
            try
            {
                var newGroup = mapper.Map<Group>(groupInboundDTO);
                await myDBContext.Groups.AddAsync(newGroup);
                await myDBContext.SaveChangesAsync();
                await myLogContext.AddAsync(new AppLog() { Title = $"Group {newGroup.Id} Created", Message = "The group has been created" });
                await myLogContext.SaveChangesAsync();
                return CreatedAtRoute("addGroup", newGroup);
            }
            catch (Exception ex)
            {
                logger.LogError("Error ocurred at Groups/Add " + ex.Message);
                return Problem("An error ocurred", null, StatusCodes.Status500InternalServerError, "Error", null);
            }


        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult> updateGroup(GroupInboundDTO inputGroup, int id)
        {
            var groupResult = await myDBContext.Groups.AnyAsync(x => x.Id == inputGroup.Id);
            if (!groupResult)
            {
                return NotFound("Group not Found");
            }
            var updatedGroup = mapper.Map<Group>(inputGroup);
            myDBContext.Update(updatedGroup);
            await myDBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> deleteGroup(int id)
        {
            try
            {
                var groupResult = await myDBContext.Groups.AnyAsync(x => x.Id == id);
                if (!groupResult)
                {
                    return NotFound("Group not Deleted");
                }

                myDBContext.Remove(new Group() { Id=id});
                await myDBContext.SaveChangesAsync();
                return Ok("Deleted");
            }catch(Exception ex)
            {
                logger.LogError("Failed to delete. ERROR -->" + ex.Message);
                return Problem("Fail to delete", null, StatusCodes.Status500InternalServerError, "Error", null);
            }
            

        }


    }
}
