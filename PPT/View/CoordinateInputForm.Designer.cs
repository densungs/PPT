
namespace PPT.View
{
    partial class CoordinateInputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._leftTopX = new System.Windows.Forms.TextBox();
            this._rightDownX = new System.Windows.Forms.TextBox();
            this._rightDownY = new System.Windows.Forms.TextBox();
            this._leftTopY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _leftTopX
            // 
            this._leftTopX.Location = new System.Drawing.Point(87, 73);
            this._leftTopX.Name = "_leftTopX";
            this._leftTopX.Size = new System.Drawing.Size(100, 29);
            this._leftTopX.TabIndex = 0;
            // 
            // _rightDownX
            // 
            this._rightDownX.Location = new System.Drawing.Point(87, 137);
            this._rightDownX.Name = "_rightDownX";
            this._rightDownX.Size = new System.Drawing.Size(100, 29);
            this._rightDownX.TabIndex = 1;
            // 
            // _rightDownY
            // 
            this._rightDownY.Location = new System.Drawing.Point(255, 137);
            this._rightDownY.Name = "_rightDownY";
            this._rightDownY.Size = new System.Drawing.Size(100, 29);
            this._rightDownY.TabIndex = 2;
            // 
            // _leftTopY
            // 
            this._leftTopY.Location = new System.Drawing.Point(255, 73);
            this._leftTopY.Name = "_leftTopY";
            this._leftTopY.Size = new System.Drawing.Size(100, 29);
            this._leftTopY.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "左上角座標X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "左上角座標Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "右下角座標X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "右下角座標Y";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // CoordinateInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 244);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._leftTopY);
            this.Controls.Add(this._rightDownY);
            this.Controls.Add(this._rightDownX);
            this.Controls.Add(this._leftTopX);
            this.Name = "CoordinateInputForm";
            this.Text = "CoordinateInputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _leftTopX;
        private System.Windows.Forms.TextBox _rightDownX;
        private System.Windows.Forms.TextBox _rightDownY;
        private System.Windows.Forms.TextBox _leftTopY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}