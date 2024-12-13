using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Factory
    {
        //繪畫建立物件
        public static Shape PaintShape(string shapeType)
        {
            Shape newShape = SetShape(shapeType);
            newShape.SetPosition(new Point(0, 0), new Point(0, 0));
            return newShape;
        }

        //建立物件
        public static Shape CreateShape(string shapeType)
        {
            Random random = new Random();
            Point firstPoint = new Point(random.Next(0, Constant.STANDARD_WIDTH), random.Next(0, Constant.STANDARD_HEIGHT));
            Point secondPoint = new Point(random.Next(0, Constant.STANDARD_WIDTH), random.Next(0, Constant.STANDARD_HEIGHT));
            Shape newShape = SetShape(shapeType);
            newShape.SetPosition(firstPoint, secondPoint);
            return newShape;
        }

        //設定圖形
        private static Shape SetShape(string shapeType)
        {
            switch (shapeType)
            {
                case Constant.SHAPE_TYPE_LINE_CHINESE:
                    return new Line();
                case Constant.SHAPE_TYPE_RECTANGLE_CHINESE:
                    return new Rectangle();
                case Constant.SHAPE_TYPE_CIRCLE_CHINESE:
                    return new Circle();
                default:
                    return null;
            }
        }
    }
}
