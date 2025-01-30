# CartonCaps.Referral.Api

[![Swagger](https://img.shields.io/badge/API-Docs-brightgreen)](https://localhost:5001/index.html)


A **CQRS-based ASP.NET Core Web API** for supporting the new Invite Friends feature of the Carton Caps mobile application. It allows you to use the previously assigned referral code and generate deferred deep links to share with your friends.

---

## **Features**
- ✅ **RESTful API** with OpenAPI documentation
- ✅ **CQRS (Command-Query Responsibility Segregation)** pattern
- ✅ **Unit testing with xUnit, AutoFixture, NSubstitute, and FluentAssertions**
- ✅ **Swagger UI for API documentation**

---

## 🔧 **Installation & Setup**
### **Prerequisites**
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)


### **Clone the Repository**
```sh
git clone https://github.com/jameskite/CartonCaps.Referral.Api.git
```
### **Navigate to Project Folder**
```sh
cd CartonCaps.Referral.Api
```
### **Run the API**
```sh
dotnet run --project CartonCaps.Referral.Api
```
### **Swagger API Documentation**
Once the API is running, open
```bash
https://localhost:5001/index.html
```
OR for the OpenAPI spec
```bash
https://localhost:5001/swagger/v1/swagger.json
```
---
## **Testing**
Run unit test from main solution folder
```sh
dotnet test
```
