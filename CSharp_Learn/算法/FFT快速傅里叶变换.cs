using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public static class FourierTransform
{
    public const double TAU = 2.0 * Math.PI;

    public static void fftLearn(Complex[] src, ref Complex[] dst, double id = 1.0)
    {
        var totalCount = src.Length;
        fft(src, ref dst, id);
        if (id < 0.0)
            for (int i = 0; i < dst.Length; i++)
                dst[i] /= dst.Length;

        void fft(Complex[] src, ref Complex[] dst, double id = 1.0)
        {
            var sampleCount = src.Length;
            var halfCount = sampleCount / 2;

            if (dst == null || dst == src || dst.Length != sampleCount)
                dst = new Complex[sampleCount];

            if (sampleCount == 1)
            {
                src.CopyTo(dst, 0);
                return;
            }

            var Pe = new Complex[halfCount];
            var Po = new Complex[halfCount];
            for (int i = 0; i < halfCount; i++)
            {
                Pe[i] = src[i * 2];
                Po[i] = src[i * 2 + 1];
            }

            if (halfCount > 1)
            {
                fft(Pe, ref Pe, id);
                fft(Po, ref Po, id);
            }

            var radTemp = -id * TAU / sampleCount;
            for (int i = 0; i < halfCount; i++)
            {
                var pe = Pe[i];
                var po = Po[i];
                var rad = radTemp * i;
                //var w_mul_po = po;
                //dst[i] = pe;
                //dst[i + halfCount] = po;
                var w_mul_po = new Complex(Math.Cos(rad), Math.Sin(rad)) * po;
                dst[i] = pe + w_mul_po;
                dst[i + halfCount] = pe - w_mul_po;
            }
        }
    }

    public static void FFT(Complex[] src, ref Complex[] dst, double id = 1.0)
    {
        var rank = Math.Log(src.Length, 2);
        if (rank != Math.Floor(rank))
        {
            throw new Exception("给定的源数据长度必须是2的指数次倍。");
            //var newLen = Convert.ToInt32(Math.Pow(2, Math.Ceiling(rank)));
            //dst = new Complex[newLen];
        }
        else if (dst == null || dst == src || dst.Length != src.Length)
            dst = new Complex[src.Length];
        var tempList = new Complex[dst.Length];

        src.CopyTo(dst, 0);

        fft(dst, tempList, 0, dst.Length, id);

        if (id < 0.0)
            for (int i = 0; i < dst.Length; i++)
                dst[i] /= dst.Length;

        void fft(Complex[] dst, Complex[] temp, int start, int count, double id = 1.0)
        {
            var halfCount = count / 2;

            if (count > 2)
            {
                for (int i = 0; i < halfCount; i++)
                {
                    var index = start + i * 2;
                    temp[i] = dst[index];
                    temp[i + halfCount] = dst[index + 1];
                }

                Array.Copy(temp, 0, dst, start, count);
            }

            if (halfCount > 1)
            {
                fft(dst, temp, start, halfCount, id);
                fft(dst, temp, start + halfCount, halfCount, id);
            }

            Array.Copy(dst, start, temp, start, count);
            var radTemp = -id * TAU / count;
            for (int i = 0; i < halfCount; i++)
            {
                var peIndex = start + i;
                var poIndex = peIndex + halfCount;
                var pe = temp[peIndex];
                var po = temp[poIndex];
                var rad = radTemp * i;
                var w_mul_po = new Complex(Math.Cos(rad), Math.Sin(rad)) * po;
                dst[peIndex] = pe + w_mul_po;
                dst[poIndex] = pe - w_mul_po;
            }
        }
    }

    /// <summary>
    /// 快速傅里叶变换(FFT)
    /// </summary>
    /// <param name="src">原数据</param>
    /// <param name="dst">目标数据</param>
    /// <param name="id">傅里叶变换为 1 ，逆变换为 -1</param>
    /// <returns></returns>
    public static void FFTOLD(Complex[] src, ref Complex[] dst, double id = 1.0)
    {
        var sampleCount = src.Length;
        var rank = Math.Log(src.Length, 2);
        if (rank != Math.Floor(rank))
        {
            throw new Exception("给定的源数据长度必须是2的指数次倍。");
            //var newLen = Convert.ToInt32(Math.Pow(2, Math.Ceiling(rank)));
            //dst = new Complex[newLen];
        }

        if (dst == null || dst == src || dst.Length != sampleCount)
            dst = new Complex[sampleCount];
        src.CopyTo(dst, 0);

        var ns = sampleCount / 2;
        var radTemp = 2.0 * Math.PI / (double)sampleCount;

        while (ns >= 1)
        {
            var arg = 0;
            for (var j0 = 0; j0 < sampleCount; j0 += 2 * ns)
            {
                var k = sampleCount / 4;

                var th = -id * radTemp * arg;
                var compTh = new Complex(Math.Cos(th), Math.Sin(th));

                for (var i0 = j0; i0 < j0 + ns; i0++)
                {
                    var i1 = i0 + ns;

                    var comp = dst[i1] * compTh;

                    dst[i1] = dst[i0] - comp;
                    dst[i0] = dst[i0] + comp;
                }

                while (k <= arg)
                {
                    arg -= k;
                    k /= 2;

                    if (k == 0) break;
                }

                arg += k;
            }
            ns /= 2;
        }

        // 逆変換
        if (id < 0)
            for (var i = 0; i < sampleCount; i++)
                dst[i] = dst[i] / (double)sampleCount;

        var j = 1;
        for (var i = 1; i < sampleCount; i++)
        {
            if (i <= j)
            {
                var comp = dst[i - 1];
                dst[i - 1] = dst[j - 1];
                dst[j - 1] = comp;
            }
            var k = sampleCount / 2;

            while (k < j)
            {
                j -= k;
                k /= 2;
            }
            j += k;
        }
    }

    /// <summary>
    /// 离散傅里叶变换(DFT)
    /// </summary>
    /// <param name="src">原数据</param>
    /// <param name="dst">目标数据</param>
    /// <param name="id">傅里叶变换为 1 ，逆变换为 -1</param>
    /// <returns></returns>
    public static void DFT(Complex[] src, ref Complex[] dst, double id = 1.0)
    {
        var sampleCount = src.Length;
        if (dst == null || dst.Length != sampleCount)
            dst = new Complex[sampleCount];

        for (int _w_t = 0; _w_t < sampleCount; _w_t++)
        {
            var sum = Complex.Zero;
            for (int _t_w = 0; _t_w < sampleCount; _t_w++)
            {
                var radTemp = TAU * _t_w * _w_t / sampleCount;
                sum += src[_t_w] * new Complex(Math.Cos(radTemp), -id * Math.Sin(radTemp));
            }
            //dst[_w_t] = sum / Math.Sqrt(sampleCount);
            dst[_w_t] = sum / (id < 0.0 ? (sampleCount) : 1.0);
        }
    }
    public static void DFT(double[] src, ref Complex[] dst)
        => DFT(src.Select(n => new Complex(n)).ToArray(), ref dst);
    public static void IDFT(Complex[] src, ref double[] dst)
    {
        if (dst == null || dst.Length != src.Length)
            dst = new double[src.Length];

        Complex[] tempDst = null;
        DFT(src, ref tempDst, -1.0);

        for (int i = 0; i < src.Length; i++)
            dst[i] = tempDst[i].real;
    }

    public static void DFT2D(Complex[] src, int width, int height, ref Complex[] dst, double id = 1.0)
    {
        var sampleCount = src.Length;
        if (sampleCount != width * height)
            throw null;

        if (dst == null || dst.Length != sampleCount)
            dst = new Complex[sampleCount];
        var tempDst = new Complex[sampleCount];

        for (int x = 0; x < width; x++)
        {
            for (int _w_t = 0; _w_t < height; _w_t++)
            {
                var sum = Complex.Zero;
                for (int _t_w = 0; _t_w < height; _t_w++)
                {
                    var radTemp = TAU * _t_w * _w_t / height;
                    sum += src[x * width + _t_w] * new Complex(Math.Cos(radTemp), -id * Math.Sin(radTemp));
                }
                //tempDst[x, _w_t] = sum / Math.Sqrt(height);
                tempDst[x * width + _w_t] = sum / (id < 0 ? height : 1.0);
            }
        }
        for (int y = 0; y < height; y++)
        {
            for (int _w_t = 0; _w_t < width; _w_t++)
            {
                var sum = Complex.Zero;
                for (int _t_w = 0; _t_w < width; _t_w++)
                {
                    var radTemp = TAU * _t_w * _w_t / width;
                    sum += tempDst[y + width * _t_w] * new Complex(Math.Cos(radTemp), -id * Math.Sin(radTemp));
                }
                //dst[_w_t, y] = sum / Math.Sqrt(width);
                dst[y + width * _w_t] = sum / (id < 0 ? width : 1.0);
            }
        }
    }
    public static void DFT2D(Complex[,] src, ref Complex[,] dst, double id = 1.0)
    {
        var sampleCount = src.Length;
        var width = src.GetLength(0);
        var height = src.GetLength(1);

        if (dst == null || dst.Length != sampleCount)
            dst = new Complex[width, height];
        var tempDst = new Complex[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int _w_t = 0; _w_t < height; _w_t++)
            {
                var sum = Complex.Zero;
                for (int _t_w = 0; _t_w < height; _t_w++)
                {
                    var radTemp = TAU * _t_w * _w_t / height;
                    sum += src[x, _t_w] * new Complex(Math.Cos(radTemp), -id * Math.Sin(radTemp));
                }
                //tempDst[x, _w_t] = sum / Math.Sqrt(height);
                tempDst[x, _w_t] = sum / (id < 0 ? height : 1.0);
            }
        }
        for (int y = 0; y < height; y++)
        {
            for (int _w_t = 0; _w_t < width; _w_t++)
            {
                var sum = Complex.Zero;
                for (int _t_w = 0; _t_w < width; _t_w++)
                {
                    var radTemp = TAU * _t_w * _w_t / width;
                    sum += tempDst[_t_w, y] * new Complex(Math.Cos(radTemp), -id * Math.Sin(radTemp));
                }
                //dst[_w_t, y] = sum / Math.Sqrt(width);
                dst[_w_t, y] = sum / (id < 0 ? width : 1.0);
            }
        }
    }

    /// <summary>
    /// 汉明窗
    /// </summary>
    /// <param name="data"></param>
    public static void Hamming(Complex[] data)
    {
        if (data == null) return;

        int dataCount = data.Length;

        var radTemp = 2.0 * Math.PI / (double)dataCount;

        for (int i = 0; i < dataCount; i++)
        {
            data[i] = data[i] * (0.54 - 0.46 * Math.Cos(radTemp * (double)i));
        }
    }

    /// <summary>
    /// 汉宁窗
    /// </summary>
    /// <param name="data"></param>
    public static void Hanning(Complex[] data)
    {
        if (data == null) return;

        int dataCount = data.Length;

        var radTemp = 2.0 * Math.PI / (double)dataCount;

        for (int i = 0; i < dataCount; i++)
        {
            data[i] = data[i] * (0.5 * (1.0 - Math.Cos(radTemp * (double)i)));
        }
    }

    /// <summary>
    /// 布莱克曼窗
    /// </summary>
    /// <param name="data"></param>
    public static void Blackman(Complex[] data)
    {
        if (data == null) return;

        int dataCount = data.Length;

        var radTemp = 2.0 * Math.PI / (double)dataCount;

        for (int i = 0; i < dataCount; i++)
        {
            data[i] = data[i] * (0.42 - 0.5 * Math.Cos(radTemp * (double)i) + 0.08 * Math.Cos(2.0 * radTemp * (double)i));
        }
    }

}


