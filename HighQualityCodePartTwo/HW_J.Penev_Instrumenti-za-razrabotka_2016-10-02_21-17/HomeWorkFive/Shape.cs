namespace HomeWorkFive
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;

        /// <summary>
        /// Calculate surface of a current shape
        /// </summary>
        public abstract double CalculateSurface();
    }
}
