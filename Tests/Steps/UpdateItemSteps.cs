using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantBilling.AcceptanceTests.Context;
using RestaurantBilling.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RestaurantBilling.AcceptanceTests.Steps
{
    [Binding]
    public sealed class UpdateItemSteps
    {
        private OrderContext _orderContext;
        public UpdateItemSteps(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

   
        [Given(@"I update a single maincourse item from an existing order")]
        public void GivenIUpdateASingleMaincourseItemFromAnExistingOrder()
        {
            new AddOrderSteps(_orderContext).GivenIOrderAStarterAndAMains();
            var orderId = _orderContext.order.GetOrderId();

            var itemToUpdate = new Item("Veg Katsu Curry", ItemType.Mains);
            _orderContext.billingService.UpdateItem(orderId, itemToUpdate);
        }

        [Given(@"I update a single starter item from an existing order")]
        public void GivenIUpdateASingleStarterItemFromAnExistingOrder()
        {
            new AddOrderSteps(_orderContext).GivenIOrderAStarterAndAMains();
            var orderId = _orderContext.order.GetOrderId();

            var itemToUpdate = new Item("Corn Fritters", ItemType.Starter);
            _orderContext.billingService.UpdateItem(orderId, itemToUpdate); 

        }

        [Given(@"I update multiple items from an existing order")]
        public void GivenIUpdateMultipleItemsFromAnExistingOrder()
        {
            new AddOrderSteps(_orderContext).GivenIOrderTwoStartersTwoMains();
            var orderId = _orderContext.order.GetOrderId();
            var totalCost = _orderContext.billingService.TotalCost(orderId);

           List<Item> itemsToUpdate = new List<Item>()
            {
              new Item("Corn Soup",ItemType.Starter),
             new Item("Veg Green Thai Curry",ItemType.Mains),
            };
            foreach (var item in itemsToUpdate)
                _orderContext.billingService.UpdateItem(orderId, item);
        }



        [Then(@"Order Not found exception is thrown")]
        public void ThenOrderNotFoundExceptionIsThrown()
        {
            var itemToUpdate = new Item("Unknown Item", ItemType.Mains);
            IBillingService billingService = new BillingService();
            Assert.ThrowsException<OrderNotFoundException>(() => billingService.UpdateItem(_orderContext.orderId, itemToUpdate));

        }


        [Given(@"I do not update any items from an existing order")]
        public void GivenIDoNotUpdateAnyItemsFromAnExistingOrder()
        {
            new AddOrderSteps(_orderContext).GivenIOrderAStarterAndAMains();
            var orderId = _orderContext.order.GetOrderId();
        }




    }
}
