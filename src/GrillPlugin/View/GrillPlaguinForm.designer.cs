﻿namespace GrillPlugin
{
	partial class GrillPluginForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.boxLengthLable = new System.Windows.Forms.Label();
			this.boxLengthTextBox = new System.Windows.Forms.TextBox();
			this.boxWidthLable = new System.Windows.Forms.Label();
			this.boxHeightLable = new System.Windows.Forms.Label();
			this.boxWallThickness = new System.Windows.Forms.Label();
			this.boxGroupBox = new System.Windows.Forms.GroupBox();
			this.lengthBorderLable = new System.Windows.Forms.Label();
			this.thicknessBorderLable = new System.Windows.Forms.Label();
			this.widthBorderLable = new System.Windows.Forms.Label();
			this.heightBorderLable = new System.Windows.Forms.Label();
			this.wallThicknessTextBox = new System.Windows.Forms.TextBox();
			this.boxHeightTextBox = new System.Windows.Forms.TextBox();
			this.boxWidthTextBox = new System.Windows.Forms.TextBox();
			this.legsGroupBox = new System.Windows.Forms.GroupBox();
			this.legDiameterBorderLable = new System.Windows.Forms.Label();
			this.legDiameterTextBox = new System.Windows.Forms.TextBox();
			this.legDiameterLable = new System.Windows.Forms.Label();
			this.legHeightBorderLable = new System.Windows.Forms.Label();
			this.legHeightTextBox = new System.Windows.Forms.TextBox();
			this.legHeightLable = new System.Windows.Forms.Label();
			this.grooveGroupBox = new System.Windows.Forms.GroupBox();
			this.grooveDiameterBorderLable = new System.Windows.Forms.Label();
			this.grooveDistanceTextBox = new System.Windows.Forms.TextBox();
			this.grooveDistanceLable = new System.Windows.Forms.Label();
			this.grooveDistanceBorderLable = new System.Windows.Forms.Label();
			this.grooveDiameterTextBox = new System.Windows.Forms.TextBox();
			this.grooveDiameterLable = new System.Windows.Forms.Label();
			this.holeGroupBox = new System.Windows.Forms.GroupBox();
			this.holeDistanceTextBox = new System.Windows.Forms.TextBox();
			this.holeDistanceLable = new System.Windows.Forms.Label();
			this.holeDistanceBorderLable = new System.Windows.Forms.Label();
			this.holeDiameterBorderLable = new System.Windows.Forms.Label();
			this.holeHeightTextBox = new System.Windows.Forms.TextBox();
			this.holeHeightLable = new System.Windows.Forms.Label();
			this.holeHeightBorderLable = new System.Windows.Forms.Label();
			this.holeDiameterTextBox = new System.Windows.Forms.TextBox();
			this.holeDiameterLable = new System.Windows.Forms.Label();
			this.buildButton = new System.Windows.Forms.Button();
			this.ErrorLable = new System.Windows.Forms.Label();
			this.boxGroupBox.SuspendLayout();
			this.legsGroupBox.SuspendLayout();
			this.grooveGroupBox.SuspendLayout();
			this.holeGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// boxLengthLable
			// 
			this.boxLengthLable.AutoSize = true;
			this.boxLengthLable.Location = new System.Drawing.Point(70, 16);
			this.boxLengthLable.Name = "boxLengthLable";
			this.boxLengthLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.boxLengthLable.Size = new System.Drawing.Size(49, 13);
			this.boxLengthLable.TabIndex = 0;
			this.boxLengthLable.Text = "Длина L";
			// 
			// boxLengthTextBox
			// 
			this.boxLengthTextBox.Location = new System.Drawing.Point(131, 13);
			this.boxLengthTextBox.Name = "boxLengthTextBox";
			this.boxLengthTextBox.Size = new System.Drawing.Size(100, 20);
			this.boxLengthTextBox.TabIndex = 1;
			this.boxLengthTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChange);
			this.boxLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			// 
			// boxWidthLable
			// 
			this.boxWidthLable.AutoSize = true;
			this.boxWidthLable.Location = new System.Drawing.Point(59, 42);
			this.boxWidthLable.Name = "boxWidthLable";
			this.boxWidthLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.boxWidthLable.Size = new System.Drawing.Size(60, 13);
			this.boxWidthLable.TabIndex = 2;
			this.boxWidthLable.Text = "Ширина W";
			// 
			// boxHeightLable
			// 
			this.boxHeightLable.AutoSize = true;
			this.boxHeightLable.Location = new System.Drawing.Point(57, 68);
			this.boxHeightLable.Name = "boxHeightLable";
			this.boxHeightLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.boxHeightLable.Size = new System.Drawing.Size(62, 13);
			this.boxHeightLable.TabIndex = 3;
			this.boxHeightLable.Text = "Высота Hg";
			// 
			// boxWallThickness
			// 
			this.boxWallThickness.AutoSize = true;
			this.boxWallThickness.Location = new System.Drawing.Point(6, 94);
			this.boxWallThickness.Name = "boxWallThickness";
			this.boxWallThickness.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.boxWallThickness.Size = new System.Drawing.Size(113, 13);
			this.boxWallThickness.TabIndex = 4;
			this.boxWallThickness.Text = "Толщина стенок Ww";
			// 
			// boxGroupBox
			// 
			this.boxGroupBox.Controls.Add(this.lengthBorderLable);
			this.boxGroupBox.Controls.Add(this.thicknessBorderLable);
			this.boxGroupBox.Controls.Add(this.widthBorderLable);
			this.boxGroupBox.Controls.Add(this.heightBorderLable);
			this.boxGroupBox.Controls.Add(this.wallThicknessTextBox);
			this.boxGroupBox.Controls.Add(this.boxHeightTextBox);
			this.boxGroupBox.Controls.Add(this.boxWidthTextBox);
			this.boxGroupBox.Controls.Add(this.boxLengthLable);
			this.boxGroupBox.Controls.Add(this.boxLengthTextBox);
			this.boxGroupBox.Controls.Add(this.boxWallThickness);
			this.boxGroupBox.Controls.Add(this.boxWidthLable);
			this.boxGroupBox.Controls.Add(this.boxHeightLable);
			this.boxGroupBox.Location = new System.Drawing.Point(12, 12);
			this.boxGroupBox.Name = "boxGroupBox";
			this.boxGroupBox.Size = new System.Drawing.Size(436, 122);
			this.boxGroupBox.TabIndex = 5;
			this.boxGroupBox.TabStop = false;
			this.boxGroupBox.Text = "Короб мангала";
			// 
			// lengthBorderLable
			// 
			this.lengthBorderLable.AutoSize = true;
			this.lengthBorderLable.Location = new System.Drawing.Point(237, 16);
			this.lengthBorderLable.Name = "lengthBorderLable";
			this.lengthBorderLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lengthBorderLable.Size = new System.Drawing.Size(80, 13);
			this.lengthBorderLable.TabIndex = 8;
			this.lengthBorderLable.Text = "500 - 2000, мм";
			// 
			// thicknessBorderLable
			// 
			this.thicknessBorderLable.AutoSize = true;
			this.thicknessBorderLable.Location = new System.Drawing.Point(237, 94);
			this.thicknessBorderLable.Name = "thicknessBorderLable";
			this.thicknessBorderLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.thicknessBorderLable.Size = new System.Drawing.Size(50, 13);
			this.thicknessBorderLable.TabIndex = 11;
			this.thicknessBorderLable.Text = "2 - 8, мм";
			// 
			// widthBorderLable
			// 
			this.widthBorderLable.AutoSize = true;
			this.widthBorderLable.Location = new System.Drawing.Point(237, 42);
			this.widthBorderLable.Name = "widthBorderLable";
			this.widthBorderLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.widthBorderLable.Size = new System.Drawing.Size(74, 13);
			this.widthBorderLable.TabIndex = 9;
			this.widthBorderLable.Text = "300 - 500, мм";
			// 
			// heightBorderLable
			// 
			this.heightBorderLable.AutoSize = true;
			this.heightBorderLable.Location = new System.Drawing.Point(237, 68);
			this.heightBorderLable.Name = "heightBorderLable";
			this.heightBorderLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.heightBorderLable.Size = new System.Drawing.Size(74, 13);
			this.heightBorderLable.TabIndex = 10;
			this.heightBorderLable.Text = "200 - 500, мм";
			// 
			// wallThicknessTextBox
			// 
			this.wallThicknessTextBox.Location = new System.Drawing.Point(131, 91);
			this.wallThicknessTextBox.Name = "wallThicknessTextBox";
			this.wallThicknessTextBox.Size = new System.Drawing.Size(100, 20);
			this.wallThicknessTextBox.TabIndex = 7;
			this.wallThicknessTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChange);
			this.wallThicknessTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			// 
			// boxHeightTextBox
			// 
			this.boxHeightTextBox.Location = new System.Drawing.Point(131, 65);
			this.boxHeightTextBox.Name = "boxHeightTextBox";
			this.boxHeightTextBox.Size = new System.Drawing.Size(100, 20);
			this.boxHeightTextBox.TabIndex = 6;
			this.boxHeightTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChange);
			this.boxHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			// 
			// boxWidthTextBox
			// 
			this.boxWidthTextBox.Location = new System.Drawing.Point(131, 39);
			this.boxWidthTextBox.Name = "boxWidthTextBox";
			this.boxWidthTextBox.Size = new System.Drawing.Size(100, 20);
			this.boxWidthTextBox.TabIndex = 5;
			this.boxWidthTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChange);
			this.boxWidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			// 
			// legsGroupBox
			// 
			this.legsGroupBox.Controls.Add(this.legDiameterBorderLable);
			this.legsGroupBox.Controls.Add(this.legDiameterTextBox);
			this.legsGroupBox.Controls.Add(this.legDiameterLable);
			this.legsGroupBox.Controls.Add(this.legHeightBorderLable);
			this.legsGroupBox.Controls.Add(this.legHeightTextBox);
			this.legsGroupBox.Controls.Add(this.legHeightLable);
			this.legsGroupBox.Location = new System.Drawing.Point(13, 140);
			this.legsGroupBox.Name = "legsGroupBox";
			this.legsGroupBox.Size = new System.Drawing.Size(435, 70);
			this.legsGroupBox.TabIndex = 6;
			this.legsGroupBox.TabStop = false;
			this.legsGroupBox.Text = "Ножки";
			// 
			// legDiameterBorderLable
			// 
			this.legDiameterBorderLable.AutoSize = true;
			this.legDiameterBorderLable.Location = new System.Drawing.Point(236, 42);
			this.legDiameterBorderLable.Name = "legDiameterBorderLable";
			this.legDiameterBorderLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.legDiameterBorderLable.Size = new System.Drawing.Size(101, 13);
			this.legDiameterBorderLable.TabIndex = 17;
			this.legDiameterBorderLable.Text = "[2*Ww] - [W/2], мм";
			// 
			// legDiameterTextBox
			// 
			this.legDiameterTextBox.Location = new System.Drawing.Point(130, 39);
			this.legDiameterTextBox.Name = "legDiameterTextBox";
			this.legDiameterTextBox.Size = new System.Drawing.Size(100, 20);
			this.legDiameterTextBox.TabIndex = 16;
			this.legDiameterTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChange);
			this.legDiameterTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			// 
			// legDiameterLable
			// 
			this.legDiameterLable.AutoSize = true;
			this.legDiameterLable.Location = new System.Drawing.Point(58, 42);
			this.legDiameterLable.Name = "legDiameterLable";
			this.legDiameterLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.legDiameterLable.Size = new System.Drawing.Size(66, 13);
			this.legDiameterLable.TabIndex = 15;
			this.legDiameterLable.Text = "Диаметр Dl";
			// 
			// legHeightBorderLable
			// 
			this.legHeightBorderLable.AutoSize = true;
			this.legHeightBorderLable.Location = new System.Drawing.Point(236, 16);
			this.legHeightBorderLable.Name = "legHeightBorderLable";
			this.legHeightBorderLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.legHeightBorderLable.Size = new System.Drawing.Size(80, 13);
			this.legHeightBorderLable.TabIndex = 14;
			this.legHeightBorderLable.Text = "500 - 1000, мм";
			// 
			// legHeightTextBox
			// 
			this.legHeightTextBox.Location = new System.Drawing.Point(130, 13);
			this.legHeightTextBox.Name = "legHeightTextBox";
			this.legHeightTextBox.Size = new System.Drawing.Size(100, 20);
			this.legHeightTextBox.TabIndex = 13;
			this.legHeightTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChange);
			this.legHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			// 
			// legHeightLable
			// 
			this.legHeightLable.AutoSize = true;
			this.legHeightLable.Location = new System.Drawing.Point(66, 16);
			this.legHeightLable.Name = "legHeightLable";
			this.legHeightLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.legHeightLable.Size = new System.Drawing.Size(58, 13);
			this.legHeightLable.TabIndex = 12;
			this.legHeightLable.Text = "Высота Hl";
			// 
			// grooveGroupBox
			// 
			this.grooveGroupBox.Controls.Add(this.grooveDiameterBorderLable);
			this.grooveGroupBox.Controls.Add(this.grooveDistanceTextBox);
			this.grooveGroupBox.Controls.Add(this.grooveDistanceLable);
			this.grooveGroupBox.Controls.Add(this.grooveDistanceBorderLable);
			this.grooveGroupBox.Controls.Add(this.grooveDiameterTextBox);
			this.grooveGroupBox.Controls.Add(this.grooveDiameterLable);
			this.grooveGroupBox.Location = new System.Drawing.Point(13, 216);
			this.grooveGroupBox.Name = "grooveGroupBox";
			this.grooveGroupBox.Size = new System.Drawing.Size(435, 76);
			this.grooveGroupBox.TabIndex = 18;
			this.grooveGroupBox.TabStop = false;
			this.grooveGroupBox.Text = "Пазы для шампуров";
			// 
			// grooveDiameterBorderLable
			// 
			this.grooveDiameterBorderLable.AutoSize = true;
			this.grooveDiameterBorderLable.Location = new System.Drawing.Point(236, 22);
			this.grooveDiameterBorderLable.Name = "grooveDiameterBorderLable";
			this.grooveDiameterBorderLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grooveDiameterBorderLable.Size = new System.Drawing.Size(56, 13);
			this.grooveDiameterBorderLable.TabIndex = 17;
			this.grooveDiameterBorderLable.Text = "5 - 20, мм";
			// 
			// grooveDistanceTextBox
			// 
			this.grooveDistanceTextBox.Location = new System.Drawing.Point(130, 45);
			this.grooveDistanceTextBox.Name = "grooveDistanceTextBox";
			this.grooveDistanceTextBox.Size = new System.Drawing.Size(100, 20);
			this.grooveDistanceTextBox.TabIndex = 16;
			this.grooveDistanceTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChange);
			this.grooveDistanceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			// 
			// grooveDistanceLable
			// 
			this.grooveDistanceLable.AutoSize = true;
			this.grooveDistanceLable.Location = new System.Drawing.Point(6, 48);
			this.grooveDistanceLable.Name = "grooveDistanceLable";
			this.grooveDistanceLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grooveDistanceLable.Size = new System.Drawing.Size(118, 13);
			this.grooveDistanceLable.TabIndex = 15;
			this.grooveDistanceLable.Text = "Расстояние между dg";
			// 
			// grooveDistanceBorderLable
			// 
			this.grooveDistanceBorderLable.AutoSize = true;
			this.grooveDistanceBorderLable.Location = new System.Drawing.Point(236, 48);
			this.grooveDistanceBorderLable.Name = "grooveDistanceBorderLable";
			this.grooveDistanceBorderLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grooveDistanceBorderLable.Size = new System.Drawing.Size(134, 13);
			this.grooveDistanceBorderLable.TabIndex = 14;
			this.grooveDistanceBorderLable.Text = "Dg - [L - (2*Ww + Dg)], мм";
			// 
			// grooveDiameterTextBox
			// 
			this.grooveDiameterTextBox.Location = new System.Drawing.Point(130, 19);
			this.grooveDiameterTextBox.Name = "grooveDiameterTextBox";
			this.grooveDiameterTextBox.Size = new System.Drawing.Size(100, 20);
			this.grooveDiameterTextBox.TabIndex = 13;
			this.grooveDiameterTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChange);
			this.grooveDiameterTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			// 
			// grooveDiameterLable
			// 
			this.grooveDiameterLable.AutoSize = true;
			this.grooveDiameterLable.Location = new System.Drawing.Point(54, 22);
			this.grooveDiameterLable.Name = "grooveDiameterLable";
			this.grooveDiameterLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.grooveDiameterLable.Size = new System.Drawing.Size(70, 13);
			this.grooveDiameterLable.TabIndex = 12;
			this.grooveDiameterLable.Text = "Диаметр Dg";
			// 
			// holeGroupBox
			// 
			this.holeGroupBox.Controls.Add(this.holeDistanceTextBox);
			this.holeGroupBox.Controls.Add(this.holeDistanceLable);
			this.holeGroupBox.Controls.Add(this.holeDistanceBorderLable);
			this.holeGroupBox.Controls.Add(this.holeDiameterBorderLable);
			this.holeGroupBox.Controls.Add(this.holeHeightTextBox);
			this.holeGroupBox.Controls.Add(this.holeHeightLable);
			this.holeGroupBox.Controls.Add(this.holeHeightBorderLable);
			this.holeGroupBox.Controls.Add(this.holeDiameterTextBox);
			this.holeGroupBox.Controls.Add(this.holeDiameterLable);
			this.holeGroupBox.Location = new System.Drawing.Point(13, 298);
			this.holeGroupBox.Name = "holeGroupBox";
			this.holeGroupBox.Size = new System.Drawing.Size(435, 107);
			this.holeGroupBox.TabIndex = 19;
			this.holeGroupBox.TabStop = false;
			this.holeGroupBox.Text = "Отверстия для воздуха";
			// 
			// holeDistanceTextBox
			// 
			this.holeDistanceTextBox.Location = new System.Drawing.Point(130, 75);
			this.holeDistanceTextBox.Name = "holeDistanceTextBox";
			this.holeDistanceTextBox.Size = new System.Drawing.Size(100, 20);
			this.holeDistanceTextBox.TabIndex = 20;
			this.holeDistanceTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChange);
			this.holeDistanceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			// 
			// holeDistanceLable
			// 
			this.holeDistanceLable.AutoSize = true;
			this.holeDistanceLable.Location = new System.Drawing.Point(6, 78);
			this.holeDistanceLable.Name = "holeDistanceLable";
			this.holeDistanceLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.holeDistanceLable.Size = new System.Drawing.Size(118, 13);
			this.holeDistanceLable.TabIndex = 19;
			this.holeDistanceLable.Text = "Расстояние между dh";
			// 
			// holeDistanceBorderLable
			// 
			this.holeDistanceBorderLable.AutoSize = true;
			this.holeDistanceBorderLable.Location = new System.Drawing.Point(236, 78);
			this.holeDistanceBorderLable.Name = "holeDistanceBorderLable";
			this.holeDistanceBorderLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.holeDistanceBorderLable.Size = new System.Drawing.Size(134, 13);
			this.holeDistanceBorderLable.TabIndex = 18;
			this.holeDistanceBorderLable.Text = "Dh - [L - (2*Ww + Dh)], мм";
			// 
			// holeDiameterBorderLable
			// 
			this.holeDiameterBorderLable.AutoSize = true;
			this.holeDiameterBorderLable.Location = new System.Drawing.Point(236, 22);
			this.holeDiameterBorderLable.Name = "holeDiameterBorderLable";
			this.holeDiameterBorderLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.holeDiameterBorderLable.Size = new System.Drawing.Size(81, 13);
			this.holeDiameterBorderLable.TabIndex = 17;
			this.holeDiameterBorderLable.Text = "10 - [Hg/2], мм";
			// 
			// holeHeightTextBox
			// 
			this.holeHeightTextBox.Location = new System.Drawing.Point(130, 45);
			this.holeHeightTextBox.Name = "holeHeightTextBox";
			this.holeHeightTextBox.Size = new System.Drawing.Size(100, 20);
			this.holeHeightTextBox.TabIndex = 16;
			this.holeHeightTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChange);
			this.holeHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			// 
			// holeHeightLable
			// 
			this.holeHeightLable.AutoSize = true;
			this.holeHeightLable.Location = new System.Drawing.Point(24, 48);
			this.holeHeightLable.Name = "holeHeightLable";
			this.holeHeightLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.holeHeightLable.Size = new System.Drawing.Size(100, 13);
			this.holeHeightLable.TabIndex = 15;
			this.holeHeightLable.Text = "Высота центра Hh";
			// 
			// holeHeightBorderLable
			// 
			this.holeHeightBorderLable.AutoSize = true;
			this.holeHeightBorderLable.Location = new System.Drawing.Point(236, 48);
			this.holeHeightBorderLable.Name = "holeHeightBorderLable";
			this.holeHeightBorderLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.holeHeightBorderLable.Size = new System.Drawing.Size(193, 13);
			this.holeHeightBorderLable.TabIndex = 14;
			this.holeHeightBorderLable.Text = "[Dh/2 - Ww] -[Hg/2 - Dh/2 + Ww] , мм";
			// 
			// holeDiameterTextBox
			// 
			this.holeDiameterTextBox.Location = new System.Drawing.Point(130, 19);
			this.holeDiameterTextBox.Name = "holeDiameterTextBox";
			this.holeDiameterTextBox.Size = new System.Drawing.Size(100, 20);
			this.holeDiameterTextBox.TabIndex = 13;
			this.holeDiameterTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChange);
			this.holeDiameterTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
			// 
			// holeDiameterLable
			// 
			this.holeDiameterLable.AutoSize = true;
			this.holeDiameterLable.Location = new System.Drawing.Point(54, 22);
			this.holeDiameterLable.Name = "holeDiameterLable";
			this.holeDiameterLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.holeDiameterLable.Size = new System.Drawing.Size(70, 13);
			this.holeDiameterLable.TabIndex = 12;
			this.holeDiameterLable.Text = "Диаметр Dh";
			// 
			// buildButton
			// 
			this.buildButton.Location = new System.Drawing.Point(454, 343);
			this.buildButton.Name = "buildButton";
			this.buildButton.Size = new System.Drawing.Size(280, 60);
			this.buildButton.TabIndex = 20;
			this.buildButton.Text = "Построить";
			this.buildButton.UseVisualStyleBackColor = true;
			this.buildButton.Click += new System.EventHandler(this.BuildButton_Click);
			// 
			// ErrorLable
			// 
			this.ErrorLable.AutoSize = true;
			this.ErrorLable.Location = new System.Drawing.Point(464, 25);
			this.ErrorLable.Name = "ErrorLable";
			this.ErrorLable.Size = new System.Drawing.Size(0, 13);
			this.ErrorLable.TabIndex = 22;
			// 
			// GrillPluginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(742, 417);
			this.Controls.Add(this.ErrorLable);
			this.Controls.Add(this.buildButton);
			this.Controls.Add(this.holeGroupBox);
			this.Controls.Add(this.grooveGroupBox);
			this.Controls.Add(this.legsGroupBox);
			this.Controls.Add(this.boxGroupBox);
			this.Name = "GrillPluginForm";
			this.Text = "GrillPlugin";
			this.TextChanged += new System.EventHandler(this.TextBoxTextChange);
			this.boxGroupBox.ResumeLayout(false);
			this.boxGroupBox.PerformLayout();
			this.legsGroupBox.ResumeLayout(false);
			this.legsGroupBox.PerformLayout();
			this.grooveGroupBox.ResumeLayout(false);
			this.grooveGroupBox.PerformLayout();
			this.holeGroupBox.ResumeLayout(false);
			this.holeGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label boxLengthLable;
		private System.Windows.Forms.TextBox boxLengthTextBox;
		private System.Windows.Forms.Label boxWidthLable;
		private System.Windows.Forms.Label boxHeightLable;
		private System.Windows.Forms.Label boxWallThickness;
		private System.Windows.Forms.GroupBox boxGroupBox;
		private System.Windows.Forms.TextBox boxHeightTextBox;
		private System.Windows.Forms.TextBox boxWidthTextBox;
		private System.Windows.Forms.Label lengthBorderLable;
		private System.Windows.Forms.Label thicknessBorderLable;
		private System.Windows.Forms.Label widthBorderLable;
		private System.Windows.Forms.Label heightBorderLable;
		private System.Windows.Forms.TextBox wallThicknessTextBox;
		private System.Windows.Forms.GroupBox legsGroupBox;
		private System.Windows.Forms.Label legHeightBorderLable;
		private System.Windows.Forms.TextBox legHeightTextBox;
		private System.Windows.Forms.Label legHeightLable;
		private System.Windows.Forms.Label legDiameterBorderLable;
		private System.Windows.Forms.TextBox legDiameterTextBox;
		private System.Windows.Forms.Label legDiameterLable;
		private System.Windows.Forms.GroupBox grooveGroupBox;
		private System.Windows.Forms.Label grooveDiameterBorderLable;
		private System.Windows.Forms.TextBox grooveDistanceTextBox;
		private System.Windows.Forms.Label grooveDistanceLable;
		private System.Windows.Forms.Label grooveDistanceBorderLable;
		private System.Windows.Forms.TextBox grooveDiameterTextBox;
		private System.Windows.Forms.Label grooveDiameterLable;
		private System.Windows.Forms.GroupBox holeGroupBox;
		private System.Windows.Forms.Label holeDiameterBorderLable;
		private System.Windows.Forms.TextBox holeHeightTextBox;
		private System.Windows.Forms.Label holeHeightLable;
		private System.Windows.Forms.Label holeHeightBorderLable;
		private System.Windows.Forms.TextBox holeDiameterTextBox;
		private System.Windows.Forms.Label holeDiameterLable;
		private System.Windows.Forms.TextBox holeDistanceTextBox;
		private System.Windows.Forms.Label holeDistanceLable;
		private System.Windows.Forms.Label holeDistanceBorderLable;
		private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.Label ErrorLable;
    }
}

