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
    public class DeleteCommandTests
    {
        private DeleteCommand _deleteCommand;
        private Model _model;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            Shape target = new Line();
            target.SetPosition(new Point(10, 10), new Point(20, 20));
            target.SetLayers(0);
            _deleteCommand = new DeleteCommand(_model, target);
        }

        //執行
        [TestMethod()]
        public void ExecuteTest()
        {
            Shape a = new Line();
            a.SetPosition(new Point(10, 10), new Point(20, 20));
            Shape b = new Rectangle();
            b.SetPosition(new Point(100, 100), new Point(200, 200));
            _model.CreateShapeByDrawing(a);
            _model.CreateShapeByDrawing(b);
            Assert.AreEqual(_model.ShapeList.Count, 2);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(10, 10));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(20, 20));
            Assert.IsInstanceOfType(_model.ShapeList[1], typeof(Rectangle));
            Assert.AreEqual(_model.ShapeList[1].GetStartPoint(), new Point(100, 100));
            Assert.AreEqual(_model.ShapeList[1].GetEndPoint(), new Point(200, 200));
            _deleteCommand.Execute();
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Rectangle));
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(100, 100));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(200, 200));
        }

        //不執行
        [TestMethod()]
        public void ReverseExecutionTest()
        {
            Shape a = new Line();
            a.SetPosition(new Point(10, 10), new Point(20, 20));
            Shape b = new Rectangle();
            b.SetPosition(new Point(100, 100), new Point(200, 200));
            _model.CreateShapeByDrawing(a);
            _model.CreateShapeByDrawing(b);
            Assert.AreEqual(_model.ShapeList.Count, 2);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(10, 10));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(20, 20));
            Assert.IsInstanceOfType(_model.ShapeList[1], typeof(Rectangle));
            Assert.AreEqual(_model.ShapeList[1].GetStartPoint(), new Point(100, 100));
            Assert.AreEqual(_model.ShapeList[1].GetEndPoint(), new Point(200, 200));
            _deleteCommand.Execute();
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Rectangle));
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(100, 100));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(200, 200));
            _deleteCommand.ReverseExecution();
            Assert.AreEqual(_model.ShapeList.Count, 2);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(10, 10));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(20, 20));
            Assert.IsInstanceOfType(_model.ShapeList[1], typeof(Rectangle));
            Assert.AreEqual(_model.ShapeList[1].GetStartPoint(), new Point(100, 100));
            Assert.AreEqual(_model.ShapeList[1].GetEndPoint(), new Point(200, 200));
        }
    }
}