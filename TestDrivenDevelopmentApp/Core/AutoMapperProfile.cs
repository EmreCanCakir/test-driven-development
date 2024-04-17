using AutoMapper;
using TestDrivenDevelopmentApp.Model;
using TestDrivenDevelopmentApp.Model.Dtos;

namespace TestDrivenDevelopmentApp.Core
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author))
                .ReverseMap();
        }
    }
}
