namespace EBook.Domain.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public Guid PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }
        public Guid LanguageId { get; set; }
        public Language? Language { get; set; }
        public Guid JenreId { get; set; }
        public Jenre? Jenre { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public string? PathToFile { get; set; }
    }
}