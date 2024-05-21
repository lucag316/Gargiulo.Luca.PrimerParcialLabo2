using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Chicle : Golosina
    {
        #region Atributos
        private string elasticidad; //mucha, poca, normal, etc
        private string duracionSabor; 
        #endregion

        #region Propiedades
        public string Elasticidad { get { return this.elasticidad; } }
        public string DuracionSabor { get { return this.duracionSabor; } }
        #endregion

        #region Constructor
        public Chicle(int codigo, float peso, double precio, int cantidad) : base(codigo, peso, precio, cantidad)
        {
            this.elasticidad = "nada";
            this.duracionSabor = "poca";
        }
        public Chicle(int codigo, float peso, double precio, int cantidad, string elasticidad) : this(codigo, peso, precio, cantidad)
        {
            this.elasticidad = elasticidad;
        }
        public Chicle(int codigo, float peso, double precio, int cantidad, string elasticidad, string duracionSabor) : this(codigo, peso, precio, cantidad, elasticidad)
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

            if (base.Equals(obj) && obj is Chicle chicle)
            {
                if (this.Elasticidad == chicle.Elasticidad && this.DuracionSabor == chicle.DuracionSabor) //aca no se si poner this.codigo == chocolate.codigo
                {
                    mismoChicle = true;
                }
            }
            return mismoChicle;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Metodos sobrescritos
        public override double CalcularPrecioFinal()
        {
            double precioFinal = base.CalcularPrecioFinal();
            //si compro mas de 5 chicles aplico 15% de descuento
            if (Cantidad > 5) //aca no se si tendria que poner this.Cantidad
            {
                precioFinal *= 0.85;
            }
            return precioFinal;
        }
        public override string MostrarEnVisor()
        {
            string mensaje = $"Elasticidad: {this.elasticidad} - Duracion del sabor: {this.duracionSabor}";
            //fijarme si poner todo o no, para no repetir codigo
            return mensaje;
        }
        #endregion

        #region Sobrecargas de operadores de igualdad
        public static bool operator ==(Chicle chicle1, Chicle chicle2)
        {
            bool mismoChicle = false;

            if (chicle1.Equals(chicle2))// en Equals comparo codigo y peso, decia que tenia que usarlo en ==
            {
                mismoChicle = true;
            }
            return mismoChicle;
        }
        public static bool operator !=(Chicle chicle1, Chicle chicle2)
        {
            return !(chicle1 == chicle2); // aca llamo al == de g1 y g2
        }
        #endregion
    }
}
