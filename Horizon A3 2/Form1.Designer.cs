namespace Horizon_A3_2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownRadius = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStep = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRetire = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCreateTap = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRetire)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Радиус сканирования (мм)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Шаг сканирования (мм)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Отход (мм)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Скорость сканирования";
            // 
            // numericUpDownRadius
            // 
            this.numericUpDownRadius.DecimalPlaces = 2;
            this.numericUpDownRadius.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownRadius.Location = new System.Drawing.Point(437, 25);
            this.numericUpDownRadius.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRadius.Name = "numericUpDownRadius";
            this.numericUpDownRadius.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownRadius.TabIndex = 5;
            this.numericUpDownRadius.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDownRadius.ValueChanged += new System.EventHandler(this.numericUpDownRadius_ValueChanged);
            // 
            // numericUpDownSpeed
            // 
            this.numericUpDownSpeed.Location = new System.Drawing.Point(437, 51);
            this.numericUpDownSpeed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownSpeed.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSpeed.Name = "numericUpDownSpeed";
            this.numericUpDownSpeed.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownSpeed.TabIndex = 6;
            this.numericUpDownSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownStep
            // 
            this.numericUpDownStep.DecimalPlaces = 2;
            this.numericUpDownStep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownStep.Location = new System.Drawing.Point(437, 130);
            this.numericUpDownStep.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownStep.Name = "numericUpDownStep";
            this.numericUpDownStep.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownStep.TabIndex = 7;
            this.numericUpDownStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownStep.ValueChanged += new System.EventHandler(this.numericUpDownStep_ValueChanged);
            // 
            // numericUpDownRetire
            // 
            this.numericUpDownRetire.DecimalPlaces = 2;
            this.numericUpDownRetire.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownRetire.Location = new System.Drawing.Point(437, 202);
            this.numericUpDownRetire.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRetire.Name = "numericUpDownRetire";
            this.numericUpDownRetire.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownRetire.TabIndex = 8;
            this.numericUpDownRetire.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.numericUpDownRetire);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownStep);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDownSpeed);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDownRadius);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 251);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры сканирования";
            // 
            // buttonCreateTap
            // 
            this.buttonCreateTap.Location = new System.Drawing.Point(12, 269);
            this.buttonCreateTap.Name = "buttonCreateTap";
            this.buttonCreateTap.Size = new System.Drawing.Size(170, 23);
            this.buttonCreateTap.TabIndex = 10;
            this.buttonCreateTap.Text = "Создать код сканирования";
            this.buttonCreateTap.UseVisualStyleBackColor = true;
            this.buttonCreateTap.Click += new System.EventHandler(this.buttonCreateTap_Click);
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(188, 269);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(186, 23);
            this.buttonConvert.TabIndex = 11;
            this.buttonConvert.Text = "Конвертировать облако точек";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(388, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Американская фирма \"Транссептор технолоджи\" 2015 год. Штат Мичиган.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::Horizon_A3_2.Properties.Resources.picture;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 226);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 333);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonCreateTap);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Супер полировка дисков";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRetire)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownRadius;
        private System.Windows.Forms.NumericUpDown numericUpDownSpeed;
        private System.Windows.Forms.NumericUpDown numericUpDownStep;
        private System.Windows.Forms.NumericUpDown numericUpDownRetire;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCreateTap;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Label label5;
    }
}

