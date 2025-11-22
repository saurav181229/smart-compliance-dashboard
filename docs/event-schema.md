{
  "id": "string-guid",
  "userId": 101,
  "eventType": "Transaction",     // or Login, LoginFailure, PasswordReset
  "amount": 9500.00,              // null for non-transaction events
  "currency": "EUR",
  "location": "DE",
  "status": "SUCCESS",            // or FAILED, PENDING
  "deviceId": "dev-123",
  "ipAddress": "192.168.0.5",
  "timestamp": "2025-11-17T10:01:00Z"
} 

id: unique identifier of the event.

userId: who did this.

eventType: which kind of action.

amount: relevant for financial events only.

timestamp: when it happened.

