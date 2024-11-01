using Food_Delivery_Management.constant;
using System.ComponentModel.DataAnnotations;

namespace food_delivery_management.Contract.Response
{
    public class UpdateOrderStatusResponse
    {
        public OrderStatus OrderStatus { get; set; }
        public DateTime Time { get; set; }
    }
}
