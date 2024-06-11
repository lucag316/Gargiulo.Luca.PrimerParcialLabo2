using Entidades;
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
    public partial class FrmChupetin : FrmGolosina
    {
        protected Chupetin miChupetin;

        public Chupetin MiChupetin { get { return this.miChupetin; } }

        public FrmChupetin() : base()
        {
            InitializeComponent();
            ConfigurarComboBoxes();
        }

        public FrmChupetin(Chupetin chupetin) : this()
        {
            InicializarControlesGenerales(chupetin);
        }

        private void FrmChupetin_Load(object sender, EventArgs e)
        {

        }

        public void InicializarControlesGenerales(Chupetin chupetin) //podria hacerlo protected y virtual y los 4 primeros hacerlos en golosina
        {
            txtCodigo.Text = chupetin.Codigo.ToString();
            txtPeso.Text = chupetin.Peso.ToString();
            txtPrecio.Text = chupetin.Precio.ToString();
            txtCantidad.Text = chupetin.Cantidad.ToString();
            this.cboFormaChupetin.SelectedItem = chupetin.FormaChupetin;
            this.cboDureza.SelectedItem = chupetin.Dureza;
        }

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

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            base.btnAceptar_Click(sender, e);
            
            if (this.DialogResult == DialogResult.OK)
            {
                EFormasDeChupetin formaChupetin = (EFormasDeChupetin)this.cboFormaChupetin.SelectedItem;
                ENivelesDeDureza dureza = (ENivelesDeDureza)this.cboDureza.SelectedItem;

                this.miChupetin = new Chupetin(int.Parse(txtCodigo.Text),
                                                float.Parse(txtPeso.Text),
                                                float.Parse(txtPrecio.Text),
                                                int.Parse(txtCantidad.Text),
                                                formaChupetin,
                                                dureza);
            }
        }
    }
}
