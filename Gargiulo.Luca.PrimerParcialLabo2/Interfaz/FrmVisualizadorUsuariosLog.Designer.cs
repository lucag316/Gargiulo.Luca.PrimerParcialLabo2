namespace Interfaz
{
    partial class FrmVisualizadorUsuariosLog
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
            lstVisualizadorUsuariosLog = new ListBox();
            SuspendLayout();
            // 
            // lstVisualizadorUsuariosLog
            // 
            lstVisualizadorUsuariosLog.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lstVisualizadorUsuariosLog.FormattingEnabled = true;
            lstVisualizadorUsuariosLog.ItemHeight = 14;
            lstVisualizadorUsuariosLog.Location = new Point(12, 11);
            lstVisualizadorUsuariosLog.Name = "lstVisualizadorUsuariosLog";
            lstVisualizadorUsuariosLog.Size = new Size(1066, 382);
            lstVisualizadorUsuariosLog.TabIndex = 0;
            // 
            // FrmVisualizadorUsuariosLog
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1090, 447);
            Controls.Add(lstVisualizadorUsuariosLog);
            Font = new Font("Rockwell", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FrmVisualizadorUsuariosLog";
            Text = "Registro de Accesos";
            Load += FrmVisualizadorUsuariosLog_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstVisualizadorUsuariosLog;
    }
}