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
    /// <summary>
    /// Formulario para visualizar el registro de usuarios almacenado en un archivo especifico.
    /// </summary>
    public partial class FrmVisualizadorUsuariosLog : Form
    {
        #region Atributos
        private UsuarioLog usuarioLog;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa el formulario y carga el contenido del archivo de registro de usuarios.
        /// </summary>
        //// <param name="logFilePath">Ruta del archivo de registro de usuarios.</param>
        public FrmVisualizadorUsuariosLog(string logFilePath) //paso la ruta del archivo de registro de usuarios
        {
            InitializeComponent();
            this.usuarioLog = new UsuarioLog(logFilePath);
            MostrarLog();
        }
        #endregion

        #region Manejadores de eventos
        private void FrmVisualizadorUsuariosLog_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Metodo Mostrar
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
        #endregion
    }
}