public struct Complex
{
    public double real;
    public double imaginary;

    public double Modulus => Math.Sqrt(real * real + imaginary * imaginary);
    public double Theta => Math.Atan2(imaginary, real);

    public readonly static Complex Zero = new Complex(0.0, 0.0);

    /// <summary>
    /// 从极坐标创建虚数
    /// </summary>
    /// <param name="r"></param>
    /// <param name="theta"></param>
    /// <returns></returns>
    public static Complex FromPolarCoordinates(double r, double theta)
        => new Complex(r * Math.Cos(theta), r * Math.Sin(theta));

    public Complex(double r, double i)
    {
        real = r;
        imaginary = i;
    }
    public Complex(double r) : this(r, 0.0) { }
    public Complex(Complex other) : this(other.real, other.imaginary) { }

    public override string ToString()
    {
        return $"({real:F2}, {imaginary:F2}i)";
    }
    public override bool Equals(object obj)
    {
        return obj is Complex complex &&
               real == complex.real &&
               imaginary == complex.imaginary;
    }
    public override int GetHashCode()
    {
        int hashCode = -1613305685;
        hashCode = hashCode * -1521134295 + real.GetHashCode();
        hashCode = hashCode * -1521134295 + imaginary.GetHashCode();
        return hashCode;
    }


    public static Complex operator +(in Complex l, in Complex r)
        => new Complex(l.real + r.real, l.imaginary + r.imaginary);
    public static Complex operator -(in Complex l, in Complex r)
        => new Complex(l.real - r.real, l.imaginary - r.imaginary);
    public static Complex operator *(in Complex l, in Complex r)
        => new Complex(l.real * r.real - l.imaginary * r.imaginary, l.real * r.imaginary + l.imaginary * r.real);
    public static Complex operator *(in Complex l, in double r)
        => new Complex(l.real * r, l.imaginary * r);
    public static Complex operator *(in double l, in Complex r)
        => new Complex(r.real * l, r.imaginary * l);
    public static Complex operator /(in Complex l, in double r)
        => new Complex(l.real / r, l.imaginary / r);

    public static bool operator ==(in Complex l, in Complex r)
        => ((l.real == r.real) && (l.imaginary == r.imaginary));
    public static bool operator !=(in Complex l, in Complex r)
        => !((l.real == r.real) && (l.imaginary == r.imaginary));

    public static implicit operator Complex(double value) => new Complex(value);
}
