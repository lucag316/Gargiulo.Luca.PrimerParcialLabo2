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

namespace Interfaz
{
    public partial class FrmChicle : FrmGolosina
    {
        protected Chicle miChicle;

        public Chicle MiChicle { get { return this.miChicle; } }

        public FrmChicle()
        {
            InitializeComponent();
        }

        private void FrmChicle_Load(object sender, EventArgs e)
        {

        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(base.txtCodigo.Text);
            float precio = float.Parse(base.txtPrecio.Text);
            float peso = float.Parse(base.txtPeso.Text);
            int cantidad = int.Parse(base.txtCantidad.Text);

            this.miChicle = new Chicle(codigo, peso, precio, cantidad);

            base.btnAceptar_Click(sender, e);
        }
    }
}
