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
        protected double precio;
        protected double cantidad;
        //protected string marca;
        //protected string popularidad;//nivel 1,2,3 o bajo, normal, alto puede ser
        //public Datetime fechaDeCaducidad; //puede ser
        #endregion

        #region Propiedades
        #endregion

        #region Constructor
        public Golosina() //esta la pongo a eleccion, CAMBIARLA SI QUIERO
        {
            this.codigo = 0;
            this.precio = 0;
            this.cantidad = 0;
        }
        public Golosina(int codigo, double precio) : this()
        {
            this.codigo = codigo;
            this.precio = precio;
            this.cantidad = 0;
        }

        public Golosina(int codigo, double precio, double cantidad) : this(codigo, precio)
        {
            this.cantidad = cantidad;
        }
        #endregion

        #region Metodos
        public virtual string Mostrar() // esta al pedo porque hace lo mismo que el ToString
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Codigo: {this.codigo}");
            sb.AppendLine($"Precio: {this.precio}");
            sb.Append($"Cantidad: {this.cantidad}");

            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Codigo: {this.codigo}");
            sb.AppendLine($"Precio: {this.precio}");
            sb.Append($"Cantidad: {this.cantidad}");// creo que no hace falta el  ToString si ya esta en el return

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
