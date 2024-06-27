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
    /// Formulario para ingresar informacion específica de un chocolate.
    /// </summary>
    public partial class FrmChocolate : FrmGolosina
    {
        #region Atributos
        protected Chocolate miChocolate;
        #endregion

        #region Propiedades
        public Chocolate MiChocolate 
        { 
            get { return this.miChocolate; } //propiedad publica que devuelve el modificado
        }
        #endregion

        #region Constructores
        public FrmChocolate() : base()//:base()//ACA VA?O NO?
        {
            InitializeComponent();
            ConfigurarComboBoxes();
            this.miChocolate = new Chocolate(); // Inicializacion aca para evitar error ed que puede ser nulo, el codigo me funciona, lo tenga o no, solo para sacar la advertencia
        }

        public FrmChocolate(Chocolate chocolate) : this()
        {
            InicializarControlesGenerales(chocolate);
        }
        #endregion

        #region Manejadores de eventos
        private void FrmChocolate_Load(object sender, EventArgs e)
        {

        }

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
        public void InicializarControlesGenerales(Chocolate chocolate) //podria hacerlo protected y virtual y los 4 primeros hacerlos en golosina
        {
            txtCodigo.Text = chocolate.Codigo.ToString();
            txtPeso.Text = chocolate.Peso.ToString();
            txtPrecio.Text = chocolate.Precio.ToString();
            txtCantidad.Text = chocolate.Cantidad.ToString();

            this.cboRelleno.SelectedItem = chocolate.Relleno;
            this.cboTipoDeCacao.SelectedItem = chocolate.TipoDeCacao;
            this.chkEsVegano.Checked = chocolate.EsVegano;

            this.txtCodigo.Enabled = false; // para no poder modificar
        }
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

    }
}
