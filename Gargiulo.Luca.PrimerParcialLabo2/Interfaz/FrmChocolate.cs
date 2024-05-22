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
    public partial class FrmChocolate : FrmGolosina
    {
        protected Chocolate miChocolate;

        public Chocolate MiChocolate { get { return this.miChocolate; } }

        public FrmChocolate()
        {
            InitializeComponent();
        }

        private void FrmChocolate_Load(object sender, EventArgs e)
        {

        }

        //antes tenia solo dos referencias, me fije que le faltaba viendo ejercicios, y se lo agregue y funciono
        protected override void btnAceptar_Click(object sender, EventArgs e) //heredo del btnAceptar de Golosina
        {
            int codigo = int.Parse(base.txtCodigo.Text);//fijarse en las propiedades del frmGolosinas, que los txtBox sea protected, NO privados
            float precio = float.Parse(base.txtPrecio.Text);
            float peso = float.Parse(base.txtPeso.Text);
            int cantidad = int.Parse(base.txtCantidad.Text);

            this.miChocolate = new Chocolate(codigo, peso, precio, cantidad);

            base.btnAceptar_Click(sender, e);
        }


    }
}
