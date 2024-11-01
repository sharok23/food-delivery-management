using food_delivery_management.Model;
using food_delivery_management.Repository;
using Food_Delivery_Management.Data;

public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
{
    private readonly FoodDeliveryManagementDbContext _context;

    public MenuItemRepository(FoodDeliveryManagementDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<decimal> GetMenuItemPrice(Guid menuItemId)
    {
        var menuItem = await _context.MenuItems.FindAsync(menuItemId);
        return menuItem?.Price ?? 0;
    }

    public async Task<MenuItem> GetByIdAsync(Guid menuItemId)
    {
        return await _context.MenuItems.FindAsync(menuItemId);
    }

    public async Task UpdateAsync(MenuItem menuItem)
    {
        _context.MenuItems.Update(menuItem);
        await _context.SaveChangesAsync();
    }
}