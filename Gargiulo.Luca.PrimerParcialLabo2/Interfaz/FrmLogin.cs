using Entidades;
namespace Interfaz
{
    public partial class FrmLogin : Form
    {
        private List<Usuario> usuarios;

        public FrmLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}