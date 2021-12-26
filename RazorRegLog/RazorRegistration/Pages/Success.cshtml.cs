using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorRegistration.Pages
{
    public class SuccessModel : PageModel
    {
        [BindProperty]
        public string logmessage { get; set; }
        [BindProperty]
        public string Regmessage { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                logmessage = "Login Successfull!";
            }
            else
            {
                Regmessage = "Register Successfull!";
            }
        }
    }
}
