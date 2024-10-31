namespace food_delivery_management.Contract.Response
{
    public class AddResturantResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Cuisine { get; set; }
        public string Location { get; set; }
        public float Rating { get; set; }
        public bool IsOpen { get; set; }
        public decimal MinimumOrder { get; set; }
        public int EstimatedDeliveryTime { get; set; }
    }
}
