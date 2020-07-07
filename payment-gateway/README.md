
# Use Case Diagram
what our system should do (forever and ever)

![use case](/payment-gateway/images/use-case.jpg)

# Compliance & Best Practice
 - [PCI](/payment-gateway/PCI/)
 - GDPR
 - ISO 27001
 - Industry best practice
  
# Areas of Volatility
 what can change over time (that we should prepare for)
 
 - Multi-Tenant
 - Multi-Region (User Count and Location)
 - Reporting
 - Data & Analytics

## Architecture
Define the services that will compose the architecture.  Flow control only goes from top to bottom (client → Manager → Engine (optional)→Resource Access). Each Service can access any service, as long as it’s top to bottom. Each service should be independent (potentially a microservice), this means that for instance, it has to have it’s own business objects.

**Find the smallest set of services that will satisfy all core use cases and encapsulate all volatilities.**

### Utilities
Cross-cutting concern that is not specific to our business logic. Every service can access any utility service.

- **Identity and access management (IAM)** - facilitates the management of digital identities

### Clients
Handles communication with client, no business logic

- **Gateway** - entrance into the application, reverse proxy, middleware

### Managers
 Orchestrated business use cases, define the workflow — what needs to be done.  Manager can call other managers but only by triggering an action (asynchronous)

- **Tokenization** - stores credit card numbers
- **Authorization** - authorizes an approval from a card issuer
- **Capture** - authorized money is transferred from the customer's account to a merchant's account
- **Credit** -  customer receives a refund for a transaction
- **Void** -  cancel one or several related transactions that were not yet settled
- **Verify** - zero or small amount verification transactions 

### Engines
Executes business logic — how to implement an activity

- **Prechecks** - implement fraud checks prior to tokenization and authorization. Address verification, CVV, device id, large transactions, payer auth, high-risk countries, risk scoring.
- **PCI Compliance** - ensure no PAN data is being published to service bus
- **Transactions Reporting** - listens to the message bus and creates projected views for transaction reports

Define the layers of the architecture

### Landscape
![landscape](/payment-gateway/images/landscape.jpg)
![authorization](/payment-gateway/images/authorization.jpg)

### Configuration
![configuration](/payment-gateway/images/configuration.jpg)

### Security
![security](/payment-gateway/images/security.jpg)

### Observability
![observability](/payment-gateway/images/observability.jpg)

### Devops
![Devops](/payment-gateway/images/devops.jpg)

### Disaster Recovery (TBD)

### Governance (TBD)

### Multi-Region (TBD)

### Costing (TBD)

## API Design
- [Tokenization](/payment-gateway/API/)

## References

- [SQL Change Data Capture](https://docs.microsoft.com/en-us/sql/relational-databases/track-changes/about-change-data-capture-sql-server?view=sql-server-ver15)
- [Azure Architectures](https://docs.microsoft.com/en-us/azure/architecture/browse/)
- [Azure GDPR Blueprint](https://servicetrust.officeppe.com/ViewPage/GDPRBlueprint?command=Download&downloadType=Document&downloadId=abe94a89-72e1-4c21-a0af-e01472e65a68&docTab=d67046f0-4994-11e8-b5cc-896bfb7494a6_IaaS)
- [Serverless Event Processing](https://docs.microsoft.com/en-us/azure/architecture/reference-architectures/serverless/event-processing)
- [App Service Environment](https://docs.microsoft.com/en-us/azure/app-service/environment/using-an-ase)

