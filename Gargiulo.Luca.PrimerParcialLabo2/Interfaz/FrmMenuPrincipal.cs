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
        List<Golosina> golosinas;
        //private string pathArchivoJson = "golosinas.json";
        //private string pathArchivoXml = "golosinas.Xml";

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            this.golosinas = new List<Golosina>();
            
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            //tratar de cargar la lista del archivo al principio
            //CargarGolosinas();
            //ActualizarVisorGolosinas();
        }

        private void ActualizarVisorGolosinas()
        {
            this.lstVisorGolosinas.Items.Clear();//limpio para no duplicar ni agregar cosas

            foreach (Golosina golosina in this.golosinas)
            {//LLAMARIA A UN MOSTRAR EN VISOR DE LAS CLASES, ASI SE VE BIEN
                //this.lstVisorGolosinas.Items.Add(golosina.ToString());//LA COMENTE YO//ver bien porque hay varios tipos de golosinas
                //this.lstVisorGolosinas.Text += golosina.ToString();//para un richBox, aca no creo que funcione
                this.lstVisorGolosinas.Items.Add(golosina.MostrarEnVisor());
            }
        }

        private void cHOCOLATEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmChocolate frmChocolate = new FrmChocolate();
            frmChocolate.ShowDialog(); //lo muestro en forma modal

            if (frmChocolate.DialogResult == DialogResult.OK)
            {
                this.golosinas.Add(frmChocolate.MiChocolate);
                this.ActualizarVisorGolosinas();
            }
        }

        private void cHICLEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmChicle frmChicle = new FrmChicle();
            frmChicle.ShowDialog(); //lo muestro en forma modal

            if (frmChicle.DialogResult == DialogResult.OK)
            {
                this.golosinas.Add(frmChicle.MiChicle);
                this.ActualizarVisorGolosinas();
            }
        }
        private void cHUPETINToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmChupetin frmChupetin = new FrmChupetin();
            frmChupetin.ShowDialog(); //lo muestro en forma modal

            if (frmChupetin.DialogResult == DialogResult.OK)
            {
                this.golosinas.Add(frmChupetin.MiChupetin);
                this.ActualizarVisorGolosinas();
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int i = this.lstVisorGolosinas.SelectedIndex;//el indice que selecciono

            if (i < 0)
            {
                MessageBox.Show("Por favor, seleccione una golosina para modificar.", "Seleccion requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;//VA O NO VA?
            }

            Golosina golosinaSeleccionada = this.golosinas[i];//la golosina que seleccione en el visor

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
                    //this.golosinas[i] = (Golosina)frmGolosina.Tag;//BUSCAR QUE HACE TAG
                    //this.golosinas[i] = golosinaSeleccionada;
                    //---
                    if (frmGolosina is FrmChocolate frmChocolate)
                    {
                        this.golosinas[i] = frmChocolate.MiChocolate; //lo modifico
                    }
                    else if (frmGolosina is FrmChicle frmChicle)
                    {
                        this.golosinas[i] = frmChicle.MiChicle; //lo modifico
                    }
                    else if (frmGolosina is FrmChupetin frmChupetin)
                    {
                        this.golosinas[i] = frmChupetin.MiChupetin; //lo modifico
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
                return;//VA O NO VA?
            }
            //no se si va este--
            Golosina golosinaSeleccionada = this.golosinas[i];//la golosina que seleccione en el visor
            //---
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desa eliminar esta golosina?", "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.golosinas.RemoveAt(i); //lo elimino
                this.ActualizarVisorGolosinas();
            }
            
        }

        private void jSONToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //guardo en json
            Serializadora serializadoraJson = new Serializadora("Golosinas");
            
            serializadoraJson.SerializarGolosinasJSON(this.golosinas);
            MessageBox.Show("Lista de golosinas guardada correctamente en un archivo JSON.");
        }

        private void xMLToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Serializadora serializadoraXml = new Serializadora("Golosinas");

            serializadoraXml.SerializarGolosinasXML(this.golosinas);
            MessageBox.Show("Lista de golosinas guardada correctamente en un archivo XML.");
        }
    }
}
