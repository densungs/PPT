using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface IGraphics
    {
        //清除
        void ClearAll();

        //畫線
        void DrawLine(double firstPointX, double firstPointY, double secondPointX, double secondPointY);

        //畫矩形
        void DrawRectangle(double firstPointX, double firstPointY, double secondPointX, double secondPointY);

        //畫圓
        void DrawCircle(double firstPointX, double firstPointY, double secondPointX, double secondPointY);

        //畫外框
        void DrawOuterFrame(double firstPointX, double firstPointY, double secondPointX, double secondPointY);
    }
}
