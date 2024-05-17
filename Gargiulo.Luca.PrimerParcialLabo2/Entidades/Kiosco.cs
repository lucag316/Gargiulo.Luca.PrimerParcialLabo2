using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Kiosco
    {
        #region Atributos
        private List<Golosina> golosinas;

        private double precioChocolate;
        private double precioChicle;
        private double precioChupetin;

        private double capacidadGolosinas = 10;

        private string detalle;
        #endregion

        #region Propiedades
        public List<Golosina> Golosinas
        {
            get
            {
                return this.golosinas;
            }
        }
        public string Detalle
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("\n=============== PRECIOS GOLOSINAS ===============");
                sb.AppendLine($"   Precio chocolate: ${this.precioChocolate.ToString()}");
                sb.AppendLine($"   Precio chicle: {this.precioChicle.ToString()}");
                sb.AppendLine($"   Precio chupetin: {this.precioChupetin.ToString()}");
                sb.AppendLine("=================================================\n");

                foreach (Golosina golosina in Golosinas)
                {
                    if (golosina is Chocolate)// si golosina es un Chocolate
                    {
                        sb.AppendLine(((Chocolate)golosina).ToString());//lo casteo para tener ese metodo
                    }
                    else if (golosina is Chicle)
                    {
                        sb.AppendLine(((Chicle)golosina).ToString());
                    }
                    else if (golosina is Chupetin)
                    {
                        sb.AppendLine(((Chupetin)golosina).ToString());
                    }
                }
                return sb.ToString();
            }
        }
        #endregion

        #region Constructores
        private Kiosco() //no me acuerdo porque privado, pero solo inicializo la lista de golosinas
        {
            this.golosinas =new List<Golosina>();
        }
        public Kiosco(double precioChocolate, double precioChicle, double precioChupetin, double capacidadGolosinas) : this()
        {
            this.precioChocolate = precioChocolate;
            this.precioChicle = precioChicle;
            this.precioChupetin = precioChupetin;

            this.capacidadGolosinas = capacidadGolosinas;
        }
        #endregion

        //puedo tener un ordenar o un mostrar aca?

        public int CompararGolosinasPorCodigo(Golosina golosina1, Golosina golosina2, bool ascendente)
        {
            int retorno;
            if (ascendente)// si ascendente es true
            {               // si golosina1 tiene un Codigo menor que golosina 2, retorna un valor negativo
                retorno = golosina1.Codigo.CompareTo(golosina2.Codigo);//si tiene el mismo codigo, retorna 0, si golosina1 es mayor a 2, retorna un valor positivo
                //if(int.Parse(golosina1.Codigo) > int.Parse(golosina2.Codigo)); ES LO MISMO
            }
            else
            {
                retorno = golosina2.Codigo.CompareTo(golosina1.Codigo);
            }
            return retorno;
        }
        public void OrdenarGolosinasPorCodigo(bool ascendente)
        {
            Golosinas.Sort((golosina1, golosina2) => CompararGolosinasPorCodigo(golosina1, golosina2, ascendente));
        }//no me salia de otra manera, no entendi bien el landa

        public static int OrdenarGolosinasPorPeso(Golosina golosina1, Golosina golosina2, bool ascendente)
        {
            int retorno;
            if (ascendente)// si ascendente es true
            {               // si golosina1 tiene un Peso menor que golosina 2, retorna un valor negativo
                retorno = golosina1.Peso.CompareTo(golosina2.Peso);//si tiene el mismo Peso, retorna 0, si golosina1 es mayor a 2, retorna un valor positivo
            }
            else
            {
                retorno = golosina2.Peso.CompareTo(golosina1.Peso);
            }
            return retorno;
        }


        #region Operadores suma y resta
        public static Kiosco operator +(Kiosco kiosco, Golosina golosina)
        {
            if (kiosco.Golosinas.Count < kiosco.capacidadGolosinas) // si la cantidad de golosinas en la lista, es menor a la capacidad/stock que tiene el kiosco
            { 
                if (kiosco != golosina) //(!kiosco.Golosinas.Contains(golosina))// capaz es comparando, agregar si no esta por ejemplo fijandose que codigo es
                { //si la golosina no esta en el kiosco, la agrego
                    kiosco.Golosinas.Add(golosina);
                }
                else
                {
                    Console.WriteLine("La golosina ya esta en el kiosco");
                }
            }
            else
            {
                Console.WriteLine("No se puede agregar mas, es la capacidad maxima del kiosco");
            }
            return kiosco;
        }
        public static Kiosco operator -(Kiosco kiosco, Golosina golosina)
        {
            if(kiosco.Golosinas.Count > 0)
            {
                if (kiosco == golosina)//si la golosina esta en el kiosco, la saco, //(kiosco.Golosinas.Contains(golosina)), NO SE QUE SERIA MEJOR
                {
                    kiosco.Golosinas.Remove(golosina);
                }
                else
                {
                    Console.WriteLine("La golosina no esta en el kiosco");
                }
            }
            else
            {
                Console.WriteLine("El kiosco no tiene golosinas");
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
            // NO SE QUE FORMA SERIA MEJOR
            //foreach(Golosina item in kiosco.Golosinas)
            //{
            //    if(item == golosina)
            //    {
            //        estaEnKiosco = true;
            //        break;
            //    }
            //}

            return estaEnKiosco;
        }
        public static bool operator !=(Kiosco kiosco, Golosina golosina)
        {
            return !(kiosco == golosina); // va hacia el ==
        }
        #endregion

        //PODRIA HACER UN MOSTRAR KIOSCO


    }
}
