namespace WindowsForm
{
    partial class FrmChicle
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
            btnCancelar = new Button();
            txtDuracionDeSabor = new TextBox();
            lblDuracionDeSabor = new Label();
            txtElasticidad = new TextBox();
            lblElasticidad = new Label();
            txtPopularidad = new TextBox();
            lblPopularidad = new Label();
            txtMarca = new TextBox();
            lblMarca = new Label();
            txtPrecio = new TextBox();
            lblPrecio = new Label();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(205, 206);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(128, 28);
            btnCancelar.TabIndex = 23;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtDuracionDeSabor
            // 
            txtDuracionDeSabor.Location = new Point(205, 129);
            txtDuracionDeSabor.Name = "txtDuracionDeSabor";
            txtDuracionDeSabor.Size = new Size(128, 23);
            txtDuracionDeSabor.TabIndex = 22;
            // 
            // lblDuracionDeSabor
            // 
            lblDuracionDeSabor.AutoSize = true;
            lblDuracionDeSabor.Location = new Point(205, 111);
            lblDuracionDeSabor.Name = "lblDuracionDeSabor";
            lblDuracionDeSabor.Size = new Size(106, 15);
            lblDuracionDeSabor.TabIndex = 21;
            lblDuracionDeSabor.Text = "Duracion de sabor:";
            // 
            // txtElasticidad
            // 
            txtElasticidad.Location = new Point(205, 69);
            txtElasticidad.Name = "txtElasticidad";
            txtElasticidad.Size = new Size(128, 23);
            txtElasticidad.TabIndex = 20;
            // 
            // lblElasticidad
            // 
            lblElasticidad.AutoSize = true;
            lblElasticidad.Location = new Point(205, 51);
            lblElasticidad.Name = "lblElasticidad";
            lblElasticidad.Size = new Size(66, 15);
            lblElasticidad.TabIndex = 19;
            lblElasticidad.Text = "Elasticidad:";
            // 
            // txtPopularidad
            // 
            txtPopularidad.Location = new Point(43, 147);
            txtPopularidad.Name = "txtPopularidad";
            txtPopularidad.Size = new Size(128, 23);
            txtPopularidad.TabIndex = 18;
            // 
            // lblPopularidad
            // 
            lblPopularidad.AutoSize = true;
            lblPopularidad.Location = new Point(43, 129);
            lblPopularidad.Name = "lblPopularidad";
            lblPopularidad.Size = new Size(74, 15);
            lblPopularidad.TabIndex = 17;
            lblPopularidad.Text = "Popularidad:";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(43, 95);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(128, 23);
            txtMarca.TabIndex = 16;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(43, 77);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(43, 15);
            lblMarca.TabIndex = 15;
            lblMarca.Text = "Marca:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(43, 44);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(128, 23);
            txtPrecio.TabIndex = 14;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(43, 26);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(43, 15);
            lblPrecio.TabIndex = 13;
            lblPrecio.Text = "Precio:";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(43, 206);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(128, 28);
            btnAceptar.TabIndex = 12;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // FrmChicle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 264);
            Controls.Add(btnCancelar);
            Controls.Add(txtDuracionDeSabor);
            Controls.Add(lblDuracionDeSabor);
            Controls.Add(txtElasticidad);
            Controls.Add(lblElasticidad);
            Controls.Add(txtPopularidad);
            Controls.Add(lblPopularidad);
            Controls.Add(txtMarca);
            Controls.Add(lblMarca);
            Controls.Add(txtPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(btnAceptar);
            Name = "FrmChicle";
            Text = "Formulario chicle";
            Load += FrmChicle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private TextBox txtDuracionDeSabor;
        private Label lblDuracionDeSabor;
        private TextBox txtElasticidad;
        private Label lblElasticidad;
        private TextBox txtPopularidad;
        private Label lblPopularidad;
        private TextBox txtMarca;
        private Label lblMarca;
        private TextBox txtPrecio;
        private Label lblPrecio;
        private Button btnAceptar;
    }
}