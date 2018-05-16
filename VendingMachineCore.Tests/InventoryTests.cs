using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace VendingMachineCore.Tests
{
    public class InventoryTests
    {
        [Fact]
        public void LoadInventoryTests()
        {
            Inventory item = new Inventory();

            Assert.True(item.LoadInventory(new Inventory("cola", 1.00), 5).Where(i => i.Name == "cola").Count() == 5);
            Assert.False(item.LoadInventory(new Inventory("cola", 1.00), 5).Where(i => i.Name == "cola").Count() == 4);
        }

        [Fact]
        public void UnloadInventoryTests()
        {
            List<Inventory> products = new List<Inventory>();
            Inventory item = new Inventory("cola", 1.00);

            products = item.LoadInventory(item, 5);
            Assert.True(item.UnloadInventory(item, 1, products).Where(i => i.Name == "cola").Count() == 4);
            Assert.True(item.UnloadInventory(item, 5, products).Where(i => i.Name == "cola").Count() == 0);
        }

        [Fact]
        public void GetInventoryTests()
        {
            List<Inventory> products = new List<Inventory>();
            Inventory item = new Inventory();
            Inventory cola = new Inventory("cola", 1.00);
            Inventory chips = new Inventory("chips", 0.65);

            products = item.LoadInventory(cola, 5);
            products = item.LoadInventory(chips, 3, products);

            Assert.Equal(5, item.GetInventory(cola, products));
            Assert.Equal(3, item.GetInventory(chips, products));
        }
    }
}
