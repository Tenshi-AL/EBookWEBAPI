using AutoMapper;
using EBook.Domain.Models;
using EBook.Infrastructure.DTO;
using EBook.Persistence;
using MediatR;

namespace EBook.Infrastructure.Behavior.Commands
{
    public class InsertBookCommand:IRequest
    {
        public BookWriteDTO book { get; set; }
        public class InsertBookCommandHandler : IRequestHandler<InsertBookCommand>
        {
            public InsertBookCommandHandler(EBookContext db,IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }
            private readonly EBookContext _db;
            private readonly IMapper _mapper;
            public async Task Handle(InsertBookCommand request, CancellationToken cancellationToken)
            {
                var newBook = _mapper.Map<Book>(request.book);
                _db.Books.Add(newBook);
                await _db.SaveChangesAsync();
            }
        }
    }
}