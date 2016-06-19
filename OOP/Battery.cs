using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOneGSM
{
    public class Batteryes
    {
        private int? hoursIdle;
        private int? hoursTalk;
        private BatteryType? type;


        public Batteryes(int? HoursIdle, int? HoursTalk, BatteryType Type)
        {
            this.hoursIdle = HoursIdle;
            this.hoursTalk = HoursTalk;
            this.type = Type;
        }

        public Batteryes()
            : this(null, null, BatteryType.unknown)
        {
        }

        public enum BatteryType //Енумератор
        {
            unknown,
            LiIon,
            NiMH,
            NiCd
        }

        public int? HoursIdle				//Пропърти
        {
            get { return this.hoursIdle; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value must be positive !");
                }
                this.hoursIdle = value;
            }
        }
        public int? HoursTalk				//Пропърти
        {
            get { return this.hoursTalk; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value must be positive !");
                }
                this.hoursTalk = value;
            }
        }
        public BatteryType? Type				//Пропърти
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public override string ToString()   //Метод
        {
            return string.Format("HoursIdle - {0}, HoursTalk - {1}, Type - {2}",
                 this.hoursIdle, this.hoursTalk, this.type);
        }
    }
}
