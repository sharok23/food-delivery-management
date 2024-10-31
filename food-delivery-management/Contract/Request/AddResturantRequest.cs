using System.ComponentModel.DataAnnotations;

namespace food_delivery_management.Contract.Request
{
    public class AddResturantRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cuisine is required.")]
        public string Cuisine { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public float Rating { get; set; }

        [Required(ErrorMessage = "IsOpen status is required.")]
        public bool IsOpen { get; set; }
        public decimal MinimumOrder { get; set; }
        public int EstimatedDeliveryTime { get; set; }
    }
}
