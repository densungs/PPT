using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    public class MockGraphics : IGraphics
    {
        public Point _startPoint
        {
            get;
            private set;
        }
        public Point _endPoint
        {
            get;
            private set;
        }
        public bool _isClearAllCalled = false;
        public bool _isDrawLineCalled = false;
        public bool _isDrawRectangleCalled = false;
        public bool _isDrawCircleCalled = false;
        public bool _isDrawOuterFrameCalled = false;

        //清除
        public void ClearAll()
        {
            _isClearAllCalled = true;
        }

        //畫線
        public void DrawLine(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            _startPoint = new Point(firstPointX, firstPointY);
            _endPoint = new Point(secondPointX, secondPointY);
            _isDrawLineCalled = true;
        }

        //畫矩形
        public void DrawRectangle(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            _startPoint = new Point(firstPointX, firstPointY);
            _endPoint = new Point(secondPointX, secondPointY);
            _isDrawRectangleCalled = true;
        }

        //畫圓
        public void DrawCircle(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            _startPoint = new Point(firstPointX, firstPointY);
            _endPoint = new Point(secondPointX, secondPointY);
            _isDrawCircleCalled = true;
        }

        //畫外框
        public void DrawOuterFrame(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            _startPoint = new Point(firstPointX, firstPointY);
            _endPoint = new Point(secondPointX, secondPointY);
            _isDrawOuterFrameCalled = true;
        }
    }
}
