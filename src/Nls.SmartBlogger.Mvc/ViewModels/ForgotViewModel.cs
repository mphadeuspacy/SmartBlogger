using System.ComponentModel.DataAnnotations;

namespace Nls.SmartBlogger.Mvc.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
