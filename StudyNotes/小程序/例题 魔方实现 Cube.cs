using System;
using System.Collections.Generic;
using System.Windows;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CubeNameSpace.CubeBass;

namespace CubeNameSpace
{
    public static class a
    {
        public static Color ToColor(this ColorEnum param)
        {
            switch (param)
            {
                case ColorEnum.None:
                    break;
                case ColorEnum.Blue:
                    return Color.Blue;
                case ColorEnum.Orange:
                    return Color.Orange;
                case ColorEnum.White:
                    return Color.White;
                case ColorEnum.Yellow:
                    return Color.Yellow;
                case ColorEnum.Red:
                    return Color.Red;
                case ColorEnum.Green:
                    return Color.Green;
                default:
                    break;
            }
            return Color.Gray;
        }
    }

    /// <summary>
    /// 标准正阶魔方封装
    /// </summary>
    public abstract class CubeBass
    {
        /// <summary>
        /// 阶数
        /// </summary>
        public readonly int Order;
        /// <summary>
        /// 面（顺序：前，左，上，右，下，后）
        /// </summary>
        public List<SurfaceWrapper> Surface = new List<SurfaceWrapper>();

        /// <summary>
        /// 单面封装
        /// </summary>
        public struct SurfaceWrapper
        {
            /// <summary>
            /// 颜色坐标
            /// </summary>
            private ColorEnum[,] _urfaceArray;

            /// <summary>
            /// 阶数
            /// </summary>
            public readonly int Order;
            /// <summary>
            /// 方位
            /// </summary>
            public PositionEnum Position { get; set; }

            /// <summary>
            /// 获取或设置坐标颜色
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public ColorEnum this[int x, int y]
            {
                get
                {
                    if ((0 <= x && x < Order) && (0 <= y && y < Order))
                        return _urfaceArray[x, y];
                    else
                        return ColorEnum.None;
                }
                set
                {
                    if ((0 <= x && x < Order) && (0 <= y && y < Order)) _urfaceArray[x, y] = value;
                    else return;
                }
            }


            /// <summary>
            /// 获取某列颜色
            /// </summary>
            /// <param name="x"></param>
            /// <returns></returns>
            public ColorEnum[] GetColorForX(int x)
            {
                var list = new ColorEnum[Order];
                for (int y = 0; y < Order; y++)
                {
                    list[y] = this[x, y];
                }
                return list;
            }
            /// <summary>
            /// 获取某行颜色
            /// </summary>
            /// <param name="y"></param>
            /// <returns></returns>
            public ColorEnum[] GetColorForY(int y)
            {
                var list = new ColorEnum[Order];
                for (int x = 0; x < Order; x++)
                {
                    list[x] = this[x, y];
                }
                return list;
            }
            /// <summary>
            /// 设置某列颜色
            /// </summary>
            /// <param name="x"></param>
            /// <param name="ColorArray"></param>
            public void SetColorForX(int x, ColorEnum[] ColorArray)
            {
                if (ColorArray.Length == Order)
                {
                    for (int y = 0; y < Order; y++)
                    {
                        this[x, y] = ColorArray[y];
                    }
                }
            }
            /// <summary>
            /// 设置某行颜色
            /// </summary>
            /// <param name="y"></param>
            /// <param name="ColorArray"></param>
            public void SetColorForY(int y, ColorEnum[] ColorArray)
            {
                if (ColorArray.Length == Order)
                {
                    for (int x = 0; x < Order; x++)
                    {
                        this[x, y] = ColorArray[x];
                    }
                }
            }
            /// <summary>
            /// 获取整面颜色
            /// </summary>
            /// <returns></returns>
            public ColorEnum[] GetColor()
            {
                ColorEnum[] list = new ColorEnum[Order * Order];
                for (int x = 0; x < Order; x++)
                {
                    for (int y = 0; y < Order; y++)
                    {
                        list[x * Order + y] = this[x, y];
                    }
                }
                return list;
            }
            /// <summary>
            /// 设置整面颜色
            /// </summary>
            /// <param name="ColorArray"></param>
            public void SetColor(ColorEnum[] ColorArray)
            {
                if (ColorArray.Length != Order * Order) return;
                //先列后行赋值颜色
                for (int x = 0; x < Order; x++)
                {
                    for (int y = 0; y < Order; y++)
                    {
                        this[x, y] = ColorArray[x * Order + y];
                    }
                }
            }

            /// <summary>
            /// 构造
            /// </summary>
            /// <param name="position">当前方位</param>
            /// <param name="order">阶数</param>
            /// <param name="colorArray">颜色组</param>
            public SurfaceWrapper(int order, PositionEnum position, ColorEnum[] colorArray)
            {
                this.Order = order;
                this.Position = position;
                _urfaceArray = new ColorEnum[order, order];


                if (colorArray.Length != order * order) return;
                //先列后行赋值颜色
                for (int x = 0; x < order; x++)
                {
                    for (int y = 0; y < order; y++)
                    {
                        this[x, y] = colorArray[x * this.Order + y];
                    }
                }
            }
        }
        /// <summary>
        /// 方位类型
        /// </summary>
        public enum PositionEnum : int
        {
            /// <summary>
            /// 前
            /// </summary>
            Front,
            /// <summary>
            /// 左
            /// </summary>
            LeftSide,
            /// <summary>
            /// 上
            /// </summary>
            Top,
            /// <summary>
            /// 右
            /// </summary>
            RightSide,
            /// <summary>
            /// 下
            /// </summary>
            Bottom,
            /// <summary>
            /// 后
            /// </summary>
            Back
        }
        /// <summary>
        /// 颜色类型
        /// </summary>
        public enum ColorEnum : int
        {
            None,
            Blue,
            Orange,
            White,
            Yellow,
            Red,
            Green
        }
        /// <summary>
        /// 获取一个颜色（面）
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private ColorEnum[] ReadColorInColorEnum(ColorEnum color)
        {
            ColorEnum[] list = new ColorEnum[Order * Order];
            for (int i = 0; i < Order * Order; i++)
            {
                list[i] = color;
            }
            return list;
        }
        

        /// <summary>
        /// 创建一个新的Cube
        /// </summary>
        /// <param name="color">正前方颜色</param>
        public void Create(ColorEnum color = ColorEnum.Blue)
        {
            for (int i = 0; i < 6; i++)
            {
                Surface.Add(new SurfaceWrapper(Order, (PositionEnum)i, ReadColorInColorEnum((ColorEnum)(i + 1))));
            }
        }


        public CubeBass(int order)
        {
            Order = order;
            Create();
        }
    }

    /// <summary>
    /// 三阶魔方
    /// </summary>
    public class ThreeOrderCube : CubeBass
    {
        public ThreeOrderCube() : base(3)
        { }
    }
}
