using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model
{
    public class OrderModel
    {
        public string OrderName { get; set; }
        public string OrderNumber { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public string Address { get; set; }
    }
}
