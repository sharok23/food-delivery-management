using Food_Delivery_Management.Model;

namespace food_delivery_management.Repository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetByIdAsync(Guid id); 
        Task UpdateAsync(Order order);
    }
}
