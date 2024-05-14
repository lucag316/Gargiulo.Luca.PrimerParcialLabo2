namespace WindowsForm
{
    partial class FrmPrincipal
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
            btnAgregar = new Button();
            listBox1 = new ListBox();
            btnModificar = new Button();
            btnEliminar = new Button();
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            deserializarToolStripMenuItem = new ToolStripMenuItem();
            serializarToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 384);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(213, 40);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "&Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 60);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(776, 289);
            listBox1.TabIndex = 1;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(295, 384);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(213, 40);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "&Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(575, 384);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(213, 40);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "&Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(713, 1);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "leer";
            button1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { deserializarToolStripMenuItem, serializarToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // deserializarToolStripMenuItem
            // 
            deserializarToolStripMenuItem.Name = "deserializarToolStripMenuItem";
            deserializarToolStripMenuItem.Size = new Size(78, 20);
            deserializarToolStripMenuItem.Text = "Deserializar";
            // 
            // serializarToolStripMenuItem
            // 
            serializarToolStripMenuItem.Name = "serializarToolStripMenuItem";
            serializarToolStripMenuItem.Size = new Size(65, 20);
            serializarToolStripMenuItem.Text = "Serializar";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(listBox1);
            Controls.Add(btnAgregar);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmPrincipal";
            Text = "Formulario principal";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private ListBox listBox1;
        private Button btnModificar;
        private Button btnEliminar;
        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem deserializarToolStripMenuItem;
        private ToolStripMenuItem serializarToolStripMenuItem;
    }
}