using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.LeaseAgreement.Commands.CreateLeaseAgreement;
using Application.Price.Queries.GetPrice;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IMediator _mediator;


        public CommonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/PriceCalculator
        [HttpPost("/api/PriceCalculator")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<PriceDto> Post(GetPriceQuery priceQuery)
        {
            var responce = await _mediator.Send(priceQuery);
            return responce;
        }
        
        // POST: api/CreateLeaseAgreement
        [HttpPost("/api/CreateLeaseAgreement")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateLeaseAgreementCommand command)
        {
            var responce = await _mediator.Send(command);
            return CreatedAtAction(nameof(Post), new { id = responce });
        
        }
        
        
    }
}
