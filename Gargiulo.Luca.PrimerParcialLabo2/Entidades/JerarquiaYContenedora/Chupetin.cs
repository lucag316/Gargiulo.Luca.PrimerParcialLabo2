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
    [Serializable]
    public class Chupetin : Golosina, ICalculos
    {
        #region Atributos
        protected EFormasDeChupetin formaChupetin;
        protected ENivelesDeDureza dureza;
        protected bool envolturaTransparente;
        #endregion

        #region Propiedades
        //[JsonPropertyName("formaChupetin")]
        public EFormasDeChupetin FormaChupetin
        {
            get { return formaChupetin; }
            set { formaChupetin = value; }
        }

        //[JsonPropertyName("dureza")]
        public ENivelesDeDureza Dureza
        {
            get { return dureza; }
            set { dureza = value; }
        }
        public bool EnvolturaTransparente
        {
            get { return envolturaTransparente; }
            set { envolturaTransparente = value; }
        }
        #endregion

        #region Constructores
        public Chupetin() : base() //constructor sin parametros para poder usar JSON
        {
            formaChupetin = EFormasDeChupetin.Redondo;
            dureza = ENivelesDeDureza.Media;
            envolturaTransparente = false;
        }
        public Chupetin(int codigo, float peso, float precio, int cantidad) : base(codigo, peso, precio, cantidad)
        {
            //this.formaChupetin = EFormasDeChupetin.Redondo;
            //this.dureza = ENivelesDeDureza.Media;
        }
        public Chupetin(int codigo, float peso, float precio, int cantidad, EFormasDeChupetin formaChupetin) : this(codigo, peso, precio, cantidad)
        {
            this.formaChupetin = formaChupetin;
        }
        public Chupetin(int codigo, float peso, float precio, int cantidad, EFormasDeChupetin formaChupetin, ENivelesDeDureza dureza) : this(codigo, peso, precio, cantidad, formaChupetin)
        {
            this.dureza = dureza;
        }
        public Chupetin(int codigo, float peso, float precio, int cantidad, EFormasDeChupetin formaChupetin, ENivelesDeDureza dureza, bool envolturaTransparente) : this(codigo, peso, precio, cantidad, formaChupetin, dureza)
        {
            this.envolturaTransparente = envolturaTransparente;
        }
        #endregion

        #region Metodos de Object sobrescritos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=============== CHUPETIN ===============");
            sb.Append(base.ToString());
            sb.AppendLine($"Forma de Chupetin: {formaChupetin}");
            sb.AppendLine($"Dureza: {dureza}");
            sb.AppendLine($"Envoltura transparente: {envolturaTransparente}");
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
        public override int GetHashCode()
        {
            return HashCode.Combine(codigo, precio, peso, cantidad, formaChupetin, dureza, envolturaTransparente);
        }
        #endregion

        #region Metodos Interfaces

        double ICalculos.CalcularDescuento(double precio)
        {
            return precio * 0.80;
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
            //sb.Append("CHUPETIN:");
            //sb.Append(base.MostrarEnVisor());
            //sb.Append($"Forma de chupetin: {formaChupetin} - Dureza: {dureza} - Envoltura transparente: {envolturaTransparente}");
            sb.AppendLine(string.Format("{0, -24}", "CHUPETIN"));
            sb.AppendLine(base.MostrarEnVisor());
            sb.AppendLine($"{"Forma:"} {formaChupetin,-22}");
            sb.AppendLine($"{"Dureza:"} {dureza,-40}");
            sb.AppendLine($"{"Envoltura transparente:"} {envolturaTransparente,-20}");
            return sb.ToString();
        }

        /// <summary>
        /// Calcula el precio final del chupetin, si se compra mas de 2 chupetines, aplico 20% de descuento.
        /// </summary>
        /// <returns>El precio final del chupetin.</returns>
        public override double CalcularPrecioFinal()
        {
            double precioFinal = Precio * Cantidad;

            if (Cantidad > 2)
            {
                precioFinal = ((ICalculos)this).CalcularDescuento(precioFinal);
            }
            if (cantidad < 0)
            {
                throw new MiExcepcion("La cantidad de golosinas no puede ser negativa");// fijarme si lla verifique en otro lado
            }
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
