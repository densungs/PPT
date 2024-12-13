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
    public class ZoomStateTests
    {
        private ZoomState _zoomState;
        private MockGraphics _mockGraphics;
        Shapes _shapes;
        Shape _shape;
        PrivateObject _zoomStatePrivateObject;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _shapes = new Shapes();
            _zoomState = new ZoomState(_shapes);
            _mockGraphics = new MockGraphics();
            _zoomStatePrivateObject = new PrivateObject(_zoomState);

            _shape = new Line();
            _shape.SetPosition(new Point(20, 20), new Point(100, 300));
            _shapes.AddShape(_shape);
            _shape = new Rectangle();
            _shape.SetPosition(new Point(157, 238), new Point(75, 50));
            _shapes.AddShape(_shape);
            _shape = new Circle();
            _shape.SetPosition(new Point(30, 555), new Point(66, 333));
            _shapes.AddShape(_shape);
            _shape = new Line();
            _shape.SetPosition(new Point(837, 38), new Point(374, 360));
            _shapes.AddShape(_shape);
        }

        //按下滑鼠
        [TestMethod()]
        public void MousePressedTest()
        {
            Assert.IsNull(_zoomState.MousePressed("隨便", 100, 300));
            _shapes.ShapesList[0].SetIsSelect(true);
            Assert.IsInstanceOfType(_zoomState.MousePressed("隨便", 100, 300), typeof(Line));
            Assert.AreEqual(_zoomStatePrivateObject.GetField("_distanceX"), (double)0);
            Assert.AreEqual(_zoomStatePrivateObject.GetField("_distanceY"), (double)0);
            Assert.AreEqual(_zoomStatePrivateObject.GetField("_changeXName"), 2);
            Assert.AreEqual(_zoomStatePrivateObject.GetField("_changeYName"), 2);
            _shapes.ShapesList[0].SetIsSelect(false);
            _shapes.ShapesList[1].SetIsSelect(true);
            Assert.IsInstanceOfType(_zoomState.MousePressed("隨便", 157, 238), typeof(Rectangle));
            Assert.AreEqual(_zoomStatePrivateObject.GetField("_distanceX"), (double)0);
            Assert.AreEqual(_zoomStatePrivateObject.GetField("_distanceY"), (double)0);
            Assert.AreEqual(_zoomStatePrivateObject.GetField("_changeXName"), 1);
            Assert.AreEqual(_zoomStatePrivateObject.GetField("_changeYName"), 1);
        }

        //移動滑鼠
        [TestMethod()]
        public void MouseMoveTest()
        {
            _shapes.ShapesList[0].SetIsSelect(true);
            _zoomState.MousePressed("隨便", 100, 300);
            _zoomState.MouseMove(150, 350);
            Assert.AreEqual(((Shape)_zoomStatePrivateObject.GetField("_hint")).GetStartPoint(), new Point(20, 20));
            Assert.AreEqual(((Shape)_zoomStatePrivateObject.GetField("_hint")).GetEndPoint(), new Point(150, 350));
            _shapes.ShapesList[0].SetIsSelect(false);
            _shapes.ShapesList[1].SetIsSelect(true);
            _zoomState.MousePressed("隨便", 157, 238);
            _zoomState.MouseMove(160, 300);
            Assert.AreEqual(((Shape)_zoomStatePrivateObject.GetField("_hint")).GetStartPoint(), new Point(160, 300));
            Assert.AreEqual(((Shape)_zoomStatePrivateObject.GetField("_hint")).GetEndPoint(), new Point(75, 50));
            _shapes.ShapesList[1].SetIsSelect(false);
            _shapes.ShapesList[2].SetIsSelect(true);
            _zoomState.MousePressed("隨便", 66, 555);
            _zoomState.MouseMove(80, 400);
            Assert.AreEqual(((Shape)_zoomStatePrivateObject.GetField("_hint")).GetStartPoint(), new Point(30, 400));
            Assert.AreEqual(((Shape)_zoomStatePrivateObject.GetField("_hint")).GetEndPoint(), new Point(80, 333));
            _shapes.ShapesList[2].SetIsSelect(false);
            _shapes.ShapesList[3].SetIsSelect(true);
            _zoomState.MousePressed("隨便", 837, 360);
            _zoomState.MouseMove(800, 100);
            Assert.AreEqual(((Shape)_zoomStatePrivateObject.GetField("_hint")).GetStartPoint(), new Point(800, 38));
            Assert.AreEqual(((Shape)_zoomStatePrivateObject.GetField("_hint")).GetEndPoint(), new Point(374, 100));
        }

        //放開滑鼠
        [TestMethod()]
        public void MouseReleasedTest()
        {
            _shapes.ShapesList[0].SetIsSelect(true);
            _zoomState.MousePressed("隨便", 100, 300);
            Assert.AreEqual(_zoomState.MouseReleased(150, 350).GetStartPoint(), new Point(20, 20));
            Assert.AreEqual(_zoomState.MouseReleased(150, 350).GetEndPoint(), new Point(150, 350));
            _shapes.ShapesList[0].SetIsSelect(false);
            _shapes.ShapesList[1].SetIsSelect(true);
            _zoomState.MousePressed("隨便", 157, 238);
            Assert.AreEqual(_zoomState.MouseReleased(160, 300).GetStartPoint(), new Point(160, 300));
            Assert.AreEqual(_zoomState.MouseReleased(160, 300).GetEndPoint(), new Point(75, 50));
            _shapes.ShapesList[1].SetIsSelect(false);
            _shapes.ShapesList[2].SetIsSelect(true);
            _zoomState.MousePressed("隨便", 66, 555);
            Assert.AreEqual(_zoomState.MouseReleased(80, 400).GetStartPoint(), new Point(30, 400));
            Assert.AreEqual(_zoomState.MouseReleased(80, 400).GetEndPoint(), new Point(80, 333));
            _shapes.ShapesList[2].SetIsSelect(false);
            _shapes.ShapesList[3].SetIsSelect(true);
            _zoomState.MousePressed("隨便", 837, 360);
            Assert.AreEqual(_zoomState.MouseReleased(800, 100).GetStartPoint(), new Point(800, 38));
            Assert.AreEqual(_zoomState.MouseReleased(800, 100).GetEndPoint(), new Point(374, 100));
        }

        //畫圖
        [TestMethod()]
        public void DrawTest()
        {
            _shapes.ShapesList[0].SetIsSelect(true);
            _zoomState.MousePressed("隨便", 100, 300);
            _zoomState.Draw(_mockGraphics, 1, 01);
            Assert.IsTrue(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawCircleCalled);
            Assert.IsTrue(_mockGraphics._isDrawOuterFrameCalled);
            Assert.AreEqual(_mockGraphics._startPoint, new Point(20, 20));
            Assert.AreEqual(_mockGraphics._endPoint, new Point(100, 300));
            _zoomState.MouseMove(120, 320);
            _zoomState.Draw(_mockGraphics, 1, 1);
            Assert.IsTrue(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawCircleCalled);
            Assert.IsTrue(_mockGraphics._isDrawOuterFrameCalled);
            Assert.AreEqual(_mockGraphics._startPoint, new Point(20, 20));
            Assert.AreEqual(_mockGraphics._endPoint, new Point(120, 320));
            _zoomState.MouseReleased(150, 350);
            _zoomState.Draw(_mockGraphics, 1, 1);
            Assert.IsTrue(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawCircleCalled);
            Assert.IsTrue(_mockGraphics._isDrawOuterFrameCalled);
            Assert.AreEqual(_mockGraphics._startPoint, new Point(20, 20));
            Assert.AreEqual(_mockGraphics._endPoint, new Point(150, 350));
        }
    }
}