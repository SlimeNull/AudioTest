using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audio.Visualizer.Win
{
    public class FFTHelp
    {
        /// <summary>
        /// 快速傅里叶变换（当信号源长度等于2^N时，结果与dft相同，当长度不等于2^N时，先在尾部补零，所以计算结果与dft不同）
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double[] fft(double[] array)
        {
            array = FillArray(array);            // 填充数组
            int N = array.Length;

            //生成WN表，以免运行时进行重复计算
            Complex[] WN = new Complex[N];
            for (int i = 0; i < N / 2; i++)
                WN[i] = new Complex(Math.Cos(2 * Math.PI / N * i), -1 * Math.Sin(2 * Math.PI / N * i));

            int stageNum = ReLog2N(N);
            int[] stage = new int[stageNum];
            stage[0] = 0;
            for (int i = 1; i < stageNum; i++)
            {
                stage[i] = Convert.ToInt32(Math.Round(Math.Pow(2, stageNum - 1 - i)));
            }

            //重排数据
            Complex[] Register = new Complex[N];
            for (int i = 0; i < N; i++)
            {
                int index = ReArrange(i, stageNum);
                Register[i] = new Complex(array[index], 0);
            }

            //蝶形运算
            Complex[] p = new Complex[N];
            Complex[] q = new Complex[N];
            Complex[] w = new Complex[N];
            int group = N;
            for (int i = 0; i < stageNum; i++)
            {
                group = group >> 1;
                int subnum = N / group;

                for (int k = 0; k < group; k++)
                {
                    for (int n = 0; n < subnum / 2; n++)
                    {
                        p[k * subnum + n] = p[k * subnum + n + subnum / 2] = Register[k * subnum + n];
                        w[k * subnum + n] = WN[stage[i] * n];
                    }

                    for (int n = subnum / 2; n < subnum; n++)
                    {
                        q[k * subnum + n] = q[k * subnum + n - subnum / 2] = Register[k * subnum + n];
                        w[k * subnum + n] = -1 * w[n - subnum / 2];
                    }
                }

                for (int k = 0; k < N; k++)
                {
                    Register[k] = p[k] + w[k] * q[k];
                }

            }

            double[] dest = new double[N];
            for (int k = 0; k < N; k++)
            {
                dest[k] = Register[k].Modulus();
            }
            return dest;
        }
        //public static double[] NFFT(double[] samples)
        //{

        //}
        public static double[] NDFT(double[] samples)
        {
            const double DoublePI = Math.PI * 2;         // 两个 PI, 即 360°
            int slen = samples.Length;    // samples Length
            return Enumerable
                .Range(0, slen)        // 频率
                .Select(f => samples   // 每一个频率的值
                    .Select((i, s) => s * new Complex(Math.Cos(DoublePI / slen * i * f), Math.Sin(DoublePI / slen * i * f)))
                    .Aggregate((v1, v2) => v1 + v2))
                .Select(v => v.Modulus())
                .ToArray();
        }
        /// <summary>
        /// 离散傅里叶变换
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double[] dft(double[] array)
        {
            //array = FillArray(array);
            int N = array.Length;

            //重排数据
            Complex[] Register = new Complex[N];
            Complex[] dest = new Complex[N];
            for (int i = 0; i < N; i++)
            {
                Register[i] = new Complex(array[i], 0);
            }
            // k 大概是表示一个频率, 求频率从0到N, 因为采样的长度是 N, 所以所求值大概是, 周期非常小和周期为采样长度的值...
            for (int k = 0; k < N; k++)
            {
                Complex sum = new Complex();     // 离散傅里叶变换就只能相加了, 数学上的傅里叶变换的话, 就是积分了
                // n 表示采样的索引
                for (int n = 0; n < N; n++)
                {
                    sum += Register[n] * (new Complex(Math.Cos(2 * Math.PI / N * n * k),
                                                      -1 * Math.Sin(2 * Math.PI / N * n * k)));
                }
                dest[k] = sum;
            }

            double[] dest2 = new double[N];
            for (int k = 0; k < N; k++)
            {
                dest2[k] = dest[k].Modulus();
            }
            return dest2;
        }
        /// <summary>
        /// 离散傅里叶逆变换
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double[] idft(double[] array)
        {
            //array = FillArray(array);
            int N = array.Length;

            //重排数据
            Complex[] Register = new Complex[N];
            Complex[] dest = new Complex[N];
            for (int i = 0; i < N; i++)
            {
                Register[i] = new Complex(array[i], 0);
            }
            for (int k = 0; k < N; k++)
            {
                Complex sum = new Complex();
                for (int n = 0; n < N; n++)
                {
                    sum += Register[n] * (new Complex(Math.Cos(2 * Math.PI / N * n * k), -1 * Math.Sin(2 * Math.PI / N * n * k)));
                }
                dest[k] = sum / N;
            }

            double[] dest2 = new double[N];
            for (int k = 0; k < N; k++)
            {
                dest2[k] = dest[k].Modulus();
            }
            return dest2;
        }
        /// <summary>
        /// 离散傅里叶变换
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static Complex[] dft(Complex[] array)
        {
            //array = FillArray(array);
            int N = array.Length;

            //重排数据
            Complex[] Register = array;
            Complex[] dest = new Complex[N];
            //for (int i = 0; i < N; i++)
            //{
            //    Register[i] = new Complex(array[i], 0);
            //}
            for (int k = 0; k < N; k++)
            {
                Complex sum = new Complex();
                for (int n = 0; n < N; n++)
                {
                    sum += Register[n] * (new Complex(Math.Cos(2 * Math.PI / N * n * k), -1 * Math.Sin(2 * Math.PI / N * n * k)));
                }
                dest[k] = sum;
            }

            //double[] dest2 = new double[N];
            //for (int k = 0; k < N; k++)
            //{
            //    dest2[k] = dest[k].Modulus();
            //}
            //return dest2;
            return dest;
        }

        /// <summary>
        /// 离散傅里叶逆变换
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static Complex[] idft(Complex[] array)
        {
            //array = FillArray(array);
            int N = array.Length;

            //重排数据
            Complex[] Register = array;
            Complex[] dest = new Complex[N];
            //for (int i = 0; i < N; i++)
            //{
            //    Register[i] = new Complex(array[i], 0);
            //}
            for (int k = 0; k < N; k++)
            {
                Complex sum = new Complex();
                for (int n = 0; n < N; n++)
                {
                    sum += Register[n] * (new Complex(Math.Cos(-2 * Math.PI / N * n * k), -1 * Math.Sin(-2 * Math.PI / N * n * k)));
                }
                dest[k] = sum / N;
            }

            //double[] dest2 = new double[N];
            //for (int k = 0; k < N; k++)
            //{
            //    dest2[k] = dest[k].Modulus();
            //}
            //return dest2;
            return dest;
        }

        /// <summary>
        /// 利用傅里叶变换实现的低通滤波（消除高频信号）
        /// </summary>
        /// <param name="array">信号源</param>
        /// <param name="n">截止频率</param>
        /// <returns></returns>
        public static double[] FFTFilter(double[] array, int n)
        {
            if (array == null || n <= 0 || array.Length <= n)
                return array;

            int N = array.Length;
            Complex[] Register = new Complex[N];
            for (int i = 0; i < N; i++)
            {
                Register[i] = new Complex(array[i], 0);
            }
            Complex[] dest = dft(Register);
            for (int i = 0; i < dest.Length; i++)
            {
                if (i > n && i < dest.Length - n)
                    dest[i].Im = dest[i].Re = 0;
            }
            Complex[] dest2 = idft(dest);

            double[] result = new double[dest2.Length];
            for (int i = 0; i < dest2.Length; i++)
            {
                result[i] = dest2[i].Modulus();
            }
            return result;
        }
        public static double[] FillArray(double[] array)
        {
            //补零后长度
            int len = 2 << (int)Math.Ceiling(Math.Log(array.Length, 2));
            double[] ret = new double[len];
            Array.Copy(array, ret, array.Length);
            return ret;
        }
        public static float[] FillArray(float[] array)
        {
            //补零后长度
            int len = 2 << (int)Math.Ceiling(Math.Log(array.Length, 2));
            float[] ret = new float[len];
            Array.Copy(array, ret, array.Length);
            return ret;
        }

        // 获取扩展长度后的幂次
        // 由于fft要求长度为2^n，所以用此函数来获取所需长度
        public static int ReLog2N(int count)
        {
            int log2N = 0;
            uint mask = 0x80000000;
            for (int i = 0; i < 32; i++)
            {
                if (0 != ((mask >> i) & count))
                {
                    if ((mask >> i) == count) log2N = 31 - i;
                    else log2N = 31 - i + 1;
                    break;
                }
            }
            return log2N;
        }

        // 获取按位逆序，bitlenght为数据长度
        // fft函数内使用
        private static int ReArrange(int dat, int bitlenght)
        {
            int ret = 0;
            for (int i = 0; i < bitlenght; i++)
            {
                if (0 != (dat & (0x01 << i))) ret |= ((0x01 << (bitlenght - 1)) >> i);
            }
            return ret;
        }
    }
    /// <summary>
    /// 表示一个复数
    /// </summary>
    public class Complex
    {
        public double Re;
        public double Im;
        public Complex() { }
        public Complex(double re) => (Re, Im) = (re, 0);
        public Complex(double re, double im) => (Re, Im) = (re, im);

        public double Modulus() => Math.Sqrt(Re * Re + Im * Im);

        public override string ToString()
        {
            string retStr;
            if (Math.Abs(Im) < 0.0001) retStr = Re.ToString("f4");
            else if (Math.Abs(Re) < 0.0001)
            {
                if (Im > 0) retStr = "j" + Im.ToString("f4");
                else retStr = "- j" + (0 - Im).ToString("f4");
            }
            else
            {
                if (Im > 0) retStr = Re.ToString("f4") + "+ j" + Im.ToString("f4");
                else retStr = Re.ToString("f4") + "- j" + (0 - Im).ToString("f4");
            }
            retStr += " ";
            return retStr;
        }

        //操作符重载
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Re + c2.Re, c1.Im + c2.Im);
        }
        public static Complex operator +(double d, Complex c)
        {
            return new Complex(d + c.Re, c.Im);
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.Re - c2.Re, c1.Im - c2.Im);
        }
        public static Complex operator -(double d, Complex c)
        {
            return new Complex(d - c.Re, -c.Im);
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.Re * c2.Re - c1.Im * c2.Im, c1.Re * c2.Im + c2.Re * c1.Im);
        }
        public static Complex operator *(Complex c, double d)
        {
            return new Complex(c.Re * d, c.Im * d);
        }
        public static Complex operator *(double d, Complex c)
        {
            return new Complex(c.Re * d, c.Im * d);
        }
        public static Complex operator /(Complex c, double d)
        {
            return new Complex(c.Re / d, c.Im / d);
        }
        public static Complex operator /(double d, Complex c)
        {
            double temp = d / (c.Re * c.Re + c.Im * c.Im);
            return new Complex(c.Re * temp, -c.Im * temp);
        }
        public static Complex operator /(Complex c1, Complex c2)
        {
            double temp = 1 / (c2.Re * c2.Re + c2.Im * c2.Im);
            return new Complex((c1.Re * c2.Re + c1.Im * c2.Im) * temp, (-c1.Re * c2.Im + c2.Re * c1.Im) * temp);
        }
    }
}
