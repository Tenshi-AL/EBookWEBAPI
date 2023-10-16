using EBook.Domain.Models;
using EBook.Persistence;
using MediatR;

namespace EBook.Infrastructure.Behavior.Queries
{
    public class SelectLanguageQuery:IRequest<List<Language>>
    {
        public class SelectLanguageQueryHandler : IRequestHandler<SelectLanguageQuery,List<Language>>
        {
            public SelectLanguageQueryHandler(EBookContext db)
            {
                _db = db;
            }
            private readonly EBookContext _db;
            public async Task<List<Language>> Handle(SelectLanguageQuery request, CancellationToken cancellationToken)
            {
                var list = _db.Languages.ToList();
                return list;
            }

        }
    }
}