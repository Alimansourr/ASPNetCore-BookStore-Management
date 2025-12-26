using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Advanced.Models;

namespace Project_Advanced.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add the DbSet for the all entities
        public DbSet<Book> Books { get; set; }

        public DbSet<CartItem> CartItems { get; set; }
       public DbSet<Order> Orders { get; set; }
       public DbSet<OrderItem> OrderItems { get; set; }
    }

}
