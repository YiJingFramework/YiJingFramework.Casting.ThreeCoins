using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.Casting.ThreeCoins
{
    /// <summary>
    /// 一枚硬币。
    /// 除非随机数发生器在其他位置被同时使用，这个类是线程安全的。
    /// A coin.
    /// The class is thread-safe, unless the random is also being used elsewhere.
    /// </summary>
    public sealed class Coin : ICoin
    {
        private static readonly Random randomProvider = new Random();
        private static readonly object providerLocker = new object();

        private readonly Random random;
        private readonly object locker = new object();

        private bool? state = null;

        /// <summary>
        /// Initialize an instance.
        /// </summary>
        /// <param name="random">The random to be used.</param>
        public Coin(Random? random = null)
        {
            lock (providerLocker)
            {
                this.random = random ?? new Random(randomProvider.Next());
            }
        }

        /// <summary>
        /// 获取当前是否正面朝上。
        /// 如果被握在手中会返回一个新的随机值，
        /// 但不会影响下次获取的结果。
        /// Get whether the coin's yang side is up currently.
        /// If the coin is held in hand, the method will return a new random value,
        /// but won't influence the next result.
        /// </summary>
        public bool IsYangSideUp
        {
            get
            {
                lock (this.locker)
                {
                    if (this.state.HasValue)
                        return this.state.Value;
                    else
                        return Convert.ToBoolean(this.random.Next(0, 2));
                }
            }
        }

        /// <summary>
        /// 把硬币握在手中。
        /// Hold the coin in hand.
        /// </summary>
        public void HoldInHand()
        {
            lock (this.locker)
            {
                this.state = null;
            }
        }

        /// <summary>
        /// 抛出硬币。
        /// Toss the coin.
        /// </summary>
        /// <returns>
        /// 抛出后是否阳面朝上。
        /// Whether the coin's yang side is up after being tossed.
        /// </returns>
        public bool Toss()
        {
            lock (this.locker)
            {
                this.state = Convert.ToBoolean(this.random.Next(0, 2));
                return this.state.Value;
            }
        }
    }
}
