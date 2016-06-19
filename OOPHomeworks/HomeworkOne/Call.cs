using System;

namespace HomeworkOneGSM
{
    public class Call
    {
      private string date;
      private string time;
      private string dialedNumber;
      private int durationInSeconds;


      public Call( string dialedNumber = "", string date = "", string time = "", int durationInSeconds = 0)
        {
            this.date = date;
            this.time = time;
            this.dialedNumber = dialedNumber;
            this.durationInSeconds = durationInSeconds;
        }

         public int DurationInSeconds				//Пропърти
         {
             get { return this.durationInSeconds; }
         }
         public override string ToString()   //Метод
         {
             return string.Format("Date: {0}, Time:  {1}, dialedNumber: {2}, Duration: {3} sec",
                  this.date, this.time, this.dialedNumber, this.durationInSeconds);
         }
    }
}
