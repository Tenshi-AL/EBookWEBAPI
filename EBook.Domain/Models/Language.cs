namespace EBook.Domain.Models
{
    public class Language
    {
        public Guid Id { get; set; }
        public string? BookLanguage { get; set; }
        public ICollection<Book>? Books { get; set;}
         
    }
}