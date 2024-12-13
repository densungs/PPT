using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PowerPoint
{
    public class Shapes
    {
        private BindingList<Shape> _shapesList = new BindingList<Shape>();

        public BindingList<Shape> ShapesList
        {
            get
            {
                return _shapesList;
            }
        }

        //儲存物件
        public void AddShape(Shape newShape)
        {
            _shapesList.Add(newShape);
            SetLayers();
        }

        //刪除物件
        public void DeleteShape(int rowIndex)
        {
            _shapesList.RemoveAt(rowIndex);
            SetLayers();
        }

        //更新物件
        public void UpdateShape(int index, Shape result)
        {
            _shapesList[index] = result;
        }

        //獲取儲存物件
        public BindingList<Shape> GetShapesList()
        {
            return _shapesList;
        }

        //建立物件
        public Shape CreateShape(string shapeType)
        {
            Shape result = Factory.CreateShape(shapeType);
            return result;
        }

        //設定圖層
        public void SetLayers()
        {
            int layers = 0;
            foreach (Shape aShape in _shapesList)
            {
                aShape.SetLayers(layers);
                layers++;
            }
        }

        //插入圖形
        public void InsertShape(Shape target)
        {
            ShapesList.Insert(target.GetLayers(), target);
            SetLayers();
        }
    }
}
