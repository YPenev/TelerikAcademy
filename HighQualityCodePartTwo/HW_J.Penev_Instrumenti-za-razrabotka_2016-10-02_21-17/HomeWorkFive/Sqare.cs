namespace HomeWorkFive
{
    public class Sqare : Shape
    {
        private double width;
        private double height;

        /// <summary>
        /// Create sqare
        /// </summary>
        public Sqare(double width)
        {
            this.width = width;
            this.height = width;
        }

        /// <summary>
        /// Calculate surface of the square
        /// </summary>
        public override double CalculateSurface()
        {
            return this.width * this.height;
        }
    }
}
