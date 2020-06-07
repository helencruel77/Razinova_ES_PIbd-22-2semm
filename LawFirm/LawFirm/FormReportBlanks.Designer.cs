namespace LawFirm
{
    partial class FormReportBlanks
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
            this.ReportSkladBlankViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ButtonToPdf = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportProductBlankViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BlankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportSkladBlankViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportProductBlankViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlankBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportSkladBlankViewModelBindingSource
            // 
            this.ReportSkladBlankViewModelBindingSource.DataSource = typeof(LawFirmBusinessLogics.ViewModels.ReportSkladBlankViewModel);
            // 
            // ButtonToPdf
            // 
            this.ButtonToPdf.Location = new System.Drawing.Point(10, 11);
            this.ButtonToPdf.Name = "ButtonToPdf";
            this.ButtonToPdf.Size = new System.Drawing.Size(112, 24);
            this.ButtonToPdf.TabIndex = 10;
            this.ButtonToPdf.Text = "В PDF";
            this.ButtonToPdf.UseVisualStyleBackColor = true;
            this.ButtonToPdf.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSetBlanks";
            reportDataSource1.Value = this.BlankBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "LawFirm.ReportBlanks.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(10, 49);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(581, 307);
            this.reportViewer.TabIndex = 9;
            // 
            // ReportProductBlankViewModelBindingSource
            // 
            this.ReportProductBlankViewModelBindingSource.DataSource = typeof(LawFirmBusinessLogics.ViewModels.ReportProductBlankViewModel);
            // 
            // BlankBindingSource
            // 
            this.BlankBindingSource.DataMember = "SkladBlanks";
            this.BlankBindingSource.DataSource = typeof(LawFirmDataBaseImplement.Models.Blank);
            // 
            // FormReportBlanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.ButtonToPdf);
            this.Controls.Add(this.reportViewer);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormReportBlanks";
            this.Text = "Список бланков ";
            this.Load += new System.EventHandler(this.reportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportSkladBlankViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportProductBlankViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlankBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonToPdf;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource ReportSkladBlankViewModelBindingSource;
        private System.Windows.Forms.BindingSource ReportProductBlankViewModelBindingSource;
        private System.Windows.Forms.BindingSource BlankBindingSource;
    }
}