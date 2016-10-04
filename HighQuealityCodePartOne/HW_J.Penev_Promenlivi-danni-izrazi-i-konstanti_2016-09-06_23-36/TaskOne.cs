public class Size
{
    private double width;
    private double hight;

    public Size(double Width, double Hight)
    {
        this.width = Width;
        this.hight = Hight;
    }

    public double Width
    {
        get
        {
            return this.width;
        }
        set
        {
            this.width = value;
        }
    }

    public double Hight
    {
        get
        {
            return this.hight;
        }
        set
        {
            this.hight = value;
        }
    }
}

public static class SizeOperations
{
    /// <summary>
    /// Return size of rotated figure
    /// </summary>
    /// <param size of the figure that we want ro rotate ="figureSize"></param>
    /// <param angle of rotation in degree="rotationAngle"></param>
    public static Size GetRotatedSize(Size figureSize, double rotationAngle)
    {
        var sinOfAngle = Math.Sin(rotationAngle);
        var cosOfAngle = Math.Cos(rotationAngle);

        var rootOfSinOfAngle = Math.Abs(sinOfAngle);
        var rootOfCosOfAngle = Math.Abs(cosOfAngle);

        var WidthOfRotatedFigure = cosOfAngle * figureSize.Width + sinOfAngle * figureSize.Hight;
        var HightOfRotatedFigure = sinOfAngle * figureSize.Width + cosOfAngle * figureSize.Hight;

        return new Size(WidthOfRotatedFigure, HightOfRotatedFigure);
    }
}