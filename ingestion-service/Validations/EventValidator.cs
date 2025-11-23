using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ingestion_service.models;

namespace ingestion_service.Validations
{
    public class EventValidator:AbstractValidator<EventDto>
    {
        public EventValidator()
        {
            
            RuleFor(x=>x.UserId).GreaterThan(0).WithMessage("UserId must be positive");
            RuleFor(x=>x.EventType).NotNull().WithMessage("ventType is required.");

              var allowedEventTypes = new[] { "Transaction", "Login", "LoginFailure" };
            RuleFor(x=>x.EventType).Must(value=>allowedEventTypes.Contains(value,StringComparer.OrdinalIgnoreCase))
            .WithMessage("event type is not supported");

            RuleFor(x=>x.Timestamp).NotEqual(default(DateTime)).WithMessage("Timestamp is required.");
        
            RuleFor(x=>x.Location).NotNull().WithMessage("location is required");

            RuleFor(x=>x.DeviceId).NotNull().WithMessage("Device is required");
            RuleFor(x=>x.IpAddress).NotNull().WithMessage("Ip address is required");


            When(x => x.EventType == "Transaction", () =>
            {
             RuleFor(x=>x.Amount)
             .NotNull().WithMessage("Amount must be non-negative for Transaction events.")
             .GreaterThanOrEqualTo(0).WithMessage("Amount must be non-negative for Transaction events.");

             RuleFor(x => x.Currency)
        .NotEmpty().WithMessage("Currency is required for Transaction events.");   
            });
        
        }
    }

    
}