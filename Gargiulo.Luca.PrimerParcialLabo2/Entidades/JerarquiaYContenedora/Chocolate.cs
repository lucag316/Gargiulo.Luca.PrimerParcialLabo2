using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Entidades.Interfaces;
using Entidades.Excepciones;

namespace Entidades.JerarquiaYContenedora
{
    /// <summary>
    /// Representa una golosina del tipo chocolate.
    /// </summary>
    [Serializable]
    public class Chocolate : Golosina, IDescuentoCalculable
    {
        #region Atributos
        protected ERellenos relleno;
        protected ETiposDeCacao tipoDeCacao;
        protected bool esVegano;
        #endregion

        #region Propiedades
        public ERellenos Relleno
        {
            get { return this.relleno; }
            set { this.relleno = value; }
        }

        public ETiposDeCacao TipoDeCacao
        {
            get { return this.tipoDeCacao; }
            set { this.tipoDeCacao = value; }
        }

        public bool EsVegano
        {
            get { return this.esVegano; }
            set { this.esVegano = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros para poder usar JSON
        /// </summary>
        public Chocolate() : base()
        {
            this.relleno = ERellenos.SinRelleno;
            this.tipoDeCacao = ETiposDeCacao.Negro;
            this.esVegano = false;
        }

        /// <summary>
        /// Constructor que inicializa los atributos del chocolate.
        /// </summary>
        //// <param name="codigo">Codigo del chocolate.</param>
        //// <param name="peso">Peso del chocolate.</param>
        //// <param name="precio">Precio del chocolate.</param>
        //// <param name="cantidad">Cantidad de chocolates.</param>
        public Chocolate(int codigo, float peso, float precio, int cantidad) : base(codigo, peso, precio, cantidad)
        {

        }

        /// <summary>
        /// Constructor que inicializa los atributos del chocolate con relleno.
        /// </summary>
        //// <param name="codigo">Codigo del chocolate.</param>
        //// <param name="peso">Peso del chocolate.</param>
        //// <param name="precio">Precio del chocolate.</param>
        //// <param name="cantidad">Cantidad de chocolates.</param>
        //// <param name="relleno">Tipo de relleno del chocolate.</param>
        public Chocolate(int codigo, float peso, float precio, int cantidad, ERellenos relleno) : this(codigo, peso, precio, cantidad)
        {
            this.relleno = relleno;
        }

        /// <summary>
        /// Constructor que inicializa los atributos del chocolate con relleno y tipo de cacao.
        /// </summary>
        //// <param name="codigo">Codigo del chocolate.</param>
        //// <param name="peso">Peso del chocolate.</param>
        //// <param name="precio">Precio del chocolate.</param>
        //// <param name="cantidad">Cantidad de chocolates.</param>
        //// <param name="relleno">Tipo de relleno del chocolate.</param>
        //// <param name="tipoDeCacao">Tipo de cacao del chocolate.</param>
        public Chocolate(int codigo, float peso, float precio, int cantidad, ERellenos relleno, ETiposDeCacao tipoDeCacao) : this(codigo, peso, precio, cantidad, relleno)
        {
            this.tipoDeCacao = tipoDeCacao;

        }

        /// <summary>
        /// Constructor que inicializa todos los atributos del chocolate.
        /// </summary>
        //// <param name="codigo">oódigo del chocolate.</param>
        //// <param name="peso">Peso del chocolate.</param>
        //// <param name="precio">Precio del chocolate.</param>
        //// <param name="cantidad">Cantidad de chocolates.</param>
        //// <param name="relleno">Tipo de relleno del chocolate.</param>
        //// <param name="tipoDeCacao">Tipo de cacao del chocolate.</param>
        //// <param name="esVegano">Indica si el chocolate es vegano.</param>
        public Chocolate(int codigo, float peso, float precio, int cantidad, ERellenos relleno, ETiposDeCacao tipoDeCacao, bool esVegano) : this(codigo, peso, precio, cantidad, relleno, tipoDeCacao)
        {
            this.esVegano = esVegano;

        }
        #endregion

        #region Metodos de Object sobrescritos

        /// <summary>
        /// Devuelve una cadena que representa el chocolate.
        /// </summary>
        /// <returns>Una cadena con los detalles del chocolate.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=============== CHOCOLATE ===============");
            sb.Append(base.ToString());
            sb.AppendLine($"Relleno: {this.relleno}");
            sb.AppendLine($"Tipo de cacao: {this.tipoDeCacao}");
            sb.AppendLine($"Es vegano: {this.esVegano}");
            sb.AppendLine("=========================================\n");

            return sb.ToString();
        }

        /// <summary>
        /// Compara el objeto actual con otro objeto para determinar si son iguales.
        /// Dos chocolates se consideran iguales si comparten el mismo codigo, precio,
        /// cantidad, relleno, tipo de cacao y condicion vegana.
        /// </summary>
        //// <param name="obj">El objeto a comparar con el chocolate actual.</param>
        /// <returns>True si el objeto especificado es igual al chocolate actual; de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            bool mismaGolosina = base.Equals(obj);

            bool mismoChocolate = false;

            if (obj is Chocolate)
            {
                if((Chocolate)obj == this && mismaGolosina == true)
                {
                    mismoChocolate = true;
                }
            }
            return mismoChocolate;
        }

