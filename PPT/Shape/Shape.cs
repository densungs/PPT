using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public abstract class Shape
    {
        public string ShapeInformation
        {
            get;
            set;
        }

        public string ShapeType
        {
            get;
            set;
        }

        //設定圖位置
        public abstract void SetPosition(Point firstPoint, Point secondPoint);

        //開始點
        public abstract Point GetStartPoint();

        //結束點
        public abstract Point GetEndPoint();

        //畫圖
        public abstract void Draw(IGraphics graphics, double scaleX, double scaleY);

        //鼠標是否在圖內
        public abstract bool IsInGraphRange(double mousePointX, double mousePointY);

        //是否在圖的右下角
        public abstract bool IsInRightDownRange(double mousePointX, double mousePointY);

        //設定選取
        public abstract void SetIsSelect(bool isSelect);

        //看物件是否被選取
        public abstract bool GetIsSelect();

        //設定圖層
        public abstract void SetLayers(int layers);

        //獲取圖層
        public abstract int GetLayers();

        //獲取型態
        public new abstract Shape GetType();
    }
}
