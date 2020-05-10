namespace MvcCustomerManager.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public int ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}