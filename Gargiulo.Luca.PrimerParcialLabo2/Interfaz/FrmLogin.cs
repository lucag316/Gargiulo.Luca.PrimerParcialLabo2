using Entidades;


namespace Interfaz
{
    public partial class FrmLogin : Form
    {
        private List<Usuario> usuarios;

        private string pathJsonUsuarios = "C:\\Users\\luca_\\Desktop\\Labo2 primerParcial\\Gargiulo.Luca.PrimerParcialLabo2\\Gargiulo.Luca.PrimerParcialLabo2\\usuarios.json";

        public FrmLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.usuarios = Serializadora.DeserializarUsuariosJSON(pathJsonUsuarios);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private bool VerificarUsuario(string correo, string clave)
        {
            bool estaElUsuario = false;

            foreach (Usuario usuario in this.usuarios)
            {
                if (usuario.correo == correo && usuario.clave == clave)
                {
                    estaElUsuario = true;
                    break;//rompo el bucle
                }
            }
            return estaElUsuario;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            bool usuarioValidado = VerificarUsuario(txtCorreo.Text, txtClave.Text);

            if (usuarioValidado)
            {
                FrmMenuPrincipal frmMenuPrincipal = new FrmMenuPrincipal();
                frmMenuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Clear();
                txtClave.Clear();
            }
        }

        
    }
}