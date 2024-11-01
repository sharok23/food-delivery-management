using AutoMapper;
using food_delivery_management.Contract.Request;
using food_delivery_management.Contract.Response;
using food_delivery_management.Model;
using Food_Delivery_Management.Model;


namespace Food_Delivery_Management.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AddResturantRequest, Resturant>();
            CreateMap<Resturant, AddResturantResponse>();
            CreateMap<AddMenuItemRequest, MenuItem>();
            CreateMap<MenuItem, AddMenuItemResponse>();
            CreateMap<AddOrderRequest, Order>();
            CreateMap<Order, AddOrderResponse>();
        }
    }
}
