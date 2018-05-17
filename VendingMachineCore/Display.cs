using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineCore
{
    public class Display
    {
        public double ChangeInserted;
        public double ChangeReturned;
        public bool ExactChangeMode = false;
        public Dictionary<int, string> UserOptions;
        public List<Inventory> StartingItems;

        public Display(List<Inventory> startingItems = null, double changeInserted = 0, double changeReturned = 0)
        {
            ChangeInserted = changeInserted;
            ChangeReturned = changeReturned;
            UserOptions = new Dictionary<int, string>();
            UserOptions.Add(0, "Insert Coins");
            UserOptions.Add(1, "Display Products");
            UserOptions.Add(2, "Return Coins");
            UserOptions.Add(3, "Exit Application");

            if(startingItems != null)
            {
                StartingItems = new List<Inventory>();
                foreach (Inventory i in startingItems.Distinct())
                {
                    StartingItems.Add(i);
                }
            }
        }

        public Display AddChange(Display dis, Coins coin)
        {
            double amountToAdd = coin.GetCoinValue(coin);
            dis.ChangeInserted += amountToAdd;
            return dis;
        }

        public Display ReturnChange(Display dis)
        {            
            dis.ChangeReturned = dis.ChangeInserted;
            dis.ChangeInserted = 0;
            return dis;
        }

        public bool CanBuyProduct(Display dis, Inventory item)
        {
            if (dis.ChangeInserted >= item.Value)
                return true;

            return false;
        }

        public Coins InsertCoin()
        {
            Coins coin = new Coins();
            Console.WriteLine("INSERT COIN" + "\n");
            coin.GetCoinWeight();
            coin.GetCoinThickness();
            return coin;
        }
    }
}
