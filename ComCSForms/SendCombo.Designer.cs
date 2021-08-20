
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
            this.SuspendLayout();
            // 
            // SCtb
            // 
            this.SCtb.Location = new System.Drawing.Point(3, 10);
            this.SCtb.Name = "SCtb";
            this.SCtb.Size = new System.Drawing.Size(247, 20);
            this.SCtb.TabIndex = 0;
            // 
            // SCbt
            // 
            this.SCbt.Location = new System.Drawing.Point(256, 1);
            this.SCbt.Name = "SCbt";
            this.SCbt.Size = new System.Drawing.Size(75, 36);
            this.SCbt.TabIndex = 1;
            this.SCbt.Text = "Отправить";
            this.SCbt.UseVisualStyleBackColor = true;
            // 
            // SCbm
            // 
            this.SCbm.Image = ((System.Drawing.Image)(resources.GetObject("SCbm.Image")));
            this.SCbm.Location = new System.Drawing.Point(337, 1);
            this.SCbm.Name = "SCbm";
            this.SCbm.Size = new System.Drawing.Size(28, 36);
            this.SCbm.TabIndex = 2;
            this.SCbm.Text = "-";
            this.SCbm.UseVisualStyleBackColor = true;
            // 
            // SendCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.SCbm);
            this.Controls.Add(this.SCbt);
            this.Controls.Add(this.SCtb);
            this.Name = "SendCombo";
            this.Size = new System.Drawing.Size(368, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SCtb;
        private System.Windows.Forms.Button SCbt;
        private System.Windows.Forms.Button SCbm;
    }
}
