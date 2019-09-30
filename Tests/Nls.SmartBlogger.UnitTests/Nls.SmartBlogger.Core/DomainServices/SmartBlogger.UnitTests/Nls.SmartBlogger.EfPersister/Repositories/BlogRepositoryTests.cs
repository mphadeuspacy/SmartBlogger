using Nls.SmartBlogger.EfPersister.Abstracts;
using NUnit.Framework;
using Shouldly;
using SmartBlogger.Tests.Common;
using SmartBlogger.UnitTests.Modules;

namespace SmartBlogger.UnitTests.Nls.SmartBlogger.EfPersister.Repositories
{
    [TestFixture]
    public class BlogRepositoryTests : TestBase<InfrastructureUnitTestsModule>
    {
        private IBlogRepository _blogRepository;

        [OneTimeSetUp]
        public void InitializePerClassInstance()
        {
            _blogRepository = Resolve<IBlogRepository>();
        }

        [Test]
        public void CanCreateBlogRepositoryInstance()
        {
            // Assert 
            _blogRepository.ShouldNotBeNull();
        }

        [OneTimeTearDown]
        public void TearDownAfterAllTestRuns()
        {
            Shutdown();
        }
    }
}
