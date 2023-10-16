using EBook.Domain.Models;
using EBook.Persistence;
using MediatR;

namespace EBook.Infrastructure.Behavior.Commands
{
    public class InsertPublisherCommand:IRequest
    {
        public string? PublisherName { get; set; }
        public class InsertPublisherCommandHandler : IRequestHandler<InsertPublisherCommand>
        {
            public InsertPublisherCommandHandler(EBookContext db)
            {
                _db = db;
            }
            private readonly EBookContext _db;
            public async Task Handle(InsertPublisherCommand request, CancellationToken cancellationToken)
            {
                var publisher = new Publisher();
                publisher.Name = request.PublisherName;

                _db.Publishers.Add(publisher);
                await _db.SaveChangesAsync();
            }
        }
    }
}