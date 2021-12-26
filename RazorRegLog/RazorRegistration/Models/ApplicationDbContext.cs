using Microsoft.EntityFrameworkCore;

namespace RazorRegistration.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<UserInfo> userInfo { get; set; }
    }
}
