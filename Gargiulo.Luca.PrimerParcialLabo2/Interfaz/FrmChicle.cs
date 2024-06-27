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
    public partial class FrmChicle : FrmGolosina
    {
        #region Atributos
        protected Chicle miChicle;
        #endregion

        #region Propiedades
        public Chicle MiChicle 
        { 
            get { return this.miChicle; } 
        }
        #endregion

        #region Constructores
        public FrmChicle() : base()
        {
            InitializeComponent();
            ConfigurarComboBoxes();
            this.miChicle = new Chicle(); //fijarme en chocolate
            
        }
        public FrmChicle(Chicle chicle) : this()
        {
            InicializarControlesGenerales(chicle);
        }
        #endregion

        #region Manejadores de eventos
        private void FrmChicle_Load(object sender, EventArgs e)
        {

        }

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
        public void InicializarControlesGenerales(Chicle chicle) //podria hacerlo protected y virtual y los 4 primeros hacerlos en golosina
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

        public void ConfigurarComboBoxes()
        {
            foreach (ENivelesDeElasticidad elasticidad in Enum.GetValues(typeof(ENivelesDeElasticidad)))
            {
                this.cboElasticidad.Items.Add(elasticidad);
            }
            this.cboElasticidad.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboElasticidad.SelectedItem = ENivelesDeElasticidad.Media; //valor predeterminado

            foreach (ENivelesDuracionDeSabor duracionSabor in Enum.GetValues(typeof(ENivelesDuracionDeSabor)))
            {
                this.cboDuracionSabor.Items.Add(duracionSabor);
            }
            this.cboDuracionSabor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboDuracionSabor.SelectedItem = ENivelesDuracionDeSabor.Media; //valor predeterminado
        }
        #endregion

    }
}
