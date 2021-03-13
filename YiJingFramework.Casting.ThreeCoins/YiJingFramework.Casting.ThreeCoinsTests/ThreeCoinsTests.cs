using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Casting.ThreeCoins;
using YiJingFramework.Core;

namespace YiJingFramework.Casting.ThreeCoins.Tests
{
    [TestClass()]
    public class ThreeCoinsTests
    {
        private class TestPaper : IPaper
        {
            internal Coin Coin1 { get; init; }
            internal Coin Coin2 { get; init; }
            internal Coin Coin3 { get; init; }
            public void Draw(LineAttribute attribute, bool isChanging)
            {
                if (this.Coin1.IsYangSideUp && this.Coin2.IsYangSideUp && this.Coin3.IsYangSideUp)
                {
                    Assert.AreEqual(LineAttribute.Yang, attribute);
                    Assert.AreEqual(true, isChanging);
                }
                if (this.Coin1.IsYangSideUp && this.Coin2.IsYangSideUp && !this.Coin3.IsYangSideUp)
                {
                    Assert.AreEqual(LineAttribute.Yin, attribute);
                    Assert.AreEqual(false, isChanging);
                }
                if (this.Coin1.IsYangSideUp && !this.Coin2.IsYangSideUp && this.Coin3.IsYangSideUp)
                {
                    Assert.AreEqual(LineAttribute.Yin, attribute);
                    Assert.AreEqual(false, isChanging);
                }
                if (this.Coin1.IsYangSideUp && !this.Coin2.IsYangSideUp && !this.Coin3.IsYangSideUp)
                {
                    Assert.AreEqual(LineAttribute.Yang, attribute);
                    Assert.AreEqual(false, isChanging);
                }
                if (!this.Coin1.IsYangSideUp && this.Coin2.IsYangSideUp && this.Coin3.IsYangSideUp)
                {
                    Assert.AreEqual(LineAttribute.Yin, attribute);
                    Assert.AreEqual(false, isChanging);
                }
                if (!this.Coin1.IsYangSideUp && this.Coin2.IsYangSideUp && !this.Coin3.IsYangSideUp)
                {
                    Assert.AreEqual(LineAttribute.Yang, attribute);
                    Assert.AreEqual(false, isChanging);
                }
                if (!this.Coin1.IsYangSideUp && !this.Coin2.IsYangSideUp && !this.Coin3.IsYangSideUp)
                {
                    Assert.AreEqual(LineAttribute.Yin, attribute);
                    Assert.AreEqual(true, isChanging);
                }
            }
            public (Painting Original, Painting Changed) GetPaintings()
            {
                throw new NotImplementedException();
            }
        }
        [TestMethod()]
        public void ThreeCoinsTest()
        {
            Coin c1 = new Coin(), c2 = new Coin(), c3 = new Coin();
            var tc = new ThreeCoins(new TestPaper() { Coin1 = c1, Coin2 = c2, Coin3 = c3 }, c1, c2, c3);
            for (int i = 0; i < 100; i++)
                tc.TossAndDraw();

            var p = new Paper();
            tc = new ThreeCoins(p);
            for (int i = 0; i < 100; i++)
                tc.TossAndDraw();
            Assert.AreEqual(100, p.GetPaintings().Original.Count);
            Assert.AreEqual(100, p.GetPaintings().Changed.Count);
        }
    }
}