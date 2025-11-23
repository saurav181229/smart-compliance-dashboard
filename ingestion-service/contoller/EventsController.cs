using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ingestion_service.mappers;
using ingestion_service.models;
using ingestion_service.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ingestion_service.contoller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;
        private readonly IEventRepository _repository;

        public EventsController(ILogger<EventsController> logger,IEventRepository eventRepository)
        {
            _logger = logger;
            _repository = eventRepository;
        }

       


        [HttpPost("events")]
        public async Task<IActionResult> ReceiveEvents([FromBody] EventDto eventsDto,CancellationToken cancellationToken )
        {
            
        //    if (!ModelState.IsValid)                 // kind of a contrainer which stores validation result 
        //       return BadRequest(ModelState);

        //1.validation done

        //2.map entity

        var entity = EventMapper.ToEntity(eventsDto);

        try
            {
                var saved = await _repository.AddAsync(entity, cancellationToken);
            }
            catch(Exception ex)
            {
                
            }

        return Ok("Accepted");
        }
    }
}