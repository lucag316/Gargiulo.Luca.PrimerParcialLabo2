namespace Interfaz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            btnIniciarSesion = new Button();
            txtClave = new TextBox();
            txtCorreo = new TextBox();
            lblClave = new Label();
            lblCorreo = new Label();
            SuspendLayout();
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.Aqua;
            btnIniciarSesion.FlatStyle = FlatStyle.Flat;
            btnIniciarSesion.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnIniciarSesion.Location = new Point(135, 159);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(321, 42);
            btnIniciarSesion.TabIndex = 0;
            btnIniciarSesion.Text = "&Iniciar sesion";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            // 
            // txtClave
            // 
            txtClave.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtClave.Location = new Point(135, 116);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.PlaceholderText = "Ingrese su clave";
            txtClave.Size = new Size(321, 22);
            txtClave.TabIndex = 2;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtCorreo.Location = new Point(135, 66);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Ingrese su correo";
            txtCorreo.Size = new Size(321, 22);
            txtCorreo.TabIndex = 1;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.BackColor = Color.Aqua;
            lblClave.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblClave.Location = new Point(135, 99);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(45, 14);
            lblClave.TabIndex = 13;
            lblClave.Text = "Clave:";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.BackColor = Color.Aqua;
            lblCorreo.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCorreo.Location = new Point(135, 49);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(121, 14);
            lblCorreo.TabIndex = 12;
            lblCorreo.Text = "Correo electronico:";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(605, 280);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtClave);
            Controls.Add(txtCorreo);
            Controls.Add(lblClave);
            Controls.Add(lblCorreo);
            Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Name = "FrmLogin";
            Text = "Form1";
            Load += FrmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnIniciarSesion;
        private TextBox txtClave;
        private TextBox txtCorreo;
        private Label lblClave;
        private Label lblCorreo;
    }
}