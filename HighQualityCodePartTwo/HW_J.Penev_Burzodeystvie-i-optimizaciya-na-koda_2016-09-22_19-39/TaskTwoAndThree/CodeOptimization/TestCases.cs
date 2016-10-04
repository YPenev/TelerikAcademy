using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeOptimization
{
  public static  class TestCases
    {
      public static void FullSimpleMathTest(string type)
      {
          Console.Write("Add (" + type + ") : ");
          Console.WriteLine(SimpleMathComparator.AddComparator(type));
          Console.Write("Subtract (" + type + ") : ");
          Console.WriteLine(SimpleMathComparator.SubtarctComparator(type));
          Console.Write("Increment (" + type + ") : ");
          Console.WriteLine(SimpleMathComparator.IncrementComparator(type));
          Console.Write("Multiply (" + type + ") : ");
          Console.WriteLine(SimpleMathComparator.MultiplyComparator(type));
          Console.Write("Divide (" + type + ") : ");
          Console.WriteLine(SimpleMathComparator.DivideComparator(type));
          Console.WriteLine();
          Console.WriteLine();
      }

      public static void FullAdvancedMathTest(string type)
      {
          Console.Write("Square root (" + type + ") : ");
          Console.WriteLine(AdvancedMathComparator.SqareRootComparator(type));
          Console.Write("Natural logarithm (" + type + ") : ");
          Console.WriteLine(AdvancedMathComparator.NaturalLogarithmComparator(type));
          Console.Write("Sinus (" + type + ") : ");
          Console.WriteLine(AdvancedMathComparator.SinusComparator(type));
          Console.WriteLine();
          Console.WriteLine();
      }

    }
}
