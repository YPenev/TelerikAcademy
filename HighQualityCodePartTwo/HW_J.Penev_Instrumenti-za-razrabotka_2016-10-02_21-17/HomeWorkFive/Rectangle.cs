namespace HomeWorkFive
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;

        /// <summary>
        /// Create rectangle
        /// </summary>
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Calculate surface of the rectange
        /// </summary>
        public override double CalculateSurface()
        {
            return this.width * this.height;
        }
    }
}
