namespace MyWordPad
{
    partial class Find
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Find));
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.chbMatchCase = new System.Windows.Forms.CheckBox();
            this.chbMatchWhole = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(106, 17);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(243, 26);
            this.txtFind.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(355, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(355, 13);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(87, 30);
            this.btnFind.TabIndex = 8;
            this.btnFind.Text = "Find Next";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // chbMatchCase
            // 
            this.chbMatchCase.AutoSize = true;
            this.chbMatchCase.Location = new System.Drawing.Point(24, 90);
            this.chbMatchCase.Name = "chbMatchCase";
            this.chbMatchCase.Size = new System.Drawing.Size(110, 24);
            this.chbMatchCase.TabIndex = 5;
            this.chbMatchCase.Text = "Match case";
            this.chbMatchCase.UseVisualStyleBackColor = true;
            this.chbMatchCase.CheckedChanged += new System.EventHandler(this.chbMatchCase_CheckedChanged);
            // 
            // chbMatchWhole
            // 
            this.chbMatchWhole.AutoSize = true;
            this.chbMatchWhole.Location = new System.Drawing.Point(24, 60);
            this.chbMatchWhole.Name = "chbMatchWhole";
            this.chbMatchWhole.Size = new System.Drawing.Size(187, 24);
            this.chbMatchWhole.TabIndex = 6;
            this.chbMatchWhole.Text = "Match whole word only";
            this.chbMatchWhole.UseVisualStyleBackColor = true;
            this.chbMatchWhole.CheckedChanged += new System.EventHandler(this.chbMatchWhole_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Find what:";
            // 
            // Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 127);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.chbMatchCase);
            this.Controls.Add(this.chbMatchWhole);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Find";
            this.Text = "Find";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Find_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.CheckBox chbMatchCase;
        private System.Windows.Forms.CheckBox chbMatchWhole;
        private System.Windows.Forms.Label label1;
    }
}