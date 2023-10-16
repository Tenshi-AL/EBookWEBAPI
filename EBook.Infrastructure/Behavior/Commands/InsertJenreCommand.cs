using EBook.Domain.Models;
using EBook.Persistence;
using MediatR;

namespace EBook.Infrastructure.Behavior.Commands
{
    public class InsertJenreCommand:IRequest
    {
        public string? Jenre { get; set; }

        public class InsertJenreCommandHandler : IRequestHandler<InsertJenreCommand>
        {
            public InsertJenreCommandHandler(EBookContext db)
            {
                _db = db;
            }
            private readonly EBookContext _db;
            public async Task Handle(InsertJenreCommand request, CancellationToken cancellationToken)
            {
                var jenre = new Jenre();
                jenre.Title = request.Jenre;

                _db.Jenres.Add(jenre);
                await _db.SaveChangesAsync();
            }
        }
    }
}