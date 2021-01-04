//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NokiKanColle
//{
//    /// <summary>
//    /// 颜色方法
//    /// </summary>
//    public static class ColorFunction
//    {
//        /// <summary>
//        /// color转str(16进制)
//        /// </summary>
//        /// <param name="color"></param>
//        /// <returns></returns>
//        public static string ColorToStr16(Color color) => $"{color.R.ToString("X2")}{color.G.ToString("X2")}{color.B.ToString("X2")}";
//        /// <summary>
//        /// str(16进制)转Color
//        /// </summary>
//        /// <param name="str"></param>
//        /// <returns></returns>
//        public static Color StringToColor(string str) => ColorTranslator.FromHtml($"#{str.Substring(0, 2)}{str.Substring(2, 2)}{str.Substring(4)}");

//        /// <summary>
//        /// 判断两个颜色是否相似
//        /// </summary>
//        /// <param name="color1">颜色1</param>
//        /// <param name="color2">颜色2</param>
//        /// <param name="r">阈值（0~1000）</param>
//        /// <returns>布尔值</returns>
//        public static bool IsSimilarColor(Color color1, Color color2, double r)
//        {
//            if (r < 0) return false;
//            else if (r == 0)
//            {
//                if (color1.R == color2.R && color1.G == color2.G && color1.B == color2.B) return true;
//                else return false;
//            }

//            var p = Math.Sqrt(Math.Pow(color1.R - color2.R, 2) + Math.Pow(color1.G - color2.G, 2) + Math.Pow(color1.B - color2.B, 2));

//            r = r / 1000d * 441d;
//            if (r >= p)
//                return true;
//            else return false;
//        }
//        /// <summary>
//        /// 判断两个颜色是否相似
//        /// </summary>
//        /// <param name="color1"></param>
//        /// <param name="color2"></param>
//        /// <param name="r">阈值（0 ~ 1）</param>
//        /// <returns></returns>
//        public static bool IsSimilarColor(ColorF color1, ColorF color2, double r)
//        {
//            r = r.Clamp(0f, 1f);
//            if (r == 0)
//            {
//                if (color1.R == color2.R && color1.G == color2.G && color1.B == color2.B) return true;
//                else return false;
//            }

//            var p = Math.Sqrt(Math.Pow(color1.R - color2.R, 2) + Math.Pow(color1.G - color2.G, 2) + Math.Pow(color1.B - color2.B, 2)) / 1.7320508075688772935274463415059d;

//            if (r >= p)
//                return true;
//            else return false;
//        }

//        /// <summary>
//        /// 转化为浮点值颜色
//        /// </summary>
//        /// <param name="origi"></param>
//        /// <returns></returns>
//        public static ColorF ToColorF(this Color origi) => new ColorF(origi.R / 255f, origi.G / 255f, origi.B / 255f, origi.A / 255f);

//        // 参考： https://www.w3.org/TR/compositing/#values

