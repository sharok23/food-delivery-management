using food_delivery_management.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_Delivery_Management.Model
{
    public class Resturant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Cuisine { get; set; }
        public string Location { get; set; }
        public float Rating { get; set; }
        public bool IsOpen { get; set; }
        public int EstimatedDeliveryTime { get; set; }
        public decimal MinimumOrder { get; set; }
        public int totalOrders { get; set; }
        public decimal revenue { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
