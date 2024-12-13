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
    public class ShapesTests
    {
        private Shapes _shapes;
        private Shape _result;

        //測試初始化
        [TestInitialize()]
        public void Initialize()
        {
            _shapes = new Shapes();
        }

        //儲存物件
        [TestMethod()]
        public void AddShapeTest()
        {
            _shapes.AddShape(new Line());
            Assert.AreEqual(1, _shapes.ShapesList.Count);
            Assert.IsInstanceOfType(_shapes.ShapesList[0], typeof(Line));
            _shapes.AddShape(new Line());
            Assert.AreEqual(2, _shapes.ShapesList.Count);
            Assert.IsInstanceOfType(_shapes.ShapesList[1], typeof(Line));
            _shapes.AddShape(new Rectangle());
            Assert.AreEqual(3, _shapes.ShapesList.Count);
            Assert.IsInstanceOfType(_shapes.ShapesList[2], typeof(Rectangle));
            _shapes.AddShape(new Circle());
            Assert.AreEqual(4, _shapes.ShapesList.Count);
            Assert.IsInstanceOfType(_shapes.ShapesList[0], typeof(Line));
            Assert.IsInstanceOfType(_shapes.ShapesList[1], typeof(Line));
            Assert.IsInstanceOfType(_shapes.ShapesList[2], typeof(Rectangle));
            Assert.IsInstanceOfType(_shapes.ShapesList[3], typeof(Circle));
        }

        //刪除物件
        [TestMethod()]
        public void DeleteShapeTest()
        {
            _shapes.AddShape(new Line());
            _shapes.AddShape(new Line());
            _shapes.AddShape(new Rectangle());
            _shapes.AddShape(new Circle());
            _shapes.DeleteShape(2);
            Assert.IsFalse(_shapes.ShapesList.Contains(new Rectangle()));
            Assert.IsInstanceOfType(_shapes.ShapesList[2], typeof(Circle));
            _shapes.DeleteShape(0);
            Assert.IsInstanceOfType(_shapes.ShapesList[0], typeof(Line));
            Assert.IsInstanceOfType(_shapes.ShapesList[1], typeof(Circle));
            _shapes.DeleteShape(1);
            Assert.IsFalse(_shapes.ShapesList.Contains(new Circle()));
            _shapes.DeleteShape(0);
            Assert.IsFalse(_shapes.ShapesList.Contains(new Line()));
        }

        //更新物件
        [TestMethod()]
        public void UpdateShapeTest()
        {
            _shapes.AddShape(_shapes.CreateShape("線"));
            _shapes.UpdateShape(0, new Rectangle());
            Assert.IsInstanceOfType(_shapes.ShapesList[0], typeof(Rectangle));
            _result = new Rectangle();
            _result.SetPosition(new Point(0, 0), new Point(100, 100));
            _shapes.UpdateShape(0, _result);
            Assert.AreEqual(_shapes.ShapesList[0].GetStartPoint(), new Point(0, 0));
            Assert.AreEqual(_shapes.ShapesList[0].GetEndPoint(), new Point(100, 100));
        }

        //建立物件
        [TestMethod()]
        public void CreateShapeTest()
        {
            _shapes.AddShape(_shapes.CreateShape("線"));
            Assert.AreEqual(1, _shapes.GetShapesList().Count);
            _shapes.AddShape(_shapes.CreateShape("矩形"));
            Assert.AreEqual(2, _shapes.GetShapesList().Count);
            _shapes.AddShape(_shapes.CreateShape("線"));
            Assert.AreEqual(3, _shapes.GetShapesList().Count);
            _shapes.DeleteShape(1);
            Assert.AreEqual(2, _shapes.GetShapesList().Count);
            Assert.IsInstanceOfType(_shapes.ShapesList[0], typeof(Line));
            Assert.IsInstanceOfType(_shapes.ShapesList[1], typeof(Line));
        }

        //建立物件
        [TestMethod()]
        public void InsertShapeTest()
        {
            _shapes.AddShape(_shapes.CreateShape("線"));
            _result = new Rectangle();
            _result.SetLayers(0);
            _shapes.InsertShape(_result);
            Assert.AreEqual(2, _shapes.GetShapesList().Count);
            Assert.IsInstanceOfType(_shapes.ShapesList[0], typeof(Rectangle));
            Assert.IsInstanceOfType(_shapes.ShapesList[1], typeof(Line));
        }
    }
}