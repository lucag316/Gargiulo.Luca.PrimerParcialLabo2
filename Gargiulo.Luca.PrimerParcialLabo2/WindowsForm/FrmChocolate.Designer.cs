namespace WindowsForm
{
    partial class FrmChocolate
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
            btnAceptar = new Button();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            txtMarca = new TextBox();
            lblMarca = new Label();
            txtPopularidad = new TextBox();
            lblPopularidad = new Label();
            txtRelleno = new TextBox();
            lblRelleno = new Label();
            txtTipoDeCacao = new TextBox();
            lblTipoDeCacao = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(37, 189);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(128, 28);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(37, 9);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(43, 15);
            lblPrecio.TabIndex = 1;
            lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(37, 27);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(128, 23);
            txtPrecio.TabIndex = 2;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(37, 78);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(128, 23);
            txtMarca.TabIndex = 4;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(37, 60);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(43, 15);
            lblMarca.TabIndex = 3;
            lblMarca.Text = "Marca:";
            // 
            // txtPopularidad
            // 
            txtPopularidad.Location = new Point(37, 130);
            txtPopularidad.Name = "txtPopularidad";
            txtPopularidad.Size = new Size(128, 23);
            txtPopularidad.TabIndex = 6;
            // 
            // lblPopularidad
            // 
            lblPopularidad.AutoSize = true;
            lblPopularidad.Location = new Point(37, 112);
            lblPopularidad.Name = "lblPopularidad";
            lblPopularidad.Size = new Size(74, 15);
            lblPopularidad.TabIndex = 5;
            lblPopularidad.Text = "Popularidad:";
            // 
            // txtRelleno
            // 
            txtRelleno.Location = new Point(199, 52);
            txtRelleno.Name = "txtRelleno";
            txtRelleno.Size = new Size(128, 23);
            txtRelleno.TabIndex = 8;
            // 
            // lblRelleno
            // 
            lblRelleno.AutoSize = true;
            lblRelleno.Location = new Point(199, 34);
            lblRelleno.Name = "lblRelleno";
            lblRelleno.Size = new Size(49, 15);
            lblRelleno.TabIndex = 7;
            lblRelleno.Text = "Relleno:";
            // 
            // txtTipoDeCacao
            // 
            txtTipoDeCacao.Location = new Point(199, 112);
            txtTipoDeCacao.Name = "txtTipoDeCacao";
            txtTipoDeCacao.Size = new Size(128, 23);
            txtTipoDeCacao.TabIndex = 10;
            // 
            // lblTipoDeCacao
            // 
            lblTipoDeCacao.AutoSize = true;
            lblTipoDeCacao.Location = new Point(199, 94);
            lblTipoDeCacao.Name = "lblTipoDeCacao";
            lblTipoDeCacao.Size = new Size(85, 15);
            lblTipoDeCacao.TabIndex = 9;
            lblTipoDeCacao.Text = "Tipo de Cacao:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(199, 189);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(128, 28);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmChocolate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 263);
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
            Name = "FrmChocolate";
            Text = "Formulario Chocolate";
            Load += FrmChocolate_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private TextBox txtMarca;
        private Label lblMarca;
        private TextBox txtPopularidad;
        private Label lblPopularidad;
        private TextBox txtRelleno;
        private Label lblRelleno;
        private TextBox txtTipoDeCacao;
        private Label lblTipoDeCacao;
        private Button btnCancelar;
    }
}