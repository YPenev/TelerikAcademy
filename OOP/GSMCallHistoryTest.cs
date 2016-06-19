using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOneGSM
{
    public class GSMCallHistoryTest
    {
        public static void Test()
        {
            GSM callTestGSM = new GSM("HTC", "one", 200, "Pesho", new Batteryes(100, 40, Batteryes.BatteryType.LiIon), new Displays(4.5, 100000));

            callTestGSM.AddCall(new Call("0888085482", "17.02.16", "12:02", 200));
            callTestGSM.AddCall(new Call("0888565472", "17.02.16", "15:22", 50));
            callTestGSM.AddCall(new Call("0888023652", "17.02.16", "15:42", 20));
            callTestGSM.AddCall(new Call("0881246536", "17.02.17", "10:05", 300));

            callTestGSM.DisplayHistory();

            Console.WriteLine("Total price: {0:0.00}", callTestGSM.CallPrice(0.35));

            callTestGSM.RemoveCall(callTestGSM.IndexOfLongestCal());

            Console.WriteLine("Total price: {0:0.00}", callTestGSM.CallPrice(0.35));

            Console.WriteLine("Cleaning the history...");
            callTestGSM.ClearHistory();

            callTestGSM.DisplayHistory();
        }
    }


}
