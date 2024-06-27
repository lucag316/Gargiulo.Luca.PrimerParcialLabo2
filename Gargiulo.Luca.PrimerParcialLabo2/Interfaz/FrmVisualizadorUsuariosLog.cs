using Entidades.OtrasClases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class FrmVisualizadorUsuariosLog : Form
    {
        private UsuarioLog usuarioLog;

        public FrmVisualizadorUsuariosLog(string logFilePath) //paso la ruta del archivo de registro de usuarios
        {
            InitializeComponent();
            this.usuarioLog = new UsuarioLog(logFilePath);
            MostrarLog();
        }

        private void FrmVisualizadorUsuariosLog_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Muestra el contenido del archivo de registro de usuarios en el ListBox.
        /// </summary>
        private void MostrarLog()
        {
            string logInfo = this.usuarioLog.LeerLog(); //leo el contenido del archivo
            
            string[] lines = logInfo.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); // divido el contenido por líneas, por el split

            this.lstVisualizadorUsuariosLog.Items.Clear();

            foreach (string line in lines)
            {
                this.lstVisualizadorUsuariosLog.Items.Add(line); // Agrego cada linea a la lista
            }
        }
    }
}
