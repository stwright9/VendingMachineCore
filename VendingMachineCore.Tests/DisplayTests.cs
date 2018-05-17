using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace VendingMachineCore.Tests
{
    public class DisplayTests
    {
        [Fact]
        public void AddChangeTests()
        {
            Display dis = new Display();
            Coins coin = new Coins(5.670, 1.75);

            Assert.Equal(0.25, dis.AddChange(dis, coin).ChangeInserted);
            dis.AddChange(dis, coin);
            dis.AddChange(dis, coin);
            dis.AddChange(dis, coin);
            Assert.Equal(1, dis.ChangeInserted);

            coin = new Coins(2.5, 1.52);
            Assert.Equal(1, dis.AddChange(dis, coin).ChangeInserted);
            Assert.Equal(0.01, dis.ChangeReturned);
        }

        [Fact]
        public void ReturnChangeTests()
        {
            Display dis = new Display();
            Coins coin = new Coins(5.670, 1.75);

            Assert.Equal(0.25, dis.AddChange(dis, coin).ChangeInserted);
            dis.AddChange(dis, coin);
            dis.AddChange(dis, coin);
            dis.AddChange(dis, coin);
            dis = dis.ReturnChange(dis);
            Assert.Equal(1, dis.ChangeReturned);
            Assert.Equal(0, dis.ChangeInserted);
        }

        [Fact]
        public void CanBuyProductTest()
        {
            Display dis = new Display();
            Inventory item = new Inventory();
            dis.ChangeInserted = 5;
            item.Value = 5;

            Assert.True(dis.CanBuyProduct(dis, item, false));
            Assert.True(dis.CanBuyProduct(dis, item, true));
            dis.ChangeInserted = 4;
            Assert.False(dis.CanBuyProduct(dis, item, true));
        }

    }
}
