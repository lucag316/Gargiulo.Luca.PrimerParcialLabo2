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
    public partial class FrmChupetin : FrmGolosina
    {
        protected Chupetin miChupetin;

        public Chupetin MiChupetin { get { return this.miChupetin; } }

        public FrmChupetin()
        {
            InitializeComponent();
        }

        private void FrmChupetin_Load(object sender, EventArgs e)
        {

        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(base.txtCodigo.Text);//fijarse en las propiedades del frmGolosinas, que los txtBox sea protected, NO privados
            float precio = float.Parse(base.txtPrecio.Text);
            float peso = float.Parse(base.txtPeso.Text);
            int cantidad = int.Parse(base.txtCantidad.Text);

            this.miChupetin = new Chupetin(codigo, peso, precio, cantidad);

            base.btnAceptar_Click(sender, e);
        }

    }
}
