namespace MyWordPad
{
    partial class Replace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Replace));
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.chbMatchCase = new System.Windows.Forms.CheckBox();
            this.chbMatchWhole = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(108, 73);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(243, 26);
            this.txtReplace.TabIndex = 28;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(108, 28);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(243, 26);
            this.txtFind.TabIndex = 29;
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplaceAll.Location = new System.Drawing.Point(370, 107);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(92, 30);
            this.btnReplaceAll.TabIndex = 24;
            this.btnReplaceAll.Text = "Replace All";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(370, 143);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 30);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(370, 66);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(92, 30);
            this.btnReplace.TabIndex = 26;
            this.btnReplace.Text = "Replace ";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(370, 26);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(92, 30);
            this.btnFind.TabIndex = 27;
            this.btnFind.Text = "Find Next";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // chbMatchCase
            // 
            this.chbMatchCase.AutoSize = true;
            this.chbMatchCase.Location = new System.Drawing.Point(11, 143);
            this.chbMatchCase.Name = "chbMatchCase";
            this.chbMatchCase.Size = new System.Drawing.Size(110, 24);
            this.chbMatchCase.TabIndex = 22;
            this.chbMatchCase.Text = "Match case";
            this.chbMatchCase.UseVisualStyleBackColor = true;
            this.chbMatchCase.CheckedChanged += new System.EventHandler(this.chbMatchCase_CheckedChanged);
            // 
            // chbMatchWhole
            // 
            this.chbMatchWhole.AutoSize = true;
            this.chbMatchWhole.Location = new System.Drawing.Point(11, 113);
            this.chbMatchWhole.Name = "chbMatchWhole";
            this.chbMatchWhole.Size = new System.Drawing.Size(187, 24);
            this.chbMatchWhole.TabIndex = 23;
            this.chbMatchWhole.Text = "Match whole word only";
            this.chbMatchWhole.UseVisualStyleBackColor = true;
            this.chbMatchWhole.CheckedChanged += new System.EventHandler(this.chbMatchWhole_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Replace with:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Find what:";
            // 
            // Replace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 183);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.btnReplaceAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.chbMatchCase);
            this.Controls.Add(this.chbMatchWhole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Replace";
            this.Text = "Replace";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Replace_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.CheckBox chbMatchCase;
        private System.Windows.Forms.CheckBox chbMatchWhole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}