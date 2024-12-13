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
    public class DrawingStateTests
    {
        private DrawingState _drawingState;
        private MockGraphics _mockGraphics;
        PrivateObject _drawingStatePrivateObject;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _drawingState = new DrawingState();
            _mockGraphics = new MockGraphics();
            _drawingStatePrivateObject = new PrivateObject(_drawingState);
        }

        //按下滑鼠
        [TestMethod()]
        public void MousePressedTest()
        {
            _drawingState.MousePressed("圓", 50, 30);
            Assert.IsInstanceOfType(_drawingStatePrivateObject.GetField("_hint"), typeof(Circle));
            Assert.AreEqual(_drawingStatePrivateObject.GetField("_firstPointX"), (double)50);
            Assert.AreEqual(_drawingStatePrivateObject.GetField("_firstPointY"), (double)30);
        }

        //移動滑鼠
        [TestMethod()]
        public void MouseMoveTest()
        {
            _drawingState.MousePressed("線", 20, 70);
            _drawingState.MouseMove(100, 200);
            Assert.AreEqual(new Point(20, 70), ((Shape)_drawingStatePrivateObject.GetField("_hint")).GetStartPoint());
            Assert.AreEqual(new Point(100, 200), ((Shape)_drawingStatePrivateObject.GetField("_hint")).GetEndPoint());
            _drawingState.MouseMove(1, 2);
            Assert.AreEqual(new Point(20, 70), ((Shape)_drawingStatePrivateObject.GetField("_hint")).GetStartPoint());
            Assert.AreEqual(new Point(1, 2), ((Shape)_drawingStatePrivateObject.GetField("_hint")).GetEndPoint());
            _drawingState.MouseMove(300, 238);
            Assert.AreEqual(new Point(20, 70), ((Shape)_drawingStatePrivateObject.GetField("_hint")).GetStartPoint());
            Assert.AreEqual(new Point(300, 238), ((Shape)_drawingStatePrivateObject.GetField("_hint")).GetEndPoint());
        }

        //放開滑鼠
        [TestMethod()]
        public void MouseReleasedTest()
        {
            _drawingState.MousePressed("線", 20, 70);
            Assert.IsInstanceOfType(_drawingState.MouseReleased(500, 23), typeof(Line));
            Assert.AreEqual(_drawingState.MouseReleased(500, 23).GetStartPoint(), new Point(20, 70));
            Assert.AreEqual(_drawingState.MouseReleased(500, 23).GetEndPoint(), new Point(500, 23));
        }


        //畫圖
        [TestMethod()]
        public void DrawTest()
        {
            _drawingState.MousePressed("圓", 100, 48);
            _drawingState.MouseMove(92, 398);
            _drawingState.Draw(_mockGraphics, 1, 1);
            Assert.IsTrue(_mockGraphics._isDrawCircleCalled);
            Assert.IsFalse(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawOuterFrameCalled);
            Assert.AreEqual(_mockGraphics._startPoint, new Point(100, 48));
            Assert.AreEqual(_mockGraphics._endPoint, new Point(92, 398));
            _drawingState.MouseMove(348, 273);
            _drawingState.Draw(_mockGraphics, 1, 1);
            Assert.AreEqual(_mockGraphics._startPoint, new Point(100, 48));
            Assert.AreEqual(_mockGraphics._endPoint, new Point(348, 273));
            _drawingState.MouseReleased(500, 300);
            _drawingState.Draw(_mockGraphics, 1, 1);
            Assert.AreEqual(_mockGraphics._startPoint, new Point(100, 48));
            Assert.AreEqual(_mockGraphics._endPoint, new Point(500, 300));
        }
    }
}