//        /// <summary>
//        /// 简单Alpha混合
//        /// </summary>
//        /// <param name="baseValue">基色Alpha</param>
//        /// <param name="blendValue">混合色Alpha</param>
//        /// <returns></returns>
//        public static byte SimpleAlphaCompositing(byte baseValue, byte blendValue)
//        {
//            if (baseValue == 255 || blendValue == 255) return 255;
//            return (baseValue + blendValue - (baseValue * blendValue) / 255d).RoundToInt().ToByte();
//        }
//        /// <summary>
//        /// 简单Alpha混合
//        /// </summary>
//        /// <param name="baseValue">基色Alpha</param>
//        /// <param name="blendValue">混合色Alpha</param>
//        /// <returns></returns>
//        public static double SimpleAlphaCompositing(double baseValue, double blendValue)
//        {
//            if (baseValue == 1d || blendValue == 1d) return 1d;
//            return (baseValue + blendValue - (baseValue * blendValue));
//        }
//        /// <summary>
//        /// 计算带Alpha的混合
//        /// </summary>
//        /// <param name="baseValue">基色</param>
//        /// <param name="baseAlpha">基色Alpha</param>
//        /// <param name="blendValue">混合色</param>
//        /// <param name="blendAlpha">混合色Alpha</param>
//        /// <param name="mixing">混合结果</param>
//        /// <returns></returns>
//        public static byte Blending(byte baseValue, byte baseAlpha, byte blendValue, byte blendAlpha, byte mixing)
//        {
//            return (Blending(baseValue.Normalized(), baseAlpha.Normalized(), blendValue.Normalized(), blendAlpha.Normalized(), mixing.Normalized()) * 255d).RoundToInt().ToByte();
//        }
//        /// <summary>
//        /// 计算带Alpha的混合
//        /// </summary>
//        /// <param name="baseValue">基色</param>
//        /// <param name="baseAlpha">基色Alpha</param>
//        /// <param name="blendValue">混合色</param>
//        /// <param name="blendAlpha">混合色Alpha</param>
//        /// <param name="mixing">混合结果</param>
//        /// <returns></returns>
//        public static double Blending(double baseValue, double baseAlpha, double blendValue, double blendAlpha, double mixing)
//        {
//            var Ar = SimpleAlphaCompositing(baseAlpha, blendAlpha);
//            //var mix = mixingFunc(baseValue, blendValue) / 255d;
//            // var Cr = (1 - As / Ar) * Cb + As / Ar * ((1 - Ab) * Cs + Ab * mix);
//            return (1 - blendAlpha / Ar) * baseValue + blendAlpha / Ar * ((1 - baseAlpha) * blendValue + baseAlpha * mixing);
//        }
//        /// <summary>
//        /// 单通道颜色混合
//        /// </summary>
//        /// <param name="baseValue">基色</param>
//        /// <param name="baseAlpha">基色不透明度</param>
//        /// <param name="blendValue">混合色</param>
//        /// <param name="blendAlpha">混合色不透明度</param>
//        /// <returns></returns>
//        public static byte Normal(byte baseValue, byte baseAlpha, byte blendValue, byte blendAlpha)
//        {
//            if (blendAlpha == 255) return blendValue;
//            if (blendAlpha == 0) return baseValue;
//            var result = (((255d - blendAlpha) * baseAlpha * baseValue / 255d + blendAlpha * blendValue) / SimpleAlphaCompositing(baseAlpha, blendAlpha)).RoundToInt().ToByte();
//            return result;
//        }

//        /// <summary>
//        /// 变暗
//        /// </summary>
//        /// <param name="baseValue">基色</param>
//        /// <param name="blendValue">混合色</param>
//        /// <returns>混合结果</returns>
//        public static byte Darken(byte baseValue, byte blendValue) => Math.Min(baseValue, blendValue);
//        /// <summary>
//        /// 乘算，正片叠底
//        /// </summary>
//        /// <param name="baseValue">基色</param>
//        /// <param name="blendValue">混合色</param>
//        /// <returns>混合结果</returns>
//        public static byte Multiply(byte baseValue, byte blendValue) => (baseValue * blendValue / 255d).RoundToInt().ToByte();
//        /// <summary>
//        /// 颜色加深
//        /// </summary>
//        /// <param name="baseValue"></param>
//        /// <param name="blendValue"></param>
//        /// <returns></returns>
//        public static byte ColorBurn(byte baseValue, byte blendValue) => (ColorBurn(baseValue.Normalized(), blendValue.Normalized()) * 255d).RoundToInt().ToByte();
//        /// <summary>
//        /// 颜色加深
//        /// </summary>
//        /// <param name="baseValue"></param>
//        /// <param name="blendValue"></param>
//        /// <returns></returns>
//        public static double ColorBurn(double baseValue, double blendValue) => blendValue == 0 ? 0 : 1d - Math.Min(1, (1d - baseValue) / blendValue);

//        /// <summary>
//        /// 变亮
//        /// </summary>
//        /// <param name="baseValue">基色</param>
//        /// <param name="blendValue">混合色</param>
//        /// <returns>混合结果</returns>
//        public static byte Lighten(byte baseValue, byte blendValue) => Math.Max(baseValue, blendValue);
//        /// <summary>
//        /// 滤色
//        /// </summary>
//        /// <param name="baseValue">基色</param>
//        /// <param name="blendValue">混合色</param>
//        /// <returns>混合结果</returns>
//        public static byte Screen(byte baseValue, byte blendValue) => (baseValue + blendValue - (baseValue * blendValue / 255d)).RoundToInt().ToByte();

//        /// <summary>
//        /// 叠加，覆盖
//        /// </summary>
//        /// <param name="baseValue">基色</param>
//        /// <param name="blendValue">混合色</param>
//        /// <returns>混合结果</returns>
//        public static byte Overlay(byte baseValue, byte blendValue) => (Overlay(baseValue.Normalized(), blendValue.Normalized()) * 255d).RoundToInt().ToByte();
//        /// <summary>
//        /// 叠加，覆盖
//        /// </summary>
//        /// <param name="baseValue">基色</param>
//        /// <param name="blendValue">混合色</param>
//        /// <returns>混合结果</returns>
//        public static double Overlay(double baseValue, double blendValue) => (baseValue + (blendValue - .5d) * (1 - Math.Abs(baseValue - .5d) / .5d));

