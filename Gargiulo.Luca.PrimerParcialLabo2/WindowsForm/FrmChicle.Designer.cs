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
            txtTipoDeCacao = new TextBox();
            lblTipoDeCacao = new Label();
            txtRelleno = new TextBox();
            lblRelleno = new Label();
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
            // txtTipoDeCacao
            // 
            txtTipoDeCacao.Location = new Point(205, 129);
            txtTipoDeCacao.Name = "txtTipoDeCacao";
            txtTipoDeCacao.Size = new Size(128, 23);
            txtTipoDeCacao.TabIndex = 22;
            // 
            // lblTipoDeCacao
            // 
            lblTipoDeCacao.AutoSize = true;
            lblTipoDeCacao.Location = new Point(205, 111);
            lblTipoDeCacao.Name = "lblTipoDeCacao";
            lblTipoDeCacao.Size = new Size(85, 15);
            lblTipoDeCacao.TabIndex = 21;
            lblTipoDeCacao.Text = "Tipo de Cacao:";
            // 
            // txtRelleno
            // 
            txtRelleno.Location = new Point(205, 69);
            txtRelleno.Name = "txtRelleno";
            txtRelleno.Size = new Size(128, 23);
            txtRelleno.TabIndex = 20;
            // 
            // lblRelleno
            // 
            lblRelleno.AutoSize = true;
            lblRelleno.Location = new Point(205, 51);
            lblRelleno.Name = "lblRelleno";
            lblRelleno.Size = new Size(49, 15);
            lblRelleno.TabIndex = 19;
            lblRelleno.Text = "Relleno:";
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
            ClientSize = new Size(392, 280);
            Controls.Add(btnCancelar);
            Controls.Add(txtTipoDeCacao);
            Controls.Add(lblTipoDeCacao);
            Controls.Add(txtRelleno);
            Controls.Add(lblRelleno);
            Controls.Add(txtPopularidad);
            Controls.Add(lblPopularidad);
            Controls.Add(txtMarca);
            Controls.Add(lblMarca);
            Controls.Add(txtPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(btnAceptar);
            Name = "FrmChicle";
            Text = "FrmChicle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private TextBox txtTipoDeCacao;
        private Label lblTipoDeCacao;
        private TextBox txtRelleno;
        private Label lblRelleno;
        private TextBox txtPopularidad;
        private Label lblPopularidad;
        private TextBox txtMarca;
        private Label lblMarca;
        private TextBox txtPrecio;
        private Label lblPrecio;
        private Button btnAceptar;
    }
}