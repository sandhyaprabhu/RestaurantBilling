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
    public sealed class RemoveItemSteps
    {
        private OrderContext _orderContext;
        public RemoveItemSteps(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }


        [Given(@"I remove a single item from an existing order")]
        public void GivenIRemoveASingleItemFromAnExistingOrder()
        {
            new AddOrderSteps(_orderContext).GivenIOrderAStarterAndAMains();
            var orderId = _orderContext.order.GetOrderId();
            var totalCost = _orderContext.billingService.TotalCost(orderId);

            var itemToRemove = new Item("Tofu Pad Thai", ItemType.Mains);
       
            _orderContext.billingService.RemoveItem(orderId, itemToRemove);

        }


        [Given(@"I remove multiple items from an existing order")]
        public void GivenIRemoveMultipleItemsFromAnExistingOrder()
        {
            new AddOrderSteps(_orderContext).GivenIOrderTwoStartersTwoMains();
            var orderId = _orderContext.order.GetOrderId();
            var totalCost = _orderContext.billingService.TotalCost(orderId);

            List<Item> itemsToRemove = new List<Item>()
            {
              new Item("Vegetable Gyoza",ItemType.Starter),
             new Item("Vegetable Katsu Curry",ItemType.Mains),


            };
            foreach(var item in itemsToRemove)
            _orderContext.billingService.RemoveItem(orderId, item);
        }

      
    
        [Given(@"I update non existing item from an existing order")]
        [Given(@"I remove non existing item from an existing order")]
        public void GivenIRemoveNonExistingItemFromAnExistingOrder()
        {
            new AddOrderSteps(_orderContext).GivenIOrderAStarterAndAMains();
        }


        [Then(@"Item not found exception is thrown")]
        public void ThenItemNotFoundExceptionIsThrown()
        {
            var itemToRemove = new Item("Unknown Item", ItemType.Mains);
            var orderId = _orderContext.order.GetOrderId();
            Assert.ThrowsException<ItemNotFoundException>(() => _orderContext.billingService.RemoveItem(orderId, itemToRemove));

        }

        [Given(@"I do not remove any items from an existing order")]
        public void GivenIDoNotRemoveAnyItemsFromAnExistingOrder()
        {
            new AddOrderSteps(_orderContext).GivenIOrderAStarterAndAMains();
            var orderId = _orderContext.order.GetOrderId();

        }

        [Given(@"I update items from an non-existing order")]
        [Given(@"I remove items from an non-existing order")]
        public void GivenIRemoveItemsFromAnNon_ExistingOrder()
        {
           
            _orderContext.orderId = 0;
        }

        [Then(@"Order not found exception is thrown")]
        public void ThenOrderNotFoundExceptionIsThrown()
        {
            var itemToRemove = new Item("Unknown Item", ItemType.Mains);
            IBillingService billingService = new BillingService();
            Assert.ThrowsException<OrderNotFoundException>(() => billingService.RemoveItem(_orderContext.orderId, itemToRemove));

        }

        [Given(@"I remove a duplicate item from an existing order")]
        public void GivenIRemoveADuplicateItemFromAnExistingOrder()
        {
            
            new AddOrderSteps(_orderContext).GivenIOrderTwoStartersAndOneMain();
            var orderId = _orderContext.order.GetOrderId();


            var itemToRemove = new Item("Veg Spring Rolls", ItemType.Starter);

            _orderContext.billingService.RemoveItem(orderId, itemToRemove);
        }



    }
}
