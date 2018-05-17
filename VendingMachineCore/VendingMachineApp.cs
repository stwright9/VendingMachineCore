using System;

namespace VendingMachineCore
{
    class VendingMachineApp
    {        
        static void Main()
        {
            ConsoleKeyInfo input;
            Display display = new Display();

            do
            {
                display.DisplayMainScreen(display);

                input = Console.ReadKey();

                ProcessKeyInput(input, display);

            } while (input.Key != ConsoleKey.D3);
        }

        private static void ProcessKeyInput(ConsoleKeyInfo input, Display dis)
        {
            Coins coin = new Coins();

            if (input.Key == ConsoleKey.D0)
            {
                coin = dis.InsertCoin();
                dis = dis.AddChange(dis, coin);
            }
        }
    }
}
