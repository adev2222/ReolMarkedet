using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Shelf.Queries.GetShelfList;
using Application.ShelfRenter.Commands.CreateShelfRenter;
using Application.ShelfRenter.Queries;
using Application.ShelfRenter.Queries.GetShelfRentersList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfRenterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShelfRenterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // GET: api/ShelfRenter
        [HttpGet]
        public async Task<List<ShelfRentersListDto>> Get()
        {
            var shelfRenters = await _mediator.Send(new GetShelfRentersListQuery());
            return shelfRenters;
        }
        
        // POST: api/ShelfRenter
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateShelfRenterCommand shelfRenter)
        {
            var responce = await _mediator.Send(shelfRenter);
            return CreatedAtAction(nameof(Get), new { id = responce });
        }
    }
}
