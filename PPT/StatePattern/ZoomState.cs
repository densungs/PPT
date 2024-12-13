using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class ZoomState : IState
    {
        Shape _hint;
        Shapes _shapes;
        Rectangle _outerFrame = new Rectangle();
        int _changeXName;
        int _changeYName;
        double _changeX;
        double _changeY;
        double _distanceX;
        double _distanceY;

        private double _x1
        {
            get
            {
                return _hint.GetStartPoint().X;
            }
        }
        private double _y1
        {
            get
            {
                return _hint.GetStartPoint().Y;
            }
        }
        private double _x2
        {
            get
            {
                return _hint.GetEndPoint().X;
            }
        }
        private double _y2
        {
            get
            {
                return _hint.GetEndPoint().Y;
            }
        }

        public ZoomState(Shapes shapes)
        {
            _shapes = shapes;
        }

        //確認更改的座標點X
        private void SetChangeX()
        {
            if (_x1 > _x2)
            {
                _changeX = _x1;
                _changeXName = 1;
            }
            else if (_x1 < _x2)
            {
                _changeX = _x2;
                _changeXName = Constant.NUMBER_TWO;
            }
        }

        //確認更改的座標點Y
        private void SetChangeY()
        {
            if (_y1 > _y2)
            {
                _changeY = _y1;
                _changeYName = 1;
            }
            else if (_y1 < _y2)
            {
                _changeY = _y2;
                _changeYName = Constant.NUMBER_TWO;
            }
        }

        //按下滑鼠
        public Shape MousePressed(string shapeType, double mousePointX, double mousePointY)
        {
            foreach (Shape aShape in _shapes.ShapesList)
            {
                if (aShape.GetIsSelect())
                {
                    _hint = aShape;
                    SetChangeX();
                    SetChangeY();
                    _distanceX = mousePointX - _changeX;
                    _distanceY = mousePointY - _changeY;
                    return _hint;
                }
            }
            return null;
        }

        //滑鼠移動
        public void MouseMove(double mousePointX, double mousePointY)
        {
            double changeX = mousePointX - _distanceX;
            double changeY = mousePointY - _distanceY;
            if (_changeXName == 1 && _changeYName == 1)
                _hint.SetPosition(new Point(changeX, changeY), new Point(_x2, _y2));
            else if (_changeXName == 1 && _changeYName == Constant.NUMBER_TWO)
                _hint.SetPosition(new Point(changeX, _y1), new Point(_x2, changeY));
            else if (_changeXName == Constant.NUMBER_TWO && _changeYName == 1)
                _hint.SetPosition(new Point(_x1, changeY), new Point(changeX, _y2));
            else if (_changeXName == Constant.NUMBER_TWO && _changeYName == Constant.NUMBER_TWO)
                _hint.SetPosition(new Point(_x1, _y1), new Point(changeX, changeY));
        }

        //放開滑鼠
        public Shape MouseReleased(double mousePointX, double mousePointY)
        {
            if (_hint != null)
            {
                double x = mousePointX - _distanceX;
                double y = mousePointY - _distanceY;
                if (_changeXName == 1 && _changeYName == 1)
                    _hint.SetPosition(new Point(x, y), new Point(_x2, _y2));
                else if (_changeXName == 1 && _changeYName == Constant.NUMBER_TWO)
                    _hint.SetPosition(new Point(x, _y1), new Point(_x2, y));
                else if (_changeXName == Constant.NUMBER_TWO && _changeYName == 1)
                    _hint.SetPosition(new Point(_x1, y), new Point(x, _y2));
                else if (_changeXName == Constant.NUMBER_TWO && _changeYName == Constant.NUMBER_TWO)
                    _hint.SetPosition(new Point(_x1, _y1), new Point(x, y));
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
    }
}
