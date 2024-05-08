namespace WindowsForm
{
    partial class Login
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
            lblCorreo = new Label();
            lblContraseña = new Label();
            txtCorreo = new TextBox();
            txtContraseña = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(35, 18);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(162, 15);
            lblCorreo.TabIndex = 0;
            lblCorreo.Text = "Ingrese su correo electronico:";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Location = new Point(35, 71);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(70, 15);
            lblContraseña.TabIndex = 1;
            lblContraseña.Text = "Contraseña:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(35, 36);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(281, 23);
            txtCorreo.TabIndex = 2;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(35, 89);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(281, 23);
            txtContraseña.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(35, 135);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(109, 38);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "&Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(205, 135);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(111, 38);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 199);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtContraseña);
            Controls.Add(txtCorreo);
            Controls.Add(lblContraseña);
            Controls.Add(lblCorreo);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCorreo;
        private Label lblContraseña;
        private TextBox txtCorreo;
        private TextBox txtContraseña;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}