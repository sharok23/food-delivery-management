using Food_Delivery_Management.Data;
using Food_Delivery_Management.Model;
using Microsoft.EntityFrameworkCore;
using food_delivery_management.Repository;
using food_delivery_management.Contract.Response;

namespace Food_Delivery_Management.Repository
{
    public class ResturantRepository : GenericRepository<Resturant>, IResturantRepository
    {
        private readonly FoodDeliveryManagementDbContext _context;
        public ResturantRepository(FoodDeliveryManagementDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Resturant> GetDetails(Guid id)
        {
            return await _context.Resturants.FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task UpdateAsync(Resturant entity)
        {
            _context.Set<Resturant>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Resturant>> GetFilteredRestaurantsAsync(string cuisine, string location, float? rating, bool? isOpen)
        {
            var query = _context.Resturants.AsQueryable();

            if (!string.IsNullOrEmpty(cuisine))
            {
                query = query.Where(r => r.Cuisine == cuisine);
            }

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(r => r.Location == location);
            }

            if (rating.HasValue)
            {
                query = query.Where(r => r.Rating >= rating.Value);
            }

            if (isOpen.HasValue)
            {
                query = query.Where(r => r.IsOpen == isOpen.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<decimal> GetMenuItemPrice(Guid menuItemId)
        {
            var menuItem = await _context.MenuItems.FirstOrDefaultAsync(m => m.Id == menuItemId);
            return menuItem?.Price ?? 0;
        }

        public async Task<RestaurantAnalyticsResponse> GetAnalyticsAsync(Guid restaurantId)
        {
            var restaurant = await _context.Resturants
                .Include(r => r.Orders) 
                .FirstOrDefaultAsync(r => r.Id == restaurantId);

            if (restaurant == null) return null;

            var totalOrders = restaurant.totalOrders;
            var revenue = restaurant.revenue; 
            var averageDeliveryTime = restaurant.EstimatedDeliveryTime; 

            
            var firstOrderDate = await _context.Orders
                .Where(o => o.RestaurantId == restaurantId)
                .OrderBy(o => o.OrderTime)
                .Select(o => o.OrderTime)
                .FirstOrDefaultAsync();


            var period = firstOrderDate != default ? firstOrderDate.ToString("yyyy-MM") : DateTime.UtcNow.ToString("yyyy-MM");

            var response = new RestaurantAnalyticsResponse
            {
                Period = period,
                TotalOrders = totalOrders,
                Revenue = revenue,
                AverageDeliveryTime = averageDeliveryTime
            };

            return response;
        }
    }
}
