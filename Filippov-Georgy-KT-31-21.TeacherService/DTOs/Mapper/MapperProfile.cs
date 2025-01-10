using AutoMapper;

using Filippov_Georgy_KT_31_21.TeacherService.Entities;

namespace Filippov_Georgy_KT_31_21.TeacherService.DTOs.Mapper;

public class MapperProfile : Profile {
    public MapperProfile() {
        CreateMap<Post, PostDto>();
        CreateMap<PostDto, Post>();
        CreateMap<Degree, DegreeDto>();
        CreateMap<DegreeDto, Degree>();
        CreateMap<Teacher, TeacherDto>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => new TeacherDto.FullName {
                    FirstName = src.FirstName, 
                    LastName = src.LastName, 
                    SecondName = src.SecondName
                })
            );
        CreateMap<TeacherDto, Teacher>()
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.Name.FirstName))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.Name.LastName))
            .ForMember(dest => dest.SecondName,
                opt => opt.MapFrom(src => src.Name.SecondName));
    }
}