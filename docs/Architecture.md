 Event Simulator 
        |
        v
 Ingestion Service  ----> [ Events DB ]
        |
        v
    Kafka Topic: events 
        |
        v
 Stream Processor  ----> [ Risk Engine (ML) ]
        |
        v
       Alerts DB 
        |
        v
    Dashboard API 
        |
        v
  Frontend Dashboard 

Event Simulator → generates fake user activity.

Ingestion Service → receives, validates, stores and publishes events.

Kafka → durable event log so processors can read asynchronously.

Stream Processor → analyses events + calls ML + creates alerts.

Risk Engine → returns risk score using an ML model.

Alerts DB → stores all suspicious events.

Dashboard API → exposes data to frontend.

Frontend → shows alerts & charts to compliance officers.