using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBilling.Src
{
    public class BillingService : IBillingService
    {

        private Dictionary<int, Order> orders = new Dictionary<int, Order>();

        public Order AddOrder(List<Item> items)
        {
           Order order = new Order(items);
            orders.Add(order.GetOrderId(), order);
            return order;
        }

        public void RemoveOrder(int orderId)
        {
            orders.Remove(orderId);

        }

        public void RemoveItem(int orderId, Item item)
        {
            Order order;
            orders.TryGetValue(orderId, out order);
            if (order == null)
                throw new OrderNotFoundException();

            var orderedItems = order.GetItems();
            if (orderedItems.Exists(i => i.GetItemName() == item.GetItemName()))
               orderedItems.RemoveAll(i => i.GetItemName() == item.GetItemName());
            else
                throw new ItemNotFoundException();

        }



        public void UpdateItem(int orderId, Item item)
        {
            Order order;
            orders.TryGetValue(orderId, out order);
            if (order == null)
                throw new OrderNotFoundException();

            order.GetItems().Add(item);
        }


        public double TotalCost( int orderId)
        {
            Order order;
            double totalCost;
            orders.TryGetValue(orderId, out order);
            if (order == null)
                throw new OrderNotFoundException();
            else
                totalCost = GetPrice(order.GetItems());

            return totalCost;
        }

        private double GetPrice(List<Item> items)
        {
            double totalCost = 0;


            items.ForEach(i =>
            {
                if (i.GetItemType() == ItemType.Starter)
                    totalCost = totalCost + 4.40;
                else
                    totalCost = totalCost + 7;

            });


            return totalCost;
        }

    }
}