//        /// <summary>
//        /// 差值
//        /// </summary>
//        /// <param name="baseValue">基色</param>
//        /// <param name="blendValue">混合色</param>
//        /// <returns>混合结果</returns>
//        public static byte Difference(byte baseValue, byte blendValue) => Math.Abs(baseValue - blendValue).ToByte();


//        /// <summary>
//        /// 混合颜色
//        /// </summary>
//        /// <param name="origi">基色</param>
//        /// <param name="blend">混合色</param>
//        /// <param name="mode">混合模式</param>
//        /// <returns></returns>
//        public static Color Blending(this Color origi, Color blend, BlendMode mode)
//        {
//            Color mixing = blend;// 混合结果
//            var Ar = SimpleAlphaCompositing(origi.A, blend.A);// 混合后的不透明度
//            if (Ar == 0) return Color.Empty;// 两色均为透明

//            switch (mode)
//            {
//                case BlendMode.COPY:
//                    return Color.FromArgb(Ar, origi);
//                case BlendMode.DESTINATION:
//                    return Color.FromArgb(Ar, blend);
//                case BlendMode.NORMAL:
//                    return origi.Normal(blend);
//                case BlendMode.AVERAGE:
//                    break;
//                case BlendMode.DARKEN:
//                    mixing = origi.Darken(blend);
//                    break;
//                case BlendMode.MULTIPLY:
//                    mixing = origi.Multiply(blend);
//                    break;
//                case BlendMode.COLOR_BURN:
//                    mixing = origi.ColorBurn(blend);
//                    break;
//                case BlendMode.LINEAR_BURN:
//                    break;
//                case BlendMode.DARKER_COLOR:
//                    break;
//                case BlendMode.LIGHTEN:
//                    mixing = origi.Lighten(blend);
//                    break;
//                case BlendMode.SCREEN:
//                    mixing = origi.Screen(blend);
//                    break;
//                case BlendMode.COLOR_DODGE:
//                    break;
//                case BlendMode.LINEAR_DODGE_ADD:
//                    break;
//                case BlendMode.LIGHTER_COLOR:
//                    break;
//                case BlendMode.OVERLAY:
//                    mixing = origi.Overlay(blend);
//                    break;
//                case BlendMode.SOFT_LIGHT:
//                    break;
//                case BlendMode.HARD_LIGHT:
//                    break;
//                case BlendMode.VIVID_LIGHT:
//                    break;
//                case BlendMode.LINEAR_LIGHT:
//                    break;
//                case BlendMode.PIN_LIGHT:
//                    break;
//                case BlendMode.HARD_MIX:
//                    break;
//                case BlendMode.DIFFERENCE:
//                    mixing = origi.Difference(blend);
//                    break;
//                case BlendMode.EXCLUSION:
//                    break;
//                case BlendMode.SUBTRACT:
//                    break;
//                case BlendMode.DIVIDE:
//                    break;
//                case BlendMode.HUE:
//                    break;
//                case BlendMode.SATURATION:
//                    break;
//                case BlendMode.COLOR:
//                    break;
//                case BlendMode.LUMINOSITY:
//                    break;
//                default:
//                    break;
//            }

//            if (origi.A == 255 && blend.A == 255) return mixing;// 不带透明度的混色
//            else return Color.FromArgb(Ar,
//                Blending(origi.R, origi.A, blend.R, blend.A, mixing.R),
//                Blending(origi.G, origi.A, blend.G, blend.A, mixing.G),
//                Blending(origi.B, origi.A, blend.B, blend.A, mixing.B));// 带透明度的混色
//        }

//        /// <summary>
//        /// 正常颜色混合
//        /// </summary>
//        /// <param name="origi">基色</param>
//        /// <param name="blend">混合色</param>
//        /// <returns></returns>
//        public static Color Normal(this Color origi, Color blend)
//        {
//            return Color.FromArgb(SimpleAlphaCompositing(origi.A, blend.A), Normal(origi.R, origi.A, blend.R, blend.A), Normal(origi.G, origi.A, blend.G, blend.A), Normal(origi.B, origi.A, blend.B, blend.A));
//        }

