namespace RestaurantManagementSystem.Models
{
    public class MenuItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public MenuItem(int itemId, string name, string category, decimal price)
        {
            ItemId = itemId;
            Name = name;
            Category = category;
            Price = price;
            IsAvailable = true;
        }
    }
}