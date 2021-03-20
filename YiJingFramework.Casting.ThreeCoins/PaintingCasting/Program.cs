using System;
using YiJingFramework.Casting.ThreeCoins;

namespace PaintingCasting
{
    class Program
    {
        static void TossSixTimes(ThreeCoins threeCoins)
        {
            for (int i = 0; i < 6; i++)
            {
                threeCoins.TossAndDraw();
                Console.WriteLine($"{(threeCoins.Coin1.IsYangSideUp ? 3 : 2)} " +
                    $"{(threeCoins.Coin2.IsYangSideUp ? 3 : 2)} " +
                    $"{(threeCoins.Coin3.IsYangSideUp ? 3 : 2)}");
            }
        }
        static void Main()
        {
            var threeCoins = new ThreeCoins(new Paper());
            TossSixTimes(threeCoins);
            var paintings = threeCoins.Paper.GetPaintings();
            Console.WriteLine($"{paintings.Original} -> {paintings.Changed}");

            Console.WriteLine();

            // To use a new empty paper to record.
            threeCoins.Paper = new Paper();
            TossSixTimes(threeCoins);
            paintings = threeCoins.Paper.GetPaintings();
            Console.WriteLine($"{paintings.Original} -> {paintings.Changed}");
        }
    }
}
