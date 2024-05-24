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
    public partial class FrmGolosina : Form
    {
        public FrmGolosina()
        {
            InitializeComponent();
        }

        private void FrmGolosina_Load(object sender, EventArgs e)
        {

        }

        protected virtual void btnAceptar_Click(object sender, EventArgs e)//lo hago virtual para heredarlo, protected porque no puede ser privadi
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desea cancelar?", "Confirmar cancelacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            //this.Close()//FIJARME SI VAN LOS CANCEL ACA
        }
    }
}
