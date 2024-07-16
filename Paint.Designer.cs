namespace MyWordPad
{
    partial class Paint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.lbColorPen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPenWidth = new System.Windows.Forms.Label();
            this.picDecrease = new System.Windows.Forms.PictureBox();
            this.picIncrease = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDecrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIncrease)).BeginInit();
            this.SuspendLayout();
            // 
            // lbColorPen
            // 
            this.lbColorPen.BackColor = System.Drawing.Color.Black;
            this.lbColorPen.Location = new System.Drawing.Point(12, 11);
            this.lbColorPen.Name = "lbColorPen";
            this.lbColorPen.Size = new System.Drawing.Size(46, 40);
            this.lbColorPen.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pen";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPenWidth
            // 
            this.lbPenWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPenWidth.AutoSize = true;
            this.lbPenWidth.Location = new System.Drawing.Point(494, 29);
            this.lbPenWidth.Name = "lbPenWidth";
            this.lbPenWidth.Size = new System.Drawing.Size(82, 20);
            this.lbPenWidth.TabIndex = 2;
            this.lbPenWidth.Text = "PenWidth:";
            // 
            // picDecrease
            // 
            this.picDecrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picDecrease.Image = global::MyWordPad.Properties.Resources.down_arrow;
            this.picDecrease.Location = new System.Drawing.Point(458, 21);
            this.picDecrease.Name = "picDecrease";
            this.picDecrease.Size = new System.Drawing.Size(30, 28);
            this.picDecrease.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDecrease.TabIndex = 3;
            this.picDecrease.TabStop = false;
            this.picDecrease.Click += new System.EventHandler(this.picDecrease_Click);
            // 
            // picIncrease
            // 
            this.picIncrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picIncrease.Image = global::MyWordPad.Properties.Resources.up_arrow2;
            this.picIncrease.Location = new System.Drawing.Point(421, 21);
            this.picIncrease.Name = "picIncrease";
            this.picIncrease.Size = new System.Drawing.Size(30, 28);
            this.picIncrease.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIncrease.TabIndex = 3;
            this.picIncrease.TabStop = false;
            this.picIncrease.Click += new System.EventHandler(this.picIncrease_Click);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(623, 392);
            this.Controls.Add(this.picDecrease);
            this.Controls.Add(this.picIncrease);
            this.Controls.Add(this.lbPenWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbColorPen);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Paint";
            this.Text = "Paint basic";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Paint_FormClosed);
            this.Load += new System.EventHandler(this.Paint_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Paint_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Paint_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Paint_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picDecrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIncrease)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbColorPen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPenWidth;
        private System.Windows.Forms.PictureBox picIncrease;
        private System.Windows.Forms.PictureBox picDecrease;
    }
}