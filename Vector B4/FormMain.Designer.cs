namespace Vector_B4
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownRadius = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStep = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRetire = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonCreateTap = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonFixReturn = new System.Windows.Forms.Button();
            this.numericUpDownRepeats = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRepeatStep = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRetire)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatStep)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(275, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Радиус сканирования (мм)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(275, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Шаг сканирования (мм)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(275, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Отход (мм)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(275, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Скорость сканирования";
            // 
            // numericUpDownRadius
            // 
            this.numericUpDownRadius.DecimalPlaces = 2;
            this.numericUpDownRadius.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownRadius.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownRadius.Location = new System.Drawing.Point(465, 17);
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
            this.numericUpDownRadius.Size = new System.Drawing.Size(188, 46);
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
            this.numericUpDownSpeed.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownSpeed.Location = new System.Drawing.Point(465, 67);
            this.numericUpDownSpeed.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericUpDownSpeed.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSpeed.Name = "numericUpDownSpeed";
            this.numericUpDownSpeed.Size = new System.Drawing.Size(188, 46);
            this.numericUpDownSpeed.TabIndex = 6;
            this.numericUpDownSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSpeed.ValueChanged += new System.EventHandler(this.numericUpDownSpeed_ValueChanged);
            // 
            // numericUpDownStep
            // 
            this.numericUpDownStep.DecimalPlaces = 2;
            this.numericUpDownStep.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownStep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownStep.Location = new System.Drawing.Point(465, 119);
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
            this.numericUpDownStep.Size = new System.Drawing.Size(188, 46);
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
            this.numericUpDownRetire.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownRetire.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownRetire.Location = new System.Drawing.Point(465, 171);
            this.numericUpDownRetire.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRetire.Name = "numericUpDownRetire";
            this.numericUpDownRetire.Size = new System.Drawing.Size(188, 46);
            this.numericUpDownRetire.TabIndex = 8;
            this.numericUpDownRetire.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRetire.ValueChanged += new System.EventHandler(this.numericUpDownRetire_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.numericUpDownRetire);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownStep);
            this.groupBox1.Controls.Add(this.buttonCreateTap);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDownSpeed);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDownRadius);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 283);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сканирование";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::Vector_B4.Properties.Resources.picture;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(6, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 226);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonCreateTap
            // 
            this.buttonCreateTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreateTap.Location = new System.Drawing.Point(465, 223);
            this.buttonCreateTap.Name = "buttonCreateTap";
            this.buttonCreateTap.Size = new System.Drawing.Size(188, 48);
            this.buttonCreateTap.TabIndex = 10;
            this.buttonCreateTap.Text = "Создать код сканирования";
            this.buttonCreateTap.UseVisualStyleBackColor = true;
            this.buttonCreateTap.Click += new System.EventHandler(this.buttonCreateTap_Click);
            // 
            // buttonConvert
            // 
            this.buttonConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConvert.Location = new System.Drawing.Point(465, 22);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(188, 48);
            this.buttonConvert.TabIndex = 11;
            this.buttonConvert.Text = "Конвертировать облако точек (oblako T.tap)";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 438);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(691, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "ООО \"Системы Автоматизации\" по заказу \"Zatonirui\". Москва. 2024. Версия для верти" +
    "кального станка.";
            // 
            // buttonFixReturn
            // 
            this.buttonFixReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFixReturn.Location = new System.Drawing.Point(465, 74);
            this.buttonFixReturn.Name = "buttonFixReturn";
            this.buttonFixReturn.Size = new System.Drawing.Size(188, 48);
            this.buttonFixReturn.TabIndex = 13;
            this.buttonFixReturn.Text = "Исправить возврат и добавить повторы";
            this.buttonFixReturn.UseVisualStyleBackColor = true;
            this.buttonFixReturn.Click += new System.EventHandler(this.buttonFixReturn_Click);
            // 
            // numericUpDownRepeats
            // 
            this.numericUpDownRepeats.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownRepeats.Location = new System.Drawing.Point(124, 22);
            this.numericUpDownRepeats.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRepeats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRepeats.Name = "numericUpDownRepeats";
            this.numericUpDownRepeats.Size = new System.Drawing.Size(161, 46);
            this.numericUpDownRepeats.TabIndex = 14;
            this.numericUpDownRepeats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRepeats.ValueChanged += new System.EventHandler(this.numericUpDownRepeats_ValueChanged);
            // 
            // numericUpDownRepeatStep
            // 
            this.numericUpDownRepeatStep.DecimalPlaces = 2;
            this.numericUpDownRepeatStep.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownRepeatStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownRepeatStep.Location = new System.Drawing.Point(124, 74);
            this.numericUpDownRepeatStep.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRepeatStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownRepeatStep.Name = "numericUpDownRepeatStep";
            this.numericUpDownRepeatStep.Size = new System.Drawing.Size(161, 46);
            this.numericUpDownRepeatStep.TabIndex = 15;
            this.numericUpDownRepeatStep.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownRepeatStep.ValueChanged += new System.EventHandler(this.numericUpDownRepeatStep_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.buttonFixReturn);
            this.groupBox2.Controls.Add(this.buttonConvert);
            this.groupBox2.Controls.Add(this.numericUpDownRepeatStep);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numericUpDownRepeats);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(685, 134);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Конвертер";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(9, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Смещение (мм)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(52, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Повторы";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 462);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Полировка дисков";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRetire)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatStep)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button buttonFixReturn;
        private System.Windows.Forms.NumericUpDown numericUpDownRepeats;
        private System.Windows.Forms.NumericUpDown numericUpDownRepeatStep;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

