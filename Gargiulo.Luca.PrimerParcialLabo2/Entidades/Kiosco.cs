using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Kiosco
    {
        private List<Golosina> golosinas;

        private double precioGolosina; //o cambiar el precio de la otra clase o de este

        //atributos de comprar o vender?capaz puedo poner

        private string detalle;//podria crearle tipo un string para que muestre bien lindo

        public List<Golosina> Golosinas
        {
            get
            {
                return this.golosinas;
            }
        }


        private Kiosco() //no me acuerdo porque privado, pero solo inicializo la lista de golosinas
        {
            this.golosinas =new List<Golosina>();
        }
        public Kiosco(double precioGolosina) : this()
        {
            this.precioGolosina = precioGolosina;
        }


        //puedo tener un ordenar o un mostrar aca?

        //Agregar la posibilidad de poder ordenar los objetos de la colección con, al menos,
        //dos criterios distintos de ordenamiento.Cada criterio de ordenación deberá incluir el modo
        //ascendente y descendente.
        public static int OrdenarGolosinasPorCodigo(Golosina golosina1, Golosina golosina2, bool ascendente)
        {
            int retorno;
            if (ascendente)// si ascendente es true
            {               // si golosina1 tiene un Codigo menor que golosina 2, retorna un valor negativo
                retorno = golosina1.Codigo.CompareTo(golosina2.Codigo);//si tiene el mismo codigo, retorna 0, si golosina1 es mayor a 2, retorna un valor positivo
            }
            else
            {
                retorno = golosina2.Codigo.CompareTo(golosina1.Codigo);
            }
            return retorno;
        }
        

        #region Operadores suma y resta
        public static Kiosco operator +(Kiosco kiosco, Golosina golosina)
        {
            if (!kiosco.Golosinas.Contains(golosina)) // capaz es comparando, agregar si no esta por ejemplo fijandose que codigo es
            {
                kiosco.Golosinas.Add(golosina);
            }
            return kiosco;
        }
        public static Kiosco operator -(Kiosco kiosco, Golosina golosina)
        {
            if (kiosco.Golosinas.Contains(golosina))
            {
                kiosco.Golosinas.Remove(golosina);
            }
            return kiosco;
        }
        #endregion

        #region Operadores de igualdad
        public static bool operator ==(Kiosco kiosco, Golosina golosina)
        {
            bool estaEnKiosco = false;

            if (kiosco.Golosinas.Contains(golosina))
            {
                estaEnKiosco = true;
            }
            return estaEnKiosco;
        }
        public static bool operator !=(Kiosco kiosco, Golosina golosina)
        {
            return !(kiosco == golosina); // va hacia el ==
        }
        #endregion

    }
}
