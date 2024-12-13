﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class MoveCommandTests
    {
        private MoveCommand _moveCommand;
        private Model _model;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            Shape origin = new Line();
            origin.SetPosition(new Point(10, 10), new Point(20, 20));
            origin.SetLayers(0);
            Shape result = new Line();
            result.SetPosition(new Point(100, 100), new Point(200, 200));
            result.SetLayers(0);
            _moveCommand = new MoveCommand(_model, origin, result);
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
            _moveCommand.Execute();
            Assert.AreEqual(_model.ShapeList.Count, 2);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(100, 100));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(200, 200));
            Assert.IsInstanceOfType(_model.ShapeList[1], typeof(Rectangle));
            Assert.AreEqual(_model.ShapeList[1].GetStartPoint(), new Point(100, 100));
            Assert.AreEqual(_model.ShapeList[1].GetEndPoint(), new Point(200, 200));
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
            _moveCommand.Execute();
            Assert.AreEqual(_model.ShapeList.Count, 2);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
            Assert.AreEqual(_model.ShapeList[0].GetStartPoint(), new Point(100, 100));
            Assert.AreEqual(_model.ShapeList[0].GetEndPoint(), new Point(200, 200));
            Assert.IsInstanceOfType(_model.ShapeList[1], typeof(Rectangle));
            Assert.AreEqual(_model.ShapeList[1].GetStartPoint(), new Point(100, 100));
            Assert.AreEqual(_model.ShapeList[1].GetEndPoint(), new Point(200, 200));
            _moveCommand.ReverseExecution();
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