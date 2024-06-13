using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Entidades.Interfaces;
using Entidades.Excepciones;

namespace Entidades
{
    [Serializable]
    public class Chupetin: Golosina, ICalculos
    {
        #region Atributos
        protected EFormasDeChupetin formaChupetin;
        protected ENivelesDeDureza dureza;
        protected bool envolturaTransparente;
        #endregion

        #region Propiedades
        [JsonPropertyName("formaChupetin")]
        public EFormasDeChupetin FormaChupetin
        {
            get { return this.formaChupetin;}
            set { this.formaChupetin = value;}
        }

        [JsonPropertyName("dureza")]
        public ENivelesDeDureza Dureza
        {
            get { return this.dureza; }
            set { this.dureza = value; }
        }
        #endregion

        #region Constructores
        public Chupetin() : base() //constructor sin parametros para poder usar JSON
        {
            this.formaChupetin = EFormasDeChupetin.Redondo;
            this.dureza = ENivelesDeDureza.Media;
        }
        public Chupetin(int codigo, float peso, double precio, int cantidad) : base(codigo, peso, precio, cantidad)
        {
            //this.formaChupetin = EFormasDeChupetin.Redondo;
            //this.dureza = ENivelesDeDureza.Media;
        }
        public Chupetin(int codigo, float peso, double precio, int cantidad, EFormasDeChupetin formaChupetin) : this(codigo, peso, precio, cantidad)
        {
            this.formaChupetin = formaChupetin;
        }
        public Chupetin(int codigo, float peso, double precio, int cantidad, EFormasDeChupetin formaChupetin, ENivelesDeDureza dureza) : this(codigo, peso, precio, cantidad, formaChupetin)
        {
            this.dureza = dureza;
        }
        #endregion

        #region Metodos de Object sobrescritos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=============== CHUPETIN ===============");
            sb.Append(base.ToString());
            sb.AppendLine($"Forma de Chupetin: {this.formaChupetin}");
            sb.AppendLine($"Dureza: {this.dureza}");
            sb.AppendLine("========================================\n");

            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            bool mismaGolosina = base.Equals(obj);

            bool mismoChupetin = false;

            if (obj is Chupetin)
            {
                if (((Chupetin)obj) == this && mismaGolosina == true)
                {
                    mismoChupetin = true;
                }
            }
            return mismoChupetin;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.codigo, this.precio, this.peso, this.cantidad, this.formaChupetin, this.dureza);
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
            sb.Append("CHUPETIN:");
            sb.Append(base.MostrarEnVisor());
            sb.Append($"Forma de chupetin: {this.formaChupetin} - Dureza: {this.dureza}");

            return sb.ToString();
        }

        /// <summary>
        /// Calcula el precio final del chupetin, si se compra mas de 2 chupetines, aplico 20% de descuento.
        /// </summary>
        /// <returns>El precio final del chupetin.</returns>
        public override double CalcularPrecioFinal()
        {
            double precioFinal = base.Precio * base.Cantidad;

            if (base.Cantidad > 2)
            {
                precioFinal = ((ICalculos)this).CalcularDescuento(precioFinal);
            }
            if (base.cantidad < 0)
            {
                throw new MiExcepcion("La cantidad de golosinas no puede ser negativa");// fijarme si lla verifique en otro lado
            }
            return precioFinal;
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
            bool mismoGolosina = (Golosina)chupetin1 == (Golosina)chupetin2;

            bool mismoChupetin = mismoGolosina && chupetin1.FormaChupetin == chupetin2.FormaChupetin && chupetin1.Dureza == chupetin2.Dureza;

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
