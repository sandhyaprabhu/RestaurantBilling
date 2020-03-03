using RestaurantBilling.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBilling.AcceptanceTests.Context
{
  public  class OrderContext
    {
        //public double totalPrice;
        //public double updatedPrice;
        //public double menuPrice;
        public IBillingService billingService;
        public Order order;
        public int orderId;
    }
}
