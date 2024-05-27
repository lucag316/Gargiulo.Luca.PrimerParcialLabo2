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
    [DataContract]//para json
    public abstract class Golosina
    {
        #region Atributos
        private int codigo;
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

        #region Constructor
        //constructor sin parametros para poder usar JSON
        public Golosina() //esta la pongo a eleccion, CAMBIARLA SI QUIERO
        {
            this.codigo = 0;
            this.peso = 0;
            this.precio = 0;
            this.cantidad = 0;
        }
        public Golosina(int codigo, float peso) : this()
        {
            this.codigo = codigo;
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
        //puedo hacer protegido el Mostrar y pasarselo a ToString con this.Mostrar(), en To string no hago nada
        public override string ToString()// si no sobreescribo el ToString, devuelve namespace.clase
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Codigo: {this.codigo.ToString()}");
            sb.AppendLine($"Peso: {this.peso.ToString()} g");
            sb.AppendLine($"Precio: ${this.precio.ToString()}");
            sb.AppendLine($"Cantidad: {this.cantidad.ToString()} unidades");

            return sb.ToString();
        }
        public override bool Equals(object? obj) //Equals determinna si dos objetos son iguales
        {
            bool mismaGolosina = false;
            //por ej, verifico si el obj es del mismo tipo osea si es Golosina
            if (obj is Golosina)
            {
                if(((Golosina)obj) == this) // voy al == de Golosina y Golosina
                {
                    mismaGolosina = true;
                }
            }
            return mismaGolosina;
        }
        /*public override int GetHashCode()
        {
            return base.GetHashCode();
        }*/
        #endregion

        #region Metodos virtuales y abstractos
        public virtual string Mostrar() // esta al pedo porque hace lo mismo que el ToString
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Codigo de barra: {this.codigo}");
            sb.AppendLine($"Peso: {this.peso} kg");
            sb.AppendLine($"Precio: ${this.precio}");

            return sb.ToString();
        }
        public abstract string MostrarEnVisor();
        public virtual double CalcularPrecioFinal()
        {
            return this.Precio * this.Cantidad;
        }
        #endregion

        #region Sobrecarga de operadores de igualdad
        public static bool operator ==(Golosina golosina1, Golosina golosina2) //DICE RELACIONARLO CON equals, y si pongo == en equals y listo?
        {
            bool mismaGolosina = false;

            if (golosina1.Codigo == golosina2.Codigo && golosina1.Peso == golosina2.Peso)
            {
                mismaGolosina = true;
            }

            return mismaGolosina;
        }
        public static bool operator !=(Golosina golosina1, Golosina golosina2)
        {
            return !(golosina1 == golosina2); // aca llamo al == de g1 y g2
        }
        #endregion
    }
}
