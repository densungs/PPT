using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Circle : Shape
    {
        private double _rightDownX;
        private double _rightDownY;
        private double _startPointX
        {
            get
            {
                return StartPoint.X;
            }
        }
        private double _startPointY
        {
            get
            {
                return StartPoint.Y;
            }
        }
        private double _endPointX
        {
            get
            {
                return EndPoint.X;
            }
        }

        private double _endPointY
        {
            get
            {
                return EndPoint.Y;
            }
        }

        private int _layers;

        public Point StartPoint
        {
            get;
            set;
        }
        public Point EndPoint
        {
            get;
            set;
        }

        public bool IsSelect
        {
            get;
            set;
        }

        public Circle()
        {
            ShapeType = Constant.SHAPE_TYPE_CIRCLE_CHINESE;
        }

        //設定圖位置
        public override void SetPosition(Point firstPoint, Point secondPoint)
        {
            StartPoint = firstPoint;
            EndPoint = secondPoint;
            ShapeInformation = string.Format(Constant.SHAPE_INFORMATION, (int)StartPoint.X, (int)StartPoint.Y, (int)EndPoint.X, (int)EndPoint.Y);
        }

        //開始點
        public override Point GetStartPoint()
        {
            return StartPoint;
        }

        //結束點
        public override Point GetEndPoint()
        {
            return EndPoint;
        }

        //畫圓
        public override void Draw(IGraphics graphics, double scaleX, double scaleY)
        {
            graphics.DrawCircle(ConvertCoordinate(StartPoint.X, scaleX), ConvertCoordinate(StartPoint.Y, scaleY), ConvertCoordinate(EndPoint.X, scaleX), ConvertCoordinate(EndPoint.Y, scaleY));
            if (IsSelect)
            {
                graphics.DrawOuterFrame(ConvertCoordinate(StartPoint.X, scaleX), ConvertCoordinate(StartPoint.Y, scaleY), ConvertCoordinate(EndPoint.X, scaleX), ConvertCoordinate(EndPoint.Y, scaleY));
            }
        }

        //鼠標是否在圖內
        public override bool IsInGraphRange(double mousePointX, double mousePointY)
        {
            if (Math.Min(StartPoint.X, EndPoint.X) <= mousePointX && Math.Max(StartPoint.X, EndPoint.X) >= mousePointX && Math.Min(StartPoint.Y, EndPoint.Y) <= mousePointY && Math.Max(StartPoint.Y, EndPoint.Y) >= mousePointY)
            {
                IsSelect = true;
                return true;
            }
            else
            {
                IsSelect = false;
                return false;
            }
        }

        //是否在圖的右下角
        public override bool IsInRightDownRange(double mousePointX, double mousePointY)
        {
            if (_startPointX > _endPointX)
                _rightDownX = _startPointX;
            else if (_startPointX < _endPointX)
                _rightDownX = _endPointX;
            if (_startPointY > _endPointY)
                _rightDownY = _startPointY;
            else if (_startPointY < _endPointY)
                _rightDownY = _endPointY;
            if (_rightDownX - Constant.NUMBER_TEN <= mousePointX && _rightDownX + Constant.NUMBER_TEN >= mousePointX && _rightDownY - Constant.NUMBER_TEN <= mousePointY && _rightDownY + Constant.NUMBER_TEN >= mousePointY)
                return true;
            else
                return false;
        }

        //設定選取
        public override void SetIsSelect(bool isSelect)
        {
            IsSelect = isSelect;
        }

        //看物件是否被選取
        public override bool GetIsSelect()
        {
            return IsSelect;
        }

        //設定圖層
        public override void SetLayers(int layers)
        {
            _layers = layers;
        }

        //獲取圖層
        public override int GetLayers()
        {
            return _layers;
        }

        //獲取型態
        public override Shape GetType()
        {
            return new Circle();
        }

        //轉換座標
        private double ConvertCoordinate(double number, double scale)
        {
            return number * scale;
        }
    }
}