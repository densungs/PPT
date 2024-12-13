using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface IState
    {
        //按下滑鼠
        Shape MousePressed(string shapeType, double firstPointX, double firstPointY);

        //滑鼠移動
        void MouseMove(double firstPointX, double firstPointY);

        //放開滑鼠
        Shape MouseReleased(double firstPointX, double firstPointY);

        //畫圖
        void Draw(IGraphics graphics, double scaleX, double scaleY);
    }
}
