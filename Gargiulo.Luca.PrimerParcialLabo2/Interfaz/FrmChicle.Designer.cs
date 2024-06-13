namespace Interfaz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChicle));
            cboDuracionSabor = new ComboBox();
            cboElasticidad = new ComboBox();
            lblDuracionDelSabor = new Label();
            lblElasticidad = new Label();
            chkBlanqueadorDental = new CheckBox();
            SuspendLayout();
            // 
            // cboDuracionSabor
            // 
            cboDuracionSabor.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cboDuracionSabor.FormattingEnabled = true;
            cboDuracionSabor.Location = new Point(315, 118);
            cboDuracionSabor.Name = "cboDuracionSabor";
            cboDuracionSabor.Size = new Size(121, 22);
            cboDuracionSabor.TabIndex = 50;
            // 
            // cboElasticidad
            // 
            cboElasticidad.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cboElasticidad.FormattingEnabled = true;
            cboElasticidad.Location = new Point(315, 59);
            cboElasticidad.Name = "cboElasticidad";
            cboElasticidad.Size = new Size(121, 22);
            cboElasticidad.TabIndex = 49;
            // 
            // lblDuracionDelSabor
            // 
            lblDuracionDelSabor.AutoSize = true;
            lblDuracionDelSabor.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDuracionDelSabor.Location = new Point(311, 101);
            lblDuracionDelSabor.Name = "lblDuracionDelSabor";
            lblDuracionDelSabor.Size = new Size(125, 14);
            lblDuracionDelSabor.TabIndex = 48;
            lblDuracionDelSabor.Text = "Duracion del sabor:";
            // 
            // lblElasticidad
            // 
            lblElasticidad.AutoSize = true;
            lblElasticidad.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblElasticidad.Location = new Point(315, 42);
            lblElasticidad.Name = "lblElasticidad";
            lblElasticidad.Size = new Size(78, 14);
            lblElasticidad.TabIndex = 47;
            lblElasticidad.Text = "Elasticidad:";
            // 
            // chkBlanqueadorDental
            // 
            chkBlanqueadorDental.AutoSize = true;
            chkBlanqueadorDental.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            chkBlanqueadorDental.Location = new Point(315, 179);
            chkBlanqueadorDental.Name = "chkBlanqueadorDental";
            chkBlanqueadorDental.Size = new Size(144, 18);
            chkBlanqueadorDental.TabIndex = 51;
            chkBlanqueadorDental.Text = "Blanqueador dental";
            chkBlanqueadorDental.UseVisualStyleBackColor = true;
            // 
            // FrmChicle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(636, 403);
            Controls.Add(chkBlanqueadorDental);
            Controls.Add(cboDuracionSabor);
            Controls.Add(cboElasticidad);
            Controls.Add(lblDuracionDelSabor);
            Controls.Add(lblElasticidad);
            Name = "FrmChicle";
            Text = "Chicle";
            Load += FrmChicle_Load;
            Controls.SetChildIndex(txtPrecio, 0);
            Controls.SetChildIndex(txtCodigo, 0);
            Controls.SetChildIndex(txtPeso, 0);
            Controls.SetChildIndex(txtCantidad, 0);
            Controls.SetChildIndex(lblElasticidad, 0);
            Controls.SetChildIndex(lblDuracionDelSabor, 0);
            Controls.SetChildIndex(cboElasticidad, 0);
            Controls.SetChildIndex(cboDuracionSabor, 0);
            Controls.SetChildIndex(chkBlanqueadorDental, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboDuracionSabor;
        private ComboBox cboElasticidad;
        private Label lblDuracionDelSabor;
        private Label lblElasticidad;
        private CheckBox chkBlanqueadorDental;
    }
}