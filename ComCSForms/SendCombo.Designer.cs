
namespace ComCSForms
{
    partial class SendCombo
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendCombo));
            this.SCtb = new System.Windows.Forms.TextBox();
            this.SCbt = new System.Windows.Forms.Button();
            this.SCbm = new System.Windows.Forms.Button();
            this.SCbtS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SCtb
            // 
            this.SCtb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SCtb.Location = new System.Drawing.Point(3, 10);
            this.SCtb.Name = "SCtb";
            this.SCtb.Size = new System.Drawing.Size(275, 20);
            this.SCtb.TabIndex = 0;
            this.SCtb.SizeChanged += new System.EventHandler(this.SCtb_SizeChanged);
            // 
            // SCbt
            // 
            this.SCbt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SCbt.FlatAppearance.BorderSize = 0;
            this.SCbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SCbt.Image = ((System.Drawing.Image)(resources.GetObject("SCbt.Image")));
            this.SCbt.Location = new System.Drawing.Point(364, 1);
            this.SCbt.Name = "SCbt";
            this.SCbt.Size = new System.Drawing.Size(47, 146);
            this.SCbt.TabIndex = 1;
            this.SCbt.UseVisualStyleBackColor = true;
            // 
            // SCbm
            // 
            this.SCbm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SCbm.FlatAppearance.BorderSize = 0;
            this.SCbm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SCbm.Image = ((System.Drawing.Image)(resources.GetObject("SCbm.Image")));
            this.SCbm.Location = new System.Drawing.Point(417, 0);
            this.SCbm.Name = "SCbm";
            this.SCbm.Size = new System.Drawing.Size(28, 146);
            this.SCbm.TabIndex = 2;
            this.SCbm.Text = "-";
            this.SCbm.UseVisualStyleBackColor = true;
            // 
            // SCbtS
            // 
            this.SCbtS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SCbtS.FlatAppearance.BorderSize = 0;
            this.SCbtS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SCbtS.Image = ((System.Drawing.Image)(resources.GetObject("SCbtS.Image")));
            this.SCbtS.Location = new System.Drawing.Point(375, 0);
            this.SCbtS.Name = "SCbtS";
            this.SCbtS.Size = new System.Drawing.Size(36, 144);
            this.SCbtS.TabIndex = 3;
            this.SCbtS.UseVisualStyleBackColor = true;
            // 
            // SendCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.SCtb);
            this.Controls.Add(this.SCbm);
            this.Controls.Add(this.SCbt);
            this.Controls.Add(this.SCbtS);
            this.Name = "SendCombo";
            this.Size = new System.Drawing.Size(448, 150);
            this.Load += new System.EventHandler(this.SendCombo_Load);
            this.SizeChanged += new System.EventHandler(this.SCtb_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox SCtb;
        public System.Windows.Forms.Button SCbt;
        public System.Windows.Forms.Button SCbm;
        private System.Windows.Forms.Button SCbtS;
    }
}
