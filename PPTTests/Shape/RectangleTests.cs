using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        private Rectangle _rectangle;
        private MockGraphics _mockGraphics;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _rectangle = new Rectangle();
            _mockGraphics = new MockGraphics();
        }

        //設定圖位置
        [TestMethod()]
        public void SetPositionTest()
        {
            _rectangle.SetPosition(new Point(0, 0), new Point(10, 10));
            Assert.AreEqual(new Point(0, 0), _rectangle.StartPoint);
            Assert.AreEqual(new Point(10, 10), _rectangle.EndPoint);
            Assert.AreEqual(string.Format("({0}, {1}), ({2}, {3})", 0, 0, 10, 10), _rectangle.ShapeInformation);

            _rectangle.SetPosition(new Point(7, 50), new Point(-3, 27));
            Assert.AreEqual(new Point(7, 50), _rectangle.GetStartPoint());
            Assert.AreEqual(new Point(-3, 27), _rectangle.GetEndPoint());
            Assert.AreEqual(string.Format("({0}, {1}), ({2}, {3})", 7, 50, -3, 27), _rectangle.ShapeInformation);
        }

        //畫矩形
        [TestMethod()]
        public void DrawTest()
        {
            _rectangle.StartPoint = new Point(0, 0);
            _rectangle.EndPoint = new Point(100, 100);
            _rectangle.SetIsSelect(false);
            _rectangle.Draw(_mockGraphics, 1, 1);
            Assert.AreEqual(_mockGraphics._startPoint, new Point(0, 0));
            Assert.AreEqual(_mockGraphics._endPoint, new Point(100, 100));
            Assert.IsTrue(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawCircleCalled);
            Assert.IsFalse(_mockGraphics._isDrawOuterFrameCalled);
            _rectangle.SetIsSelect(true);
            _rectangle.Draw(_mockGraphics, 1, 1);
            Assert.IsTrue(_mockGraphics._isDrawRectangleCalled);
            Assert.IsTrue(_mockGraphics._isDrawOuterFrameCalled);
        }

        //鼠標是否在範圍內
        [TestMethod()]
        public void IsInGraphRangeTest()
        {
            _rectangle.StartPoint = new Point(0, 0);
            _rectangle.EndPoint = new Point(50, 400);

            Assert.IsTrue(_rectangle.IsInGraphRange(0, 0));
            Assert.IsTrue(_rectangle.GetIsSelect());
            Assert.IsTrue(_rectangle.IsInGraphRange(0, 400));
            Assert.IsTrue(_rectangle.GetIsSelect());
            Assert.IsTrue(_rectangle.IsInGraphRange(50, 0));
            Assert.IsTrue(_rectangle.GetIsSelect());
            Assert.IsFalse(_rectangle.IsInGraphRange(-1, -1));
            Assert.IsFalse(_rectangle.GetIsSelect());
            Assert.IsFalse(_rectangle.IsInGraphRange(25, 401));
            Assert.IsFalse(_rectangle.GetIsSelect());
        }

        //是否在圖的右下角
        [TestMethod()]
        public void IsInRightDownRangeTest()
        {
            _rectangle.StartPoint = new Point(0, 0);
            _rectangle.EndPoint = new Point(50, 400);
            Assert.IsFalse(_rectangle.IsInRightDownRange(0, 0));
            Assert.IsFalse(_rectangle.IsInRightDownRange(50, 415));
            Assert.IsFalse(_rectangle.IsInRightDownRange(35, 400));
            Assert.IsTrue(_rectangle.IsInRightDownRange(50, 400));
            Assert.IsTrue(_rectangle.IsInRightDownRange(48, 398));
            Assert.IsTrue(_rectangle.IsInRightDownRange(52, 402));
            _rectangle.StartPoint = new Point(50, 400);
            _rectangle.EndPoint = new Point(0, 0);
            Assert.IsFalse(_rectangle.IsInRightDownRange(0, 0));
            Assert.IsFalse(_rectangle.IsInRightDownRange(50, 415));
            Assert.IsFalse(_rectangle.IsInRightDownRange(35, 400));
            Assert.IsTrue(_rectangle.IsInRightDownRange(50, 400));
            Assert.IsTrue(_rectangle.IsInRightDownRange(48, 398));
            Assert.IsTrue(_rectangle.IsInRightDownRange(52, 402));
        }

        //設定選取
        [TestMethod()]
        public void SetIsSelectTest()
        {
            _rectangle.SetIsSelect(true);
            Assert.IsTrue(_rectangle.GetIsSelect());
            _rectangle.SetIsSelect(false);
            Assert.IsFalse(_rectangle.GetIsSelect());
        }
    }
}