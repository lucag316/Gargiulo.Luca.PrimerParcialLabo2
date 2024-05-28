namespace Interfaz
{
    partial class FrmGolosina
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
            txtCantidad = new TextBox();
            txtPeso = new TextBox();
            txtCodigo = new TextBox();
            lblCantidad = new Label();
            lblPeso = new Label();
            btnCancelar = new Button();
            lblCodigo = new Label();
            txtPrecio = new TextBox();
            lblPrecio = new Label();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // txtCantidad
            // 
            txtCantidad.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtCantidad.Location = new Point(105, 235);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.PlaceholderText = "Ingrese Cantidad";
            txtCantidad.Size = new Size(128, 22);
            txtCantidad.TabIndex = 44;
            // 
            // txtPeso
            // 
            txtPeso.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtPeso.Location = new Point(105, 175);
            txtPeso.Name = "txtPeso";
            txtPeso.PlaceholderText = "Ingrese Peso";
            txtPeso.Size = new Size(128, 22);
            txtPeso.TabIndex = 43;
            // 
            // txtCodigo
            // 
            txtCodigo.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtCodigo.Location = new Point(105, 59);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.PlaceholderText = "Ingrese Codigo";
            txtCodigo.Size = new Size(128, 22);
            txtCodigo.TabIndex = 42;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCantidad.Location = new Point(105, 218);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(66, 14);
            lblCantidad.TabIndex = 39;
            lblCantidad.Text = "Cantidad:";
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPeso.Location = new Point(105, 158);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(39, 14);
            lblPeso.TabIndex = 38;
            lblPeso.Text = "Peso:";
            // 
            // btnCancelar
            // 
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(288, 291);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(182, 40);
            btnCancelar.TabIndex = 37;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCodigo.Location = new Point(105, 42);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(107, 14);
            lblCodigo.TabIndex = 36;
            lblCodigo.Text = "Codigo de barra:";
            // 
            // txtPrecio
            // 
            txtPrecio.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtPrecio.Location = new Point(105, 118);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.PlaceholderText = "Ingrese Precio";
            txtPrecio.Size = new Size(128, 22);
            txtPrecio.TabIndex = 35;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrecio.Location = new Point(105, 101);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(49, 14);
            lblPrecio.TabIndex = 34;
            lblPrecio.Text = "Precio:";
            // 
            // btnAceptar
            // 
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.Location = new Point(75, 291);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(175, 40);
            btnAceptar.TabIndex = 33;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FrmGolosina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 391);
            ControlBox = false;
            Controls.Add(txtCantidad);
            Controls.Add(txtPeso);
            Controls.Add(txtCodigo);
            Controls.Add(lblCantidad);
            Controls.Add(lblPeso);
            Controls.Add(btnCancelar);
            Controls.Add(lblCodigo);
            Controls.Add(txtPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(btnAceptar);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FrmGolosina";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Golosina";
            Load += FrmGolosina_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblCantidad;
        private Label lblPeso;
        private Button btnCancelar;
        private Label lblCodigo;
        private Label lblPrecio;
        private Button btnAceptar;
        protected TextBox txtCantidad;
        protected TextBox txtPeso;
        protected TextBox txtCodigo;
        protected TextBox txtPrecio;
    }
}