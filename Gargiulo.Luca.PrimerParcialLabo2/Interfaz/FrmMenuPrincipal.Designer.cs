namespace Interfaz
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
            lstVisorGolosinas = new ListBox();
            menuStrip1 = new MenuStrip();
            gOLOSINASToolStripMenuItem = new ToolStripMenuItem();
            aGREGARToolStripMenuItem1 = new ToolStripMenuItem();
            cHOCOLATEToolStripMenuItem = new ToolStripMenuItem();
            cHICLEToolStripMenuItem = new ToolStripMenuItem();
            cHUPETINToolStripMenuItem = new ToolStripMenuItem();
            mODIFICARToolStripMenuItem = new ToolStripMenuItem();
            eLIMINARToolStripMenuItem = new ToolStripMenuItem();
            aRCHIVOSToolStripMenuItem = new ToolStripMenuItem();
            sERIALIZARToolStripMenuItem2 = new ToolStripMenuItem();
            jSONToolStripMenuItem2 = new ToolStripMenuItem();
            xMLToolStripMenuItem2 = new ToolStripMenuItem();
            dESERIALIZARToolStripMenuItem2 = new ToolStripMenuItem();
            jSONToolStripMenuItem3 = new ToolStripMenuItem();
            xMLToolStripMenuItem3 = new ToolStripMenuItem();
            oRDENARToolStripMenuItem = new ToolStripMenuItem();
            pORCODIGOToolStripMenuItem = new ToolStripMenuItem();
            aSCENDENTEToolStripMenuItem = new ToolStripMenuItem();
            dESCENDENTEToolStripMenuItem = new ToolStripMenuItem();
            pORPESOToolStripMenuItem = new ToolStripMenuItem();
            aSCENDENTEToolStripMenuItem1 = new ToolStripMenuItem();
            dESCENDENTEToolStripMenuItem1 = new ToolStripMenuItem();
            uSUARIOSToolStripMenuItem = new ToolStripMenuItem();
            dETALLEToolStripMenuItem = new ToolStripMenuItem();
            iNFORMACIONToolStripMenuItem = new ToolStripMenuItem();
            vOLVERToolStripMenuItem = new ToolStripMenuItem();
            dESERIALIZARToolStripMenuItem = new ToolStripMenuItem();
            jSONToolStripMenuItem = new ToolStripMenuItem();
            xMLToolStripMenuItem = new ToolStripMenuItem();
            jSONToolStripMenuItem1 = new ToolStripMenuItem();
            xMLToolStripMenuItem1 = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            ofdAbrirXml = new OpenFileDialog();
            sfdGuardarXml = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
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
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { gOLOSINASToolStripMenuItem, aRCHIVOSToolStripMenuItem, oRDENARToolStripMenuItem, uSUARIOSToolStripMenuItem, dETALLEToolStripMenuItem, iNFORMACIONToolStripMenuItem, vOLVERToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(914, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // gOLOSINASToolStripMenuItem
            // 
            gOLOSINASToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aGREGARToolStripMenuItem1, mODIFICARToolStripMenuItem, eLIMINARToolStripMenuItem });
            gOLOSINASToolStripMenuItem.Font = new Font("Rockwell", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gOLOSINASToolStripMenuItem.Name = "gOLOSINASToolStripMenuItem";
            gOLOSINASToolStripMenuItem.Size = new Size(87, 20);
            gOLOSINASToolStripMenuItem.Text = "GOLOSINAS";
            // 
            // aGREGARToolStripMenuItem1
            // 
            aGREGARToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { cHOCOLATEToolStripMenuItem, cHICLEToolStripMenuItem, cHUPETINToolStripMenuItem });
            aGREGARToolStripMenuItem1.Name = "aGREGARToolStripMenuItem1";
            aGREGARToolStripMenuItem1.Size = new Size(141, 22);
            aGREGARToolStripMenuItem1.Text = "AGREGAR";
            // 
            // cHOCOLATEToolStripMenuItem
            // 
            cHOCOLATEToolStripMenuItem.Name = "cHOCOLATEToolStripMenuItem";
            cHOCOLATEToolStripMenuItem.Size = new Size(150, 22);
            cHOCOLATEToolStripMenuItem.Text = "CHOCOLATE";
            cHOCOLATEToolStripMenuItem.Click += cHOCOLATEToolStripMenuItem_Click;
            // 
            // cHICLEToolStripMenuItem
            // 
            cHICLEToolStripMenuItem.Name = "cHICLEToolStripMenuItem";
            cHICLEToolStripMenuItem.Size = new Size(150, 22);
            cHICLEToolStripMenuItem.Text = "CHICLE";
            cHICLEToolStripMenuItem.Click += cHICLEToolStripMenuItem_Click;
            // 
            // cHUPETINToolStripMenuItem
            // 
            cHUPETINToolStripMenuItem.Name = "cHUPETINToolStripMenuItem";
            cHUPETINToolStripMenuItem.Size = new Size(150, 22);
            cHUPETINToolStripMenuItem.Text = "CHUPETIN";
            cHUPETINToolStripMenuItem.Click += cHUPETINToolStripMenuItem_Click;
            // 
            // mODIFICARToolStripMenuItem
            // 
            mODIFICARToolStripMenuItem.Name = "mODIFICARToolStripMenuItem";
            mODIFICARToolStripMenuItem.Size = new Size(141, 22);
            mODIFICARToolStripMenuItem.Text = "MODIFICAR";
            mODIFICARToolStripMenuItem.Click += mODIFICARToolStripMenuItem_Click;
            // 
            // eLIMINARToolStripMenuItem
            // 
            eLIMINARToolStripMenuItem.Name = "eLIMINARToolStripMenuItem";
            eLIMINARToolStripMenuItem.Size = new Size(141, 22);
            eLIMINARToolStripMenuItem.Text = "ELIMINAR";
            eLIMINARToolStripMenuItem.Click += eLIMINARToolStripMenuItem_Click;
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
            sERIALIZARToolStripMenuItem2.Size = new Size(154, 22);
            sERIALIZARToolStripMenuItem2.Text = "SERIALIZAR";
            // 
            // jSONToolStripMenuItem2
            // 
            jSONToolStripMenuItem2.Name = "jSONToolStripMenuItem2";
            jSONToolStripMenuItem2.Size = new Size(102, 22);
            jSONToolStripMenuItem2.Text = "JSON";
            jSONToolStripMenuItem2.Click += jSONToolStripMenuItem2_Click;
            // 
            // xMLToolStripMenuItem2
            // 
            xMLToolStripMenuItem2.Name = "xMLToolStripMenuItem2";
            xMLToolStripMenuItem2.Size = new Size(102, 22);
            xMLToolStripMenuItem2.Text = "XML";
            xMLToolStripMenuItem2.Click += xMLToolStripMenuItem2_Click;
            // 
            // dESERIALIZARToolStripMenuItem2
            // 
            dESERIALIZARToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { jSONToolStripMenuItem3, xMLToolStripMenuItem3 });
            dESERIALIZARToolStripMenuItem2.Name = "dESERIALIZARToolStripMenuItem2";
            dESERIALIZARToolStripMenuItem2.Size = new Size(154, 22);
            dESERIALIZARToolStripMenuItem2.Text = "DESERIALIZAR";
            // 
            // jSONToolStripMenuItem3
            // 
            jSONToolStripMenuItem3.Name = "jSONToolStripMenuItem3";
            jSONToolStripMenuItem3.Size = new Size(102, 22);
            jSONToolStripMenuItem3.Text = "JSON";
            jSONToolStripMenuItem3.Click += jSONToolStripMenuItem3_Click;
            // 
            // xMLToolStripMenuItem3
            // 
            xMLToolStripMenuItem3.Name = "xMLToolStripMenuItem3";
            xMLToolStripMenuItem3.Size = new Size(102, 22);
            xMLToolStripMenuItem3.Text = "XML";
            xMLToolStripMenuItem3.Click += xMLToolStripMenuItem3_Click;
            // 
            // oRDENARToolStripMenuItem
            // 
            oRDENARToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pORCODIGOToolStripMenuItem, pORPESOToolStripMenuItem });
            oRDENARToolStripMenuItem.Font = new Font("Rockwell", 9F, FontStyle.Regular, GraphicsUnit.Point);
            oRDENARToolStripMenuItem.Name = "oRDENARToolStripMenuItem";
            oRDENARToolStripMenuItem.Size = new Size(77, 20);
            oRDENARToolStripMenuItem.Text = "ORDENAR";
            // 
            // pORCODIGOToolStripMenuItem
            // 
            pORCODIGOToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aSCENDENTEToolStripMenuItem, dESCENDENTEToolStripMenuItem });
            pORCODIGOToolStripMenuItem.Name = "pORCODIGOToolStripMenuItem";
            pORCODIGOToolStripMenuItem.Size = new Size(152, 22);
            pORCODIGOToolStripMenuItem.Text = "POR CODIGO";
            // 
            // aSCENDENTEToolStripMenuItem
            // 
            aSCENDENTEToolStripMenuItem.Name = "aSCENDENTEToolStripMenuItem";
            aSCENDENTEToolStripMenuItem.Size = new Size(164, 22);
            aSCENDENTEToolStripMenuItem.Text = "ASCENDENTE";
            aSCENDENTEToolStripMenuItem.Click += aSCENDENTEToolStripMenuItem_Click;
            // 
            // dESCENDENTEToolStripMenuItem
            // 
            dESCENDENTEToolStripMenuItem.Name = "dESCENDENTEToolStripMenuItem";
            dESCENDENTEToolStripMenuItem.Size = new Size(164, 22);
            dESCENDENTEToolStripMenuItem.Text = "DESCENDENTE";
            dESCENDENTEToolStripMenuItem.Click += dESCENDENTEToolStripMenuItem_Click;
            // 
            // pORPESOToolStripMenuItem
            // 
            pORPESOToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aSCENDENTEToolStripMenuItem1, dESCENDENTEToolStripMenuItem1 });
            pORPESOToolStripMenuItem.Name = "pORPESOToolStripMenuItem";
            pORPESOToolStripMenuItem.Size = new Size(152, 22);
            pORPESOToolStripMenuItem.Text = "POR PESO";
            // 
            // aSCENDENTEToolStripMenuItem1
            // 
            aSCENDENTEToolStripMenuItem1.Name = "aSCENDENTEToolStripMenuItem1";
            aSCENDENTEToolStripMenuItem1.Size = new Size(164, 22);
            aSCENDENTEToolStripMenuItem1.Text = "ASCENDENTE";
            aSCENDENTEToolStripMenuItem1.Click += aSCENDENTEToolStripMenuItem1_Click;
            // 
            // dESCENDENTEToolStripMenuItem1
            // 
            dESCENDENTEToolStripMenuItem1.Name = "dESCENDENTEToolStripMenuItem1";
            dESCENDENTEToolStripMenuItem1.Size = new Size(164, 22);
            dESCENDENTEToolStripMenuItem1.Text = "DESCENDENTE";
            dESCENDENTEToolStripMenuItem1.Click += dESCENDENTEToolStripMenuItem1_Click;
            // 
            // uSUARIOSToolStripMenuItem
            // 
            uSUARIOSToolStripMenuItem.Font = new Font("Rockwell", 9F, FontStyle.Regular, GraphicsUnit.Point);
            uSUARIOSToolStripMenuItem.Name = "uSUARIOSToolStripMenuItem";
            uSUARIOSToolStripMenuItem.Size = new Size(153, 20);
            uSUARIOSToolStripMenuItem.Text = "USUARIOS LOGUEADOS";
            uSUARIOSToolStripMenuItem.Click += uSUARIOSToolStripMenuItem_Click;
            // 
            // dETALLEToolStripMenuItem
            // 
            dETALLEToolStripMenuItem.Font = new Font("Rockwell", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dETALLEToolStripMenuItem.Name = "dETALLEToolStripMenuItem";
            dETALLEToolStripMenuItem.Size = new Size(71, 20);
            dETALLEToolStripMenuItem.Text = "DETALLE";
            dETALLEToolStripMenuItem.Click += dETALLEToolStripMenuItem_Click;
            // 
            // iNFORMACIONToolStripMenuItem
            // 
            iNFORMACIONToolStripMenuItem.Font = new Font("Rockwell", 9F, FontStyle.Regular, GraphicsUnit.Point);
            iNFORMACIONToolStripMenuItem.Name = "iNFORMACIONToolStripMenuItem";
            iNFORMACIONToolStripMenuItem.Size = new Size(105, 20);
            iNFORMACIONToolStripMenuItem.Text = "INFORMACION";
            // 
            // vOLVERToolStripMenuItem
            // 
            vOLVERToolStripMenuItem.Font = new Font("Rockwell", 9F, FontStyle.Regular, GraphicsUnit.Point);
            vOLVERToolStripMenuItem.Name = "vOLVERToolStripMenuItem";
            vOLVERToolStripMenuItem.Size = new Size(68, 20);
            vOLVERToolStripMenuItem.Text = "VOLVER";
            vOLVERToolStripMenuItem.Click += vOLVERToolStripMenuItem_Click;
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
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3 });
            statusStrip1.Location = new Point(0, 398);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(914, 22);
            statusStrip1.TabIndex = 12;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(72, 17);
            toolStripStatusLabel2.Text = "NOMBRE: ";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(69, 17);
            toolStripStatusLabel3.Text = " -  FECHA: ";
            // 
            // ofdAbrirXml
            // 
            ofdAbrirXml.FileName = "ofdAbrirXml";
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(914, 420);
            Controls.Add(statusStrip1);
            Controls.Add(lstVisorGolosinas);
            Controls.Add(menuStrip1);
            Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Name = "FrmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            FormClosing += FrmMenuPrincipal_FormClosing;
            Load += FrmMenuPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox lstVisorGolosinas;
        private MenuStrip menuStrip1;
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
        private ToolStripMenuItem gOLOSINASToolStripMenuItem;
        private ToolStripMenuItem aGREGARToolStripMenuItem1;
        private ToolStripMenuItem cHOCOLATEToolStripMenuItem;
        private ToolStripMenuItem cHICLEToolStripMenuItem;
        private ToolStripMenuItem cHUPETINToolStripMenuItem;
        private ToolStripMenuItem mODIFICARToolStripMenuItem;
        private ToolStripMenuItem eLIMINARToolStripMenuItem;
        private ToolStripMenuItem oRDENARToolStripMenuItem;
        private ToolStripMenuItem pORCODIGOToolStripMenuItem;
        private ToolStripMenuItem aSCENDENTEToolStripMenuItem;
        private ToolStripMenuItem dESCENDENTEToolStripMenuItem;
        private ToolStripMenuItem pORPESOToolStripMenuItem;
        private ToolStripMenuItem aSCENDENTEToolStripMenuItem1;
        private ToolStripMenuItem dESCENDENTEToolStripMenuItem1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private OpenFileDialog ofdAbrirXml;
        private SaveFileDialog sfdGuardarXml;
        private ToolStripMenuItem dETALLEToolStripMenuItem;
        private ToolStripMenuItem iNFORMACIONToolStripMenuItem;
        private ToolStripMenuItem uSUARIOSToolStripMenuItem;
        private ToolStripMenuItem vOLVERToolStripMenuItem;
    }
}