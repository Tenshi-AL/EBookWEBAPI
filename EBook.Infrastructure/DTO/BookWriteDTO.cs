using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EBook.Infrastructure.DTO
{
    public class BookWriteDTO
    {
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public Guid PublisherId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid JenreId { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public IFormFile? book { get; set; }
    }
}