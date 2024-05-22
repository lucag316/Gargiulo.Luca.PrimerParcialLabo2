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

        public Chocolate MiChocolate { get { return this.miChocolate; } }//propiedad public que devuelve la golosia modificada

        public FrmChocolate() // :base()//ACA VA?O NO?
        {
            InitializeComponent();

            foreach (ERellenos relleno in Enum.GetValues(typeof(ERellenos)))
            {
                this.cboRelleno.Items.Add(relleno);
            }
            this.cboRelleno.SelectedItem = ERellenos.SinRelleno; //valor predeterminado

            foreach (ETiposDeCacao tipoDeCacao in Enum.GetValues(typeof(ETiposDeCacao)))
            {
                this.cboTipoDeCacao.Items.Add(tipoDeCacao);
            }
            this.cboTipoDeCacao.SelectedItem = ETiposDeCacao.Negro; //valor predeterminado
        }

        public FrmChocolate(Chocolate chocolate) : this()
        {
            //ACA VAN LOS DEMAS O NO?
            this.cboRelleno.SelectedItem = chocolate.Relleno;
            this.cboTipoDeCacao.SelectedItem = chocolate.TipoDeCacao;
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

            ERellenos relleno = (ERellenos)this.cboRelleno.SelectedItem;
            ETiposDeCacao tipoDeCacao = (ETiposDeCacao)this.cboTipoDeCacao.SelectedItem;

            //SUPONGO QUE ACA VAN LOS DEMAS DATOS

            this.miChocolate = new Chocolate(codigo, peso, precio, cantidad, relleno, tipoDeCacao);

            base.btnAceptar_Click(sender, e);
        }


    }
}
