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
        }

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
            if (txtCorreo.Text == "luca" && txtClave.Text == "123")
            {
                FrmPrincipal frmPrincipal = new FrmPrincipal();
                //frmPrincipal.StartPosition = FormStartPosition.CenterScreen;//aca no es, ya probe
                this.Hide();//lo oculta, si no lo pongo queda atras del frmPrincipal?
                frmPrincipal.Show();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Clear();
                txtClave.Clear();
            }
        }

        public void DeserializarJSON()
        {
            using (StreamReader streamReader = new StreamReader("./usuarios.json"))
            {
                string jsonUsuarios = streamReader.ReadToEnd();

                this.usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonUsuarios);
            }
        }

    }
}