using Cars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Tests.JustMock
{
    public static class FakeData
    {
        public static List<Car> CarList()
        {
            return new List<Car>
           {
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };
        }

    }
}
