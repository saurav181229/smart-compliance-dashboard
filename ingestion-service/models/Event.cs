using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ingestion_service.models
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; }                            // Internal event identifier

        public int UserId { get; set; }
        public string EventType { get; set; } = string.Empty;
        public decimal? Amount { get; set; }
        public string? Currency { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string DeviceId { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }

        // Optional: full original JSON payload for audit/debug
        public string RawPayload { get; set; } = string.Empty;

        // Optional: useful later for Kafka status / replay logic
        public DateTime CreatedAtUtc { get; set; }
    }
}