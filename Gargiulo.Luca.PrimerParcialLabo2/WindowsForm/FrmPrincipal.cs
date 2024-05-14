using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class FrmPrincipal : Form
    {
        private List<Golosina> golosinas; //crearla pero con esa clase que no hice supongo
        public FrmPrincipal()
        {
            InitializeComponent();
            this.golosinas = new List<Golosina>();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void ActualizarVisor()
        {
            this.lstGolosinas.Items.Clear();

            foreach (Golosina golosina in this.golosinas)
            {
                this.lstGolosinas.Items.Add(golosina.Mostrar());
            }
        }
    }
}
