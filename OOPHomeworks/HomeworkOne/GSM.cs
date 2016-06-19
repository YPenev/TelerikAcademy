
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOneGSM
{
    public class GSM
    {
        public static readonly GSM Iphone4S = new GSM("Apple", "Iphone4S", 1200, "John", new Batteryes(120, 50, Batteryes.BatteryType.LiIon), new Displays(4.5, 120000));
        private string model;                              //Полета
        private string manufacturer;
        private double? price;
        private string owner;
        private Batteryes battery;
        private Displays display;
        private List<Call> callHistory = new List<Call>();

        public GSM(string Manufacturer, string Model, double? Price = null, string Owner = null, Batteryes Battery = null, Displays Display = null) //Конструктор
        {
            this.manufacturer = Manufacturer;
            this.model = Model;
            this.price = Price;
            this.owner = Owner;
            this.battery = Battery;
            this.display = Display;

        }

        public string Manufacturer				//Пропърти
        {
            get { return this.manufacturer; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Manufacturer cannot be empty!");
                }
                if (value.Length >= 50)
                {
                    throw new ArgumentException("Manufacturer too long! It should be less than 50 letters");
                }
                this.manufacturer = value;
            }
        }

        public string Model				//Пропърти
        {
            get { return this.model; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model cannot be empty!");
                }
                if (value.Length >= 50)
                {
                    throw new ArgumentException("Model too long! It should be less than 50 letters");
                }
                this.model = value;
            }
        }


        public double? Price				//Пропърти
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value must be positive !");
                }
                this.price = value;
            }
        }

        public string Owner				//Пропърти
        {
            get { return this.owner; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                if (value.Length >= 50)
                {
                    throw new ArgumentException("Name too long! It should be less than 50 letters");
                }
                this.owner = value;
            }
        }

        public Displays Display			      	//Пропърти
        {
            get { return this.display; }
            set { this.display = value; }
        }


        public Batteryes Battery				//Пропърти
        {
            get { return this.battery; }
            set { this.battery = value; }
        }


        public List<Call> CalHistory
        {
            get { return this.callHistory; }
        }


        public override string ToString()   //Метод
        {
            return string.Format("Manufacturer: {0}, Model: {1}, Prise: {2}, Owner: {3}, Display: {4}, Battery: {5}",
                this.manufacturer, this.model, this.price, this.owner, this.display.ToString(), this.battery.ToString());
        }

        public void ClearHistory()
        {
            this.callHistory.Clear();
        }

        public void AddCall(Call newCall)
        {
            this.callHistory.Add(newCall);
        }

        public void RemoveCall(Call newCall)
        {
            this.callHistory.RemoveAll(item => item == newCall);
        }

        public void RemoveCall(int index)
        {
            this.callHistory.Remove(this.callHistory[index]);
        }

        public double CallPrice(double prisePerMinute)
        {
            double fullDuration = 0;
          

            for (int i = 0; i < callHistory.Count; i++)
            {
                fullDuration += callHistory[i].DurationInSeconds ;
            }

            return fullDuration / 60 * prisePerMinute;
        }

        public void DisplayHistory()
        {
            if (callHistory.Count > 0)
            {
                Console.WriteLine("Full call history:");
                foreach (var call in callHistory)
                {
                    Console.WriteLine(call.ToString());
                }
            }
            else
            {
                Console.WriteLine("Call history is empty !");
            }
            
        }

        public int IndexOfLongestCal()
        {
            int maxDuration = 0;
            int maxIndex = 0;

            for (int i = 0; i < this.CalHistory.Count; i++)
            {
                if (this.CalHistory[i].DurationInSeconds > maxDuration)
                {
                    maxDuration = this.CalHistory[i].DurationInSeconds;
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }
}

