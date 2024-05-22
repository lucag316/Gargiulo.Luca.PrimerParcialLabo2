namespace Interfaz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChupetin));
            cboDureza = new ComboBox();
            cboFormaChupetin = new ComboBox();
            lblDureza = new Label();
            lblFormaChupetin = new Label();
            SuspendLayout();
            // 
            // cboDureza
            // 
            cboDureza.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cboDureza.FormattingEnabled = true;
            cboDureza.Location = new Point(312, 175);
            cboDureza.Name = "cboDureza";
            cboDureza.Size = new Size(121, 22);
            cboDureza.TabIndex = 50;
            // 
            // cboFormaChupetin
            // 
            cboFormaChupetin.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cboFormaChupetin.FormattingEnabled = true;
            cboFormaChupetin.Location = new Point(312, 118);
            cboFormaChupetin.Name = "cboFormaChupetin";
            cboFormaChupetin.Size = new Size(121, 22);
            cboFormaChupetin.TabIndex = 49;
            // 
            // lblDureza
            // 
            lblDureza.AutoSize = true;
            lblDureza.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDureza.Location = new Point(312, 158);
            lblDureza.Name = "lblDureza";
            lblDureza.Size = new Size(105, 14);
            lblDureza.TabIndex = 48;
            lblDureza.Text = "Nivel de dureza:";
            // 
            // lblFormaChupetin
            // 
            lblFormaChupetin.AutoSize = true;
            lblFormaChupetin.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblFormaChupetin.Location = new Point(312, 101);
            lblFormaChupetin.Name = "lblFormaChupetin";
            lblFormaChupetin.Size = new Size(129, 14);
            lblFormaChupetin.TabIndex = 47;
            lblFormaChupetin.Text = "Forma del chupetin:";
            // 
            // FrmChupetin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(648, 432);
            Controls.Add(cboDureza);
            Controls.Add(cboFormaChupetin);
            Controls.Add(lblDureza);
            Controls.Add(lblFormaChupetin);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FrmChupetin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chupetin";
            Load += FrmChupetin_Load;
            Controls.SetChildIndex(txtPrecio, 0);
            Controls.SetChildIndex(txtCodigo, 0);
            Controls.SetChildIndex(txtPeso, 0);
            Controls.SetChildIndex(txtCantidad, 0);
            Controls.SetChildIndex(lblFormaChupetin, 0);
            Controls.SetChildIndex(lblDureza, 0);
            Controls.SetChildIndex(cboFormaChupetin, 0);
            Controls.SetChildIndex(cboDureza, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboDureza;
        private ComboBox cboFormaChupetin;
        private Label lblDureza;
        private Label lblFormaChupetin;
    }
}