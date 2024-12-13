using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public partial class Point
    {
        public double X
        {
            get;
            set;
        }
        public double Y
        {
            get;
            set;
        }
        public Point(double coordinateX, double coordinateY)
        {
            X = coordinateX;
            Y = coordinateY;
        }

        //給unit test加的東東
        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        //給unit test加的東東
        public override bool Equals(object aObject)
        {
            return Equals(aObject as Point);
        }

        //給unit test加的東東
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
