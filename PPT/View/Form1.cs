using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        Model _model;
        PresentationModel.PresentationModel _presentationModel;

        public Form1()
        {
            InitializeComponent();
            KeyDown += KeyDownForm1;

            _canvas.MouseEnter += MouseEnterCanvas;
            _canvas.MouseLeave += MouseLeaveCanvas;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;

            _dataGridViewShape.CellClick += new DataGridViewCellEventHandler(ClickDataGridView1CellContent);

            _model = new Model();
            _dataGridViewShape.DataSource = _model.ShapeList;
            _presentationModel = new PresentationModel.PresentationModel(_model);
            _model._modelChanged += HandleModelChanged;
            _presentationModel._toolBarButtonClicked += SetToolBarStatus;
            _chooseToolBarButton.Checked = true;
            _undoToolBarButton.Enabled = false;
            _redoToolBarButton.Enabled = false;
        }

        //滑鼠進入Canvas
        public void MouseEnterCanvas(object sender, EventArgs e)
        {
            Cursor = _presentationModel.SetCursor();
        }

        //滑鼠離開Canvas
        public void MouseLeaveCanvas(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        //在Canvas上按下滑鼠
        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasPressed(e.X, e.Y, _canvas.Width, _canvas.Height);
        }

        //放開滑鼠
        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasReleased(e.X, e.Y, _canvas.Width, _canvas.Height);
            Cursor = Cursors.Default;
            RefreshButton();
            RefreshUndoRedoButton();
        }

        //滑鼠移動
        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasMoved(e.X, e.Y, _canvas.Width, _canvas.Height);
            Cursor = _presentationModel.SetCursor();
        }

        //更新畫布
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics, _canvas.Width, _canvas.Height);
        }

        //是否更新畫布
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        //按下刪除
        private void ClickDataGridView1CellContent(object sender, DataGridViewCellEventArgs e)
        {
            _model.DeleteShape(e.RowIndex, e.ColumnIndex);
            RefreshButton();
            RefreshUndoRedoButton();
        }

        //按下新增按鈕
        private void ClickButtonNewShape(object sender, EventArgs e)
        {
            if (_comboBoxSetShape.SelectedItem != null)
            {
                _model.CreateShape(_comboBoxSetShape.SelectedItem.ToString());
                RefreshButton();
            }
            RefreshUndoRedoButton();
        }

        //按下ToolBar按鈕
        private void ClickToolButton(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            _presentationModel.ClickToolButton(button.Text);
        }

        //設定ToolBar狀態
        private void SetToolBarStatus(bool lineChecked, bool rectangleChecked, bool circleChecked, bool chooseChecked)
        {
            _lineToolBarButton.Checked = lineChecked;
            _rectangleToolBarButton.Checked = rectangleChecked;
            _circleToolBarButton.Checked = circleChecked;
            _chooseToolBarButton.Checked = chooseChecked;
        }

        //更新左邊button圖像
        private void RefreshButton()
        {
            Bitmap aPicture = new Bitmap(_canvas.Width, _canvas.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            _canvas.DrawToBitmap(aPicture, new System.Drawing.Rectangle(0, 0, _canvas.Width, _canvas.Height));
            _button2.Image = ZoomPicture(aPicture);
        }

        //複製canvas
        private Bitmap ZoomPicture(Bitmap aPicture)
        {
            var actualBitmap = new Bitmap(_button2.Width, _button2.Height);
            var graph = Graphics.FromImage(actualBitmap);
            graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            graph.DrawImage(aPicture,
                new RectangleF(0, 0, actualBitmap.Width, actualBitmap.Height),
                new RectangleF(0, 0, aPicture.Width, aPicture.Height),
                GraphicsUnit.Pixel);
            graph.Dispose();
            return actualBitmap;
        }

        //按下undo鍵
        private void ClickUndoToolBarButton(object sender, EventArgs e)
        {
            _model.Undo();
            RefreshButton();
            RefreshUndoRedoButton();
        }

        //按下redo鍵
        private void ClickRedoToolBarButton(object sender, EventArgs e)
        {
            _model.Redo();
            RefreshButton();
            RefreshUndoRedoButton();
        }

        //更新undo, redo的UI
        private void RefreshUndoRedoButton()
        {
            _undoToolBarButton.Enabled = _model.IsUndoEnable;
            _redoToolBarButton.Enabled = _model.IsRedoEnable;
            Invalidate();
        }

        //設定panel的大小會固定在16:9
        private void MoveSplitContainer1(object sender, SplitterEventArgs e)
        {
            _canvas.Width = _splitContainer1.Panel1.Width;
            _canvas.Height = _splitContainer1.Panel1.Width * Constant.NUMBER_NINE / Constant.NUMBER_SIXTEEN;
            _canvas.Location = new System.Drawing.Point(0, _splitContainer1.Panel1.Height / Constant.NUMBER_TWO - _canvas.Height / Constant.NUMBER_TWO);
            RefreshButton();
            HandleModelChanged();
        }

        //設定左邊的顯示button的大小
        private void MoveSplitContainer2(object sender, SplitterEventArgs e)
        {
            _button2.Width = _groupBox1.Width;
            _button2.Height = _groupBox1.Width * Constant.NUMBER_NINE / Constant.NUMBER_SIXTEEN;
            RefreshButton();
            HandleModelChanged();
        }

        //按下Delete鍵
        private void KeyDownForm1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _model.DeleteShape(Constant.NUMBER_MINUS_ONE_THOUSAND, 0);
                RefreshButton();
                RefreshUndoRedoButton();
            }
        }
    }
}
