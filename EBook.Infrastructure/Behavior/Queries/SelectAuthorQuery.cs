using AutoMapper;
using EBook.Infrastructure.DTO;
using EBook.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EBook.Infrastructure.Behavior.Queries
{
    public class SelectAuthorQuery:IRequest<List<AuthorDTO>>
    {
        public class SelectAuthorQueryHandler : IRequestHandler<SelectAuthorQuery, List<AuthorDTO>>
        {
            public SelectAuthorQueryHandler(EBookContext db,IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }
            private readonly EBookContext _db;
            private readonly IMapper _mapper;
            public async Task<List<AuthorDTO>> Handle(SelectAuthorQuery request, CancellationToken cancellationToken)
            {
                var list = await _db.Authors.ToListAsync();
                
                return _mapper.Map<List<AuthorDTO>>(list);
            }
        }
    }
}