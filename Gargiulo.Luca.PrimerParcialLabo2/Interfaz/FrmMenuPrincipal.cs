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
using Entidades.Interfaces;
using Entidades.JerarquiaYContenedora;
using Entidades.OtrasClases;
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
        private Kiosco<Golosina> kiosco;
        private string operador;
        private Usuario usuarioLogueado;
        public Task? hiloGuardarBD;
        public Task? hiloCargarBD;
        #endregion

        #region Eventos
        public event DelegadoMensajeMenuHandler? ErrorAlGuardarEnBaseDeDatos;
        public event DelegadoMensajeMenuHandler? ErrorAlCargarDesdeBaseDeDatos;
        public event DelegadoMensajeMenuHandler? GolosinasGuardadasExitosamenteBd;
        public event DelegadoMensajeMenuHandler? GolosinasCargadasExitosamenteBD;
        public event DelegadoMensajeMenuHandler? ErrorAlGuardarEnXML;
        public event DelegadoMensajeMenuHandler? ErrorAlCargarDesdeXML;
        public event DelegadoMensajeMenuHandler? GolosinasGuardadasExitosamenteXML;
        public event DelegadoMensajeMenuHandler? GolosinasCargadasExitosamenteXML;
        #endregion

        #region Constructor

        //// <param name="usuarioLogueado">Usuario que ha iniciado sesión.</param>
        public FrmMenuPrincipal(Usuario usuarioLogueado)
        {
            InitializeComponent();

            this.kiosco = new Kiosco<Golosina>(10);
            Kiosco<Golosina>.CapacidadMaximaAlcanzada += MostrarMessageBoxCapacidadMaxima;
            Kiosco<Golosina>.ProductoYaEstaEnLista += MostrarMessageBoxGolosinaRepetida;
            Kiosco<Golosina>.ProductoAgregadoExitosamente += MostrarMessageBoxGolosinaAgregadaExitosamente;
            Kiosco<Golosina>.ProductoEliminadoExitosamente += MostrarMessageBoxGolosinaEliminadaExitosamente;
            //Kiosco<Golosina>.GolosinaModificadaExitosamente += KioscoGolosinaModificada;

            this.ErrorAlGuardarEnBaseDeDatos += MostrarMensajeDeError;
            this.ErrorAlCargarDesdeBaseDeDatos += MostrarMensajeDeError;
            this.GolosinasGuardadasExitosamenteBd += MostrarMensajeDeInformacion;
            this.GolosinasCargadasExitosamenteBD += MostrarMensajeDeInformacion;
            this.ErrorAlGuardarEnXML += MostrarMensajeDeError;
            this.ErrorAlCargarDesdeXML += MostrarMensajeDeError;
            this.GolosinasGuardadasExitosamenteXML += MostrarMensajeDeInformacion;
            this.GolosinasCargadasExitosamenteXML += MostrarMensajeDeInformacion;

            this.operador = usuarioLogueado.nombre;
            this.usuarioLogueado = usuarioLogueado;

            this.btnGuardarEnBaseDeDatos.Click += new EventHandler(this.ManejadorGuardarEnBaseDeDatos); //genero manejadores de eventos dinamicos
            this.btnCargarDesdeBaseDeDatos.Click += new EventHandler(this.ManejadorAbrirDesdeBaseDeDatos);
            
            ConfigurarComboBoxes();
            ConfigurarPermisos();
            AsignarHora();
        }
        #endregion

        #region Manejadores con utilizacion de hilos
        /// <summary>
        /// Actualiza continuamente el control lblHora con la hora actual, incluyendo segundos.
        /// Ejecuta la actualizacion en un hilo secundario para evitar bloqueos en la interfaz de usuario.
        /// </summary>
        private void AsignarHora()
        {
            // Lo ejecuto continuamente en un hilo secundario(es para que vaya mostrando la hora con segundos y todo)
            Task.Run(async () =>
            {
                while (true)
                {
                    Invoke(new Action(() =>
                    {
                        lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
                    }));
                    await Task.Delay(1000);  //lo estey haciendo esperar 1 seg cada vez..
                }
            });
        }

        /// <summary>
        /// Maneja el evento de guardar golosinas en la base de datos.
        /// Crea un Task que espera 3 segundos y luego llama al metodo GuardarGolosinasEnBaseDeDatos en un hilo separado.
        /// </summary>
        //// <param name="sender">El objeto que desencadenó el evento.</param>
        //// <param name="e">Argumentos del evento.</param>
        private void ManejadorGuardarEnBaseDeDatos(object? sender, EventArgs e)//por cada click que haga en este boton, instancio el Task invocando al metodo
        {
            Task.Delay(3000).Wait();
            this.hiloGuardarBD = Task.Run(() => this.GuardarGolosinasEnBaseDeDatos());
        }

        /// <summary>
        /// Maneja el evento de abrir golosinas desde la base de datos.
        /// Crea un Task que espera 3 segundos y luego llama al metodo CargarGolosinasDesdeBaseDeDatos en un hilo separado.
        /// </summary>
        //// <param name="sender">El objeto que desencadenó el evento.</param>
        //// <param name="e">Argumentos del evento.</param>
        private void ManejadorAbrirDesdeBaseDeDatos(object? sender, EventArgs e)
        {
            // Esperar 3 segundos en el hilo principal
            Task.Delay(3000).Wait();
            this.hiloCargarBD = Task.Run(() => this.CargarGolosinasDesdeBaseDeDatos());
        }
        #endregion

        #region Mostrar mensajes de eventos kiosco
        private void MostrarMessageBoxCapacidadMaxima(string mensaje)
        {
            MessageBox.Show($"Error: {mensaje}", "Capacidad Maxima Alcanzada", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MostrarMessageBoxGolosinaRepetida(string mensaje)
        {
            MessageBox.Show($"Advertencia: {mensaje}", "Golosina Repetida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MostrarMessageBoxGolosinaAgregadaExitosamente(string mensaje)
        {
            MessageBox.Show(mensaje, "Golosina Agregada Exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MostrarMessageBoxGolosinaEliminadaExitosamente(string mensaje)
        {
            MessageBox.Show(mensaje, "Golosina Eliminada Exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Mostrar mensaje de eventos menu

        private void MostrarMensajeDeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MostrarMensajeDeInformacion(string mensaje)
        {
            MessageBox.Show(mensaje, "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion


        #region Manejadores de eventos 

        #region Load y Closing
        /// <summary>
        /// Maneja el evento de carga del formulario principal. Configura el formulario como contenedor MDI, 
        /// actualiza la barra de informaciOn y el visor de golosinas.
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto EventArgs que contiene los datos del evento.</param>
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ActualizarBarraDeInformacion();
            ActualizarVisorGolosinas();
        }

        /// <summary>
        /// Maneja el evento de cierre del formulario principal. Muestra un mensaje de confirmaciOn antes de cerrar
        /// el formulario y cancela el cierre si el usuario selecciona "No".
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto FormClosingEventArgs que contiene los datos del evento.</param>
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
        /// <summary>
        /// Muestra el formulario para agregar un chocolate y lo añade al kiosco si el usuario confirma.
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto EventArgs que contiene los datos del evento.</param>
        private void cHOCOLATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChocolate frmChocolate = new FrmChocolate();
            frmChocolate.ShowDialog();

            if (frmChocolate.DialogResult == DialogResult.OK)
            {
                this.AgregarGolosina(frmChocolate.MiChocolate);
            }
        }
        /// <summary>
        /// Muestra el formulario para agregar un chicle y lo añade al kiosco si el usuario confirma.
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto EventArgs que contiene los datos del evento.</param>
        private void cHICLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChicle frmChicle = new FrmChicle();
            frmChicle.ShowDialog();

            if (frmChicle.DialogResult == DialogResult.OK)
            {
                this.AgregarGolosina(frmChicle.MiChicle);
            }
        }
        /// <summary>
        /// Muestra el formulario para agregar un chupetin y lo añade al kiosco si el usuario confirma.
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto EventArgs que contiene los datos del evento.</param>
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
        /// <summary>
        /// Muestra el formulario para modificar una golosina seleccionada del kiosco.
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto EventArgs que contiene los datos del evento.</param>
        private void mODIFICARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = this.lstVisorGolosinas.SelectedIndex;//el indice que selecciono

            if (i < 0)
            {
                MessageBox.Show("Por favor, seleccione una golosina para modificar.", "Seleccion requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Golosina golosinaSeleccionada = kiosco.Productos[i];//la golosina que seleccione en el visor

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
                        kiosco.Productos[i] = frmChocolate.MiChocolate; //lo modifico
                    }
                    else if (frmGolosina is FrmChicle frmChicle)
                    {
                        kiosco.Productos[i] = frmChicle.MiChicle;
                    }
                    else if (frmGolosina is FrmChupetin frmChupetin)
                    {
                        kiosco.Productos[i] = frmChupetin.MiChupetin;
                    }

                    this.ActualizarVisorGolosinas();
                }
            }
        }

        /// <summary>
        /// Elimina una golosina seleccionada del kiosco despues de una confirmacion del usuario.
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto EventArgs que contiene los datos del evento.</param>
        private void eLIMINARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = this.lstVisorGolosinas.SelectedIndex;

            if (i < 0)
            {
                MessageBox.Show("Por favor, seleccione una golosina para eliminar.", "Seleccion requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Esta seguro que desea eliminar esta golosina?", "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                //this.kiosco.Golosinas.RemoveAt(i); //lo elimino
                kiosco -= kiosco.Productos[i]; //lo elimino
                this.ActualizarVisorGolosinas();
            }
        }
        #endregion

        #region Ordenar
        /// <summary>
        /// Ordena las golosinas segun el criterio seleccionado en el ComboBox correspondiente.
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto EventArgs que contiene los datos del evento.</param>
        private void cboOrden_SelectedIndexChanged(object? sender, EventArgs e) //el signo es para que no me tire advertencia de null
        {
            OrdenarGolosinas();
        }
        /// <summary>
        /// Ordena las golosinas segun el criterio de manera seleccionado en el ComboBox correspondiente.
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto EventArgs que contiene los datos del evento.</param>
        private void cboOrdenManera_SelectedIndexChanged(object? sender, EventArgs e)
        {
            OrdenarGolosinas();
        }
        #endregion

        #region Archivos
        /// <summary>
        /// Maneja el evento de clic para guardar los datos del kiosco en un archivo XML.
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto EventArgs que contiene los datos del evento.</param>
        private void xMLToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.GuardarXML();
        }

        /// <summary>
        /// Maneja el evento de clic para abrir un archivo XML y cargar los datos del kiosco.
        //// </summary>
        //// <param name="sender">El origen del evento.</param>
        private void xMLToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.AbrirXML();
        }

        #endregion

        #region Volver, Detalle e Informacion
        /// <summary>
        /// Maneja el evento de clic para volver al formulario de login. 
        /// Pregunta al usuario si esta seguro de querer volver y, si es asi, cierra el formulario actual y muestra el formulario de login.
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto EventArgs que contiene los datos del evento.</param>
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
        /// Maneja el evento de clic para mostrar el detalle del kiosco en un formulario.
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto EventArgs que contiene los datos del evento.</param>
        private void dETALLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetalleKiosco frmDetalleKiosco = new FrmDetalleKiosco();

            frmDetalleKiosco.MostrarDetalleEnVisor(this.kiosco.MostrarListaEnVisorDetalle());

            frmDetalleKiosco.ShowDialog();
        }

        /// <summary>
        /// Maneja el evento de clic para mostrar información sobre los descuentos aplicables a las golosinas.
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto EventArgs que contiene los datos del evento.</param>
        private void iNFORMACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine("");
            info.AppendLine("=========== DESCUENTOS ===========");
            info.AppendLine("CHOCOLATE: Si la cantidad es mayor a 3, tiene un 30% de descuento");
            info.AppendLine("CHICLE: Si la cantidad es mayor a 5, tiene un 15% de descuento");
            info.AppendLine("CHUPETIN: No tiene descuento");
            info.AppendLine("=================================");
            info.AppendLine("");

            string infosString = info.ToString();

            MessageBox.Show(infosString, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        #endregion

        #region Visualizador usuarios logeados

        /// <summary>
        /// Maneja el evento de clic para abrir un formulario que muestra el registro de usuarios logueados.
        /// </summary>
        //// <param name="sender">El origen del evento.</param>
        //// <param name="e">Un objeto EventArgs que contiene los datos del evento.</param>
        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisualizadorUsuariosLog frmVisualizadorUsuariosLog = new FrmVisualizadorUsuariosLog("usuarios.log");
            frmVisualizadorUsuariosLog.ShowDialog();
        }

        #endregion

        #endregion


        #region Metodos de configuracion
        /// <summary>
        /// Configura los ComboBoxes para la seleccion de criterios y maneras de ordenamiento.
        /// </summary>
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

        /// <summary>
        /// Configura los permisos de los usuarios segun su perfil.
        /// </summary>
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

                    btnGuardarEnBaseDeDatos.Enabled = false;
                    btnGuardarEnBaseDeDatos.Visible = false;

                    GuardarToolStripMenuItem2.Enabled = false;
                    GuardarToolStripMenuItem2.Visible = false;


                    break;
            }
        }
        #endregion

        #region Metodos de ordenamiento
        /// <summary>
        /// Ordena las golosinas del kiosco segun el criterio seleccionado.
        /// </summary>
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
                        this.kiosco.Ordenar(g => g.Codigo, g => g.Codigo, ascendente); // lo pongo asi por la interfaz
                        break;
                    case EOrdenes.PorPrecio:
                        this.kiosco.Ordenar(g => g.Precio, g => g.Precio, ascendente);
                        break;
                    case EOrdenes.PorPeso:
                        this.kiosco.Ordenar(g => g.Peso, g => g.Peso, ascendente);
                        break;
                    case EOrdenes.PorCantidad:
                        this.kiosco.Ordenar(g => g.Cantidad, g => g.Cantidad, ascendente);
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
        public void ActualizarBarraDeInformacion()
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

            foreach (Golosina golosina in kiosco.Productos)
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
                        this.kiosco.Productos.Clear();
                        this.kiosco += golosinasDeserializadas;
                        this.ActualizarVisorGolosinas();
                        this.GolosinasCargadasExitosamenteXML?.Invoke("Lista de golosinas cargada correctamente desde el archivo XML");
                        //MessageBox.Show("Lista de golosinas cargada correctamente desde el archivo XML.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show($"Error al cargar golosinas: {ex.Message}\n{ex.InnerException?.Message}");
                    }
                    catch (Exception)
                    {
                        this.ErrorAlCargarDesdeXML?.Invoke("Error al cargar golosinas");
                        //MessageBox.Show($"Error al cargar golosinas: {ex.Message}");
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

                        SerializadorXML<Golosina>.Serializar(this.kiosco.Productos, pathArchivo);

                        this.GolosinasGuardadasExitosamenteXML?.Invoke("Lista de golosinas guardada correctamente en un archivo XML.");
                        //MessageBox.Show("Lista de golosinas guardada correctamente en un archivo XML.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show($"Error al guardar golosinas: {ex.Message}\n{ex.InnerException?.Message}");
                    }
                    catch (Exception)
                    {
                        this.ErrorAlGuardarEnXML?.Invoke("Error al guardar golosinas");
                        //MessageBox.Show($"Error al guardar golosinas: {ex.Message}");
                    }
                }
            }
        }


        #endregion

        #region Metodos de Base De Datos
        /// <summary>
        /// Guarda las golosinas en la base de datos
        /// </summary>
        private void GuardarGolosinasEnBaseDeDatos()
        {
            //tengo que hacerlo desde el hilo principal
            if (this.btnCargarDesdeBaseDeDatos.InvokeRequired)//si alguien invoco desde otro subprocesosi alguien solicito cambiar este elemento
            {
                DelegadotaskHandler delegadotask = new DelegadotaskHandler(this.GuardarGolosinasEnBaseDeDatos);//genero un delegado dentro del subproceso que invoque al mismo metodo
                this.btnGuardarEnBaseDeDatos.Invoke(delegadotask);//desde el hilo principal invoco al subproceso

            }
            else
            {
                bool exito = GuardarGolosinas();
                if (exito)
                {
                    this.GolosinasGuardadasExitosamenteBd?.Invoke("Golosinas guardadas en la base de datos exitosamente");
                    //MessageBox.Show("Golosinas guardadas correctamente en la base de datos.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.ErrorAlGuardarEnBaseDeDatos?.Invoke("Error al guardar golosinas en la base de datos.");
                    //MessageBox.Show("Error al guardar golosinas en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        /// <summary>
        /// Carga las golosinas desde la base de datos 
        /// </summary>
        private void CargarGolosinasDesdeBaseDeDatos()
        {
            
            if (this.btnCargarDesdeBaseDeDatos.InvokeRequired)
            {
                DelegadotaskHandler delegadotask = new DelegadotaskHandler(this.CargarGolosinasDesdeBaseDeDatos);
                this.btnCargarDesdeBaseDeDatos.Invoke(delegadotask);
            }
            else
            {
                bool exito = CargarGolosinas();
                if (exito)
                {
                    this.GolosinasCargadasExitosamenteBD?.Invoke("Golosinas cargadas exitosamente desde la base de datos");
                    //MessageBox.Show("Golosinas cargadas correctamente desde la base de datos.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarVisorGolosinas(); 
                }
                else
                {
                    this.ErrorAlCargarDesdeBaseDeDatos?.Invoke("Error al cargar golosinas desde la base de datos");
                    //MessageBox.Show("Error al cargar golosinas desde la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Carga las golosinas desde la base de datos.
        /// </summary>
        /// <returns>Retorna true si la operación fue exitosa, de lo contrario false.</returns>
        private bool CargarGolosinas()
        {
            bool retorno = true;
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();

                // cargar golosinas desde la base de datos
                List<Golosina> golosinasBD = accesoDatos.ObtenerListaGolosinas();

                kiosco.Productos.Clear(); // limpio la lista actual
                                          //kiosco += golosinasBD; // NOSE PORQUE NO ME DEJA DE ESTA MANERA cargo la de la abse de datos
                if (golosinasBD == null)
                {
                    Console.WriteLine("La lista de golosinas desde la base de datos es nula.");
                    retorno = false;
                }
                else
                {
                    foreach (Golosina golosina in golosinasBD)
                    {
                        kiosco.Productos.Add(golosina);
                    }
                    ActualizarVisorGolosinas(); // actualizo despues de cargar
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar golosinas desde la base de datos: " + ex.Message);
                retorno = false;
            }
            return retorno;
        }

        /// <summary>
        /// Guarda las golosinas en la base de datos.
        /// </summary>
        /// <returns>Retorna true si la operación fue exitosa, de lo contrario false.</returns>
        private bool GuardarGolosinas()
        {
            bool retorno = true;
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                accesoDatos.BorrarTodasLasGolosinas();// SI QUIERO QUE SE MANTENGAN LOS DATOS, SACAR ESTA LINEA

                foreach (Golosina golosina in kiosco.Productos) //guardar todas las golosinas en la base de datos
                {
                    bool exito = accesoDatos.AgregarGolosina(golosina);
                    if (!exito)
                    {
                        retorno = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar golosinas en la base de datos: " + ex.Message);
                retorno = false;
            }
            return retorno;
        }
        #endregion

        #region Metodo Agregar
        /// <summary>
        /// Agrega una golosina al kiosco, ordena las golosinas y actualiza el visor de golosinas.
        /// </summary>
        //// <param name="golosina">La golosina a agregar.</param>
        private void AgregarGolosina(Golosina golosina)
        {
            if (this.kiosco.Productos.Count < this.kiosco.CapacidadProductosDistintos)
            {
                if (this.kiosco != golosina)
                {
                    this.kiosco += golosina;
                    OrdenarGolosinas(false); //para que se ordene por defecto
                    this.ActualizarVisorGolosinas(); // ver que diferencia hay si lo pongo arriba de ordenar
                }
                else
                {
                    MostrarMessageBoxGolosinaRepetida("La golosina ya esta en el kiosco");
                }
            }
            else
            {
                MostrarMessageBoxCapacidadMaxima("Se alcanzo la capacidad maxima de la lista de productos");
            }
        }
        #endregion
    }
}
