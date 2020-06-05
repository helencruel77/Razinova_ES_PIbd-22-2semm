namespace LawFirm
{
    partial class FormReportSkladBlanks
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
            this.ButtonSaveToExcel = new System.Windows.Forms.Button();
            this.Sklad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonSaveToExcel
            // 
            this.ButtonSaveToExcel.Location = new System.Drawing.Point(9, 9);
            this.ButtonSaveToExcel.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonSaveToExcel.Name = "ButtonSaveToExcel";
            this.ButtonSaveToExcel.Size = new System.Drawing.Size(113, 23);
            this.ButtonSaveToExcel.TabIndex = 5;
            this.ButtonSaveToExcel.Text = "Сохранить в Exсel";
            this.ButtonSaveToExcel.UseVisualStyleBackColor = true;
            this.ButtonSaveToExcel.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
            // 
            // Sklad
            // 
            this.Sklad.HeaderText = "Склад";
            this.Sklad.MinimumWidth = 6;
            this.Sklad.Name = "Sklad";
            this.Sklad.Width = 150;
            // 
            // BlankName
            // 
            this.BlankName.HeaderText = "Бланк";
            this.BlankName.MinimumWidth = 6;
            this.BlankName.Name = "BlankName";
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество";
            this.Count.MinimumWidth = 6;
            this.Count.Name = "Count";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sklad,
            this.BlankName,
            this.Count});
            this.dataGridView1.Location = new System.Drawing.Point(12, 36);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(407, 319);
            this.dataGridView1.TabIndex = 4;
            // 
            // FormReportSkladBlanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 366);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ButtonSaveToExcel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormReportSkladBlanks";
            this.Text = "Бланки по складам";
            this.Load += new System.EventHandler(this.FormReportSkladBlanks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonSaveToExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sklad;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}