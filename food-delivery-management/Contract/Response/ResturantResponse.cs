namespace food_delivery_management.Contract.Response
{
    public class ResturantResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public double Rating { get; set; }
        public int EstimatedDeliveryTime { get; set; }
        public decimal MinimumOrder { get; set; }
    }
}
