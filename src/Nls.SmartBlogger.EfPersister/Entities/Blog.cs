using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nls.SmartBlogger.EfPersister.Entities
{
    [Table("Blogs")]
    public class Blog
    {
        public const int MaxNameLength = 32;

        public int BlogId { get; set; }
        [Required]
        [MaxLength(MaxNameLength)]
        public string Title { get; set; }
        public int AuthorId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Blurb { get; set; }

        public DateTime? CreationTime { get; set; }
        public int? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int? LastModifierUserId { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
