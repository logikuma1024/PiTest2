using PiTest2.Model.Helper;
using System;
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
            //2番ピンが開いていない場合はOpenします。
            GpioOperationHelper.Open(2);

            //書き込み可能方向にします。
            GpioOperationHelper.SetDirection(2, GpioDirection.Out);

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
                    await Task.Delay(500);
                }
            });

            //タスクを実行し、完了を待機します。
            task.Wait();
        }
    }
}
