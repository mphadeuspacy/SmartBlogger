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

        private readonly BlogRepositoryBuilder _blogRepositoryBuilder = new BlogRepositoryBuilder();

        private GetAllByFilterInput _getAllFilterInput;

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
            _getAllFilterInput = null;
           
            // Act & Assert
            Assert.ThrowsAsync<BusinessException>( async() => await _blogService.GetAllByFilterAsync(_getAllFilterInput));
        }
        #endregion

        #region OnSuccess
        [Test]
        public async Task GetAllByFilterAsync_WhenGetAllAsyncFilterSkipAndTakeValuesAre0AndBlogsExistInTheDataStore_ThenReturn0Blogs()
        {
            // Arrange
            IList<Blog> blogList = _blogBuilder.BuildBlogs;

            _mockBlogRepository = _blogRepositoryBuilder.BuildBlogRepositoryMock;

            _mockBlogRepository
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(blogList);

            int expectedResult = 0;

            _getAllFilterInput = new GetAllByFilterInput(skip:0, take:0);

            // Act 
            var actualResult = await new BlogService(_mockBlogRepository.Object).GetAllByFilterAsync(_getAllFilterInput);

            // Assert
            actualResult.Count.ShouldBe(expectedResult);
        }

        [Test]
        public async Task GetAllByFilterAsync_WhenGetAllAsyncFilterSkipIs0AndTakeIs3AndBlogsExistInTheDataStore_ThenReturnFirst3Blogs()
        {
            // Arrange
            IList<Blog> blogList = _blogBuilder.BuildBlogs;

            _mockBlogRepository = _blogRepositoryBuilder.BuildBlogRepositoryMock;

            _mockBlogRepository
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(blogList);

            int expectedResult = 3;

            _getAllFilterInput = new GetAllByFilterInput(skip: 0, take: 3);

            // Act 
            var actualResult = await new BlogService(_mockBlogRepository.Object).GetAllByFilterAsync(_getAllFilterInput);

            // Assert
            actualResult.Count.ShouldBe(expectedResult);

            actualResult.Single(first => first.BlogId == 1).ShouldNotBeNull();

            actualResult.Single(second => second.BlogId == 2).ShouldNotBeNull();

            actualResult.Single(third => third.BlogId == 3).ShouldNotBeNull();
        }

        [Test]
        public async Task GetAllByFilterAsync_WhenGetAllAsyncFilterTakeAndSkipAre3AndBlogsExistInTheDataStore_ThenReturnNext4To6Blogs()
        {
            // Arrange
            IList<Blog> blogList = _blogBuilder.BuildBlogs;

            _mockBlogRepository
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(blogList);

            int expectedResult = 3;

            _getAllFilterInput = new GetAllByFilterInput(skip: 3, take: 3);

            // Act 
            var actualResult = await new BlogService(_mockBlogRepository.Object).GetAllByFilterAsync(_getAllFilterInput);

            // Assert
            actualResult.Count.ShouldBe(expectedResult);

            actualResult.Single(four => four.BlogId == 4).ShouldNotBeNull();

            actualResult.Single(five => five.BlogId == 5).ShouldNotBeNull();

            actualResult.Single(six => six.BlogId == 6).ShouldNotBeNull();
        }

        [Test]
        public async Task GetAllByFilterAsync_WhenGetAllAsyncFilterSkipIs9AndTake3AndBlogsExistInTheDataStore_ThenReturn10thBlog()
        {
            // Arrange
            IList<Blog> blogList = _blogBuilder.BuildBlogs;

            _mockBlogRepository
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(blogList);

            int expectedResult = 1;

            _getAllFilterInput = new GetAllByFilterInput(skip: 9, take: 1);

            // Act 
            var actualResult = await new BlogService(_mockBlogRepository.Object).GetAllByFilterAsync(_getAllFilterInput);

            // Assert
            actualResult.Count.ShouldBe(expectedResult);

            actualResult.Single(ten => ten.BlogId == 10).ShouldNotBeNull();
        }

        #endregion

        [OneTimeTearDown]
        public void TearDownAfterAllTestRuns()
        {
            Shutdown();
        }
    }
}
