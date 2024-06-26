namespace Interfaz
{
    partial class FrmDetalleKiosco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetalleKiosco));
            lstVisorDetalleKiosco = new ListBox();
            SuspendLayout();
            // 
            // lstVisorDetalleKiosco
            // 
            lstVisorDetalleKiosco.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lstVisorDetalleKiosco.FormattingEnabled = true;
            lstVisorDetalleKiosco.ItemHeight = 14;
            lstVisorDetalleKiosco.Location = new Point(59, 12);
            lstVisorDetalleKiosco.Name = "lstVisorDetalleKiosco";
            lstVisorDetalleKiosco.Size = new Size(981, 396);
            lstVisorDetalleKiosco.TabIndex = 0;
            // 
            // FrmDetalleKiosco
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1102, 420);
            Controls.Add(lstVisorDetalleKiosco);
            Font = new Font("Rockwell", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FrmDetalleKiosco";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle";
            Load += FrmDetalleKiosco_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstVisorDetalleKiosco;
    }
}