using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebAssignment3.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")] 
        public string FirstName { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
