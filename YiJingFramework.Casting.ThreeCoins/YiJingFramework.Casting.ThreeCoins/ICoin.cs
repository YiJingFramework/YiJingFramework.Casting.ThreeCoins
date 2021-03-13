namespace YiJingFramework.Casting.ThreeCoins
{
    /// <summary>
    /// 一枚硬币。
    /// A coin.
    /// </summary>
    public interface ICoin
    {
        /// <summary>
        /// 获取当前是否正面朝上。
        /// 如果被握在手中会返回一个新的随机值，
        /// 但不会影响下次获取的结果。
        /// Get whether the coin's yang side is up currently.
        /// If the coin is held in hand, the method will return a new random value,
        /// but won't influence the next result.
        /// </summary>
        bool IsYangSideUp { get; }

        /// <summary>
        /// 把硬币握在手中。
        /// Hold the coin in hand.
        /// </summary>
        void HoldInHand();

        /// <summary>
        /// 抛出硬币。
        /// Toss the coin.
        /// </summary>
        /// <returns>
        /// 抛出后是否阳面朝上。
        /// Whether the coin's yang side is up after being tossed.
        /// </returns>
        bool Toss();
    }
}