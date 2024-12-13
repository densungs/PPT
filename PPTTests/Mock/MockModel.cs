using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    public class MockModel : Model
    {
        //畫哪個圖形
        public new bool SetPaintWhichShape(string shapeType)
        {
            return true;
        }

        //設定state
        public new bool SetPointerState(string shapeType)
        {
            return true;
        }

        //不選圖
        public new bool SelectNoGraph()
        {
            return true;
        }

        //按下滑鼠
        public new bool PressedMouse(double firstPointX, double firstPointY)
        {
            return true;
        }

        //移動滑鼠
        public new bool MoveMouse(double secondPointX, double secondPointY)
        {
            return true;
        }

        //放開滑鼠
        public new bool ReleasedMouse(double secondPointX, double secondPointY)
        {
            return true;
        }
    }
}
