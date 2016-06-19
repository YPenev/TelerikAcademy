using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOneGSM
{
  public  class GSMTest
    {
     public static void Test()
      {
          //  Manufacturer,  Model,  Price ,  Owner ,  Battery,  Display )
          GSM[] test = new GSM[3];

          test[0] = new GSM("HTC", "one", 200, "Pesho", new Batteryes(100,40,Batteryes.BatteryType.LiIon),new Displays(4.5, 100000));
          test[1] = new GSM("Lenovo", "Touch", 100, "Ivan", new Batteryes(200, 50, Batteryes.BatteryType.NiCd), new Displays(5, 300000));
          test[2] = new GSM("Nokia", "SFenerche", 200, "Gosho", new Batteryes(1500,100,Batteryes.BatteryType.NiMH),new Displays(2, 100));

          foreach (var gsm in test)
          {
              Console.WriteLine(gsm.ToString());
              Console.WriteLine();
          }

          Console.WriteLine(GSM.Iphone4S.ToString());
      }

    }
}
