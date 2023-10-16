using Microsoft.AspNetCore.Http;

namespace EBook.Infrastructure.DTO
{
    public class BookReadDTO
    {
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public string? Publisher { get; set; }
        public string? Author { get; set; }
        public string? Language { get; set; }
        public string? Jenre { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public string? PathToFile { get; set; }
    }
}