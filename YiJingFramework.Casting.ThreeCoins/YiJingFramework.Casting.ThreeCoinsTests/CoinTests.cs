using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Casting.ThreeCoins;

namespace YiJingFramework.Casting.ThreeCoins.Tests
{
    [TestClass()]
    public class CoinTests
    {
        [TestMethod()]
        public void CoinTest()
        {
            var coin = new Coin();
            var q = Convert.ToInt32(coin.Toss());
            for (int i = 0; i < 2000; i++)
            {
                q += Convert.ToInt32(coin.Toss());
            }
            Assert.AreNotEqual(0, q);
            Assert.AreNotEqual(2001, q);

            q = Convert.ToInt32(coin.Toss());
            var d = q;
            for (int i = 0; i < 2000; i++)
            {
                q += Convert.ToInt32(coin.IsYangSideUp);
            }
            Assert.AreEqual(d * 2001, q);

            coin.HoldInHand();
            q = Convert.ToInt32(coin.IsYangSideUp);
            for (int i = 0; i < 2000; i++)
            {
                q += Convert.ToInt32(coin.IsYangSideUp);
            }
            Assert.AreNotEqual(0, q);
            Assert.AreNotEqual(2001, q);
        }
    }
}