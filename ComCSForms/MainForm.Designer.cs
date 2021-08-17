
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
            this.PortOpenButton = new System.Windows.Forms.Button();
            this.PortCombobox = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.FileSend = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Setbt = new System.Windows.Forms.Button();
            this.IOLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.TimeLable = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PortOpenButton
            // 
            this.PortOpenButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PortOpenButton.Location = new System.Drawing.Point(710, 6);
            this.PortOpenButton.Margin = new System.Windows.Forms.Padding(4);
            this.PortOpenButton.Name = "PortOpenButton";
            this.PortOpenButton.Size = new System.Drawing.Size(116, 35);
            this.PortOpenButton.TabIndex = 0;
            this.PortOpenButton.Text = "Открыть";
            this.PortOpenButton.UseVisualStyleBackColor = true;
            this.PortOpenButton.Click += new System.EventHandler(this.PortOpenButton_Click);
            // 
            // PortCombobox
            // 
            this.PortCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortCombobox.FormattingEnabled = true;
            this.PortCombobox.Location = new System.Drawing.Point(834, 15);
            this.PortCombobox.Margin = new System.Windows.Forms.Padding(4);
            this.PortCombobox.Name = "PortCombobox";
            this.PortCombobox.Size = new System.Drawing.Size(150, 24);
            this.PortCombobox.TabIndex = 1;
            this.PortCombobox.DropDown += new System.EventHandler(this.PortCombobox_DropDown);
            this.PortCombobox.Click += new System.EventHandler(this.PortComboBox_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(15, 502);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(526, 49);
            this.textBox3.TabIndex = 4;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(550, 488);
            this.SendButton.Margin = new System.Windows.Forms.Padding(4);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(219, 65);
            this.SendButton.TabIndex = 5;
            this.SendButton.Text = "Отправить";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // FileSend
            // 
            this.FileSend.Location = new System.Drawing.Point(776, 488);
            this.FileSend.Margin = new System.Windows.Forms.Padding(4);
            this.FileSend.Name = "FileSend";
            this.FileSend.Size = new System.Drawing.Size(102, 65);
            this.FileSend.TabIndex = 7;
            this.FileSend.Text = "Файл";
            this.FileSend.UseVisualStyleBackColor = true;
            this.FileSend.Click += new System.EventHandler(this.FileSend_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.splitContainer1);
            this.flowLayoutPanel1.Controls.Add(this.splitter1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(710, 49);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(494, 416);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(188, 0);
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 4);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 0);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1124, 474);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1022, 472);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 10;
            this.button2.Text = "Очистить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1022, 509);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 30);
            this.button3.TabIndex = 34;
            this.button3.Text = "Разделить I/O";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(886, 488);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 65);
            this.button4.TabIndex = 35;
            this.button4.Text = "Очистить IO";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Setbt
            // 
            this.Setbt.Location = new System.Drawing.Point(1178, 6);
            this.Setbt.Margin = new System.Windows.Forms.Padding(4);
            this.Setbt.Name = "Setbt";
            this.Setbt.Size = new System.Drawing.Size(40, 29);
            this.Setbt.TabIndex = 37;
            this.Setbt.Text = "Set";
            this.Setbt.UseVisualStyleBackColor = true;
            this.Setbt.Click += new System.EventHandler(this.Setbt_Click);
            // 
            // IOLayout
            // 
            this.IOLayout.Location = new System.Drawing.Point(15, 49);
            this.IOLayout.Margin = new System.Windows.Forms.Padding(4);
            this.IOLayout.Name = "IOLayout";
            this.IOLayout.Size = new System.Drawing.Size(688, 416);
            this.IOLayout.TabIndex = 38;
            // 
            // TimeLable
            // 
            this.TimeLable.AutoSize = true;
            this.TimeLable.Location = new System.Drawing.Point(546, 12);
            this.TimeLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeLable.Name = "TimeLable";
            this.TimeLable.Size = new System.Drawing.Size(44, 16);
            this.TimeLable.TabIndex = 39;
            this.TimeLable.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1230, 562);
            this.Controls.Add(this.TimeLable);
            this.Controls.Add(this.IOLayout);
            this.Controls.Add(this.Setbt);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.FileSend);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.PortCombobox);
            this.Controls.Add(this.PortOpenButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PortForm";
            this.Text = "ComPortToolkit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PortOpenButton;
        private System.Windows.Forms.ComboBox PortCombobox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button SendButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button FileSend;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Setbt;
        private System.Windows.Forms.FlowLayoutPanel IOLayout;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label TimeLable;
        private System.Windows.Forms.Timer timer1;
    }
}

