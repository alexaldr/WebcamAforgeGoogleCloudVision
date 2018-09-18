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
            this.btSair = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btAnalisar = new System.Windows.Forms.Button();
            this.pbWebcam = new System.Windows.Forms.PictureBox();
            this.cbResolucao = new System.Windows.Forms.ComboBox();
            this.lblResolucao = new System.Windows.Forms.Label();
            this.lblDispositivo = new System.Windows.Forms.Label();
            this.cbDispositivo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebcam)).BeginInit();
            this.SuspendLayout();
            // 
            // btSair
            // 
            this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btSair.Location = new System.Drawing.Point(381, 441);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(80, 25);
            this.btSair.TabIndex = 17;
            this.btSair.Text = "Sair";
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btSalvar.Location = new System.Drawing.Point(295, 441);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(80, 25);
            this.btSalvar.TabIndex = 16;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btAnalisar
            // 
            this.btAnalisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btAnalisar.Location = new System.Drawing.Point(209, 441);
            this.btAnalisar.Name = "btAnalisar";
            this.btAnalisar.Size = new System.Drawing.Size(80, 25);
            this.btAnalisar.TabIndex = 15;
            this.btAnalisar.Text = "Analisar";
            this.btAnalisar.UseVisualStyleBackColor = true;
            this.btAnalisar.Click += new System.EventHandler(this.btAnalisar_Click);
            // 
            // pbWebcam
            // 
            this.pbWebcam.BackColor = System.Drawing.Color.Gainsboro;
            this.pbWebcam.Location = new System.Drawing.Point(12, 35);
            this.pbWebcam.Name = "pbWebcam";
            this.pbWebcam.Size = new System.Drawing.Size(640, 400);
            this.pbWebcam.TabIndex = 14;
            this.pbWebcam.TabStop = false;
            // 
            // cbResolucao
            // 
            this.cbResolucao.FormattingEnabled = true;
            this.cbResolucao.Location = new System.Drawing.Point(480, 8);
            this.cbResolucao.Name = "cbResolucao";
            this.cbResolucao.Size = new System.Drawing.Size(172, 21);
            this.cbResolucao.TabIndex = 13;
            this.cbResolucao.SelectedIndexChanged += new System.EventHandler(this.cbResolucao_SelectedIndexChanged);
            // 
            // lblResolucao
            // 
            this.lblResolucao.AutoSize = true;
            this.lblResolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblResolucao.Location = new System.Drawing.Point(395, 9);
            this.lblResolucao.Name = "lblResolucao";
            this.lblResolucao.Size = new System.Drawing.Size(79, 17);
            this.lblResolucao.TabIndex = 12;
            this.lblResolucao.Text = "Resolução:";
            // 
            // lblDispositivo
            // 
            this.lblDispositivo.AutoSize = true;
            this.lblDispositivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDispositivo.Location = new System.Drawing.Point(12, 9);
            this.lblDispositivo.Name = "lblDispositivo";
            this.lblDispositivo.Size = new System.Drawing.Size(80, 17);
            this.lblDispositivo.TabIndex = 11;
            this.lblDispositivo.Text = "Dispositivo:";
            // 
            // cbDispositivo
            // 
            this.cbDispositivo.FormattingEnabled = true;
            this.cbDispositivo.Location = new System.Drawing.Point(98, 8);
            this.cbDispositivo.Name = "cbDispositivo";
            this.cbDispositivo.Size = new System.Drawing.Size(241, 21);
            this.cbDispositivo.TabIndex = 10;
            this.cbDispositivo.SelectedIndexChanged += new System.EventHandler(this.cbDispositivo_SelectedIndexChanged);
            // 
            // FormWebcam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 476);
            this.Controls.Add(this.btSair);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.btAnalisar);
            this.Controls.Add(this.pbWebcam);
            this.Controls.Add(this.cbResolucao);
            this.Controls.Add(this.lblResolucao);
            this.Controls.Add(this.lblDispositivo);
            this.Controls.Add(this.cbDispositivo);
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

        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btAnalisar;
        private System.Windows.Forms.PictureBox pbWebcam;
        private System.Windows.Forms.ComboBox cbResolucao;
        private System.Windows.Forms.Label lblResolucao;
        private System.Windows.Forms.Label lblDispositivo;
        private System.Windows.Forms.ComboBox cbDispositivo;
    }
}

