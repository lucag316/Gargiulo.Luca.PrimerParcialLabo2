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
    [Serializable]
    public class Chocolate : Golosina, ICalculos, IValidable
    {
        #region Atributos
        protected ERellenos relleno;
        protected ETiposDeCacao tipoDeCacao;
        //protected int porcentajeDeCacao;
        protected bool esVegano;
        #endregion

        #region Propiedades
        //[JsonPropertyName("relleno")]
        public ERellenos Relleno
        {
            get { return relleno; }
            set { relleno = value; }
        }

        //[JsonPropertyName("tipoDeCacao")]
        public ETiposDeCacao TipoDeCacao
        {
            get { return tipoDeCacao; }
            set { tipoDeCacao = value; }
        }

        public bool EsVegano
        {
            get { return esVegano; }
            set { esVegano = value; }
        }
        #endregion

        #region Constructores
        public Chocolate() : base()//constructor sin parametros para poder usar JSON
        {
            relleno = ERellenos.SinRelleno;
            tipoDeCacao = ETiposDeCacao.Negro;
            esVegano = false;
        }
        public Chocolate(int codigo, float peso, float precio, int cantidad) : base(codigo, peso, precio, cantidad)
        {
            //this.relleno = ERellenos.SinRelleno; 
            //this.tipoDeCacao = ETiposDeCacao.Negro;
            //this.porcentajeDeCacao = 0;
            //this.esVegano = false;
        }
        public Chocolate(int codigo, float peso, float precio, int cantidad, ERellenos relleno) : this(codigo, peso, precio, cantidad)
        {
            this.relleno = relleno;
        }
        public Chocolate(int codigo, float peso, float precio, int cantidad, ERellenos relleno, ETiposDeCacao tipoDeCacao) : this(codigo, peso, precio, cantidad, relleno)
        {
            this.tipoDeCacao = tipoDeCacao;

        }
        public Chocolate(int codigo, float peso, float precio, int cantidad, ERellenos relleno, ETiposDeCacao tipoDeCacao, bool esVegano) : this(codigo, peso, precio, cantidad, relleno, tipoDeCacao)
        {
            this.esVegano = esVegano;

        }
        #endregion

        #region Metodos de Object sobrescritos

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=============== CHOCOLATE ===============");
            sb.Append(base.ToString());
            sb.AppendLine($"Relleno: {relleno}");
            sb.AppendLine($"Tipo de cacao: {tipoDeCacao}");
            sb.AppendLine($"Es vegano: {esVegano}");
            sb.AppendLine("=========================================\n");

            return sb.ToString();
        }
        public override bool Equals(object? obj)
        {
            bool mismaGolosina = base.Equals(obj); //creo que estas modificaciones estan bien

            bool mismoChocolate = false;


            if (obj is Chocolate)
            {
                if ((Chocolate)obj == this && mismaGolosina == true) // voy al == de chocolate y chocolate
                {
                    mismoChocolate = true;
                }
            }
            return mismoChocolate;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(codigo, precio, peso, cantidad, relleno, tipoDeCacao, esVegano);
        }
        #endregion

        #region Metodos Interfaces

        void IValidable.ValidarRangoPrecio()
        {
            if (Precio < 0 || Precio > 2000)
            {
                throw new ArgumentException("El precio del chocolate esta fuera del rango permitido($0 - $2000)");
            }
        }

        void IValidable.ValidarRangoPeso()
        {
            if (Peso < 0 || Peso > 1000)
            {
                throw new ArgumentException("El peso del chocolate esta fuera del rango permitido(0 g - 1000 g)");
            }
        }
        void IValidable.ValidarRangoCantidad()
        {
            if (Cantidad < 0 || Cantidad > 50)
            {
                throw new ArgumentException("La cantidad del chocolate esta fuera del rango permitido(0 - 50)");
            }
        }

        double ICalculos.CalcularDescuento(double precio)
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
            sb.Append("CHOCOLATE:");
            sb.Append(base.MostrarEnVisor());
            sb.Append($"Relleno: {relleno} - Tipo de cacao: {tipoDeCacao} - Es vegano: {esVegano}");

            return sb.ToString();
        }

        /// <summary>
        /// Calcula el precio final del chocolate, si se compra mas de 3 chocolates, aplico 30% de descuento.
        /// </summary>
        /// <returns>El precio final del chocolate.</returns>
        public override double CalcularPrecioFinal()
        {
            double precioFinal = Precio * Cantidad;

            if (Cantidad > 3)
            {
                precioFinal = ((ICalculos)this).CalcularDescuento(precioFinal); // ver bien porque lo tengo que castear asi

                //precioFinal *= 0.7;
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
        /// Determina si dos instancias de Chocolate son iguales.
        /// </summary>
        /// <returns>true si las instancias son iguales, sino false
        public static bool operator ==(Chocolate chocolate1, Chocolate chocolate2)
        {
            // ESTO COMENTADO SE ME OCURRIO, VER SI ESTA BIEN
            bool mismoGolosina = chocolate1 == (Golosina)chocolate2;

            bool mismoChocolate = mismoGolosina && chocolate1.Relleno == chocolate2.Relleno &&
                                                   chocolate1.TipoDeCacao == chocolate2.TipoDeCacao &&
                                                   chocolate1.esVegano == chocolate2.esVegano;

            return mismoChocolate;
            //return (Golosina)chocolate1 == (Golosina)chocolate2; //llamo al == de la clase base, NO SIRVE SOLO CON DECIR QUE LAS GOLOSINAS SON IGUALES


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
