namespace VendingMachineCore
{
    public class Coins
    {
        private struct TypesOfCoins
        {
            public const double Penny = 0.01;
            public const double Nickel = 0.05;
            public const double Dime = 0.10;
            public const double Quarter = 0.25;
        }

        //Assume to be in milimeters
        public double Thickness;

        //Assume to be in grams
        public double Weight;

        public Coins(double weight = 0, double thickness = 0)
        {
            Thickness = thickness;
            Weight = weight;
        }

        //Values determined per: https://www.usmint.gov/learn/coin-and-medal-programs/coin-specifications
        public double GetCoinValue(Coins coin)
        {
            if (coin.Weight == 2.5 && coin.Thickness == 1.52)
                return TypesOfCoins.Penny;
            else if (coin.Weight == 5 && coin.Thickness == 1.95)
                return TypesOfCoins.Nickel;
            else if (coin.Weight == 2.268 && coin.Thickness == 1.35)
                return TypesOfCoins.Dime;
            else if (coin.Weight == 5.670 && coin.Thickness == 1.75)
                return TypesOfCoins.Quarter;
            else
                return 0;
        }
    }
}
