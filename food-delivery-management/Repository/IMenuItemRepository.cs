using food_delivery_management.Model;

namespace food_delivery_management.Repository
{
    public interface IMenuItemRepository : IGenericRepository<MenuItem>
    {
        Task<decimal> GetMenuItemPrice(Guid menuItemId);
        Task<MenuItem> GetByIdAsync(Guid menuItemId);
        Task UpdateAsync(MenuItem menuItem);
    }
}
