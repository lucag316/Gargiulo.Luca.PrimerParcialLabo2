using Entidades;

namespace Interfaz
{
    public partial class FrmLogin : Form
    {
        private List<Usuario> usuarios;
        private string pathJsonUsuarios = "../../../../usuarios.json";
        //private string pathJsonUsuarios = "C:\\Users\\luca_\\Desktop\\Labo2 primerParcial\\Gargiulo.Luca.PrimerParcialLabo2\\Gargiulo.Luca.PrimerParcialLabo2\\usuarios.json";

        public FrmLogin()
        {
            InitializeComponent();
            this.CenterToScreen();

            try
            {
                this.usuarios = Serializadora.DeserializarUsuariosJSON(pathJsonUsuarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close(); //FIJARME SI VA
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Busca un usuario en la lista segun el correo electronico y la clave proporcionados.
        /// </summary>
        //// <param name="correo">Correo electronico del usuario.</param>
        //// <param name="clave">Clave del usuario.</param>
        /// <returns>El objeto Usuario correspondiente o null si no se encuentra.</returns>
        private Usuario ObtenerUsuario(string correo, string clave)
        {
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave))
            {
                throw new ArgumentNullException();
            }

            foreach (Usuario usuario in this.usuarios)
            {
                if (usuario.correo.ToLower() == correo.ToLower() && usuario.clave == clave)
                {
                    return usuario;
                }
            }
            return null;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Usuario usuarioLogueado = ObtenerUsuario(txtCorreo.Text, txtClave.Text);    //veo si el usuario y contraseña se validos


            if (usuarioLogueado != null)
            {
                //registro el acceso
                UsuarioLog usuarioLog = new UsuarioLog("usuarios.log");
                usuarioLog.RegistrarAcceso(usuarioLogueado);

                FrmMenuPrincipal frmMenuPrincipal = new FrmMenuPrincipal(usuarioLogueado.nombre);
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

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show("Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true; // lo cancelo al cierre
                }
                else
                {
                    Application.Exit(); //si no lo hago me queda abierto en el administrador de tareas, se cierran todos los forms correctamente
                }
            }
            
        }
    }
}