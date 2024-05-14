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

        private void FrmChocolate_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string detalle = $"Precio: {txtPrecio.Text}";
            this.Tag = detalle;
            this.DialogResult = DialogResult.OK;
        }
    }
}
