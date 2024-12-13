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
    public class DrawCommandTests
    {
        private DrawCommand _drawCommand;
        private Model _model;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            Shape target = new Line();
            target.SetPosition(new Point(10, 10), new Point(20, 20));
            _drawCommand = new DrawCommand(_model, target);
        }

        //執行
        [TestMethod()]
        public void ExecuteTest()
        {
            _drawCommand.Execute();
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
        }

        //不執行
        [TestMethod()]
        public void ReverseExecutionTest()
        {
            _drawCommand.Execute();
            _drawCommand.ReverseExecution();
            Assert.AreEqual(_model.ShapeList.Count, 0);
        }
    }
}