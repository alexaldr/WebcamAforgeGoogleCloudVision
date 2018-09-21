namespace WebcamAforgeGoogleCloudVision
{
    partial class FormAnalise
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartAnalise = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnalise)).BeginInit();
            this.SuspendLayout();
            // 
            // chartAnalise
            // 
            chartArea1.Name = "ChartArea1";
            this.chartAnalise.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartAnalise.Legends.Add(legend1);
            this.chartAnalise.Location = new System.Drawing.Point(12, 12);
            this.chartAnalise.Name = "chartAnalise";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartAnalise.Series.Add(series1);
            this.chartAnalise.Size = new System.Drawing.Size(600, 417);
            this.chartAnalise.TabIndex = 0;
            this.chartAnalise.Text = "Analise";
            // 
            // FormAnalise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.chartAnalise);
            this.Name = "FormAnalise";
            this.Text = "FormAnalise";
            ((System.ComponentModel.ISupportInitialize)(this.chartAnalise)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnalise;
    }
}