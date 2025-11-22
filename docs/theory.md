5.1 Event-driven vs Request/Response

Request/response: client sends request and waits for direct answer.

Event-driven: producers send events and don’t care who handles them.

Our system is event-driven: ingestion doesn’t know/care who reads events.

This allows scalability and decoupling.

5.2 What Kafka is doing in this system

Kafka is a log that stores all events in order.

Ingestion writes to Kafka, stream-processor reads from Kafka.

If stream-processor dies, Kafka still has all events.

We can replay events to re-run detection or retrain models.

5.3 Where ML fits

ML is NOT everywhere; it only lives in risk-engine.

Stream-processor turns raw events into features and asks ML for risk score.

ML returns a number (0–1), stream-processor decides to create an alert or not.

ML is a helper, not the main architecture.

5.4 Who the users are

End users (customers) are simulated only.

Real product users = compliance officers & managers.

They use dashboard to review alerts and see risk patterns.