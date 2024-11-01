using food_delivery_management.Model;
using System.ComponentModel.DataAnnotations;

namespace food_delivery_management.Contract.Request
{
    public class AddOrderRequest
    {
        [Required(ErrorMessage = "Restaurant Id is required.")]
        public Guid RestaurantId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string CustomerName { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in the format xxx-xxx-xxxx")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Delivery address is required.")]
        public string DeliveryAddress { get; set; }

        [Required]
        public List<OrderItem> Items { get; set; }
    }
}
