namespace EBook.Domain.Models
{
    public class Jenre
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}