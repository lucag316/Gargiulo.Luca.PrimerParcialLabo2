﻿namespace Interfaz
{
    partial class FrmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            button1 = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            lstVisorGolosinas = new ListBox();
            btnAgregar = new Button();
            menuStrip1 = new MenuStrip();
            cRUDToolStripMenuItem = new ToolStripMenuItem();
            aGREGARToolStripMenuItem = new ToolStripMenuItem();
            cHOCOLATEToolStripMenuItem1 = new ToolStripMenuItem();
            cHICLEToolStripMenuItem1 = new ToolStripMenuItem();
            cHUPETINToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            oToolStripMenuItem = new ToolStripMenuItem();
            aRCHIVOSToolStripMenuItem = new ToolStripMenuItem();
            sERIALIZARToolStripMenuItem2 = new ToolStripMenuItem();
            jSONToolStripMenuItem2 = new ToolStripMenuItem();
            xMLToolStripMenuItem2 = new ToolStripMenuItem();
            dESERIALIZARToolStripMenuItem2 = new ToolStripMenuItem();
            jSONToolStripMenuItem3 = new ToolStripMenuItem();
            xMLToolStripMenuItem3 = new ToolStripMenuItem();
            dESERIALIZARToolStripMenuItem = new ToolStripMenuItem();
            jSONToolStripMenuItem = new ToolStripMenuItem();
            xMLToolStripMenuItem = new ToolStripMenuItem();
            jSONToolStripMenuItem1 = new ToolStripMenuItem();
            xMLToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(815, 13);
            button1.Name = "button1";
            button1.Size = new Size(86, 21);
            button1.TabIndex = 10;
            button1.Text = "leer";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.Location = new Point(657, 371);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(243, 37);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "&Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnModificar.Location = new Point(337, 371);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(243, 37);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "&Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // lstVisorGolosinas
            // 
            lstVisorGolosinas.FormattingEnabled = true;
            lstVisorGolosinas.ItemHeight = 14;
            lstVisorGolosinas.Location = new Point(14, 68);
            lstVisorGolosinas.Name = "lstVisorGolosinas";
            lstVisorGolosinas.Size = new Size(886, 270);
            lstVisorGolosinas.TabIndex = 7;
            // 
            // btnAgregar
            // 
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.Location = new Point(14, 371);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(243, 37);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "&Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cRUDToolStripMenuItem, aRCHIVOSToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(914, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // cRUDToolStripMenuItem
            // 
            cRUDToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aGREGARToolStripMenuItem, toolStripMenuItem1, oToolStripMenuItem });
            cRUDToolStripMenuItem.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cRUDToolStripMenuItem.Name = "cRUDToolStripMenuItem";
            cRUDToolStripMenuItem.Size = new Size(55, 20);
            cRUDToolStripMenuItem.Text = "CRUD";
            // 
            // aGREGARToolStripMenuItem
            // 
            aGREGARToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cHOCOLATEToolStripMenuItem1, cHICLEToolStripMenuItem1, cHUPETINToolStripMenuItem1 });
            aGREGARToolStripMenuItem.Name = "aGREGARToolStripMenuItem";
            aGREGARToolStripMenuItem.Size = new Size(151, 22);
            aGREGARToolStripMenuItem.Text = "AGREGAR";
            // 
            // cHOCOLATEToolStripMenuItem1
            // 
            cHOCOLATEToolStripMenuItem1.Name = "cHOCOLATEToolStripMenuItem1";
            cHOCOLATEToolStripMenuItem1.Size = new Size(153, 22);
            cHOCOLATEToolStripMenuItem1.Text = "CHOCOLATE";
            cHOCOLATEToolStripMenuItem1.Click += cHOCOLATEToolStripMenuItem1_Click;
            // 
            // cHICLEToolStripMenuItem1
            // 
            cHICLEToolStripMenuItem1.Name = "cHICLEToolStripMenuItem1";
            cHICLEToolStripMenuItem1.Size = new Size(153, 22);
            cHICLEToolStripMenuItem1.Text = "CHICLE";
            cHICLEToolStripMenuItem1.Click += cHICLEToolStripMenuItem1_Click;
            // 
            // cHUPETINToolStripMenuItem1
            // 
            cHUPETINToolStripMenuItem1.Name = "cHUPETINToolStripMenuItem1";
            cHUPETINToolStripMenuItem1.Size = new Size(153, 22);
            cHUPETINToolStripMenuItem1.Text = "CHUPETIN";
            cHUPETINToolStripMenuItem1.Click += cHUPETINToolStripMenuItem1_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(151, 22);
            toolStripMenuItem1.Text = "MODIFICAR";
            // 
            // oToolStripMenuItem
            // 
            oToolStripMenuItem.Name = "oToolStripMenuItem";
            oToolStripMenuItem.Size = new Size(151, 22);
            oToolStripMenuItem.Text = "ELIMINAR";
            // 
            // aRCHIVOSToolStripMenuItem
            // 
            aRCHIVOSToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sERIALIZARToolStripMenuItem2, dESERIALIZARToolStripMenuItem2 });
            aRCHIVOSToolStripMenuItem.Font = new Font("Rockwell", 9F, FontStyle.Regular, GraphicsUnit.Point);
            aRCHIVOSToolStripMenuItem.Name = "aRCHIVOSToolStripMenuItem";
            aRCHIVOSToolStripMenuItem.Size = new Size(80, 20);
            aRCHIVOSToolStripMenuItem.Text = "ARCHIVOS";
            // 
            // sERIALIZARToolStripMenuItem2
            // 
            sERIALIZARToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { jSONToolStripMenuItem2, xMLToolStripMenuItem2 });
            sERIALIZARToolStripMenuItem2.Name = "sERIALIZARToolStripMenuItem2";
            sERIALIZARToolStripMenuItem2.Size = new Size(180, 22);
            sERIALIZARToolStripMenuItem2.Text = "SERIALIZAR";
            // 
            // jSONToolStripMenuItem2
            // 
            jSONToolStripMenuItem2.Name = "jSONToolStripMenuItem2";
            jSONToolStripMenuItem2.Size = new Size(180, 22);
            jSONToolStripMenuItem2.Text = "JSON";
            jSONToolStripMenuItem2.Click += jSONToolStripMenuItem2_Click;
            // 
            // xMLToolStripMenuItem2
            // 
            xMLToolStripMenuItem2.Name = "xMLToolStripMenuItem2";
            xMLToolStripMenuItem2.Size = new Size(180, 22);
            xMLToolStripMenuItem2.Text = "XML";
            // 
            // dESERIALIZARToolStripMenuItem2
            // 
            dESERIALIZARToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { jSONToolStripMenuItem3, xMLToolStripMenuItem3 });
            dESERIALIZARToolStripMenuItem2.Name = "dESERIALIZARToolStripMenuItem2";
            dESERIALIZARToolStripMenuItem2.Size = new Size(180, 22);
            dESERIALIZARToolStripMenuItem2.Text = "DESERIALIZAR";
            // 
            // jSONToolStripMenuItem3
            // 
            jSONToolStripMenuItem3.Name = "jSONToolStripMenuItem3";
            jSONToolStripMenuItem3.Size = new Size(102, 22);
            jSONToolStripMenuItem3.Text = "JSON";
            // 
            // xMLToolStripMenuItem3
            // 
            xMLToolStripMenuItem3.Name = "xMLToolStripMenuItem3";
            xMLToolStripMenuItem3.Size = new Size(102, 22);
            xMLToolStripMenuItem3.Text = "XML";
            // 
            // dESERIALIZARToolStripMenuItem
            // 
            dESERIALIZARToolStripMenuItem.Name = "dESERIALIZARToolStripMenuItem";
            dESERIALIZARToolStripMenuItem.Size = new Size(32, 19);
            // 
            // jSONToolStripMenuItem
            // 
            jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            jSONToolStripMenuItem.Size = new Size(32, 19);
            // 
            // xMLToolStripMenuItem
            // 
            xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            xMLToolStripMenuItem.Size = new Size(32, 19);
            // 
            // jSONToolStripMenuItem1
            // 
            jSONToolStripMenuItem1.Name = "jSONToolStripMenuItem1";
            jSONToolStripMenuItem1.Size = new Size(32, 19);
            // 
            // xMLToolStripMenuItem1
            // 
            xMLToolStripMenuItem1.Name = "xMLToolStripMenuItem1";
            xMLToolStripMenuItem1.Size = new Size(32, 19);
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(914, 420);
            Controls.Add(button1);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(lstVisorGolosinas);
            Controls.Add(btnAgregar);
            Controls.Add(menuStrip1);
            Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Name = "FrmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            Load += FrmMenuPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button btnEliminar;
        private Button btnModificar;
        private ListBox lstVisorGolosinas;
        private Button btnAgregar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem cRUDToolStripMenuItem;
        private ToolStripMenuItem aGREGARToolStripMenuItem;
        private ToolStripMenuItem cHOCOLATEToolStripMenuItem1;
        private ToolStripMenuItem cHICLEToolStripMenuItem1;
        private ToolStripMenuItem cHUPETINToolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem oToolStripMenuItem;
        private ToolStripMenuItem dESERIALIZARToolStripMenuItem;
        private ToolStripMenuItem jSONToolStripMenuItem;
        private ToolStripMenuItem xMLToolStripMenuItem;
        private ToolStripMenuItem jSONToolStripMenuItem1;
        private ToolStripMenuItem xMLToolStripMenuItem1;
        private ToolStripMenuItem aRCHIVOSToolStripMenuItem;
        private ToolStripMenuItem sERIALIZARToolStripMenuItem2;
        private ToolStripMenuItem jSONToolStripMenuItem2;
        private ToolStripMenuItem xMLToolStripMenuItem2;
        private ToolStripMenuItem dESERIALIZARToolStripMenuItem2;
        private ToolStripMenuItem jSONToolStripMenuItem3;
        private ToolStripMenuItem xMLToolStripMenuItem3;
    }
}