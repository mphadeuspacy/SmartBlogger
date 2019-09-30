using System;
using System.Collections;
using System.Collections.Generic;
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
        public async Task GetAllByFilterAsync_WhenGetAllAsyncFilterIsNull_ThenThrowBusinessException()
        {
            // Arrange
            GetAllAsyncFilter getAllAsyncFilter = null;
           
            // Act & Assert
            Assert.ThrowsAsync<BusinessException>( () => _blogService.GetAllByFilterAsync(getAllAsyncFilter));
        } 
        #endregion
        //public async Task GetAllByFilterAsync_WhenGetAllAsyncFilterTakeValueIs0_ThenReturnAllBlogs()
        //{
        //    // Arrange
        //    var getAllAsyncFilter = null
        //    // Act 

        //    // Assert
        //}

        [OneTimeTearDown]
        public void TearDownAfterAllTestRuns()
        {
            Shutdown();
        }
    }
}
