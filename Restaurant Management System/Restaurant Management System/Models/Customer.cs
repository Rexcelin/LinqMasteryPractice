namespace RestaurantManagementSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        public Customer(int customerId, string name, string phoneNo, string email)
        {
            CustomerId = customerId;
            Name = name;
            PhoneNo = phoneNo;
            Email = email;
        }
    }
}