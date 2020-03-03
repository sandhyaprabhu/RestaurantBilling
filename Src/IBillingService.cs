using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBilling.Src
{
  public interface IBillingService
    {
        Order AddOrder(List<Item> items);
        void RemoveItem(int orderId, Item item);

        void UpdateItem(int orderId, Item item);

        double TotalCost(int orderId);


    }
}
