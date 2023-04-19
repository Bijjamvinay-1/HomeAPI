using bijjam_API.Model;
using Microsoft.EntityFrameworkCore;

namespace bijjam_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        } 
         public DbSet<Home>Homes { get; set; }



    }
}
