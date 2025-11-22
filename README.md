Problem statement

Compliance teams need to monitor financial activity and detect suspicious patterns in real time (fraud, unusual logins, risky transactions).

Solution
this project is a real-time compliance monitoring system that ingests events (logins, transactions), processes them using rules + an ML risk engine, generates alerts, and visualises them on a dashboard for compliance officers.


High-level architecture

Events → Ingestion Service → Kafka → Stream Processor + ML → Alerts → Dashboard

Users
Internal users: compliance officers / managers in a financial institution.