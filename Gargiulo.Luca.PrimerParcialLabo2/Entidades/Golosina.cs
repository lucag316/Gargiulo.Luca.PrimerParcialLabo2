using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
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
            get
            {
                return this.codigo;
            }
        }
        public float Peso
        {
            get
            {
                return this.peso;
            }
        }
        public double Precio
        {
            get
            {
                return this.precio;
            }
        }
        public double Cantidad
        {
            get
            {
                return this.cantidad;
            }
        }
        #endregion

        #region Constructor
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

            sb.AppendLine($"Codigo: {this.codigo}");
            sb.AppendLine($"Peso: {this.peso} g");// creo que no hace falta el  ToString si ya esta en el return
            sb.AppendLine($"Precio: ${this.precio}");
            sb.AppendLine($"Cantidad: {this.cantidad} unidades");

            return sb.ToString();
        }
        public override bool Equals(object? obj) //Equals determinna si dos objetos son iguales
        {
            bool mismaGolosina = false;
            //por ej, verifico si el obj es del mismo tipo osea si es Golosina
            if (obj != null && GetType() == obj.GetType()) // podria poner    obj is Golosina, digo si no es nul para no cerrucho verde
            {
                Golosina golosina = (Golosina)obj;

                if(golosina.Codigo == this.Codigo && golosina.Peso == this.Peso) // voy al == de Golosina y Golosina
                {
                    mismaGolosina = true;
                }
            }
            return mismaGolosina;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.codigo, this.peso); //buscar algo para entender mejor
        }
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
        public static bool operator ==(Golosina golosina1, Golosina golosina2)
        {
            bool mismaGolosina = false;

            if(golosina1.Equals(golosina2))// en Equals comparo codigo y peso, decia que tenia que usarlo en ==
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

        #region Operadores implicitos y explicitos
        #endregion

        #region Sobrecargas
        #endregion
    }
}
