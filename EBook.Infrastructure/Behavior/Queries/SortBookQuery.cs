using EBook.Domain.Models;
using EBook.Infrastructure.Enums;
using MediatR;

namespace EBook.Infrastructure.Behavior.Queries
{
    public class SortBookQuery:IRequest<IEnumerable<Book>>
    {
        public IEnumerable<Book> list { get; set; }
        public BookSort bookSort { get; set; }

        public class SortBookQueryHandler : IRequestHandler<SortBookQuery, IEnumerable<Book>>
        {
            public async Task<IEnumerable<Book>> Handle(SortBookQuery request, CancellationToken cancellationToken)
            {
                return request.list = request.bookSort switch
                {
                    BookSort.TitleAsk => request.list.OrderBy(p => p.Title),
                    BookSort.TitleDesk => request.list.OrderByDescending(p => p.Title),
                    BookSort.PriceAsk => request.list.OrderBy(p => p.Price),
                    BookSort.PriceDesk => request.list.OrderByDescending(p => p.Price),
                    _ => request.list,
                };
            }
        }
    }
}