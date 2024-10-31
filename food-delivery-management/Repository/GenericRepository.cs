using Food_Delivery_Management.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo_Hotel_Listing.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FoodDeliveryManagementDbContext _context;

        public GenericRepository(FoodDeliveryManagementDbContext context)
        {
            this._context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

       
    }
}