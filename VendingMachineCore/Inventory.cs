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

        public List<Inventory> BuyProduct(string name, List<Inventory> inventory, Display dis)
        {
            Inventory itemPurchased = inventory.Where(i => i.Name == name).First();
            inventory = UnloadInventory(itemPurchased, 1, inventory);
            dis.ChangeInserted -= itemPurchased.Value;
            dis.ReturnChange(dis);
            return inventory;
        }        
    }
}
