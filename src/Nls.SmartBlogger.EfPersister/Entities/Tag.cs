using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Nls.SmartBlogger.Common.Enums;
using Nls.SmartBlogger.Common.Exceptions;

namespace Nls.SmartBlogger.EfPersister.Entities
{
    /// <summary>
    /// For simplicity, we will assume no blog can have same based on resolving
    /// the uri slugs
    /// </summary>
    [Table("Tags")]
    public class Tag : Enumeration
    {
        #region EnumValues
        public static Tag TagExampleOne = new Tag(0x1, nameof(TagExampleOne).ToLowerInvariant());
        public static Tag TagExampleTwo = new Tag(0x2, nameof(TagExampleTwo).ToLowerInvariant());
        public static Tag TagExampleThree = new Tag(0x4, nameof(TagExampleThree).ToLowerInvariant());
        public static Tag TagExampleFour = new Tag(0x8, nameof(TagExampleFour).ToLowerInvariant());
        #endregion

        public static IEnumerable<Tag> ListOfAllPredefinedTags => new[] { TagExampleOne, TagExampleTwo, TagExampleThree, TagExampleFour };

        #region TableColumns
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TagKey { get; set; }
        public string TagName { get; set; }
        public int BlogId { get; set; }
        #endregion

        public virtual Blog Blog { get; set; }

        public Tag() { }

        public Tag(int value, string name)
            : base(value, name)
        {
            TagKey = value;

            TagName = name;
        }

        public static Tag FromName(string name)
        {
            var registrationStatus = ListOfAllPredefinedTags
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (registrationStatus == null)
            {
                throw new BusinessException($"Possible values for Tag: {string.Join(",", ListOfAllPredefinedTags.Select(s => s.Name))}");
            }

            return registrationStatus;
        }

        public static Tag FromKey(int value)
        {
            var registrationStatus = ListOfAllPredefinedTags.SingleOrDefault(s => s.Value == value);

            if (registrationStatus == null)
            {
                throw new BusinessException($"Possible values for Tag: {string.Join(",", ListOfAllPredefinedTags.Select(s => s.Name))}");
            }

            return registrationStatus;
        }
    }
}
