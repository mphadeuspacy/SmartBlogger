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

        private Mock<IBlogRepository> _mockBlogRepository;

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
        public async Task GetAllByFilterAsync_WhenGetAllAsyncFilterSkipAndTakeValuesAre0AndBlogsExistInTheDataStore_ThenReturn0Blogs()
        {
            // Arrange
            IList<Blog> blogList = _blogBuilder.BuildBlogs;

            _mockBlogRepository = new Mock<IBlogRepository>();

            _mockBlogRepository
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(blogList);

            int expectedResult = 0;

            var getAllAsyncFilter = new GetAllAsyncFilter(skip: 0, take:0);

            // Act 
            var actualResult = await new BlogService(_mockBlogRepository.Object).GetAllByFilterAsync(getAllAsyncFilter);

            // Assert
            actualResult.Count.ShouldBe(expectedResult);
        }

        [Test]
        public async Task GetAllByFilterAsync_WhenGetAllAsyncFilterSkipIs0AndTakeIs3AndBlogsExistInTheDataStore_ThenReturnFirst3Blogs()
        {
            // Arrange
            IList<Blog> blogList = _blogBuilder.BuildBlogs;

            _mockBlogRepository = new Mock<IBlogRepository>();

            _mockBlogRepository
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(blogList);

            int expectedResult = 3;

            var getAllAsyncFilter = new GetAllAsyncFilter(skip: 0, take: 3);

            // Act 
            var actualResult = await new BlogService(_mockBlogRepository.Object).GetAllByFilterAsync(getAllAsyncFilter);

            // Assert
            actualResult.Count.ShouldBe(expectedResult);

            actualResult.Single(first => first.BlogId == 1).ShouldNotBeNull();

            actualResult.Single(second => second.BlogId == 2).ShouldNotBeNull();

            actualResult.Single(third => third.BlogId == 3).ShouldNotBeNull();
        }

        public async Task GetAllByFilterAsync_WhenGetAllAsyncFilterTakeAndSkipAre3AndBlogsExistInTheDataStore_ThenReturnNext4To6Blogs()
        {
            // Arrange
            IList<Blog> blogList = _blogBuilder.BuildBlogs;

            _mockBlogRepository
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(blogList);

            int expectedResult = 3;

            var getAllAsyncFilter = new GetAllAsyncFilter(skip: 3, take: 3);

            // Act 
            var actualResult = await new BlogService(_mockBlogRepository.Object).GetAllByFilterAsync(getAllAsyncFilter);

            // Assert
            actualResult.Count.ShouldBe(expectedResult);

            actualResult.Single(four => four.BlogId == 4).ShouldNotBeNull();

            actualResult.Single(five => five.BlogId == 5).ShouldNotBeNull();

            actualResult.Single(six => six.BlogId == 6).ShouldNotBeNull();
        }

        #endregion

        [OneTimeTearDown]
        public void TearDownAfterAllTestRuns()
        {
            Shutdown();
        }
    }
}
