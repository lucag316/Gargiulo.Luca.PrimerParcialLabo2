using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Golosina
    {
        #region Atributos
        protected double precio;
        protected string marca;
        protected string popularidad;//nivel 1,2,3 o bajo, normal, alto puede ser
        //public Datetime fechaDeCaducidad; //puede ser
        #endregion

        #region Propiedades
        #endregion

        #region Constructor
        public Golosina() //esta la pongo a eleccion, CAMBIARLA SI QUIERO
        {

        }
        public Golosina(double precio, string marca)
        {
            this.precio = precio;
            this.marca = marca;
        }

        public Golosina(double precio, string marca, string popularidad) : this(precio, marca)
        {
            this.popularidad = popularidad;
        }
        #endregion

        #region Metodos
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Precio: {this.precio}");
            sb.AppendLine($"Marca: {this.marca}");
            sb.Append($"Popilaridad: {this.popularidad}");

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
