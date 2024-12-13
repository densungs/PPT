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
    public class ModelTests
    {
        private Model _model;
        private PrivateObject _modelPrivateObject;
        private MockGraphics _mockGraphics;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _modelPrivateObject = new PrivateObject(_model);
            _mockGraphics = new MockGraphics();
        }

        //畫哪個圖形
        [TestMethod()]
        public void SetPaintWhichShapeTest()
        {
            _model.SetPaintWhichShape("圓");
            Assert.AreEqual(_modelPrivateObject.GetField("_shapeToolBarButton"), "圓");
            _model.SetPaintWhichShape("線");
            Assert.AreEqual(_modelPrivateObject.GetField("_shapeToolBarButton"), "線");
            _model.SetPaintWhichShape("矩形");
            Assert.AreEqual(_modelPrivateObject.GetField("_shapeToolBarButton"), "矩形");
        }

        //設定state
        [TestMethod()]
        public void SetPointerStateTest()
        {
            _model.SetPointerState("選取");
            Assert.IsInstanceOfType(_modelPrivateObject.GetField("_state"), typeof(PointState));
            _model.SetPointerState("線");
            Assert.IsInstanceOfType(_modelPrivateObject.GetField("_state"), typeof(DrawingState));
            _model.SetPointerState("矩形");
            Assert.IsInstanceOfType(_modelPrivateObject.GetField("_state"), typeof(DrawingState));
            _model.SetPointerState("圓");
            Assert.IsInstanceOfType(_modelPrivateObject.GetField("_state"), typeof(DrawingState));
        }

        //畫圖
        [TestMethod()]
        public void DrawTest()
        {
            _model.Draw(_mockGraphics, 1, 1);
            Assert.IsTrue(_mockGraphics._isClearAllCalled);
            Assert.IsFalse(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawCircleCalled);
            Assert.IsFalse(_mockGraphics._isDrawOuterFrameCalled);
            _model.SetPaintWhichShape("線");
            _model.SetPointerState("線");
            _model.PressedMouse(20, 20);
            _model.Draw(_mockGraphics, 1, 1);
            Assert.IsTrue(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawCircleCalled);
            Assert.IsFalse(_mockGraphics._isDrawOuterFrameCalled);
            _model.MoveMouse(50, 495);
            _model.Draw(_mockGraphics, 1, 1);
            Assert.IsTrue(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawCircleCalled);
            Assert.IsFalse(_mockGraphics._isDrawOuterFrameCalled);
            _model.ReleasedMouse(100, 300);
            _model.Draw(_mockGraphics, 1, 1);
            Assert.IsTrue(_mockGraphics._isDrawLineCalled);
            Assert.IsFalse(_mockGraphics._isDrawRectangleCalled);
            Assert.IsFalse(_mockGraphics._isDrawCircleCalled);
            Assert.IsTrue(_mockGraphics._isDrawOuterFrameCalled);
        }

        //新增圖形
        [TestMethod()]
        public void CreateShapeTest()
        {
            _model.CreateShape("圓");
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Circle));
            _model.CreateShape("線");
            Assert.AreEqual(_model.ShapeList.Count, 2);
            Assert.IsInstanceOfType(_model.ShapeList[1], typeof(Line));
            _model.CreateShape("矩形");
            Assert.AreEqual(_model.ShapeList.Count, 3);
            Assert.IsInstanceOfType(_model.ShapeList[2], typeof(Rectangle));
        }

        //刪除圖形
        [TestMethod()]
        public void DeleteShapeTest()
        {
            _model.CreateShape("圓");
            _model.CreateShape("線");
            _model.CreateShape("矩形");
            _model.DeleteShape(1, 1);
            Assert.AreEqual(_model.ShapeList.Count, 3);
            _model.DeleteShape(1, 0);
            Assert.AreEqual(_model.ShapeList.Count, 2);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Circle));
            Assert.IsInstanceOfType(_model.ShapeList[1], typeof(Rectangle));
            _model.DeleteShape(0, 0);
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Rectangle));
        }

        //不選圖
        [TestMethod()]
        public void SelectNoGraphTest()
        {
            _model.SetPaintWhichShape("線");
            _model.SetPointerState("線");
            _model.PressedMouse(20, 20);
            _model.ReleasedMouse(100, 300);
            _model.SetPaintWhichShape("矩形");
            _model.SetPointerState("矩形");
            _model.PressedMouse(75, 50);
            _model.ReleasedMouse(157, 238);
            _model.SetPointerState("選取");
            _model.PressedMouse(30, 150);
            Assert.IsTrue(_model.ShapeList[0].GetIsSelect());
            Assert.IsFalse(_model.ShapeList[1].GetIsSelect());
            _model.SelectNoGraph();
            Assert.IsFalse(_model.ShapeList[0].GetIsSelect());
            Assert.IsFalse(_model.ShapeList[1].GetIsSelect());
        }

        //選了哪張圖
        [TestMethod()]
        public void SelectWhichGraphTest()
        {
            _model.SetPaintWhichShape("線");
            _model.SetPointerState("線");
            _model.PressedMouse(20, 20);
            _model.ReleasedMouse(100, 300);
            _model.SetPaintWhichShape("矩形");
            _model.SetPointerState("矩形");
            _model.PressedMouse(75, 50);
            _model.ReleasedMouse(157, 238);
            _model.SetPointerState("選取");
            _model.PressedMouse(30, 150);
            _model.ReleasedMouse(30, 150);
            Assert.AreEqual(_model.SelectWhichGraph(), 0);
            _model.PressedMouse(0, 0);
            Assert.AreEqual(_model.SelectWhichGraph(), -1);
            _model.PressedMouse(110, 100);
            _model.ReleasedMouse(110, 100);
            Assert.AreEqual(_model.SelectWhichGraph(), 1);
        }

        //按下滑鼠
        [TestMethod()]
        public void PressedMouseTest()
        {
            _model.SetPaintWhichShape("線");
            _model.SetPointerState("線");
            _model.PressedMouse(20, 20);
            Assert.IsTrue((bool)_modelPrivateObject.GetField("_isPressed"));
            _model.ReleasedMouse(100, 300);
            _model.SetPointerState("選取");
            _model.PressedMouse(0, 0);
            Assert.IsFalse((bool)_modelPrivateObject.GetField("_isPressed"));
            _model.SetPointerState("選取");
            _model.PressedMouse(30, 150);
            Assert.IsTrue((bool)_modelPrivateObject.GetField("_isPressed"));
        }

        //移動滑鼠
        [TestMethod()]
        public void MoveMouseTest()
        {
            _model.MoveMouse(20, 49);
            Assert.IsFalse((bool)_modelPrivateObject.GetField("_isPressed"));
            _model.SetPaintWhichShape("線");
            _model.SetPointerState("線");
            _model.PressedMouse(20, 20);
            _model.MoveMouse(40, 434);
            Assert.IsTrue((bool)_modelPrivateObject.GetField("_isPressed"));
        }

        //放開滑鼠
        [TestMethod()]
        public void ReleasedMouseTest()
        {
            _model.SetPaintWhichShape("線");
            _model.SetPointerState("線");
            _model.PressedMouse(20, 20);
            _model.ReleasedMouse(100, 300);
            Assert.IsFalse((bool)_modelPrivateObject.GetField("_isPressed"));
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(20, 20));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(100, 300));
            _model.SetPointerState("選取");
            _model.PressedMouse(30, 30);
            _model.ReleasedMouse(50, 50);
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(40, 40));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(120, 320));
        }

        //上一步
        [TestMethod()]
        public void UndoTest()
        {
            _model.CreateShape("圓");
            _model.CreateShape("線");
            _model.DeleteShape(0, 0);
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
            _model.Undo();
            Assert.AreEqual(_model.ShapeList.Count, 2);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Circle));
            Assert.IsInstanceOfType(_model.ShapeList[1], typeof(Line));
            _model.Undo();
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Circle));
        }

        //還原上一步
        [TestMethod()]
        public void RedoTest()
        {
            _model.SetPaintWhichShape("線");
            _model.SetPointerState("線");
            _model.PressedMouse(20, 20);
            _model.ReleasedMouse(100, 300);
            Assert.IsFalse((bool)_modelPrivateObject.GetField("_isPressed"));
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(20, 20));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(100, 300));
            _model.SetPointerState("選取");
            _model.PressedMouse(30, 30);
            _model.ReleasedMouse(50, 50);
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(40, 40));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(120, 320));
            _model.Undo();
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(20, 20));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(100, 300));
            _model.Undo();
            Assert.AreEqual(_model.ShapeList.Count, 0);
            _model.Redo();
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(20, 20));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(100, 300));
            _model.Redo();
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(40, 40));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(120, 320));
        }

        //隨機建立用的執行
        [TestMethod()]
        public void CreateShapeByRandomCreateTest()
        {
            Shape one = new Line();
            Shape two = new Rectangle();
            Shape three = new Circle();
            _model.CreateShapeByRandomCreate(one);
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
            _model.CreateShapeByRandomCreate(two);
            Assert.AreEqual(_model.ShapeList.Count, 2);
            Assert.IsInstanceOfType(_model.ShapeList[1], typeof(Rectangle));
            _model.CreateShapeByRandomCreate(three);
            Assert.AreEqual(_model.ShapeList.Count, 3);
            Assert.IsInstanceOfType(_model.ShapeList[2], typeof(Circle));
        }

        //隨機建立用的反向執行
        [TestMethod()]
        public void DeleteShapeByRandomCreateTest()
        {
            Shape one = new Line();
            _model.CreateShapeByRandomCreate(one);
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
            _model.DeleteShapeByRandomCreate();
            Assert.AreEqual(_model.ShapeList.Count, 0);
        }

        //畫畫的執行
        [TestMethod()]
        public void CreateShapeByDrawingCreateTest()
        {
            Shape one = new Line();
            Shape two = new Rectangle();
            Shape three = new Circle();
            _model.CreateShapeByDrawing(one);
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
            _model.CreateShapeByDrawing(two);
            Assert.AreEqual(_model.ShapeList.Count, 2);
            Assert.IsInstanceOfType(_model.ShapeList[1], typeof(Rectangle));
            _model.CreateShapeByDrawing(three);
            Assert.AreEqual(_model.ShapeList.Count, 3);
            Assert.IsInstanceOfType(_model.ShapeList[2], typeof(Circle));
        }

        //畫畫的反向執行
        [TestMethod()]
        public void DeleteShapeByDrawingTest()
        {
            Shape one = new Line();
            _model.CreateShapeByDrawing(one);
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
            _model.DeleteShapeByDrawing();
            Assert.AreEqual(_model.ShapeList.Count, 0);
        }

        //刪除的執行
        [TestMethod()]
        public void ExecuteDeleteTest()
        {
            Shape one = new Line();
            Shape two = new Rectangle();
            two.SetLayers(1);
            Shape three = new Circle();
            _model.CreateShapeByDrawing(one);
            _model.CreateShapeByDrawing(two);
            _model.CreateShapeByDrawing(three);
            _model.ExecuteDelete(two.GetLayers());
            Assert.AreEqual(_model.ShapeList.Count, 2);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
            Assert.IsInstanceOfType(_model.ShapeList[1], typeof(Circle));
        }

        //刪除的反向執行
        [TestMethod()]
        public void ReverseExecutionDeleteTest()
        {
            Shape one = new Line();
            Shape two = new Rectangle();
            two.SetLayers(1);
            Shape three = new Circle();
            _model.CreateShapeByDrawing(one);
            _model.CreateShapeByDrawing(two);
            _model.CreateShapeByDrawing(three);
            _model.ExecuteDelete(two.GetLayers());
            Assert.AreEqual(_model.ShapeList.Count, 2);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
            Assert.IsInstanceOfType(_model.ShapeList[1], typeof(Circle));
            _model.ReverseExecutionDelete(two);
            Assert.AreEqual(_model.ShapeList.Count, 3);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
            Assert.IsInstanceOfType(_model.ShapeList[1], typeof(Rectangle));
            Assert.IsInstanceOfType(_model.ShapeList[2], typeof(Circle));
        }

        //移動的執行
        [TestMethod()]
        public void ExecuteMoveTest()
        {
            Shape origin = new Line();
            origin.SetPosition(new Point(10, 10), new Point(20, 20));
            Shape result = new Line();
            result.SetPosition(new Point(100, 100), new Point(200, 200));
            _model.CreateShapeByDrawing(origin);
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(10, 10));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(20, 20));
            _model.ExecuteMove(result);
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(100, 100));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(200, 200));
        }

        //移動的反向執行
        [TestMethod()]
        public void ReverseExecutionMoveTest()
        {
            Shape origin = new Line();
            origin.SetPosition(new Point(10, 10), new Point(20, 20));
            Shape result = new Line();
            result.SetPosition(new Point(100, 100), new Point(200, 200));
            _model.CreateShapeByDrawing(origin);
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(10, 10));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(20, 20));
            _model.ExecuteMove(result);
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(100, 100));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(200, 200));
            _model.ReverseExecutionMove(origin);
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(10, 10));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(20, 20));
        }
    }
}