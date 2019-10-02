using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Nls.SmartBlogger.Common.Enums;

namespace Nls.SmartBlogger.Mvc.ViewModels.Blog
{
    public class CreateBlobViewModel
    {
        public CreateBlobViewModel(){}

        public EfPersister.Entities.Blog Blog { get; set; }

        public string SelectedTag { get; set; }

        public List<SelectListItem> GetBlogsTagSelectListItems()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Select Tag",
                    Value = string.Empty,
                    Selected = SelectedTag == null
                }
            };

            list.AddRange(Enum.GetValues(typeof(AppEnums.TagEnum))
                .Cast<AppEnums.TagEnum>()
                .Select(tag =>
                    new SelectListItem
                    {
                        Text = $"{tag}",
                        Value = tag.ToString(),
                        Selected = tag.ToString() == SelectedTag
                    })
            );

            return list;
        }
    }
}
