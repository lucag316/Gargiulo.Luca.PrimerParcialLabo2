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
    public partial class FrmEntidades : Form
    {
        public string EntidadSeleccionada { get; private set; }

        public FrmEntidades()
        {
            InitializeComponent();
        }

        private void FrmEntidades_Load(object sender, EventArgs e)
        {
        }

        private void btnChocolate_Click(object sender, EventArgs e)
        {
            FrmChocolate frmChocolate = new FrmChocolate();
            DialogResult dialogResultRta = frmChocolate.ShowDialog();
            if (dialogResultRta == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }

            //AbrirFormDeGolosinaSeleccionada(new FrmChocolate());
        }

        private void AbrirFormDeGolosinaSeleccionada(Form formulario)
        {
            DialogResult dialogResultRta = formulario.ShowDialog();

            if (dialogResultRta == DialogResult.OK)//despues de que el usuario cierra el formulario que abri, esta linea verifica si el usuario hizo clic en aceptar u otra accion que indica que fue exitoso
            {
                EntidadSeleccionada = formulario.Tag.ToString();//guarda dato adicional que el formulario mostrado tenga en la propiedad tag
                this.DialogResult = DialogResult.OK;//si fue exitoso, en este form tambien fue exitoso
            }

        }
    }
}
