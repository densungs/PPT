using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class DrawingState : IState
    {
        double _firstPointX;
        double _firstPointY;
        Shape _hint;

        //按下滑鼠
        public Shape MousePressed(string shapeType, double firstPointX, double firstPointY)
        {
            _hint = Factory.PaintShape(shapeType);
            _firstPointX = firstPointX;
            _firstPointY = firstPointY;
            return _hint;
        }

        //移動滑鼠
        public void MouseMove(double secondPointX, double secondPointY)
        {
            Point firstPoint = new Point(_firstPointX, _firstPointY);
            Point secondPoint = new Point(secondPointX, secondPointY);
            _hint.SetPosition(firstPoint, secondPoint);
        }

        //放開滑鼠
        public Shape MouseReleased(double secondPointX, double secondPointY)
        {
            Point firstPoint = new Point(_firstPointX, _firstPointY);
            Point secondPoint = new Point(secondPointX, secondPointY);
            _hint.SetPosition(firstPoint, secondPoint);
            return _hint;
        }

        //畫圖
        public void Draw(IGraphics graphics, double scaleX, double scaleY)
        {
            if (_hint != null)
                _hint.Draw(graphics, scaleX, scaleY);
        }
    }
}
