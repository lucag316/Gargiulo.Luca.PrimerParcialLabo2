using Entidades;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace WindowsForm
{
    public partial class FrmLogin : Form
    {
        private List<Usuario> usuarios;
        public int intentos = 0;

        private string pathJsonUsuarios = "C:\\Users\\luca_\\Desktop\\Labo2 primerParcial\\Gargiulo.Luca.PrimerParcialLabo2\\Gargiulo.Luca.PrimerParcialLabo2\\WindowsForm\\usuarios.json";
        public FrmLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.usuarios = DeserializarUsuariosJSON(this.pathJsonUsuarios);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }


        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            bool usuarioValidado = VerificarUsuario(txtCorreo.Text, txtClave.Text);

            if (usuarioValidado)
            {
                FrmPrincipal frmPrincipal = new FrmPrincipal();
                frmPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Clear();
                txtClave.Clear();
                this.intentos++;
            }



            /*if (this.intentos <= 3)
            {
                if (this.usuarios != null)
                {
                    bool usuarioValidado = false;



                    foreach (Usuario usuario in this.usuarios)
                    {
                        if (txtCorreo.Text == usuario.Correo && txtClave.Text == usuario.Clave)//tratar de hacerlo con verificarUsuario
                        {
                            usuarioValidado = true;
                            break;
                        }
                        
                    }
                    if (usuarioValidado)
                    {
                        FrmPrincipal frmPrincipal = new FrmPrincipal();
                        frmPrincipal.Show();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Datos Incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCorreo.Clear();
                        txtClave.Clear();
                        this.intentos++;
                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar usuarios.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //mensaje de a pasado el numero de intentos permitidos
                    //this.Close();
                }

            }
            else
            {
                MessageBox.Show("Ha excedido el número de intentos permitidos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Otra acción en caso de exceder el número de intentos
            }*/

            /*if (usuarioValidado)
            {
                FrmPrincipal frmPrincipal = new FrmPrincipal();
                //frmPrincipal.StartPosition = FormStartPosition.CenterScreen;//aca no es, ya probe
                this.Hide();//lo oculta, si no lo pongo queda atras del frmPrincipal?
                frmPrincipal.Show();
                MessageBox.Show("Inicio de sesion exitoso");
            }
            else
            {
                MessageBox.Show("Datos Incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Clear();
                txtClave.Clear();
            }*/
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCorreo.Clear();
            txtClave.Clear();
        }

        private List<Usuario> DeserializarUsuariosJSON(string pathArchivo)
        {
            List<Usuario> listaAux = new List<Usuario>();

            using (StreamReader streamReader = new StreamReader(pathArchivo))
            {
                string jsonUsuarios = streamReader.ReadToEnd();

                listaAux = JsonSerializer.Deserialize<List<Usuario>>(jsonUsuarios);
            }
            return listaAux;
        }

        /*private List<Usuario> DeserializarUsuariosJSON(string pathArchivo)
        {
            string jsonString = File.ReadAllText(pathArchivo);// lee el contenido del JSON en una cadena
        
            List<Usuario> listaUsuarios =  JsonSerializer.Deserialize<List<Usuario>>(jsonString);

            return listaUsuarios;
        }*/

        private bool VerificarUsuario(string correo, string clave)
        {
            bool estaElUsuario = false;

            foreach (Usuario usuario in this.usuarios)
            {
                if(usuario.correo == correo && usuario.clave == clave)
                {
                    estaElUsuario = true;
                    break;
                }
            }
            return estaElUsuario;
        }
    }
}