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
    public partial class FrmChicle : FrmGolosina
    {
        protected Chicle miChicle;

        public Chicle MiChicle { get { return this.miChicle; } }

        public FrmChicle()
        {
            InitializeComponent();

            foreach (ENivelesDeElasticidad elasticidad in Enum.GetValues(typeof(ENivelesDeElasticidad)))
            {
                this.cboElasticidad.Items.Add(elasticidad);
            }
            this.cboElasticidad.SelectedItem = ENivelesDeElasticidad.Media; //valor predeterminado

            foreach (ENivelesDuracionDeSabor duracionSabor in Enum.GetValues(typeof(ENivelesDuracionDeSabor)))
            {
                this.cboDuracionSabor.Items.Add(duracionSabor);
            }
            this.cboDuracionSabor.SelectedItem = ENivelesDuracionDeSabor.Media; //valor predeterminado
        }
        public FrmChicle(Chicle chicle) : this()
        {
            this.cboElasticidad.SelectedItem = chicle.Elasticidad;
            this.cboDuracionSabor.SelectedItem = chicle.DuracionSabor;
        }

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

                this.miChicle = new Chicle(int.Parse(txtCodigo.Text),
                                                float.Parse(txtPeso.Text),
                                                float.Parse(txtPrecio.Text),
                                                int.Parse(txtCantidad.Text),
                                                elasticidad,
                                                duracionSabor);
            }
        }
    }
}
