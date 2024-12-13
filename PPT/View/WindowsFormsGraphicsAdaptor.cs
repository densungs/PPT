using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPoint
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        //清除
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        //畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            if (x1 > x2 && y1 < y2)
            {
                _graphics.DrawRectangle(Pens.Black, (float)x2, (float)y1, (float)(x1 - x2), (float)(y2 - y1));
            }
            else if (x1 < x2 && y1 > y2)
            {
                _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y2, (float)(x2 - x1), (float)(y1 - y2));
            }
            else if (x1 > x2 && y1 > y2)
            {
                _graphics.DrawRectangle(Pens.Black, (float)x2, (float)y2, (float)(x1 - x2), (float)(y1 - y2));
            }
            else
            {
                _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
            }
        }

        //畫圓
        public void DrawCircle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
        }

        //畫外框
        public void DrawOuterFrame(double x1, double y1, double x2, double y2)
        {
            DrawRectangle(x1, y1, x2, y2);
            _graphics.DrawEllipse(Pens.Black, (float)(x1 - Constant.NUMBER_FIVE), (float)(y1 - Constant.NUMBER_FIVE), Constant.NUMBER_TEN, Constant.NUMBER_TEN);
            _graphics.DrawEllipse(Pens.Black, (float)(x2 - Constant.NUMBER_FIVE), (float)(y2 - Constant.NUMBER_FIVE), Constant.NUMBER_TEN, Constant.NUMBER_TEN);
            _graphics.DrawEllipse(Pens.Black, (float)(x1 - Constant.NUMBER_FIVE), (float)(y2 - Constant.NUMBER_FIVE), Constant.NUMBER_TEN, Constant.NUMBER_TEN);
            _graphics.DrawEllipse(Pens.Black, (float)(x2 - Constant.NUMBER_FIVE), (float)(y1 - Constant.NUMBER_FIVE), Constant.NUMBER_TEN, Constant.NUMBER_TEN);
            _graphics.DrawEllipse(Pens.Black, (float)((x1 + x2) / Constant.NUMBER_TWO - Constant.NUMBER_FIVE), (float)(y1 - Constant.NUMBER_FIVE), Constant.NUMBER_TEN, Constant.NUMBER_TEN);
            _graphics.DrawEllipse(Pens.Black, (float)((x1 + x2) / Constant.NUMBER_TWO - Constant.NUMBER_FIVE), (float)(y2 - Constant.NUMBER_FIVE), Constant.NUMBER_TEN, Constant.NUMBER_TEN);
            _graphics.DrawEllipse(Pens.Black, (float)(x1 - Constant.NUMBER_FIVE), (float)((y1 + y2) / Constant.NUMBER_TWO - Constant.NUMBER_FIVE), Constant.NUMBER_TEN, Constant.NUMBER_TEN);
            _graphics.DrawEllipse(Pens.Black, (float)(x2 - Constant.NUMBER_FIVE), (float)((y1 + y2) / Constant.NUMBER_TWO - Constant.NUMBER_FIVE), Constant.NUMBER_TEN, Constant.NUMBER_TEN);
        }
    }
}
