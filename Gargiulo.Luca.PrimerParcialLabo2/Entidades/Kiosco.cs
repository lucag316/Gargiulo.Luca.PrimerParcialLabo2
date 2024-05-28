using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Representa un kiosco que almacena golosinas.
    /// </summary>
    public class Kiosco
    {
        #region Atributos
        private List<Golosina> golosinas;       // lista de golosinas disponibles en el kiosco
        private double capacidadGolosinasDistintas;   //Capacidad maxima de tipos diferentes de golosinas que el kiosco puede almacenar.
        private string detalle = "";    //inicializo asi no me tira advertencia
        #endregion

        #region Propiedades
        public List<Golosina> Golosinas
        {
            get { return this.golosinas; }
        }

        public string Detalle
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("=============== LISTA DE GOLOSINAS ===============");

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

        /// <summary>
        /// Constructor sin parametros que inicializa la lista de golosinas y establece una capacidad predeterminada.
        /// </summary>
        public Kiosco()
        {
            this.golosinas = new List<Golosina>();
            this.capacidadGolosinasDistintas = 10;
        }
        public Kiosco(double capacidadGolosinasDistintas) : this()
        {
            this.capacidadGolosinasDistintas = capacidadGolosinasDistintas;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los detalles de todas las golosinas en un formato adecuado para un visor.
        /// </summary>
        /// <returns>Una cadena con los detalles de todas las golosinas.</returns>
        public string MostrarDetalleEnVisor()
        {
            StringBuilder sb = new StringBuilder();

            List<Golosina> listaLocalGolosinas = this.Golosinas;

            int totalChocolates = 0;
            int totalChicles = 0;
            int totalChupetines = 0;
            int totalGolosinas = 0;

            double totalPrecioChocolates = 0;
            double totalPrecioChicles = 0;
            double totalPrecioChupetines = 0;
            double totalPrecioGolosinas = 0;

            sb.AppendLine("============== LISTA DE GOLOSINAS ==============");

            foreach (Golosina golosina in listaLocalGolosinas)
            {
                if (golosina is Chocolate)// si golosina es un Chocolate
                {
                    sb.AppendLine(((Chocolate)golosina).MostrarEnVisor());//lo casteo para tener ese metodo
                    totalChocolates += golosina.Cantidad;
                    totalPrecioChocolates += golosina.CalcularPrecioFinal();
                }
                else if (golosina is Chicle)
                {
                    sb.AppendLine(((Chicle)golosina).MostrarEnVisor());
                    totalChicles += golosina.Cantidad;
                    totalPrecioChicles += golosina.CalcularPrecioFinal();
                }
                else if (golosina is Chupetin)
                {
                    sb.AppendLine(((Chupetin)golosina).MostrarEnVisor());
                    totalChupetines += golosina.Cantidad;
                    totalPrecioChupetines += golosina.CalcularPrecioFinal();
                }
            }
            totalGolosinas = totalChocolates + totalChicles + totalChupetines;
            double precioTotal = CalcularPrecioTotal();
            sb.AppendLine("================================================");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("================= CANTIDADES ===================");
            sb.AppendLine($"Total de Chocolates: {totalChocolates}");
            sb.AppendLine($"Total de Chicles: {totalChicles}");
            sb.AppendLine($"Total de Chupetines: {totalChupetines}");
            sb.AppendLine($"Total de Golosinas: {totalGolosinas}");
            sb.AppendLine("================================================");
            sb.AppendLine("");
            sb.AppendLine("==================== PRECIOS ====================");
            sb.AppendLine($"Precio total de Chocolates: ${totalPrecioChocolates:F2}");
            sb.AppendLine($"Precio total de Chicles: ${totalPrecioChicles:F2}");
            sb.AppendLine($"Precio toal de Chupetines: ${totalPrecioChupetines:F2}");
            sb.AppendLine("================================================");
            sb.AppendLine($"  TOTAL: ${precioTotal:F2}");
            sb.AppendLine("================================================");
            sb.AppendLine("");

            return sb.ToString();
        }

        /// <summary>
        /// Muestra una lista de golosinas en un formato adecuado para un visor.
        /// </summary>
        /// <returns>Una cadena con la lista de golosinas.</returns>
        public string MostrarListaEnVisor()
        {
            StringBuilder sb = new StringBuilder();

            List<Golosina> listaLocalGolosinas = this.Golosinas;

            foreach (Golosina golosina in listaLocalGolosinas)
            {
                if (golosina is Chocolate)// si golosina es un Chocolate
                {
                    sb.AppendLine(((Chocolate)golosina).MostrarEnVisor()); //lo casteo para tener ese metodo
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

        /// <summary>
        /// Calcula el precio total de todas las golosinas en el kiosco.
        /// </summary>
        /// <returns>El precio total de todas las golosinas.</returns>
        public double CalcularPrecioTotal()
        {
            double precioTotal = 0;

            foreach (Golosina golosina in Golosinas)
            {
                precioTotal += golosina.CalcularPrecioFinal();
            }
            return precioTotal;
        }

        /// <summary>
        /// Ordena las golosinas por codigo de barra.
        /// </summary>
        //// <param name="ascendente">Si es true, ordena de forma ascendente; de lo contrario, de forma descendente.</param>
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

        /// <summary>
        /// Agrega una golosina al kiosco si no excede la capacidad maxima.
        /// </summary>
        //// <param name="kiosco">El kiosco al que se agrega la golosina.</param>
        //// <param name="golosina">La golosina a agregar.</param>
        /// <returns>El kiosco con la golosina agregada.</returns>
        public static Kiosco operator +(Kiosco kiosco, Golosina golosina)
        {
            if (kiosco.Golosinas.Count < kiosco.capacidadGolosinasDistintas)
            { 
                if (kiosco != golosina) //si la golosina no esta en el kiosco, la agrego
                { 
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

        /// <summary>
        /// Elimina una golosina del kiosco, solo si esta.
        /// </summary>
        //// <param name="kiosco">El kiosco del que se elimina la golosina.</param>
        //// <param name="golosina">La golosina a eliminar.</param>
        /// <returns>El kiosco con la golosina eliminada.</returns>
        public static Kiosco operator -(Kiosco kiosco, Golosina golosina)
        {
            if(kiosco.Golosinas.Count > 0)
            {
                if (kiosco == golosina)//si la golosina esta en el kiosco, la saco
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

        /// <summary>
        /// Agrega una lista de golosinas al kiosco si no excede la capacidad maxima.
        /// </summary>
        //// <param name="kiosco">El kiosco al que se agregan las golosinas.</param>
        //// <param name="listaGolosina">La lista de golosinas a agregar.</param>
        /// <returns>El kiosco con las golosinas agregadas.</returns>
        public static Kiosco operator +(Kiosco kiosco, List<Golosina> listaGolosina)
        {
            if (kiosco.Golosinas.Count + listaGolosina.Count <= kiosco.capacidadGolosinasDistintas)
            {
                if (listaGolosina != null) 
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

        /// <summary>
        /// Determina si una golosina esta en el kiosco.
        /// </summary>
        //// <param name="kiosco">El kiosco en el que se busca la golosina.</param>
        //// <param name="golosina">La golosina a buscar.</param>
        /// <returns>true si la golosina esta en el kiosco; de lo contrario, false.</returns>
        public static bool operator ==(Kiosco kiosco, Golosina golosina)
        {
            bool estaEnKiosco = false;

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

        /// <summary>
        /// Convierte un kiosco en una lista de golosinas implicitamente.
        /// </summary>
        //// <param name="kiosco">El kiosco a convertir.</param>
        public static implicit operator List<Golosina>(Kiosco kiosco)
        {
            return kiosco.Golosinas;
        }

        /// <summary>
        /// Convierte un kiosco en una cadena explicitamente.
        /// </summary>
        //// <param name="kiosco">El kiosco a convertir.</param>
        public static explicit operator string(Kiosco kiosco)
        {
            return kiosco.ToString();
        }
        #endregion

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (ReferenceEquals(obj, null))
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //public override int GetHashCode() //lo agregue para que no me tire advertencia
        //{
        //    throw new NotImplementedException();
        //}
    }
}
