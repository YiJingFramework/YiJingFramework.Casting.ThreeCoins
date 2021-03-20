using System;
using YiJingFramework.Casting.ThreeCoins;

namespace Coins
{
    class Program
    {
        static void Main()
        {
            var coin = new Coin();
            // Random values:
            Console.WriteLine($"Before being tossed: {coin.IsYangSideUp}");
            Console.WriteLine($"Before being tossed: {coin.IsYangSideUp}");
            Console.WriteLine($"Before being tossed: {coin.IsYangSideUp}");
            Console.WriteLine($"Before being tossed: {coin.IsYangSideUp}");
            Console.WriteLine($"Before being tossed: {coin.IsYangSideUp}");
            Console.WriteLine($"Before being tossed: {coin.IsYangSideUp}");
            Console.WriteLine();

            Console.WriteLine(coin.Toss());
            // Same values:
            Console.WriteLine($"Tossed: {coin.IsYangSideUp}");
            Console.WriteLine($"Tossed: {coin.IsYangSideUp}");
            Console.WriteLine($"Tossed: {coin.IsYangSideUp}");
            Console.WriteLine($"Tossed: {coin.IsYangSideUp}");
            Console.WriteLine($"Tossed: {coin.IsYangSideUp}");
            Console.WriteLine($"Tossed: {coin.IsYangSideUp}");
            Console.WriteLine();

            coin.HoldInHand();
            // Random values:
            Console.WriteLine($"After being held: {coin.IsYangSideUp}");
            Console.WriteLine($"After being held: {coin.IsYangSideUp}");
            Console.WriteLine($"After being held: {coin.IsYangSideUp}");
            Console.WriteLine($"After being held: {coin.IsYangSideUp}");
            Console.WriteLine($"After being held: {coin.IsYangSideUp}");
            Console.WriteLine($"After being held: {coin.IsYangSideUp}");
            Console.WriteLine();
        }
    }
}
