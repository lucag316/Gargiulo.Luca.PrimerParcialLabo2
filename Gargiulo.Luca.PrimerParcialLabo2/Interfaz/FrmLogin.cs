using Entidades;
using Entidades.OtrasClases;
using Entidades.Serializadoras;

namespace Interfaz
{
    /// <summary>
    /// Formulario de inicio de sesion que permite autenticar usuarios utilizando credenciales almacenadas en un archivo JSON.
    /// </summary>
    public partial class FrmLogin : Form
    {

        #region Atributos
        private List<Usuario> usuarios = new List<Usuario>(); //si no inicializo me tira advertencia de nulo
        private string pathJsonUsuarios = "../../../../usuarios.json"; // ruta de archivo JSON que tiene los usuarios
        //private string pathJsonUsuarios = "C:\\Users\\luca_\\Desktop\\Labo2 primerParcial\\Gargiulo.Luca.PrimerParcialLabo2\\Gargiulo.Luca.PrimerParcialLabo2\\usuarios.json";
        #endregion

        #region Constructor
        public FrmLogin()
        {
            InitializeComponent();
            this.CenterToScreen();

            try
            {
                this.usuarios = SerializadorJSON<Usuario>.DeserializarUsuariosJSON(pathJsonUsuarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close(); //FIJARME SI VA
            }
        }
        #endregion

        #region Manejadores de eventos
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Intenta autenticar al usuario con las credenciales ingresadas y muestra el formulario principal si la autenticación es exitosa.
        /// </summary>
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Usuario usuarioLogueado = ObtenerUsuario(txtCorreo.Text, txtClave.Text);    //veo si el usuario y contraseña sean validos

            if (usuarioLogueado != null)
            {
                //registro el acceso
                UsuarioLog usuarioLog = new UsuarioLog("usuarios.log");
                usuarioLog.RegistrarAcceso(usuarioLogueado);

                FrmMenuPrincipal frmMenuPrincipal = new FrmMenuPrincipal(usuarioLogueado);
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

        /// <summary>
        /// Pregunta al usuario si desea salir de la aplicacion antes de cerrarla.
        /// </summary>
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
        #endregion

        #region Mis Metodos
        /// <summary>
        /// Busca un usuario en la lista segun el correo electronico y la clave proporcionados.
        /// </summary>
        //// <param name="correo">Correo electronico del usuario.</param>
        //// <param name="clave">Clave del usuario.</param>
        /// <returns>El objeto Usuario correspondiente o null si no se encuentra.</returns>
        private Usuario? ObtenerUsuario(string correo, string clave) //el signo es para que no me advierta por nulos
        {
            try
            {
                if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave))
                {
                    throw new ArgumentNullException("Los parametros correo y clave no pueden estar vacios.");
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
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Retorna null si hay algun problema con los parámetros.
            }
        }
        #endregion

    }
}