﻿using Entidades.Interfaces;
using System.Runtime.CompilerServices;
using System.Text;

namespace Entidades.JerarquiaYContenedora
{

    /// <summary>
    /// Representa un kiosco que almacena golosinas.
    /// </summary>
    //// <typeparam name="T">Tipo de golosina que puede almacenar el kiosco.</typeparam>
    public class Kiosco<T> : IOrdenable<T> where T : IProductoDeUnKiosco
    {
        #region Atributos
        private List<T> productos;
        private int capacidadProductosDistintos;
        #endregion

        #region Eventos
        /// <summary>
        /// Evento lanzado cuando se alcanza la capacidad maxima del kiosco.
        /// </summary>
        public static event MensajeKioscoHandler? CapacidadMaximaAlcanzada; //lo hice estatic asi los puedo poner en +
        public static event MensajeKioscoHandler? ProductoYaEstaEnLista;
        public static event MensajeKioscoHandler? ProductoAgregadoExitosamente;
        public static event MensajeKioscoHandler? ProductoEliminadoExitosamente;
        public static event MensajeKioscoHandler? ProductoModificadoExitosamente;
        #endregion

        #region Propiedades
        /// <summary>
        /// Lista de golosinas almacenadas en el kiosco.
        /// </summary>
        public List<T> Productos
        {
            get { return this.productos; }
        }
        /// <summary>
        /// Capacidad maxima de golosinas distintas que puede contener el kiosco.
        /// </summary>
        public int CapacidadProductosDistintos
        {
            get => this.capacidadProductosDistintos;
            set => this.capacidadProductosDistintos = value;
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor sin parametros que inicializa el kiosco con una capacidad predeterminada.
        /// </summary>
        public Kiosco()
        {
            this.productos = new List<T>();
            this.capacidadProductosDistintos = 4;
        }
        /// <summary>
        /// Constructor que inicializa el kiosco con una capacidad especificada.
        /// </summary>
        //// <param name="capacidadGolosinasDistintas">Capacidad maxima de golosinas distintas que puede contener el kiosco.</param>
        public Kiosco(int capacidadProductosDistintos) : this()
        {
            this.capacidadProductosDistintos = capacidadProductosDistintos;
        }
        #endregion

        #region Metodos de visualizacion y calculo

        /// <summary>
        /// Muestra la lista de golosinas en un formato adecuado para un visor.
        /// </summary>
        /// <returns>Cadena con la lista de golosinas.</returns>
        public string MostrarListaEnVisor()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T producto in this.Productos)
            {
                sb.AppendLine(producto.MostrarEnVisor());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Muestra la lista de golosinas junto con el precio total en un formato adecuado para un visor.
        /// </summary>
        /// <returns>Cadena con la lista de golosinas y el precio total.</returns>
        public string MostrarListaEnVisorDetalle()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("============================================= LISTA DE GOLOSINAS ==========================================");
            foreach (T producto in this.Productos)
            {
                sb.AppendLine(producto.ToString());
            }
            double precioTotal = CalcularPrecioTotal();

            sb.AppendLine("\n============================================= PRECIOS TOTAL =============================================");
            sb.AppendLine($"  TOTAL: ${precioTotal.ToString()}");
            sb.AppendLine("========================================================================================================\n");
            
            return sb.ToString();
        }

        /// <summary>
        /// Calcula el precio total de todas las golosinas en el kiosco.
        /// </summary>
        /// <returns>Precio total de todas las golosinas.</returns>
        public double CalcularPrecioTotal()
        {
            double precioTotal = 0;

            foreach (T producto in this.Productos)
            {
                precioTotal += producto.CalcularPrecioFinal();
            }

            return precioTotal;
        }
        #endregion

        #region Metodos de Ordenamiento
        /// <summary>
        /// Ordena las golosinas del kiosco segun los selectores especificados y el criterio de orden ascendente o descendente.
        /// </summary>
        //// <typeparam name="TPropiedad1">Tipo de la primera propiedad para ordenar.</typeparam>
        //// <typeparam name="TPropiedad2">Tipo de la segunda propiedad para ordenar.</typeparam>
        //// <param name="selector1">Selector de la primera propiedad.</param>
        //// <param name="selector2">Selector de la segunda propiedad.</param>
        //// <param name="ascendente">true para ordenar ascendente, false para ordenar descendente.</param>
        public void Ordenar<TPropiedad1, TPropiedad2>(Func<T, TPropiedad1> selector1, Func<T, TPropiedad2> selector2, bool ascendente)
        {
            if (ascendente)
            {
                Productos.Sort((g1, g2) =>
                {
                    int resultado = Comparar(selector1(g1), selector1(g2));
                    if (resultado == 0)
                    {
                        resultado = Comparar(selector2(g1), selector2(g2));
                    }
                    return resultado;
                });
            }
            else
            {
                Productos.Sort((g1, g2) =>
                {
                    int resultado = Comparar(selector1(g2), selector1(g1));
                    if (resultado == 0)
                    {
                        resultado = Comparar(selector2(g2), selector2(g1));
                    }
                    return resultado;
                });
            }
        }

        private int Comparar<TPropiedad>(TPropiedad valor1, TPropiedad valor2)
        {
            if (valor1 is IComparable comparable)
            {
                return comparable.CompareTo(valor2);
            }
            throw new ArgumentException("Los tipos de propiedad no son comparables.");
        }
        #endregion

        #region Operadores suma y resta

