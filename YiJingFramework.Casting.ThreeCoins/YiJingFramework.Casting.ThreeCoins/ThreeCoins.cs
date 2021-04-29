using System;

namespace YiJingFramework.Casting.ThreeCoins
{
    /// <summary>
    /// 铜钱起卦法。
    /// The three-coin method.
    /// </summary>
    public sealed class ThreeCoins
    {
        /// <summary>
        /// 用来记录爻的纸。
        /// The paper to record the lines.
        /// </summary>
        public IPaper? Paper { get; set; }

        /// <summary>
        /// 一枚硬币。
        /// A coin.
        /// </summary>
        public ICoin Coin1 { get; }

        /// <summary>
        /// 一枚硬币。
        /// A coin.
        /// </summary>
        public ICoin Coin2 { get; }

        /// <summary>
        /// 一枚硬币。
        /// A coin.
        /// </summary>
        public ICoin Coin3 { get; }

        /// <summary>
        /// 创建一个实例。
        /// Initialize a new instance.
        /// </summary>
        /// <param name="paper">
        /// 用来记录爻的纸。
        /// The paper to record the lines.
        /// </param>
        /// <param name="coin1">
        /// 一枚硬币。
        /// A coin.
        /// </param>
        /// <param name="coin2">
        /// 一枚硬币。
        /// A coin.
        /// </param>
        /// <param name="coin3">
        /// 一枚硬币。
        /// A coin.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="paper"/> 是 <c>null</c> 。
        /// <paramref name="paper"/> is <c>null</c>.
        /// </exception>
        public ThreeCoins(IPaper? paper, ICoin? coin1 = null, ICoin? coin2 = null, ICoin? coin3 = null)
        {
            this.Paper = paper;
            this.Coin1 = coin1 ?? new Coin();
            this.Coin2 = coin2 ?? new Coin();
            this.Coin3 = coin3 ?? new Coin();
        }

        /// <summary>
        /// 抛出硬币并在纸上记录一根爻。
        /// Toss the coins and draw a line on the paper.
        /// </summary>
        public void TossAndDraw()
        {
            var num = 0;
            num += this.Coin1.Toss() ? 3 : 2;
            num += this.Coin2.Toss() ? 3 : 2;
            num += this.Coin3.Toss() ? 3 : 2;

            var (attribute, isChanging) = num switch {
                6 => (Core.YinYang.Yin, true),
                7 => (Core.YinYang.Yang, false),
                8 => (Core.YinYang.Yin, false),
                _ => (Core.YinYang.Yang, true) // 9
            };
            this.Paper?.Draw(attribute, isChanging);
        }

        /// <summary>
        /// 检查硬币的状态并在纸上记录一根爻。
        /// Check the coins and draw a line on the paper.
        /// </summary>
        public void CheckAndDraw()
        {
            var num = 0;
            num += this.Coin1.IsYangSideUp ? 3 : 2;
            num += this.Coin2.IsYangSideUp ? 3 : 2;
            num += this.Coin3.IsYangSideUp ? 3 : 2;

            var (attribute, isChanging) = num switch {
                6 => (Core.YinYang.Yin, true),
                7 => (Core.YinYang.Yang, false),
                8 => (Core.YinYang.Yin, false),
                _ => (Core.YinYang.Yang, true) // 9
            };
            this.Paper?.Draw(attribute, isChanging);
        }
    }
}
