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

        public Chicle(int codigo, float peso, double precio) : base(codigo, peso, precio)
        {
            this.elasticidad = "nada";
            this.duracionSabor = "poca";
        }
        public Chicle(int codigo, float peso, double precio, string elasticidad) : this(codigo, peso, precio)
        {
            this.elasticidad = elasticidad;
            this.duracionSabor = "poca";
        }
        public Chicle(int codigo, float peso, double precio, string elasticidad, string duracionSabor) : this(codigo, peso, precio, elasticidad)
        {
            this.duracionSabor = duracionSabor;
        }
        #endregion

        #region Metodos Sobrescritos
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
            return HashCode.Combine(base.GetHashCode(), this); //ver bien que hace esto, no entendi bien
        }

        public override string MostrarEnVisor()
        {
            string mensaje = $"Elasticidad: {this.elasticidad} - Duracion del sabor: {this.duracionSabor}";
            //fijarme si poner todo o no, para no repetir codigo
            return mensaje;
        }

        #endregion

        #region Sobrecargas
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
