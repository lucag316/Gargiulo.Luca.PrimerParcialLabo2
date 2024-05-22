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

        public FrmChupetin()
        {
            InitializeComponent();

            foreach (EFormasDeChupetin formaChupetin in Enum.GetValues(typeof(EFormasDeChupetin)))
            {
                this.cboFormaChupetin.Items.Add(formaChupetin);
            }
            this.cboFormaChupetin.SelectedItem = EFormasDeChupetin.Redondo;

            foreach (ENivelesDeDureza dureza in Enum.GetValues(typeof(ENivelesDeDureza)))
            {
                this.cboDureza.Items.Add(dureza);
            }
            this.cboDureza.SelectedItem = ENivelesDeDureza.Media;
        }

        public FrmChupetin(Chupetin chupetin) : this()
        {
            this.cboFormaChupetin.SelectedItem = chupetin.FormaChupetin;
            this.cboDureza.SelectedItem = chupetin.Dureza;
        }

        private void FrmChupetin_Load(object sender, EventArgs e)
        {

        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(base.txtCodigo.Text);//fijarse en las propiedades del frmGolosinas, que los txtBox sea protected, NO privados
            float precio = float.Parse(base.txtPrecio.Text);
            float peso = float.Parse(base.txtPeso.Text);
            int cantidad = int.Parse(base.txtCantidad.Text);

            EFormasDeChupetin formaChupetin = (EFormasDeChupetin)this.cboFormaChupetin.SelectedItem;
            ENivelesDeDureza dureza = (ENivelesDeDureza)this.cboDureza.SelectedItem;

            this.miChupetin = new Chupetin(codigo, peso, precio, cantidad, formaChupetin, dureza);

            base.btnAceptar_Click(sender, e);
        }

    }
}
