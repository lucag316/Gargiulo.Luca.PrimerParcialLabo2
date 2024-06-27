using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;

namespace Entidades.JerarquiaYContenedora
{
    [Serializable]
    [XmlInclude(typeof(Chocolate))]
    [XmlInclude(typeof(Chicle))]
    [XmlInclude(typeof(Chupetin))]
    //[DataContract] //para JSON
    public abstract class Golosina
    {
        #region Atributos
        protected int codigo; //seria como si fuera el codigo de barra
        protected float precio;
        protected float peso;
        protected int cantidad;
        #endregion

        #region Eventos
        //public event Action CodigoInvalido; //puede ser que codigo este entre 0 y 100 y que si no esta se lance este que es codigo invalido y algun otro
        //public event Action CodigoNulo;
        //public event Action CodigoNegativo; //declaro el evento
        //public event Action CodigoMuyAlto;
        //public event Action CodigoNoNumerico;

        //public event MiDelegado CodigoNulo;
        public event MiDelegado CodigoNegativo; //declaro el evento
        public event MiDelegado CodigoMuyAlto;
        public event MiDelegado CodigoNoNumerico;

        #endregion
        //FALTA EL THIS A TODAS LAS  PROPIEDADES NO SE PORQUE
        #region Propiedades
        public int Codigo
        {
            get { return codigo; }
            //set { codigo = value; }
            set
            {
                int valorParseado;
                if (value < 0)
                {
                    //this.CodigoNegativo(value);
                    this.CodigoNegativo.Invoke(this.codigo);// esta es otr forma
                }
                else if (value > 100)
                {
                    this.CodigoMuyAlto(value);
                }
                else if (!int.TryParse(value.ToString(), out valorParseado))
                {
                    this.CodigoNoNumerico(value);
                }
                else
                {
                    this.codigo = value;
                }
            }
        }
        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public float Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        #endregion

        #region Constructores
        public Golosina()
        {
            codigo = 0;
            precio = 0;
            peso = 0;
            cantidad = 0;

            this.CodigoNegativo += MostrarMensajeCodigoInvalido;
            this.CodigoMuyAlto += MostrarMensajeCodigoInvalido;
            this.CodigoNoNumerico += MostrarMensajeCodigoInvalido;

            this.CodigoNegativo += MostrarMensajeCodigoNegativo;
            this.CodigoMuyAlto += MostrarMensajeCodigoMuyAlto;
            this.CodigoNoNumerico += MostrarMensajeCodigoNoNumerico;

        }
        public Golosina(int codigo) : this()
        {
            this.codigo = codigo;
        }
        public Golosina(int codigo, float peso) : this(codigo)
        {
            this.peso = peso;
        }
        public Golosina(int codigo, float peso, float precio) : this(codigo, peso)
        {
            this.precio = precio;
        }
        public Golosina(int codigo, float peso, float precio, int cantidad) : this(codigo, peso, precio)
        {
            this.cantidad = cantidad;
        }
        #endregion

        #region Metodos de Object sobrescritos

        /// <summary>
        /// Devuelve una cadena que representa la golosina.
        /// </summary>
        public override string ToString()// si no sobreescribo el ToString, devuelve namespace.clase
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Codigo: {codigo}");    // no hace falta castearlo a string
            sb.AppendLine($"Precio: ${precio}");
            sb.AppendLine($"Peso: {peso} g");
            sb.AppendLine($"Cantidad: {cantidad} unidades");

            return sb.ToString();
        }

        /// <summary>
        /// Determina si el objeto especificado es igual a la golosina actual.
        /// </summary>
        /// <returns>True si el objeto especificado es igual a la golosina actual, sino false
        public override bool Equals(object? obj) //Equals determinna si dos objetos son iguales
        {
            bool mismaGolosina = false;

            if (obj is Golosina)
            {
                if ((Golosina)obj == this) // voy al == de Golosina y Golosina
                {
                    mismaGolosina = true;
                }
            }
            return mismaGolosina;
        }

        /// <summary>
        /// Devuelve un código hash para el objeto actual.
        /// </summary>
        public override int GetHashCode() //SI LO POMGO ME TIRA UN ERROR AL GUARDAR XML, porque no se utiliza el metodo//lo pongo para que no me tire advertiencia, que hago?
        {
            //throw new NotImplementedException();
            return HashCode.Combine(codigo, precio, peso, cantidad); // si le pongo esto, se arregla
        }
        #endregion

        #region Metodos virtuales y abstractos

        /// <summary>
        /// Lo utilizan sus clases derivadas, devuelve una cadena con los detalles de las golosinas, en el visor
        /// </summary>
        public virtual string MostrarEnVisor()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Codigo de barra: {Codigo} - Precio: ${Precio} - Peso: {Peso}g - Cantidad: {Cantidad} unidades - ");

            return sb.ToString();
        }

        public abstract double CalcularPrecioFinal();

        #endregion

        #region Sobrecargas de operadores de igualdad

        /// <summary>
        /// Determina si dos golosinas son iguales comparando sus codigos y pesos.
        /// </summary>
        /// <returns>True si las golosinas son iguales, sino false
        public static bool operator ==(Golosina golosina1, Golosina golosina2)
        {
            bool mismaGolosina = false;

            if (ReferenceEquals(golosina1, golosina2))
            {
                mismaGolosina = true;
            }

            if (golosina1 is null || golosina2 is null) // le pongo is en vez de == para que no me advierta lo de valores null
            {
                mismaGolosina = false;
            }
            else if (!(golosina1 is null && golosina2 is null))
            {
                if (golosina1.Codigo == golosina2.Codigo && golosina1.precio == golosina2.precio)
                {
                    mismaGolosina = true;
                }
            }
            return mismaGolosina;
        }

        /// <summary>
        /// Determina si dos golosinas son diferentes.
        /// </summary>
        /// <returns>True si las golosinas son diferentes, sino false
        public static bool operator !=(Golosina golosina1, Golosina golosina2)
        {
            return !(golosina1 == golosina2); // aca llamo al == de g1 y g2
        }
        #endregion

        #region Manejadores de eventos
        public void MostrarMensajeCodigoNegativo(int numero)
        {
            Console.WriteLine($"Error: El codigo no puede ser negativo. Codigo ingresado: {numero}");
        }
        public void MostrarMensajeCodigoMuyAlto(int numero)
        {
            Console.WriteLine($"Error: El codigo no puede ser mayor que 100. Codigo ingresado: {numero}");
        }
        public void MostrarMensajeCodigoNoNumerico(int numero)
        {
            Console.WriteLine($"Error: El codigo debe ser numerico. Codigo ingresado: {numero}");
        }
        public void MostrarMensajeCodigoInvalido(int numero)
        {
            Console.WriteLine($"Codigo invalido. Codigo ingresado: {numero}");
        }
        #endregion

        #region Metodos Auxiliares

        private static int ValidarNoNegativo(int valor, string nombrePropiedad)
        {
            // si hago esto, tengo que asignar los parametros de los constructores, a sus propiedades, no a atributos, sino, no validaria
            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException(nombrePropiedad, $"{nombrePropiedad} no puede ser negativo");
                //throw new MiExcepcion($"{nombrePropiedad} no puede ser negativo");//esta es con mi funcion 
            }
            return valor;
        }
        /*
         private static T ValidarNoNegativo<T>(T valor, string nombrePropiedad) where T : IComparable<T>
        {
            if (valor.CompareTo(default) < 0)
            {
                throw new ArgumentOutOfRangeException(nombrePropiedad, $"{nombrePropiedad} no puede ser negativo");
            }
            return valor;
        }
         */
        #endregion
    }
}
