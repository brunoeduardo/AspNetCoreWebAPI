using AutoMapper;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Student, StudentDto>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.Name} {src.Surname}")
            )
            .ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(src => src.Birth.GetCurrentAge())
            );

            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentRegisterDto>().ReverseMap();
        }
    }
}