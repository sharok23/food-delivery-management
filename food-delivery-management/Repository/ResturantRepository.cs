using Demo_Hotel_Listing.Repository;
using Food_Delivery_Management.Data;
using Food_Delivery_Management.Model;

namespace Food_Delivery_Management.Repository
{
    public class ResturantRepository : GenericRepository<Resturant>, IResturantRepository
    {
        private readonly FoodDeliveryManagementDbContext _context;
        public ResturantRepository(FoodDeliveryManagementDbContext context) : base(context)
        {
            this._context = context;
        }

        public Task<Resturant> GetDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
