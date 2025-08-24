# KwikNesta.Contracts

---
[![NuGet](https://img.shields.io/nuget/v/KwikNesta.Contracts.Core.svg)](https://www.nuget.org/packages/KwikNesta.Contracts.Core)  
[![NuGet Downloads](https://img.shields.io/nuget/dt/KwikNesta.Contracts.Core.svg)](https://www.nuget.org/packages/KwikNesta.Contracts.Core)

---
A common library of enums, message contracts, and base types shared across services.  
It exists to standardize communication and reduce duplication in distributed systems.

---
## Contents
- **Enums**
  - `AuditDomain`, `AuditAction`, `EmailType`, `OtpType`, ...
- **Messages**
  - `AuditLog`, `NotificationMessage`, ...
- **Static Methods**
  - `AuditLog.Initialize(string actionBy, Guid domainId, AuditDomain domain, AuditAction action);`
  - `NotificationMessage.Initialize(string email, string name, string otp, EmailType type, int expirationInMinutes = 10);`
  - `NotificationMessage.Initialize(string email, string name, EmailType type, string? reason);`  
- **Extension Methods**
  - `ToEmailType(this OtpType type);` 
- **Pagination**
  - `enumerableList.Paginate(pageNumber: 2, pageSize: 10);`

---
## Installation
```bash
dotnet add package KwikNesta.Contracts.Core
```

---
## ⚖ License

This project is licensed under the MIT License - see the LICENSE file for details.