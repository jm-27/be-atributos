using AutoMapper;
using be_atributos.DTOs;
using be_atributos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be_atributos.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeachersController : Controller
    {
        private readonly MyDBContext dbContext;
        private readonly IMapper mapper;    
        public TeachersController(MyDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;

        }

        [HttpPost]
        public async Task<ActionResult<TeacherOutboundDTO>> postTeacher(TeacherInboundDTO teacherInboundDTO)
        {
            Teacher newTeacher = mapper.Map<Teacher>(teacherInboundDTO);
            await dbContext.Teachers.AddAsync(newTeacher);
            await dbContext.SaveChangesAsync();
            return Ok(newTeacher);

        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherOutboundDTO>>> getAllTeachers()
        {
            List<Teacher> teacherList = await dbContext.Teachers.Include(e => e.Groups).ToListAsync();
            if (teacherList != null)
            {
                var teacherOutbound = mapper.Map<List<TeacherOutboundDTO>>(teacherList);
                return Ok(teacherOutbound);
            }
            return Ok("No items.");
        }



    }
}
