using PiTest2.Model.Controller;
using PiTest2.Model.Helper;
using System;
using System.IO;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

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
            //2番ピンをオープンします。
            GpioOperationHelper.Open(2);

            //Lチカタスクを作成します。
            var task = Task.Run(async () =>
            {
                foreach(var i in Enumerable.Range(1,10))
                {
                    if (GpioOperationHelper.GetValue(2) == 1)
                    {
                        Console.WriteLine("Off");
                        GpioOperationHelper.SetValue(2, 0);
                    }
                    else
                    {
                        Console.WriteLine("On");
                        GpioOperationHelper.SetValue(2, 1);
                    }
                    await Task.Delay(1000);
                }
            });

            //タスクを実行し、完了を待機します。
            task.Wait();

            //2番ピンをクローズします。
            GpioOperationHelper.Close(2);
        }
    }
}
