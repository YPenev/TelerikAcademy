using Abstraction;
using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileOperations.GetExtension("example"));
            Console.WriteLine(FileOperations.GetExtension("example.pdf"));
            Console.WriteLine(FileOperations.GetExtension("example.new.pdf"));

            Console.WriteLine(FileOperations.GetNameWithoutExtension("example"));
            Console.WriteLine(FileOperations.GetNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileOperations.GetNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                ObjectCalculator.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                ObjectCalculator.CalcDistance3D(5, 2, -1, 3, -6, 4));

            
            var figure = new Simple3DFigure(5,4,3);

            Console.WriteLine("Volume = {0:f2}", ObjectCalculator.CalcVolume(figure));
            Console.WriteLine("Diagonal XYZ = {0:f2}", ObjectCalculator.CalcDiagonalXYZ(figure));
            Console.WriteLine("Diagonal XY = {0:f2}", ObjectCalculator.CalcDiagonalXY(figure));
            Console.WriteLine("Diagonal XZ = {0:f2}", ObjectCalculator.CalcDiagonalXZ(figure));
            Console.WriteLine("Diagonal YZ = {0:f2}", ObjectCalculator.CalcDiagonalYZ(figure));
        }
    }
}
