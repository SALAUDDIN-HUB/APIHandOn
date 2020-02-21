using System;
using System.Collections.Generic;

namespace HandsOnPractice.Models
{
    public partial class Order
    {
        public string Ordersid { get; set; }
        public DateTime Ordersdate { get; set; }
        public DateTime? Deliverydate { get; set; }
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
