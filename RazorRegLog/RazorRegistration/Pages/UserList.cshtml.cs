using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorRegistration.Models;

namespace RazorRegistration.Pages
{
    public class UserListModel : PageModel
    {
        private readonly RazorRegistration.Models.ApplicationDbContext _context;

        public UserListModel(RazorRegistration.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserInfo> UserInfo { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return RedirectToPage("signin");
            }
            UserInfo = await _context.userInfo.ToListAsync();
            return Page();
        }
    }
}
