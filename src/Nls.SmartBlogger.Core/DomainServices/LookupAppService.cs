using System.Collections.Generic;
using System.Linq;
using Nls.SmartBlogger.Common.Dtos;
using Nls.SmartBlogger.EfPersister.Entities;

namespace Nls.SmartBlogger.Core.DomainServices
{
    public class LookupAppService
    {
        public static IList<ComboboxItemDto> GetTagComboboxItems()
        {
            return new List<ComboboxItemDto>
            (
                Tag.ListOfAllPredefinedTags
                    .Select(tag => new ComboboxItemDto(tag.Value.ToString("D"), tag.Name))
                    .ToList()
            );
        }
    }
}
