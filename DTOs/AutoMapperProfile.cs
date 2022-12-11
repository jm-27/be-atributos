using AutoMapper;
using be_atributos.Models;

namespace be_atributos.DTOs
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() { 
        
            CreateMap<Group, GroupOutboundDTO>();
            CreateMap<GroupInboundDTO, Group>();
            CreateMap<TeacherInboundDTO, Teacher>();
            CreateMap<Teacher, TeacherOutboundDTO>();

        }
    }
}
