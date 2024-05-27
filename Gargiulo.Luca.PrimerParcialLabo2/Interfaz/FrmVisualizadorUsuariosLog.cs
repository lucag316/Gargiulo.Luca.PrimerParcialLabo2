using Entidades;
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

        public FrmVisualizadorUsuariosLog(string logFilePath)
        {
            InitializeComponent();
            this.usuarioLog = new UsuarioLog(logFilePath);
            MostrarLog();
        }

        private void FrmVisualizadorUsuariosLog_Load(object sender, EventArgs e)
        {

        }

        private void MostrarLog()
        {
            string logInfo = this.usuarioLog.LeerLog();
            // Dividir el contenido del registro por líneas
            string[] lines = logInfo.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // Limpiar la lista antes de agregar nuevos elementos
            lstVisualizadorUsuariosLog.Items.Clear();

            // Agregar cada línea a la lista
            foreach (string line in lines)
            {
                lstVisualizadorUsuariosLog.Items.Add(line);
            }

        }

    }
}
