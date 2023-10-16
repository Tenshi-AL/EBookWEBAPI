using EBook.Domain.Models;
using EBook.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EBook.Infrastructure.Behavior.Queries
{
    public class SelectPublisherQuery:IRequest<List<Publisher>>
    {
        public class SelectPublisherQueryHandler : IRequestHandler<SelectPublisherQuery, List<Publisher>>
        {
            public SelectPublisherQueryHandler(EBookContext db)
            {
                _db = db;
            } 
            private readonly EBookContext _db;
            public async Task<List<Publisher>> Handle(SelectPublisherQuery request, CancellationToken cancellationToken)
            {
                var list = await _db.Publishers.ToListAsync();
                return list;
            }
        }
    }
}