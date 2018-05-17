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
            Inventory chips = new Inventory("chips", 0.50);

            products = item.LoadInventory(cola, 5);
            products = item.LoadInventory(chips, 3, products);

            Assert.Equal(5, item.GetInventoryCount(cola, products));
            Assert.Equal(3, item.GetInventoryCount(chips, products));
        }

        [Fact]
        public void BuyProductTests()
        {
            List<Inventory> products = new List<Inventory>();
            Inventory item = new Inventory();
            Inventory cola = new Inventory("cola", 1.00);
            Inventory chips = new Inventory("chips", 0.50);

            products = item.LoadInventory(cola, 5);
            products = item.LoadInventory(chips, 3, products);

            Display dis = new Display();
            Coins coin = new Coins(5.670, 1.75);
            dis.AddChange(dis, coin);
            dis.AddChange(dis, coin);
            dis.AddChange(dis, coin);
            dis.AddChange(dis, coin);

            string name = products.Where(i => i.Name == "chips").First().Name;

            Assert.True(dis.CanBuyProduct(dis, chips, false));

            products = item.BuyProduct(name, products, dis);

            Assert.Equal(0.50, dis.ChangeReturned);
            Assert.Equal(2, item.GetInventoryCount(chips, products));
            Assert.False(dis.CanBuyProduct(dis, chips, false));
        }

        [Fact]
        public void GetInventoryListTests()
        {
            List<Inventory.InventoryDisplayItem> displayProducts = new List<Inventory.InventoryDisplayItem>();
            List<Inventory> products = new List<Inventory>();
            Inventory item = new Inventory();
            Inventory cola = new Inventory("cola", 1.00);
            Inventory chips = new Inventory("chips", 0.50);
            Inventory candy = new Inventory("candy", 0.65);

            item.LoadInventory(cola, 5, products);
            item.LoadInventory(chips, 3, products);
            item.LoadInventory(candy, 2, products);

            Display dis = new Display(products);

            displayProducts = item.GetInventoryList(products, dis.StartingItems);

            Assert.Equal(5, Convert.ToInt32(displayProducts.Where(i => i.name.Equals(cola.Name)).Single().stock));

            products = item.UnloadInventory(candy, 2, products);
            displayProducts = item.GetInventoryList(products, dis.StartingItems);

            Assert.Equal("OUT OF STOCK", displayProducts.Where(i => i.name.Equals(candy.Name)).Single().stock);
        }
    }
}
