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
    public class CircleTests
    {
        private Circle _circle;
        private MockGraphics _mockGraphics;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _circle = new Circle();
            _mockGraphics = new MockGraphics();
        }

        //設定圖位置
        [TestMethod()]
        public void SetPositionTest()
        {
            _circle.SetPosition(new Point(0, 0), new Point(10, 10));
            Assert.AreEqual(new Point(0, 0), _circle.StartPoint);
            Assert.AreEqual(new Point(10, 10), _circle.EndPoint);
            Assert.AreEqual(string.Format("({0}, {1}), ({2}, {3})", 0, 0, 10, 10), _circle.ShapeInformation);

            _circle.SetPosition(new Point(7, 50), new Point(-3, 27));
            Assert.AreEqual(new Point(7, 50), _circle.GetStartPoint());
            Assert.AreEqual(new Point(-3, 27), _circle.GetEndPoint());
            Assert.AreEqual(string.Format("({0}, {1}), ({2}, {3})", 7, 50, -3, 27), _circle.ShapeInformation);
        }

        //畫圓
        [TestMethod()]
        public void DrawTest()
        {
            _circle.StartPoint = new Point(0, 0);
            _circle.EndPoint = new Point(100, 100);
            _circle.SetIsSelect(false);
            _circle.Draw(_mockGraphics, 1, 1);
            Assert.AreEqual(_mockGraphics._startPoint, new Point(0, 0));
            Assert.AreEqual(_mockGraphics._endPoint, new Point(100, 100));
            Assert.IsTrue(_mockGraphics._isDrawCircleCalled);
            Assert.IsFalse(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawOuterFrameCalled);
            _circle.SetIsSelect(true);
            _circle.Draw(_mockGraphics, 1, 1);
            Assert.IsTrue(_mockGraphics._isDrawCircleCalled);
            Assert.IsTrue(_mockGraphics._isDrawOuterFrameCalled);
        }

        //鼠標是否在圖內
        [TestMethod()]
        public void IsInGraphRangeTest()
        {
            _circle.StartPoint = new Point(0, 0);
            _circle.EndPoint = new Point(50, 400);

            Assert.IsTrue(_circle.IsInGraphRange(0, 0));
            Assert.IsTrue(_circle.GetIsSelect());
            Assert.IsTrue(_circle.IsInGraphRange(0, 400));
            Assert.IsTrue(_circle.GetIsSelect());
            Assert.IsTrue(_circle.IsInGraphRange(50, 0));
            Assert.IsTrue(_circle.GetIsSelect());
            Assert.IsFalse(_circle.IsInGraphRange(-1, -1));
            Assert.IsFalse(_circle.GetIsSelect());
            Assert.IsFalse(_circle.IsInGraphRange(25, 401));
            Assert.IsFalse(_circle.GetIsSelect());
        }

        //是否在圖的右下角
        [TestMethod()]
        public void IsInRightDownRangeTest()
        {
            _circle.StartPoint = new Point(0, 0);
            _circle.EndPoint = new Point(50, 400);
            Assert.IsFalse(_circle.IsInRightDownRange(0, 0));
            Assert.IsFalse(_circle.IsInRightDownRange(50, 415));
            Assert.IsFalse(_circle.IsInRightDownRange(35, 400));
            Assert.IsTrue(_circle.IsInRightDownRange(50, 400));
            Assert.IsTrue(_circle.IsInRightDownRange(48, 398));
            Assert.IsTrue(_circle.IsInRightDownRange(52, 402));
            _circle.StartPoint = new Point(50, 400);
            _circle.EndPoint = new Point(0, 0);
            Assert.IsFalse(_circle.IsInRightDownRange(0, 0));
            Assert.IsFalse(_circle.IsInRightDownRange(50, 415));
            Assert.IsFalse(_circle.IsInRightDownRange(35, 400));
            Assert.IsTrue(_circle.IsInRightDownRange(50, 400));
            Assert.IsTrue(_circle.IsInRightDownRange(48, 398));
            Assert.IsTrue(_circle.IsInRightDownRange(52, 402));
        }

        //設定選取
        [TestMethod()]
        public void SetIsSelectTest()
        {
            _circle.SetIsSelect(true);
            Assert.IsTrue(_circle.GetIsSelect());
            _circle.SetIsSelect(false);
            Assert.IsFalse(_circle.GetIsSelect());
        }
    }
}