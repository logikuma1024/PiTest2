using System;
using System.IO;

namespace PiTest2
{
    class Program
    {
        /// <summary>
        /// Application Entry
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Raspberry Pi Test");

            //とりあえず2番ピンでテスト
            if (!Directory.Exists(@"/sys/class/gpio/gpio2"))
            {
                Console.WriteLine("open ping 2");

                File.WriteAllText("/sys/class/gpio/export", "2");
            }
            else
            {
                Console.WriteLine("...pin is already open");
            }

            Console.WriteLine("...specifying direction of Pin 2 as OUT");
            File.WriteAllText("/sys/class/gpio/gpio2/direction", "out");

            File.WriteAllText("/sys/class/gpio/gpio2/value", "1");
        }
    }
}
