# Project structure

I'm most familiar with naming as described in:
https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture

Having that said through assignment requirements given and initial project references setup I assumed following:
  - Data project is the fundamental one as it is not referencing other projects -> "Core"
  - Core is where I will put DTOs, services, and implementations of interfaces from Data project as it should contain business logic -> "Infrastructure"
  
