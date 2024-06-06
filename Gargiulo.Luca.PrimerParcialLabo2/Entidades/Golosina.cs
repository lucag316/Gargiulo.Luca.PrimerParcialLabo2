using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Chocolate))]
    [XmlInclude(typeof(Chicle))]
    [XmlInclude(typeof(Chupetin))]
    [DataContract] //para JSON
    public abstract class Golosina
    {
        #region Atributos
        protected int codigo; //seria como si fuera el codigo de barra
        protected double precio;
        protected float peso;
        protected int cantidad;
        #endregion

        #region Propiedades
        public int Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }
        public double Precio
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
        public Golosina()   //constructor sin parametros para poder usar JSON
        {
            this.codigo = 0;
            this.precio = 0;
            this.peso = 0;
            this.cantidad = 0;
        }
        public Golosina(int codigo) : this()
        {
            this.codigo = codigo;
        }
        public Golosina(int codigo, float peso) : this(codigo)
        {
            this.peso = peso;
        }
        public Golosina(int codigo, float peso, double precio) : this(codigo, peso)
        {
            this.precio = precio;
        }
        public Golosina(int codigo, float peso, double precio, int cantidad) : this(codigo, peso, precio)
        {
            this.cantidad = cantidad;
        }
        #endregion

        #region Metodos de Object sobrescritos

        /// <summary>
        /// Devuelve una cadena que representa la golosina.
        /// </summary>
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
        /// <returns>True si el objeto especificado es igual a la golosina actual, sino false
        public override bool Equals(object? obj) //Equals determinna si dos objetos son iguales
        {
            bool mismaGolosina = false;

            if (obj is Golosina)
            {
                if(((Golosina)obj) == this) // voy al == de Golosina y Golosina
                {
                    mismaGolosina = true;
                }
            }
            return mismaGolosina;
        }

        /// <summary>
        /// Devuelve un código hash para el objeto actual.
        /// </summary>
        public override int GetHashCode() //SI LO POMGO ME TIRA UN ERROR AL GUARDAR XML, porque no se utiliza el metodo//lo pongo para que no me tire advertiencia, que hago?
        {
            //throw new NotImplementedException();
            return HashCode.Combine(this.codigo, this.precio, this.peso, this.cantidad); // si le pongo esto, se arregla
        }
        #endregion

        #region Metodos virtuales y abstractos

        /// <summary>
        /// Lo utilizan sus clases derivadas, devuelve una cadena con los detalles de las golosinas, en el visor
        /// </summary>
        public virtual string MostrarEnVisor()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Codigo de barra: {this.Codigo} - Precio: ${this.Precio} - Peso: {this.Peso}g - Cantidad: {this.Cantidad} unidades - ");

            return sb.ToString();
        }

        public abstract double CalcularPrecioFinal();
  
        #endregion

        #region Sobrecargas de operadores de igualdad

        /// <summary>
        /// Determina si dos golosinas son iguales comparando sus codigos y pesos.
        /// </summary>
        /// <returns>True si las golosinas son iguales, sino false
        public static bool operator ==(Golosina golosina1, Golosina golosina2)
        {
            bool mismaGolosina = false;

            if (ReferenceEquals(golosina1, golosina2))
            {
                mismaGolosina = true;
            }

            if (golosina1 is null || golosina2 is null) // le pongo is en vez de == para que no me advierta lo de valores null
            {
                mismaGolosina = false;
            }
            else if (!(golosina1 is null && golosina2 is null))
            {
                if (golosina1.Codigo == golosina2.Codigo &&
                    golosina1.precio == golosina2.precio && 
                    golosina1.Peso == golosina2.Peso)
                {
                    mismaGolosina = true;
                }
            }
            return mismaGolosina;
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

        #region Metodos Auxiliares

        private static int ValidarNoNegativo(int valor, string nombrePropiedad)
        {
            // si hago esto, tengo que asignar los parametros de los constructores, a sus propiedades, no a atributos, sino, no validaria
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException(nombrePropiedad, $"{nombrePropiedad} no puede ser negativo");
            }
            return valor;
        }

        #endregion
    }
}
