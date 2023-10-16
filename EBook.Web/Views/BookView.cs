using EBook.Domain.Models;
using EBook.Infrastructure.DTO;

namespace EBook.Web.Views
{
    public class BookView
    {
        public List<BookWriteDTO> Books { get; set;}
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}