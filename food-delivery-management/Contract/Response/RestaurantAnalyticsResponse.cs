namespace food_delivery_management.Contract.Response
{
    public class RestaurantAnalyticsResponse
    {
        public string Period { get; set; }
        public int TotalOrders { get; set; }
        public decimal Revenue { get; set; }
        public double AverageDeliveryTime { get; set; }
    }
}
