namespace LawFirmView
{
    partial class FormFillUpSklad
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
            this.labelSklad = new System.Windows.Forms.Label();
            this.labelBlank = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.comboBoxSklad = new System.Windows.Forms.ComboBox();
            this.comboBoxBlank = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSklad
            // 
            this.labelSklad.AutoSize = true;
            this.labelSklad.Location = new System.Drawing.Point(12, 19);
            this.labelSklad.Name = "labelSklad";
            this.labelSklad.Size = new System.Drawing.Size(41, 13);
            this.labelSklad.TabIndex = 0;
            this.labelSklad.Text = "Склад:";
            // 
            // labelBlank
            // 
            this.labelBlank.AutoSize = true;
            this.labelBlank.Location = new System.Drawing.Point(12, 59);
            this.labelBlank.Name = "labelBlank";
            this.labelBlank.Size = new System.Drawing.Size(41, 13);
            this.labelBlank.TabIndex = 1;
            this.labelBlank.Text = "Бланк:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 97);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(69, 13);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Количество:";
            // 
            // comboBoxSklad
            // 
            this.comboBoxSklad.FormattingEnabled = true;
            this.comboBoxSklad.Location = new System.Drawing.Point(83, 16);
            this.comboBoxSklad.Name = "comboBoxSklad";
            this.comboBoxSklad.Size = new System.Drawing.Size(347, 21);
            this.comboBoxSklad.TabIndex = 3;
            // 
            // comboBoxBlank
            // 
            this.comboBoxBlank.FormattingEnabled = true;
            this.comboBoxBlank.Location = new System.Drawing.Point(83, 56);
            this.comboBoxBlank.Name = "comboBoxBlank";
            this.comboBoxBlank.Size = new System.Drawing.Size(347, 21);
            this.comboBoxBlank.TabIndex = 4;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(83, 94);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(347, 20);
            this.textBoxCount.TabIndex = 6;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(246, 132);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(102, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(111, 132);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(102, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormFillUpSklad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 170);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxBlank);
            this.Controls.Add(this.comboBoxSklad);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelBlank);
            this.Controls.Add(this.labelSklad);
            this.Name = "FormFillUpSklad";
            this.Text = "Пополнить склад";
            this.Load += new System.EventHandler(this.FormSklad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSklad;
        private System.Windows.Forms.Label labelBlank;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.ComboBox comboBoxSklad;
        private System.Windows.Forms.ComboBox comboBoxBlank;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}