using EBook.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EBook.Infrastructure.Behavior.Queries
{
    public class PaginationBookQuery:IRequest<IEnumerable<Book>>
    {
        public IEnumerable<Book> books { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }

        public class PaginationBookQueryHandler : IRequestHandler<PaginationBookQuery, IEnumerable<Book>>
        {
            public async Task<IEnumerable<Book>> Handle(PaginationBookQuery request, CancellationToken cancellationToken)
            {
                return request.books.Skip(request.page * request.pageSize).Take(request.pageSize);
            }
        }
    }
}