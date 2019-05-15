using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Library
{
    public class GameOrder
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public StoreLocation GameStore { get; set; }
        public DateTime DateTime { get; set; }
    }
}
