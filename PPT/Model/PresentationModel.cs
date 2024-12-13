using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint.PresentationModel
{
    public class PresentationModel
    {
        public delegate void ToolBarButtonClickEventHandler(bool lineChecked, bool rectangleChecked, bool circleChecked, bool chooseChecked);
        public event ToolBarButtonClickEventHandler _toolBarButtonClicked;
        Model _model;
        bool _isLinePressed = false;
        bool _isRectanglePressed = false;
        bool _isCirclePressed = false;
        bool _isChoosePressed = true;
        public PresentationModel(Model model)
        {
            _model = model;
        }

        //在畫布上按下滑鼠
        public void HandleCanvasPressed(double mousePointX, double mousePointY, int panelWidth, int panelHeight)
        {
            _model.PressedMouse(ConvertScaleStoreX(panelWidth, mousePointX), ConvertScaleStoreY(panelHeight, mousePointY));
            //_model.PressedMouse(mousePointX, mousePointY);
        }

        //放開滑鼠
        public void HandleCanvasReleased(double mousePointX, double mousePointY, int panelWidth, int panelHeight)
        {
            _model.ReleasedMouse(ConvertScaleStoreX(panelWidth, mousePointX), ConvertScaleStoreY(panelHeight, mousePointY));
            _isLinePressed = false;
            _isRectanglePressed = false;
            _isCirclePressed = false;
            _isChoosePressed = true;
            _model.SetPointerState(Constant.TOOL_BAR_STATE_CHOOSE);
            SetToolBarStatus();
        }

        //移動滑鼠
        public void HandleCanvasMoved(double mousePointX, double mousePointY, int panelWidth, int panelHeight)
        {
            _model.MoveMouse(ConvertScaleStoreX(panelWidth, mousePointX), ConvertScaleStoreY(panelHeight, mousePointY));
            SetCursor();
        }

        //ToolBar被按下
        public void ClickToolButton(string shapeType)
        {
            _isLinePressed = false;
            _isRectanglePressed = false;
            _isCirclePressed = false;
            _isChoosePressed = false;
            _model.SelectNoGraph();
            _model.SetPaintWhichShape(shapeType);
            _model.SetPointerState(shapeType);
            PressedWhichToolButton(shapeType);
            SetToolBarStatus();
        }

        //確定ToolBar的哪顆Button被按下
        private void PressedWhichToolButton(string shapeType)
        {
            switch (shapeType)
            {
                case Constant.SHAPE_TYPE_LINE_CHINESE:
                    _isLinePressed = true;
                    return;
                case Constant.SHAPE_TYPE_RECTANGLE_CHINESE:
                    _isRectanglePressed = true;
                    return;
                case Constant.SHAPE_TYPE_CIRCLE_CHINESE:
                    _isCirclePressed = true;
                    return;
                case Constant.TOOL_BAR_STATE_CHOOSE:
                    _isChoosePressed = true;
                    return;
            }
            SetToolBarStatus();
        }

        //設定ToolBar狀態
        public void SetToolBarStatus()
        {
            if (_toolBarButtonClicked != null)
            {
                _toolBarButtonClicked(_isLinePressed, _isRectanglePressed, _isCirclePressed, _isChoosePressed);
            }
        }

        //設定鼠標形狀
        public Cursor SetCursor()
        {
            if (_isChoosePressed == true)
            {
                if (_model.IsZoomState())
                    return Cursors.SizeNWSE;
                else
                    return Cursors.Default;
            }
            else
                return Cursors.Cross;
        }

        //畫圖
        public void Draw(System.Drawing.Graphics graphics, int panelWidth, int panelHeight)
        {
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics), ConvertScaleDrawX(panelWidth), ConvertScaleDrawY(panelHeight));
        }

        //轉換比例X儲存用
        public double ConvertScaleStoreX(int panelWidth, double mousePointX)
        {
            double resultX = mousePointX * Constant.STANDARD_WIDTH / panelWidth;
            return resultX;
        }

        //轉換比例Y儲存用
        public double ConvertScaleStoreY(int panelHeight, double mousePointY)
        {
            double resultY = mousePointY * Constant.STANDARD_HEIGHT / panelHeight;
            return resultY;
        }

        //轉換比例X繪圖用
        public double ConvertScaleDrawX(int panelWidth)
        {
            double scaleX = (double)panelWidth / Constant.STANDARD_WIDTH;
            return scaleX;
        }

        //轉換比例Y繪圖用
        public double ConvertScaleDrawY(int panelHeight)
        {
            double scaleY = (double)panelHeight / Constant.STANDARD_HEIGHT;
            return scaleY;
        }
    }
}
