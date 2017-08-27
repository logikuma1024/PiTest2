using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace PiTest2.Model.Helper
{
    /// <summary>
    /// Gpio操作をヘルプするクラス
    /// ------------------------------
    /// FixMe:規模が大きくなってきたら、状態管理クラスとしてDI管理を追加して制御クラスにしたい。
    /// 現在のままだと、存在しないGpioであったりデータ方向が適正でない場合に良い制御ができない。
    /// </summary>
    class GpioOperationHelper
    {
        /// <summary>
        /// 指定したgpioピンをオープンします。
        /// </summary>
        /// <param name="gpio"></param>
        public static void Open(int gpio)
        {
            File.WriteAllText("/sys/class/gpio/export", gpio.ToString());
        }

        /// <summary>
        /// 指定したgpioピンをクローズします。
        /// </summary>
        /// <param name="gpio"></param>
        public static void Close(int gpio)
        {
            File.WriteAllText("/sys/class/gpio/unexport", gpio.ToString());
        }

        /// <summary>
        /// 指定したgpioピンがオープン済みかを確認します。
        /// </summary>
        /// <param name="gpio"></param>
        /// <returns></returns>
        public static bool IsOpen(int gpio)
        {
            return Directory.Exists($"/sys/class/gpio/gpio{gpio}");
        }

        /// <summary>
        /// 指定したgpioピンのデータ設定方向を取得します。
        /// </summary>
        /// <param name="direction"></param>
        public static string GetDirection(int gpio)
        {
            return File.ReadAllText($"/sys/class/gpio/gpio{gpio}/direction",Encoding.Default);
        }

        /// <summary>
        /// 指定したgpioピンにデータ設定方向を設定します。
        /// </summary>
        /// <param name="gpio"></param>
        /// <param name="direction"></param>
        public static void SetDirection(int gpio, GpioDirection direction)
        {
            if(direction == GpioDirection.In)
                File.WriteAllText($"/sys/class/gpio/gpio{gpio}/direction", "in");
            else
                File.WriteAllText($"/sys/class/gpio/gpio{gpio}/direction", "out");
        }

        /// <summary>
        /// 指定したgpioピンのvalueを取得します。
        /// </summary>
        /// <param name="gpio"></param>
        /// <returns></returns>
        public static int GetValue(int gpio)
        {
            return Convert.ToInt32(File.ReadAllText($"/sys/class/gpio/gpio{gpio}/value", Encoding.Default));
        }

        /// <summary>
        /// 指定したgpioピンのvalueを設定します。
        /// </summary>
        /// <param name="gpio"></param>
        /// <param name="value"></param>
        public static void SetValue(int gpio, int value)
        {
            File.WriteAllText($"/sys/class/gpio/gpio{gpio}/value", value.ToString());
        }
    }

    /// <summary>
    /// Gpioのデータ取得方向
    /// </summary>
    public enum GpioDirection
    {
        In,Out
    }
}
