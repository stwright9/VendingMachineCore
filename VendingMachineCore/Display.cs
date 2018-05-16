using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineCore
{
    public class Display
    {
        public double ChangeInserted;
        public double ChangeReturned;
        public bool ExactChangeMode = false;
        public Dictionary<int, string> UserOptions;

        public Display(double changeInserted = 0, double changeReturned = 0)
        {
            ChangeInserted = changeInserted;
            ChangeReturned = changeReturned;
            UserOptions = new Dictionary<int, string>();
            UserOptions.Add(0, "Insert Coins");
            UserOptions.Add(1, "Display Products");
            UserOptions.Add(2, "Return Coins");
            UserOptions.Add(3, "Exit Application");
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




    }
}
