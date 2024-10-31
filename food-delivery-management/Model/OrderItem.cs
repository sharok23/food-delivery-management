namespace food_delivery_management.Model
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public string SpecialInstructions { get; set; }
    }
}
