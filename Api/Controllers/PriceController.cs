using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Price.Queries.GetPrice;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IMediator _mediator;


        public PriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/Price
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<PriceDto> Post(GetPriceQuery priceQuery)
        {
            var responce = await _mediator.Send(priceQuery);
            return responce;
        }
    }
}
