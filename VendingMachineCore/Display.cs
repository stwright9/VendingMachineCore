﻿using System;
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

            if (amountToAdd == 0.01)            
                dis.ChangeReturned += amountToAdd;            
            else
                dis.ChangeInserted += amountToAdd;

            return dis;
        }

        //I am assuming your taking the change out of the coin return every time you return coins
        public Display ReturnChange(Display dis)
        {            
            dis.ChangeReturned = dis.ChangeInserted;
            dis.ChangeInserted = 0;
            return dis;
        }

        public bool CanBuyProduct(Display dis, Inventory item, bool exactChange)
        {
            if (dis.ChangeInserted == item.Value && exactChange == true)
                return true;
            else if (dis.ChangeInserted >= item.Value && exactChange == false)
                return true;

            return false;
        }

        public Coins InsertCoin()
        {
            Coins coin = new Coins();
            Console.Clear();
            Console.WriteLine("INSERT COIN" + "\n");
            coin.Weight = coin.GetCoinWeight();
            coin.Thickness = coin.GetCoinThickness();
            return coin;
        }

        public void DisplayMainScreen(Display dis, bool purchasedItem)
        {
            Console.Clear();
            Console.WriteLine("Current Change: " + dis.ChangeInserted + "\t" + "Coin Return: " + dis.ChangeReturned + "\n");

            if(purchasedItem)
                Console.WriteLine("THANK YOU FOR YOUR PURCHASE" + "\n");

            foreach (KeyValuePair<int, string> i in dis.UserOptions)
            {
                Console.WriteLine(i.Key + "\t" + i.Value);
            }
            Console.Write("Select an option: ");
        }

        public void DisplayInventory(Display dis, List<Inventory> inventory)
        {
            Inventory inv = new Inventory();
            Console.Clear();
            Console.WriteLine("Current Change: " + dis.ChangeInserted + "\t" + "Coin Return: " + dis.ChangeReturned + "\n");
            Console.Write("Id" + "\t" + "Name" + "\t" + "Amount" + "\t" + "Stock" + "\n");
            foreach (Inventory.InventoryDisplayItem i in inv.GetInventoryList(inventory, dis.StartingItems))
            {
                Console.WriteLine(i.id + "\t" + i.name + "\t"+ i.value + "\t" + i.stock);
            }
            Console.Write("Select an id: ");            
        }
    }
}
