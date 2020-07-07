
# PCI
Compliance for Level 1 merchants is the most demanding and requires an independent annual Report on Compliance (ROC) by a certified Qualified Security Assessor (QSA).




## 1. **Install and maintain a firewall configuration to protect cardholder data**
  - **Application Gateway** - transport layer load balancing, SSL/TSL termination, web app firewall
  - **Network Security Group (NSG)** - (allow / deny)  (inbound / outbound) traffic
  - **App Service Environment (ASE)** - fully isolated and dedicated environement  for securely running App Service apps as high scale
  - **Azure Active Directory (AAD)** (native or sync w/AD) - identity management

## 2. **Don’t Use Vendor-Supplied Defaults for System Passwords**
  - **AAD** (native or sync w/AD) - identity management, generate access tokens, manage passwords

## 3. **Protect Stored Cardholder Data**
  - **Transparent data encryption (TDE)** -  provides encryption at rest and is enabled by default for Azure SQL
  - **Dynamic Data Masking (DDM)** -  SQL security feature that allows customers to limit sensitive data exposure by masking it to non-privileged users.
  - **Always Encrypted** - protects sensitive data at rest on the server, during movement between the client and server, and while the data is in use.

 ## 4. **Encrypt Transmission of Cardholder Data**
  - **ASE** - fully isolated and dedicated environement  for securely running App Service apps as high scale
  - **x.509 v3 certificates** - public key certificate
  - **Application Gateway** - TLS 1.2 encryption for all data in transit over public networks with Azure
  - **Azure Key Vault** - requesting and renewing TLS certificates
  - **Service Bus** - Any transmission of PAN data through a messaging system must be secure. (keep PAN off service bus)

## 5.  **Protect All Systems Against Malware**
  - **Azure PaaS VMs** are constantly scanned to validate that anti-malware clients are installed and current

## 6.  **Develop and Maintain Secure Systems and Applications**
  - **Azure Security Center** - assess workloads and raise threat prevention recommendations and threat detection alerts, Advanced Threat Detection detects anomalous activities that indicate unusual and potentially harmful attempts to access or exploit databases,  provide real-time monitoring and scanning of customer workloads 
  - **SQL Vulnerability Assessment** - discover, track, and help customers remediate potential database vulnerabilities
  - **Microsoft Security Response Center** - regularly monitors external security vulnerability awareness sites
  - **Microsoft Security Development Lifecycle (SDL) methodology** -  in line with DSS requirements

## 7.  **Install and Maintain a Firewall Configuration to Protect Cardholder Data**  
  - **Role-based access control (RBAC)** - restrict access to cardholder data by business “need to know”
  - **Row-level security (RLS)** -  restrict access to certain rows within a table to only those who require access
  - **Dynamic Data Masking DDM** - mask sensitive data only revealing full column level data to those who require it

## 8.  **Identify and Authenticate Access to System Components**
  - **AAD** - Multi-Factor Authentication (MFA), Password expiration policies, session lockout
  - **RBAC** - least privilege principle to establish who can perform which task based on job function

## 9.  **Restrict Physical Access to Cardholder Data**
  - **Microsoft Datacenter Security Policies** - Microsoft designs, builds, and operates datacenters in a way that strictly controls physical access to the areas where your data is stored.

## 10.  **Track and Monitor All Access to Network Resources and Cardholder Data**
  - **Log Analytics** -  search, identify trends, analyze patterns, data insights
  - **AAD** - reporting provides insights into user sign-in activities and system activity information about user and group management
  - **Azure** -  records and maintains a log of all individual user access to Microsoft Azure system components, Audit logs are stored for a minimum of 180 days
  - **Tracing** -  include user IDs, event types, timestamps, success or failure of an event, origination of an event, and the asset name

## 11.  **Regularly Test Security Systems and Processes**
  - **Azure Security Center** - rapidly updates detection algorithms as attackers release new and increasingly sophisticated exploits
  - **Open Web Application Security Project OWASP** - third party penetration testing per PCI DSS compliance guidelines
  - **PCI SSC Approved Scanning Vendor (ASV)** - internal and external vulnerability scans on at least a quarterly basis
  - **Intrusion Detection Systems (IDS)** - near real-time alerts about events that could potentially compromise the system

## 12.   **Maintain a Policy that Addresses Information Security for all Personnel**
  - **Microsoft Server Security Assessment (MSSA)** -  detailed review of the configuration of Microsoft servers to ensure that critical systems are configured to minimize exposure and risk and thus maximize security


## Azure Paas
The Azure PaaS platform also offers Vulnerability Assessments, Data Classification and Discovery (in preview at time of writing), auditing, Azure Active Directory (AAD), and Threat Protection. 

## Azure SQL Database
Azure SQL Database is database scoped, it does not support cross-database queries. This is a critical benefit for customers that need database isolation, such as Software-asa-Service (SaaS) companies that have a database per customer. They can easily create a database when a new customer signs up for their service, grant access to the customer, and not
have to worry about the customer being able to elevate privileges or see data from any other customer with a database on the system. 

Azure SQL Database does not have SQL Server Agent built in or support Database Mail, Common Language Runtime (CLR), linked servers, and other features. This restrictive footprint makes some aspects of the PCI DSS compliance easier to attain.

For data protection, there are many features including Always Encrypted for encrypting column level data within the database itself, Transparent Data Encryption (TDE) for encrypting the data and log file at rest, Dynamic Data Masking (DDM) for masking how sensitive data appears in query results, data redundancy, and managed encrypted backups.

## Azure compliance with PCI

[Payment Card Industry (PCI) Data Security Standard (DSS)](https://docs.microsoft.com/en-us/microsoft-365/compliance/offering-pci-dss?view=o365-worldwide)

[Control mapping of the PCI-DSS v3.2.1 blueprint sample](https://docs.microsoft.com/en-us/azure/governance/blueprints/samples/pci-dss-3.2.1/control-mapping)

[Making PCI compliance easier with Azure SQL Database](https://azure.microsoft.com/mediahandler/files/resourcefiles/azure-sql-db-pci-compliance-whitepaper/AzureSQLDB%20PCI%20Compliance%20WhitePaper.pdf)

