namespace HomeWorkFive
{
    using log4net;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static readonly ILog logger =
          LogManager.GetLogger(typeof(StartUp));

        public static void Main(string[] args)
        {
            Shape[] testArray = { new Rectangle(2, 3), new Sqare(3), new Triangle(2, 5) };

            foreach (var shape in testArray)
            {
                Console.WriteLine("Surface of this {0} is: {1}", shape.GetType().ToString().Substring(13), shape.CalculateSurface());
                logger.Info($"Surface of {shape} was printed \n");
            }

            logger.Info("All shapes surfaces was printed \n");
        }
    }
}
