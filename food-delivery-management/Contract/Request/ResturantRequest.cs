namespace food_delivery_management.Contract.Request
{
    public class ResturantRequest
    {
        public string Cuisine { get; set; }
        public string Location { get; set; }
        public double? Rating { get; set; }
        public bool? IsOpen { get; set; }
    }
}
