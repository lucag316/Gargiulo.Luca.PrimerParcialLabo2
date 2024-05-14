namespace WindowsForm
{
    partial class FrmChupetin
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
            txtTipoDePalo = new TextBox();
            lblTipoDePalo = new Label();
            txtNivelDeDureza = new TextBox();
            lblNivelDeDureza = new Label();
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
            btnCancelar.Location = new Point(202, 210);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(128, 28);
            btnCancelar.TabIndex = 23;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtTipoDePalo
            // 
            txtTipoDePalo.Location = new Point(202, 133);
            txtTipoDePalo.Name = "txtTipoDePalo";
            txtTipoDePalo.Size = new Size(128, 23);
            txtTipoDePalo.TabIndex = 22;
            // 
            // lblTipoDePalo
            // 
            lblTipoDePalo.AutoSize = true;
            lblTipoDePalo.Location = new Point(202, 115);
            lblTipoDePalo.Name = "lblTipoDePalo";
            lblTipoDePalo.Size = new Size(75, 15);
            lblTipoDePalo.TabIndex = 21;
            lblTipoDePalo.Text = "Tipo de Palo:";
            // 
            // txtNivelDeDureza
            // 
            txtNivelDeDureza.Location = new Point(202, 73);
            txtNivelDeDureza.Name = "txtNivelDeDureza";
            txtNivelDeDureza.Size = new Size(128, 23);
            txtNivelDeDureza.TabIndex = 20;
            // 
            // lblNivelDeDureza
            // 
            lblNivelDeDureza.AutoSize = true;
            lblNivelDeDureza.Location = new Point(202, 55);
            lblNivelDeDureza.Name = "lblNivelDeDureza";
            lblNivelDeDureza.Size = new Size(91, 15);
            lblNivelDeDureza.TabIndex = 19;
            lblNivelDeDureza.Text = "Nivel de dureza:";
            // 
            // txtPopularidad
            // 
            txtPopularidad.Location = new Point(40, 151);
            txtPopularidad.Name = "txtPopularidad";
            txtPopularidad.Size = new Size(128, 23);
            txtPopularidad.TabIndex = 18;
            // 
            // lblPopularidad
            // 
            lblPopularidad.AutoSize = true;
            lblPopularidad.Location = new Point(40, 133);
            lblPopularidad.Name = "lblPopularidad";
            lblPopularidad.Size = new Size(74, 15);
            lblPopularidad.TabIndex = 17;
            lblPopularidad.Text = "Popularidad:";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(40, 99);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(128, 23);
            txtMarca.TabIndex = 16;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(40, 81);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(43, 15);
            lblMarca.TabIndex = 15;
            lblMarca.Text = "Marca:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(40, 48);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(128, 23);
            txtPrecio.TabIndex = 14;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(40, 30);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(43, 15);
            lblPrecio.TabIndex = 13;
            lblPrecio.Text = "Precio:";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(40, 210);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(128, 28);
            btnAceptar.TabIndex = 12;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // FrmChupetin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 258);
            Controls.Add(btnCancelar);
            Controls.Add(txtTipoDePalo);
            Controls.Add(lblTipoDePalo);
            Controls.Add(txtNivelDeDureza);
            Controls.Add(lblNivelDeDureza);
            Controls.Add(txtPopularidad);
            Controls.Add(lblPopularidad);
            Controls.Add(txtMarca);
            Controls.Add(lblMarca);
            Controls.Add(txtPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(btnAceptar);
            Name = "FrmChupetin";
            Text = "FrmChupetin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private TextBox txtTipoDePalo;
        private Label lblTipoDePalo;
        private TextBox txtNivelDeDureza;
        private Label lblNivelDeDureza;
        private TextBox txtPopularidad;
        private Label lblPopularidad;
        private TextBox txtMarca;
        private Label lblMarca;
        private TextBox txtPrecio;
        private Label lblPrecio;
        private Button btnAceptar;
    }
}