//        /// <summary>
//        /// 变暗
//        /// </summary>
//        /// <param name="origi">基色</param>
//        /// <param name="blend">混合色</param>
//        /// <returns>混合结果</returns>
//        public static Color Darken(this Color origi, Color blend) => Color.FromArgb(Darken(origi.R, blend.R), Darken(origi.G, blend.G), Darken(origi.B, blend.B));
//        /// <summary>
//        /// 乘算，正片叠底
//        /// </summary>
//        /// <param name="origi">基色</param>
//        /// <param name="blend">混合色</param>
//        /// <returns>混合结果</returns>
//        public static Color Multiply(this Color origi, Color blend) => Color.FromArgb(Multiply(origi.R, blend.R), Multiply(origi.G, blend.G), Multiply(origi.B, blend.B));
//        /// <summary>
//        /// 颜色加深
//        /// </summary>
//        /// <param name="origi">基色</param>
//        /// <param name="blend">混合色</param>
//        /// <returns>混合结果</returns>
//        public static Color ColorBurn(this Color origi, Color blend) => Color.FromArgb(ColorBurn(origi.R, blend.R), ColorBurn(origi.G, blend.G), ColorBurn(origi.B, blend.B));

//        /// <summary>
//        /// 变亮
//        /// </summary>
//        /// <param name="origi">基色</param>
//        /// <param name="blend">混合色</param>
//        /// <returns>混合结果</returns>
//        public static Color Lighten(this Color origi, Color blend) => Color.FromArgb(Lighten(origi.R, blend.R), Lighten(origi.G, blend.G), Lighten(origi.B, blend.B));
//        /// <summary>
//        /// 滤色
//        /// </summary>
//        /// <param name="origi">基色</param>
//        /// <param name="blend">混合色</param>
//        /// <returns>混合结果</returns>
//        public static Color Screen(this Color origi, Color blend) => Color.FromArgb(Screen(origi.R, blend.R), Screen(origi.G, blend.G), Screen(origi.B, blend.B));

//        /// <summary>
//        /// 叠加，覆盖
//        /// </summary>
//        /// <param name="origi">基色</param>
//        /// <param name="blend">混合色</param>
//        /// <returns>混合结果</returns>
//        public static Color Overlay(this Color origi, Color blend) => Color.FromArgb(Overlay(origi.R, blend.R), Overlay(origi.G, blend.G), Overlay(origi.B, blend.B));

//        /// <summary>
//        /// 差值
//        /// </summary>
//        /// <param name="origi">基色</param>
//        /// <param name="blend">混合色</param>
//        /// <returns>混合结果</returns>
//        public static Color Difference(this Color origi, Color blend) => Color.FromArgb(Difference(origi.R, blend.R), Difference(origi.G, blend.G), Difference(origi.B, blend.B));


//        ///// <summary>
//        ///// 调整色阶
//        ///// </summary>
//        ///// <param name="origi">原始颜色</param>
//        ///// <param name="inShadow">黑场[0,253]</param>
//        ///// <param name="inHighLight">白场[2,255]</param>
//        ///// <param name="inMidtone">中间调[0.01,9.99]</param>
//        ///// <param name="outShadow">输出黑场[0,255]</param>
//        ///// <param name="outHighLight">输出白场[0,255]</param>
//        ///// <returns></returns>
//        //public static Color Level(this Color origi, int inShadow, int inHighLight, float inMidtone, int outShadow, int outHighLight)
//        //{
//        //    // 设定输入值取值范围
//        //    //inShadow = inShadow.SetMinMax(0, 253);
//        //    ////inHighLight = inHighLight.SetMinMax(2, 255);
//        //    //inHighLight = inHighLight.SetMinMax(inShadow + 2, 255);
//        //    //inMidtone = inMidtone.SetMinMax(0.01f, 9.99f);
//        //    //outShadow = outShadow.SetMinMax(0, 255);
//        //    //outHighLight = outHighLight.SetMinMax(0, 255);

//        //    byte level(byte rgb) => Math.Round(Math.Pow((double)(rgb - inShadow).SetMin(0) / (inHighLight - inShadow), 1d / inMidtone) * 255d * (outHighLight - outShadow) / 255d + outShadow).ToByte();
//        //    return Color.FromArgb(level(origi.R), level(origi.G), level(origi.B));


