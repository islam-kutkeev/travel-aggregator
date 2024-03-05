# TravelAggregator Service

The TravelAggregator service is a travel-related information aggregator, built on the .NET 8 framework. It efficiently gathers and presents travel data from various sources, offering a unified and convenient experience for users.

## Features:

### 1. .NET 8 Framework:
The service is developed using the `.NET 8`, taking advantage of its modern features and capabilities for robust and efficient application development.

### 2. Caching Mechanism:
To enhance performance and reduce response times, TravelAggregator incorporates a caching mechanism. This feature helps store frequently accessed data, reducing the need to fetch it from external sources repeatedly.

### 3. Basic Authentication:
The service implements `Basic Authentication` to ensure that only authorized users can access sensitive travel information. This authentication method requires a valid username and password for access, adding an extra layer of protection to the service.

## Usage:

To interact with the TravelAggregator service, clients must adhere to the following guidelines:

### Authentication:
Before accessing specified endpoints, clients need to provide valid credentials using `Basic Authentication`. This involves including the appropriate Authorization header in the HTTP request.

Example Authorization Header:
```
Authorization: Basic dXNlcm5hbWU6cGFzc3dvcmQ=
```