        /// <summary>
        /// Devuelve un codigo hash para el objeto actual.
        /// </summary>
        /// <returns>Un codigo hash para el objeto actual.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), this.relleno, this.tipoDeCacao, this.esVegano);
        }
        #endregion

        #region Metodos Interfaces
        /// <summary>
        /// Calcula el descuento aplicado al precio original de la golosina.
        /// Este metodo implementa la logica para aplicar un descuento del 30%
        /// al precio proporcionado.
        /// </summary>
        //// <param name="precio">El precio original de la golosina.</param>
        /// <returns>El precio con el descuento aplicado.</returns>
        public double CalcularDescuento(double precio)
        {
            return precio * 0.7;
        }

        #endregion

        #region Metodos sobrescritos

        /// <summary>
        /// Muestra la informacion del chocolate en un formato adecuado para un visor.
        /// </summary>
        /// <returns>Una cadena que contiene la informacion del chocolate.</returns>
        public override string MostrarEnVisor()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("{0, -20}", "CHOCOLATE"));
            sb.Append(base.MostrarEnVisor());
            sb.AppendLine($"Relleno: {this.relleno,-20}");
            sb.AppendLine($"Tipo de cacao: {this.tipoDeCacao,-29}");
            sb.AppendLine($"Es vegano: {this.esVegano,-20}");

            return sb.ToString();
        }
        
        /// <summary>
        /// Calcula el precio final del chocolate, si se compra mas de 3 chocolates, aplico 30% de descuento.
        /// </summary>
        /// <returns>El precio final del chocolate.</returns>
        public override double CalcularPrecioFinal()
        {
            double precioFinal = this.Precio * this.Cantidad;

            if (this.Cantidad > 3)
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
        /// Determina si dos instancias de Chocolate son iguales.
        /// Dos chocolates se consideran iguales si comparten el mismo codigo, precio, cantidad, relleno,
        /// tipo de cacao y condición vegana.
        /// </summary>
        //// <param name="chocolate1">Primer chocolate a comparar.</param>
        //// <param name="chocolate2">Segundo chocolate a comparar.</param>
        /// <returns>True si las dos instancias de Chocolate son iguales; de lo contrario, false.</returns>
        public static bool operator ==(Chocolate chocolate1, Chocolate chocolate2)
        {
            bool mismaGolosina = (Golosina)chocolate1 == (Golosina)chocolate2;

            bool mismoChocolate = mismaGolosina && chocolate1.Relleno == chocolate2.Relleno &&
                                   chocolate1.TipoDeCacao == chocolate2.TipoDeCacao &&
                                   chocolate1.EsVegano == chocolate2.EsVegano;

            return mismoChocolate;
        }

        /// <summary>
        /// Determina si dos instancias de Chocolate son diferentes.
        /// </summary>
        public static bool operator !=(Chocolate chocolate1, Chocolate chocolate2)
        {
            return !(chocolate1 == chocolate2);
        }
        #endregion
    }
}
