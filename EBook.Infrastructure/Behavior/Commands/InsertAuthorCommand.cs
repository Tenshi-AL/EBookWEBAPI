using AutoMapper;
using EBook.Domain.Models;
using EBook.Infrastructure.DTO;
using EBook.Persistence;
using MediatR;

namespace EBook.Infrastructure.Behavior.Commands
{
    public class InsertAuthorCommand:IRequest
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public class InsertAuthorCommandHandler : IRequestHandler<InsertAuthorCommand>
        {
            public InsertAuthorCommandHandler(EBookContext db,IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }
            private readonly EBookContext _db;
            private IMapper _mapper;
            public async Task Handle(InsertAuthorCommand request, CancellationToken cancellationToken)
            {
                var author = _mapper.Map<Author>(new AuthorDTO{Name = request.Name, Surname = request.Surname});
                _db.Authors.Add(author);
                await _db.SaveChangesAsync();
            }
        }
    }
}