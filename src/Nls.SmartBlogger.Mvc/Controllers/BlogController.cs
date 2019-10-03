using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Nls.SmartBlogger.Common;
using Nls.SmartBlogger.Core.DomainServices;
using Nls.SmartBlogger.Core.Filters;
using Nls.SmartBlogger.EfPersister.Entities;
using Nls.SmartBlogger.Mvc.ViewModels.Blog;
using static System.Web.Configuration.WebConfigurationManager;

namespace Nls.SmartBlogger.Mvc.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        private readonly ICloudBlobStorageService _cloudBlobStorageService;

        public BlogController
        (
            IBlogService blogService, 
            ICloudBlobStorageService cloudBlobStorageService
        )
        {
            _blogService = blogService;

            _cloudBlobStorageService = cloudBlobStorageService;
        }

        public async Task<ActionResult> Index(GetAllByFilterInput input)
        {
            IList<Blog> blogs = await _blogService.GetAllByFilterAsync(input);

            var blogListViewModel = new BlogListViewModel
            {
                Blogs = blogs
            };

            return View(blogListViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(CreateBlobViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBlobViewModel blogViewModel)
        {
            try
            {                
                // TODO: ModelState validation not working as expected, although values required are not empty
                var blogToCreate = new Blog
                {
                    Title = blogViewModel.Blog.Title,
                    AuthorId = User.Identity.GetUserName(),
                    ImageUrl = blogViewModel.SelectedImageUri,
                    Blurb = blogViewModel.Blog.Blurb,
                    TagId = int.TryParse(blogViewModel.SelectedTag, out int tagIdResult) ? tagIdResult : (int?) null, // TODO: Retrieve enum value based on selection
                    CreationTime = DateTime.UtcNow,
                    CreatorUserId = User.Identity.GetUserName()
                };
                
                await _blogService.CreateAsync(blogToCreate);

                return RedirectToAction("Index");

            }
            catch (DataException)
            { 
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(CreateBlobViewModel());
        }

        #region Helpers
        private CreateBlobViewModel CreateBlobViewModel()
        {
            IList<string> blobImageUriList = _cloudBlobStorageService.GetBlobUriListForAccountContainer
            (
                AppSettings[SmartBloggerConsts.AzureStorageAccount],
                AppSettings[SmartBloggerConsts.AzureStorageContainer],
                AppSettings[SmartBloggerConsts.AzureStorageKey]
            );

            return new CreateBlobViewModel(blobImageUriList);
        } 
        #endregion
    }
}