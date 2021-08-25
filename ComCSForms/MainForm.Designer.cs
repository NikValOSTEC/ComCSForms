
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
            this.SLpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Setbt = new System.Windows.Forms.Button();
            this.PortOpenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PortCombobox
            // 
            this.PortCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PortCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortCombobox.FormattingEnabled = true;
            this.PortCombobox.Location = new System.Drawing.Point(964, 7);
            this.PortCombobox.Name = "PortCombobox";
            this.PortCombobox.Size = new System.Drawing.Size(121, 21);
            this.PortCombobox.TabIndex = 1;
            this.PortCombobox.DropDown += new System.EventHandler(this.PortCombobox_DropDown);
            this.PortCombobox.Click += new System.EventHandler(this.PortComboBox_Click);
            // 
            // MNtb
            // 
            this.MNtb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MNtb.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MNtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MNtb.Location = new System.Drawing.Point(12, 633);
            this.MNtb.Multiline = true;
            this.MNtb.Name = "MNtb";
            this.MNtb.Size = new System.Drawing.Size(600, 40);
            this.MNtb.TabIndex = 4;
            this.MNtb.TextChanged += new System.EventHandler(this.MNtb_TextChanged);
            this.MNtb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SndEnt_KeyUp);
            // 
            // MNbt
            // 
            this.MNbt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MNbt.Image = ((System.Drawing.Image)(resources.GetObject("MNbt.Image")));
            this.MNbt.Location = new System.Drawing.Point(624, 617);
            this.MNbt.Name = "MNbt";
            this.MNbt.Size = new System.Drawing.Size(64, 64);
            this.MNbt.TabIndex = 5;
            this.MNbt.UseVisualStyleBackColor = true;
            this.MNbt.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // FileSend
            // 
            this.FileSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FileSend.Image = ((System.Drawing.Image)(resources.GetObject("FileSend.Image")));
            this.FileSend.Location = new System.Drawing.Point(694, 617);
            this.FileSend.Name = "FileSend";
            this.FileSend.Size = new System.Drawing.Size(32, 36);
            this.FileSend.TabIndex = 7;
            this.FileSend.UseVisualStyleBackColor = true;
            this.FileSend.Click += new System.EventHandler(this.FileSend_Click);
            // 
            // PLbt
            // 
            this.PLbt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PLbt.BackColor = System.Drawing.Color.Transparent;
            this.PLbt.Image = ((System.Drawing.Image)(resources.GetObject("PLbt.Image")));
            this.PLbt.Location = new System.Drawing.Point(1188, 622);
            this.PLbt.Name = "PLbt";
            this.PLbt.Size = new System.Drawing.Size(86, 51);
            this.PLbt.TabIndex = 9;
            this.PLbt.UseVisualStyleBackColor = false;
            this.PLbt.Click += new System.EventHandler(this.Plusbt_Click);
            // 
            // CLbt
            // 
            this.CLbt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CLbt.Location = new System.Drawing.Point(1063, 622);
            this.CLbt.Name = "CLbt";
            this.CLbt.Size = new System.Drawing.Size(119, 47);
            this.CLbt.TabIndex = 10;
            this.CLbt.Text = "Очистить";
            this.CLbt.UseVisualStyleBackColor = true;
            this.CLbt.Click += new System.EventHandler(this.button2_Click);
            // 
            // splitbt
            // 
            this.splitbt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.splitbt.Location = new System.Drawing.Point(732, 650);
            this.splitbt.Name = "splitbt";
            this.splitbt.Size = new System.Drawing.Size(164, 31);
            this.splitbt.TabIndex = 34;
            this.splitbt.Text = "Разделить Прием/Отправка";
            this.splitbt.UseVisualStyleBackColor = true;
            this.splitbt.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(732, 617);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(163, 31);
            this.button4.TabIndex = 35;
            this.button4.Text = "Очистить Прием/Отправка";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // IOLayout
            // 
            this.IOLayout.BackColor = System.Drawing.Color.Transparent;
            this.IOLayout.Location = new System.Drawing.Point(12, 39);
            this.IOLayout.Name = "IOLayout";
            this.IOLayout.Size = new System.Drawing.Size(600, 579);
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
            // SLpanel
            // 
            this.SLpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SLpanel.AutoScroll = true;
            this.SLpanel.BackColor = System.Drawing.Color.Transparent;
            this.SLpanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.SLpanel.Location = new System.Drawing.Point(601, 40);
            this.SLpanel.Name = "SLpanel";
            this.SLpanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SLpanel.Size = new System.Drawing.Size(700, 578);
            this.SLpanel.TabIndex = 41;
            this.SLpanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SLpanel_Scroll);
            // 
            // Setbt
            // 
            this.Setbt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Setbt.Image = ((System.Drawing.Image)(resources.GetObject("Setbt.Image")));
            this.Setbt.Location = new System.Drawing.Point(1240, 2);
            this.Setbt.Name = "Setbt";
            this.Setbt.Size = new System.Drawing.Size(32, 32);
            this.Setbt.TabIndex = 37;
            this.Setbt.UseVisualStyleBackColor = true;
            this.Setbt.Click += new System.EventHandler(this.Setbt_Click);
            // 
            // PortOpenButton
            // 
            this.PortOpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PortOpenButton.Image = ((System.Drawing.Image)(resources.GetObject("PortOpenButton.Image")));
            this.PortOpenButton.Location = new System.Drawing.Point(919, 0);
            this.PortOpenButton.Name = "PortOpenButton";
            this.PortOpenButton.Size = new System.Drawing.Size(39, 36);
            this.PortOpenButton.TabIndex = 42;
            this.PortOpenButton.UseVisualStyleBackColor = true;
            this.PortOpenButton.Click += new System.EventHandler(this.PortOpenButton_Click);
            // 
            // PortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1284, 681);
            this.Controls.Add(this.PortOpenButton);
            this.Controls.Add(this.FileSend);
            this.Controls.Add(this.SLpanel);
            this.Controls.Add(this.TimeLable);
            this.Controls.Add(this.IOLayout);
            this.Controls.Add(this.Setbt);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.splitbt);
            this.Controls.Add(this.CLbt);
            this.Controls.Add(this.PLbt);
            this.Controls.Add(this.MNbt);
            this.Controls.Add(this.MNtb);
            this.Controls.Add(this.PortCombobox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1046, 489);
            this.Name = "PortForm";
            this.Text = " Ostec ComPort";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.PortForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.PortForm_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.FlowLayoutPanel SLpanel;
        private System.Windows.Forms.Button Setbt;
        private System.Windows.Forms.Button PortOpenButton;
    }
}

