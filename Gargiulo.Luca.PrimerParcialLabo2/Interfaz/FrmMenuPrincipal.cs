using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Interfaz
{
    /// <summary>
    /// Formulario principal del menu de la aplicacion.
    /// </summary>
    public partial class FrmMenuPrincipal : Form
    {
        private Kiosco kiosco;
        private string operador;
        private UsuarioLog usuarioLogueado;

        public FrmMenuPrincipal(string nombreOperador)
        {
            InitializeComponent();
            this.kiosco = new Kiosco();
            this.operador = nombreOperador;
            this.usuarioLogueado = new UsuarioLog("usuarios.log");
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            ActualizarBarraDeInformacion();
            ActualizarVisorGolosinas();
        }

        #region Metodos

        /// <summary>
        /// Actualiza la barra de informacion con el nombre del operador y la fecha actual.
        /// </summary>
        private void ActualizarBarraDeInformacion()
        {
            this.toolStripStatusLabel2.Text = $"Operador: {this.operador}";
            this.toolStripStatusLabel3.Text = $"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}";
        }

        /// <summary>
        /// Actualiza el visor de golosinas con la lista actual de golosinas del kiosco.
        /// </summary>
        private void ActualizarVisorGolosinas()
        {
            this.lstVisorGolosinas.Items.Clear();//limpio para no duplicar ni agregar cosas

            foreach (Golosina golosina in kiosco.Golosinas)
            {
                this.lstVisorGolosinas.Items.Add(golosina.MostrarEnVisor());
            }
        }
        #endregion

        #region Golosinas
        //Eventos click para agregar los diferentes tipos de golosina al kiosco
        private void cHOCOLATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChocolate frmChocolate = new FrmChocolate();
            frmChocolate.ShowDialog();

            if (frmChocolate.DialogResult == DialogResult.OK)
            {
                this.kiosco += frmChocolate.MiChocolate;
                this.ActualizarVisorGolosinas();
            }
        }
        private void cHICLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChicle frmChicle = new FrmChicle();
            frmChicle.ShowDialog();

            if (frmChicle.DialogResult == DialogResult.OK)
            {
                this.kiosco += frmChicle.MiChicle;
                this.ActualizarVisorGolosinas();
            }
        }
        private void cHUPETINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChupetin frmChupetin = new FrmChupetin();
            frmChupetin.ShowDialog();

            if (frmChupetin.DialogResult == DialogResult.OK)
            {
                this.kiosco += frmChupetin.MiChupetin;
                this.ActualizarVisorGolosinas();
            }
        }

        //Modifica la Golosina que seleccione
        private void mODIFICARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = this.lstVisorGolosinas.SelectedIndex;//el indice que selecciono

            if (i < 0)
            {
                MessageBox.Show("Por favor, seleccione una golosina para modificar.", "Seleccion requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Golosina golosinaSeleccionada = kiosco.Golosinas[i];//la golosina que seleccione en el visor

            FrmGolosina frmGolosina = null;//lo declaro asi despues puedo llamarla

            if (golosinaSeleccionada is Chocolate)
            {
                frmGolosina = new FrmChocolate((Chocolate)golosinaSeleccionada);
            }
            else if (golosinaSeleccionada is Chicle)
            {
                frmGolosina = new FrmChicle((Chicle)golosinaSeleccionada);
            }
            else if (golosinaSeleccionada is Chupetin)
            {
                frmGolosina = new FrmChupetin((Chupetin)golosinaSeleccionada);
            }

            if (frmGolosina != null)
            {
                frmGolosina.ShowDialog();

                if (frmGolosina.DialogResult == DialogResult.OK)
                {
                    if (frmGolosina is FrmChocolate frmChocolate)
                    {
                        kiosco.Golosinas[i] = frmChocolate.MiChocolate; //lo modifico
                    }
                    else if (frmGolosina is FrmChicle frmChicle)
                    {
                        kiosco.Golosinas[i] = frmChicle.MiChicle;
                    }
                    else if (frmGolosina is FrmChupetin frmChupetin)
                    {
                        kiosco.Golosinas[i] = frmChupetin.MiChupetin;
                    }

                    this.ActualizarVisorGolosinas();
                }
            }
        }

        //Elimino la golosina que seleccione
        private void eLIMINARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = this.lstVisorGolosinas.SelectedIndex;

            if (i < 0)
            {
                MessageBox.Show("Por favor, seleccione una golosina para eliminar.", "Seleccion requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Esta seguro que desa eliminar esta golosina?", "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                //this.kiosco.Golosinas.RemoveAt(i); //lo elimino
                this.kiosco -= this.kiosco.Golosinas[i]; //lo elimino
                this.ActualizarVisorGolosinas();
            }
        }
        #endregion

        #region Ordenar

        /// <summary>
        /// Maneja el evento de hacer clic en el elemento de menu para ordenar las golosinas por codigo en orden ascendente.
        /// </summary>
        private void aSCENDENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.kiosco.OrdenarGolosinasPorCodigo(true);
                this.ActualizarVisorGolosinas();
                MessageBox.Show("Lista de golosinas fue ordenada por codigo, forma ascendente, correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ordenar golosinas por codigo ascendente: {ex.Message}");
            }

        }
        private void dESCENDENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.kiosco.OrdenarGolosinasPorCodigo(false);
                this.ActualizarVisorGolosinas();
                MessageBox.Show("Lista de golosinas fue ordenada por codigo, forma descendente, correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ordenar golosinas por codigo descendente: {ex.Message}");
            }
        }
        private void aSCENDENTEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                this.kiosco.OrdenarGolosinasPorPeso(true);
                this.ActualizarVisorGolosinas();
                MessageBox.Show("Lista de golosinas fue ordenada por peso, forma ascendente, correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ordenar golosinas por peso ascendente: {ex.Message}");
            }
        }
        private void dESCENDENTEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                this.kiosco.OrdenarGolosinasPorPeso(false);
                this.ActualizarVisorGolosinas();
                MessageBox.Show("Lista de golosinas fue ordenada por peso, forma descendente, correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ordenar golosinas por peso descendente: {ex.Message}");
            }
        }
        #endregion

        /// <summary>
        /// Abre un archivo XML que contiene datos de golosinas y los carga en el kiosco.
        /// </summary>
        public void AbrirXML()
        {
            using (OpenFileDialog odfAbrirXml = new OpenFileDialog())
            {
                ofdAbrirXml.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                ofdAbrirXml.Title = "Abrir archivo XML";

                if (ofdAbrirXml.ShowDialog() == DialogResult.OK)
                {
                    string pathArchivo = ofdAbrirXml.FileName;

                    if (!File.Exists(pathArchivo))
                    {
                        MessageBox.Show($"El archivo no existe: {pathArchivo}");
                        return;
                    }
                    MessageBox.Show($"Ruta del archivo: {pathArchivo}");
                    try
                    {
                        Serializadora deserializadoraXml = new Serializadora(pathArchivo);
                        List<Golosina> golosinasDeserializadas = deserializadoraXml.DeserialiazarGolosinasXML();
                        this.kiosco.Golosinas.Clear();
                        this.kiosco += golosinasDeserializadas;
                        this.ActualizarVisorGolosinas();
                        MessageBox.Show("Lista de golosinas cargada correctamente desde el archivo XML.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show($"Error al cargar golosinas: {ex.Message}\n{ex.InnerException?.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar golosinas: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Guarda los datos de las golosinas del kiosco en un archivo XML.
        /// </summary>
        public void GuardarXML()
        {
            using (SaveFileDialog sfdGuardarXml = new SaveFileDialog())
            {
                sfdGuardarXml.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                sfdGuardarXml.Title = "Guardar archivo XML";
                sfdGuardarXml.FileName = "Golosinas.xml";

                if (sfdGuardarXml.ShowDialog() == DialogResult.OK)
                {
                    string pathArchivo = sfdGuardarXml.FileName;

                    try
                    {
                        Serializadora serializadoraXml = new Serializadora(pathArchivo);

                        serializadoraXml.SerializarGolosinasXML(this.kiosco.Golosinas);
                        MessageBox.Show("Lista de golosinas guardada correctamente en un archivo XML.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show($"Error al guardar golosinas: {ex.Message}\n{ex.InnerException?.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar golosinas: {ex.Message}");
                    }
                }
            }
        }

        public void AbrirJSON()
        {

        }

        /// <summary>
        /// Guarda los datos de las golosinas del kiosco en un archivo JSON.
        /// </summary>
        public void GuardarJSON()
        {
            using (SaveFileDialog sfdGuardarJson = new SaveFileDialog())
            {
                sfdGuardarJson.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                sfdGuardarJson.Title = "Guardar archivo JSON";
                sfdGuardarJson.FileName = "Golosinas.json";

                if (sfdGuardarJson.ShowDialog() == DialogResult.OK)
                {
                    string pathArchivo = sfdGuardarJson.FileName;

                    try
                    {
                        Serializadora serializadoraJson = new Serializadora(pathArchivo);

                        serializadoraJson.SerializarGolosinasJSON(this.kiosco.Golosinas);
                        MessageBox.Show("Lista de golosinas guardada correctamente en un archivo JSON.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show($"Error al guardar golosinas: {ex.Message}\n{ex.InnerException?.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar golosinas: {ex.Message}");
                    }
                }
            }
        }

        #region Archivos
        private void jSONToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.GuardarJSON();
        }
        private void xMLToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.GuardarXML();
        }
        private void jSONToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                Serializadora deserializadoraJson = new Serializadora("Golosinas", kiosco.Golosinas);
                List<Golosina> golosinasDeserializadas = deserializadoraJson.DeserializarGolosinasJSON();
                this.kiosco.Golosinas.Clear();
                this.kiosco += golosinasDeserializadas; //para no usar AddRange
                this.ActualizarVisorGolosinas();
                MessageBox.Show("Lista de golosinas cargada correctamente desde el archivo JSON.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar golosinas: {ex.Message}");
            }
        }
        private void xMLToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.AbrirXML();
        }
        #endregion

        /// <summary>
        /// Muestra un mensaje de confirmacion antes de cerrar el formulario.
        /// </summary>
        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
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
                    Application.Exit(); //si no lo hago me queda abierto en el administrador de tareas
                }
            }
        }

        /// <summary>
        /// Abre un formulario para visualizar el registro de usuarios.
        /// </summary>
        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisualizadorUsuariosLog frmVisualizadorUsuariosLog = new FrmVisualizadorUsuariosLog("usuarios.log");
            frmVisualizadorUsuariosLog.ShowDialog();
        }

        /// <summary>
        /// Cierra el formulario actual y muestra el formulario del login.
        /// </summary>
        private void vOLVERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual 

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show(); // Muestro el formulario del login
        }

        /// <summary>
        /// Abre un formulario para mostrar el detalle del kiosco.
        /// </summary>
        private void dETALLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetalleKiosco frmDetalleKiosco = new FrmDetalleKiosco();

            frmDetalleKiosco.MostrarDetalleEnVisor(this.kiosco.MostrarDetalleEnVisor());

            frmDetalleKiosco.ShowDialog();
        }
    }
}
