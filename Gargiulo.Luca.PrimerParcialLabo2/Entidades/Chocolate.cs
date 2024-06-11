﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Chocolate : Golosina, ICalculos
    {
        #region Atributos
        protected ERellenos relleno;
        protected ETiposDeCacao tipoDeCacao;
        #endregion

        #region Propiedades
        [JsonPropertyName("relleno")]
        public ERellenos Relleno
        {
            get { return this.relleno; }
            set { this.relleno = value;}
        }

        [JsonPropertyName("tipoDeCacao")]
        public ETiposDeCacao TipoDeCacao
        {
            get { return this.tipoDeCacao; }
            set { this.tipoDeCacao = value; }
        }
        #endregion

        #region Constructores
        public Chocolate() : base()//constructor sin parametros para poder usar JSON
        {
            this.relleno = ERellenos.SinRelleno;
            this.tipoDeCacao = ETiposDeCacao.Negro;
        }
        public Chocolate(int codigo, float peso, double precio, int cantidad) : base(codigo, peso, precio, cantidad)
        {
            //this.relleno = ERellenos.SinRelleno; 
            //this.tipoDeCacao = ETiposDeCacao.Negro;
        }
        public Chocolate(int codigo, float peso, double precio, int cantidad, ERellenos relleno): this(codigo, peso, precio, cantidad)
        {
            this.relleno = relleno;
        }
        public Chocolate(int codigo, float peso, double precio, int cantidad, ERellenos relleno, ETiposDeCacao tipoDeCacao) : this(codigo, peso, precio, cantidad, relleno)
        {
            this.tipoDeCacao = tipoDeCacao;

        }
        #endregion

        #region Metodos de Object sobrescritos

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=============== CHOCOLATE ===============");
            sb.Append(base.ToString());
            sb.AppendLine($"Relleno: {this.relleno}");
            sb.AppendLine($"Tipo de cacao: {this.tipoDeCacao}");
            sb.AppendLine("=========================================\n");

            return sb.ToString();
        }
        public override bool Equals(object? obj)
        {
            bool mismoChocolate = false;
            
            if (obj is Chocolate)
            {
                if (((Chocolate)obj) == this) // voy al == de chocolate y chocolate
                {
                    mismoChocolate = true;
                }
            }
            return mismoChocolate;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.codigo, this.precio, this.peso, this.cantidad, this.relleno, this.tipoDeCacao);
        }
        #endregion


        double ICalculos.CalcularDescuento(double precio)
        {
            return precio * 0.7;
        }

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
            sb.Append($"Relleno: {this.relleno} - Tipo de cacao: {this.tipoDeCacao}");

            return sb.ToString();
        }

        /// <summary>
        /// Calcula el precio final del chocolate, si se compra mas de 3 chocolates, aplico 30% de descuento.
        /// </summary>
        /// <returns>El precio final del chocolate.</returns>
        public override double CalcularPrecioFinal()
        {
            double precioFinal = base.Precio * base.Cantidad;



            if (base.Cantidad > 3)
            {
                precioFinal = ((ICalculos)this).CalcularDescuento(precioFinal); // ver bien porque lo tengo que castear asi

                //precioFinal *= 0.7;
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
            //bool mismoGolosina = (Golosina)chocolate1 == (Golosina)chocolate2;

            //bool mismoChocolate = mismoGolosina && chocolate1.Relleno == chocolate2.Relleno;

            //return mismoChocolate;
            return (Golosina)chocolate1 == (Golosina)chocolate2; //llamo al == de la clase base
        
        
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
