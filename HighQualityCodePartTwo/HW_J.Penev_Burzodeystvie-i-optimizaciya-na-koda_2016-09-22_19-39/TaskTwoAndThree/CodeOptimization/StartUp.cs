//Write a program to compare the performance of:
//  add, subtract, increment, multiply, divide
//for the values:
//  int, long, float, double and decimal

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeOptimization
{
    class StartUp
    {
        static void Main(string[] args)
        {
            TestCases.FullSimpleMathTest("int");
            TestCases.FullSimpleMathTest("float");
            TestCases.FullSimpleMathTest("long");
            TestCases.FullSimpleMathTest("double");
            TestCases.FullSimpleMathTest("decimal");

            TestCases.FullAdvancedMathTest("float");
            TestCases.FullAdvancedMathTest("double");
            TestCases.FullAdvancedMathTest("decimal");
        }
    }
}
