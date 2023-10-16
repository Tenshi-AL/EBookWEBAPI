using EBook.Domain.Models;
using EBook.Infrastructure.DTO;
using EBook.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EBook.Infrastructure.Behavior.Queries
{
    public class SelectJenreQuery:IRequest<List<Jenre>>
    {
        public class SelectJenreQueryHandler : IRequestHandler<SelectJenreQuery, List<Jenre>>
        {
            public SelectJenreQueryHandler(EBookContext db)
            {
                _db = db;
            }
            private readonly EBookContext _db;
            public async Task<List<Jenre>> Handle(SelectJenreQuery request, CancellationToken cancellationToken)
            {
                var list = await _db.Jenres.ToListAsync();
                return list;
            }
        }
    }
}