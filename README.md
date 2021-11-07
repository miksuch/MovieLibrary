## Project structure

I'm most familiar with naming as described in:
https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture

Having that said through assignment requirements given and initial project references setup I assumed following:
  - Data project is the fundamental one as it is not referencing other projects -> "Core"
  - Core is where I will put DTOs, services, and implementations of interfaces from Data project as it should contain business logic -> "Infrastructure"
  
## Notes

Used templating across "data access stack" to save on some CRUD logic code repetition. 

Tests are obviously not extensive but just as a example - I chose to test filtering logic of MovieRepository to have some room to play with parametrized tests and database setup - for each test new context with no data is created.

Rudimentary commit history.
  
## Data

Haven't modified given entity classes, but I did modify MovieLibraryContext by adding constructors.

### Interfaces 

Supposed to define possible operations on entities. 

For efficiency filtering logic should ideally be as close to database as possible so there is IMovieRepository method defined which accepts filtering parameters given.

## Core

### Models

DTOs as entities are troublesome for passing to and from user. Also for a little shortcut some mapping logic is attached to them.

### Repositories

Implementations of Data interfaces.

Filtering implementation with paging isn't perfect but I at least tried to make it a bit more testable by splitting filtering into smaller testable methods.

### Services

Interfaces and their implementations to make better use of dependency injection and allow for mocking and testing.
Services make use of mapping logic attached to DTOs instead of dedicated mapper and they don't do that much outside of passing data from/to repositories.

## Api

### Controllers

ErrorController with combination of built-in exception handler to hopefully stop exception messages from leaking to client.

Filtering endpoint takes list of ids representing categories as there are some problem of sort if this is list of reference types, swagger tries to put them into body of GET ( should be avoided ), if it is put in query then parsing doesn't quite get it - I have encountered this before and I think list of ids is quite cost efficient so didn't think of this much. 

