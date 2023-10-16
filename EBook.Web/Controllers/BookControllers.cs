using AutoMapper;
using EBook.Infrastructure.Behavior.Commands;
using EBook.Infrastructure.Behavior.Queries;
using EBook.Infrastructure.DTO;
using EBook.Infrastructure.Enums;
using EBook.Web.Views;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController:ControllerBase
    {
        public BookController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        [HttpPost]
        public async Task<IActionResult> Post ([FromForm] BookWriteDTO book)
        {
            await _mediator.Send(new SaveBookFileCommand()
            {
                book = book.book
            });
            await _mediator.Send(new InsertBookCommand()
            {
                book = book
            });
            return Ok(); //return CreateAt()
        }

        [HttpGet]
        [Route("/{sortState=0}/page/size")] //переделать какашечку
        public async Task<IActionResult> Get(BookSort sortState = 0, int page = 1, int pageSize = 5)
        {
            var list = await _mediator.Send(new SelectBookQuery()); //получаем список книг
            //if list = null return no content

            await _mediator.Send(new SortBookQuery() 
            {
                list = list,
                bookSort = sortState
            }); 
            
            await _mediator.Send(new PaginationBookQuery()
            {
                books = list,
                page = page,
                pageSize = pageSize,
            });

            // //фильтрация

            // var bookView = new BookView()
            // {
            //     //Books = list,
            //     Page = page,
            //     PageSize = pageSize,
            // };

            //return Ok(bookView);
            return Ok(_mapper.Map<List<BookReadDTO>>(list)); //_mapper
        }
    }
}