using api.Entity;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<Photo> Photos { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Size> Sizes { get; set; }

        public virtual DbSet<Status> Status { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<User> Users { get; set; }

        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);
             List<IdentityRole> roles = new List<IdentityRole>
             {
                 new IdentityRole
                 {
                     Name = "Admin",NormalizedName = "ADMIN"
                 },
                 new IdentityRole
                 {
                     Name = "Customer",NormalizedName="CUSTOMER"
                 }
             };
             modelBuilder.Entity<IdentityRole>().HasData(roles);
         }*/
    }
}
