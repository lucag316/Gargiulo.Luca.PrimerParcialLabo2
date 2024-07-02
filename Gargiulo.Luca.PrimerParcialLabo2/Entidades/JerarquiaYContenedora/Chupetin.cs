using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Entidades.Interfaces;
using Entidades.Excepciones;

namespace Entidades.JerarquiaYContenedora
{
    /// <summary>
    /// Representa una golosina del tipo chupetin.
    /// </summary>
    [Serializable]
    public class Chupetin : Golosina
    {
        #region Atributos
        protected EFormasDeChupetin formaChupetin;
        protected ENivelesDeDureza dureza;
        protected bool envolturaTransparente;
        #endregion

        #region Propiedades
        public EFormasDeChupetin FormaChupetin
        {
            get { return this.formaChupetin; }
            set { this.formaChupetin = value; }
        }

        public ENivelesDeDureza Dureza
        {
            get { return this.dureza; }
            set { this.dureza = value; }
        }
        public bool EnvolturaTransparente
        {
            get { return this.envolturaTransparente; }
            set { this.envolturaTransparente = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros para poder usar JSON
        /// </summary>
        public Chupetin() : base()
        {
            formaChupetin = EFormasDeChupetin.Redondo;
            dureza = ENivelesDeDureza.Media;
            envolturaTransparente = false;
        }

        /// <summary>
        /// Constructor que inicializa los atributos del chupetin.
        /// </summary>
        //// <param name="codigo">Codigo del chupetin.</param>
        //// <param name="peso">Peso del chupetin.</param>
        //// <param name="precio">Precio del chupetin.</param>
        //// <param name="cantidad">Cantidad de chupetin.</param>
        public Chupetin(int codigo, float peso, float precio, int cantidad) : base(codigo, peso, precio, cantidad)
        {

        }

        /// <summary>
        /// Constructor que inicializa los atributos del chupetin con forma del chupetin.
        /// </summary>
        //// <param name="codigo">Codigo del chupetin.</param>
        //// <param name="peso">Peso del chupetin.</param>
        //// <param name="precio">Precio del chupetin.</param>
        //// <param name="cantidad">Cantidad de chupetin.</param>
        //// <param name="formaChupetin">Forma del chupetin.</param>
        public Chupetin(int codigo, float peso, float precio, int cantidad, EFormasDeChupetin formaChupetin) : this(codigo, peso, precio, cantidad)
        {
            this.formaChupetin = formaChupetin;
        }

        /// <summary>
        /// Constructor que inicializa los atributos del chupetin con forma del chupetin y dureza.
        /// </summary>
        //// <param name="codigo">Codigo del chupetin.</param>
        //// <param name="peso">Peso del chupetin.</param>
        //// <param name="precio">Precio del chupetin.</param>
        //// <param name="cantidad">Cantidad de chupetin.</param>
        //// <param name="formaChupetin">Forma del chupetin.</param>
        //// <param name="dureza">Dureza del chupetin.</param>
        public Chupetin(int codigo, float peso, float precio, int cantidad, EFormasDeChupetin formaChupetin, ENivelesDeDureza dureza) : this(codigo, peso, precio, cantidad, formaChupetin)
        {
            this.dureza = dureza;
        }

        /// <summary>
        /// Constructor que inicializa los atributos del chupetin con forma del chupetin, dureza y su envoltura.
        /// </summary>
        //// <param name="codigo">Codigo del chupetin.</param>
        //// <param name="peso">Peso del chupetin.</param>
        //// <param name="precio">Precio del chupetin.</param>
        //// <param name="cantidad">Cantidad de chupetin.</param>
        //// <param name="formaChupetin">Forma del chupetin.</param>
        //// <param name="envolturaTransparente">Tiene Envoltura transparente o no.</param>
        public Chupetin(int codigo, float peso, float precio, int cantidad, EFormasDeChupetin formaChupetin, ENivelesDeDureza dureza, bool envolturaTransparente) : this(codigo, peso, precio, cantidad, formaChupetin, dureza)
        {
            this.envolturaTransparente = envolturaTransparente;
        }
        #endregion

        #region Metodos de Object sobrescritos
        /// <summary>
        /// Devuelve una cadena que representa el chupetin.
        /// </summary>
        /// <returns>Una cadena con los detalles del chupetin.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=============== CHUPETIN ===============");
            sb.Append(base.ToString());
            sb.AppendLine($"Forma de Chupetin: {this.formaChupetin}");
            sb.AppendLine($"Dureza: {this.dureza}");
            sb.AppendLine($"Envoltura transparente: {this.envolturaTransparente}");
            sb.AppendLine("========================================\n");

            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            bool mismaGolosina = base.Equals(obj);

            bool mismoChupetin = false;

            if (obj is Chupetin)
            {
                if ((Chupetin)obj == this && mismaGolosina == true)
                {
                    mismoChupetin = true;
                }
            }
            return mismoChupetin;
        }

        /// <summary>
        /// Devuelve un codigo hash para el objeto actual.
        /// </summary>
        /// <returns>Un codigo hash para el objeto actual.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), this.formaChupetin, this.dureza, this.envolturaTransparente);
        }
        #endregion

        #region Metodos sobrescritos

        /// <summary>
        /// Muestra la informacion del chupetin en un formato adecuado para un visor.
        /// </summary>
        /// <returns>Una cadena que contiene la informacion del chupetin.</returns>
        public override string MostrarEnVisor()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("{0, -24}", "CHUPETIN"));
            sb.AppendLine(base.MostrarEnVisor());
            sb.AppendLine($"Forma: {this.formaChupetin,-22}");
            sb.AppendLine($"Dureza: {this.dureza,-40}");
            sb.AppendLine($"Envoltura transparente: {this.envolturaTransparente,-20}");

            return sb.ToString();
        }

        /// <summary>
        /// Calcula el precio final del chupetin, si se compra mas de 2 chupetines, aplico 20% de descuento.
        /// </summary>
        /// <returns>El precio final del chupetin.</returns>
        public override double CalcularPrecioFinal()
        {
            double precioFinal = Precio * Cantidad;

            return precioFinal;
        }
        #endregion

        #region Sobrecargas de operadores de igualdad

        /// <summary>
        /// Determina si dos instancias de Chupetin son iguales.
        /// </summary>
        /// <returns>true si las instancias son iguales, sino false
        public static bool operator ==(Chupetin chupetin1, Chupetin chupetin2)
        {
            bool mismoGolosina = chupetin1 == (Golosina)chupetin2;

            bool mismoChupetin = mismoGolosina && chupetin1.FormaChupetin == chupetin2.FormaChupetin &&
                                                  chupetin1.Dureza == chupetin2.Dureza &&
                                                  chupetin1.envolturaTransparente == chupetin2.envolturaTransparente;

            return mismoChupetin;
        }

        /// <summary>
        /// Determina si dos instancias de Chupetin son diferentes.
        /// </summary>
        public static bool operator !=(Chupetin chupetin1, Chupetin chupetin2)
        {
            return !(chupetin1 == chupetin2);
        }
        #endregion
    }
}
