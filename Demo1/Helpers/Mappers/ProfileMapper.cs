using AutoMapper;
using Demo1.Data.Entities;
using Demo1.Models;

namespace Demo1.Helpers.Mappers
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<StudentEntity, StudentModel>();
            CreateMap<InstructorEntity, InstructorModel>();
            CreateMap<CourseEntity, CourseModel>();
            CreateMap<SubjectEntity, SubjectModel>();
            CreateMap<StudentCreateRequestModel, StudentEntity>();
            CreateMap<InstructorCreateRequestModel, InstructorEntity>();
            CreateMap<InstructorEntity, InstructorModel1>();
        }
    }
}
