using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Interfaz
{
    public partial class FrmMenuPrincipal : Form
    {
        private Kiosco kiosco;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            this.kiosco = new Kiosco();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            //tratar de cargar la lista del archivo al principio
            //CargarGolosinas();
            ActualizarVisorGolosinas();
        }

        private void ActualizarVisorGolosinas()
        {
            this.lstVisorGolosinas.Items.Clear();//limpio para no duplicar ni agregar cosas

            foreach (Golosina golosina in kiosco.Golosinas)// THIS.GOLOSINAS POR KIOSCO.GOLOSINAS
            {
                this.lstVisorGolosinas.Items.Add(golosina.MostrarEnVisor());//CAMBIAR Y USAR UN DETALLE DE KIOSCO PERO QUE 
            }
        }

        private void cHOCOLATEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmChocolate frmChocolate = new FrmChocolate();
            frmChocolate.ShowDialog();

            if (frmChocolate.DialogResult == DialogResult.OK)
            {
                kiosco += frmChocolate.MiChocolate;
                this.ActualizarVisorGolosinas();
            }
        }

        private void cHICLEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmChicle frmChicle = new FrmChicle();
            frmChicle.ShowDialog();

            if (frmChicle.DialogResult == DialogResult.OK)
            {
                kiosco += frmChicle.MiChicle;
                this.ActualizarVisorGolosinas();
            }
        }
        private void cHUPETINToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmChupetin frmChupetin = new FrmChupetin();
            frmChupetin.ShowDialog(); //lo muestro en forma modal

            if (frmChupetin.DialogResult == DialogResult.OK)
            {
                kiosco += frmChupetin.MiChupetin;    //LO AGREGO SOLO DE ESTA MANERA // no se si aca va this.kiosco
                this.ActualizarVisorGolosinas();
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int i = this.lstVisorGolosinas.SelectedIndex;//el indice que selecciono

            if (i < 0)
            {
                MessageBox.Show("Por favor, seleccione una golosina para modificar.", "Seleccion requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Golosina golosinaSeleccionada = kiosco.Golosinas[i];//la golosina que seleccione en el visor

            FrmGolosina frmGolosina = null;//lo declaro asi despues puedo llamarla, creo que esta bien, //el formuladio de edicion

            if (golosinaSeleccionada is Chocolate)
            {
                frmGolosina = new FrmChocolate((Chocolate)golosinaSeleccionada);
            }
            else if (golosinaSeleccionada is Chicle)
            {
                frmGolosina = new FrmChicle((Chicle)golosinaSeleccionada);//ACTUALIZAR CHICLE COMO HICE CON CHOCOLATE
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int i = this.lstVisorGolosinas.SelectedIndex;//el indice que selecciono

            if (i < 0)
            {
                MessageBox.Show("Por favor, seleccione una golosina para eliminar.", "Seleccion requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Esta seguro que desa eliminar esta golosina?", "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.kiosco.Golosinas.RemoveAt(i); //lo elimino
                this.ActualizarVisorGolosinas();
            }

        }

        private void jSONToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //guardo en json
            Serializadora serializadoraJson = new Serializadora("Golosinas");

            serializadoraJson.SerializarGolosinasJSON(kiosco.Golosinas);
            MessageBox.Show("Lista de golosinas guardada correctamente en un archivo JSON.");
        }

        private void xMLToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Serializadora serializadoraXml = new Serializadora("Golosinas");

            serializadoraXml.SerializarGolosinasXML(kiosco.Golosinas);
            MessageBox.Show("Lista de golosinas guardada correctamente en un archivo XML.");
        }

        private void jSONToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                Serializadora deserializadoraJson = new Serializadora("Golosinas");
                //List<Golosina> golosinasDeserializadas = Deser
            }
            catch
            {

            }
        }

        private void xMLToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                Serializadora deserializadoraXml = new Serializadora("Golosinas", kiosco.Golosinas);
                List<Golosina> golosinasDeserializadas = deserializadoraXml.DeserialiazrGolosinasXML();
                this.kiosco.Golosinas.Clear();
                this.kiosco.Golosinas.AddRange(golosinasDeserializadas); //+= golosinasDeserializadas;//hacer una sobrecarga de Kiosco += Lista
                this.ActualizarVisorGolosinas();
                MessageBox.Show("Lista de golosinas cargada correctamente desde el archivo XML.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar golosinas: {ex.Message}");
            }
        }
    }
}
