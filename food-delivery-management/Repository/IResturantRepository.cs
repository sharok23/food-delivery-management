using food_delivery_management.Contract.Response;
using Food_Delivery_Management.Model;


namespace food_delivery_management.Repository
{
    public interface IResturantRepository : IGenericRepository<Resturant>
    {
        Task<Resturant> GetDetails(Guid id);
        Task<IEnumerable<Resturant>> GetFilteredRestaurantsAsync(string cuisine, string location, float? rating, bool? isOpen);
        Task<RestaurantAnalyticsResponse> GetAnalyticsAsync(Guid restaurantId);
    }
}
