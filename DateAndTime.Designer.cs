
namespace MyWordPad
{
    partial class DateAndTime
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
            this.label1 = new System.Windows.Forms.Label();
            this.lsBox = new System.Windows.Forms.ListBox();
            this.btOkDT = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available format: ";
            // 
            // lsBox
            // 
            this.lsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsBox.FormattingEnabled = true;
            this.lsBox.ItemHeight = 16;
            this.lsBox.Location = new System.Drawing.Point(18, 40);
            this.lsBox.Name = "lsBox";
            this.lsBox.Size = new System.Drawing.Size(335, 324);
            this.lsBox.TabIndex = 1;
            // 
            // btOkDT
            // 
            this.btOkDT.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btOkDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOkDT.Location = new System.Drawing.Point(115, 392);
            this.btOkDT.Name = "btOkDT";
            this.btOkDT.Size = new System.Drawing.Size(104, 34);
            this.btOkDT.TabIndex = 2;
            this.btOkDT.Text = "OK";
            this.btOkDT.UseVisualStyleBackColor = false;
            this.btOkDT.Click += new System.EventHandler(this.btOkDT_Click);
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(250, 392);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(103, 34);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // DateAndTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 450);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOkDT);
            this.Controls.Add(this.lsBox);
            this.Controls.Add(this.label1);
            this.Name = "DateAndTime";
            this.Text = "Date And Time";
            this.Load += new System.EventHandler(this.DateTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsBox;
        private System.Windows.Forms.Button btOkDT;
        private System.Windows.Forms.Button btCancel;
    }
}