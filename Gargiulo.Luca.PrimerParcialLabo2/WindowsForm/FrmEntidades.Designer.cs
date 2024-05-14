namespace WindowsForm
{
    partial class FrmEntidades
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
            btnChocolate = new Button();
            btnChicle = new Button();
            btnChupetin = new Button();
            SuspendLayout();
            // 
            // btnChocolate
            // 
            btnChocolate.Location = new Point(33, 27);
            btnChocolate.Name = "btnChocolate";
            btnChocolate.Size = new Size(144, 31);
            btnChocolate.TabIndex = 0;
            btnChocolate.Text = "&Chocolate";
            btnChocolate.UseVisualStyleBackColor = true;
            btnChocolate.Click += btnChocolate_Click;
            // 
            // btnChicle
            // 
            btnChicle.Location = new Point(33, 74);
            btnChicle.Name = "btnChicle";
            btnChicle.Size = new Size(144, 31);
            btnChicle.TabIndex = 1;
            btnChicle.Text = "&Chicle";
            btnChicle.UseVisualStyleBackColor = true;
            // 
            // btnChupetin
            // 
            btnChupetin.Location = new Point(33, 122);
            btnChupetin.Name = "btnChupetin";
            btnChupetin.Size = new Size(144, 31);
            btnChupetin.TabIndex = 2;
            btnChupetin.Text = "&Chupetin";
            btnChupetin.UseVisualStyleBackColor = true;
            // 
            // FrmEntidades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(209, 188);
            Controls.Add(btnChupetin);
            Controls.Add(btnChicle);
            Controls.Add(btnChocolate);
            Name = "FrmEntidades";
            Text = "Formulario Entidades";
            Load += FrmEntidades_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnChocolate;
        private Button btnChicle;
        private Button btnChupetin;
    }
}