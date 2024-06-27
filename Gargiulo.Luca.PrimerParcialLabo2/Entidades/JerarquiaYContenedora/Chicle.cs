using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Entidades.Interfaces;
using Entidades.Excepciones;

namespace Entidades.JerarquiaYContenedora
{
    [Serializable]
    public class Chicle : Golosina, ICalculos
    {
        #region Atributos
        protected ENivelesDeElasticidad elasticidad;
        protected ENivelesDuracionDeSabor duracionSabor;
        protected bool blanqueadorDental;
        //protected ESaboresChicle saborChicle;
        #endregion

        #region Propiedades
        //[JsonPropertyName("elasticidad")]
        public ENivelesDeElasticidad Elasticidad
        {
            get { return elasticidad; }
            set { elasticidad = value; }
        }

        //[JsonPropertyName("duracionSabor")]
        public ENivelesDuracionDeSabor DuracionSabor
        {
            get { return duracionSabor; }
            set { duracionSabor = value; }
        }

        public bool BlanqueadorDental
        {
            get { return blanqueadorDental; }
            set { blanqueadorDental = value; }
        }
        #endregion

        #region Constructores
        public Chicle() : base()
        {
            elasticidad = ENivelesDeElasticidad.Media;
            duracionSabor = ENivelesDuracionDeSabor.Media;
            blanqueadorDental = false;
        }
        public Chicle(int codigo, float peso, float precio, int cantidad) : base(codigo, peso, precio, cantidad)
        {
            //this.elasticidad = ENivelesDeElasticidad.Media;
            //this.duracionSabor = ENivelesDuracionDeSabor.Media;
        }
        public Chicle(int codigo, float peso, float precio, int cantidad, ENivelesDeElasticidad elasticidad) : this(codigo, peso, precio, cantidad)
        {
            this.elasticidad = elasticidad;
        }
        public Chicle(int codigo, float peso, float precio, int cantidad, ENivelesDeElasticidad elasticidad, ENivelesDuracionDeSabor duracionSabor) : this(codigo, peso, precio, cantidad, elasticidad)
        {
            this.duracionSabor = duracionSabor;
        }
        public Chicle(int codigo, float peso, float precio, int cantidad, ENivelesDeElasticidad elasticidad, ENivelesDuracionDeSabor duracionSabor, bool blanqueadorDental) : this(codigo, peso, precio, cantidad, elasticidad, duracionSabor)
        {
            this.blanqueadorDental = blanqueadorDental;
        }
        #endregion

        #region Metodos de Object sobrescritos

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=============== CHICLE =================");
            sb.Append(base.ToString());
            sb.AppendLine($"Elasticidad: {elasticidad}");
            sb.AppendLine($"Duracion del sabor: {duracionSabor}");
            sb.AppendLine($"Blanqueador dental: {blanqueadorDental}");
            sb.AppendLine("========================================\n");

            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            bool mismaGolosina = base.Equals(obj);

            bool mismoChicle = false;

            if (obj is Chicle)
            {
                if ((Chicle)obj == this && mismaGolosina == true)
                {
                    mismoChicle = true;
                }
            }
            return mismoChicle;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(codigo, precio, peso, cantidad, elasticidad, duracionSabor, blanqueadorDental);
        }
        #endregion

        #region Metodos Interfaces

        double ICalculos.CalcularDescuento(double precio)
        {
            return precio * 0.85;
        }

        #endregion

        #region Metodos sobrescritos

        /// <summary>
        /// Muestra la informacion del chicle en un formato adecuado para un visor.
        /// </summary>
        /// <returns>Una cadena que contiene la informacion del chicle.</returns>
        public override string MostrarEnVisor()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CHICLE:");
            sb.Append(base.MostrarEnVisor());
            sb.Append($"Elasticidad: {elasticidad} - Duracion del sabor: {duracionSabor} - Blanqueador dental: {blanqueadorDental}");

            return sb.ToString();
        }

        /// <summary>
        /// Calcula el precio final del chicle, si se compra mas de 5 chicles, aplico 15% de descuento.
        /// </summary>
        /// <returns>El precio final del chicle.</returns>
        public override double CalcularPrecioFinal()
        {
            double precioFinal = Precio * Cantidad;

            if (Cantidad > 5)
            {
                precioFinal = ((ICalculos)this).CalcularDescuento(precioFinal);
            }
            if (cantidad < 0)
            {
                throw new MiExcepcion("La cantidad de golosinas no puede ser negativa");// fijarme si lla verifique en otro lado
            }
            return precioFinal;
        }
        #endregion

        #region Sobrecargas de operadores de igualdad

        /// <summary>
        /// Determina si dos instancias de Chicle son iguales.
        /// </summary>
        /// <returns>true si las instancias son iguales, sino false
        public static bool operator ==(Chicle chicle1, Chicle chicle2)
        {
            bool mismoGolosina = chicle1 == (Golosina)chicle2;

            bool mismoChicle = mismoGolosina && chicle1.Elasticidad == chicle2.Elasticidad &&
                                                chicle1.DuracionSabor == chicle2.DuracionSabor &&
                                                chicle1.blanqueadorDental == chicle2.blanqueadorDental;

            return mismoChicle;
        }

        /// <summary>
        /// Determina si dos instancias de chicle son diferentes.
        /// </summary>
        public static bool operator !=(Chicle chicle1, Chicle chicle2)
        {
            return !(chicle1 == chicle2);
        }
        #endregion
    }
}
