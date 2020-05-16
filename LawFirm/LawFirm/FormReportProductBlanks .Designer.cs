namespace LawFirm
{
    partial class FormReportProductBlanks
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ButtonToPdf = new System.Windows.Forms.Button();
            this.ReportProductBlankViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportProductBlankViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSet";
            reportDataSource1.Value = this.ReportProductBlankViewModelBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "LawFirm.Report.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(3, 50);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(634, 535);
            this.reportViewer.TabIndex = 1;
            this.reportViewer.Load += new System.EventHandler(this.reportViewer_Load);
            // 
            // ButtonToPdf
            // 
            this.ButtonToPdf.Location = new System.Drawing.Point(12, 12);
            this.ButtonToPdf.Name = "ButtonToPdf";
            this.ButtonToPdf.Size = new System.Drawing.Size(137, 23);
            this.ButtonToPdf.TabIndex = 6;
            this.ButtonToPdf.Text = "в pdf";
            this.ButtonToPdf.UseVisualStyleBackColor = true;
            this.ButtonToPdf.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // ReportProductBlankViewModelBindingSource
            // 
            this.ReportProductBlankViewModelBindingSource.DataSource = typeof(LawFirmLogic.ViewModels.ReportProductBlankViewModel);
            // 
            // FormReportProductBlanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 588);
            this.Controls.Add(this.ButtonToPdf);
            this.Controls.Add(this.reportViewer);
            this.Name = "FormReportProductBlanks";
            this.Text = "Бланки и пакеты документов";
            ((System.ComponentModel.ISupportInitialize)(this.ReportProductBlankViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Button ButtonToPdf;
        private System.Windows.Forms.BindingSource ReportProductBlankViewModelBindingSource;
    }
}