                                                                       ** Sales Representative Management System**
The Sales Representative Management System is designed as a scalable, maintainable full-stack web application to manage sales representatives across multiple platforms efficiently. It follows a layered architecture ensuring separation of concerns, maintainability, and security.

Tech Stack:
•	Backend: .NET 8 Web API
•	Database & ORM: SQL Server + Entity Framework Core (Code-First Approach)
•	Frontend: Angular (Version 19)

**Architectural Layers**
The application follows a three-tier architecture, separating concerns into distinct layers:
**Layer	Description**
Presentation Layer (Angular)	- Provides an intuitive and dynamic UI using Angular's component-based architecture.
Business Logic Layer (Controller, Services in .NET)	- Handles core logic, validation, and interaction with the database through services and repository.
Data Access Layer (Entity Framework Core)	- Manages database interaction through repository patterns and data models.

**Design Choices & Reasoning**
**.NET 8 for Backend**
•	High performance and efficiency with minimal API support.
•	Strong type safety and robust exception handling.
•	Seamless integration with SQL Server and Entity Framework Core.
•	Global Exception Handler
Entity Framework Core - Code-First Approach
•	Provides flexibility in defining models without needing database-first schema definitions.
•	Supports migrations, enabling incremental changes to the database.
•	Improves maintainability by using Models and Repository Patterns.

**Angular 19 for Frontend**
•	Component-based architecture for modularity.
•	Bootstrap CSS framework for responsiveness.

**Repository Pattern –**
Implemented to ensure a clear separation between the business logic layer and the data access layer, promoting modularity, maintainability, and scalability.

**Authentication with JWT-**
•	Ensures secure token-based authentication for API access.
•	Allows easy integration with role-based authorization mechanisms.

**Security Features in Sales Representative Management System-**
To ensure data protection and system integrity, the Sales Representative Management System incorporates various security measures.
1. Authentication & Authorization
•	JWT-Based Authentication: Uses JSON Web Tokens (JWT) for secure login and session management.
•	Role-Based Access Control (RBAC): Ensures users can only access authorized features based on their assigned role (Admin, Manager, Sales Rep).
2. Secure API Communication
•	HTTPS Enforcement: All API interactions occur over SSL/TLS to protect sensitive data.
•	CORS Configuration: Allows only requests from the Angular UI to prevent unauthorized cross-origin access.
3. API Security Measures
•	Logging & Monitoring: Used serilog and ILogger to Implements centralized logging for tracking suspicious activities.
4. Input Validation
•	Input Validation & Sanitization
5. Exception Handling

Functionality Implemented -
Add – Enables users to input and save details for new sales representatives.
Delete – Provides the option to remove sales representative records from the system.
Edit – Allows users to update or modify existing sales representative information.
Search – Facilitates quick lookup of sales representatives by name.
Filters – Allows users to refine data based on product, region, and sales performance criteria.


