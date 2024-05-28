using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Chicle : Golosina
    {
        #region Atributos
        protected ENivelesDeElasticidad elasticidad;
        protected ENivelesDuracionDeSabor duracionSabor;
        #endregion

        #region Propiedades
        [JsonPropertyName("elasticidad")]
        public ENivelesDeElasticidad Elasticidad
        {
            get { return this.elasticidad; }
            set { this.elasticidad = value; }
        }

        [JsonPropertyName("duracionSabor")]
        public ENivelesDuracionDeSabor DuracionSabor
        {
            get { return this.duracionSabor; }
            set { this.duracionSabor = value; }
        }
        #endregion

        #region Constructores
        public Chicle() : base()//constructor sin parametros para poder usar JSON
        {
            this.elasticidad = ENivelesDeElasticidad.Media;
            this.duracionSabor = ENivelesDuracionDeSabor.Media;
        }
        public Chicle(int codigo, float peso, double precio, int cantidad) : base(codigo, peso, precio, cantidad)
        {
            //this.elasticidad = ENivelesDeElasticidad.Media;
            //this.duracionSabor = ENivelesDuracionDeSabor.Media;
        }
        public Chicle(int codigo, float peso, double precio, int cantidad, ENivelesDeElasticidad elasticidad) : this(codigo, peso, precio, cantidad)
        {
            this.elasticidad = elasticidad;
        }
        public Chicle(int codigo, float peso, double precio, int cantidad, ENivelesDeElasticidad elasticidad, ENivelesDuracionDeSabor duracionSabor) : this(codigo, peso, precio, cantidad, elasticidad)
        {
            this.duracionSabor = duracionSabor;
        }
        #endregion

        #region Metodos ToString, Equals, GetHashCode Sobrescritos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("=============== CHICLE =================");
            sb.Append(base.ToString());
            sb.AppendLine($"Elasticidad: {this.elasticidad}");
            sb.AppendLine($"Duracion del sabor: {this.duracionSabor}");
            sb.AppendLine("========================================\n");

            return sb.ToString();
        }
        public override bool Equals(object? obj)
        {
            bool mismoChicle = false;

            if (obj is Chicle)
            {
                if (((Chicle)obj) == this)
                {
                    mismoChicle = true;
                }
            }
            return mismoChicle;
        }

        //public override int GetHashCode()
        //{
        //    throw new NotImplementedException();
        //}
        #endregion

        #region Metodos sobrescritos

        /// <summary>
        /// Muestra la informacion del chicle en un formato adecuado para un visor.
        /// </summary>
        /// <returns>Una cadena que contiene la informacion del chicle.</returns>
        public override string MostrarEnVisor()
        {
            string mensaje = $"CHICLE: Codigo de barra: {base.Codigo} - Precio: ${base.Precio} - Peso: {base.Peso}g - Cantidad: {base.Cantidad} unidades - Elasticidad: {this.elasticidad} - Duracion del sabor: {this.duracionSabor}";
            return mensaje;
        }

        /// <summary>
        /// Calcula el precio final del chicle, si se compra mas de 5 chicles, aplico 15% de descuento.
        /// </summary>
        /// <returns>El precio final del chicle.</returns>
        public override double CalcularPrecioFinal()
        {
            double precioFinal = base.CalcularPrecioFinal();

            if (this.Cantidad > 5)
            {
                precioFinal *= 0.85;
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
            //bool mismoChicle = false;

            //if (chicle1.Codigo == chicle2.Codigo && chicle1.Peso == chicle2.Peso)
            //{
            //    mismoChicle = true;
            //}

            //return mismoChicle;
            return (Golosina)chicle1 == (Golosina)chicle2;
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
