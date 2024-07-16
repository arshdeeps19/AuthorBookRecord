using AutoMapper;
using Service_Layer.DTO;
using AuthorBookRecord.ViewModels;
using Domain_Layer.Models;

namespace AuthorBookRecord.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<BookViewModel, BookDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<AuthorViewModel, AuthorDTO>().ReverseMap();
        }
    }
}
