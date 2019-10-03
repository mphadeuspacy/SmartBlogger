# SmartBlogger
Just a simple yet smart blogging web app...

Project Implementation Frameworks, Tools, & Platform:
1. .Net Framework 4.7.2
2. Visual Studio 2019 Community
3. Microsoft Azure

Running the Application.
1. Open solution file using Visual Studio 2019 located in the root of the project folder by either a double click or click & press ENTER.
2. Open Package Manager Console
3. Select the database project called 'Nls.SmartBlogger.EfPersister' under 'Default project'.
4. Type & Run 'Update-Database' command to locally create the SQL Database using migration scripts. Since this is hosted on Azure, might not be required.
Otherwise, a connectionString can be changed to point to any accessible SQL Database server.
(NB: since the Database is deployed on Azure, the Client IP will have to be manually added.)
5. After Migration have ran. press f5 in Visual Studio to run the project.
6. On first run, using local authenticate, register as a new user if not already have login credentials, & then login in.

Some of the Technologies, Methologies, Principles, Patterns for best practices design.
1. DI using Autofac IoC
2. Azure SQL Database for Data Store
4. Azure BLOB storage for Image storage
4. Nunit for automated tests implementation
5. Moq for mocking objects for unit tests
6. Multi-Layered Architecture
7. SOLID principles.
8. Software & Architectural patterns.

NOTES: 
Because of the time constraints, some of the best practices have been left out, listed in the TODOs below.
Also some of the CRUD implementation have not been integrated to the Mvc App as yet, although service for these
have been implemented. Proper end to end test have not been complted as well, some functionality might be a bit buggy
at this time as implementation was done chasing lost time & on a none dev ready machine.

TODO:
1. Add Logging such as NLog, Log4net etc
2. Add Effort for in-memory integration test implementation for Database
3. Slugs implementations & Tags.
4. Add Validation for input, maybe use FluentValidation, Specification pattern etc.
5. DTos with Automapper or custom extensions for mappings between entities & presentation objects.
6. Exclusion of REST Api layer.
7. Security considerations, for one addint custom error class for production exception handlers.
8. Store keys, connectiionString passwords etc into enviroment varibale, or even better Azure Vaults for security.

@Url.Content(Model.Blogs.FirstOrDefault().ImageUrl)


