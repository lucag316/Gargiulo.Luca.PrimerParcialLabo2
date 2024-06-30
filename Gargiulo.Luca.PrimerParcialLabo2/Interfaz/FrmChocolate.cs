using Entidades.JerarquiaYContenedora;
using Interfaz.Properties;
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
    /// Formulario para ingresar informacion especifica de un chocolate.
    /// </summary>
    public partial class FrmChocolate : FrmGolosina
    {
        #region Atributos
        protected Chocolate miChocolate;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el objeto Chocolate modificado o creado en el formulario.
        /// </summary>
        public Chocolate MiChocolate 
        { 
            get { return this.miChocolate; } //propiedad publica que devuelve el modificado
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de FrmChocolate.
        /// </summary>
        public FrmChocolate() : base()
        {
            InitializeComponent();
            ConfigurarComboBoxes();
            this.miChocolate = new Chocolate(); // Inicializacion aca para evitar error ed que puede ser nulo, el codigo me funciona, lo tenga o no, solo para sacar la advertencia
        }

        /// <summary>
        /// Constructor que inicializa el formulario con un objeto Chocolate existente.
        /// </summary>
        //// <param name="chocolate">Objeto Chocolate a editar.</param>
        public FrmChocolate(Chocolate chocolate) : this()
        {
            InicializarControlesGenerales(chocolate);
        }
        #endregion

        #region Manejadores de eventos
        private void FrmChocolate_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Manejador del evento Click del boton Aceptar.
        /// </summary>
        //// <param name="sender">Objeto que envia el evento.</param>
        //// <param name="e">Argumentos del evento.</param>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            base.btnAceptar_Click(sender, e); //llamo al metodo de Golosina

            if (this.DialogResult == DialogResult.OK)
            {
                ERellenos relleno = (ERellenos)this.cboRelleno.SelectedItem;
                ETiposDeCacao tipoDeCacao = (ETiposDeCacao)this.cboTipoDeCacao.SelectedItem;
                bool esVegano = this.chkEsVegano.Checked;

                this.miChocolate = new Chocolate(int.Parse(txtCodigo.Text),
                                                float.Parse(txtPeso.Text),
                                                float.Parse(txtPrecio.Text),
                                                int.Parse(txtCantidad.Text),
                                                relleno,
                                                tipoDeCacao,
                                                esVegano); //cree el choco con los datos ingresados

            }
        }

        #endregion

        #region Metodos de inicializacion y configuracion
        /// <summary>
        /// Inicializa los controles del formulario con los datos de un objeto Chocolate existente.
        /// </summary>
        //// <param name="chocolate">Objeto Chocolate a mostrar en los controles.</param>
        public void InicializarControlesGenerales(Chocolate chocolate) 
        {
            txtCodigo.Text = chocolate.Codigo.ToString();
            txtPeso.Text = chocolate.Peso.ToString();
            txtPrecio.Text = chocolate.Precio.ToString();
            txtCantidad.Text = chocolate.Cantidad.ToString();

            this.cboRelleno.SelectedItem = chocolate.Relleno;
            this.cboTipoDeCacao.SelectedItem = chocolate.TipoDeCacao;
            this.chkEsVegano.Checked = chocolate.EsVegano;

            this.txtCodigo.Enabled = false; // para no poder modificar el codigo
        }

        /// <summary>
        /// Configura los ComboBoxes del formulario con los valores de los Enums ERellenos y ETiposDeCacao.
        /// </summary>
        public void ConfigurarComboBoxes()
        {
            foreach (ERellenos relleno in Enum.GetValues(typeof(ERellenos)))
            {
                this.cboRelleno.Items.Add(relleno); //agrego los elementos de Enum a los cbo
            }
            this.cboRelleno.DropDownStyle = ComboBoxStyle.DropDownList; // asi no se podria editar
            this.cboRelleno.SelectedItem = ERellenos.SinRelleno; //valor predeterminado

            foreach (ETiposDeCacao tipoDeCacao in Enum.GetValues(typeof(ETiposDeCacao)))
            {
                this.cboTipoDeCacao.Items.Add(tipoDeCacao);
            }
            this.cboTipoDeCacao.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboTipoDeCacao.SelectedItem = ETiposDeCacao.Negro;

        }
        #endregion
        /*
        private void MostrarMensajeCodigoNegativoMsgBox(int numero)
        {
            MessageBox.Show($"Error: El código no puede ser negativo. Código ingresado: {numero}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MostrarMensajeCodigoMuyAltoMsgBox(int numero)
        {
            MessageBox.Show($"Error: El código no puede ser mayor que 100. Código ingresado: {numero}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MostrarMensajeCodigoNoNumericoMsgBox(int numero)
        {
            MessageBox.Show($"Error: El código debe ser numérico. Código ingresado: {numero}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }*/
    }
}
