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

        public DbSet<User> Users { get; set; }
        public DbSet<Filling> Fillings { get; set; }
        public DbSet<Biscuit> Biscuits { get; set; }
        public DbSet<Cookie> Cookies { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
