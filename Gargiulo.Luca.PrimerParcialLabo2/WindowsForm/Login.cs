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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCorreo.Clear();//limpio los text box
            txtContraseña.Clear();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "luca" && txtContraseña.Text == "123")
            {
                FrmLogin frmPrincipal = new FrmLogin();
                //this.Hide();//que hace?
                frmPrincipal.Show();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos", "ERROR");
                txtCorreo.Clear();
                txtContraseña.Clear();
            }
        }
    }
}
