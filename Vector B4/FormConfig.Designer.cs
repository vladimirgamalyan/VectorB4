namespace Vector_B4
{
    partial class FormConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.radioButtonFormatMach3 = new System.Windows.Forms.RadioButton();
            this.radioButtonFormatMach4 = new System.Windows.Forms.RadioButton();
            this.groupBoxFormat = new System.Windows.Forms.GroupBox();
            this.groupBoxOrientation = new System.Windows.Forms.GroupBox();
            this.radioButtonOrientationHor = new System.Windows.Forms.RadioButton();
            this.radioButtonOrientationVer = new System.Windows.Forms.RadioButton();
            this.groupBoxRepeats = new System.Windows.Forms.GroupBox();
            this.radioButtonRepeatZero = new System.Windows.Forms.RadioButton();
            this.radioButtonRepeatEnd = new System.Windows.Forms.RadioButton();
            this.groupBoxFormat.SuspendLayout();
            this.groupBoxOrientation.SuspendLayout();
            this.groupBoxRepeats.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonFormatMach3
            // 
            this.radioButtonFormatMach3.AutoSize = true;
            this.radioButtonFormatMach3.Location = new System.Drawing.Point(6, 19);
            this.radioButtonFormatMach3.Name = "radioButtonFormatMach3";
            this.radioButtonFormatMach3.Size = new System.Drawing.Size(58, 17);
            this.radioButtonFormatMach3.TabIndex = 0;
            this.radioButtonFormatMach3.TabStop = true;
            this.radioButtonFormatMach3.Text = "Mach3";
            this.radioButtonFormatMach3.UseVisualStyleBackColor = true;
            // 
            // radioButtonFormatMach4
            // 
            this.radioButtonFormatMach4.AutoSize = true;
            this.radioButtonFormatMach4.Location = new System.Drawing.Point(6, 42);
            this.radioButtonFormatMach4.Name = "radioButtonFormatMach4";
            this.radioButtonFormatMach4.Size = new System.Drawing.Size(58, 17);
            this.radioButtonFormatMach4.TabIndex = 1;
            this.radioButtonFormatMach4.TabStop = true;
            this.radioButtonFormatMach4.Text = "Mach4";
            this.radioButtonFormatMach4.UseVisualStyleBackColor = true;
            // 
            // groupBoxFormat
            // 
            this.groupBoxFormat.Controls.Add(this.radioButtonFormatMach4);
            this.groupBoxFormat.Controls.Add(this.radioButtonFormatMach3);
            this.groupBoxFormat.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFormat.Name = "groupBoxFormat";
            this.groupBoxFormat.Size = new System.Drawing.Size(74, 70);
            this.groupBoxFormat.TabIndex = 2;
            this.groupBoxFormat.TabStop = false;
            this.groupBoxFormat.Text = "Формат";
            // 
            // groupBoxOrientation
            // 
            this.groupBoxOrientation.Controls.Add(this.radioButtonOrientationVer);
            this.groupBoxOrientation.Controls.Add(this.radioButtonOrientationHor);
            this.groupBoxOrientation.Location = new System.Drawing.Point(92, 12);
            this.groupBoxOrientation.Name = "groupBoxOrientation";
            this.groupBoxOrientation.Size = new System.Drawing.Size(120, 70);
            this.groupBoxOrientation.TabIndex = 3;
            this.groupBoxOrientation.TabStop = false;
            this.groupBoxOrientation.Text = "Ориентация";
            // 
            // radioButtonOrientationHor
            // 
            this.radioButtonOrientationHor.AutoSize = true;
            this.radioButtonOrientationHor.Location = new System.Drawing.Point(6, 19);
            this.radioButtonOrientationHor.Name = "radioButtonOrientationHor";
            this.radioButtonOrientationHor.Size = new System.Drawing.Size(108, 17);
            this.radioButtonOrientationHor.TabIndex = 0;
            this.radioButtonOrientationHor.TabStop = true;
            this.radioButtonOrientationHor.Text = "Горизонтальная";
            this.radioButtonOrientationHor.UseVisualStyleBackColor = true;
            // 
            // radioButtonOrientationVer
            // 
            this.radioButtonOrientationVer.AutoSize = true;
            this.radioButtonOrientationVer.Location = new System.Drawing.Point(6, 42);
            this.radioButtonOrientationVer.Name = "radioButtonOrientationVer";
            this.radioButtonOrientationVer.Size = new System.Drawing.Size(97, 17);
            this.radioButtonOrientationVer.TabIndex = 1;
            this.radioButtonOrientationVer.TabStop = true;
            this.radioButtonOrientationVer.Text = "Вертикальная";
            this.radioButtonOrientationVer.UseVisualStyleBackColor = true;
            // 
            // groupBoxRepeats
            // 
            this.groupBoxRepeats.Controls.Add(this.radioButtonRepeatEnd);
            this.groupBoxRepeats.Controls.Add(this.radioButtonRepeatZero);
            this.groupBoxRepeats.Location = new System.Drawing.Point(12, 89);
            this.groupBoxRepeats.Name = "groupBoxRepeats";
            this.groupBoxRepeats.Size = new System.Drawing.Size(200, 72);
            this.groupBoxRepeats.TabIndex = 4;
            this.groupBoxRepeats.TabStop = false;
            this.groupBoxRepeats.Text = "Повторы";
            // 
            // radioButtonRepeatZero
            // 
            this.radioButtonRepeatZero.AutoSize = true;
            this.radioButtonRepeatZero.Location = new System.Drawing.Point(7, 20);
            this.radioButtonRepeatZero.Name = "radioButtonRepeatZero";
            this.radioButtonRepeatZero.Size = new System.Drawing.Size(132, 17);
            this.radioButtonRepeatZero.TabIndex = 0;
            this.radioButtonRepeatZero.TabStop = true;
            this.radioButtonRepeatZero.Text = "Через нулевую точку";
            this.radioButtonRepeatZero.UseVisualStyleBackColor = true;
            // 
            // radioButtonRepeatEnd
            // 
            this.radioButtonRepeatEnd.AutoSize = true;
            this.radioButtonRepeatEnd.Location = new System.Drawing.Point(7, 44);
            this.radioButtonRepeatEnd.Name = "radioButtonRepeatEnd";
            this.radioButtonRepeatEnd.Size = new System.Drawing.Size(138, 17);
            this.radioButtonRepeatEnd.TabIndex = 1;
            this.radioButtonRepeatEnd.TabStop = true;
            this.radioButtonRepeatEnd.Text = "Через конечную точку";
            this.radioButtonRepeatEnd.UseVisualStyleBackColor = true;
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 171);
            this.Controls.Add(this.groupBoxRepeats);
            this.Controls.Add(this.groupBoxOrientation);
            this.Controls.Add(this.groupBoxFormat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConfig_FormClosing);
            this.Load += new System.EventHandler(this.FormConfig_Load);
            this.groupBoxFormat.ResumeLayout(false);
            this.groupBoxFormat.PerformLayout();
            this.groupBoxOrientation.ResumeLayout(false);
            this.groupBoxOrientation.PerformLayout();
            this.groupBoxRepeats.ResumeLayout(false);
            this.groupBoxRepeats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonFormatMach3;
        private System.Windows.Forms.RadioButton radioButtonFormatMach4;
        private System.Windows.Forms.GroupBox groupBoxFormat;
        private System.Windows.Forms.GroupBox groupBoxOrientation;
        private System.Windows.Forms.RadioButton radioButtonOrientationVer;
        private System.Windows.Forms.RadioButton radioButtonOrientationHor;
        private System.Windows.Forms.GroupBox groupBoxRepeats;
        private System.Windows.Forms.RadioButton radioButtonRepeatEnd;
        private System.Windows.Forms.RadioButton radioButtonRepeatZero;
    }
}