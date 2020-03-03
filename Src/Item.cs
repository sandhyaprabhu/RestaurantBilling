using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBilling.Src
{
    public enum ItemType
    {
        Starter,
        Mains

    }
    public class Item
    {
        private string itemName;
        private ItemType itemType;

        public Item(string itemName, ItemType itemType)
        {
            this.itemName = itemName;
            this.itemType = itemType;
        }

        public string GetItemName()
        {
            return itemName;
        }

        public ItemType GetItemType()
        {
            return itemType;
        }
    }
}