//        //    //// 计算像素各份量值与黑场的离差rgbDiff，如果rgbDiff <= 0，像素各份量值等于0
//        //    //int GetDiff(int rgb) => (rgb - inShadow).SetMin(0);
//        //    //var rDiff = GetDiff(origi.R);
//        //    //var gDiff = GetDiff(origi.G);
//        //    //var bDiff = GetDiff(origi.B);
//        //    //// 计算以rgbDiff与Diff的比值为底的灰场倒数的幂
//        //    //double LevelColor(int rgb)
//        //    //{
//        //    //    return Math.Pow((double)rgb / (inHighLight - inShadow), 1d / inMidtone) * 255d;
//        //    //}
//        //    //var clR = LevelColor(rDiff);
//        //    //var clG = LevelColor(gDiff);
//        //    //var clB = LevelColor(bDiff);

//        //    //// 输出色阶
//        //    //byte OutColor(double rgb)
//        //    //{
//        //    //    return ((int)(rgb * (outHighLight - outShadow) / 255 + outShadow)).ToByte();
//        //    //}
//        //    //return Color.FromArgb(OutColor(clR), OutColor(clG), OutColor(clB));
//        //}
//        /// <summary>
//        /// 取反色
//        /// </summary>
//        /// <param name="origi"></param>
//        /// <returns></returns>
//        public static Color Complementary(this Color origi) => Color.FromArgb(origi.A, 255 - origi.R, 255 - origi.G, 255 - origi.B);
//        /// <summary>
//        /// 去色
//        /// </summary>
//        /// <param name="origi"></param>
//        /// <param name="isPhotoshopMode">是否使用PS去色算法</param>
//        /// <returns></returns>
//        public static Color Decoloration(this Color origi, bool isPhotoshopMode = true)
//        {
//            byte result;
//            if (isPhotoshopMode) result = Math.Round((Math.Max(Math.Max(origi.R, origi.G), origi.B) + Math.Min(Math.Min(origi.R, origi.G), origi.B)) / 2d).ToByte();
//            else result = Math.Round((origi.R + origi.G + origi.B) / 3d).ToByte();
//            return Color.FromArgb(origi.A, result, result, result);
//        }
//        /// <summary>
//        /// 调整色阶
//        /// </summary>
//        /// <param name="origi"></param>
//        /// <param name="colorLevel"></param>
//        /// <returns></returns>
//        public static Color Level(this Color origi, ColorLevel colorLevel) => colorLevel.DoLevel(origi);

//    }

//    /// <summary>
//    /// 色阶参数
//    /// </summary>
//    public struct ColorLevel
//    {
//        private int inShadow;
//        private int inHighLight;
//        private float inMidtone;
//        private int outShadow;
//        private int outHighLight;

//        /// <summary>
//        /// 输入黑场[0,253]
//        /// </summary>
//        public int InShadow { get => this.inShadow; set => this.inShadow = value.Clamp(0, this.InHighLight); }
//        /// <summary>
//        /// 输入白场[2,255]
//        /// </summary>
//        public int InHighLight { get => this.inHighLight; set => this.inHighLight = value.Clamp(this.InHighLight, 255); }
//        /// <summary>
//        /// 输入中间调[0.01,9.99]
//        /// </summary>
//        public float InMidtone { get => this.inMidtone; set => this.inMidtone = value.Clamp(0.01f, 9.99f); }
//        /// <summary>
//        /// 输出黑场[0,255]
//        /// </summary>
//        public int OutShadow { get => this.outShadow; set => this.outShadow = value.Clamp(0, 255); }
//        /// <summary>
//        /// 输出中间调[0,255]
//        /// </summary>
//        public int OutHighLight { get => this.outHighLight; set => this.outHighLight = value.Clamp(0, 255); }


//        /// <summary>
//        /// 执行单通道色阶调整
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public byte DoLevel(byte value)
//        {
//            var result = Math.Pow((double)(value - this.inShadow).SetMin(0) / (this.InHighLight - this.InShadow), 1d / this.InMidtone) * 255d * (this.OutHighLight - this.OutShadow) / 255d + this.OutShadow;
//            return result.ToByte();
//        }
//        /// <summary>
//        /// 执行RGB通道色阶调整
//        /// </summary>
//        /// <param name="color"></param>
//        /// <returns></returns>
//        public Color DoLevel(Color color) => Color.FromArgb(color.A, DoLevel(color.R), DoLevel(color.G), DoLevel(color.B));
//        /// <summary>
//        /// 执行位图色阶调整
//        /// </summary>
//        /// <param name="bmp"></param>
//        /// <returns></returns>
//        public Bitmap DoLevel(Bitmap bmp)
//        {
//            for (var h = 0; h < bmp.Height; h++)
//                for (var w = 0; w < bmp.Width; w++)
//                    bmp.SetPixel(w, h, DoLevel(bmp.GetPixel(w, h)));
//            return bmp;
//        }