        /// <summary>
        /// Agrega una golosina al kiosco si no se ha alcanzado la capacidad maxima.
        /// </summary>
        //// <param name="kiosco">Kiosco al que se agrega la golosina.</param>
        //// <param name="golosina">Golosina a agregar.</param>
        /// <returns>Kiosco con la golosina agregada.</returns>
        public static Kiosco<T> operator +(Kiosco<T> kiosco, T producto)
        {
            if (kiosco.Productos.Count < kiosco.capacidadProductosDistintos)
            {
                if (kiosco != producto) //si la golosina no esta en el kiosco, la agrego
                {
                    kiosco.Productos.Add(producto);
                    ProductoAgregadoExitosamente?.Invoke($"Se agrego un producto con el codigo de barra: {producto.Codigo} exitosamente");
                }
                else
                {
                    ProductoYaEstaEnLista?.Invoke("El producto ya esta en el kiosco");
                }
            }
            else
            {
                CapacidadMaximaAlcanzada?.Invoke("No se puede agregar mas, se alcanzo la capacidad maxima del kiosco.");
            }
            return kiosco;
        }

        /// <summary>
        /// Elimina una golosina del kiosco si esta presente.
        /// </summary>
        //// <param name="kiosco">Kiosco del que se elimina la golosina.</param>
        //// <param name="golosina">Golosina a eliminar.</param>
        /// <returns>Kiosco con la golosina eliminada.</returns>
        public static Kiosco<T> operator -(Kiosco<T> kiosco, T producto)
        {
            if (kiosco.Productos.Count > 0)
            {
                if (kiosco == producto)//si la golosina esta en el kiosco, la saco
                {
                    kiosco.Productos.Remove(producto);
                    ProductoEliminadoExitosamente?.Invoke($"Se elimino el producto con codigo de barra: {producto.Codigo} exitosamente.");
                }
                else
                {
                    ProductoYaEstaEnLista?.Invoke($"El producto {producto.Codigo} ya no esta en el kiosco.");
                }
            }
            return kiosco;
        }

