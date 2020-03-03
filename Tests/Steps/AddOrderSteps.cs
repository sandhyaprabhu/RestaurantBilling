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
    public sealed class AddOrderSteps
    {
        private OrderContext _orderContext;
        public AddOrderSteps(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        [Given(@"I order a starter and a mains")]
        public void GivenIOrderAStarterAndAMains()
        {
            List<Item> items = new List<Item>()
            {
                new Item("Vegetable Gyoza",ItemType.Starter),
                new Item("Tofu Pad Thai",ItemType.Mains),


            };

            IBillingService billingService = new BillingService();
            var order = billingService.AddOrder(items);

            _orderContext.order = order;
            _orderContext.billingService = billingService;
            
        }

        [Then(@"the total price should be (.*)")]
        public void ThenTheTotalPriceShouldBe(Double expectedTotal)
        {
            var orderId = _orderContext.order.GetOrderId();
            var actualCost= _orderContext.billingService.TotalCost(orderId);
            Assert.AreEqual(expectedTotal, actualCost);
            
        }


        [Given(@"I do not order any item")]
        public void GivenIDoNotOrderAnyItem()
        {
            List<Item> items = new List<Item>();
          

            IBillingService billingService = new BillingService();
            var order = billingService.AddOrder(items);

            _orderContext.order = order;
            _orderContext.billingService = billingService;
        }

        [Given(@"i order two starters, two mains")]
        public void GivenIOrderTwoStartersTwoMains()
        {
            List<Item> items = new List<Item>()
            {
                new Item("Vegetable Gyoza",ItemType.Starter),
                new Item("Veg Spring Rolls",ItemType.Starter),
                new Item("Tofu Pad Thai",ItemType.Mains),
                new Item("Vegetable Katsu Curry",ItemType.Mains),


            };

            IBillingService billingService = new BillingService();
            var order = billingService.AddOrder(items);

            _orderContext.order = order;
            _orderContext.billingService = billingService;
        }


        [Given(@"i order two same starters and one main")]
        public void GivenIOrderTwoStartersAndOneMain()
        {
            List<Item> items = new List<Item>()
            {
                new Item("Veg Spring Rolls",ItemType.Starter),
                new Item("Veg Spring Rolls",ItemType.Starter),
                new Item("Tofu Pad Thai",ItemType.Mains),


            };

            IBillingService billingService = new BillingService();
            var order = billingService.AddOrder(items);

            _orderContext.order = order;
            _orderContext.billingService = billingService;
        }


    }
}
