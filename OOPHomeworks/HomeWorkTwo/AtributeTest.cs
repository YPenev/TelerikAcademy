using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPHomeworkTwo
{
    using System;

    [Version(1,11)]

    public class AtributeTest
    {
        public static void Test()
        {
            Type type = typeof(AtributeTest);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attr in allAttributes)
            {
                Console.WriteLine("AttributeTest is version: "+attr.ToString());
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString() + " is version: " + attr.ToString());
            }
        }        
    }
   
}
