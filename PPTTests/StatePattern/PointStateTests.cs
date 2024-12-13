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
    public class PointStateTests
    {
        private PointState _pointState;
        private MockGraphics _mockGraphics;
        Shapes _shapes;
        Shape _shape;
        PrivateObject _pointStatePrivateObject;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _shapes = new Shapes();
            _pointState = new PointState(_shapes);
            _mockGraphics = new MockGraphics();
            _pointStatePrivateObject = new PrivateObject(_pointState);

            _shape = new Line();
            _shape.SetPosition(new Point(20, 20), new Point(100, 300));
            _shapes.AddShape(_shape);
            _shape = new Rectangle();
            _shape.SetPosition(new Point(75, 50), new Point(157, 238));
            _shapes.AddShape(_shape);
        }

        //按下滑鼠
        [TestMethod()]
        public void MousePressedTest()
        {
            Assert.IsInstanceOfType(_pointState.MousePressed("隨便", 30, 30), typeof(Line));
            Assert.AreEqual(_pointStatePrivateObject.GetField("_distanceMouseStart"), new Point(10, 10));
            Assert.AreEqual(_pointStatePrivateObject.GetField("_distanceMouseEnd"), new Point(-70, -270));
            Assert.IsInstanceOfType(_pointState.MousePressed("隨便", 79, 200), typeof(Line));
            Assert.AreEqual(_pointStatePrivateObject.GetField("_distanceMouseStart"), new Point(59, 180));
            Assert.AreEqual(_pointStatePrivateObject.GetField("_distanceMouseEnd"), new Point(-21, -100));
            Assert.IsInstanceOfType(_pointState.MousePressed("隨便", 143, 148), typeof(Rectangle));
            Assert.AreEqual(_pointStatePrivateObject.GetField("_distanceMouseStart"), new Point(68, 98));
            Assert.AreEqual(_pointStatePrivateObject.GetField("_distanceMouseEnd"), new Point(-14, -90));
            Assert.IsNull(_pointState.MousePressed("隨便", 5, 37));
            Assert.IsNull(_pointState.MousePressed("隨便", 138, 285));
        }

        //移動滑鼠
        [TestMethod()]
        public void MouseMoveTest()
        {
            _pointState.MousePressed("隨便", 30, 30);
            _pointState.MouseMove(50, 50);
            Assert.AreEqual(((Shape)_pointStatePrivateObject.GetField("_hint")).GetStartPoint(), new Point(40, 40));
            Assert.AreEqual(((Shape)_pointStatePrivateObject.GetField("_hint")).GetEndPoint(), new Point(120, 320));
            _pointState.MouseMove(100, 100);
            Assert.AreEqual(((Shape)_pointStatePrivateObject.GetField("_hint")).GetStartPoint(), new Point(90, 90));
            Assert.AreEqual(((Shape)_pointStatePrivateObject.GetField("_hint")).GetEndPoint(), new Point(170, 370));
            Assert.IsInstanceOfType(_pointStatePrivateObject.GetField("_hint"), typeof(Line));
        }

        //放開滑鼠
        [TestMethod()]
        public void MouseReleasedTest()
        {
            _pointState.MousePressed("隨便", 30, 30);
            Assert.AreEqual(_pointState.MouseReleased(50, 50).GetStartPoint(), new Point(40, 40));
            Assert.AreEqual(_pointState.MouseReleased(50, 50).GetEndPoint(), new Point(120, 320));
        }

        //畫圖
        [TestMethod()]
        public void DrawTest()
        {
            _pointState.MousePressed("隨便", 30, 30);
            _pointState.Draw(_mockGraphics, 1, 1);
            Assert.IsTrue(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawCircleCalled);
            Assert.IsTrue(_mockGraphics._isDrawOuterFrameCalled);
            Assert.AreEqual(_mockGraphics._startPoint, new Point(20, 20));
            Assert.AreEqual(_mockGraphics._endPoint, new Point(100, 300));
            _pointState.MouseMove(50, 50);
            _pointState.Draw(_mockGraphics, 1, 1);
            Assert.IsTrue(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawCircleCalled);
            Assert.IsTrue(_mockGraphics._isDrawOuterFrameCalled);
            Assert.AreEqual(_mockGraphics._startPoint, new Point(40, 40));
            Assert.AreEqual(_mockGraphics._endPoint, new Point(120, 320));
            _pointState.MouseReleased(100, 100);
            _pointState.Draw(_mockGraphics, 1, 1);
            Assert.IsTrue(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawCircleCalled);
            Assert.IsTrue(_mockGraphics._isDrawOuterFrameCalled);
            Assert.AreEqual(_mockGraphics._startPoint, new Point(90, 90));
            Assert.AreEqual(_mockGraphics._endPoint, new Point(170, 370));
        }
    }
}