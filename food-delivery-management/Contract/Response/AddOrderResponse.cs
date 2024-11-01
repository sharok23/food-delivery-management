using food_delivery_management.Model;
using System.ComponentModel.DataAnnotations;

namespace food_delivery_management.Contract.Response
{
    public class AddOrderResponse
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public string CustomerName { get; set; }

        public string Phone { get; set; }

        public string DeliveryAddress { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
