using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineCore
{
    class VendingMachineApp
    {
        public static Inventory item = new Inventory();
        public static bool purchasedItem = false;
        private static bool exactChange = false;

        static void Main()
        {
            ConsoleKeyInfo input;

            Console.WriteLine("Do you want exact change mode? (Y/N)");
            input = Console.ReadKey();

            if (input.Key.Equals(ConsoleKey.Y))
                exactChange = true;

            List<Inventory> products = new List<Inventory>();
            Inventory cola = new Inventory("cola", 1.00);
            Inventory chips = new Inventory("chips", 0.50);
            Inventory candy = new Inventory("candy", 0.65);

            item.LoadInventory(cola, 5, products);
            item.LoadInventory(chips, 3, products);
            item.LoadInventory(candy, 2, products);

            Display display = new Display(products);

            do
            {
                display.DisplayMainScreen(display, purchasedItem);

                input = Console.ReadKey();

                ProcessKeyInput(input, display, products);

            } while (input.Key != ConsoleKey.D3);
        }

        private static void ProcessKeyInput(ConsoleKeyInfo input, Display dis, List<Inventory> inventory)
        {
            Coins coin = new Coins();
            purchasedItem = false;

            if (input.Key == ConsoleKey.D0)
            {
                coin = dis.InsertCoin();
                dis = dis.AddChange(dis, coin);
            }
            else if (input.Key == ConsoleKey.D1)
            {
                dis.DisplayInventory(dis, inventory);
                input = Console.ReadKey();
                ProcessProductInput(ConvertInputToKey(input), dis, inventory);
            }
            else if (input.Key == ConsoleKey.D2)
            {
                dis.ReturnChange(dis);
            }
        }

        private static void ProcessProductInput(int input, Display dis, List<Inventory> inventory)
        {            
            List<Inventory.InventoryDisplayItem> products = new List<Inventory.InventoryDisplayItem>();

            products = item.GetInventoryList(inventory, dis.StartingItems);

            foreach(Inventory.InventoryDisplayItem i in products)
            {
                if (input == i.id)
                {
                    item.Name = i.name;
                    item.Value = i.value;
                    break;
                }                    
            }

            if(dis.CanBuyProduct(dis, item, exactChange) && item.GetInventoryCount(item, inventory) > 0)
            {
                item.BuyProduct(item.Name, inventory, dis);
                purchasedItem = true;
            }
        }

        //This is only for ProcessProductInput for converting the keyinput to a int Id to find the selected product
        private static int ConvertInputToKey(ConsoleKeyInfo input)
        {
            if (char.IsDigit(input.KeyChar))
                return int.Parse(input.KeyChar.ToString());
            else
                return -1;
        }
    }
}
