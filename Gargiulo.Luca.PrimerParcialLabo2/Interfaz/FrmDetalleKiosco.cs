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
    public partial class FrmDetalleKiosco : Form
    {
        public FrmDetalleKiosco()
        {
            InitializeComponent();
        }

        private void FrmDetalleKiosco_Load(object sender, EventArgs e)
        {

        }

        public void MostrarDetalleEnVisor(string detalleVisor)
        {
            this.lstVisorDetalleKiosco.Items.Clear();

            this.lstVisorDetalleKiosco.Items.Add(detalleVisor);
        }
    }
}
