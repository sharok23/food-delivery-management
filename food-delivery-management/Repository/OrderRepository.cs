using Food_Delivery_Management.Data;
using Food_Delivery_Management.Model;
using Microsoft.EntityFrameworkCore;

namespace food_delivery_management.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly FoodDeliveryManagementDbContext _context;

        public OrderRepository(FoodDeliveryManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.Items) 
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
