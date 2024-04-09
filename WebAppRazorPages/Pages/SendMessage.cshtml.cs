using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppRazorPages.Pages
{
    [Authorize]
    public class SendMessageModel : PageModel
    {
        [BindProperty]
        public string? Message { get; set; }

        [BindProperty]
        public string? UserName { get; set; }

        public void OnGet()
        {
            UserName = User?.Identity?.Name;
        }
    }
}
