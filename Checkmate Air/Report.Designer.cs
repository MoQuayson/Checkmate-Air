namespace Checkmate_Air
{
    partial class Report
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisplay2 = new System.Windows.Forms.TextBox();
            this.tblDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new Checkmate_Air.DataSet1();
            this.tblDetailsTableAdapter = new Checkmate_Air.DataSet1TableAdapters.tblDetailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tblDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tblDetailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Checkmate_Air.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(4, 58);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(938, 456);
            this.reportViewer1.TabIndex = 0;
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(13, 25);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.Size = new System.Drawing.Size(147, 20);
            this.txtDisplay.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Telephone";
            // 
            // txtDisplay2
            // 
            this.txtDisplay2.Location = new System.Drawing.Point(210, 25);
            this.txtDisplay2.Name = "txtDisplay2";
            this.txtDisplay2.ReadOnly = true;
            this.txtDisplay2.Size = new System.Drawing.Size(147, 20);
            this.txtDisplay2.TabIndex = 3;
            // 
            // tblDetailsBindingSource
            // 
            this.tblDetailsBindingSource.DataMember = "tblDetails";
            this.tblDetailsBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblDetailsTableAdapter
            // 
            this.tblDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 514);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDisplay2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblDetailsBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.tblDetailsTableAdapter tblDetailsTableAdapter;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDisplay2;
    }
}