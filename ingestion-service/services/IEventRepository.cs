using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ingestion_service.models;

namespace ingestion_service.services
{
    public interface IEventRepository
    {
     Task <Event> AddAsync(Event e,CancellationToken cancellationToken = default); //to save db resources cancelltion token is used like when client disconnects   
    }
}