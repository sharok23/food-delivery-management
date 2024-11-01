namespace food_delivery_management.exception
{
    public class NotFoundException : System.Exception 
    {
        public NotFoundException(string name, object key)
            : base($"{name} with id ({key}) was not found")
        {
        }
        public NotFoundException(string name)
            : base($"{name} not found")
        {
        }
    }
}
