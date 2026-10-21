using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantManagementSystem.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        public List<OrderItem> Items { get; set; }

        public decimal GrandTotal
        {
            get { return Items.Sum(item => item.LineTotal); }
        }

        public Order(int orderId, int? customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
            CreatedAt = DateTime.Now;
            Status = "Placed";
            Items = new List<OrderItem>();
        }
    }
}