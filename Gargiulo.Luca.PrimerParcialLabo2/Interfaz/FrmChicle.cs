using Entidades.JerarquiaYContenedora;
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
    /// Formulario para ingresar informacion especifica de un chicle.
    /// </summary>
    public partial class FrmChicle : FrmGolosina
    {
        #region Atributos
        protected Chicle miChicle;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el objeto Chicle modificado o creado en el formulario.
        /// </summary>
        public Chicle MiChicle 
        { 
            get { return this.miChicle; } 
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de FrmChicle.
        /// </summary>
        public FrmChicle() : base()
        {
            InitializeComponent();
            ConfigurarComboBoxes();
            this.miChicle = new Chicle();
            
        }

        /// <summary>
        /// Constructor que inicializa el formulario con un objeto Chicle existente.
        /// </summary>
        //// <param name="chicle">Objeto Chicle a editar.</param>
        public FrmChicle(Chicle chicle) : this()
        {
            InicializarControlesGenerales(chicle);
        }
        #endregion

        #region Manejadores de eventos
        private void FrmChicle_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Manejador del evento Click del boton Aceptar.
        /// </summary>
        //// <param name="sender">Objeto que envia el evento.</param>
        //// <param name="e">Argumentos del evento.</param>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            base.btnAceptar_Click(sender, e);

            if (this.DialogResult == DialogResult.OK)
            {
                ENivelesDeElasticidad elasticidad = (ENivelesDeElasticidad)this.cboElasticidad.SelectedItem;
                ENivelesDuracionDeSabor duracionSabor = (ENivelesDuracionDeSabor)this.cboDuracionSabor.SelectedItem;
                bool blanqueadordental = this.chkBlanqueadorDental.Checked;

                this.miChicle = new Chicle(int.Parse(txtCodigo.Text),
                                                float.Parse(txtPeso.Text),
                                                float.Parse(txtPrecio.Text),
                                                int.Parse(txtCantidad.Text),
                                                elasticidad,
                                                duracionSabor,
                                                blanqueadordental);
            }
        }
        #endregion

        #region Metodos de inicializacion y configuracion
        /// <summary>
        /// Inicializa los controles del formulario con los datos de un objeto Chicle existente.
        /// </summary>
        //// <param name="chicle">Objeto Chicle a mostrar en los controles.</param>
        public void InicializarControlesGenerales(Chicle chicle)
        {
            txtCodigo.Text = chicle.Codigo.ToString();
            txtPeso.Text = chicle.Peso.ToString();
            txtPrecio.Text = chicle.Precio.ToString();
            txtCantidad.Text = chicle.Cantidad.ToString();

            this.cboElasticidad.SelectedItem = chicle.Elasticidad;
            this.cboDuracionSabor.SelectedItem = chicle.DuracionSabor;
            this.chkBlanqueadorDental.Checked = chicle.BlanqueadorDental;

            this.txtCodigo.Enabled = false;
        }


        /// <summary>
        /// Configura los ComboBoxes del formulario con los valores de los Enums ENivelesDeelasticidad y ENivelesDuracionDelSabor.
        /// </summary>
        public void ConfigurarComboBoxes()
        {
            foreach (ENivelesDeElasticidad elasticidad in Enum.GetValues(typeof(ENivelesDeElasticidad)))
            {
                this.cboElasticidad.Items.Add(elasticidad);
            }
            this.cboElasticidad.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboElasticidad.SelectedItem = ENivelesDeElasticidad.Media;

            foreach (ENivelesDuracionDeSabor duracionSabor in Enum.GetValues(typeof(ENivelesDuracionDeSabor)))
            {
                this.cboDuracionSabor.Items.Add(duracionSabor);
            }
            this.cboDuracionSabor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboDuracionSabor.SelectedItem = ENivelesDuracionDeSabor.Media;
        }
        #endregion
    }
}
