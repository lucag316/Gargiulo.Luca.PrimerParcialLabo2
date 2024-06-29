﻿using Entidades;
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
        //protected Golosina golosina;

        #region Constructor
        public FrmGolosina()
        {
            InitializeComponent();
            //this.golosina = golosina;
            //InicializarControlesGenerales();
        }
        #endregion

        #region Manejadores de eventos

        private void FrmGolosina_Load(object sender, EventArgs e)
        {

        }

        protected virtual void btnAceptar_Click(object sender, EventArgs e) //lo hago virtual para heredarlo, protected porque no puede ser privado
        {
            int codigo;
            float precio;
            float peso;
            int cantidad;

            if (string.IsNullOrWhiteSpace(this.txtCodigo.Text)) //aca valido si los campos estan vacion y le pongo valor predeterminado
            {
                this.txtCodigo.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(this.txtPrecio.Text))
            {
                this.txtPrecio.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(this.txtPeso.Text))
            {
                this.txtPeso.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(this.txtCantidad.Text))
            {
                this.txtCantidad.Text = "0";
            }
            try
            {
                if (!int.TryParse(this.txtCodigo.Text, out codigo))
                {
                    throw new ExcepcionDatoNoNumerico("Porfavor, ingrese un codigo valido numerico");
                    //MessageBox.Show("Por favor, ingrese un codigo valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return; //hago return para salir sin hacer mas nada, si no lo pongo no vuelve
                }
                if (!float.TryParse(this.txtPrecio.Text, out precio))
                {
                    throw new ExcepcionDatoNoNumerico("Porfavor, ingrese un precio valido numerico");
                    //MessageBox.Show("Por favor, ingrese un precio valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
                if (!float.TryParse(this.txtPeso.Text, out peso))
                {
                    throw new ExcepcionDatoNoNumerico("Porfavor, ingrese un peso valido numerico");
                    //MessageBox.Show("Por favor, ingrese un peso valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
                if (!int.TryParse(this.txtCantidad.Text, out cantidad))
                {
                    throw new ExcepcionDatoNoNumerico("Porfavor, ingrese una cantidad valido numerico");
                    //MessageBox.Show("Por favor, ingrese una cantidad valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }

                if (codigo < 0 || precio < 0 || peso < 0 || cantidad < 0) //verifico si los valores son positivos
                {
                    throw new ExcepcionNumeroNegativo("Por favor, ingrese valores positivos");
                    //MessageBox.Show("Por favor, ingrese valores positivos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
                if (codigo > 1000)
                {
                    throw new ExcepcionNumeroMuyAlto("El codigo debe ser menor o igual a 1000");
                }

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

        //protected virtual void InicializarControlesGenerales()
        //{
        //    txtCodigo.Text = golosina.Codigo.ToString();
        //    txtPeso.Text = golosina.Peso.ToString();
        //    txtPrecio.Text = golosina.Precio.ToString();
        //    txtCantidad.Text = golosina.Cantidad.ToString();
        //}

    }
}
