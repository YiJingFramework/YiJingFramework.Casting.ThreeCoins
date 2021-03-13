using YiJingFramework.Core;

namespace YiJingFramework.Casting.ThreeCoins
{
    /// <summary>
    /// 一张纸，可以记录爻。
    /// A paper that records the lines.
    /// </summary>
    public interface IPaper
    {
        /// <summary>
        /// 在纸上自下而上地绘制一条爻。
        /// Draw a line bottom to top on the paper.
        /// </summary>
        /// <param name="attribute">
        /// 爻的阴阳属性。
        /// The line's attribute.
        /// </param>
        /// <param name="isChanging">
        /// 指示是否为变爻。
        /// Whether the line is a changing line or not.
        /// </param>
        void Draw(LineAttribute attribute, bool isChanging);

        /// <summary>
        /// 获取卦画。
        /// Get the paintings.
        /// </summary>
        /// <returns>
        /// 本卦卦画和变卦卦画。
        /// The original painting and the changed painting.
        /// </returns>
        (Painting Original, Painting Changed) GetPaintings();
    }
}