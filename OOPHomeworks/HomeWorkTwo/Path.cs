namespace OOPHomeworkTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class Path
    {
      private List<Point3D> pathList = new List<Point3D>();
        
        public void Add(Point3D newPoint)
        {
            this.pathList.Add(newPoint);
        }

        public int PathLenght()
        {
            return this.pathList.Count;
        }

        public Point3D GetValueAtIndex( int index)
        {
            return this.pathList[index];
        }
    }
}
