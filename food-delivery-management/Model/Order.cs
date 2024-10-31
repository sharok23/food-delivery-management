using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using food_delivery_management.Model;
using Food_Delivery_Management.constant;

namespace Food_Delivery_Management.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Resturant))]
        public Guid RestaurantId { get; set; }

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Phone { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}