        /// <summary>
        /// Agrega una lista de golosinas al kiosco si no se supera la capacidad maxima.
        /// </summary>
        //// <param name="kiosco">Kiosco al que se agregan las golosinas.</param>
        //// <param name="listaGolosina">Lista de golosinas a agregar.</param>
        /// <returns>Kiosco con las golosinas agregadas.</returns>
        public static Kiosco<T> operator +(Kiosco<T> kiosco, List<T> listaProductos)
        {
            if (kiosco.Productos.Count + listaProductos.Count <= kiosco.capacidadProductosDistintos)
            {
                if (listaProductos != null)
                {
                    kiosco.Productos.AddRange(listaProductos);
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

        #region Operadores de igualdad //DOCUMENTAR MEJOR

        /// <summary>
        /// Determina si una golosina esta en el kiosco.
        /// </summary>
        //// <param name="kiosco">El kiosco en el que se busca la golosina.</param>
        //// <param name="golosina">La golosina a buscar.</param>
        /// <returns>true si la golosina esta en el kiosco; de lo contrario, false.</returns>
        public static bool operator ==(Kiosco<T> kiosco, T producto)
        {
            bool estaEnKiosco = false;

            foreach (T item in kiosco.Productos)
            {
                if (item.Codigo == producto.Codigo)
                {
                    estaEnKiosco = true;
                    break;
                }
            }
            return estaEnKiosco;
        }
        public static bool operator !=(Kiosco<T> kiosco, T producto)
        {
            return !(kiosco == producto); // va hacia el ==
        }
        #endregion

        #region Operadores implicitos y explicitos
        /// <summary>
        /// Convierte el kiosco en una lista de golosinas implicitamente.
        /// </summary>
        //// <param name="kiosco">Kiosco a convertir.</param>
        public static implicit operator List<T>(Kiosco<T> kiosco)
        {
            return kiosco.Productos;
        }

        /// <summary>
        /// Convierte el kiosco en una cadena de texto explicitamente.
        /// </summary>
        //// <param name="kiosco">Kiosco a convertir.</param>
        public static explicit operator string(Kiosco<T> kiosco)
        {
            return $"Kiosco con {kiosco.Productos.Count} golosinas";
        }
        #endregion

        #region Metodos de object sobrescritos
        /// <summary>
        /// Determina si el objeto actual es igual a otro objeto.
        /// </summary>
        //// <param name="obj">Objeto a comparar.</param>
        /// <returns>true si el objeto es igual al objeto actual; de lo contrario, false.</returns>
        /*public override bool Equals(object? obj)
        {
            if (obj is null) return false; // Si obj es nulo, no son iguales

            if (ReferenceEquals(this, obj)) return true; // Si son la misma instancia en memoria, son iguales

            if (obj is T producto) // Si obj es de tipo T (o derivado de Golosina)
            {
                return this == producto; // Usa el operador == definido en Kiosco<T>
            }
            else if (obj is Kiosco<T> otherKiosco) // Si obj es otro Kiosco<T>
            {
                return this.Productos.SequenceEqual(otherKiosco.Productos); // Compara las listas de Productos
            }

            return false; // Si obj no es ni T ni Kiosco<T>, no son iguales
        }*/

        public override int GetHashCode() //lo agregue para que no me tire advertencia
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}



//using Entidades.Interfaces;
//using System.Runtime.CompilerServices;
//using System.Text;

//namespace Entidades.JerarquiaYContenedora
//{

//    /// <summary>
//    /// Representa un kiosco que almacena golosinas.
//    /// </summary>
//    //// <typeparam name="T">Tipo de golosina que puede almacenar el kiosco.</typeparam>
//    public class Kiosco<T> : IOrdenable<T> where T : IProductoDeUnKiosco
//    {
//        #region Atributos
//        private List<T> golosinas;
//        private int capacidadGolosinasDistintas;
//        #endregion

//        #region Eventos
//        /// <summary>
//        /// Evento lanzado cuando se alcanza la capacidad maxima del kiosco.
//        /// </summary>
//        public static event MensajeKioscoHandler? CapacidadMaximaAlcanzada; //lo hice estatic asi los puedo poner en +
//        public static event MensajeKioscoHandler? GolosinaYaEstaEnLista;
//        public static event MensajeKioscoHandler? GolosinaAgregadaExitosamente;
//        public static event MensajeKioscoHandler? GolosinaEliminadaExitosamente;
//        public static event MensajeKioscoHandler? GolosinaModificadaExitosamente;
//        #endregion

//        #region Propiedades
//        /// <summary>
//        /// Lista de golosinas almacenadas en el kiosco.
//        /// </summary>
//        public List<T> Golosinas
//        {
//            get { return this.golosinas; }
//        }
//        /// <summary>
//        /// Capacidad maxima de golosinas distintas que puede contener el kiosco.
//        /// </summary>
//        public int CapacidadGolosinasDistintas
//        {
//            get => this.capacidadGolosinasDistintas;
//            set => this.capacidadGolosinasDistintas = value;
//        }
//        #endregion

//        #region Constructores

//        /// <summary>
//        /// Constructor sin parametros que inicializa el kiosco con una capacidad predeterminada.
//        /// </summary>
//        public Kiosco()
//        {
//            this.golosinas = new List<T>();
//            this.capacidadGolosinasDistintas = 4;
//        }
//        /// <summary>
//        /// Constructor que inicializa el kiosco con una capacidad especificada.
//        /// </summary>
//        //// <param name="capacidadGolosinasDistintas">Capacidad maxima de golosinas distintas que puede contener el kiosco.</param>
//        public Kiosco(int capacidadGolosinasDistintas) : this()
//        {
//            this.capacidadGolosinasDistintas = capacidadGolosinasDistintas;
//        }
//        #endregion

//        #region Metodos de visualizacion y calculo

//        /// <summary>
//        /// Muestra la lista de golosinas en un formato adecuado para un visor.
//        /// </summary>
//        /// <returns>Cadena con la lista de golosinas.</returns>
//        public string MostrarListaEnVisor()
//        {
//            StringBuilder sb = new StringBuilder();

//            foreach (T golosina in Golosinas)
//            {
//                sb.AppendLine(golosina.MostrarEnVisor());
//            }
//            return sb.ToString();
//        }

//        /// <summary>
//        /// Muestra la lista de golosinas junto con el precio total en un formato adecuado para un visor.
//        /// </summary>
//        /// <returns>Cadena con la lista de golosinas y el precio total.</returns>
//        public string MostrarListaEnVisorDetalle()
//        {
//            StringBuilder sb = new StringBuilder();
//            sb.AppendLine("============================================= LISTA DE GOLOSINAS ==========================================");
//            foreach (T golosina in Golosinas)
//            {
//                sb.AppendLine(golosina.ToString());
//            }
//            double precioTotal = CalcularPrecioTotal();

//            sb.AppendLine("\n============================================= PRECIOS TOTAL =============================================");
//            sb.AppendLine($"  TOTAL: ${precioTotal.ToString()}");
//            sb.AppendLine("========================================================================================================\n");

//            return sb.ToString();
//        }

//        /// <summary>
//        /// Calcula el precio total de todas las golosinas en el kiosco.
//        /// </summary>
//        /// <returns>Precio total de todas las golosinas.</returns>
//        public double CalcularPrecioTotal()
//        {
//            double precioTotal = 0;

//            foreach (T golosina in golosinas)
//            {
//                precioTotal += golosina.CalcularPrecioFinal();
//            }

//            return precioTotal;
//        }
//        #endregion

//        #region Metodos de Ordenamiento
//        /// <summary>
//        /// Ordena las golosinas del kiosco segun los selectores especificados y el criterio de orden ascendente o descendente.
//        /// </summary>
//        //// <typeparam name="TPropiedad1">Tipo de la primera propiedad para ordenar.</typeparam>
//        //// <typeparam name="TPropiedad2">Tipo de la segunda propiedad para ordenar.</typeparam>
//        //// <param name="selector1">Selector de la primera propiedad.</param>
//        //// <param name="selector2">Selector de la segunda propiedad.</param>
//        //// <param name="ascendente">true para ordenar ascendente, false para ordenar descendente.</param>
//        public void Ordenar<TPropiedad1, TPropiedad2>(Func<T, TPropiedad1> selector1, Func<T, TPropiedad2> selector2, bool ascendente)
//        {
//            if (ascendente)
//            {
//                Golosinas.Sort((g1, g2) =>
//                {
//                    int resultado = Comparar(selector1(g1), selector1(g2));
//                    if (resultado == 0)
//                    {
//                        resultado = Comparar(selector2(g1), selector2(g2));
//                    }
//                    return resultado;
//                });
//            }
//            else
//            {
//                Golosinas.Sort((g1, g2) =>
//                {
//                    int resultado = Comparar(selector1(g2), selector1(g1));
//                    if (resultado == 0)
//                    {
//                        resultado = Comparar(selector2(g2), selector2(g1));
//                    }
//                    return resultado;
//                });
//            }
//        }

//        private int Comparar<TPropiedad>(TPropiedad valor1, TPropiedad valor2)
//        {
//            if (valor1 is IComparable comparable)
//            {
//                return comparable.CompareTo(valor2);
//            }
//            throw new ArgumentException("Los tipos de propiedad no son comparables.");
//        }
//        #endregion

//        #region Operadores suma y resta

//        /// <summary>
//        /// Agrega una golosina al kiosco si no se ha alcanzado la capacidad maxima.
//        /// </summary>
//        //// <param name="kiosco">Kiosco al que se agrega la golosina.</param>
//        //// <param name="golosina">Golosina a agregar.</param>
//        /// <returns>Kiosco con la golosina agregada.</returns>
//        public static Kiosco<T> operator +(Kiosco<T> kiosco, T golosina)
//        {
//            if (kiosco.Golosinas.Count < kiosco.capacidadGolosinasDistintas)
//            {
//                if (kiosco != golosina) //si la golosina no esta en el kiosco, la agrego
//                {
//                    kiosco.Golosinas.Add(golosina);
//                    GolosinaAgregadaExitosamente?.Invoke($"Se agrego la golosina con el codigo de barra: {golosina.Codigo} exitosamente");
//                }
//                else
//                {
//                    GolosinaYaEstaEnLista?.Invoke("La golosina ya esta en el kiosco");
//                }
//            }
//            else
//            {
//                CapacidadMaximaAlcanzada?.Invoke("No se puede agregar mas, se alcanzo la capacidad maxima del kiosco.");
//            }
//            return kiosco;
//        }

//        /// <summary>
//        /// Elimina una golosina del kiosco si esta presente.
//        /// </summary>
//        //// <param name="kiosco">Kiosco del que se elimina la golosina.</param>
//        //// <param name="golosina">Golosina a eliminar.</param>
//        /// <returns>Kiosco con la golosina eliminada.</returns>
//        public static Kiosco<T> operator -(Kiosco<T> kiosco, T golosina)
//        {
//            if (kiosco.Golosinas.Count > 0)
//            {
//                if (kiosco == golosina)//si la golosina esta en el kiosco, la saco
//                {
//                    kiosco.Golosinas.Remove(golosina);
//                    GolosinaEliminadaExitosamente?.Invoke($"Se elimino la golosina con codigo de barra: {golosina.Codigo} exitosamente.");
//                }
//                else
//                {
//                    GolosinaYaEstaEnLista?.Invoke($"La golosina {golosina.Codigo} ya no esta en el kiosco.");
//                }
//            }
//            return kiosco;
//        }

//        /// <summary>
//        /// Agrega una lista de golosinas al kiosco si no se supera la capacidad maxima.
//        /// </summary>
//        //// <param name="kiosco">Kiosco al que se agregan las golosinas.</param>
//        //// <param name="listaGolosina">Lista de golosinas a agregar.</param>
//        /// <returns>Kiosco con las golosinas agregadas.</returns>
//        public static Kiosco<T> operator +(Kiosco<T> kiosco, List<T> listaGolosina)
//        {
//            if (kiosco.Golosinas.Count + listaGolosina.Count <= kiosco.capacidadGolosinasDistintas)
//            {
//                if (listaGolosina != null)
//                {
//                    kiosco.Golosinas.AddRange(listaGolosina);
//                }
//                else
//                {
//                    Console.WriteLine("Error, no se puede operar valores nulos");
//                }
//            }
//            else
//            {
//                Console.WriteLine("No se puede agregar mas, es la capacidad maxima del kiosco");
//            }
//            return kiosco;
//        }
//        #endregion

//        #region Operadores de igualdad //DOCUMENTAR MEJOR

//        /// <summary>
//        /// Determina si una golosina esta en el kiosco.
//        /// </summary>
//        //// <param name="kiosco">El kiosco en el que se busca la golosina.</param>
//        //// <param name="golosina">La golosina a buscar.</param>
//        /// <returns>true si la golosina esta en el kiosco; de lo contrario, false.</returns>
//        public static bool operator ==(Kiosco<T> kiosco, T golosina)
//        {
//            bool estaEnKiosco = false;

//            foreach (Golosina item in kiosco.Golosinas)
//            {
//                if (item == golosina)
//                {
//                    estaEnKiosco = true;
//                    break;
//                }
//            }
//            return estaEnKiosco;
//        }
//        public static bool operator !=(Kiosco<T> kiosco, T golosina)
//        {
//            return !(kiosco == golosina); // va hacia el ==
//        }
//        #endregion

//        #region Operadores implicitos y explicitos
//        /// <summary>
//        /// Convierte el kiosco en una lista de golosinas implicitamente.
//        /// </summary>
//        //// <param name="kiosco">Kiosco a convertir.</param>
//        public static implicit operator List<T>(Kiosco<T> kiosco)
//        {
//            return kiosco.Golosinas;
//        }

//        /// <summary>
//        /// Convierte el kiosco en una cadena de texto explicitamente.
//        /// </summary>
//        //// <param name="kiosco">Kiosco a convertir.</param>
//        public static explicit operator string(Kiosco<T> kiosco)
//        {
//            return $"Kiosco con {kiosco.Golosinas.Count} golosinas";
//        }
//        #endregion

//        #region Metodos de object sobrescritos
//        /// <summary>
//        /// Determina si el objeto actual es igual a otro objeto.
//        /// </summary>
//        //// <param name="obj">Objeto a comparar.</param>
//        /// <returns>true si el objeto es igual al objeto actual; de lo contrario, false.</returns>
//        public override bool Equals(object? obj)
//        {
//            if (obj is T golosina)
//            {
//                return this == golosina;
//            }
//            else if (obj is Kiosco<T> otherKiosco)
//            {
//                return this.Golosinas.SequenceEqual(otherKiosco.Golosinas);
//            }
//            return false;
//        }

//        public override int GetHashCode() //lo agregue para que no me tire advertencia
//        {
//            throw new NotImplementedException();
//        }
//        #endregion
//    }
//}










//using Entidades.Interfaces;
//using System.Runtime.CompilerServices;
//using System.Text;

//namespace Entidades.JerarquiaYContenedora
//{

//    /// <summary>
//    /// Representa un kiosco que almacena golosinas.
//    /// </summary>
//    public class Kiosco<T> : IOrdenable<T> where T : Golosina
//    {
//        #region Atributos
//        private List<T> golosinas;
//        private int capacidadGolosinasDistintas;
//        //private string detalle = "";    //inicializo asi no me tira advertencia
//        #endregion

//        #region Eventos
//        public static event MensajeKioscoHandler CapacidadMaximaAlcanzada; //lo hice estatic asi los puedo poner en +
//        public static event MensajeKioscoHandler GolosinaYaEstaEnLista;
//        public static event MensajeKioscoHandler GolosinaAgregadaExitosamente;
//        public static event MensajeKioscoHandler GolosinaEliminadaExitosamente;
//        public static event MensajeKioscoHandler GolosinaModificadaExitosamente;

//        #endregion

//        #region Propiedades
//        public List<T> Golosinas
//        {
//            get { return golosinas; }
//        }

//        public int CapacidadGolosinasDistintas
//        {
//            get { return capacidadGolosinasDistintas; }
//            set { capacidadGolosinasDistintas = value; }
//        }
//        #endregion

//        #region Constructores

//        /// <summary>
//        /// Constructor sin parametros que inicializa la lista de golosinas y establece una capacidad predeterminada.
//        /// </summary>
//        public Kiosco()
//        {
//            golosinas = new List<T>();
//            capacidadGolosinasDistintas = 4;
//        }
//        public Kiosco(int capacidadGolosinasDistintas) : this()
//        {
//            this.capacidadGolosinasDistintas = capacidadGolosinasDistintas;
//        }
//        #endregion

//        #region Metodos Mostrar y calcular

//        /// <summary>
//        /// Muestra una lista de golosinas en un formato adecuado para un visor.
//        /// </summary>
//        /// <returns>Una cadena con la lista de golosinas.</returns>
//        public string MostrarListaEnVisor()
//        {
//            StringBuilder sb = new StringBuilder();

//            foreach (T golosina in Golosinas)
//            {
//                sb.AppendLine(golosina.MostrarEnVisor());
//            }
//            return sb.ToString();
//        }

//        public string MostrarListaEnVisorDetalle()
//        {
//            StringBuilder sb = new StringBuilder();
//            sb.AppendLine("============================================= LISTA DE GOLOSINAS ==========================================");
//            foreach (T golosina in Golosinas)
//            {
//                sb.AppendLine(golosina.MostrarEnVisor());
//            }
//            double precioTotal = CalcularPrecioTotal();

//            sb.AppendLine("\n============================================= PRECIOS TOTAL =============================================");
//            sb.AppendLine($"  TOTAL: ${precioTotal.ToString()}");
//            sb.AppendLine("========================================================================================================\n");
//            return sb.ToString();
//        }



//        /// <summary>
//        /// Calcula el precio total de todas las golosinas en el kiosco.
//        /// </summary>
//        /// <returns>El precio total de todas las golosinas.</returns>
//        public double CalcularPrecioTotal()
//        {
//            double precioTotal = 0;

//            foreach (T golosina in golosinas)
//            {
//                precioTotal += golosina.CalcularPrecioFinal();
//            }

//            return precioTotal;
//        }

//        #endregion

//        #region Metodos de Ordenamiento

//        public void Ordenar<TPropiedad1, TPropiedad2>(Func<T, TPropiedad1> selector1, Func<T, TPropiedad2> selector2, bool ascendente)
//        {
//            if (ascendente)
//            {
//                Golosinas.Sort((g1, g2) =>
//                {
//                    int resultado = Comparar(selector1(g1), selector1(g2));
//                    if (resultado == 0)
//                    {
//                        resultado = Comparar(selector2(g1), selector2(g2));
//                    }
//                    return resultado;
//                });
//            }
//            else
//            {
//                Golosinas.Sort((g1, g2) =>
//                {
//                    int resultado = Comparar(selector1(g2), selector1(g1));
//                    if (resultado == 0)
//                    {
//                        resultado = Comparar(selector2(g2), selector2(g1));
//                    }
//                    return resultado;
//                });
//            }
//        }

//        private int Comparar<TPropiedad>(TPropiedad valor1, TPropiedad valor2)
//        {
//            if (valor1 is IComparable comparable)
//            {
//                return comparable.CompareTo(valor2);
//            }
//            throw new ArgumentException("Los tipos de propiedad no son comparables.");
//        }


//        #endregion

//        #region Operadores suma y resta

//        /// <summary>
//        /// Agrega una golosina al kiosco si no excede la capacidad maxima.
//        /// </summary>
//        //// <param name="kiosco">El kiosco al que se agrega la golosina.</param>
//        //// <param name="golosina">La golosina a agregar.</param>
//        /// <returns>El kiosco con la golosina agregada.</returns>
//        public static Kiosco<T> operator +(Kiosco<T> kiosco, T golosina)
//        {
//            if (kiosco.Golosinas.Count < kiosco.capacidadGolosinasDistintas)
//            {
//                if (kiosco != golosina) //si la golosina no esta en el kiosco, la agrego
//                {
//                    kiosco.Golosinas.Add(golosina);
//                    GolosinaAgregadaExitosamente.Invoke($"Se agrego la golosina con el codigo de barra: {golosina.Codigo} exitosamente");
//                }
//                else
//                {
//                    //Console.WriteLine("La golosina ya esta en el kiosco");
//                    GolosinaYaEstaEnLista.Invoke("La golosina ya esta en el kiosco");
//                    //throw new InvalidOperationException("La golosina ya esta en el kiosco.");
//                }
//            }
//            else
//            {

//                CapacidadMaximaAlcanzada.Invoke("No se puede agregar más, se alcanzó la capacidad máxima del kiosco.");
//            }
//            return kiosco;
//        }

//        /// <summary>
//        /// Elimina una golosina del kiosco, solo si esta.
//        /// </summary>
//        //// <param name="kiosco">El kiosco del que se elimina la golosina.</param>
//        //// <param name="golosina">La golosina a eliminar.</param>
//        /// <returns>El kiosco con la golosina eliminada.</returns>
//        public static Kiosco<T> operator -(Kiosco<T> kiosco, T golosina)
//        {
//            if (kiosco.Golosinas.Count > 0)
//            {
//                if (kiosco == golosina)//si la golosina esta en el kiosco, la saco
//                {
//                    kiosco.Golosinas.Remove(golosina);
//                    GolosinaEliminadaExitosamente.Invoke($"Se elimino la golosina con codigo de barra: {golosina.Codigo} exitosamente.");
//                }
//                else
//                {
//                    GolosinaYaEstaEnLista?.Invoke($"La golosina {golosina.Codigo} ya está en el kiosco.");
//                }
//            }
//            else
//            {
//                CapacidadMaximaAlcanzada?.Invoke("No se puede agregar más, se alcanzó la capacidad máxima del kiosco.");
//            }
//            return kiosco;
//        }

//        /// <summary>
//        /// Agrega una lista de golosinas al kiosco si no excede la capacidad maxima.
//        /// </summary>
//        //// <param name="kiosco">El kiosco al que se agregan las golosinas.</param>
//        //// <param name="listaGolosina">La lista de golosinas a agregar.</param>
//        /// <returns>El kiosco con las golosinas agregadas.</returns>
//        public static Kiosco<T> operator +(Kiosco<T> kiosco, List<T> listaGolosina)
//        {
//            if (kiosco.Golosinas.Count + listaGolosina.Count <= kiosco.capacidadGolosinasDistintas)
//            {
//                if (listaGolosina != null)
//                {
//                    kiosco.Golosinas.AddRange(listaGolosina);
//                }
//                else
//                {
//                    Console.WriteLine("Error, no se puede operar valores nulos");
//                }
//            }
//            else
//            {
//                Console.WriteLine("No se puede agregar mas, es la capacidad maxima del kiosco");
//            }
//            return kiosco;
//        }
//        #endregion

//        #region Operadores de igualdad

//        /// <summary>
//        /// Determina si una golosina esta en el kiosco.
//        /// </summary>
//        //// <param name="kiosco">El kiosco en el que se busca la golosina.</param>
//        //// <param name="golosina">La golosina a buscar.</param>
//        /// <returns>true si la golosina esta en el kiosco; de lo contrario, false.</returns>
//        public static bool operator ==(Kiosco<T> kiosco, T golosina)
//        {
//            bool estaEnKiosco = false;

//            foreach (Golosina item in kiosco.Golosinas)
//            {
//                if (item == golosina)
//                {
//                    estaEnKiosco = true;
//                    break;
//                }
//            }
//            return estaEnKiosco;
//        }
//        public static bool operator !=(Kiosco<T> kiosco, T golosina)
//        {
//            return !(kiosco == golosina); // va hacia el ==
//        }
//        #endregion

//        #region Operadores implicitos y explicitos

//        public static implicit operator List<T>(Kiosco<T> kiosco)
//        {
//            return kiosco.Golosinas;
//        }

//        // Conversión explícita de Kiosco<T> a string
//        public static explicit operator string(Kiosco<T> kiosco)
//        {
//            return $"Kiosco con {kiosco.Golosinas.Count} golosinas";
//        }
//        #endregion

//        #region Metodos de object sobrescritos
//        //VER SI ESTA BIEN, DEJE COMENTADO EL VIEJO PARA VER SI CAMBIARLO O NO
//        public override bool Equals(object? obj)
//        {
//            if (obj is T golosina)
//            {
//                return this == golosina;
//            }
//            else if (obj is Kiosco<T> otherKiosco)
//            {
//                return this.Golosinas.SequenceEqual(otherKiosco.Golosinas);
//            }
//            return false;
//        }
//        //        public override bool Equals(object? obj)
//        //        {
//        //            bool estaEnKiosco = false;


//        //            if (obj is Golosina)
//        //            {
//        //                Golosina golosina = (Golosina)obj;

//        //                foreach (Golosina item in this.Golosinas)
//        //                {
//        //                    if (item == golosina)
//        //                    {
//        //                        estaEnKiosco = true;
//        //                    }
//        //                }
//        //            }
//        //            return estaEnKiosco;
//        //        }

//        public override int GetHashCode() //lo agregue para que no me tire advertencia
//        {
//            throw new NotImplementedException();
//        }

//        #endregion

//    }
//}



//----------------------------------



//using Entidades.Interfaces;
//using System.Text;

//namespace Entidades
//{

//    /// <summary>
//    /// Representa un kiosco que almacena golosinas.
//    /// </summary>
//    public class Kiosco : IOrdenable, ICalculable
//    {
//        #region Atributos
//        private List<Golosina> golosinas;       // lista de golosinas disponibles en el kiosco
//        private int capacidadGolosinasDistintas;   //Capacidad maxima de tipos diferentes de golosinas que el kiosco puede almacenar.
//        private string detalle = "";    //inicializo asi no me tira advertencia
//        #endregion

//        #region Propiedades
//        public List<Golosina> Golosinas
//        {
//            get { return this.golosinas; }
//        }

//        public int CapacidadGolosinasDistintas
//        {
//            get { return this.capacidadGolosinasDistintas; }
//            set { this.capacidadGolosinasDistintas = value; }
//        }
//        public string Detalle
//        {
//            get
//            {
//                StringBuilder sb = new StringBuilder();
//                sb.AppendLine("=============== LISTA DE GOLOSINAS ===============");

//                foreach (Golosina golosina in Golosinas)
//                {
//                    if (golosina is Chocolate)// si golosina es un Chocolate
//                    {
//                        sb.AppendLine(((Chocolate)golosina).ToString());//lo casteo para tener ese metodo
//                    }
//                    else if (golosina is Chicle)
//                    {
//                        sb.AppendLine(((Chicle)golosina).ToString());
//                    }
//                    else if (golosina is Chupetin)
//                    {
//                        sb.AppendLine(((Chupetin)golosina).ToString());
//                    }
//                }
//                double precioTotal = CalcularPrecioTotal();

//                sb.AppendLine("\n=============== PRECIOS TOTAL ===============");
//                sb.AppendLine($"         ${precioTotal.ToString()}");
//                sb.AppendLine("===============================================\n");

//                return sb.ToString();
//            }
//        }
//        #endregion

//        #region Constructores

//        /// <summary>
//        /// Constructor sin parametros que inicializa la lista de golosinas y establece una capacidad predeterminada.
//        /// </summary>
//        public Kiosco()
//        {
//            this.golosinas = new List<Golosina>();
//            this.capacidadGolosinasDistintas = 3;
//        }
//        public Kiosco(int capacidadGolosinasDistintas) : this()
//        {
//            this.capacidadGolosinasDistintas = capacidadGolosinasDistintas;
//        }
//        #endregion

//        #region Metodos Mostrar y calcular

//        /// <summary>
//        /// Muestra una lista de golosinas en un formato adecuado para un visor.
//        /// </summary>
//        /// <returns>Una cadena con la lista de golosinas.</returns>
//        public string MostrarListaEnVisor()
//        {
//            StringBuilder sb = new StringBuilder();

//            List<Golosina> listaLocalGolosinas = this.Golosinas;

//            foreach (Golosina golosina in listaLocalGolosinas)
//            {
//                if (golosina is Chocolate)// si golosina es un Chocolate
//                {
//                    sb.AppendLine(((Chocolate)golosina).MostrarEnVisor()); //lo casteo para tener ese metodo
//                }
//                else if (golosina is Chicle)
//                {
//                    sb.AppendLine(((Chicle)golosina).MostrarEnVisor());
//                }
//                else if (golosina is Chupetin)
//                {
//                    sb.AppendLine(((Chupetin)golosina).MostrarEnVisor());
//                }
//            }
//            return sb.ToString();
//        }

//        /// <summary>
//        /// Muestra los detalles de todas las golosinas en un formato adecuado para un visor y mas prolijo.
//        /// </summary>
//        /// <returns>Una cadena con los detalles de todas las golosinas.</returns>
//        public string MostrarDetalleEnVisor()
//        {
//            StringBuilder sb = new StringBuilder();

//            List<Golosina> listaLocalGolosinas = this.Golosinas;

//            int totalChocolates = 0;
//            int totalChicles = 0;
//            int totalChupetines = 0;
//            int totalGolosinas = 0;

//            double totalPrecioChocolates = 0;
//            double totalPrecioChicles = 0;
//            double totalPrecioChupetines = 0;

//            sb.AppendLine("============== LISTA DE GOLOSINAS ==============");

//            foreach (Golosina golosina in listaLocalGolosinas)
//            {
//                if (golosina is Chocolate)// si golosina es un Chocolate
//                {
//                    sb.AppendLine(((Chocolate)golosina).MostrarEnVisor());//lo casteo para tener ese metodo
//                    totalChocolates += golosina.Cantidad;
//                    totalPrecioChocolates += golosina.CalcularPrecioFinal();
//                }
//                else if (golosina is Chicle)
//                {
//                    sb.AppendLine(((Chicle)golosina).MostrarEnVisor());
//                    totalChicles += golosina.Cantidad;
//                    totalPrecioChicles += golosina.CalcularPrecioFinal();
//                }
//                else if (golosina is Chupetin)
//                {
//                    sb.AppendLine(((Chupetin)golosina).MostrarEnVisor());
//                    totalChupetines += golosina.Cantidad;
//                    totalPrecioChupetines += golosina.CalcularPrecioFinal();
//                }
//            }
//            totalGolosinas = totalChocolates + totalChicles + totalChupetines;
//            double precioTotal = CalcularPrecioTotal();
//            sb.AppendLine("================================================");
//            sb.AppendLine("");
//            sb.AppendLine("");
//            sb.AppendLine("================= CANTIDADES ===================");
//            sb.AppendLine($"Total de Chocolates: {totalChocolates}");
//            sb.AppendLine($"Total de Chicles: {totalChicles}");
//            sb.AppendLine($"Total de Chupetines: {totalChupetines}");
//            sb.AppendLine($"Total de Golosinas: {totalGolosinas}");
//            sb.AppendLine("================================================");
//            sb.AppendLine("");
//            sb.AppendLine("==================== PRECIOS ====================");
//            sb.AppendLine($"Precio total de Chocolates: ${totalPrecioChocolates:F2}");
//            sb.AppendLine($"Precio total de Chicles: ${totalPrecioChicles:F2}");
//            sb.AppendLine($"Precio toal de Chupetines: ${totalPrecioChupetines:F2}");
//            sb.AppendLine("================================================");
//            sb.AppendLine($"  TOTAL: ${precioTotal:F2}");
//            sb.AppendLine("================================================");
//            sb.AppendLine("");

//            return sb.ToString();
//        }

//        /// <summary>
//        /// Calcula el precio total de todas las golosinas en el kiosco.
//        /// </summary>
//        /// <returns>El precio total de todas las golosinas.</returns>
//        public double CalcularPrecioTotal()
//        {
//            double precioTotal = 0;

//            foreach (Golosina golosina in this.Golosinas)
//            {
//                precioTotal += golosina.CalcularPrecioFinal();
//            }
//            return precioTotal;
//        }

//        #endregion

//        #region Metodos de Ordenamiento
//        /// <summary>
//        /// Ordena las golosinas por codigo de barra.
//        /// </summary>
//        //// <param name="ascendente">Si es true, ordena de forma ascendente; de lo contrario, de forma descendente.</param>
//        void IOrdenable.OrdenarPorCodigo(bool ascendente)
//        {
//            if (ascendente)
//            {
//                this.Golosinas.Sort((golosina1, golosina2) => golosina1.Codigo.CompareTo(golosina2.Codigo));
//            }
//            else
//            {
//                this.Golosinas.Sort((golosina1, golosina2) => golosina2.Codigo.CompareTo(golosina1.Codigo));
//            }
//        }
//        void IOrdenable.OrdenarPorPrecio(bool ascendente)
//        {
//            if (ascendente)
//            {
//                this.Golosinas.Sort((golosina1, golosina2) => golosina1.Precio.CompareTo(golosina2.Precio));
//            }
//            else
//            {
//                this.Golosinas.Sort((golosina1, golosina2) => golosina2.Precio.CompareTo(golosina1.Precio));
//            }
//        }
//        void IOrdenable.OrdenarPorPeso(bool ascendente)
//        {
//            if (ascendente)
//            {
//                this.Golosinas.Sort((golosina1, golosina2) => golosina1.Peso.CompareTo(golosina2.Peso));
//            }
//            else
//            {
//                this.Golosinas.Sort((golosina1, golosina2) => golosina2.Peso.CompareTo(golosina1.Peso));
//            }
//        }
//        void IOrdenable.OrdenarPorCantidad(bool ascendente)
//        {
//            if (ascendente)
//            {
//                this.Golosinas.Sort((golosina1, golosina2) => golosina1.Cantidad.CompareTo(golosina2.Cantidad));
//            }
//            else
//            {
//                this.Golosinas.Sort((golosina1, golosina2) => golosina2.Cantidad.CompareTo(golosina1.Cantidad));
//            }
//        }

//        //public void OrdenarGolosinasPorCodigo()
//        //{

//        //}

//        #endregion

//        #region Operadores suma y resta

//        /// <summary>
//        /// Agrega una golosina al kiosco si no excede la capacidad maxima.
//        /// </summary>
//        //// <param name="kiosco">El kiosco al que se agrega la golosina.</param>
//        //// <param name="golosina">La golosina a agregar.</param>
//        /// <returns>El kiosco con la golosina agregada.</returns>
//        public static Kiosco operator +(Kiosco kiosco, Golosina golosina)
//        {
//            if (kiosco.Golosinas.Count < kiosco.capacidadGolosinasDistintas)
//            {
//                if (kiosco != golosina) //si la golosina no esta en el kiosco, la agrego
//                {
//                    kiosco.Golosinas.Add(golosina);
//                }
//                else
//                {
//                    Console.WriteLine("La golosina ya esta en el kiosco");
//                    //throw new InvalidOperationException("La golosina ya esta en el kiosco.");
//                }
//            }
//            else
//            {

//                Console.WriteLine("No se puede agregar mas, se alanzo la capacidad maxima del kiosco");
//            }
//            return kiosco;
//        }

//        /// <summary>
//        /// Elimina una golosina del kiosco, solo si esta.
//        /// </summary>
//        //// <param name="kiosco">El kiosco del que se elimina la golosina.</param>
//        //// <param name="golosina">La golosina a eliminar.</param>
//        /// <returns>El kiosco con la golosina eliminada.</returns>
//        public static Kiosco operator -(Kiosco kiosco, Golosina golosina)
//        {
//            if (kiosco.Golosinas.Count > 0)
//            {
//                if (kiosco == golosina)//si la golosina esta en el kiosco, la saco
//                {
//                    kiosco.Golosinas.Remove(golosina);
//                }
//                else
//                {
//                    Console.WriteLine("La golosina no esta en el kiosco");
//                }
//            }
//            else
//            {
//                Console.WriteLine("El kiosco no tiene golosinas");
//            }
//            return kiosco;
//        }

//        /// <summary>
//        /// Agrega una lista de golosinas al kiosco si no excede la capacidad maxima.
//        /// </summary>
//        //// <param name="kiosco">El kiosco al que se agregan las golosinas.</param>
//        //// <param name="listaGolosina">La lista de golosinas a agregar.</param>
//        /// <returns>El kiosco con las golosinas agregadas.</returns>
//        public static Kiosco operator +(Kiosco kiosco, List<Golosina> listaGolosina)
//        {
//            if (kiosco.Golosinas.Count + listaGolosina.Count <= kiosco.capacidadGolosinasDistintas)
//            {
//                if (listaGolosina != null)
//                {
//                    kiosco.Golosinas.AddRange(listaGolosina);
//                }
//                else
//                {
//                    Console.WriteLine("Error, no se puede operar valores nulos");
//                }
//            }
//            else
//            {
//                Console.WriteLine("No se puede agregar mas, es la capacidad maxima del kiosco");
//            }
//            return kiosco;
//        }
//        #endregion

//        #region Operadores de igualdad

//        /// <summary>
//        /// Determina si una golosina esta en el kiosco.
//        /// </summary>
//        //// <param name="kiosco">El kiosco en el que se busca la golosina.</param>
//        //// <param name="golosina">La golosina a buscar.</param>
//        /// <returns>true si la golosina esta en el kiosco; de lo contrario, false.</returns>
//        public static bool operator ==(Kiosco kiosco, Golosina golosina)
//        {
//            bool estaEnKiosco = false;

//            foreach (Golosina item in kiosco.Golosinas)
//            {
//                if (item == golosina)
//                {
//                    estaEnKiosco = true;
//                    break;
//                }
//            }
//            return estaEnKiosco;
//        }
//        public static bool operator !=(Kiosco kiosco, Golosina golosina)
//        {
//            return !(kiosco == golosina); // va hacia el ==
//        }
//        #endregion

//        #region Operadores implicitos y explicitos

//        /// <summary>
//        /// Convierte un kiosco en una lista de golosinas implicitamente.
//        /// </summary>
//        //// <param name="kiosco">El kiosco a convertir.</param>
//        public static implicit operator List<Golosina>(Kiosco kiosco)
//        {
//            return kiosco.Golosinas;
//        }

//        /// <summary>
//        /// Convierte un kiosco en una cadena explicitamente.
//        /// </summary>
//        //// <param name="kiosco">El kiosco a convertir.</param>
//        public static explicit operator string(Kiosco kiosco)
//        {
//            return kiosco.ToString();  // ME TIRA ADVERTENCIA
//        }
//        #endregion

//        #region Metodos de object sobrescritos
//        public override bool Equals(object? obj)
//        {
//            bool estaEnKiosco = false;


//            if (obj is Golosina)
//            {
//                Golosina golosina = (Golosina)obj;

//                foreach (Golosina item in this.Golosinas)
//                {
//                    if (item == golosina)
//                    {
//                        estaEnKiosco = true;
//                    }
//                }
//            }
//            return estaEnKiosco;
//        }

//        public override int GetHashCode() //lo agregue para que no me tire advertencia
//        {
//            throw new NotImplementedException();
//        }

//        #endregion
//    }
//}
