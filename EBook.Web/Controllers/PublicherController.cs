using AutoMapper;
using EBook.Infrastructure.Behavior.Commands;
using EBook.Infrastructure.Behavior.Queries;
using EBook.Infrastructure.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController:ControllerBase
    {
        public PublisherController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var list = await _mediator.Send(new SelectPublisherQuery());
            return Ok(_mapper.Map<List<PublisherDTO>>(list));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string publisherName)
        {
            await _mediator.Send(new InsertPublisherCommand() { PublisherName = publisherName} );
            return Ok();
        }
    }
}