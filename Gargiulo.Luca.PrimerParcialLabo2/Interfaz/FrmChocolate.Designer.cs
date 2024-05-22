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
            lblRelleno = new Label();
            lblTipoDeCacao = new Label();
            cboRelleno = new ComboBox();
            cboTipoDeCacao = new ComboBox();
            SuspendLayout();
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
            // cboRelleno
            // 
            cboRelleno.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cboRelleno.FormattingEnabled = true;
            cboRelleno.Location = new Point(303, 108);
            cboRelleno.Name = "cboRelleno";
            cboRelleno.Size = new Size(121, 22);
            cboRelleno.TabIndex = 45;
            // 
            // cboTipoDeCacao
            // 
            cboTipoDeCacao.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cboTipoDeCacao.FormattingEnabled = true;
            cboTipoDeCacao.Location = new Point(303, 165);
            cboTipoDeCacao.Name = "cboTipoDeCacao";
            cboTipoDeCacao.Size = new Size(121, 22);
            cboTipoDeCacao.TabIndex = 46;
            // 
            // FrmChocolate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(561, 343);
            Controls.Add(cboTipoDeCacao);
            Controls.Add(cboRelleno);
            Controls.Add(lblTipoDeCacao);
            Controls.Add(lblRelleno);
            Name = "FrmChocolate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chocolate";
            Load += FrmChocolate_Load;
            Controls.SetChildIndex(txtPrecio, 0);
            Controls.SetChildIndex(txtCodigo, 0);
            Controls.SetChildIndex(txtPeso, 0);
            Controls.SetChildIndex(txtCantidad, 0);
            Controls.SetChildIndex(lblRelleno, 0);
            Controls.SetChildIndex(lblTipoDeCacao, 0);
            Controls.SetChildIndex(cboRelleno, 0);
            Controls.SetChildIndex(cboTipoDeCacao, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblRelleno;
        private Label lblTipoDeCacao;
        private ComboBox cboRelleno;
        private ComboBox cboTipoDeCacao;
    }
}