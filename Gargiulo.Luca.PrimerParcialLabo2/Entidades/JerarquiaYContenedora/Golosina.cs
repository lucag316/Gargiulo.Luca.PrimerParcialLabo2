using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;
using Entidades.Excepciones;
using Entidades.Interfaces;

namespace Entidades.JerarquiaYContenedora
{
    [Serializable] // para que pueda ser serializada
    [XmlInclude(typeof(Chocolate))]
    [XmlInclude(typeof(Chicle))]
    [XmlInclude(typeof(Chupetin))]
    public abstract class Golosina : IProductoDeUnKiosco
    {
        #region Atributos
        /// <summary>
        /// Codigo de la golosina (como si fuera el codigo de barra).
        /// </summary>
        protected int codigo;
        protected float precio;
        protected float peso;
        protected int cantidad;
        #endregion

        #region Propiedades
        public int Codigo
        {
            get { return this.codigo; }
            set
            {
                int numero;
                if(!int.TryParse(value.ToString(), out numero))
                {
                    throw new ExcepcionDatoNoNumerico("El codigo debe ser numerico");
                }
                if(value < 0)
                {
                    throw new ExcepcionNumeroNegativo("El codigo no puede ser negativo");
                }
                else if(value > 1000)
                {
                    throw new ExcepcionNumeroMuyAlto("El codigo debe ser menor o igual a 1000");
                }
                this.codigo = value;
            }
        }
        public float Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        public float Peso
        {
            get { return this.peso; }
            set { this.peso = value; }
        }
        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto que inicializa los atributos con valores predeterminados.
        /// </summary>
        public Golosina()
        {
            this.codigo = 0;
            this.precio = 0;
            this.peso = 0;
            this.cantidad = 0;
        }
        /// <summary>
        /// Constructor que inicializa el codigo de la golosina.
        /// </summary>
        //// <param name="codigo">Codigo de la golosina.</param>
        public Golosina(int codigo) : this()
        {
            this.codigo = codigo;
        }

        /// <summary>
        /// Constructor que inicializa el codigo y el peso de la golosina.
        /// </summary>
        //// <param name="codigo">Codigo de la golosina.</param>
        //// <param name="peso">Peso de la golosina en gramos.</param>
        public Golosina(int codigo, float peso) : this(codigo)
        {
            this.peso = peso;
        }

        /// <summary>
        /// Constructor que inicializa el codigo, peso y precio de la golosina.
        /// </summary>
        //// <param name="codigo">Codigo de la golosina.</param>
        //// <param name="peso">Peso de la golosina en gramos.</param>
        //// <param name="precio">Precio de la golosina.</param>
        public Golosina(int codigo, float peso, float precio) : this(codigo, peso)
        {
            this.precio = precio;
        }

        /// <summary>
        /// Constructor que inicializa el codigo, peso, precio y cantidad de la golosina.
        /// </summary>
        //// <param name="codigo">Codigo de la golosina.</param>
        //// <param name="peso">Peso de la golosina en gramos.</param>
        //// <param name="precio">Precio de la golosina.</param>
        //// <param name="cantidad">Cantidad disponible de la golosina.</param>
        public Golosina(int codigo, float peso, float precio, int cantidad) : this(codigo, peso, precio)
        {
            this.cantidad = cantidad;
        }
        #endregion

        #region Metodos de Object sobrescritos

        /// <summary>
        /// Devuelve una cadena que representa la golosina.
        /// </summary>
        /// <returns>Una cadena con los detalles de la golosina.</returns>
        public override string ToString()// si no sobreescribo el ToString, devuelve namespace.clase
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Codigo: {this.codigo}");    // no hace falta castearlo a string
            sb.AppendLine($"Precio: ${this.precio}");
            sb.AppendLine($"Peso: {this.peso} g");
            sb.AppendLine($"Cantidad: {this.cantidad} unidades");

            return sb.ToString();
        }

        /// <summary>
        /// Determina si el objeto especificado es igual a la golosina actual.
        /// </summary>
        //// <param name="obj">El objeto a comparar con la golosina actual.</param>
        /// <returns>True si el objeto especificado es igual a la golosina actual, en caso contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Golosina otraGolosina)
            {
                return this == otraGolosina;
            }
            return false;
        }

        /// <summary>
        /// Devuelve un codigo hash para el objeto actual.
        /// </summary>
        /// <returns>Un codigo hash para el objeto actual.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.codigo, this.precio, this.peso, this.cantidad);
        }
        #endregion

        #region Metodos virtuales y abstractos

        /// <summary>
        /// Devuelve una cadena con los detalles de las golosinas, utilizado en el visor.
        /// </summary>
        /// <returns>Una cadena con los detalles de las golosinas.</returns>
        public virtual string MostrarEnVisor()
        {
            StringBuilder sb = new StringBuilder();

            //sb.Append($"Codigo de barra: {this.Codigo} - Precio: ${this.Precio} - Peso: {this.Peso}g - Cantidad: {this.Cantidad} unidades - ");
            sb.AppendFormat("{0, -28} {1, -22} {2, -22} {3, -30}",
                            $"Codigo de barra: {this.Codigo}",
                            $"Precio: ${this.Precio}",
                            $"Peso: {this.Peso}g",
                            $"Cantidad: {this.Cantidad} unidades");

            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto para calcular el precio final de la golosina.
        /// </summary>
        /// <returns>El precio final de la golosina.</returns>
        public abstract double CalcularPrecioFinal();

        #endregion

        #region Sobrecargas de operadores de igualdad

        /// <summary>
        /// Determina si dos golosinas son iguales comparando sus codigos y pesos.
        /// </summary>
        /// <returns>True si las golosinas son iguales, sino false
        public static bool operator ==(Golosina golosina1, Golosina golosina2)
        {
            if (ReferenceEquals(golosina1, golosina2))
            {
                return true;
            }

            if (golosina1 is null || golosina2 is null)
            {
                return false;
            }

            return golosina1.Codigo == golosina2.Codigo && golosina1.Precio == golosina2.Precio;
        }

        /// <summary>
        /// Determina si dos golosinas son diferentes.
        /// </summary>
        /// <returns>True si las golosinas son diferentes, sino false
        public static bool operator !=(Golosina golosina1, Golosina golosina2)
        {
            return !(golosina1 == golosina2); // aca llamo al == de g1 y g2
        }
        #endregion

    }
}
