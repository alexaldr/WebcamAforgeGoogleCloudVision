namespace WebcamAforgeGoogleCloudVision
{
    partial class FormWebcam
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWebcam));
            this.pbWebcam = new System.Windows.Forms.PictureBox();
            this.cboCapabilities = new System.Windows.Forms.ComboBox();
            this.lblResolucao = new System.Windows.Forms.Label();
            this.lblDispositivo = new System.Windows.Forms.Label();
            this.cboDevices = new System.Windows.Forms.ComboBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAnalyse = new System.Windows.Forms.Button();
            this.gbFerramentas = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebcam)).BeginInit();
            this.SuspendLayout();
            // 
            // pbWebcam
            // 
            this.pbWebcam.BackColor = System.Drawing.Color.Gainsboro;
            this.pbWebcam.Location = new System.Drawing.Point(12, 12);
            this.pbWebcam.Name = "pbWebcam";
            this.pbWebcam.Size = new System.Drawing.Size(1280, 720);
            this.pbWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWebcam.TabIndex = 14;
            this.pbWebcam.TabStop = false;
            this.pbWebcam.Click += new System.EventHandler(this.pbWebcam_Click);
            // 
            // cboCapabilities
            // 
            this.cboCapabilities.FormattingEnabled = true;
            this.cboCapabilities.Location = new System.Drawing.Point(1387, 38);
            this.cboCapabilities.Name = "cboCapabilities";
            this.cboCapabilities.Size = new System.Drawing.Size(121, 21);
            this.cboCapabilities.TabIndex = 13;
            this.cboCapabilities.SelectedIndexChanged += new System.EventHandler(this.cbResolucao_SelectedIndexChanged);
            // 
            // lblResolucao
            // 
            this.lblResolucao.AutoSize = true;
            this.lblResolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblResolucao.Location = new System.Drawing.Point(1302, 39);
            this.lblResolucao.Name = "lblResolucao";
            this.lblResolucao.Size = new System.Drawing.Size(79, 17);
            this.lblResolucao.TabIndex = 12;
            this.lblResolucao.Text = "Resolução:";
            // 
            // lblDispositivo
            // 
            this.lblDispositivo.AutoSize = true;
            this.lblDispositivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDispositivo.Location = new System.Drawing.Point(1301, 12);
            this.lblDispositivo.Name = "lblDispositivo";
            this.lblDispositivo.Size = new System.Drawing.Size(80, 17);
            this.lblDispositivo.TabIndex = 11;
            this.lblDispositivo.Text = "Dispositivo:";
            // 
            // cboDevices
            // 
            this.cboDevices.FormattingEnabled = true;
            this.cboDevices.Location = new System.Drawing.Point(1387, 11);
            this.cboDevices.Name = "cboDevices";
            this.cboDevices.Size = new System.Drawing.Size(121, 21);
            this.cboDevices.TabIndex = 10;
            this.cboDevices.SelectedIndexChanged += new System.EventHandler(this.cbDispositivo_SelectedIndexChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Location = new System.Drawing.Point(1298, 687);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(210, 45);
            this.btnExecute.TabIndex = 21;
            this.btnExecute.Text = "Executar";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btExecutar_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnExit.Location = new System.Drawing.Point(1298, 656);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(210, 25);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Sair";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btSair_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(1298, 625);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(210, 25);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btnAnalyse
            // 
            this.btnAnalyse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAnalyse.Location = new System.Drawing.Point(1297, 594);
            this.btnAnalyse.Name = "btnAnalyse";
            this.btnAnalyse.Size = new System.Drawing.Size(211, 25);
            this.btnAnalyse.TabIndex = 18;
            this.btnAnalyse.Text = "Analisar";
            this.btnAnalyse.UseVisualStyleBackColor = true;
            this.btnAnalyse.Click += new System.EventHandler(this.btAnalisar_Click);
            // 
            // gbFerramentas
            // 
            this.gbFerramentas.Location = new System.Drawing.Point(1298, 65);
            this.gbFerramentas.Name = "gbFerramentas";
            this.gbFerramentas.Size = new System.Drawing.Size(210, 523);
            this.gbFerramentas.TabIndex = 18;
            this.gbFerramentas.TabStop = false;
            this.gbFerramentas.Text = "Opções";
            // 
            // FormWebcam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 744);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.gbFerramentas);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pbWebcam);
            this.Controls.Add(this.btnAnalyse);
            this.Controls.Add(this.cboCapabilities);
            this.Controls.Add(this.lblResolucao);
            this.Controls.Add(this.lblDispositivo);
            this.Controls.Add(this.cboDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormWebcam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebcamAforge - Google Cloud Vision API";
            this.Load += new System.EventHandler(this.FormWebcam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbWebcam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbWebcam;
        private System.Windows.Forms.ComboBox cboCapabilities;
        private System.Windows.Forms.Label lblResolucao;
        private System.Windows.Forms.Label lblDispositivo;
        private System.Windows.Forms.ComboBox cboDevices;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAnalyse;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.GroupBox gbFerramentas;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

