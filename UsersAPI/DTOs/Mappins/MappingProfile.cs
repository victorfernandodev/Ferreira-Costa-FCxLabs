using AutoMapper;
using UsersAPI.Models;

namespace UsersAPI.DTOs.Mappins
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Login, opts => opts.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.CPF, opts => opts.MapFrom(src => src.CPF))
                .ForMember(dest => dest.DateOfBirth, opts => opts.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.MotherName, opts => opts.MapFrom(src => src.MotherName))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.Status.ToUpper()))
                .ForMember(dest => dest.InclusionDate, opts => opts.MapFrom(src => src.InclusionDate))
                .ForMember(dest => dest.ChangeDate, opts => opts.MapFrom(src => src.ChangeDate));

            CreateMap<LoginUserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
                .ForMember(dest => dest.CPF, opt => opt.Ignore())
                .ForMember(dest => dest.DateOfBirth, opt => opt.Ignore())
                .ForMember(dest => dest.MotherName, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.InclusionDate, opt => opt.Ignore())
                .ForMember(dest => dest.ChangeDate, opt => opt.Ignore());
        }
    }
}
