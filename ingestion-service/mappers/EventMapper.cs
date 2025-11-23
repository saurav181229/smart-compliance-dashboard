using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ingestion_service.models;
using Microsoft.Extensions.Logging;

namespace ingestion_service.mappers
{
    public static class EventMapper
    {
        public static Event ToEntity(EventDto dto)
        {
            return new Event
            {
                
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                EventType = dto.EventType,
                Amount = dto.Amount,
                Currency = dto.Currency,
                Location = dto.Location,
                Status = dto.Status,
                DeviceId = dto.DeviceId,
                IpAddress = dto.IpAddress,
                Timestamp = dto.Timestamp,
                CreatedAtUtc = DateTime.UtcNow,
                RawPayload = JsonSerializer.Serialize(dto)
            };
        }
        
    }
}