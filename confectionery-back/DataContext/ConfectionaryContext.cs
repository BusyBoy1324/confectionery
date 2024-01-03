using confectionery_back.Model;
using Microsoft.EntityFrameworkCore;

namespace confectionery_back.DataContext
{
    public class ConfectionaryContext : DbContext
    {
        public ConfectionaryContext(DbContextOptions<ConfectionaryContext> options)
            : base(options)
        {

        }

        public DbSet<User> ?Users { get; set; }
    }
}
