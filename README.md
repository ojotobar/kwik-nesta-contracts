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
  - `EnumMapper.Map<TSource, TTarget>(source)`
- **Pagination**
  - `enumerableList.Paginate(pageNumber: 2, pageSize: 10);`
- **Http Handlers 

---
## Installation
```bash
dotnet add package KwikNesta.Contracts.Core
```

## 🧩 HTTP Handlers Overview

This package provides helpful `HttpMessageHandler` implementations designed to improve resilience and request handling for service-to-service communication.

---

### 🔐 `ForwardAuthHeaderHandler`

Automatically forwards the **Authorization** header from the current HTTP context (when available) to outgoing requests.
Useful for propagating bearer tokens across internal service calls.

**Example:**

```csharp
services.AddTransient<ForwardAuthHeaderHandler>();

services.AddRefitClient<IUserServiceClient>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(servers.UserService);
    })
    .AddHttpMessageHandler<ForwardAuthHeaderHandler>();
```

This ensures every request made through `IUserServiceClient` includes the same `Authorization` header as the incoming HTTP request.

---

### 💤 `ServiceHttpClientWakeUpHandler`

Designed for scenarios where hosted services (e.g., on **Render** or other free-tier platforms) might be temporarily asleep.
This handler retries requests when a “wake-up” or non-JSON HTML response (like a Render loading page) is detected.

**Example:**

```csharp
services.AddTransient<ServiceHttpClientWakeUpHandler>();

services.AddHttpClient("PaymentService", client =>
{
    client.BaseAddress = new Uri(servers.PaymentService);
    client.Timeout = TimeSpan.FromSeconds(120);
})
.AddHttpMessageHandler<ServiceHttpClientWakeUpHandler>();
```

✅ Automatically retries and delays between attempts until a valid JSON response is received or the retry limit is reached.

---

### ⚙️ `ServiceRefitWakeUpHandler`

A Refit-compatible variant of the wake-up handler for use with strongly-typed Refit clients.
It should typically wrap the client **outermost** so that retries preserve all inner handler behavior (like auth forwarding).

**Example:**

```csharp
services.AddTransient<ForwardAuthHeaderHandler>();
services.AddTransient<ServiceRefitWakeUpHandler>();

services.AddRefitClient<IIdentityServiceClient>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(servers.IdentityService);
        c.Timeout = TimeSpan.FromSeconds(120);
    })
    .AddHttpMessageHandler(() => new ServiceRefitWakeUpHandler())
    .AddHttpMessageHandler<ForwardAuthHeaderHandler>();
```

Order matters:

* `ForwardAuthHeaderHandler` attaches the bearer token.
* `ServiceRefitWakeUpHandler` wraps and retries the whole request if the remote service is still “waking up”.

---

### 🧠 Summary

| Handler                          | Purpose                            | Typical Use                      |
| -------------------------------- | ---------------------------------- | -------------------------------- |
| `ForwardAuthHeaderHandler`       | Propagate auth tokens              | API gateway → downstream service |
| `ServiceHttpClientWakeUpHandler` | Retry for sleeping servers         | `HttpClientFactory` clients      |
| `ServiceRefitWakeUpHandler`      | Retry for sleeping servers (Refit) | Refit-based clients              |

---

**Pro tip:** Combine `ForwardAuthHeaderHandler` and `ServiceRefitWakeUpHandler` for maximum reliability in distributed service environments.


---
## ⚖ License

This project is licensed under the MIT License - see the LICENSE file for details.