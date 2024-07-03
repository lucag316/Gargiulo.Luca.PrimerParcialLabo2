using Entidades.Interfaces;
using System.Runtime.CompilerServices;
using System.Text;

namespace Entidades.JerarquiaYContenedora
{

    /// <summary>
    /// Representa un kiosco que almacena varios productos.
    /// </summary>
    //// <typeparam name="T">Tipo de producto que puede almacenar el kiosco.</typeparam>
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
        //public static event MensajeKioscoHandler? ProductoModificadoExitosamente;
        #endregion

        #region Propiedades
        /// <summary>
        /// Lista de productos almacenadas en el kiosco.
        /// </summary>
        public List<T> Productos
        {
            get { return this.productos; }
        }
        /// <summary>
        /// Capacidad maxima de productos distintos que puede contener el kiosco.
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
        //// <param name="capacidadGolosinasDistintas">Capacidad maxima de productos distintos que puede contener el kiosco.</param>
        public Kiosco(int capacidadProductosDistintos) : this()
        {
            this.capacidadProductosDistintos = capacidadProductosDistintos;
        }
        #endregion

        #region Metodos de visualizacion y calculo

        /// <summary>
        /// Muestra la lista de productos en un formato adecuado para un visor.
        /// </summary>
        /// <returns>Cadena con la lista de productos.</returns>
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
        /// Muestra la lista de productos junto con el precio total en un formato adecuado para un visor.
        /// </summary>
        /// <returns>Cadena con la lista de productos y el precio total.</returns>
        public string MostrarListaEnVisorDetalle()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("============================================= LISTA DE PRODUCTOS ==========================================");
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
        /// Calcula el precio total de todas las productos en el kiosco.
        /// </summary>
        /// <returns>Precio total de todas lOs productos.</returns>
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
        /// Ordena los productos del kiosco segun los selectores especificados y el criterio de orden ascendente o descendente.
        /// </summary>
        //// <typeparam name="TPropiedad1">Tipo de la primera propiedad para ordenar.</typeparam>
        //// <typeparam name="TPropiedad2">Tipo de la segunda propiedad para ordenar.</typeparam>
        //// <param name="selector1">Selector de la primera propiedad.</param>
        //// <param name="selector2">Selector de la segunda propiedad.</param>
        //// <param name="ascendente">true para ordenar en orden ascendente, false para ordenar en orden descendente.</param>
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
        /// Agrega un producto al kiosco si no se ha alcanzado la capacidad maxima.
        /// </summary>
        //// <param name="kiosco">Kiosco al que se agrega el producto.</param>
        //// <param name="producto">Producto a agregar.</param>
        /// <returns>Kiosco con el producto agregado.</returns>
        public static Kiosco<T> operator +(Kiosco<T> kiosco, T producto)
        {
            if (kiosco.Productos.Count < kiosco.capacidadProductosDistintos)
            {
                if (kiosco != producto) //si el producto no esta en el kiosco, la agrego
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
        /// Elimina un producto del kiosco si esta presente.
        /// </summary>
        //// <param name="kiosco">Kiosco del que se elimina el producto.</param>
        //// <param name="producto">Producto a eliminar.</param>
        /// <returns>Kiosco con el producto eliminado.</returns>
        public static Kiosco<T> operator -(Kiosco<T> kiosco, T producto)
        {
            if (kiosco.Productos.Count > 0)
            {
                if (kiosco == producto)//kiosco.productos.Contains(producto))//si el producto esta en el kiosco, la saco
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
        /// Agrega una lista de productos al kiosco si no excede la capacidad maxima.
        /// </summary>
        //// <param name="kiosco">Kiosco al que se agregan los productos.</param>
        //// <param name="listaProductos">Lista de productos a agregar.</param>
        /// <returns>Kiosco con los productos agregados.</returns>
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

        #region Operadores de igualdad

        /// <summary>
        /// Determina si un producto esta en el kiosco.
        /// </summary>
        //// <param name="kiosco">El kiosco en el que se busca el producto.</param>
        //// <param name="producto">El producto a buscar.</param>
        /// <returns>true si el producto esta en el kiosco; de lo contrario, false.</returns>
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
        /// Convierte el kiosco en una lista de productos implicitamente.
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
            return $"Kiosco con {kiosco.Productos.Count} productos";
        }
        #endregion

        #region Metodos de object sobrescritos
        /// <summary>
        /// Determina si el objeto actual es igual a otro objeto.
        /// </summary>
        //// <param name="obj">Objeto a comparar.</param>
        /// <returns>true si el objeto es igual al objeto actual; de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            bool esIgual = true;
            if (obj is null)
                esIgual = false; 

            if (ReferenceEquals(this, obj)) 
                esIgual = true;

            if (obj is T producto)
            {
                esIgual = this == producto;         // Uso el operador == de Kiosco<T>
            }
            else if (obj is Kiosco<T> otroKiosco)       // Si obj es otro Kiosco<T>
            {
                esIgual = this.Productos.SequenceEqual(otroKiosco.Productos);   // Compara las listas de Productos
            }

            return esIgual;
        }

        public override int GetHashCode() //lo agregue para que no me tire advertencia
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
