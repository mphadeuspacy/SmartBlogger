using System;
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
        public string AuthorId { get; set; }
        [Required]
        [Display(Name = "Blob Image Uri")]
        public string ImageUrl { get; set; }
        [Required]
        public string Blurb { get; set; }
        [Display(Name = "Tag")]
        public int? TagId { get; set; }

        public DateTime? CreationTime { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public string LastModifierUserId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
