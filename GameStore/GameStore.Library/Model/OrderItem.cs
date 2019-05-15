using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Library
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public GameOrder GameOrder { get; set; }
        public Game Game { get; set; }
    }
}
