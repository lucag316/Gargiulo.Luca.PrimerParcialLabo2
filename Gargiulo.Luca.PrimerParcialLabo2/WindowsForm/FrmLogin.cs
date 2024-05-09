using Entidades;
using System.Text.Json;
using System.Xml.Serialization;

namespace WindowsForm
{
    public partial class FrmLogin : Form
    {
        private List<Usuario> usuarios;

        public FrmLogin()
        {
            InitializeComponent();
            this.usuarios = DeserializarUsuariosJSON("usuarios.json");
        }//C:\\Users\\luca_\\Desktop\\Labo2 primerParcial\\Gargiulo.Luca.PrimerParcialLabo2\\Gargiulo.Luca.PrimerParcialLabo2\\usuarios.json

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {//CREO QUE NI HACE FALTA SI TIRO EL MENSAJE DE ERROR, PERO NO SE QUE FORMA ES MEJOR
            txtCorreo.Clear();//limpio los text box
            txtClave.Clear();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            bool usuarioValidado = VerificarUsuario(txtCorreo.Text, txtClave.Text);

            if (usuarioValidado)
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
            }
        }

        private List<Usuario> DeserializarUsuariosJSON(string pathArchivo)
        {
            using (StreamReader streamReader = new StreamReader(pathArchivo))
            {
                string jsonUsuarios = streamReader.ReadToEnd();

                this.usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonUsuarios);
            }
            return this.usuarios;
        }

        private bool VerificarUsuario(string correo, string clave)
        {
            bool estaElUsuario = false;

            foreach (Usuario usuario in this.usuarios)
            {
                if(usuario.Correo == correo && usuario.Clave == clave)
                {
                    estaElUsuario = true;
                    break; //aca creo que va break para que cuando lo encuentre para de iterar
                }
            }
            return estaElUsuario;
        }

    }
}