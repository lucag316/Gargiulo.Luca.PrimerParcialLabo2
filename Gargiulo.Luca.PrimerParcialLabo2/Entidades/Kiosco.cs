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
        private double capacidadGolosinasDistintas;
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
                double precioTotal = CalcularPrecioTotal();

                sb.AppendLine("\n=============== PRECIOS TOTAL ===============");
                sb.AppendLine($"         ${precioTotal.ToString()}");
                sb.AppendLine("===============================================\n");

                return sb.ToString();
            }
        }
        #endregion

        #region Constructores
        public Kiosco() //no me acuerdo porque privado, pero solo inicializo la lista de golosinas
        {
            this.golosinas =new List<Golosina>();
            this.capacidadGolosinasDistintas = 10; //fijarse si esta bien puesto aca
        }
        public Kiosco(double capacidadGolosinasDistintas) : this()
        {
            this.capacidadGolosinasDistintas = capacidadGolosinasDistintas;
        }
        #endregion

        #region Metodos

        public string MostrarDetalleEnVisor()
        {
            StringBuilder sb = new StringBuilder();

            List<Golosina> listaLocalGolosinas = this.Golosinas;

            foreach (Golosina golosina in listaLocalGolosinas)
            {
                if (golosina is Chocolate)// si golosina es un Chocolate
                {
                    sb.AppendLine(((Chocolate)golosina).MostrarEnVisor());//lo casteo para tener ese metodo
                }
                else if (golosina is Chicle)
                {
                    sb.AppendLine(((Chicle)golosina).MostrarEnVisor());
                }
                else if (golosina is Chupetin)
                {
                    sb.AppendLine(((Chupetin)golosina).MostrarEnVisor());
                }
                double precioTotal = CalcularPrecioTotal();

                sb.AppendLine("\n=============== PRECIOS TOTAL ===============");
                sb.AppendLine($"         ${precioTotal.ToString()}");
                sb.AppendLine("===============================================\n");
            }
            return sb.ToString();

        }

        public string MostrarListaEnVisor()
        {
            StringBuilder sb = new StringBuilder();

            List<Golosina> listaLocalGolosinas = this.Golosinas;

            foreach (Golosina golosina in listaLocalGolosinas)
            {
                if (golosina is Chocolate)// si golosina es un Chocolate
                {
                    sb.AppendLine(((Chocolate)golosina).MostrarEnVisor());//lo casteo para tener ese metodo
                }
                else if (golosina is Chicle)
                {
                    sb.AppendLine(((Chicle)golosina).MostrarEnVisor());
                }
                else if (golosina is Chupetin)
                {
                    sb.AppendLine(((Chupetin)golosina).MostrarEnVisor());
                }
            }
            return sb.ToString();
        }

        public double CalcularPrecioTotal() //calcular el precio total de la lista
        {
            double precioTotal = 0;

            foreach (Golosina golosina in Golosinas)
            {
                precioTotal += golosina.CalcularPrecioFinal();
            }
            return precioTotal;
        }

        public void OrdenarGolosinasPorCodigo(bool ascendente)
        {
            if (ascendente)
            {
                this.Golosinas.Sort((golosina1, golosina2) => golosina1.Codigo.CompareTo(golosina2.Codigo));
            }
            else
            {
                this.Golosinas.Sort((golosina1, golosina2) => golosina2.Codigo.CompareTo(golosina1.Codigo));
            }
        }
        public void OrdenarGolosinasPorPeso(bool ascendente)
        {
            if (ascendente)
            {
                this.Golosinas.Sort((golosina1, golosina2) => golosina1.Peso.CompareTo(golosina2.Peso));
            }
            else
            {
                this.Golosinas.Sort((golosina1, golosina2) => golosina2.Peso.CompareTo(golosina1.Peso));
            }
        }


        #endregion

        #region Operadores suma y resta

        public static Kiosco operator +(Kiosco kiosco, Golosina golosina)
        {
            if (kiosco.Golosinas.Count < kiosco.capacidadGolosinasDistintas) // si la cantidad de golosinas en la lista, es menor a la capacidad/stock que tiene el kiosco
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
        public static Kiosco operator +(Kiosco kiosco, List<Golosina> listaGolosina)
        {
            if (kiosco.Golosinas.Count < kiosco.capacidadGolosinasDistintas) // si la cantidad de golosinas en la lista, es menor a la capacidad/stock que tiene el kiosco
            {
                if (kiosco != null  && listaGolosina != null) 
                { 
                    kiosco.Golosinas.AddRange(listaGolosina);
                }
                else
                {
                    Console.WriteLine("Error, no se puede operar valores nulos");
                }
            }
            else
            {
                Console.WriteLine("No se puede agregar mas, es la capacidad maxima del kiosco");
            }
            return kiosco;
        }
        #endregion

        #region Operadores de igualdad
        public static bool operator ==(Kiosco kiosco, Golosina golosina)
        {
            bool estaEnKiosco = false;

            //if (kiosco.Golosinas.Contains(golosina))
            //{
            //    estaEnKiosco = true;
            //}
            // NO SE QUE FORMA SERIA MEJOR | //podemos hacer contains solo si tenemos Equals sobrecargado
            foreach (Golosina item in kiosco.Golosinas)
            {
                if (item == golosina)
                {
                    estaEnKiosco = true;
                    break;
                }
            }

            return estaEnKiosco;
        }
        public static bool operator !=(Kiosco kiosco, Golosina golosina)
        {
            return !(kiosco == golosina); // va hacia el ==
        }
        #endregion

        #region Operadores implicitos y explicitos
        public static implicit operator List<Golosina>(Kiosco kiosco)
        {
            return kiosco.Golosinas;
        }
        public static explicit operator string (Kiosco kiosco)
        {
            return kiosco.ToString();
        }
        #endregion


    }
}
