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
    public class RandomCreateCommandTests
    {
        private RandomCreateCommand _randomCreateCommand;
        private Model _model;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            Shape target = new Line();
            target.SetPosition(new Point(10, 10), new Point(20, 20));
            _randomCreateCommand = new RandomCreateCommand(_model, target);
        }

        //執行
        [TestMethod()]
        public void ExecuteTest()
        {
            _randomCreateCommand.Execute();
            Assert.AreEqual(_model.ShapeList.Count, 1);
            Assert.IsInstanceOfType(_model.ShapeList[0], typeof(Line));
        }

        //不執行
        [TestMethod()]
        public void ReverseExecutionTest()
        {
            _randomCreateCommand.Execute();
            _randomCreateCommand.ReverseExecution();
            Assert.AreEqual(_model.ShapeList.Count, 0);
        }
    }
}