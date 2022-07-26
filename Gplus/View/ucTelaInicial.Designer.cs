namespace Gplus.View
{
    partial class ucTelaInicial
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTelaInicial));
            this.pboxBackground = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxBackground
            // 
            this.pboxBackground.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pboxBackground.BackgroundImage")));
            this.pboxBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pboxBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxBackground.FillColor = System.Drawing.Color.Transparent;
            this.pboxBackground.ImageRotate = 0F;
            this.pboxBackground.Location = new System.Drawing.Point(0, 0);
            this.pboxBackground.Name = "pboxBackground";
            this.pboxBackground.Size = new System.Drawing.Size(1280, 720);
            this.pboxBackground.TabIndex = 0;
            this.pboxBackground.TabStop = false;
            // 
            // ucTelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pboxBackground);
            this.Name = "ucTelaInicial";
            this.Size = new System.Drawing.Size(1280, 720);
            ((System.ComponentModel.ISupportInitialize)(this.pboxBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pboxBackground;
    }
}
