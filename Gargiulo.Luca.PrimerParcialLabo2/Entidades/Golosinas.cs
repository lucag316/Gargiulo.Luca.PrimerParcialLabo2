using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Golosinas
    {
        #region Atributos
        public double precio;
        public string marca;
        public string popularidad;//nivel 1,2,3 o bajo, normal, alto puede ser
        //public Datetime fechaDeCaducidad; //puede ser
        #endregion

        #region Propiedades
        #endregion

        #region Constructor
        public Golosinas() //esta la pongo a eleccion, CAMBIARLA SI QUIERO
        {

        }
        public Golosinas(double precio, string marca)
        {
            this.precio = precio;
            this.marca = marca;
        }

        public Golosinas(double precio, string marca, string popularidad) : this(precio, marca)
        {
            this.popularidad = popularidad;
        }
        #endregion

        #region Metodos
        public string Mostrar()
        {
            return $" ${this.precio} - Marca: {this.marca} - Popularidad: {this.popularidad}";
        }
        #endregion

        #region Sobrecargas
        #endregion
    }
}
