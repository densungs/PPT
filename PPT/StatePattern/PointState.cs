using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class PointState : IState
    {
        Point _distanceMouseStart;
        Point _distanceMouseEnd;
        Shape _hint;
        Rectangle _outerFrame = new Rectangle();
        Shapes _shapes;

        public PointState(Shapes shapes)
        {
            _shapes = shapes;
        }

        private double _x1
        {
            get
            {
                return SelectWhichGraph().GetStartPoint().X;
            }
        }

        private double _y1
        {
            get
            {
                return SelectWhichGraph().GetStartPoint().Y;
            }
        }

        private double _x2
        {
            get
            {
                return SelectWhichGraph().GetEndPoint().X;
            }
        }

        private double _y2
        {
            get
            {
                return SelectWhichGraph().GetEndPoint().Y;
            }
        }

        //按下滑鼠
        public Shape MousePressed(string shapeType, double mousePointX, double mousePointY)
        {
            foreach (Shape aShape in _shapes.ShapesList)
            {
                if (aShape.IsInGraphRange(mousePointX, mousePointY))
                {
                    _distanceMouseStart = new Point(mousePointX - _x1, mousePointY - _y1);
                    _distanceMouseEnd = new Point(mousePointX - _x2, mousePointY - _y2);
                    _hint = aShape;
                    return _hint;
                }
            }
            return null;
        }

        //移動滑鼠
        public void MouseMove(double mousePointX, double mousePointY)
        {
            double x1 = mousePointX - _distanceMouseStart.X;
            double x2 = mousePointX - _distanceMouseEnd.X;
            double y1 = mousePointY - _distanceMouseStart.Y;
            double y2 = mousePointY - _distanceMouseEnd.Y;
            _hint.SetPosition(new Point(x1, y1), new Point(x2, y2));
        }

        //放開滑鼠
        public Shape MouseReleased(double mousePointX, double mousePointY)
        {
            if (_hint != null)
            {
                double x1 = mousePointX - _distanceMouseStart.X;
                double x2 = mousePointX - _distanceMouseEnd.X;
                double y1 = mousePointY - _distanceMouseStart.Y;
                double y2 = mousePointY - _distanceMouseEnd.Y;
                _hint.SetPosition(new Point(x1, y1), new Point(x2, y2));
                return _hint;
            }
            return null;
        }

        //畫圖
        public void Draw(IGraphics graphics, double scaleX, double scaleY)
        {
            if (_hint != null)
            {
                _outerFrame.Draw(graphics, scaleX, scaleY);
                _hint.Draw(graphics, scaleX, scaleY);
            }
        }

        //解決envy用的白癡東西
        public Shape SelectWhichGraph()
        {
            foreach (Shape aShape in _shapes.ShapesList)
            {
                if (aShape.GetIsSelect())
                    return aShape;
            }
            return null;
        }
    }
}
