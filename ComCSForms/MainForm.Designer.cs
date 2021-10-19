
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.FileSend = new System.Windows.Forms.Button();
            this.PLbt = new System.Windows.Forms.Button();
            this.CLbt = new System.Windows.Forms.Button();
            this.splitbt = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.TimeLable = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.FlowLP = new System.Windows.Forms.FlowLayoutPanel();
            this.Setbt = new System.Windows.Forms.Button();
            this.PortOpenButton = new System.Windows.Forms.Button();
            this.pictureBoxPortStateStop = new System.Windows.Forms.PictureBox();
            this.pictureBoxPortStateOpen = new System.Windows.Forms.PictureBox();
            this.MNbt = new System.Windows.Forms.Button();
            this.Portlabel = new System.Windows.Forms.Label();
            this.IOGroup = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPortStateStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPortStateOpen)).BeginInit();
            this.SuspendLayout();
            // 
            // PortCombobox
            // 
            this.PortCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PortCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortCombobox.FormattingEnabled = true;
            this.PortCombobox.Location = new System.Drawing.Point(900, 7);
            this.PortCombobox.Name = "PortCombobox";
            this.PortCombobox.Size = new System.Drawing.Size(121, 21);
            this.PortCombobox.TabIndex = 1;
            this.PortCombobox.DropDown += new System.EventHandler(this.PortCombobox_DropDown);
            this.PortCombobox.SelectedIndexChanged += new System.EventHandler(this.PortCombobox_SelectedIndexChanged);
            this.PortCombobox.Click += new System.EventHandler(this.PortComboBox_Click);
            // 
            // MNtb
            // 
            this.MNtb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MNtb.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MNtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MNtb.Location = new System.Drawing.Point(12, 653);
            this.MNtb.Name = "MNtb";
            this.MNtb.Size = new System.Drawing.Size(600, 20);
            this.MNtb.TabIndex = 4;
            this.MNtb.TextChanged += new System.EventHandler(this.MNtb_TextChanged);
            this.MNtb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SndEnt_KeyUp);
            // 
            // FileSend
            // 
            this.FileSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FileSend.FlatAppearance.BorderSize = 0;
            this.FileSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileSend.Image = ((System.Drawing.Image)(resources.GetObject("FileSend.Image")));
            this.FileSend.Location = new System.Drawing.Point(669, 643);
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
            this.PLbt.FlatAppearance.BorderSize = 0;
            this.PLbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PLbt.Image = ((System.Drawing.Image)(resources.GetObject("PLbt.Image")));
            this.PLbt.Location = new System.Drawing.Point(1212, 630);
            this.PLbt.Name = "PLbt";
            this.PLbt.Size = new System.Drawing.Size(69, 51);
            this.PLbt.TabIndex = 9;
            this.PLbt.UseVisualStyleBackColor = false;
            this.PLbt.Click += new System.EventHandler(this.Plusbt_Click);
            // 
            // CLbt
            // 
            this.CLbt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CLbt.FlatAppearance.BorderSize = 2;
            this.CLbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLbt.Location = new System.Drawing.Point(1087, 645);
            this.CLbt.Name = "CLbt";
            this.CLbt.Size = new System.Drawing.Size(119, 26);
            this.CLbt.TabIndex = 10;
            this.CLbt.Text = "Очистить";
            this.CLbt.UseVisualStyleBackColor = true;
            this.CLbt.Click += new System.EventHandler(this.button2_Click);
            // 
            // splitbt
            // 
            this.splitbt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.splitbt.FlatAppearance.BorderSize = 2;
            this.splitbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.splitbt.Location = new System.Drawing.Point(716, 643);
            this.splitbt.Name = "splitbt";
            this.splitbt.Size = new System.Drawing.Size(164, 26);
            this.splitbt.TabIndex = 34;
            this.splitbt.Text = "Разделить I/O";
            this.splitbt.UseVisualStyleBackColor = true;
            this.splitbt.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(886, 643);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(164, 26);
            this.button4.TabIndex = 35;
            this.button4.Text = "Очистить I/O";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // TimeLable
            // 
            this.TimeLable.AutoSize = true;
            this.TimeLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TimeLable.Location = new System.Drawing.Point(9, 7);
            this.TimeLable.Name = "TimeLable";
            this.TimeLable.Size = new System.Drawing.Size(51, 20);
            this.TimeLable.TabIndex = 39;
            this.TimeLable.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FlowLP
            // 
            this.FlowLP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlowLP.AutoScroll = true;
            this.FlowLP.BackColor = System.Drawing.Color.Transparent;
            this.FlowLP.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLP.Location = new System.Drawing.Point(981, 39);
            this.FlowLP.Name = "FlowLP";
            this.FlowLP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FlowLP.Size = new System.Drawing.Size(291, 578);
            this.FlowLP.TabIndex = 41;
            this.FlowLP.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SLpanel_Scroll);
            // 
            // Setbt
            // 
            this.Setbt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Setbt.FlatAppearance.BorderSize = 0;
            this.Setbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.PortOpenButton.FlatAppearance.BorderSize = 0;
            this.PortOpenButton.Location = new System.Drawing.Point(1027, 0);
            this.PortOpenButton.Name = "PortOpenButton";
            this.PortOpenButton.Size = new System.Drawing.Size(78, 34);
            this.PortOpenButton.TabIndex = 42;
            this.PortOpenButton.Text = "Открыть";
            this.PortOpenButton.UseVisualStyleBackColor = true;
            this.PortOpenButton.Click += new System.EventHandler(this.PortOpenButton_Click);
            // 
            // pictureBoxPortStateStop
            // 
            this.pictureBoxPortStateStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPortStateStop.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPortStateStop.Image")));
            this.pictureBoxPortStateStop.Location = new System.Drawing.Point(1111, 0);
            this.pictureBoxPortStateStop.Name = "pictureBoxPortStateStop";
            this.pictureBoxPortStateStop.Size = new System.Drawing.Size(33, 34);
            this.pictureBoxPortStateStop.TabIndex = 43;
            this.pictureBoxPortStateStop.TabStop = false;
            // 
            // pictureBoxPortStateOpen
            // 
            this.pictureBoxPortStateOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPortStateOpen.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPortStateOpen.Image")));
            this.pictureBoxPortStateOpen.Location = new System.Drawing.Point(1111, 0);
            this.pictureBoxPortStateOpen.Name = "pictureBoxPortStateOpen";
            this.pictureBoxPortStateOpen.Size = new System.Drawing.Size(33, 34);
            this.pictureBoxPortStateOpen.TabIndex = 44;
            this.pictureBoxPortStateOpen.TabStop = false;
            // 
            // MNbt
            // 
            this.MNbt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MNbt.FlatAppearance.BorderSize = 0;
            this.MNbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MNbt.Image = ((System.Drawing.Image)(resources.GetObject("MNbt.Image")));
            this.MNbt.Location = new System.Drawing.Point(618, 643);
            this.MNbt.Name = "MNbt";
            this.MNbt.Size = new System.Drawing.Size(45, 36);
            this.MNbt.TabIndex = 45;
            this.MNbt.UseVisualStyleBackColor = true;
            this.MNbt.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // Portlabel
            // 
            this.Portlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Portlabel.AutoSize = true;
            this.Portlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Portlabel.Location = new System.Drawing.Point(744, 3);
            this.Portlabel.Name = "Portlabel";
            this.Portlabel.Size = new System.Drawing.Size(150, 31);
            this.Portlabel.TabIndex = 46;
            this.Portlabel.Text = "COM-port:";
            // 
            // IOGroup
            // 
            this.IOGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IOGroup.Location = new System.Drawing.Point(13, 39);
            this.IOGroup.Name = "IOGroup";
            this.IOGroup.Size = new System.Drawing.Size(962, 578);
            this.IOGroup.TabIndex = 47;
            this.IOGroup.TabStop = false;
            // 
            // PortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1284, 681);
            this.Controls.Add(this.IOGroup);
            this.Controls.Add(this.Portlabel);
            this.Controls.Add(this.MNbt);
            this.Controls.Add(this.PortOpenButton);
            this.Controls.Add(this.FileSend);
            this.Controls.Add(this.FlowLP);
            this.Controls.Add(this.TimeLable);
            this.Controls.Add(this.Setbt);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.splitbt);
            this.Controls.Add(this.CLbt);
            this.Controls.Add(this.PLbt);
            this.Controls.Add(this.MNtb);
            this.Controls.Add(this.PortCombobox);
            this.Controls.Add(this.pictureBoxPortStateStop);
            this.Controls.Add(this.pictureBoxPortStateOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1055, 489);
            this.Name = "PortForm";
            this.Text = " Ostec ComPort";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPortStateStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPortStateOpen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox PortCombobox;
        private System.Windows.Forms.TextBox MNtb;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button FileSend;
        private System.Windows.Forms.Button PLbt;
        private System.Windows.Forms.Button CLbt;
        private System.Windows.Forms.Button splitbt;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label TimeLable;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel FlowLP;
        private System.Windows.Forms.Button Setbt;
        private System.Windows.Forms.Button PortOpenButton;
        private System.Windows.Forms.PictureBox pictureBoxPortStateStop;
        private System.Windows.Forms.PictureBox pictureBoxPortStateOpen;
        private System.Windows.Forms.Button MNbt;
        private System.Windows.Forms.Label Portlabel;
        private System.Windows.Forms.GroupBox IOGroup;
    }
}

