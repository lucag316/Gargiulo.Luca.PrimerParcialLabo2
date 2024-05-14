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
    public partial class FrmChocolate : Form
    {
        private Chocolate chocolate;

        public Chocolate Chocolate
        {
            get { return this.chocolate; }
        }

        public FrmChocolate()
        {
            InitializeComponent();
        }

        public FrmChocolate(Chocolate chocolate) : this()
        {
            //this.chocolate = chocolate;
            //this.txtPrecio.Text = chocolate.precio.ToString();//atributo heredado de golosina
            //this.txtMarca.Text = chocolate.marca;
            //this.txtPopularidad.Text = chocolate.popularidad;
            //this.txtRelleno.Text = chocolate.relleno;
            //this.txtTipoDeCacao.Text = chocolate.tipoDeCacao;
        }

        private void FrmChocolate_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            double precio = Convert.ToDouble(txtPrecio.Text);

            this.chocolate = new Chocolate(txtRelleno.Text, txtTipoDeCacao.Text);

            this.DialogResult = DialogResult.OK;
            //this.Close();//???
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
