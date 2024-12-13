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
    public class LineTests
    {
        private Line _line;
        private MockGraphics _mockGraphics;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _line = new Line();
            _mockGraphics = new MockGraphics();
        }

        //設定圖位置
        [TestMethod()]
        public void SetPositionTest()
        {
            _line.SetPosition(new Point(0, 0), new Point(10, 10));
            Assert.AreEqual(new Point(0, 0), _line.StartPoint);
            Assert.AreEqual(new Point(10, 10), _line.EndPoint);
            Assert.AreEqual(string.Format("({0}, {1}), ({2}, {3})", 0, 0, 10, 10), _line.ShapeInformation);

            _line.SetPosition(new Point(7, 50), new Point(-3, 27));
            Assert.AreEqual(new Point(7, 50), _line.GetStartPoint());
            Assert.AreEqual(new Point(-3, 27), _line.GetEndPoint());
            Assert.AreEqual(string.Format("({0}, {1}), ({2}, {3})", 7, 50, -3, 27), _line.ShapeInformation);
        }

        //畫線
        [TestMethod()]
        public void DrawTest()
        {
            _line.StartPoint = new Point(0, 0);
            _line.EndPoint = new Point(100, 100);
            _line.SetIsSelect(false);
            _line.Draw(_mockGraphics, 1, 1);
            Assert.AreEqual(_mockGraphics._startPoint, new Point(0, 0));
            Assert.AreEqual(_mockGraphics._endPoint, new Point(100, 100));
            Assert.IsTrue(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawCircleCalled);
            Assert.IsFalse(_mockGraphics._isDrawOuterFrameCalled);
            _line.SetIsSelect(true);
            _line.Draw(_mockGraphics, 1, 1);
            Assert.IsTrue(_mockGraphics._isDrawLineCalled);
            Assert.IsTrue(_mockGraphics._isDrawOuterFrameCalled);
        }

        //鼠標是否在範圍內
        [TestMethod()]
        public void IsInGraphRangeTest()
        {
            _line.StartPoint = new Point(0, 0);
            _line.EndPoint = new Point(50, 400);

            Assert.IsTrue(_line.IsInGraphRange(0, 0));
            Assert.IsTrue(_line.GetIsSelect());
            Assert.IsTrue(_line.IsInGraphRange(0, 400));
            Assert.IsTrue(_line.GetIsSelect());
            Assert.IsTrue(_line.IsInGraphRange(50, 0));
            Assert.IsTrue(_line.GetIsSelect());
            Assert.IsFalse(_line.IsInGraphRange(-1, -1));
            Assert.IsFalse(_line.GetIsSelect());
            Assert.IsFalse(_line.IsInGraphRange(25, 401));
            Assert.IsFalse(_line.GetIsSelect());
        }

        //是否在圖的右下角
        [TestMethod()]
        public void IsInRightDownRangeTest()
        {
            _line.StartPoint = new Point(0, 0);
            _line.EndPoint = new Point(50, 400);
            Assert.IsFalse(_line.IsInRightDownRange(0, 0));
            Assert.IsFalse(_line.IsInRightDownRange(50, 415));
            Assert.IsFalse(_line.IsInRightDownRange(35, 400));
            Assert.IsTrue(_line.IsInRightDownRange(50, 400));
            Assert.IsTrue(_line.IsInRightDownRange(48, 398));
            Assert.IsTrue(_line.IsInRightDownRange(52, 402));
            _line.StartPoint = new Point(50, 400);
            _line.EndPoint = new Point(0, 0);
            Assert.IsFalse(_line.IsInRightDownRange(0, 0));
            Assert.IsFalse(_line.IsInRightDownRange(50, 415));
            Assert.IsFalse(_line.IsInRightDownRange(35, 400));
            Assert.IsTrue(_line.IsInRightDownRange(50, 400));
            Assert.IsTrue(_line.IsInRightDownRange(48, 398));
            Assert.IsTrue(_line.IsInRightDownRange(52, 402));
        }

        //設定選取
        [TestMethod()]
        public void SetIsSelectTest()
        {
            _line.SetIsSelect(true);
            Assert.IsTrue(_line.GetIsSelect());
            _line.SetIsSelect(false);
            Assert.IsFalse(_line.GetIsSelect());
        }
    }
}