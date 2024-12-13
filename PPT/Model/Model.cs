using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        bool _isPressed = false;
        private string _shapeToolBarButton;
        private int _count = 0;
        CommandManager _commandManager = new CommandManager();
        Shape _hint;
        Shape _origin;
        Shape _result;
        Shapes _shapes;
        IState _state;

        public Model()
        {
            _shapes = new Shapes();
            _state = new PointState(_shapes);
        }

        public BindingList<Shape> ShapeList
        {
            get
            {
                return _shapes.ShapesList;
            }

        }

        //畫哪個圖形
        public void SetPaintWhichShape(string shapeType)
        {
            _shapeToolBarButton = shapeType;
        }

        //獲取state
        public bool IsZoomState()
        {
            if (_state.GetType() == typeof(ZoomState))
                return true;
            else
                return false;
        }

        //設定state
        public void SetPointerState(string shapeType)
        {
            if (shapeType == Constant.TOOL_BAR_STATE_CHOOSE)
                _state = new PointState(_shapes);
            else
                _state = new DrawingState();
        }

        //畫圖
        public void Draw(IGraphics graphics, double scaleX, double scaleY)
        {
            graphics.ClearAll();
            foreach (Shape aShape in _shapes.ShapesList)
            {
                aShape.Draw(graphics, scaleX, scaleY);
            }
            if (_isPressed)
                _state.Draw(graphics, scaleX, scaleY);
        }

        //是否更改
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        //新增圖形
        public void CreateShape(string shapeType)
        {
            //_shapes.CreateShape(shapeType);
            _commandManager.Execute(new RandomCreateCommand(this, _shapes.CreateShape(shapeType)));
            SelectNoGraph();
            NotifyModelChanged();
        }

        //刪除圖形
        public void DeleteShape(int rowIndex, int columnIndex)
        {
            if (rowIndex == Constant.NUMBER_MINUS_ONE_THOUSAND)
                rowIndex = SelectWhichGraph();
            if (rowIndex >= 0 && columnIndex == 0)
            {
                _commandManager.Execute(new DeleteCommand(this, ShapeList[rowIndex]));
                SelectNoGraph();
                NotifyModelChanged();
            }
        }

        //不選圖
        public void SelectNoGraph()
        {
            if (_shapes.ShapesList.Count > 0)
                foreach (Shape aShape in _shapes.ShapesList)
                    aShape.SetIsSelect(false);
            NotifyModelChanged();
        }

        //選了哪張圖
        public int SelectWhichGraph()
        {
            _count = 0;
            foreach (Shape aShape in _shapes.ShapesList)
            {
                if (aShape.GetIsSelect())
                    return _count;
                _count++;
            }
            return -1;
        }

        //按下滑鼠
        public void PressedMouse(double firstPointX, double firstPointY)
        {
            if (_state.GetType() != typeof(ZoomState))
                SelectNoGraph();
            _hint = _state.MousePressed(_shapeToolBarButton, firstPointX, firstPointY);
            if (_hint != null)
            {
                _origin = _hint.GetType();
                _origin.SetPosition(_hint.GetStartPoint(), _hint.GetEndPoint());
                _origin.SetLayers(_hint.GetLayers());
                _isPressed = true;
            }
        }

        //移動滑鼠
        public void MoveMouse(double secondPointX, double secondPointY)
        {
            if (_isPressed)
            {
                _state.MouseMove(secondPointX, secondPointY);
                NotifyModelChanged();
                return;
            }
            if (_state.GetType() != typeof(DrawingState) && SelectWhichGraph() != -1 && _shapes.ShapesList.Count > 0)
            {
                if (_shapes.ShapesList[_count].IsInRightDownRange(secondPointX, secondPointY))
                    _state = new ZoomState(_shapes);
                else
                    _state = new PointState(_shapes);
            }
        }

        //放開滑鼠
        public void ReleasedMouse(double secondPointX, double secondPointY)
        {
            _isPressed = false;
            _result = _state.MouseReleased(secondPointX, secondPointY);
            if (_state.GetType() == typeof(PointState) || _state.GetType() == typeof(ZoomState))
            {
                if (_result != null)
                    if (_origin.GetStartPoint().X != _result.GetStartPoint().X || _origin.GetStartPoint().Y != _result.GetStartPoint().Y || _origin.GetEndPoint().X != _result.GetEndPoint().X || _origin.GetEndPoint().Y != _result.GetEndPoint().Y)
                        _commandManager.Execute(new MoveCommand(this, _origin, _result));
            }
            else if (_state.GetType() == typeof(DrawingState))
                _commandManager.Execute(new DrawCommand(this, _result));
            NotifyModelChanged();
        }

        //上一步
        public void Undo()
        {
            _commandManager.Undo();
            NotifyModelChanged();
        }

        //還原上一步
        public void Redo()
        {
            _commandManager.Redo();
            NotifyModelChanged();
        }

        //隨機建立用的執行
        public void CreateShapeByRandomCreate(Shape target)
        {
            _shapes.AddShape(target);
        }

        //隨機建立用的反向執行
        public void DeleteShapeByRandomCreate()
        {
            _shapes.DeleteShape(ShapeList.Count - 1);
        }

        //畫畫的執行
        public void CreateShapeByDrawing(Shape target)
        {
            _shapes.AddShape(target);
        }

        //畫畫的反向執行
        public void DeleteShapeByDrawing()
        {
            _shapes.DeleteShape(ShapeList.Count - 1);
        }

        //刪除的執行
        public void ExecuteDelete(int layers)
        {
            _shapes.DeleteShape(layers);
        }

        //刪除的反向執行
        public void ReverseExecutionDelete(Shape target)
        {
            _shapes.InsertShape(target);
        }

        //移動的執行
        public void ExecuteMove(Shape result)
        {
            _shapes.UpdateShape(result.GetLayers(), result);
        }

        //移動的反向執行
        public void ReverseExecutionMove(Shape origin)
        {
            _shapes.UpdateShape(origin.GetLayers(), origin);
        }

        public bool IsUndoEnable
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }

        public bool IsRedoEnable
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }
    }
}
