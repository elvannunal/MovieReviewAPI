using AutoMapper;
using Entities.Dto;
using Entities.Model;

namespace MovieReviewApi.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<AddMovieDto, Movie>().ReverseMap();
        CreateMap<UpdateMovieDto, Movie>().ReverseMap();
        CreateMap<MovieDto, Movie>().ReverseMap();
        CreateMap<ReviewDto,Review>().ReverseMap();
        CreateMap<AddReviewDto, Review>().ReverseMap();
        CreateMap<UpdateReviewDto, Review>().ReverseMap();
        CreateMap<UserRegisterDto, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Roles, opt => opt.Ignore()); 
        CreateMap<UserValidationDto, User>().ReverseMap();

    }
}