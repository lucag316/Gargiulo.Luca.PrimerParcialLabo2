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

        }
        public Golosina(int codigo, double precio)
        {
            this.codigo = codigo;
            this.precio = precio;
        }

        public Golosina(int codigo, double precio, double cantidad) : this(codigo, precio)
        {
            this.cantidad = cantidad;
        }
        #endregion

        #region Metodos
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Codigo: {this.codigo}");
            sb.AppendLine($"Precio: {this.precio}");
            sb.Append($"Cantidad: {this.cantidad}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        #endregion

        #region Sobrecargas
        #endregion
    }
}
