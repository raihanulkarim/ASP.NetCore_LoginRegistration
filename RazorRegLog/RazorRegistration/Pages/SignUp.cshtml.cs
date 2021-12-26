using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorRegistration.Models;
using System.Linq;

namespace RazorRegistration.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly ApplicationDbContext context;
        [BindProperty]
        public UserInfo account { get; set; }
        public string msg { get; set; }
        [BindProperty]
        public string passCheck { get; set; }
        public SignUpModel(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                return RedirectToPage("index");
            }
            account = new UserInfo();
            return Page();
        }
        public IActionResult OnPost()
        {
            var user = context.userInfo.FirstOrDefault(x=> x.Email.Equals(account.Email));
            if (user == null)
            {
                if (account.Password.Length < 6 || account.Password.Length > 15 )
                {

                    msg = "Password Should be between 6 -15 characters!";
                    return Page();
                }
                else
                {
                    if (account.Password == passCheck)
                    {
                        account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                        context.userInfo.Add(account);
                        context.SaveChanges();
                        return RedirectToPage("success");
                    }
                    else
                    {
                        msg = "Password does not match!";
                        return Page();
                    }

                }
            }
            else
            {
                msg = "Email already exists!";
                return Page();

            }
        }
    }
}
