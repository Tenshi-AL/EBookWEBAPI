using EBook.Infrastructure.Behavior.Commands;
using EBook.Infrastructure.Behavior.Queries;
using EBook.Infrastructure.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace EBook.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController:ControllerBase
    {
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        private readonly IMediator _mediator;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AuthorDTO author)
        {
            await _mediator.Send(new InsertAuthorCommand()
            {
                Name = author.Name,
                Surname = author.Surname
            });
            return Ok();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var list = await _mediator.Send(new SelectAuthorQuery());
            return Ok(list);
        }
    }
}