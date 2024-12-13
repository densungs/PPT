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
    public class FactoryTests
    {
        //繪畫建立物件
        [TestMethod()]
        public void PaintShapeTest()
        {
            Assert.IsInstanceOfType(Factory.PaintShape("線"), typeof(Line));
            Assert.IsInstanceOfType(Factory.PaintShape("矩形"), typeof(Rectangle));
            Assert.IsInstanceOfType(Factory.PaintShape("圓"), typeof(Circle));
        }

        //建立物件
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateShapeTest()
        {
            Assert.IsNotNull(Factory.CreateShape("矩形"));
            Assert.AreEqual("矩形", Factory.CreateShape("矩形").ShapeType);
            Assert.IsNotNull(Factory.CreateShape("圓"));
            Assert.AreEqual("圓", Factory.CreateShape("圓").ShapeType);
            Assert.IsNotNull(Factory.CreateShape("線"));
            Assert.AreEqual("線", Factory.CreateShape("線").ShapeType);
            Factory.CreateShape("其他");
        }
    }
}