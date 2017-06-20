namespace Hall_Effect
{
    partial class MainForm
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
            this.constTempButton = new System.Windows.Forms.Button();
            this.varTempButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // constTempButton
            // 
            this.constTempButton.BackColor = System.Drawing.SystemColors.Control;
            this.constTempButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.constTempButton.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.constTempButton.Location = new System.Drawing.Point(12, 46);
            this.constTempButton.Name = "constTempButton";
            this.constTempButton.Size = new System.Drawing.Size(189, 124);
            this.constTempButton.TabIndex = 0;
            this.constTempButton.Text = "измерение подвижности и концентрации носителей заряда";
            this.constTempButton.UseVisualStyleBackColor = false;
            this.constTempButton.Click += new System.EventHandler(this.constTempButton_Click);
            // 
            // varTempButton
            // 
            this.varTempButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.varTempButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.varTempButton.Location = new System.Drawing.Point(207, 46);
            this.varTempButton.Name = "varTempButton";
            this.varTempButton.Size = new System.Drawing.Size(182, 124);
            this.varTempButton.TabIndex = 1;
            this.varTempButton.Text = "измерение ширины запрещенной зоны";
            this.varTempButton.UseVisualStyleBackColor = true;
            this.varTempButton.Click += new System.EventHandler(this.varTempButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите сценарий";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(400, 182);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.varTempButton);
            this.Controls.Add(this.constTempButton);
            this.Name = "MainForm";
            this.Text = "Выбор метода";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button constTempButton;
        private System.Windows.Forms.Button varTempButton;
        private System.Windows.Forms.Label label1;
    }
}

