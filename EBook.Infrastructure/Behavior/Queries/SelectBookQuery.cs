using AutoMapper;
using EBook.Domain.Models;
using EBook.Infrastructure.DTO;
using EBook.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EBook.Infrastructure.Behavior.Queries
{
    public class SelectBookQuery:IRequest<IEnumerable<Book>>
    {
        public class SelectBookQueryHandler : IRequestHandler<SelectBookQuery, IEnumerable<Book>>
        {
            public SelectBookQueryHandler(EBookContext db,IMapper mapper)
            {
                _db = db;
            }
            private readonly EBookContext _db;
            public async Task<IEnumerable<Book>> Handle(SelectBookQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<Book> list = _db.Books.Include(p => p.Publisher)
                    .Include(p => p.Author)
                    .Include(p => p.Language)
                    .Include(p => p.Jenre).AsNoTracking();

                return list;
            }
        }
    }
}