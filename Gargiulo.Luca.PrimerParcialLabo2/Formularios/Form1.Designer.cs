namespace Formularios
{
    partial class Form1
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
            btnIniciarSesion.Location = new Point(220, 206);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(321, 42);
            btnIniciarSesion.TabIndex = 14;
            btnIniciarSesion.Text = "&Iniciar sesion";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // txtClave
            // 
            txtClave.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtClave.Location = new Point(220, 163);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.PlaceholderText = "Ingrese su clave";
            txtClave.Size = new Size(321, 22);
            txtClave.TabIndex = 16;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtCorreo.Location = new Point(220, 113);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Ingrese su correo";
            txtCorreo.Size = new Size(321, 22);
            txtCorreo.TabIndex = 15;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.BackColor = Color.Aqua;
            lblClave.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblClave.Location = new Point(220, 146);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(45, 14);
            lblClave.TabIndex = 18;
            lblClave.Text = "Clave:";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.BackColor = Color.Aqua;
            lblCorreo.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCorreo.Location = new Point(220, 96);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(121, 14);
            lblCorreo.TabIndex = 17;
            lblCorreo.Text = "Correo electronico:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtClave);
            Controls.Add(txtCorreo);
            Controls.Add(lblClave);
            Controls.Add(lblCorreo);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
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