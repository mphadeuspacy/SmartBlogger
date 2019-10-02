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

        public CreateBlobViewModel(IList<string> blobImageUriList)
        {
            BlobImageUriList = blobImageUriList;
        }

        public EfPersister.Entities.Blog Blog { get; set; }

        public IList<string> BlobImageUriList { get; }

        public string SelectedImageUri { get; set; }

        public List<SelectListItem> GetBlobImageUriSelectListItems()
        {
            var selectListItemsInitial = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Select Image Uri",
                    Value = string.Empty,
                    Selected = SelectedImageUri == null
                }
            };

            var selectListItems = BlobImageUriList
                .Select(imageUri => new SelectListItem
                {
                    Value = imageUri,
                    Text = imageUri,
                    Selected = imageUri.ToString() == SelectedImageUri
                }
            ).ToList();

            return selectListItemsInitial.Union(selectListItems).ToList();
        }

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
                        Text = tag.ToString(),
                        Value = tag.ToString(),
                        Selected = tag.ToString() == SelectedTag
                    })
            );

            return list;
        }
    }
}
