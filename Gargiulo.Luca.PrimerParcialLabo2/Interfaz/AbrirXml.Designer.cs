namespace Interfaz
{
    partial class AbrirXml
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
            btnAbrir = new Button();
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // btnAbrir
            // 
            btnAbrir.Location = new Point(24, 11);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(75, 21);
            btnAbrir.TabIndex = 0;
            btnAbrir.Text = "&Abrir";
            btnAbrir.UseVisualStyleBackColor = true;
            btnAbrir.Click += btnAbrir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 56);
            label1.Name = "label1";
            label1.Size = new Size(41, 14);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Archivos XML (*.xml)|.xml";
            // 
            // AbrirXml
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 420);
            Controls.Add(label1);
            Controls.Add(btnAbrir);
            Font = new Font("Rockwell", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "AbrirXml";
            Text = "AbrirXml";
            Load += AbrirXml_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAbrir;
        private Label label1;
        private OpenFileDialog openFileDialog1;
    }
}