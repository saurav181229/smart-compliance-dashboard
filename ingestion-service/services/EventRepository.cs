using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ingestion_service.data;
using ingestion_service.models;

namespace ingestion_service.services
{
    public class EventRepository:IEventRepository
    {
        private  readonly EventDbContext _eventdbContext;

        public EventRepository(EventDbContext eventdbContext)
        {
            _eventdbContext = eventdbContext;
        }
        public async Task<Event> AddAsync(Event ev,CancellationToken cancellationToken = default)
        {
             _eventdbContext.Events.Add(ev);
         await  _eventdbContext.SaveChangesAsync(cancellationToken);
         return ev;
        }

    }
}