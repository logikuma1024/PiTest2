using PiTest2.Model.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PiTest2.Model.Controller
{
    /// <summary>
    /// Gpioピンの状態を制御するクラス
    /// ------------------------------
    /// </summary>
    public class GpioStateController
    {
        //Gpioの現在状態
        private List<Gpio> _gpioStateList;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GpioStateController()
        {
            //stateListを取得する
            _gpioStateList = Directory.EnumerateDirectories(@"/sys/class/gpio/", "*", SearchOption.TopDirectoryOnly)
                                    .Where(x => x.StartsWith("gpiochip") && x.StartsWith("gpio"))
                                    .Select(x => new Gpio {
                                        Id = Convert.ToInt32(x.Replace("gpio","")),
                                        Direction = File.ReadAllText($"/sys/class/gpio/{x}/direction", Encoding.Default),
                                        Value = Convert.ToInt32(File.ReadAllText($"/sys/class/gpio/{x}/value", Encoding.Default))
                                    }).ToList();
        }

        /// <summary>
        /// 対象のgpioピンがオープン済かを確認します。
        /// </summary>
        /// <param name="gpio"></param>
        /// <returns></returns>
        public bool IsOpen(int gpio)
        {
            return _gpioStateList.Any(x => x.Id == gpio);
        }
    }
}
