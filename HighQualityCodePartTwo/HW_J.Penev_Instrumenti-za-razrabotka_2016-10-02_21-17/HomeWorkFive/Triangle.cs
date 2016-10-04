namespace HomeWorkFive
{
    public class Triangle : Shape
    {
        private double width;
        private double height;

        /// <summary>
        /// Create triangele
        /// </summary>
        public Triangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Calculate surface of the triangle
        /// </summary>
        public override double CalculateSurface()
        {
            return this.width * this.height / 2;
        }
    }
}
