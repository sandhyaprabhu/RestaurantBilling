using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBilling.Src
{
   public class Order
    {
        private List<Item> items;
        private int orderId;
        private static int maxOrderId = 0;
        public Order(List<Item> items)
        {
            orderId = GetMaxOrderId();
            this.items = new List<Item>(items);
        }

        public List<Item> GetItems()
        {
            return items;
        }

        public int GetOrderId()
        {
            return orderId;
        }



        private static int GetMaxOrderId()
        {
            maxOrderId++;
            return maxOrderId;
        }
    }
}
