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

  
        //puedo tener un ordenar o un mostrar aca?


        public static Kiosco operator +(Kiosco kiosco, Golosina golosina)
        {
            if (!kiosco.Golosinas.Contains(golosina))
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







    }
}
