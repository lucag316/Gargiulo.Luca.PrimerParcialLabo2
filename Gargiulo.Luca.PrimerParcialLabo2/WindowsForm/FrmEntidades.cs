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
    public partial class FrmEntidades : Form
    {
        private Golosina golosina;

        //private List<Golosina> listaGolosinas;
        public Golosina Golosina
        {
            get { return this.golosina; }
        }

        public FrmEntidades()
        {
            InitializeComponent();
            //this.listaGolosinas = new List<Golosina>();
        }

        private void FrmEntidades_Load(object sender, EventArgs e)
        {
        }

        private void btnChocolate_Click(object sender, EventArgs e)
        {
            FrmChocolate frmChocolate = new FrmChocolate();
            frmChocolate.StartPosition = FormStartPosition.CenterScreen;
            DialogResult dialogResultRta = frmChocolate.ShowDialog();
            if (dialogResultRta == DialogResult.OK)
            {
                // Devolver el objeto Chocolate al formulario principal
                // Obtener el Chocolate creado en FrmChocolate y asignarlo a la propiedad Golosina
                //this.golosina = frmChocolate.Chocolate;
                this.DialogResult = DialogResult.OK;
            }

            //AbrirFormDeGolosinaSeleccionada(new FrmChocolate());
        }

        private void AbrirFormDeGolosinaSeleccionada(Form formulario)
        {
            DialogResult dialogResultRta = formulario.ShowDialog();

            if (dialogResultRta == DialogResult.OK)//despues de que el usuario cierra el formulario que abri, esta linea verifica si el usuario hizo clic en aceptar u otra accion que indica que fue exitoso
            {
                //EntidadSeleccionada = formulario.Tag.ToString();//guarda dato adicional que el formulario mostrado tenga en la propiedad tag
                this.DialogResult = DialogResult.OK;//si fue exitoso, en este form tambien fue exitoso
            }

        }

        private void btnChicle_Click(object sender, EventArgs e)
        {
            FrmChicle frmChicle = new FrmChicle();
            frmChicle.StartPosition = FormStartPosition.CenterScreen;
            DialogResult dialogResultRta = frmChicle.ShowDialog();
            if (dialogResultRta == DialogResult.OK)
            {
                // Devolver el objeto Chocolate al formulario principal
                // Obtener el Chocolate creado en FrmChocolate y asignarlo a la propiedad Golosina
                //this.golosina = frmChocolate.Chocolate;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnChupetin_Click(object sender, EventArgs e)
        {
            FrmChupetin frmChupetin = new FrmChupetin();
            frmChupetin.StartPosition = FormStartPosition.CenterScreen;
            DialogResult dialogResultRta = frmChupetin.ShowDialog();
            if (dialogResultRta == DialogResult.OK)
            {
                // Devolver el objeto Chocolate al formulario principal
                // Obtener el Chocolate creado en FrmChocolate y asignarlo a la propiedad Golosina
                //this.golosina = frmChocolate.Chocolate;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
