using System;
using YiJingFramework.Casting.ThreeCoins;

namespace Papers
{
    class Program
    {
        static void Main()
        {
            var paper = new Paper();

            paper.Draw(YiJingFramework.Core.YinYang.Yang, false);
            Console.WriteLine(paper.GetPaintings());
            Console.WriteLine();
            // Output: (1, 1)

            paper.Draw(YiJingFramework.Core.YinYang.Yang, true);
            Console.WriteLine(paper.GetPaintings());
            Console.WriteLine();
            // Output: (11, 10)

            paper.Draw(YiJingFramework.Core.YinYang.Yin, false);
            Console.WriteLine(paper.GetPaintings());
            Console.WriteLine();
            // Output: (110, 100)

            paper.Draw(YiJingFramework.Core.YinYang.Yin, true);
            Console.WriteLine(paper.GetPaintings());
            Console.WriteLine();
            // Output: (1100, 1001)
        }
    }
}
