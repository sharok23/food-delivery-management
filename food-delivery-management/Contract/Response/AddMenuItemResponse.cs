namespace food_delivery_management.Contract.Response
{
    public class AddMenuItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
