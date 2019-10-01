using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Moq;
using Nls.SmartBlogger.Common.Exceptions;
using Nls.SmartBlogger.Core.DomainServices;
using Nls.SmartBlogger.Core.Filters;
using Nls.SmartBlogger.EfPersister;
using Nls.SmartBlogger.EfPersister.Abstracts;
using Nls.SmartBlogger.EfPersister.Entities;
using Nls.SmartBlogger.EfPersister.Repositories;
using SmartBlogger.Tests.Common;
using SmartBlogger.UnitTests.Modules;
using NUnit.Framework;
using Shouldly;

namespace SmartBlogger.UnitTests.Nls.SmartBlogger.Core.DomainServices
{
    [TestFixture]
    public class BlogServiceTests : TestBase<InfrastructureUnitTestsModule>
    {
        private IBlogService _blogService;

        [OneTimeSetUp]
        public void InitializePerClassInstance()
        {
            _blogService = Resolve<IBlogService>();
        }

        [Test]
        public void CanCreateBlogServiceInstance()
        {
            // Assert 
            _blogService.ShouldNotBeNull();
        }

        #region OnFailure
        [Test]
        public void CreateBlogService_WhenBlogRepositoryIsNull_ThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BlogService(null));
        }

        [Test]
        public void GetAllByFilterAsync_WhenGetAllAsyncFilterIsNull_ThenThrowBusinessException()
        {
            // Arrange
            GetAllAsyncFilter getAllAsyncFilter = null;
           
            // Act & Assert
            Assert.ThrowsAsync<BusinessException>( async() => await _blogService.GetAllByFilterAsync(getAllAsyncFilter));
        }
        #endregion

        #region OnSuccess
        [Test]
        public async Task GetAllByFilterAsync_WhenGetAllAsyncFilterTakeValueIs0_ThenReturnAllBlogs()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var mockBlogRepository = new Mock<IBlogRepository>();

            IList<Blog> blogList = FakeBlogs();

            mockBlogRepository
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(blogList);

            int expectedResult = blogList.Count;

            var getAllAsyncFilter = new GetAllAsyncFilter(0);

            // Act 
            var actualResult = await _blogService.GetAllByFilterAsync(getAllAsyncFilter);

            // Assert
            actualResult.Count.ShouldBe(expectedResult);
        }

        private IList<Blog> FakeBlogs()
        {
            return new List<Blog>
            {
                new Blog { BlogId = 1 },
                new Blog { BlogId = 2 },
                new Blog { BlogId = 3 },
                new Blog { BlogId = 4 },
                new Blog { BlogId = 5 },
                new Blog { BlogId = 6 },
                new Blog { BlogId = 7 },
                new Blog { BlogId = 8 },
                new Blog { BlogId = 9 },
                new Blog { BlogId = 10 }
            };
        }

        #endregion

        [OneTimeTearDown]
        public void TearDownAfterAllTestRuns()
        {
            Shutdown();
        }
    }
}
