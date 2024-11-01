using System.ComponentModel.DataAnnotations;

namespace food_delivery_management.Contract.Request
{
    public class AddMenuItemRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
