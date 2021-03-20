using System;
using YiJingFramework.Casting.ThreeCoins;

namespace Papers
{
    class Program
    {
        static void Main()
        {
            var paper = new Paper();

            paper.Draw(YiJingFramework.Core.LineAttribute.Yang, false);
            Console.WriteLine(paper.GetPaintings());
            Console.WriteLine();
            // Output: (1, 1)

            paper.Draw(YiJingFramework.Core.LineAttribute.Yang, true);
            Console.WriteLine(paper.GetPaintings());
            Console.WriteLine();
            // Output: (11, 10)

            paper.Draw(YiJingFramework.Core.LineAttribute.Yin, false);
            Console.WriteLine(paper.GetPaintings());
            Console.WriteLine();
            // Output: (110, 100)

            paper.Draw(YiJingFramework.Core.LineAttribute.Yin, true);
            Console.WriteLine(paper.GetPaintings());
            Console.WriteLine();
            // Output: (1100, 1001)
        }
    }
}
