using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingestion_service.models
{
    public class EventDto
    {
         public int UserId { get; set; }
        public string EventType { get; set; } = string.Empty;   // "Transaction", "Login", "LoginFailure"
        public decimal? Amount { get; set; }                    // null for non-transaction events
        public string? Currency { get; set; }                   // null for non-transaction events
        public string Location { get; set; } = string.Empty;    // e.g. "IE", "DE"
        public string Status { get; set; } = string.Empty;      // "SUCCESS", "FAILED", "PENDING"
        public string DeviceId { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }                   
    }

}