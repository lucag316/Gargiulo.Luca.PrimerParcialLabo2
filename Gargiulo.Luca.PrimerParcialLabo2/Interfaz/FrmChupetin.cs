using Entidades.JerarquiaYContenedora;
using System;
using System.CodeDom;
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
    /// Formulario para ingresar informacion especifica de un chupetin.
    /// </summary>
    public partial class FrmChupetin : FrmGolosina
    {
        #region Atributos
        protected Chupetin miChupetin;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el objeto Chupetin modificado o creado en el formulario.
        /// </summary>
        public Chupetin MiChupetin 
        { 
            get { return this.miChupetin; } 
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de FrmChupetin.
        /// </summary>
        public FrmChupetin() : base()
        {
            InitializeComponent();
            ConfigurarComboBoxes();
            this.miChupetin = new Chupetin();
        }

        /// <summary>
        /// Constructor que inicializa el formulario con un objeto Chupetin existente.
        /// </summary>
        //// <param name="chupetin">Objeto Chupetin a editar.</param>
        public FrmChupetin(Chupetin chupetin) : this()
        {
            InicializarControlesGenerales(chupetin);
        }
        #endregion

        #region Manejadores de eventos
        private void FrmChupetin_Load(object sender, EventArgs e)
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
                EFormasDeChupetin formaChupetin = (EFormasDeChupetin)this.cboFormaChupetin.SelectedItem;
                ENivelesDeDureza dureza = (ENivelesDeDureza)this.cboDureza.SelectedItem;
                bool envolturaTransparente = this.chkEnvolturaTransparente.Checked;

                this.miChupetin = new Chupetin(int.Parse(txtCodigo.Text),
                                                float.Parse(txtPeso.Text),
                                                float.Parse(txtPrecio.Text),
                                                int.Parse(txtCantidad.Text),
                                                formaChupetin,
                                                dureza, 
                                                envolturaTransparente);
            }
        }

        #endregion

        #region Metodos de inicializacion y configuracion
        /// <summary>
        /// Inicializa los controles del formulario con los datos de un objeto Chupetin existente.
        /// </summary>
        //// <param name="chupetin">Objeto Chupetin a mostrar en los controles.</param>
        public void InicializarControlesGenerales(Chupetin chupetin) 
        {
            txtCodigo.Text = chupetin.Codigo.ToString();
            txtPeso.Text = chupetin.Peso.ToString();
            txtPrecio.Text = chupetin.Precio.ToString();
            txtCantidad.Text = chupetin.Cantidad.ToString();

            this.cboFormaChupetin.SelectedItem = chupetin.FormaChupetin;
            this.cboDureza.SelectedItem = chupetin.Dureza;
            this.chkEnvolturaTransparente.Checked = chupetin.EnvolturaTransparente;

            this.txtCodigo.Enabled = false; 
        }

        /// <summary>
        /// Configura los ComboBoxes del formulario con los valores de los Enums EFormasDeChupetin y ENivelesDeDureza.
        /// </summary>
        public void ConfigurarComboBoxes()
        {
            foreach (EFormasDeChupetin formaChupetin in Enum.GetValues(typeof(EFormasDeChupetin)))
            {
                this.cboFormaChupetin.Items.Add(formaChupetin);
            }
            this.cboFormaChupetin.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboFormaChupetin.SelectedItem = EFormasDeChupetin.Redondo;

            foreach (ENivelesDeDureza dureza in Enum.GetValues(typeof(ENivelesDeDureza)))
            {
                this.cboDureza.Items.Add(dureza);
            }
            this.cboDureza.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboDureza.SelectedItem = ENivelesDeDureza.Media;
        }

        #endregion

    }
}
