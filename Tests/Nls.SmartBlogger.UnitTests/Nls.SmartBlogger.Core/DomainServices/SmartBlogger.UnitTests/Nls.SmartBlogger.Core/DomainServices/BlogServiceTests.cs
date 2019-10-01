using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Nls.SmartBlogger.Common.Exceptions;
using Nls.SmartBlogger.Core.DomainServices;
using Nls.SmartBlogger.Core.Filters;
using Nls.SmartBlogger.EfPersister.Abstracts;
using Nls.SmartBlogger.EfPersister.Entities;
using SmartBlogger.Tests.Common;
using SmartBlogger.UnitTests.Modules;
using NUnit.Framework;
using Shouldly;
using SmartBlogger.Tests.Common.Builders;

namespace SmartBlogger.UnitTests.Nls.SmartBlogger.Core.DomainServices
{
    [TestFixture]
    public class BlogServiceTests : TestBase<InfrastructureUnitTestsModule>
    {
        private IBlogService _blogService;

        private readonly BlogBuilder _blogBuilder = new BlogBuilder();

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
        public async Task GetAllByFilterAsync_WhenGetAllAsyncFilterTakeValueIs0AndBlogsExistInTheDataStore_ThenReturn0Blogs()
        {
            // Arrange
            var mockBlogRepository = new Mock<IBlogRepository>();

            IList<Blog> blogList = _blogBuilder.BuildBlogs;

            mockBlogRepository
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(blogList);

            int expectedResult = 0;

            var getAllAsyncFilter = new GetAllAsyncFilter(0);

            // Act 
            var actualResult = await new BlogService(mockBlogRepository.Object).GetAllByFilterAsync(getAllAsyncFilter);

            // Assert
            actualResult.Count.ShouldBe(expectedResult);
        }

        [Test]
        public async Task GetAllByFilterAsync_WhenGetAllAsyncFilterTakeValueIs3AndBlogsExistInTheDataStore_ThenReturnFirst3Blogs()
        {
            // Arrange
            var mockBlogRepository = new Mock<IBlogRepository>();

            IList<Blog> blogList = _blogBuilder.BuildBlogs;

            mockBlogRepository
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(blogList);

            int expectedResult = 3;

            var getAllAsyncFilter = new GetAllAsyncFilter(3);

            // Act 
            var actualResult = await new BlogService(mockBlogRepository.Object).GetAllByFilterAsync(getAllAsyncFilter);

            // Assert
            actualResult.Count.ShouldBe(expectedResult);

            actualResult.Single(first => first.BlogId == 1).ShouldNotBeNull();

            actualResult.Single(second => second.BlogId == 2).ShouldNotBeNull();

            actualResult.Single(third => third.BlogId == 3).ShouldNotBeNull();
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
