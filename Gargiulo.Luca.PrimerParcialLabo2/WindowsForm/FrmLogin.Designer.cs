namespace WindowsForm
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCancelar = new Button();
            btnIniciarSesion = new Button();
            txtContraseña = new TextBox();
            txtCorreo = new TextBox();
            lblClave = new Label();
            lblCorreo = new Label();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(238, 158);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(111, 38);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(68, 158);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(109, 38);
            btnIniciarSesion.TabIndex = 10;
            btnIniciarSesion.Text = "&Iniciar sesion";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(68, 112);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(281, 23);
            txtContraseña.TabIndex = 9;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(68, 59);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(281, 23);
            txtCorreo.TabIndex = 8;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Location = new Point(68, 94);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(39, 15);
            lblClave.TabIndex = 7;
            lblClave.Text = "Clave:";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(68, 41);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(108, 15);
            lblCorreo.TabIndex = 6;
            lblCorreo.Text = "Correo electronico:";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 247);
            Controls.Add(btnCancelar);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtContraseña);
            Controls.Add(txtCorreo);
            Controls.Add(lblClave);
            Controls.Add(lblCorreo);
            Name = "FrmLogin";
            Text = "Login";
            Load += FrmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnIniciarSesion;
        private TextBox txtContraseña;
        private TextBox txtCorreo;
        private Label lblClave;
        private Label lblCorreo;
    }
}