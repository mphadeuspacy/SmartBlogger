using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Nls.SmartBlogger.Core.DomainServices;
using Nls.SmartBlogger.Core.Filters;
using Nls.SmartBlogger.EfPersister.Entities;
using Nls.SmartBlogger.Mvc.ViewModels;

namespace Nls.SmartBlogger.Mvc.Controllers
{
    //[Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<ActionResult> Index(GetAllBlobsFilter getAllBlobsFilter)
        {
            IList<Blog> blogs = await _blogService.GetAllByFilterAsync(getAllBlobsFilter);

            var blogListViewModel = new BlogListViewModel
            (
                blogs
            );

            return View(blogListViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}