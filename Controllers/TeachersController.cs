using AutoMapper;
using be_atributos.DTOs;
using be_atributos.Models;
using Microsoft.AspNetCore.Mvc;

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



    }
}
