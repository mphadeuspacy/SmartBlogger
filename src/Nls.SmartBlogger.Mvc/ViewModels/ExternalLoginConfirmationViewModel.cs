using System.ComponentModel.DataAnnotations;

namespace Nls.SmartBlogger.Mvc.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
