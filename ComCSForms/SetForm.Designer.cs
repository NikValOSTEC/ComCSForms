﻿
namespace ComCSForms
{
    partial class SetForm
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
            this.BaudCombobox = new System.Windows.Forms.ComboBox();
            this.Baudlable = new System.Windows.Forms.Label();
            this.DataLable = new System.Windows.Forms.Label();
            this.DatacomboBox = new System.Windows.Forms.ComboBox();
            this.Flowlabel = new System.Windows.Forms.Label();
            this.FlowcomboBox = new System.Windows.Forms.ComboBox();
            this.Stopstrlabel = new System.Windows.Forms.Label();
            this.StopstrcomboBox = new System.Windows.Forms.ComboBox();
            this.Paritylabel = new System.Windows.Forms.Label();
            this.ParitycomboBox = new System.Windows.Forms.ComboBox();
            this.Stopbitlabel = new System.Windows.Forms.Label();
            this.StopbitcomboBox = new System.Windows.Forms.ComboBox();
            this.decods = new System.Windows.Forms.GroupBox();
            this.BINcheck = new System.Windows.Forms.CheckBox();
            this.HEXCheck = new System.Windows.Forms.CheckBox();
            this.ASCIIcheck = new System.Windows.Forms.CheckBox();
            this.Circle = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Ntimeslabel = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.SendStopCheck = new System.Windows.Forms.CheckBox();
            this.Ciclecheck = new System.Windows.Forms.CheckBox();
            this.decods.SuspendLayout();
            this.Circle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // BaudCombobox
            // 
            this.BaudCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudCombobox.FormattingEnabled = true;
            this.BaudCombobox.Location = new System.Drawing.Point(13, 30);
            this.BaudCombobox.Name = "BaudCombobox";
            this.BaudCombobox.Size = new System.Drawing.Size(84, 21);
            this.BaudCombobox.TabIndex = 0;
            // 
            // Baudlable
            // 
            this.Baudlable.AutoSize = true;
            this.Baudlable.Location = new System.Drawing.Point(12, 9);
            this.Baudlable.Name = "Baudlable";
            this.Baudlable.Size = new System.Drawing.Size(49, 13);
            this.Baudlable.TabIndex = 1;
            this.Baudlable.Text = "Сорость";
            // 
            // DataLable
            // 
            this.DataLable.AutoSize = true;
            this.DataLable.Location = new System.Drawing.Point(102, 9);
            this.DataLable.Name = "DataLable";
            this.DataLable.Size = new System.Drawing.Size(48, 13);
            this.DataLable.TabIndex = 3;
            this.DataLable.Text = "Данные";
            // 
            // DatacomboBox
            // 
            this.DatacomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DatacomboBox.FormattingEnabled = true;
            this.DatacomboBox.Location = new System.Drawing.Point(103, 30);
            this.DatacomboBox.Name = "DatacomboBox";
            this.DatacomboBox.Size = new System.Drawing.Size(84, 21);
            this.DatacomboBox.TabIndex = 2;
            // 
            // Flowlabel
            // 
            this.Flowlabel.AutoSize = true;
            this.Flowlabel.Location = new System.Drawing.Point(192, 9);
            this.Flowlabel.Name = "Flowlabel";
            this.Flowlabel.Size = new System.Drawing.Size(38, 13);
            this.Flowlabel.TabIndex = 5;
            this.Flowlabel.Text = "Поток";
            // 
            // FlowcomboBox
            // 
            this.FlowcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlowcomboBox.FormattingEnabled = true;
            this.FlowcomboBox.Location = new System.Drawing.Point(193, 30);
            this.FlowcomboBox.Name = "FlowcomboBox";
            this.FlowcomboBox.Size = new System.Drawing.Size(84, 21);
            this.FlowcomboBox.TabIndex = 4;
            // 
            // Stopstrlabel
            // 
            this.Stopstrlabel.AutoSize = true;
            this.Stopstrlabel.Location = new System.Drawing.Point(194, 65);
            this.Stopstrlabel.Name = "Stopstrlabel";
            this.Stopstrlabel.Size = new System.Drawing.Size(66, 13);
            this.Stopstrlabel.TabIndex = 11;
            this.Stopstrlabel.Text = "Стопстрока";
            // 
            // StopstrcomboBox
            // 
            this.StopstrcomboBox.FormattingEnabled = true;
            this.StopstrcomboBox.Location = new System.Drawing.Point(195, 86);
            this.StopstrcomboBox.Name = "StopstrcomboBox";
            this.StopstrcomboBox.Size = new System.Drawing.Size(84, 21);
            this.StopstrcomboBox.TabIndex = 10;
            // 
            // Paritylabel
            // 
            this.Paritylabel.AutoSize = true;
            this.Paritylabel.Location = new System.Drawing.Point(104, 65);
            this.Paritylabel.Name = "Paritylabel";
            this.Paritylabel.Size = new System.Drawing.Size(49, 13);
            this.Paritylabel.TabIndex = 9;
            this.Paritylabel.Text = "Паритет";
            // 
            // ParitycomboBox
            // 
            this.ParitycomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParitycomboBox.FormattingEnabled = true;
            this.ParitycomboBox.Location = new System.Drawing.Point(105, 86);
            this.ParitycomboBox.Name = "ParitycomboBox";
            this.ParitycomboBox.Size = new System.Drawing.Size(84, 21);
            this.ParitycomboBox.TabIndex = 8;
            // 
            // Stopbitlabel
            // 
            this.Stopbitlabel.AutoSize = true;
            this.Stopbitlabel.Location = new System.Drawing.Point(14, 65);
            this.Stopbitlabel.Name = "Stopbitlabel";
            this.Stopbitlabel.Size = new System.Drawing.Size(48, 13);
            this.Stopbitlabel.TabIndex = 7;
            this.Stopbitlabel.Text = "Стопбит";
            // 
            // StopbitcomboBox
            // 
            this.StopbitcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StopbitcomboBox.FormattingEnabled = true;
            this.StopbitcomboBox.Location = new System.Drawing.Point(15, 86);
            this.StopbitcomboBox.Name = "StopbitcomboBox";
            this.StopbitcomboBox.Size = new System.Drawing.Size(84, 21);
            this.StopbitcomboBox.TabIndex = 6;
            // 
            // decods
            // 
            this.decods.Controls.Add(this.BINcheck);
            this.decods.Controls.Add(this.HEXCheck);
            this.decods.Controls.Add(this.ASCIIcheck);
            this.decods.Location = new System.Drawing.Point(0, 128);
            this.decods.Name = "decods";
            this.decods.Size = new System.Drawing.Size(200, 100);
            this.decods.TabIndex = 12;
            this.decods.TabStop = false;
            this.decods.Text = "Форматы";
            // 
            // BINcheck
            // 
            this.BINcheck.AutoSize = true;
            this.BINcheck.Location = new System.Drawing.Point(7, 68);
            this.BINcheck.Name = "BINcheck";
            this.BINcheck.Size = new System.Drawing.Size(44, 17);
            this.BINcheck.TabIndex = 2;
            this.BINcheck.Text = "BIN";
            this.BINcheck.UseVisualStyleBackColor = true;
            // 
            // HEXCheck
            // 
            this.HEXCheck.AutoSize = true;
            this.HEXCheck.Location = new System.Drawing.Point(7, 44);
            this.HEXCheck.Name = "HEXCheck";
            this.HEXCheck.Size = new System.Drawing.Size(48, 17);
            this.HEXCheck.TabIndex = 1;
            this.HEXCheck.Text = "HEX";
            this.HEXCheck.UseVisualStyleBackColor = true;
            // 
            // ASCIIcheck
            // 
            this.ASCIIcheck.AutoSize = true;
            this.ASCIIcheck.Location = new System.Drawing.Point(7, 20);
            this.ASCIIcheck.Name = "ASCIIcheck";
            this.ASCIIcheck.Size = new System.Drawing.Size(53, 17);
            this.ASCIIcheck.TabIndex = 0;
            this.ASCIIcheck.Text = "ASCII";
            this.ASCIIcheck.UseVisualStyleBackColor = true;
            // 
            // Circle
            // 
            this.Circle.Controls.Add(this.textBox1);
            this.Circle.Controls.Add(this.label1);
            this.Circle.Controls.Add(this.Ntimeslabel);
            this.Circle.Controls.Add(this.numericUpDown2);
            this.Circle.Controls.Add(this.numericUpDown1);
            this.Circle.Controls.Add(this.SendStopCheck);
            this.Circle.Controls.Add(this.Ciclecheck);
            this.Circle.Location = new System.Drawing.Point(0, 274);
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(279, 165);
            this.Circle.TabIndex = 13;
            this.Circle.TabStop = false;
            this.Circle.Text = "Циклическая отправка";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Раз";
            // 
            // Ntimeslabel
            // 
            this.Ntimeslabel.AutoSize = true;
            this.Ntimeslabel.Location = new System.Drawing.Point(238, 21);
            this.Ntimeslabel.Name = "Ntimeslabel";
            this.Ntimeslabel.Size = new System.Drawing.Size(21, 13);
            this.Ntimeslabel.TabIndex = 4;
            this.Ntimeslabel.Text = "мс";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(107, 43);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(107, 17);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // SendStopCheck
            // 
            this.SendStopCheck.AutoSize = true;
            this.SendStopCheck.Location = new System.Drawing.Point(7, 96);
            this.SendStopCheck.Name = "SendStopCheck";
            this.SendStopCheck.Size = new System.Drawing.Size(105, 17);
            this.SendStopCheck.TabIndex = 1;
            this.SendStopCheck.Text = "Остановка при:";
            this.SendStopCheck.UseVisualStyleBackColor = true;
            // 
            // Ciclecheck
            // 
            this.Ciclecheck.AutoSize = true;
            this.Ciclecheck.Location = new System.Drawing.Point(7, 20);
            this.Ciclecheck.Name = "Ciclecheck";
            this.Ciclecheck.Size = new System.Drawing.Size(93, 17);
            this.Ciclecheck.TabIndex = 0;
            this.Ciclecheck.Text = "Циклическая";
            this.Ciclecheck.UseVisualStyleBackColor = true;
            // 
            // SetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 481);
            this.Controls.Add(this.Circle);
            this.Controls.Add(this.decods);
            this.Controls.Add(this.Stopstrlabel);
            this.Controls.Add(this.StopstrcomboBox);
            this.Controls.Add(this.Paritylabel);
            this.Controls.Add(this.ParitycomboBox);
            this.Controls.Add(this.Stopbitlabel);
            this.Controls.Add(this.StopbitcomboBox);
            this.Controls.Add(this.Flowlabel);
            this.Controls.Add(this.FlowcomboBox);
            this.Controls.Add(this.DataLable);
            this.Controls.Add(this.DatacomboBox);
            this.Controls.Add(this.Baudlable);
            this.Controls.Add(this.BaudCombobox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SetForm";
            this.Text = "                                                                  ";
            this.Load += new System.EventHandler(this.SetForm_Load);
            this.decods.ResumeLayout(false);
            this.decods.PerformLayout();
            this.Circle.ResumeLayout(false);
            this.Circle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BaudCombobox;
        private System.Windows.Forms.Label Baudlable;
        private System.Windows.Forms.Label DataLable;
        private System.Windows.Forms.ComboBox DatacomboBox;
        private System.Windows.Forms.Label Flowlabel;
        private System.Windows.Forms.ComboBox FlowcomboBox;
        private System.Windows.Forms.Label Stopstrlabel;
        private System.Windows.Forms.ComboBox StopstrcomboBox;
        private System.Windows.Forms.Label Paritylabel;
        private System.Windows.Forms.ComboBox ParitycomboBox;
        private System.Windows.Forms.Label Stopbitlabel;
        private System.Windows.Forms.ComboBox StopbitcomboBox;
        private System.Windows.Forms.GroupBox decods;
        private System.Windows.Forms.CheckBox BINcheck;
        private System.Windows.Forms.CheckBox HEXCheck;
        private System.Windows.Forms.CheckBox ASCIIcheck;
        private System.Windows.Forms.GroupBox Circle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Ntimeslabel;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox SendStopCheck;
        private System.Windows.Forms.CheckBox Ciclecheck;
        private System.Windows.Forms.TextBox textBox1;
    }
}