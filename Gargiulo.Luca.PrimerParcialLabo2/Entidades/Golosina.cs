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
        protected int codigo;
        protected float peso;
        protected double precio;
        //protected string marca;
        //protected string popularidad;//nivel 1,2,3 o bajo, normal, alto puede ser
        //public Datetime fechaDeCaducidad; //puede ser
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
        #endregion

        #region Constructor
        public Golosina() //esta la pongo a eleccion, CAMBIARLA SI QUIERO
        {
            this.codigo = 0;
            this.peso = 0;
            this.precio = 0;
        }
        public Golosina(int codigo, float peso) : this()
        {
            this.codigo = codigo;
            this.peso = peso;
            this.precio = 0;
        }

        public Golosina(int codigo, float peso, double precio) : this(codigo, peso)
        {
            this.precio = precio;
        }
        #endregion

        #region Metodos
        public virtual string Mostrar() // esta al pedo porque hace lo mismo que el ToString
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Codigo de barra: {this.codigo}");
            sb.AppendLine($"Peso: {this.peso} kg");
            sb.AppendLine($"Precio: ${this.precio}");

            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Codigo: {this.codigo}");
            sb.AppendLine($"Peso: {this.peso} g");// creo que no hace falta el  ToString si ya esta en el return
            sb.AppendLine($"Precio: ${this.precio}");

            return sb.ToString();
        }

        public abstract string MostrarEnVisor();

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        #endregion

        #region Sobrecargas
        #endregion
    }
}
