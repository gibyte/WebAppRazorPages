using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppRazorPages.Pages
{
    public class SendMessageModel : PageModel
    {
        [BindProperty]
        public string? Message { get; set; }
        public void OnGet()
        {
        }
    }
}
