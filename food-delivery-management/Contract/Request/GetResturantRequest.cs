namespace food_delivery_management.Contract.Request
{
    public class GetResturantRequest
    {
        public string Cuisine { get; set; }
        public string Location { get; set; }
        public float? Rating { get; set; }
        public bool? IsOpen { get; set; }
    }
}
