# MultiShop
This project is an e-commerce web application built using ASP.NET MVC and microservices architecture. The application is designed to be scalable, maintainable, and flexible, with separate services handling different aspects of the e-commerce functionality.

## Project Overview

### Technologies Used

- **ASP.NET MVC**: The primary framework for building the web application.
- **Microservices Architecture**: To ensure scalability, maintainability, and flexibility by separating functionalities into different services.
- **Docker**: To containerize microservices for easy deployment and management.
- **Kubernetes**: For orchestration and management of containerized microservices.
- **RabbitMQ**: For asynchronous communication between microservices.
- **MSSQL**: For managing relational data.
- **MongoDB**: For managing non-relational data.
- **Entity Framework**: As the ORM (Object-Relational Mapper) for MSSQL.
- **Redis**: For caching to improve application performance.
- **JWT (JSON Web Tokens)**: For secure authentication and authorization.

## Architecture

The application follows a microservices architecture, where each service is responsible for a specific functionality within the e-commerce domain. This architecture enhances scalability and maintainability by allowing independent deployment and development of each service.

### Microservices
