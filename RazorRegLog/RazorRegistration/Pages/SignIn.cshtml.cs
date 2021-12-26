using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorRegistration.Models;
using System.Linq;

namespace RazorRegistration.Pages
{
    public class SignInModel : PageModel
    { 
       
        private readonly ApplicationDbContext context;
        public string message;

        [BindProperty]
        public UserInfo account { get; set; }
        public SignInModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("email") != null ) {
            return RedirectToPage("index");
            }
            account = new UserInfo();
            return Page();
        }
        public IActionResult OnPost()
        {
            var user = context.userInfo.SingleOrDefault(x => x.Email.Equals(account.Email));
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(account.Password, user.Password))
                {
                    HttpContext.Session.SetString("email", user.Email);
                    HttpContext.Session.SetString("firstname", user.FirstName);
                    return RedirectToPage("success");
                }
            }
            message = "Invalid Credentials!";
            return Page();
        }  
    }
}
