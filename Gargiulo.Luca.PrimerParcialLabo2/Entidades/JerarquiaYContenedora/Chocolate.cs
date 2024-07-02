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
    public class Chocolate : Golosina, ICalculos, IValidable
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
            relleno = ERellenos.SinRelleno;
            tipoDeCacao = ETiposDeCacao.Negro;
            esVegano = false;
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

        //DOCUMENTAR
        public override bool Equals(object? obj)
        {
            bool mismaGolosina = base.Equals(obj);

            if (obj is Chocolate otroChocolate)
            {
                return this == otroChocolate && mismaGolosina;
            }
            return false;
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
            double precioFinal = Precio * Cantidad;

            if (Cantidad > 3)
            {
                precioFinal = ((ICalculos)this).CalcularDescuento(precioFinal); 
                //precioFinal *= 0.7;
            }
            if (cantidad < 0)
            {
                throw new ExcepcionNumeroNegativo("La cantidad de golosinas no puede ser negativa");
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

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;
//using Entidades.Interfaces;
//using Entidades.Excepciones;

//namespace Entidades.JerarquiaYContenedora
//{
//    /// <summary>
//    /// Representa una golosina del tipo chocolate.
//    /// </summary>
//    [Serializable]
//    public class Chocolate : Golosina, ICalculos, IValidable
//    {
//        #region Atributos
//        protected ERellenos relleno;
//        protected ETiposDeCacao tipoDeCacao;
//        protected bool esVegano;
//        #endregion

//        #region Propiedades
//        //[JsonPropertyName("relleno")]
//        public ERellenos Relleno
//        {
//            get { return relleno; }
//            set { relleno = value; }
//        }

//        //[JsonPropertyName("tipoDeCacao")]
//        public ETiposDeCacao TipoDeCacao
//        {
//            get { return tipoDeCacao; }
//            set { tipoDeCacao = value; }
//        }

//        public bool EsVegano
//        {
//            get { return esVegano; }
//            set { esVegano = value; }
//        }
//        #endregion

//        #region Constructores
//        public Chocolate() : base()//constructor sin parametros para poder usar JSON
//        {
//            relleno = ERellenos.SinRelleno;
//            tipoDeCacao = ETiposDeCacao.Negro;
//            esVegano = false;
//        }
//        public Chocolate(int codigo, float peso, float precio, int cantidad) : base(codigo, peso, precio, cantidad)
//        {
//            //this.relleno = ERellenos.SinRelleno; 
//            //this.tipoDeCacao = ETiposDeCacao.Negro;
//            //this.porcentajeDeCacao = 0;
//            //this.esVegano = false;
//        }
//        public Chocolate(int codigo, float peso, float precio, int cantidad, ERellenos relleno) : this(codigo, peso, precio, cantidad)
//        {
//            this.relleno = relleno;
//        }
//        public Chocolate(int codigo, float peso, float precio, int cantidad, ERellenos relleno, ETiposDeCacao tipoDeCacao) : this(codigo, peso, precio, cantidad, relleno)
//        {
//            this.tipoDeCacao = tipoDeCacao;

//        }
//        public Chocolate(int codigo, float peso, float precio, int cantidad, ERellenos relleno, ETiposDeCacao tipoDeCacao, bool esVegano) : this(codigo, peso, precio, cantidad, relleno, tipoDeCacao)
//        {
//            this.esVegano = esVegano;

//        }
//        #endregion

//        #region Metodos de Object sobrescritos

//        public override string ToString()
//        {
//            StringBuilder sb = new StringBuilder();

//            sb.AppendLine("=============== CHOCOLATE ===============");
//            sb.Append(base.ToString());
//            sb.AppendLine($"Relleno: {relleno}");
//            sb.AppendLine($"Tipo de cacao: {tipoDeCacao}");
//            sb.AppendLine($"Es vegano: {esVegano}");
//            sb.AppendLine("=========================================\n");

//            return sb.ToString();
//        }
//        public override bool Equals(object? obj)
//        {
//            bool mismaGolosina = base.Equals(obj); //creo que estas modificaciones estan bien

//            bool mismoChocolate = false;


//            if (obj is Chocolate)
//            {
//                if ((Chocolate)obj == this && mismaGolosina == true) // voy al == de chocolate y chocolate
//                {
//                    mismoChocolate = true;
//                }
//            }
//            return mismoChocolate;
//        }
//        public override int GetHashCode()
//        {
//            return HashCode.Combine(codigo, precio, peso, cantidad, relleno, tipoDeCacao, esVegano);
//        }
//        #endregion

//        #region Metodos Interfaces

//        void IValidable.ValidarRangoPrecio()
//        {
//            if (Precio < 0 || Precio > 2000)
//            {
//                throw new ArgumentException("El precio del chocolate esta fuera del rango permitido($0 - $2000)");
//            }
//        }

//        void IValidable.ValidarRangoPeso()
//        {
//            if (Peso < 0 || Peso > 1000)
//            {
//                throw new ArgumentException("El peso del chocolate esta fuera del rango permitido(0 g - 1000 g)");
//            }
//        }
//        void IValidable.ValidarRangoCantidad()
//        {
//            if (Cantidad < 0 || Cantidad > 50)
//            {
//                throw new ArgumentException("La cantidad del chocolate esta fuera del rango permitido(0 - 50)");
//            }
//        }

//        double ICalculos.CalcularDescuento(double precio)
//        {
//            return precio * 0.7;
//        }

//        #endregion

//        #region Metodos sobrescritos

//        /// <summary>
//        /// Muestra la informacion del chocolate en un formato adecuado para un visor.
//        /// </summary>
//        /// <returns>Una cadena que contiene la informacion del chocolate.</returns>
//        public override string MostrarEnVisor()
//        {
//            StringBuilder sb = new StringBuilder();
//            //sb.Append("CHOCOLATE:");
//            sb.AppendLine(string.Format("{0, -20}", "CHOCOLATE"));
//            sb.Append(base.MostrarEnVisor());
//            //sb.Append($"Relleno: {relleno} - Tipo de cacao: {tipoDeCacao} - Es vegano: {esVegano}");
//            sb.AppendLine($"Relleno: {relleno,-20}");
//            sb.AppendLine($"Tipo de cacao: {tipoDeCacao,-29}");
//            sb.AppendLine($"Es vegano: {esVegano,-20}");
//            return sb.ToString();
//        }
//        //CHOCOLATE    CodigodeBarra:0     Precio:$0     Peso:0g      Cantidad:0 unidades      Relleno:SinRelleno    Tipo de cacao:Negro     Es vegano:true
//        /// <summary>
//        /// Calcula el precio final del chocolate, si se compra mas de 3 chocolates, aplico 30% de descuento.
//        /// </summary>
//        /// <returns>El precio final del chocolate.</returns>
//        public override double CalcularPrecioFinal()
//        {
//            double precioFinal = Precio * Cantidad;

//            if (Cantidad > 3)
//            {
//                precioFinal = ((ICalculos)this).CalcularDescuento(precioFinal); // ver bien porque lo tengo que castear asi

//                //precioFinal *= 0.7;
//            }
//            if (cantidad < 0)
//            {
//                throw new MiExcepcion("La cantidad de golosinas no puede ser negativa");// fijarme si lla verifique en otro lado
//            }
//            return precioFinal;
//        }
//        #endregion

//        #region Sobrecargas de operadores de igualdad

//        /// <summary>
//        /// Determina si dos instancias de Chocolate son iguales.
//        /// </summary>
//        /// <returns>true si las instancias son iguales, sino false
//        public static bool operator ==(Chocolate chocolate1, Chocolate chocolate2)
//        {
//            // ESTO COMENTADO SE ME OCURRIO, VER SI ESTA BIEN
//            bool mismoGolosina = chocolate1 == (Golosina)chocolate2;

//            bool mismoChocolate = mismoGolosina && chocolate1.Relleno == chocolate2.Relleno &&
//                                                   chocolate1.TipoDeCacao == chocolate2.TipoDeCacao &&
//                                                   chocolate1.esVegano == chocolate2.esVegano;

//            return mismoChocolate;
//            //return (Golosina)chocolate1 == (Golosina)chocolate2; //llamo al == de la clase base, NO SIRVE SOLO CON DECIR QUE LAS GOLOSINAS SON IGUALES


//        }

//        /// <summary>
//        /// Determina si dos instancias de Chocolate son diferentes.
//        /// </summary>
//        public static bool operator !=(Chocolate chocolate1, Chocolate chocolate2)
//        {
//            return !(chocolate1 == chocolate2);
//        }
//        #endregion
//    }
//}
