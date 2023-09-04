using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Shelf.Commands.CreateShelf;
using Application.Shelf.Queries.GetShelfList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShelfController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/Shelf
        [HttpGet]
        public async Task<List<ShelvesDto>> Get()
        {
            var shelves = await _mediator.Send(new GetShelvesQuery());
            return shelves;
        }
        
        // POST: api/Shelf
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateShelfCommand shelf)
        {
            var responce = await _mediator.Send(shelf);
            return CreatedAtAction(nameof(Get), new { id = responce });
        }
    }
}
