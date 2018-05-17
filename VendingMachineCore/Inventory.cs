using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineCore
{
    public class Inventory
    {
        public string Name;
        public double Value;

        public Inventory(string name = "", double value = 0)
        {
            Name = name;
            Value = value;
        }

        public List<Inventory> LoadInventory(Inventory item, int amountToLoad, List<Inventory> inventory = null)
        {
            if (inventory == null)
                inventory = new List<Inventory>();

            for (int i = 0; i < amountToLoad; i++)
            {
                inventory.Add(item);
            }

            return inventory;
        }

        public List<Inventory> UnloadInventory(Inventory item, int amountToUnload, List<Inventory> inventory)
        {
            for (int i = 0; i != amountToUnload; i++)
            {
                inventory.Remove(item);
            }

            return inventory;
        }

        public int GetInventoryCount(Inventory item, List<Inventory> inventory)
        {
            return inventory.Where(i => i.Name == item.Name).Count();
        }

        public double GetItemValue(string name, List<Inventory> inventory)
        {
            foreach(Inventory i in inventory)
            {
                if (i.Name.Equals(name))
                    return i.Value;
            }

            return 0;
        }

        public List<InventoryDisplayItem> GetInventoryList(List<Inventory> inventory, List<Inventory> inventoryStartingItems)
        {
            List<InventoryDisplayItem> displayItems = new List<InventoryDisplayItem>();
            InventoryDisplayItem displayItem = new InventoryDisplayItem();
            Inventory item = new Inventory();
            int stock;

            string[] tempArray = inventoryStartingItems.Select(i => i.Name).ToArray();

            for (int i = 0; i < tempArray.Count(); i++)
            {
                displayItem.id = i;
                displayItem.name = tempArray[i];
                displayItem.value = GetItemValue(displayItem.name, inventory);
                item.Name = displayItem.name;
                stock = GetInventoryCount(item, inventory);
                if (stock == 0)
                    displayItem.stock = "OUT OF STOCK";
                else
                    displayItem.stock = stock.ToString();

                displayItems.Add(displayItem);
            }

            return displayItems;
        }

        public List<Inventory> BuyProduct(string name, List<Inventory> inventory, Display dis)
        {
            Inventory itemPurchased = inventory.Where(i => i.Name == name).First();
            inventory = UnloadInventory(itemPurchased, 1, inventory);
            dis.ChangeInserted -= itemPurchased.Value;
            //dis.ReturnChange(dis);
            return inventory;
        }        

        public struct InventoryDisplayItem
        {
            public int id;
            public string name;
            public string stock;
            public double value;

            public InventoryDisplayItem(int id, string name, string stock, double value)
            {
                this.id = id;
                this.name = name;
                this.stock = stock;
                this.value = value;
            }
        }
    }
}
