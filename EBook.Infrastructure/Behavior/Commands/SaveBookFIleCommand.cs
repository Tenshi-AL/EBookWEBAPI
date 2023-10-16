using MediatR;
using Microsoft.AspNetCore.Http;

namespace EBook.Infrastructure.Behavior.Commands
{
    public class SaveBookFileCommand:IRequest
    {
        public IFormFile book { get; set; }

        public class SaveBookFileCommandHandler : IRequestHandler<SaveBookFileCommand>
        {
            public async Task Handle(SaveBookFileCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    string filePath = $"{Directory.GetCurrentDirectory()}/wwwroot/Books";
                    string fullPath = $"{filePath}/{request.book.FileName}";
                    Directory.CreateDirectory(filePath);

                    using (var fileStream = new FileStream(fullPath,FileMode.Create))
                    {
                        await request.book.CopyToAsync(fileStream);
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }
    }
}