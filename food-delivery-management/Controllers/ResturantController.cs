using AutoMapper;
using food_delivery_management.exception;
using food_delivery_management.Contract.Request;
using food_delivery_management.Contract.Response;
using food_delivery_management.Model;
using food_delivery_management.Repository;
using Food_Delivery_Management.Model;
using Microsoft.AspNetCore.Mvc;

namespace food_delivery_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IResturantRepository _resturantRepository;
        private readonly IMenuItemRepository _menuItemRepository;

        public ResturantController(IMapper mapper, IResturantRepository resturantRepository, IMenuItemRepository menuItemRepository)
        {
            this._mapper = mapper;
            this._resturantRepository = resturantRepository;
            this._menuItemRepository = menuItemRepository;
        }


        [HttpPost]
        public async Task<ActionResult<AddResturantResponse>> PostResturant(AddResturantRequest addResturantRequest)
        {
            var resturant = _mapper.Map<Resturant>(addResturantRequest);


            await _resturantRepository.AddAsync(resturant);

            var resturantResponse = _mapper.Map<AddResturantResponse>(resturant);

            return Ok(resturantResponse);
        }

        [HttpGet]
        public async Task<ActionResult<GetResturantResponse>> GetResturant(GetResturantRequest getResturantRequest)
        {
            var restaurants = await _resturantRepository.GetFilteredRestaurantsAsync(
                getResturantRequest.Cuisine,
                getResturantRequest.Location,
                getResturantRequest.Rating,
                getResturantRequest.IsOpen
            );
            if (restaurants == null || !restaurants.Any())
            {
                throw new NotFoundException("resturant");
            }

            var mappedRestaurants = _mapper.Map<List<AddResturantResponse>>(restaurants);

            var response = new GetResturantResponse
            {
                Restaurants = mappedRestaurants
            };

            return Ok(response);
        }

        [HttpPost("menu-items")]
        public async Task<ActionResult<AddMenuItemResponse>> PostMenuItem(AddMenuItemRequest addMenuItemRequest)
        {
            var menuItem = _mapper.Map<MenuItem>(addMenuItemRequest);
            await _menuItemRepository.AddAsync(menuItem);
            var menuItemResponse = _mapper.Map<AddMenuItemResponse>(menuItem);
            return Ok(menuItemResponse);
        }

        [HttpGet("{id}/analytics")]
        public async Task<ActionResult<RestaurantAnalyticsResponse>> GetRestaurantAnalytics(Guid id)
        {
            var analytics = await _resturantRepository.GetAnalyticsAsync(id);

            if (analytics == null)
                throw new NotFoundException("Restaurant",id);

            return Ok(analytics);
        }
    }
}
