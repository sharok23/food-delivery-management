using AutoMapper;
using food_delivery_management.Contract.Request;
using food_delivery_management.Contract.Response;
using food_delivery_management.exception;
using food_delivery_management.Exception;
using food_delivery_management.Repository;
using Food_Delivery_Management.constant;
using Food_Delivery_Management.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace food_delivery_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IResturantRepository _restaurantRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMapper _mapper;

        public OrderController(
            IOrderRepository orderRepository,
            IResturantRepository restaurantRepository,
            IMenuItemRepository menuItemRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _restaurantRepository = restaurantRepository;
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<AddOrderResponse>> PlaceOrder(AddOrderRequest request)
        {
            
            var restaurant = await _restaurantRepository.GetDetails(request.RestaurantId);
            if (restaurant == null)
                throw new NotFoundException("Restaurant",request.RestaurantId);
            if (!restaurant.IsOpen)
                throw new BadRequestException("Restaurant is closed.");


            decimal totalOrderAmount = 0;
            foreach (var item in request.Items)
            {
                var price = await _menuItemRepository.GetMenuItemPrice(item.MenuItemId);
                totalOrderAmount += item.Quantity * price;
                var menuItem = await _menuItemRepository.GetByIdAsync(item.MenuItemId);
                if (menuItem != null)
                {
                    menuItem.OrderCount += item.Quantity;
                    menuItem.Revenue += item.Quantity * price;
                    await _menuItemRepository.UpdateAsync(menuItem);
                }
            }

            if (totalOrderAmount < restaurant.MinimumOrder)
                throw new BadRequestException($"Order amount must be at least {restaurant.MinimumOrder}.");


            if (!Regex.IsMatch(request.Phone, @"^\d{3}-\d{3}-\d{4}$"))
                throw new BadRequestException("Invalid phone number format. Expected format: XXX-XXX-XXXX");


            var order = _mapper.Map<Order>(request);
            order.OrderTime = DateTime.UtcNow;

            
            await _orderRepository.AddAsync(order);
            restaurant.totalOrders += 1;
            restaurant.revenue += totalOrderAmount;
            await _restaurantRepository.UpdateAsync(restaurant);
            var response = _mapper.Map<AddOrderResponse>(order);

            return Ok(response);
        }


        [HttpPut("{id}/status")]
        public async Task<ActionResult<UpdateOrderStatusResponse>> UpdateOrderStatus(Guid id, UpdateOrderStatusRequest request)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
                throw new NotFoundException("Order",id);

            order.Status = request.OrderStatus;
            order.StatusTime = DateTime.UtcNow;

            await _orderRepository.UpdateAsync(order);

            var response = new UpdateOrderStatusResponse
            {
                OrderStatus = request.OrderStatus,
                Time = order.StatusTime
            };

            return Ok(response);
        }

    }
}
