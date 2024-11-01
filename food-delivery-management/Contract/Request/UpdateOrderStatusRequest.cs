using Food_Delivery_Management.constant;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace food_delivery_management.Contract.Request
{
    public class UpdateOrderStatusRequest
    {
        [Required(ErrorMessage = "OrderStatus is required.")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderStatus OrderStatus { get; set; }
    }
}
