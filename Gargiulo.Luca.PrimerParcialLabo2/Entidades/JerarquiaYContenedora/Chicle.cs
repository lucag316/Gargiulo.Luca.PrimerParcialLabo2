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
    /// Representa una golosina del tipo chicle.
    /// </summary>
    [Serializable]
    public class Chicle : Golosina, IDescuentoCalculable
    {
        #region Atributos
        protected ENivelesDeElasticidad elasticidad;
        protected ENivelesDuracionDeSabor duracionSabor;
        protected bool blanqueadorDental;
        #endregion

        #region Propiedades
        public ENivelesDeElasticidad Elasticidad
        {
            get { return this.elasticidad; }
            set { this.elasticidad = value; }
        }

        public ENivelesDuracionDeSabor DuracionSabor
        {
            get { return this.duracionSabor; }
            set { this.duracionSabor = value; }
        }

        public bool BlanqueadorDental
        {
            get { return this.blanqueadorDental; }
            set { this.blanqueadorDental = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros para poder usar JSON
        /// </summary>
        public Chicle() : base()
        {
            this.elasticidad = ENivelesDeElasticidad.Media;
            this.duracionSabor = ENivelesDuracionDeSabor.Media;
            this.blanqueadorDental = false;
        }

        /// <summary>
        /// Constructor que inicializa los atributos del chicle.
        /// </summary>
        //// <param name="codigo">Codigo del chicle.</param>
        //// <param name="peso">Peso del chicle.</param>
        //// <param name="precio">Precio del chicle.</param>
        //// <param name="cantidad">Cantidad de chicle.</param>
        public Chicle(int codigo, float peso, float precio, int cantidad) : base(codigo, peso, precio, cantidad)
        {
        }

        /// <summary>
        /// Constructor que inicializa los atributos del chicle con elasticidad.
        /// </summary>
        //// <param name="codigo">Codigo del chicle.</param>
        //// <param name="peso">Peso del chicle.</param>
        //// <param name="precio">Precio del chicle.</param>
        //// <param name="cantidad">Cantidad de chicle.</param>
        //// <param name="elasticidad">Elasticidad del chicle.</param>
        public Chicle(int codigo, float peso, float precio, int cantidad, ENivelesDeElasticidad elasticidad) : this(codigo, peso, precio, cantidad)
        {
            this.elasticidad = elasticidad;
        }

        /// <summary>
        /// Constructor que inicializa los atributos del chicle con elasticidad y duracion del sabor.
        /// </summary>
        //// <param name="codigo">Codigo del chicle.</param>
        //// <param name="peso">Peso del chicle.</param>
        //// <param name="precio">Precio del chicle.</param>
        //// <param name="cantidad">Cantidad de chicle.</param>
        //// <param name="elasticidad">Elasticidad del chicle.</param>
        //// <param name="duracionSabor">Duracion del sabor del chicle.</param>
        public Chicle(int codigo, float peso, float precio, int cantidad, ENivelesDeElasticidad elasticidad, ENivelesDuracionDeSabor duracionSabor) : this(codigo, peso, precio, cantidad, elasticidad)
        {
            this.duracionSabor = duracionSabor;
        }

        /// <summary>
        /// Constructor que inicializa los atributos del chicle con elasticidad, duracion del sabor y blanqueador dental.
        /// </summary>
        //// <param name="codigo">Codigo del chicle.</param>
        //// <param name="peso">Peso del chicle.</param>
        //// <param name="precio">Precio del chicle.</param>
        //// <param name="cantidad">Cantidad de chicle.</param>
        //// <param name="elasticidad">Elasticidad del chicle.</param>
        //// <param name="duracionSabor">Duracion del sabor del chicle.</param>
        //// <param name="blanqueadorDental">Blanqueador dental del chicle.</param>
        public Chicle(int codigo, float peso, float precio, int cantidad, ENivelesDeElasticidad elasticidad, ENivelesDuracionDeSabor duracionSabor, bool blanqueadorDental) : this(codigo, peso, precio, cantidad, elasticidad, duracionSabor)
        {
            this.blanqueadorDental = blanqueadorDental;
        }
        #endregion

        #region Metodos de Object sobrescritos
        /// <summary>
        /// Devuelve una cadena que representa el chicle.
        /// </summary>
        /// <returns>Una cadena con los detalles del chicle.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=============== CHICLE =================");
            sb.Append(base.ToString());
            sb.AppendLine($"Elasticidad: {this.elasticidad}");
            sb.AppendLine($"Duracion del sabor: {this.duracionSabor}");
            sb.AppendLine($"Blanqueador dental: {this.blanqueadorDental}");
            sb.AppendLine("========================================\n");

            return sb.ToString();
        }

        /// <summary>
        /// Compara el objeto actual con otro objeto para determinar si son iguales.
        /// Dos chicles se consideran iguales si comparten los mismos atributos heredados
        /// de la clase base Golosina y los especIficos de la clase Chicle.
        /// </summary>
        //// <param name="obj">El objeto a comparar con el chicle actual.</param>
        /// <returns>
        /// true si el objeto especificado es igual al chicle actual; de lo contrario, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            bool mismaGolosina = base.Equals(obj);

            bool mismoChicle = false;

            if (obj is Chicle)
            {
                if ((Chicle)obj == this && mismaGolosina == true)
                {
                    mismoChicle = true;
                }
            }
            return mismoChicle;
        }

        /// <summary>
        /// Devuelve un codigo hash para el objeto actual.
        /// </summary>
        /// <returns>Un codigo hash para el objeto actual.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), this.elasticidad, this.duracionSabor, this.blanqueadorDental);
        }
        #endregion

        #region Metodos Interfaces
        /// <summary>
        /// Calcula el descuento aplicado al precio original de la golosina.
        /// Este metodo implementa la logica para aplicar un descuento del 15%
        /// al precio proporcionado.
        /// </summary>
        //// <param name="precio">El precio original de la golosina.</param>
        /// <returns>El precio con el descuento aplicado.</returns>
        public double CalcularDescuento(double precio)
        {
            return precio * 0.85;
        }

        #endregion

        #region Metodos sobrescritos

        /// <summary>
        /// Muestra la informacion del chicle en un formato adecuado para un visor.
        /// </summary>
        /// <returns>Una cadena que contiene la informacion del chicle.</returns>
        public override string MostrarEnVisor()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(string.Format("{0, -27}", "CHICLE"));
            sb.Append(base.MostrarEnVisor());
            sb.AppendLine($"Elasticidad: {this.elasticidad,-18}");
            sb.AppendLine($"Duracion del sabor: {this.duracionSabor,-18}");
            sb.AppendLine($"Blanqueador dental: {this.blanqueadorDental,-20}");

            return sb.ToString();
        }

        /// <summary>
        /// Calcula el precio final del chicle, si se compra mas de 5 chicles, aplico 15% de descuento.
        /// </summary>
        /// <returns>El precio final del chicle.</returns>
        public override double CalcularPrecioFinal()
        {
            double precioFinal = this.Precio * this.Cantidad;

            if (this.Cantidad > 5)
            {
                precioFinal = CalcularDescuento(precioFinal);
            }
            if (this.Cantidad < 0)
            {
                throw new ExcepcionNumeroNegativo("La cantidad de golosinas no puede ser negativa");
            }
            return precioFinal;
        }
        #endregion

        #region Sobrecargas de operadores de igualdad

        /// <summary>
        /// Determina si dos instancias de Chicle son iguales.
        /// </summary>
        /// <returns>true si las instancias son iguales, sino false
        public static bool operator ==(Chicle chicle1, Chicle chicle2)
        {
            bool mismoGolosina = (Golosina)chicle1 == (Golosina)chicle2;

            bool mismoChicle = mismoGolosina && chicle1.Elasticidad == chicle2.Elasticidad &&
                                                chicle1.DuracionSabor == chicle2.DuracionSabor &&
                                                chicle1.blanqueadorDental == chicle2.blanqueadorDental;

            return mismoChicle;
        }

        /// <summary>
        /// Determina si dos instancias de chicle son diferentes.
        /// </summary>
        public static bool operator !=(Chicle chicle1, Chicle chicle2)
        {
            return !(chicle1 == chicle2);
        }
        #endregion
    }
}
