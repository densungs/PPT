using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        private PresentationModel.PresentationModel _presentationModel;
        private MockGraphics _mockGraphics;
        private MockModel _mockModel;
        PrivateObject _presentationModelPrivateObject;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _mockModel = new MockModel();
            _presentationModel = new PresentationModel.PresentationModel(_mockModel);
            _mockGraphics = new MockGraphics();
            _presentationModelPrivateObject = new PrivateObject(_presentationModel);
        }

        //在畫布上按下滑鼠
        [TestMethod()]
        public void HandleCanvasPressedTest()
        {
            _presentationModel.HandleCanvasPressed(30, 40, 16, 9);
            Assert.IsTrue(_mockModel.PressedMouse(30, 40));
        }

        //放開滑鼠
        [TestMethod()]
        public void HandleCanvasReleasedTest()
        {
            _presentationModel.HandleCanvasReleased(30, 40, 16, 9);
            Assert.IsTrue(_mockModel.ReleasedMouse(30, 40));
            Assert.IsTrue((bool)_presentationModelPrivateObject.GetField("_isChoosePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isLinePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isRectanglePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isCirclePressed"));
        }

        //移動滑鼠
        [TestMethod()]
        public void HandleCanvasMovedTest()
        {
            _presentationModel.HandleCanvasMoved(30, 40, 16, 9);
            Assert.IsTrue(_mockModel.MoveMouse(30, 40));
        }

        //ToolBar被按下
        [TestMethod()]
        public void ClickToolButtonTest()
        {
            _presentationModel.ClickToolButton("線");
            Assert.IsTrue(_mockModel.SelectNoGraph());
            Assert.IsTrue(_mockModel.SetPaintWhichShape("線"));
            Assert.IsTrue(_mockModel.SetPointerState("線"));
            Assert.IsTrue((bool)_presentationModelPrivateObject.GetField("_isLinePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isChoosePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isRectanglePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isCirclePressed"));
            _presentationModel.ClickToolButton("矩形");
            Assert.IsTrue((bool)_presentationModelPrivateObject.GetField("_isRectanglePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isChoosePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isLinePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isCirclePressed"));
            _presentationModel.ClickToolButton("圓");
            Assert.IsTrue((bool)_presentationModelPrivateObject.GetField("_isCirclePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isChoosePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isLinePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isRectanglePressed"));
            _presentationModel.ClickToolButton("選取");
            Assert.IsTrue((bool)_presentationModelPrivateObject.GetField("_isChoosePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isLinePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isRectanglePressed"));
            Assert.IsFalse((bool)_presentationModelPrivateObject.GetField("_isCirclePressed"));
        }
    }
}