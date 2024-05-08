namespace WindowsForm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCorreo.Clear();//limpio los text box
            txtClave.Clear();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "luca" && txtClave.Text == "123")
            {
                FrmLogin frmPrincipal = new FrmLogin();
                //this.Hide();//que hace?
                frmPrincipal.Show();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos", "ERROR");
                txtCorreo.Clear();
                txtClave.Clear();
            }
        }
    }
}