//        /// <summary>
//        /// 默认色阶
//        /// </summary>
//        public static ColorLevel Default => new ColorLevel() { inShadow = 0, inHighLight = 255, inMidtone = 1f, outShadow = 0, outHighLight = 255, };
//    }

//    /// <summary>
//    /// 混合模式
//    /// </summary>
//    public enum BlendMode
//    {
//        /// <summary>
//        /// 仅保留基色
//        /// </summary>
//        COPY,
//        /// <summary>
//        /// 仅保留混合色
//        /// </summary>
//        DESTINATION,

//        /// <summary>
//        /// 正常
//        /// </summary>
//        NORMAL,
//        /// <summary>
//        /// 平均
//        /// </summary>
//        AVERAGE,

//        /// <summary>
//        /// 变暗
//        /// </summary>
//        DARKEN,
//        /// <summary>
//        /// 乘算
//        /// </summary>
//        MULTIPLY,
//        /// <summary>
//        /// 颜色加深
//        /// </summary>
//        COLOR_BURN,
//        /// <summary>
//        /// 线性加深
//        /// </summary>
//        LINEAR_BURN,
//        /// <summary>
//        /// 深色
//        /// </summary>
//        DARKER_COLOR,

//        /// <summary>
//        /// 变亮
//        /// </summary>
//        LIGHTEN,
//        /// <summary>
//        /// 滤色
//        /// </summary>
//        SCREEN,
//        /// <summary>
//        /// 颜色减淡
//        /// </summary>
//        COLOR_DODGE,
//        /// <summary>
//        /// 线性减淡
//        /// </summary>
//        LINEAR_DODGE_ADD,
//        /// <summary>
//        /// 浅色
//        /// </summary>
//        LIGHTER_COLOR,

//        /// <summary>
//        /// 叠加
//        /// </summary>
//        OVERLAY,
//        /// <summary>
//        /// 柔光
//        /// </summary>
//        SOFT_LIGHT,
//        /// <summary>
//        /// 强光
//        /// </summary>
//        HARD_LIGHT,
//        /// <summary>
//        /// 亮光
//        /// </summary>
//        VIVID_LIGHT,
//        /// <summary>
//        /// 线性光
//        /// </summary>
//        LINEAR_LIGHT,
//        /// <summary>
//        /// 点光
//        /// </summary>
//        PIN_LIGHT,
//        /// <summary>
//        /// 实色混合
//        /// </summary>
//        HARD_MIX,

//        /// <summary>
//        /// 差值
//        /// </summary>
//        DIFFERENCE,
//        /// <summary>
//        /// 排除
//        /// </summary>
//        EXCLUSION,
//        /// <summary>
//        /// 减去
//        /// </summary>
//        SUBTRACT,
//        /// <summary>
//        /// 划分
//        /// </summary>
//        DIVIDE,

//        /// <summary>
//        /// 色相
//        /// </summary>
//        HUE,
//        /// <summary>
//        /// 饱和度
//        /// </summary>
//        SATURATION,
//        /// <summary>
//        /// 颜色
//        /// </summary>
//        COLOR,
//        /// <summary>
//        /// 明度
//        /// </summary>
//        LUMINOSITY
//    }

//    public struct ColorF
//    {
//        public float R;
//        public float G;
//        public float B;
//        /// <summary>
//        /// 不透明度
//        /// </summary>
//        public float A;

//        public override string ToString() => $"{this.R.ToString("0.00")},{this.G.ToString("0.00")},{this.B.ToString("0.00")},{this.A.ToString("0.00")}";
//        public ColorF(float r, float g, float b)
//        {
//            this.R = r.Clamp(0f, 1f);
//            this.G = g.Clamp(0f, 1f);
//            this.B = b.Clamp(0f, 1f);
//            this.A = 1f;
//        }
//        public ColorF(float r, float g, float b, float a)
//        {
//            this.R = r.Clamp(0f, 1f);
//            this.G = g.Clamp(0f, 1f);
//            this.B = b.Clamp(0f, 1f);
//            this.A = a.Clamp(0f, 1f);
//        }
//    }
//}
