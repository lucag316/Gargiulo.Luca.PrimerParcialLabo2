namespace Interfaz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChocolate));
            btnCancelar = new Button();
            lblCodigo = new Label();
            txtPrecio = new TextBox();
            lblPrecio = new Label();
            btnAceptar = new Button();
            lblPeso = new Label();
            lblCantidad = new Label();
            lblRelleno = new Label();
            lblTipoDeCacao = new Label();
            txtCodigo = new TextBox();
            txtPeso = new TextBox();
            txtCantidad = new TextBox();
            txtRelleno = new TextBox();
            txtTipoDeCacao = new TextBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(303, 281);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(182, 40);
            btnCancelar.TabIndex = 23;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCodigo.Location = new Point(120, 32);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(107, 14);
            lblCodigo.TabIndex = 15;
            lblCodigo.Text = "Codigo de barra:";
            // 
            // txtPrecio
            // 
            txtPrecio.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtPrecio.Location = new Point(120, 108);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "Ingrese Precio";
            txtPrecio.Size = new Size(128, 22);
            txtPrecio.TabIndex = 14;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrecio.Location = new Point(120, 91);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(49, 14);
            lblPrecio.TabIndex = 13;
            lblPrecio.Text = "Precio:";
            // 
            // btnAceptar
            // 
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.Location = new Point(90, 281);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(175, 40);
            btnAceptar.TabIndex = 12;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPeso.Location = new Point(120, 148);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(39, 14);
            lblPeso.TabIndex = 24;
            lblPeso.Text = "Peso:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCantidad.Location = new Point(120, 208);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(66, 14);
            lblCantidad.TabIndex = 25;
            lblCantidad.Text = "Cantidad:";
            // 
            // lblRelleno
            // 
            lblRelleno.AutoSize = true;
            lblRelleno.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblRelleno.Location = new Point(303, 91);
            lblRelleno.Name = "lblRelleno";
            lblRelleno.Size = new Size(57, 14);
            lblRelleno.TabIndex = 26;
            lblRelleno.Text = "Relleno:";
            // 
            // lblTipoDeCacao
            // 
            lblTipoDeCacao.AutoSize = true;
            lblTipoDeCacao.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTipoDeCacao.Location = new Point(303, 148);
            lblTipoDeCacao.Name = "lblTipoDeCacao";
            lblTipoDeCacao.Size = new Size(94, 14);
            lblTipoDeCacao.TabIndex = 27;
            lblTipoDeCacao.Text = "Tipo de cacao:";
            // 
            // txtCodigo
            // 
            txtCodigo.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtCodigo.Location = new Point(120, 49);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.PlaceholderText = "Ingrese Codigo";
            txtCodigo.Size = new Size(128, 22);
            txtCodigo.TabIndex = 28;
            // 
            // txtPeso
            // 
            txtPeso.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtPeso.Location = new Point(120, 165);
            txtPeso.Name = "txtPeso";
            txtPeso.PlaceholderText = "Ingrese Peso";
            txtPeso.Size = new Size(128, 22);
            txtPeso.TabIndex = 29;
            // 
            // txtCantidad
            // 
            txtCantidad.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtCantidad.Location = new Point(120, 225);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.PlaceholderText = "Ingrese Cantidad";
            txtCantidad.Size = new Size(128, 22);
            txtCantidad.TabIndex = 30;
            // 
            // txtRelleno
            // 
            txtRelleno.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtRelleno.Location = new Point(303, 108);
            txtRelleno.Name = "txtRelleno";
            txtRelleno.PlaceholderText = "Ingrese Relleno";
            txtRelleno.Size = new Size(128, 22);
            txtRelleno.TabIndex = 31;
            // 
            // txtTipoDeCacao
            // 
            txtTipoDeCacao.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtTipoDeCacao.Location = new Point(303, 165);
            txtTipoDeCacao.Name = "txtTipoDeCacao";
            txtTipoDeCacao.PlaceholderText = "Ingrese Tipo De Cacao";
            txtTipoDeCacao.Size = new Size(128, 22);
            txtTipoDeCacao.TabIndex = 32;
            // 
            // FrmChocolate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(561, 343);
            Controls.Add(txtTipoDeCacao);
            Controls.Add(txtRelleno);
            Controls.Add(txtCantidad);
            Controls.Add(txtPeso);
            Controls.Add(txtCodigo);
            Controls.Add(lblTipoDeCacao);
            Controls.Add(lblRelleno);
            Controls.Add(lblCantidad);
            Controls.Add(lblPeso);
            Controls.Add(btnCancelar);
            Controls.Add(lblCodigo);
            Controls.Add(txtPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(btnAceptar);
            Name = "FrmChocolate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Formulario Chocolate";
            Load += FrmChocolate_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Label lblCodigo;
        private TextBox txtPrecio;
        private Label lblPrecio;
        private Button btnAceptar;
        private Label lblPeso;
        private Label lblCantidad;
        private Label lblRelleno;
        private Label lblTipoDeCacao;
        private TextBox txtCodigo;
        private TextBox txtPeso;
        private TextBox txtCantidad;
        private TextBox txtRelleno;
        private TextBox txtTipoDeCacao;
    }
}