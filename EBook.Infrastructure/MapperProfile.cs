using System.Runtime.InteropServices;
using AutoMapper;
using EBook.Domain.Models;
using EBook.Infrastructure.DTO;

namespace EBook.Infrastructure
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            this.CreateMap<AuthorDTO,Author>();
            this.CreateMap<Author,AuthorDTO>();

            this.CreateMap<BookWriteDTO,Book>()
                .ForMember(dest=>dest.PathToFile, opt => opt.MapFrom(p=>p.book.FileName));

            this.CreateMap<Book,BookReadDTO>()
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(p => p.Publisher.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(p => p.Author.Name + " " + p.Author.Surname))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(p => p.Language.BookLanguage))
                .ForMember(dest => dest.Jenre, opt => opt.MapFrom(p => p.Jenre.Title));

            this.CreateMap<Jenre,JenreDTO>();
            
            this.CreateMap<Publisher,PublisherDTO>();

            this.CreateMap<Language,LanguageDTO>();

        }
    }
}