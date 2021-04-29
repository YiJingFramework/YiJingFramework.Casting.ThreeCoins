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
    public class PaperTests
    {
        [TestMethod()]
        public void PaperTest()
        {
            var random = new Random();
            for (int i = 0; i < 200; i++)
            {
                var list = new List<Core.YinYang>();
                var list2 = new List<Core.YinYang>();
                var paper = new Paper();
                for (int j = 0; j < 20; j++)
                {
                    var o = Convert.ToBoolean(random.Next(0, 2));
                    var p = (Core.YinYang)(random.Next(0, 2));
                    list.Add(p);
                    if (o)
                    {
                        list2.Add(!p);
                    }
                    else
                        list2.Add(p);
                    paper.Draw(p, o);
                    var (p1, p2) = paper.GetPaintings();
                    Assert.IsTrue(p1.SequenceEqual(list));
                    Assert.IsTrue(p2.SequenceEqual(list2));
                }
            }
        }
    }
}