using System;
using System.Collections.Generic;
using System.Text;
using PiTest2.Model.Controller;

namespace PiTest2.Model.Entity
{
    /// <summary>
    /// Gpioピンの状態を持つクラス
    /// </summary>
    class Gpio
    {
        /// <summary>
        /// Gpioピン番号
        /// </summary>
        public int Id { get;set; }

        /// <summary>
        /// 方向
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// 値
        /// </summary>
        public int Value { get; set; }
    }
}
