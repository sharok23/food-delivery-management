using Food_Delivery_Management.Model;


namespace Demo_Hotel_Listing.Repository
{
    public interface IResturantRepository : IGenericRepository<Resturant>
    {
        Task<Resturant> GetDetails(int id);
    }
}
