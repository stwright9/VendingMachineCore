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


    }
}
