using AutoMapper;
using Demo_Hotel_Listing.Repository;
using food_delivery_management.Contract.Request;
using food_delivery_management.Contract.Response;
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

        public ResturantController(IMapper mapper, IResturantRepository resturantRepository)
        {
            this._mapper = mapper;
            this._resturantRepository = resturantRepository;
        }


        [HttpPost]
        public async Task<ActionResult<AddResturantResponse>> PostResturant(AddResturantRequest addResturantRequest)
        {

            //var resturant = new Resturant
            //{
            //    Id = Guid.NewGuid(), 
            //    Name = resturantRequest.Name,
            //    Cuisine = "DefaultCuisine", 
            //    Location = resturantRequest.Location,
            //    Rating = resturantRequest.Rating,
            //    IsOpen = resturantRequest.IsOpen,
            //    MinimumOrder = 0 
            //};
            var resturant = _mapper.Map<Resturant>(addResturantRequest);


            await _resturantRepository.AddAsync(resturant);

            var resturantResponse = _mapper.Map<AddResturantResponse>(resturant);
            //var resturantResponse = new AddResturantResponse
            //{
            //    Id = resturant.Id,
            //    Name = resturant.Name,
            //    Location = resturant.Location,
            //    Rating = resturant.Rating,
            //    IsOpen = resturant.IsOpen
            //};

            return CreatedAtAction("GetResturant", new { id = resturant.Id }, resturantResponse);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddResturantResponse>>> GetResturant()
        {
            var resturant = await _resturantRepository.GetAllAsync();
            var records = _mapper.Map<List<AddResturantResponse>>(resturant);
            return Ok(records);
        }
    }
}
