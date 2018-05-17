using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineCore
{
    class VendingMachineApp
    {        
        static void Main()
        {
            ConsoleKeyInfo input;

            List<Inventory> products = new List<Inventory>();
            Inventory item = new Inventory();
            Inventory cola = new Inventory("cola", 1.00);
            Inventory chips = new Inventory("chips", 0.50);
            Inventory candy = new Inventory("candy", 0.65);

            item.LoadInventory(cola, 5, products);
            item.LoadInventory(chips, 3, products);
            item.LoadInventory(candy, 2, products);

            Display display = new Display(products);

            do
            {
                display.DisplayMainScreen(display);

                input = Console.ReadKey();

                ProcessKeyInput(input, display, products);

            } while (input.Key != ConsoleKey.D3);
        }

        private static void ProcessKeyInput(ConsoleKeyInfo input, Display dis, List<Inventory> inventory)
        {
            Coins coin = new Coins();

            if (input.Key == ConsoleKey.D0)
            {
                coin = dis.InsertCoin();
                dis = dis.AddChange(dis, coin);
            }
            else if (input.Key == ConsoleKey.D1)
            {
                dis.DisplayInventory(dis, inventory);
                Console.ReadKey();
            }
            else if (input.Key == ConsoleKey.D2)
            {
                dis.ReturnChange(dis);
            }
        }
    }
}
