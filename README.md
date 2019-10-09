# SmartBlogger
Just a simple blogging web app. Once completed, the idea is to have a really smart blogging functionality.
This will be a work in progress as the projects evolves & adds more functionalities until it becomes really smart.


Solution Projects:
1. Nls.SmartBlogger.Common
- Shared code such as global setting, constants, enums etc
2. Nls.SmartBlogger.Core
- Domain entities & services sit here, driven by business requirements.
3. Nls.SmartBlogger.EfPersister
- Data access layer, for database access.
4. Nls.SmartBlogger.Mvc
- Presentation layer for populating visually the blogging app functionality.

Project Implementation Frameworks, Tools, & Platform:
1. .Net Framework 4.7.2
2. Visual Studio 2019 Community
3. Microsoft Azure SQL Database
4. Microsoft Azure Blog Storage
5. ASP.NET MVC 5
6. Entity Framework 6

OUTSTANDING REQUIREMENTS:

Due to time constraints, & having no resources for development such as a capabale machine (As had to give bad one used before to DVT),
some of the requirements could not be completed in the time constraint given, namely below:

1. No slugs implementation.
2. CRUD, although services layer complete that the Mvc calls, not complete integration has been completed. Create & Read pretty much complete.
3. Details page for the Blog is not complete although it has been integrated into the controller & services.
4. Cleanup of client side content such as css used for blogs is not bundled & made shippable.
4. No proper end to end testing has been completed although we do have some unit test automation implemented.
5. No Validation implementation from front side to back end.

NOTES: 

Because of the time constraints, some of the best practices have been left out, listed in the TODOs below.
Also some of the CRUD implementation have not been integrated to the Mvc App as yet, although service for these
have been implemented. Proper end to end test have not been complted as well, some functionality might be a bit buggy
at this time as implementation was done chasing lost time & on a none dev ready machine.

TODOs:

1. Add Logging such as NLog, Log4net etc
2. Add Effort for in-memory integration test implementation for Database
3. Slugs implementations & Tags.
4. Add Validation for input, maybe use FluentValidation, Specification pattern etc.
5. DTos with Automapper or custom extensions for mappings between entities & presentation objects.
6. Exclusion of REST Api layer.
7. Security considerations, for one addint custom error class for production exception handlers.
8. Store keys, connectiionString passwords etc into enviroment varibale, or even better Azure Vaults for security.

Some of the Technologies, Methologies, Principles, Patterns for best practices design.

1. DI using Autofac IoC
2. Azure SQL Database for Data Store
4. Azure BLOB storage for Image storage
4. Nunit for automated tests implementation
5. Moq for mocking objects for unit tests
6. Multi-Layered Architecture
7. SOLID principles.
8. Software & Architectural patterns, such as repositories, Unit of Work, Mvc etc

Running the Application.
1. Open solution file using Visual Studio 2019 located in the root of the project folder by either a double click or click & press ENTER.
2. Open Package Manager Console.
3. Select the database project called 'Nls.SmartBlogger.EfPersister' under 'Default project'.
4. Type & Run 'Update-Database' command to locally create the SQL Database using migration scripts. Since this is hosted on Azure, might not be required.
Otherwise, a connectionString can be changed to point to any accessible SQL Database server.
(NB: since the Database is deployed on Azure, the Client IP will have to be manually added.)
5. After Migration have ran. press f5 in Visual Studio to run the project.
6. On first run, using local authenticate, register as a new user if not already have login credentials, & then login in.







