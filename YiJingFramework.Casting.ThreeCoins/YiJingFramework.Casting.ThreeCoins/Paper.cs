using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.Casting.ThreeCoins
{
    /// <summary>
    /// 一张纸，可以记录爻。
    /// 这个类是线程安全的。
    /// A paper that records the lines.
    /// The class is thread-safe.
    /// </summary>
    public sealed class Paper : IPaper
    {
        private readonly List<Core.LineAttribute> original = new List<Core.LineAttribute>(6);
        private readonly List<Core.LineAttribute> changed = new List<Core.LineAttribute>(6);

        private readonly object locker = new object();

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
        /// <exception cref="Core.Exceptions.UnexpectedLineAttributeException">
        /// <paramref name="attribute"/> 不是阴也不是阳。
        /// <paramref name="attribute"/> is neither yin nor yang.
        /// </exception>
        public void Draw(Core.LineAttribute attribute, bool isChanging)
        {
            if (attribute == Core.LineAttribute.Yang)
            {
                lock (this.locker)
                {
                    this.original.Add(Core.LineAttribute.Yang);
                    this.changed.Add(isChanging ? Core.LineAttribute.Yin : Core.LineAttribute.Yang);
                }
            }
            else if (attribute == Core.LineAttribute.Yin)
            {
                lock (this.locker)
                {
                    this.original.Add(Core.LineAttribute.Yin);
                    this.changed.Add(isChanging ? Core.LineAttribute.Yang : Core.LineAttribute.Yin);
                }
            }
            else
                throw new Core.Exceptions.UnexpectedLineAttributeException(attribute);
        }

        /// <summary>
        /// 获取卦画。
        /// Get the paintings.
        /// </summary>
        /// <returns>
        /// 本卦卦画和变卦卦画。
        /// The original painting and the changed painting.
        /// </returns>
        public (Core.Painting Original, Core.Painting Changed) GetPaintings()
        {
            lock (this.locker)
            {
                return (new Core.Painting(this.original), new Core.Painting(this.changed));
            }
        }
    }
}
