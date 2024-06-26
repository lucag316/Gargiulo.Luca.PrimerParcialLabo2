using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Interfaces;
using Entidades.Serializadoras;
using SQL;

namespace Interfaz
{
    /// <summary>
    /// Formulario principal del menu de la aplicacion.
    /// </summary>
    public partial class FrmMenuPrincipal : Form
    {
        #region Atributos
        private Kiosco kiosco;
        private string operador;
        private Usuario usuarioLogueado;
        #endregion

        #region Constructor
        public FrmMenuPrincipal(Usuario usuarioLogueado)
        {
            InitializeComponent();
            this.kiosco = new Kiosco(5);
            this.operador = usuarioLogueado.nombre;
            this.usuarioLogueado = usuarioLogueado;
            //this.usuarioLogueado = new UsuarioLog("usuarios.log");
            ConfigurarComboBoxes();
            ConfigurarPermisos();
        }
        #endregion
        
        
        #region Manejadores de eventos 

        #region Load y Closing
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            ActualizarBarraDeInformacion();
            ActualizarVisorGolosinas();
        }

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
                    Application.Exit(); //si no lo hago me queda abierto en el administrador de tareas, se cierran todos los forms correctamente
                }
            }
        }
        #endregion

        #region Agregar
        //Eventos click para agregar los diferentes tipos de golosina al kiosco
        private void cHOCOLATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChocolate frmChocolate = new FrmChocolate();
            frmChocolate.ShowDialog();

            if (frmChocolate.DialogResult == DialogResult.OK)
            {
                this.AgregarGolosina(frmChocolate.MiChocolate);
            }
        }
        private void cHICLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChicle frmChicle = new FrmChicle();
            frmChicle.ShowDialog();

            if (frmChicle.DialogResult == DialogResult.OK)
            {
                this.AgregarGolosina(frmChicle.MiChicle);
            }
        }
        private void cHUPETINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChupetin frmChupetin = new FrmChupetin();
            frmChupetin.ShowDialog();

            if (frmChupetin.DialogResult == DialogResult.OK)
            {
                this.AgregarGolosina(frmChupetin.MiChupetin);
            }
        }
        #endregion

        #region Modificar y Eliminar
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
        private void cboOrden_SelectedIndexChanged(object? sender, EventArgs e) //el signo es para que no me tire advertencia de null
        {
            OrdenarGolosinas();
        }

        private void cboOrdenManera_SelectedIndexChanged(object? sender, EventArgs e)
        {
            OrdenarGolosinas();
        }
        #endregion

        #region Archivos

        private void xMLToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.GuardarXML();
        }

        private void xMLToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.AbrirXML();
        }

        private void bASEDEDATOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool exito = GuardarGolosinasEnBaseDeDatos();

            if (exito)
            {
                MessageBox.Show("Golosinas guardadas correctamente en la base de datos.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al guardar golosinas en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bASEDEDATOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool exito = CargarGolosinasDesdeBaseDeDatos();

            if (exito)
            {
                MessageBox.Show("Golosinas cargadas correctamente desde la base de datos.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarVisorGolosinas(); // Asegúrate de actualizar el visor después de cargar
            }
            else
            {
                MessageBox.Show("Error al cargar golosinas desde la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Volver, Detalle e Informacion
        /// <summary>
        /// Cierra el formulario actual y muestra el formulario del login.
        /// </summary>
        private void vOLVERToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Esta seguro que desea volver?", "Confirmar Volver", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Hide(); // Cierra el formulario actual 

                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show(); // Muestro el formulario del login
            }
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

        private void iNFORMACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine("");
            info.AppendLine("=========== DESCUENTOS ===========");
            info.AppendLine("CHOCOLATE: Si la cantidad es mayor a 3, tiene un 30% de descuento");
            info.AppendLine("CHICLE: Si la cantidad es mayor a 5, tiene un 15% de descuento");
            info.AppendLine("CHUPETIN: Si la cantidad es mayor a 2, tiene un 20% de descuento");
            info.AppendLine("=================================");
            info.AppendLine("");

            string infosString = info.ToString();

            MessageBox.Show(infosString, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        #endregion

        #region Visualizador usuarios logeados

        /// <summary>
        /// Abre un formulario para visualizar el registro de usuarios.
        /// </summary>
        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisualizadorUsuariosLog frmVisualizadorUsuariosLog = new FrmVisualizadorUsuariosLog("usuarios.log");
            frmVisualizadorUsuariosLog.ShowDialog();
        }

        #endregion

        #endregion


        #region Metodos de configuracion
        public void ConfigurarComboBoxes()
        {
            this.cboOrden.SelectedIndexChanged -= cboOrden_SelectedIndexChanged; //descubro los eventos antes de inicializar sino me tira excepcion
            this.cboOrdenManera.SelectedIndexChanged -= cboOrdenManera_SelectedIndexChanged;

            foreach (EOrdenes orden in Enum.GetValues(typeof(EOrdenes)))
            {
                this.cboOrden.Items.Add(orden);
            }
            this.cboOrden.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboOrden.SelectedItem = EOrdenes.PorCodigo;


            foreach (EOrdenManera ordenManera in Enum.GetValues(typeof(EOrdenManera)))
            {
                this.cboOrdenManera.Items.Add(ordenManera);
            }
            this.cboOrdenManera.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboOrdenManera.SelectedItem = EOrdenManera.Ascendente;

            this.cboOrden.SelectedIndexChanged += cboOrden_SelectedIndexChanged;
            this.cboOrdenManera.SelectedIndexChanged += cboOrdenManera_SelectedIndexChanged;

            OrdenarGolosinas(false);
        }

        private void ConfigurarPermisos()
        {
            switch (usuarioLogueado.perfil)
            {
                case "administrador":
                    break;
                case "supervisor":
                    //no puede eliminar
                    eLIMINARToolStripMenuItem.Enabled = false;
                    eLIMINARToolStripMenuItem.Visible = false;
                    break;
                case "vendedor":
                    //no puede agregar golosinas
                    //no puede modificar  
                    //no puede eliminar
                    // NO SE SI CON SOLO SACAR VISIBILIDAD ESTARIA BIEN
                    eLIMINARToolStripMenuItem.Enabled = false;
                    eLIMINARToolStripMenuItem.Visible = false;

                    mODIFICARToolStripMenuItem.Enabled = false;
                    mODIFICARToolStripMenuItem.Visible = false;

                    aGREGARToolStripMenuItem1.Enabled = false;
                    aGREGARToolStripMenuItem1.Visible = false;

                    xMLToolStripMenuItem2.Enabled = false;
                    xMLToolStripMenuItem2.Visible = false;

                    bASEDEDATOSToolStripMenuItem.Enabled = false;
                    bASEDEDATOSToolStripMenuItem.Visible = false;

                    GuardarToolStripMenuItem2.Enabled = false;
                    GuardarToolStripMenuItem2.Visible = false;
                    break;
            }
        }
        #endregion

        #region Metodos de ordenamiento

        private void OrdenarGolosinas(bool mostrarMensaje = true)
        {
            EOrdenes ordenSeleccionado = (EOrdenes)this.cboOrden.SelectedItem;
            EOrdenManera ordenManeraSeleccionada = (EOrdenManera)this.cboOrdenManera.SelectedItem;

            bool ascendente = ordenManeraSeleccionada == EOrdenManera.Ascendente;
            //ascendente puede ser true o false

            try
            {
                switch (ordenSeleccionado)
                {
                    case EOrdenes.PorCodigo:
                        ((IOrdenable)this.kiosco).OrdenarPorCodigo(ascendente); // lo pongo asi por la interfaz
                        break;
                    case EOrdenes.PorPrecio:
                        ((IOrdenable)this.kiosco).OrdenarPorPrecio(ascendente);
                        break;
                    case EOrdenes.PorPeso:
                        ((IOrdenable)this.kiosco).OrdenarPorPeso(ascendente);
                        break;
                    case EOrdenes.PorCantidad:
                        ((IOrdenable)this.kiosco).OrdenarPorCantidad(ascendente);
                        break;
                }
                this.ActualizarVisorGolosinas(); //creo que solo va aca
                if (mostrarMensaje)
                {
                    MessageBox.Show($"La lista de golosinas fue ordenada {ordenSeleccionado} de manera {ordenManeraSeleccionada} correctamente"); //tratar de que aparezca descendente o descendente
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ordenar golosinas {ordenSeleccionado} de manera: {ordenManeraSeleccionada}: {ex.Message}");
            }

        }
        #endregion

        #region Metodos de actualizacion

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

        #region Metodos de archivos

        // /<summary>
        // Abre un archivo XML que contiene datos de golosinas y los carga en el kiosco.
        // </summary>
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
                        //el profe dijo que seria una por una, separado, no entedi como, video clase 10:30 18/6
                        List<Golosina> golosinasDeserializadas = SerializadorXML<Golosina>.Deserializar(pathArchivo);// Llamo al metodo estatico Deserializar de SerializadorXML<Golosina>
                        //Serializadora deserializadoraXml = new Serializadora(pathArchivo);
                        //List<Golosina> golosinasDeserializadas = deserializadoraXml.DeserialiazarGolosinasXML();
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

                        SerializadorXML<Golosina>.Serializar(this.kiosco.Golosinas, pathArchivo);

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


        #endregion

        #region Metodos de Base De Datos

        private bool GuardarGolosinasEnBaseDeDatos()
        {
            bool retorno = true;
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();

                accesoDatos.BorrarTodasLasGolosinas();// SI QUIERO QUE SE MANTENGAN LOS DATOS, SACAR ESTA LINEA

                foreach (Golosina golosina in kiosco.Golosinas) //guardar todas las golosinas en la base de datos
                {
                    bool exito = accesoDatos.AgregarGolosina(golosina);
                    if (!exito)
                    {
                        retorno = false;
                    }
                }
                //retorno = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar golosinas en la base de datos: " + ex.Message);
                retorno = false;
            }
            return retorno;
        }

        private bool CargarGolosinasDesdeBaseDeDatos()
        {
            bool retorno = true;
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
               
                // cargar golosinas desde la base de datos
                List<Golosina> golosinasBD = accesoDatos.ObtenerListaDato();

                kiosco.Golosinas.Clear(); // limpio la lista actual
                //kiosco += golosinasBD; // NOSE PORQUE NO ME DEJA DE ESTA MANERA cargo la de la abse de datos
                foreach (Golosina golosina in golosinasBD)
                {
                    kiosco.Golosinas.Add(golosina);
                }
                ActualizarVisorGolosinas(); // actualizo despues de cargar

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar golosinas desde la base de datos: " + ex.Message);
                retorno = false;
            }
            return retorno;
        }

        
        #endregion

        #region Metodo Agregar
        private void AgregarGolosina(Golosina golosina)
        {
            if (this.kiosco.Golosinas.Count < this.kiosco.CapacidadGolosinasDistintas)
            {
                if (this.kiosco != golosina)
                {
                    this.kiosco += golosina;
                    OrdenarGolosinas(false); //para que se ordene por defecto
                    this.ActualizarVisorGolosinas(); // ver que diferencia hay si lo pongo arriba de ordenar
                }
                else
                {
                    MessageBox.Show("La golosina ya esta en el kiosco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No se puede agregar mas, se ha alcanzado la capacidad maxima del kiosco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        #endregion

        
    }
}
