using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Nls.SmartBlogger.Core.DomainServices;
using Nls.SmartBlogger.Core.Filters;
using Nls.SmartBlogger.EfPersister.Entities;
using Nls.SmartBlogger.Mvc.ViewModels;
using Nls.SmartBlogger.Mvc.ViewModels.Blog;

namespace Nls.SmartBlogger.Mvc.Controllers
{
    //[Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        private readonly ICloudBlobStorageService _cloudBlobStorageService;

        public BlogController(IBlogService blogService, ICloudBlobStorageService cloudBlobStorageService)
        {
            _blogService = blogService;

            _cloudBlobStorageService = cloudBlobStorageService;
        }

        public async Task<ActionResult> Index(GetAllByFilterInput input)
        {
            IList<Blog> blogs = await _blogService.GetAllByFilterAsync(input);

            var blogListViewModel = new BlogListViewModel
            (
                blogs
            );

            return View(blogListViewModel);
        }

        public ActionResult Create()
        {
            var allCloudBlobUriList = _cloudBlobStorageService.GetBlobUriListForAccountContainer
            (
                "nlsaccount",
                "smart-blogger-images",
                "R6BkV3TZmcPx/l2loaulp9imd0wlFuQXZRhs2H9/5v+VN4UaswIl6vhZ+6AZOtcdFlZBmghnOQg/aXASW3xIFw=="
            );

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}