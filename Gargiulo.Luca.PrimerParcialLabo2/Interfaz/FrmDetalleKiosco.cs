using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    /// <summary>
    /// Formulario para mostrar el detalle del kiosco.
    /// </summary>
    public partial class FrmDetalleKiosco : Form
    {
        public FrmDetalleKiosco()
        {
            InitializeComponent();
        }

        private void FrmDetalleKiosco_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Muestra el detalle del kiosco en el visor.
        /// </summary>
        public void MostrarDetalleEnVisor(string detalleVisor)
        {
            this.lstVisorDetalleKiosco.Items.Clear();

            string[] lineas = detalleVisor.Split(new[] { Environment.NewLine }, StringSplitOptions.None); //lo divido por lineas(split...)
            foreach (string linea in lineas)
            {
                this.lstVisorDetalleKiosco.Items.Add(linea); //agrego cada linea
            }
        }
    }
}
