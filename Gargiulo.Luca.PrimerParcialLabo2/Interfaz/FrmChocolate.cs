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
            this.cboRelleno.SelectedItem = chocolate.Relleno;
            this.cboTipoDeCacao.SelectedItem = chocolate.TipoDeCacao;
        }

        private void FrmChocolate_Load(object sender, EventArgs e)
        {

        }

        //antes tenia solo dos referencias, me fije que le faltaba viendo ejercicios, y se lo agregue y funciono
        protected override void btnAceptar_Click(object sender, EventArgs e) //heredo del btnAceptar de Golosina
        {

            base.btnAceptar_Click(sender, e);

            //lo puse en un if porque sino me controlaba la excepcion en FrmGolosina pero cuando pasaba por aca, la volvia a tirar
            if (this.DialogResult == DialogResult.OK)
            {
                ERellenos relleno = (ERellenos)this.cboRelleno.SelectedItem;
                ETiposDeCacao tipoDeCacao = (ETiposDeCacao)this.cboTipoDeCacao.SelectedItem;

                this.miChocolate = new Chocolate(int.Parse(txtCodigo.Text),
                                                float.Parse(txtPeso.Text),
                                                float.Parse(txtPrecio.Text),
                                                int.Parse(txtCantidad.Text),
                                                relleno,
                                                tipoDeCacao);
            }
        }
    }
}
