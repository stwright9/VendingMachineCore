using System;
using Xunit;

namespace VendingMachineCore.Tests
{
    public class CoinsTests
    {
        [Fact]
        public void GetCoinValueTest()
        {
            Coins coin = new Coins();
            
            Assert.Equal(0.01, coin.GetCoinValue(new Coins(2.5, 1.52)));
            Assert.Equal(0.05, coin.GetCoinValue(new Coins(5, 1.95)));
            Assert.Equal(0.10, coin.GetCoinValue(new Coins(2.268, 1.35)));
            Assert.Equal(0.25, coin.GetCoinValue(new Coins(5.670, 1.75)));
            Assert.Equal(0, coin.GetCoinValue(new Coins(50, 1.25)));
        }
    }
}
