
namespace PowerPoint
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._directionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolBar = new System.Windows.Forms.ToolStrip();
            this._lineToolBarButton = new System.Windows.Forms.ToolStripButton();
            this._rectangleToolBarButton = new System.Windows.Forms.ToolStripButton();
            this._circleToolBarButton = new System.Windows.Forms.ToolStripButton();
            this._chooseToolBarButton = new System.Windows.Forms.ToolStripButton();
            this._undoToolBarButton = new System.Windows.Forms.ToolStripButton();
            this._redoToolBarButton = new System.Windows.Forms.ToolStripButton();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._button2 = new System.Windows.Forms.Button();
            this._groupBox2 = new System.Windows.Forms.GroupBox();
            this._buttonNewShape = new System.Windows.Forms.Button();
            this._comboBoxSetShape = new System.Windows.Forms.ComboBox();
            this._dataGridViewShape = new System.Windows.Forms.DataGridView();
            this._delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._canvas = new PowerPoint.DoubleBufferedPanel();
            this._splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._menuStrip1.SuspendLayout();
            this._toolBar.SuspendLayout();
            this._groupBox1.SuspendLayout();
            this._groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewShape)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
            this._splitContainer1.Panel1.SuspendLayout();
            this._splitContainer1.Panel2.SuspendLayout();
            this._splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).BeginInit();
            this._splitContainer2.Panel1.SuspendLayout();
            this._splitContainer2.Panel2.SuspendLayout();
            this._splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip1
            // 
            this._menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this._menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._directionsToolStripMenuItem});
            this._menuStrip1.Location = new System.Drawing.Point(0, 0);
            this._menuStrip1.Name = "_menuStrip1";
            this._menuStrip1.Size = new System.Drawing.Size(1198, 31);
            this._menuStrip1.TabIndex = 0;
            this._menuStrip1.Text = "_menuStrip1";
            // 
            // _directionsToolStripMenuItem
            // 
            this._directionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._directionsToolStripMenuItem.Name = "_directionsToolStripMenuItem";
            this._directionsToolStripMenuItem.Size = new System.Drawing.Size(62, 27);
            this._directionsToolStripMenuItem.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(146, 34);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _toolBar
            // 
            this._toolBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineToolBarButton,
            this._rectangleToolBarButton,
            this._circleToolBarButton,
            this._chooseToolBarButton,
            this._undoToolBarButton,
            this._redoToolBarButton});
            this._toolBar.Location = new System.Drawing.Point(0, 31);
            this._toolBar.Name = "_toolBar";
            this._toolBar.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this._toolBar.Size = new System.Drawing.Size(1198, 33);
            this._toolBar.TabIndex = 1;
            this._toolBar.Text = "toolStrip1";
            // 
            // _lineToolBarButton
            // 
            this._lineToolBarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._lineToolBarButton.Image = ((System.Drawing.Image)(resources.GetObject("_lineToolBarButton.Image")));
            this._lineToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineToolBarButton.Name = "_lineToolBarButton";
            this._lineToolBarButton.Size = new System.Drawing.Size(34, 28);
            this._lineToolBarButton.Text = "線";
            this._lineToolBarButton.Click += new System.EventHandler(this.ClickToolButton);
            // 
            // _rectangleToolBarButton
            // 
            this._rectangleToolBarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rectangleToolBarButton.Image = ((System.Drawing.Image)(resources.GetObject("_rectangleToolBarButton.Image")));
            this._rectangleToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleToolBarButton.Name = "_rectangleToolBarButton";
            this._rectangleToolBarButton.Size = new System.Drawing.Size(34, 28);
            this._rectangleToolBarButton.Text = "矩形";
            this._rectangleToolBarButton.Click += new System.EventHandler(this.ClickToolButton);
            // 
            // _circleToolBarButton
            // 
            this._circleToolBarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._circleToolBarButton.Image = ((System.Drawing.Image)(resources.GetObject("_circleToolBarButton.Image")));
            this._circleToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleToolBarButton.Name = "_circleToolBarButton";
            this._circleToolBarButton.Size = new System.Drawing.Size(34, 28);
            this._circleToolBarButton.Text = "圓";
            this._circleToolBarButton.Click += new System.EventHandler(this.ClickToolButton);
            // 
            // _chooseToolBarButton
            // 
            this._chooseToolBarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._chooseToolBarButton.Image = ((System.Drawing.Image)(resources.GetObject("_chooseToolBarButton.Image")));
            this._chooseToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._chooseToolBarButton.Name = "_chooseToolBarButton";
            this._chooseToolBarButton.Size = new System.Drawing.Size(34, 28);
            this._chooseToolBarButton.Text = "選取";
            this._chooseToolBarButton.Click += new System.EventHandler(this.ClickToolButton);
            // 
            // _undoToolBarButton
            // 
            this._undoToolBarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._undoToolBarButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoToolBarButton.Image")));
            this._undoToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoToolBarButton.Name = "_undoToolBarButton";
            this._undoToolBarButton.Size = new System.Drawing.Size(34, 28);
            this._undoToolBarButton.Click += new System.EventHandler(this.ClickUndoToolBarButton);
            // 
            // _redoToolBarButton
            // 
            this._redoToolBarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._redoToolBarButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoToolBarButton.Image")));
            this._redoToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoToolBarButton.Name = "_redoToolBarButton";
            this._redoToolBarButton.Size = new System.Drawing.Size(34, 28);
            this._redoToolBarButton.Text = "toolStripButton2";
            this._redoToolBarButton.Click += new System.EventHandler(this.ClickRedoToolBarButton);
            // 
            // _groupBox1
            // 
            this._groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this._groupBox1.Controls.Add(this._button2);
            this._groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBox1.Location = new System.Drawing.Point(0, 0);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(211, 552);
            this._groupBox1.TabIndex = 2;
            this._groupBox1.TabStop = false;
            // 
            // _button2
            // 
            this._button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._button2.Location = new System.Drawing.Point(0, 0);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(208, 117);
            this._button2.TabIndex = 0;
            this._button2.UseVisualStyleBackColor = true;
            // 
            // _groupBox2
            // 
            this._groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this._groupBox2.Controls.Add(this._buttonNewShape);
            this._groupBox2.Controls.Add(this._comboBoxSetShape);
            this._groupBox2.Controls.Add(this._dataGridViewShape);
            this._groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBox2.Location = new System.Drawing.Point(0, 0);
            this._groupBox2.Name = "_groupBox2";
            this._groupBox2.Size = new System.Drawing.Size(307, 552);
            this._groupBox2.TabIndex = 3;
            this._groupBox2.TabStop = false;
            this._groupBox2.Text = "資料顯示";
            // 
            // _buttonNewShape
            // 
            this._buttonNewShape.Location = new System.Drawing.Point(6, 22);
            this._buttonNewShape.Name = "_buttonNewShape";
            this._buttonNewShape.Size = new System.Drawing.Size(110, 46);
            this._buttonNewShape.TabIndex = 0;
            this._buttonNewShape.Text = "新增";
            this._buttonNewShape.UseVisualStyleBackColor = true;
            this._buttonNewShape.Click += new System.EventHandler(this.ClickButtonNewShape);
            // 
            // _comboBoxSetShape
            // 
            this._comboBoxSetShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxSetShape.FormattingEnabled = true;
            this._comboBoxSetShape.Items.AddRange(new object[] {
            "線",
            "矩形",
            "圓"});
            this._comboBoxSetShape.Location = new System.Drawing.Point(160, 28);
            this._comboBoxSetShape.Name = "_comboBoxSetShape";
            this._comboBoxSetShape.Size = new System.Drawing.Size(98, 26);
            this._comboBoxSetShape.TabIndex = 2;
            // 
            // _dataGridViewShape
            // 
            this._dataGridViewShape.AllowUserToAddRows = false;
            this._dataGridViewShape.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridViewShape.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridViewShape.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewShape.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._delete,
            this._shape,
            this._information});
            this._dataGridViewShape.Location = new System.Drawing.Point(3, 74);
            this._dataGridViewShape.Name = "_dataGridViewShape";
            this._dataGridViewShape.ReadOnly = true;
            this._dataGridViewShape.RowHeadersVisible = false;
            this._dataGridViewShape.RowHeadersWidth = 62;
            this._dataGridViewShape.RowTemplate.Height = 31;
            this._dataGridViewShape.Size = new System.Drawing.Size(301, 475);
            this._dataGridViewShape.TabIndex = 1;
            // 
            // _delete
            // 
            this._delete.FillWeight = 95.03218F;
            this._delete.HeaderText = "刪除";
            this._delete.MinimumWidth = 8;
            this._delete.Name = "_delete";
            this._delete.ReadOnly = true;
            this._delete.Text = "刪除";
            this._delete.UseColumnTextForButtonValue = true;
            // 
            // _shape
            // 
            this._shape.DataPropertyName = "ShapeType";
            this._shape.FillWeight = 85.22727F;
            this._shape.HeaderText = "形狀";
            this._shape.MinimumWidth = 8;
            this._shape.Name = "_shape";
            this._shape.ReadOnly = true;
            // 
            // _information
            // 
            this._information.DataPropertyName = "ShapeInformation";
            this._information.FillWeight = 119.7406F;
            this._information.HeaderText = "資訊";
            this._information.MinimumWidth = 8;
            this._information.Name = "_information";
            this._information.ReadOnly = true;
            // 
            // _splitContainer1
            // 
            this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._splitContainer1.Location = new System.Drawing.Point(0, 0);
            this._splitContainer1.Name = "_splitContainer1";
            // 
            // _splitContainer1.Panel1
            // 
            this._splitContainer1.Panel1.Controls.Add(this._canvas);
            // 
            // _splitContainer1.Panel2
            // 
            this._splitContainer1.Panel2.Controls.Add(this._groupBox2);
            this._splitContainer1.Size = new System.Drawing.Size(983, 552);
            this._splitContainer1.SplitterDistance = 672;
            this._splitContainer1.TabIndex = 5;
            this._splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MoveSplitContainer1);
            // 
            // _canvas
            // 
            this._canvas.BackColor = System.Drawing.Color.LightYellow;
            this._canvas.Location = new System.Drawing.Point(0, 0);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(535, 411);
            this._canvas.TabIndex = 4;
            // 
            // _splitContainer2
            // 
            this._splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainer2.Location = new System.Drawing.Point(0, 64);
            this._splitContainer2.Name = "_splitContainer2";
            // 
            // _splitContainer2.Panel1
            // 
            this._splitContainer2.Panel1.Controls.Add(this._groupBox1);
            // 
            // _splitContainer2.Panel2
            // 
            this._splitContainer2.Panel2.Controls.Add(this._splitContainer1);
            this._splitContainer2.Size = new System.Drawing.Size(1198, 552);
            this._splitContainer2.SplitterDistance = 211;
            this._splitContainer2.TabIndex = 6;
            this._splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MoveSplitContainer2);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1198, 616);
            this.Controls.Add(this._splitContainer2);
            this.Controls.Add(this._toolBar);
            this.Controls.Add(this._menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this._menuStrip1;
            this.Name = "Form1";
            this.Text = "HW4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            this._toolBar.ResumeLayout(false);
            this._toolBar.PerformLayout();
            this._groupBox1.ResumeLayout(false);
            this._groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewShape)).EndInit();
            this._splitContainer1.Panel1.ResumeLayout(false);
            this._splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
            this._splitContainer1.ResumeLayout(false);
            this._splitContainer2.Panel1.ResumeLayout(false);
            this._splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).EndInit();
            this._splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _directionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton _lineToolBarButton;
        private System.Windows.Forms.ToolStripButton _rectangleToolBarButton;
        private System.Windows.Forms.ToolStripButton _circleToolBarButton;
        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.GroupBox _groupBox2;
        private System.Windows.Forms.ComboBox _comboBoxSetShape;
        private System.Windows.Forms.DataGridView _dataGridViewShape;
        private System.Windows.Forms.Button _buttonNewShape;
        private System.Windows.Forms.Button _button2;
        private System.Windows.Forms.ToolStrip _toolBar;
        private System.Windows.Forms.DataGridViewButtonColumn _delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shape;
        private System.Windows.Forms.DataGridViewTextBoxColumn _information;
        private System.Windows.Forms.ToolStripButton _chooseToolBarButton;
        private System.Windows.Forms.ToolStripButton _undoToolBarButton;
        private System.Windows.Forms.ToolStripButton _redoToolBarButton;
        private System.Windows.Forms.SplitContainer _splitContainer1;
        private System.Windows.Forms.SplitContainer _splitContainer2;
        private DoubleBufferedPanel _canvas;
    }
}

