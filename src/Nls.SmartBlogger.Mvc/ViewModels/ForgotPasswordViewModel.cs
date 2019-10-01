using System.ComponentModel.DataAnnotations;

namespace Nls.SmartBlogger.Mvc.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
