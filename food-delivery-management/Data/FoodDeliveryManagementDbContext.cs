using food_delivery_management.Model;
using Food_Delivery_Management.constant;
using Food_Delivery_Management.Model;
using Microsoft.EntityFrameworkCore;

namespace Food_Delivery_Management.Data
{
    public class FoodDeliveryManagementDbContext : DbContext
    {
        public FoodDeliveryManagementDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Order>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),                    
                    v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v) 
                )
                .HasMaxLength(50);  
        }
    }
}
