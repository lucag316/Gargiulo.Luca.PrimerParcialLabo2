using System;
using System.Collections.Generic;
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
        private int codigo; //seria como si fuera el codigo de barra
        private float peso;
        private double precio;
        protected int cantidad;
        #endregion

        #region Propiedades
        public int Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }
        public float Peso
        {
            get { return this.peso; }
            set { this.peso = value; }
        }
        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
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
            this.peso = 0;
            this.precio = 0;
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

        #region Metodos ToString, Equals, GetHashCode

        /// <summary>
        /// Devuelve una cadena que representa la golosina.
        /// </summary>
        public override string ToString()// si no sobreescribo el ToString, devuelve namespace.clase
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Codigo: {this.codigo.ToString()}");
            sb.AppendLine($"Peso: {this.peso.ToString()} g");
            sb.AppendLine($"Precio: ${this.precio.ToString()}");
            sb.AppendLine($"Cantidad: {this.cantidad.ToString()} unidades");

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

        public override int GetHashCode() //lo pongo para que no me tire advertiencia
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Metodos virtuales y abstractos
        /// <summary>
        /// Lo utilizan sus clases derivadas, devuelve una cadena con los detalles de las golosinas, en el visor
        /// </summary>
        public abstract string MostrarEnVisor();

        public virtual double CalcularPrecioFinal()
        {
            return this.Precio * this.Cantidad;
        }
        #endregion

        #region Sobrecarga de operadores de igualdad

        /// <summary>
        /// Determina si dos golosinas son iguales comparando sus codigos y pesos.
        /// </summary>
        /// <returns>True si las golosinas son iguales, sino false
        public static bool operator ==(Golosina golosina1, Golosina golosina2)
        {
            bool mismaGolosina = false;

            if (golosina1.Codigo == golosina2.Codigo && golosina1.Peso == golosina2.Peso)
            {
                mismaGolosina = true;
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
    }
}
