
namespace ComCSForms
{
    partial class PortForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortForm));
            this.PortOpenButton = new System.Windows.Forms.Button();
            this.PortCombobox = new System.Windows.Forms.ComboBox();
            this.MNtb = new System.Windows.Forms.TextBox();
            this.MNbt = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.FileSend = new System.Windows.Forms.Button();
            this.PLbt = new System.Windows.Forms.Button();
            this.CLbt = new System.Windows.Forms.Button();
            this.splitbt = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.IOLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.TimeLable = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SLpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Setbt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PortOpenButton
            // 
            this.PortOpenButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PortOpenButton.Location = new System.Drawing.Point(568, 5);
            this.PortOpenButton.Name = "PortOpenButton";
            this.PortOpenButton.Size = new System.Drawing.Size(93, 28);
            this.PortOpenButton.TabIndex = 0;
            this.PortOpenButton.Text = "Открыть";
            this.PortOpenButton.UseVisualStyleBackColor = true;
            this.PortOpenButton.Click += new System.EventHandler(this.PortOpenButton_Click);
            // 
            // PortCombobox
            // 
            this.PortCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortCombobox.FormattingEnabled = true;
            this.PortCombobox.Location = new System.Drawing.Point(667, 12);
            this.PortCombobox.Name = "PortCombobox";
            this.PortCombobox.Size = new System.Drawing.Size(121, 21);
            this.PortCombobox.TabIndex = 1;
            this.PortCombobox.DropDown += new System.EventHandler(this.PortCombobox_DropDown);
            this.PortCombobox.Click += new System.EventHandler(this.PortComboBox_Click);
            // 
            // MNtb
            // 
            this.MNtb.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MNtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MNtb.Location = new System.Drawing.Point(12, 402);
            this.MNtb.Multiline = true;
            this.MNtb.Name = "MNtb";
            this.MNtb.Size = new System.Drawing.Size(422, 40);
            this.MNtb.TabIndex = 4;
            this.MNtb.TextChanged += new System.EventHandler(this.MNtb_TextChanged);
            this.MNtb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SndEnt_KeyUp);
            // 
            // MNbt
            // 
            this.MNbt.Location = new System.Drawing.Point(440, 390);
            this.MNbt.Name = "MNbt";
            this.MNbt.Size = new System.Drawing.Size(175, 52);
            this.MNbt.TabIndex = 5;
            this.MNbt.Text = "Отправить";
            this.MNbt.UseVisualStyleBackColor = true;
            this.MNbt.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // FileSend
            // 
            this.FileSend.Location = new System.Drawing.Point(621, 390);
            this.FileSend.Name = "FileSend";
            this.FileSend.Size = new System.Drawing.Size(82, 52);
            this.FileSend.TabIndex = 7;
            this.FileSend.Text = "Файл";
            this.FileSend.UseVisualStyleBackColor = true;
            this.FileSend.Click += new System.EventHandler(this.FileSend_Click);
            // 
            // PLbt
            // 
            this.PLbt.Location = new System.Drawing.Point(908, 390);
            this.PLbt.Name = "PLbt";
            this.PLbt.Size = new System.Drawing.Size(64, 23);
            this.PLbt.TabIndex = 9;
            this.PLbt.Text = "+";
            this.PLbt.UseVisualStyleBackColor = true;
            this.PLbt.Click += new System.EventHandler(this.Plusbt_Click);
            // 
            // CLbt
            // 
            this.CLbt.Location = new System.Drawing.Point(829, 389);
            this.CLbt.Name = "CLbt";
            this.CLbt.Size = new System.Drawing.Size(73, 23);
            this.CLbt.TabIndex = 10;
            this.CLbt.Text = "Очистить";
            this.CLbt.UseVisualStyleBackColor = true;
            this.CLbt.Click += new System.EventHandler(this.button2_Click);
            // 
            // splitbt
            // 
            this.splitbt.Location = new System.Drawing.Point(829, 418);
            this.splitbt.Name = "splitbt";
            this.splitbt.Size = new System.Drawing.Size(145, 24);
            this.splitbt.TabIndex = 34;
            this.splitbt.Text = "Разделить I/O";
            this.splitbt.UseVisualStyleBackColor = true;
            this.splitbt.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(709, 390);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 52);
            this.button4.TabIndex = 35;
            this.button4.Text = "Очистить Прием/Отправка";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // IOLayout
            // 
            this.IOLayout.Location = new System.Drawing.Point(12, 39);
            this.IOLayout.Name = "IOLayout";
            this.IOLayout.Size = new System.Drawing.Size(550, 333);
            this.IOLayout.TabIndex = 38;
            // 
            // TimeLable
            // 
            this.TimeLable.AutoSize = true;
            this.TimeLable.Location = new System.Drawing.Point(437, 10);
            this.TimeLable.Name = "TimeLable";
            this.TimeLable.Size = new System.Drawing.Size(35, 13);
            this.TimeLable.TabIndex = 39;
            this.TimeLable.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(794, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // SLpanel
            // 
            this.SLpanel.AutoScroll = true;
            this.SLpanel.Location = new System.Drawing.Point(568, 39);
            this.SLpanel.Name = "SLpanel";
            this.SLpanel.Size = new System.Drawing.Size(406, 333);
            this.SLpanel.TabIndex = 41;
            // 
            // Setbt
            // 
            this.Setbt.Image = ((System.Drawing.Image)(resources.GetObject("Setbt.Image")));
            this.Setbt.Location = new System.Drawing.Point(938, 3);
            this.Setbt.Name = "Setbt";
            this.Setbt.Size = new System.Drawing.Size(34, 32);
            this.Setbt.TabIndex = 37;
            this.Setbt.UseVisualStyleBackColor = true;
            this.Setbt.Click += new System.EventHandler(this.Setbt_Click);
            // 
            // PortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(984, 450);
            this.Controls.Add(this.SLpanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TimeLable);
            this.Controls.Add(this.IOLayout);
            this.Controls.Add(this.Setbt);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.splitbt);
            this.Controls.Add(this.CLbt);
            this.Controls.Add(this.PLbt);
            this.Controls.Add(this.FileSend);
            this.Controls.Add(this.MNbt);
            this.Controls.Add(this.MNtb);
            this.Controls.Add(this.PortCombobox);
            this.Controls.Add(this.PortOpenButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PortForm";
            this.Text = " Ostec ComPort";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PortOpenButton;
        private System.Windows.Forms.ComboBox PortCombobox;
        private System.Windows.Forms.TextBox MNtb;
        private System.Windows.Forms.Button MNbt;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button FileSend;
        private System.Windows.Forms.Button PLbt;
        private System.Windows.Forms.Button CLbt;
        private System.Windows.Forms.Button splitbt;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FlowLayoutPanel IOLayout;
        private System.Windows.Forms.Label TimeLable;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel SLpanel;
        private System.Windows.Forms.Button Setbt;
    }
}

