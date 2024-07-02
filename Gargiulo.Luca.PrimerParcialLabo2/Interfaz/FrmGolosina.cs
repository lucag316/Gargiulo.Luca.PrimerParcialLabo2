using Entidades;
using Entidades.Excepciones;
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
    /// Formulario base para ingresar informacion de una golosina.
    /// </summary>
    public partial class FrmGolosina : Form
    {

        #region Constructor
        /// <summary>
        /// Constructor por defecto de la clase FrmGolosina.
        /// </summary>
        public FrmGolosina()
        {
            InitializeComponent();
        }
        #endregion

        #region Manejadores de eventos

        private void FrmGolosina_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el boton "Aceptar".
        /// Valida y procesa la informacion ingresada por el usuario.
        /// </summary>
        //// <param name="sender">Objeto que genera el evento.</param>
        //// <param name="e">Argumentos del evento.</param>
        protected virtual void btnAceptar_Click(object sender, EventArgs e) //lo hago virtual para heredarlo, protected porque no puede ser privado
        {
            int codigo;
            float precio;
            float peso;
            int cantidad;

            if (string.IsNullOrWhiteSpace(this.txtCodigo.Text)) // valido si estan vacios los campos y les pongo valor predeterminado
                this.txtCodigo.Text = "0";
            if (string.IsNullOrWhiteSpace(this.txtPrecio.Text))
                this.txtPrecio.Text = "0";
            if (string.IsNullOrWhiteSpace(this.txtPeso.Text))
                this.txtPeso.Text = "0";
            if (string.IsNullOrWhiteSpace(this.txtCantidad.Text))
                this.txtCantidad.Text = "0";
            try
            {
                if (!int.TryParse(this.txtCodigo.Text, out codigo))
                    throw new ExcepcionDatoNoNumerico("Por favor, ingrese un codigo valido numerico");
                if (!float.TryParse(this.txtPrecio.Text, out precio))
                    throw new ExcepcionDatoNoNumerico("Por favor, ingrese un precio valido numerico");
                if (!float.TryParse(this.txtPeso.Text, out peso))
                    throw new ExcepcionDatoNoNumerico("Por favor, ingrese un peso valido numerico");
                if (!int.TryParse(this.txtCantidad.Text, out cantidad))
                    throw new ExcepcionDatoNoNumerico("Por favor, ingrese una cantidad valido numerica");

                if (codigo < 0 || precio < 0 || peso < 0 || cantidad < 0)
                    throw new ExcepcionNumeroNegativo("Por favor, ingrese valores positivos");

                if (codigo > 1000)
                    throw new ExcepcionNumeroMuyAlto("El codigo debe ser menor o igual a 1.000");
                if (precio > 10000)
                    throw new ExcepcionNumeroMuyAlto("El precio es muy alto, debe ser menor a $10.000");
                if(peso > 5000)
                    new ExcepcionNumeroMuyAlto("El peso es mucho, debe ser menor a 5.000 gramos");
                if(cantidad > 100)
                    new ExcepcionNumeroMuyAlto("Demasiada cantidad, el maximo es 100 unidades");

                this.DialogResult = DialogResult.OK;
            }
            catch (ExcepcionDatoNoNumerico ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionNumeroNegativo ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionNumeroMuyAlto ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el boton "Cancelar".
        /// Pregunta al usuario si desea cancelar y cierra el formulario si asi lo decide.
        /// </summary>
        //// <param name="sender">Objeto que genera el evento.</param>
        //// <param name="e">Argumentos del evento.</param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desea cancelar?", "Confirmar cancelacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        #endregion

    }
}
