using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Interfaz
{
    public partial class FrmMenuPrincipal : Form
    {
        List<Golosina> golosinas;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            this.golosinas = new List<Golosina>();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void ActualizarVisorGolosinas()
        {
            this.lstVisorGolosinas.Items.Clear();//limpio para no duplicar ni agregar cosas

            foreach(Golosina golosina in this.golosinas)
            {//LLAMARIA A UN MOSTRAR EN VISOR DE LAS CLASES, ASI SE VE BIEN
                this.lstVisorGolosinas.Items.Add(golosina.ToString());//ver bien porque hay varios tipos de golosinas
                //this.lstVisorGolosinas.Text += golosina.ToString();//para un richBox, aca no creo que funcione
            }
        }

        private void cHOCOLATEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmChocolate frmChocolate = new FrmChocolate();
            frmChocolate.ShowDialog(); //lo muestro en forma modal

            if (frmChocolate.DialogResult == DialogResult.OK)
            {
                this.golosinas.Add(frmChocolate.MiChocolate);
                this.ActualizarVisorGolosinas();
            }
        }


    }
}
